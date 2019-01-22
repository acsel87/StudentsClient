using Newtonsoft.Json;
using Student_UI.Helpers;
using Student_UI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_UI
{
    // todo - check iis/api connection
    public partial class Dashboard : Form
    {
        public bool loggedOut = false;
        public static UserModel currentUser;

        public static StudentService.StudentServiceClient studentService = new StudentService.StudentServiceClient();
        private Validation validation = new Validation();
        private Encryptor encryptor = new Encryptor();
        private ErrorHelper errorHelper = new ErrorHelper();
        private StudentModel selectedStudent = new StudentModel();
        private TeacherModel selectedTeacher = new TeacherModel();
        private Dictionary<string, int> grades = new Dictionary<string, int>();       

        public Dashboard(UserModel userModel)
        {            
            InitializeComponent();
            Program.currentForm = this;
            currentUser = userModel;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            CheckAuthentication();
            userLabel.Text = currentUser.Username;       
        }

        private void Dashboard_Shown(object sender, EventArgs e)
        {
            Request(InitialBindings);
            errorHelper.ShowError();
            DisableButtons();
        }

        // initialize students, teachers, grades, username label
        private void InitialBindings()
        {
            ResponseModel<List<StudentModel>> studentsResponseModel = new ResponseModel<List<StudentModel>>();
            ResponseModel<List<TeacherModel>> teachersResponseModel = new ResponseModel<List<TeacherModel>>();

            studentsResponseModel = encryptor.ResponseDeserializer<List<StudentModel>>
            (studentService.GetStudents(currentUser.AccessToken));

            teachersResponseModel = encryptor.ResponseDeserializer<List<TeacherModel>>
            (studentService.GetTeachers(currentUser.AccessToken));           

            gradeDataGridView.AutoGenerateColumns = false;

            grades.Add("A", 0);
            grades.Add("B", 1);
            grades.Add("C", 2);
            grades.Add("D", 3);
            grades.Add("E", 4);
            grades.Add("F", 5);

            gradeDataGridView.Columns[0].DataPropertyName = "Grade";
            gradeDataGridView.Columns[1].DataPropertyName = "GradeDate";
            gradeDataGridView.Columns[2].DataPropertyName = "GradeNotes";

            if (teachersResponseModel.IsSuccess && studentsResponseModel.IsSuccess)
            {
                teacherComboBox.DataSource = teachersResponseModel.Model;
                studentComboBox.DataSource = studentsResponseModel.Model;

                studentComboBox.ValueMember = "StudentID";
                studentComboBox.DisplayMember = "StudentName";

                teacherComboBox.ValueMember = "TeacherID";
                teacherComboBox.DisplayMember = "Class";
            }
            else
            {
                Program.outputMessage += teachersResponseModel.OutputMessage + "\n";
                Program.outputMessage += studentsResponseModel.OutputMessage;
                CheckResponseError(studentsResponseModel.ErrorAction);
                CheckResponseError(teachersResponseModel.ErrorAction);
            }
        }

        private void DisableButtons()
        {
            if (studentComboBox.SelectedValue == null || teacherComboBox.SelectedValue == null)
            {
                rateButton.Enabled = false;
                addGradeButton.Enabled = false;
            }
        }

        private void StudentComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (studentComboBox.SelectedValue != null)
            {
                SwitchGradePanel(false);

                selectedStudent = studentComboBox.SelectedItem as StudentModel;
                RefreshStudentInfo();
            }
            errorHelper.ShowError();
        }

        private void TeacherComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (teacherComboBox.SelectedValue != null)
            {
                SwitchGradePanel(false);

                selectedTeacher = teacherComboBox.SelectedItem as TeacherModel;
                RefreshTeacherInfo();
            }
            errorHelper.ShowError();
        }

        private void RefreshStudentInfo()
        {
            yearLabel.Text = selectedStudent.Year;

            if (teacherComboBox.SelectedValue != null)
            {
                Request(GetStudentRating);
                Request(GetGrades);
            }
        }

        private void RefreshTeacherInfo()
        {
            teacherLabel.Text = selectedTeacher.TeacherName;
            ratingLabel.Text = selectedTeacher.TeacherRating.ToString() + "/7";

            if (studentComboBox.SelectedValue != null)
            {
                Request(GetGrades);
            }
        }        

        private void GetGrades()
        {
            ResponseModel<List<GradeModel>> gradesResponseModel = new ResponseModel<List<GradeModel>>();

            gradesResponseModel = encryptor.ResponseDeserializer<List<GradeModel>>
            (studentService.GetGrades(selectedStudent.StudentID, selectedTeacher.TeacherID, currentUser.AccessToken));            

            if (gradesResponseModel.IsSuccess)
            {                
                gradeDataGridView.DataSource = gradesResponseModel.Model;
            }
            else
            {
                Program.outputMessage += gradesResponseModel.OutputMessage + "\n";
                CheckResponseError(gradesResponseModel.ErrorAction);
            }
        }

        private void GetStudentRating()
        {
            ResponseModel<int> ratingResponseModel = new ResponseModel<int>();
            
            ratingResponseModel = encryptor.ResponseDeserializer<int>
            (studentService.GetStudentRating(selectedTeacher.TeacherID, currentUser.AccessToken));            

            if (ratingResponseModel.IsSuccess)
            {
                rateComboBox.SelectedIndex = ratingResponseModel.Model;
            }
            else
            {
                Program.outputMessage += ratingResponseModel.OutputMessage + "\n";
                CheckResponseError(ratingResponseModel.ErrorAction);
            }
        }

        private void Request(Action action)
        {            
            errorHelper.CheckRequest(CheckAccessTokenExpiration, this);           
            errorHelper.CheckRequest(action, this);            
        }

        private void CheckAccessTokenExpiration()
        {
            if (currentUser.AccessToken_ExpDate < DateTimeOffset.UtcNow.AddSeconds(-1).ToUnixTimeSeconds()) // if token is expired
            {
                ResponseModel<long> accessTokenResponseModel = new ResponseModel<long>();

                accessTokenResponseModel = encryptor.ResponseDeserializer<long>
                (studentService.GetNewAccessToken(currentUser.RefreshToken, currentUser.AccessToken));
                
                if (accessTokenResponseModel.IsSuccess)
                {
                    currentUser.AccessToken = accessTokenResponseModel.OutputMessage;
                    currentUser.AccessToken_ExpDate = accessTokenResponseModel.Model;
                }
                else
                {
                    Program.outputMessage += accessTokenResponseModel.OutputMessage + "\n";
                    CheckResponseError(accessTokenResponseModel.ErrorAction);
                }
            }
        }

        private void CheckResponseError(string errorAction)
        {
            if (!string.IsNullOrEmpty(errorAction))
            {
                switch (errorAction)
                {
                    case "[LogOut]":
                        LogOut();
                        break;
                    default:
                        break;
                }
            }  
        }

        private void LogOut()
        {
            if (!loggedOut)
            {
                DialogResult result = MessageBox.Show(Program.outputMessage);
                Program.outputMessage = string.Empty;
                if (result == DialogResult.OK)
                {
                    loggedOut = true;
                    this.Close();
                }
            }            
        }

        private void SignOut()
        {            
            studentService.SignOut(currentUser.AccessToken);            
        }
        
        private void CheckAuthentication()
        {
            if (string.IsNullOrEmpty(currentUser.AccessToken))
            {
                MessageBox.Show("Authentication check failed");
                this.Close();
            }
        }

        private void RateButton_Click(object sender, EventArgs e)
        {
            Request(RateTeacher);
            errorHelper.ShowError();
        }

        private void RateTeacher()
        {
            int rate = Convert.ToInt16(rateComboBox.SelectedItem);

            ResponseModel<string> rateResponseModel = new ResponseModel<string>();

            rateResponseModel = encryptor.ResponseDeserializer<string>
            (studentService.RateTeacher(selectedTeacher.TeacherID, rate, currentUser.AccessToken));            

            if (rateResponseModel.IsSuccess)
            {
                MessageBox.Show(rateResponseModel.Model);
            }
            else
            {
                Program.outputMessage = rateResponseModel.OutputMessage + "\n";
                CheckResponseError(rateResponseModel.ErrorAction);                
            }
        }

        private void GradeNotesTextBox_Enter(object sender, EventArgs e)
        {
            if (gradeNotesTextBox.Text.Equals("Add notes"))
            {
                gradeNotesTextBox.Text = string.Empty;
            }

            gradeNotesTextBox.Font = this.Font;
            gradeNotesTextBox.ForeColor = Color.Black;
        }

        private void GradeNotesTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(gradeNotesTextBox.Text))
            {
                gradeNotesTextBox.Text = "Add notes";
                gradeNotesTextBox.Font = new Font(this.Font, FontStyle.Italic);
                gradeNotesTextBox.ForeColor = Color.Gray;
            }
        }

        private void EditGradeButton_Click(object sender, EventArgs e)
        {
            ShowGradePanel(false);
        }

        private void AddGradeButton_Click(object sender, EventArgs e)
        {
            ShowGradePanel(true);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            SwitchGradePanel(false);
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            Request(ApplyGrades);
            Request(GetGrades);

            SwitchGradePanel(false);

            errorHelper.ShowError();
        }

        private void ApplyGrades()
        {
            bool isNewGrade = applyButton.Tag.Equals("Add");

            List<GradeModel> currentGrades = gradeDataGridView.DataSource as List<GradeModel>;

            StudentService.GradeModel gradeModel = new StudentService.GradeModel
            {
                StudentID = selectedStudent.StudentID,
                TeacherID = selectedTeacher.TeacherID,
                Grade = gradeComboBox.SelectedItem.ToString(),
                GradeNotes = gradeNotesTextBox.Text
        };

            if (gradeDataGridView.SelectedRows.Count == 1)
            {
                int rowindex = gradeDataGridView.SelectedRows[0].Index;
                GradeModel selectedGrade = currentGrades[rowindex];
                gradeModel.GradeID = selectedGrade.GradeID;               
            }

            ResponseModel<string> gradeResponseModel = new ResponseModel<string>();

            gradeResponseModel = encryptor.ResponseDeserializer<string>
            (studentService.ModifyGrades(isNewGrade, gradeModel, currentUser.AccessToken));

            if (!gradeResponseModel.IsSuccess)
            {
                Program.outputMessage += gradeResponseModel.OutputMessage + "\n";
                CheckResponseError(gradeResponseModel.ErrorAction);
            }
        }

        private void ShowGradePanel(bool newGrade)
        {            
            if (newGrade)
            {
                applyButton.Tag = "Add";

                gradeNotesTextBox.Text = "Add notes";
                gradeNotesTextBox.Font = new Font(this.Font, FontStyle.Italic);
                gradeNotesTextBox.ForeColor = Color.Gray;
                gradeComboBox.SelectedIndex = 0;

                SwitchGradePanel(true);
            }
            else
            {
                applyButton.Tag = "Edit";

                if (gradeDataGridView.SelectedRows.Count == 1)
                {                   
                    gradeNotesTextBox.Font = this.Font;
                    gradeNotesTextBox.ForeColor = Color.Black;

                    gradeNotesTextBox.Text = gradeDataGridView.SelectedCells[2].Value.ToString();
                    gradeComboBox.SelectedIndex = grades[gradeDataGridView.SelectedCells[0].Value.ToString()];

                    SwitchGradePanel(true);
                }
            }              
        }

        private void SwitchGradePanel(bool visible)
        {
            gradePanel.Visible = visible;
            editGradeButton.Visible = !visible;
            addGradeButton.Visible = !visible;
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            Program.outputMessage = "Logging out...";
            LogOut();
        }        

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {            
            Request(SignOut);            
            studentService.Close();;
        }
    }
}
