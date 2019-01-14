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
        private StudentService.StudentServiceClient studentService = new StudentService.StudentServiceClient();
        private Validation validation = new Validation();
        private Encryptor encryptor = new Encryptor();
        public static UserModel currentUser = new UserModel();

        private StudentModel selectedStudent = new StudentModel();
        private TeacherModel selectedTeacher = new TeacherModel();

        private Dictionary<string, int> grades = new Dictionary<string, int>();        

        private string errorMessage = string.Empty;

        public Dashboard(UserModel userModel)
        {            
            InitializeComponent();
            currentUser = userModel;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            CheckAuthentication();
            userLabel.Text = currentUser.Username;
            InitialBindings();
        }
        
        private void InitialBindings()
        {
            ResponseModel<List<StudentModel>> studentsResponseModel = new ResponseModel<List<StudentModel>>();
            ResponseModel<List<TeacherModel>> teachersResponseModel = new ResponseModel<List<TeacherModel>>();
           
            try
            {
                studentsResponseModel = encryptor.ResponseDeserializer<List<StudentModel>>
                (studentService.GetStudents(currentUser.AccessToken));

                teachersResponseModel = encryptor.ResponseDeserializer<List<TeacherModel>>
                (studentService.GetTeachers(currentUser.AccessToken));
            }
            catch (TimeoutException)
            {
                {
                    errorMessage = "Request timed out";
                }
            }
            catch (System.ServiceModel.FaultException)
            {
                {
                    errorMessage = "Service down";
                }
            }

            gradeDataGridView.AutoGenerateColumns = false;

            grades.Add("A", 0);
            grades.Add("B", 1);
            grades.Add("C", 2);
            grades.Add("D", 3);
            grades.Add("E", 4);
            grades.Add("F", 5);

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
                errorMessage += teachersResponseModel.ErrorMessage + "\n";
                errorMessage += studentsResponseModel.ErrorMessage;
                LogOut();
            }
        }

        private void StudentComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (studentComboBox.SelectedValue != null)
            {
                selectedStudent = studentComboBox.SelectedItem as StudentModel;
                RefreshStudentInfo();
            }

            ShowError();
        }

        private void TeacherComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (teacherComboBox.SelectedValue != null)
            {
                selectedTeacher = teacherComboBox.SelectedItem as TeacherModel;
                RefreshTeacherInfo();
            }

            ShowError();
        }

        private void RefreshStudentInfo()
        {
            yearLabel.Text = selectedStudent.Year;

            if (teacherComboBox.SelectedValue != null)
            {
                GetStudentRating();
                RefreshGrades();
            }
        }

        private void RefreshTeacherInfo()
        {
            teacherLabel.Text = selectedTeacher.TeacherName;
            ratingLabel.Text = selectedTeacher.TeacherRating.ToString() + "/7";

            if (studentComboBox.SelectedValue != null)
            {
                RefreshGrades();
            }
        }        

        private ResponseModel<T> CheckResponse<T>()
        {
            try
            {
                return new ResponseModel<T>(); // todo - dynamic method to send request
            }
            catch (TimeoutException)
            {
                {
                    return new ResponseModel<T> { ErrorMessage = "Request timed out" };
                }
            }
        }

        private void RefreshGrades()
        {
            ResponseModel<List<GradeModel>> gradesResponseModel = new ResponseModel<List<GradeModel>>();

            try
            {
                gradesResponseModel = encryptor.ResponseDeserializer<List<GradeModel>>
                (studentService.GetGrades(selectedStudent.StudentID, selectedTeacher.TeacherID, currentUser.AccessToken));
            }
            catch (TimeoutException)
            {
                {
                    gradesResponseModel.ErrorMessage = "Request timed out";
                }
            }

            if (gradesResponseModel.IsSuccess)
            {  
                gradeDataGridView.Columns[0].DataPropertyName = "Grade";
                gradeDataGridView.Columns[1].DataPropertyName = "GradeDate";
                gradeDataGridView.Columns[2].DataPropertyName = "GradeNotes";
                gradeDataGridView.DataSource = gradesResponseModel.Model;
            }
            else
            {
                errorMessage += gradesResponseModel.ErrorMessage + "\n";
                CheckResponseError(gradesResponseModel.ErrorAction);                
            }
        }

        // todo - get rating of current user if a student NOT from selected student
        private void GetStudentRating()
        {
            ResponseModel<int> ratingResponseModel = new ResponseModel<int>(); 

            try
            {
                ratingResponseModel = encryptor.ResponseDeserializer<int>
                (studentService.GetStudentRating(selectedStudent.StudentID, selectedTeacher.TeacherID, currentUser.AccessToken));
            }
            catch (TimeoutException)
            {
                {
                    ratingResponseModel.ErrorMessage = "Request timed out";
                }
            }

            if (ratingResponseModel.IsSuccess)
            {
                rateComboBox.SelectedIndex = ratingResponseModel.Model;
            }
            else
            {
                errorMessage += ratingResponseModel.ErrorMessage + "\n";
                CheckResponseError(ratingResponseModel.ErrorAction);                
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

        private void ShowError()
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage);
                errorMessage = string.Empty;
            }
        }

        private void LogOut()
        {
            DialogResult result = MessageBox.Show(errorMessage);
            errorMessage = string.Empty;
            if (result == DialogResult.OK)
            {
                loggedOut = true;
                this.Close();
            }
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
            int rate = Convert.ToInt16(rateComboBox.SelectedItem);

            ResponseModel<string> rateResponseModel = new ResponseModel<string>(); 

            try
            {
                rateResponseModel = encryptor.ResponseDeserializer<string>
                (studentService.RateTeacher(selectedTeacher.TeacherID, rate, currentUser.AccessToken));
            }
            catch (TimeoutException)
            {
                {
                    rateResponseModel.ErrorMessage = "Request timed out";
                }
            }

            if (rateResponseModel.IsSuccess)
            {
                MessageBox.Show(rateResponseModel.Model);
            }
            else
            {
                errorMessage = rateResponseModel.ErrorMessage + "\n";
                CheckResponseError(rateResponseModel.ErrorAction);
                ShowError();
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
            editGradeButton.Visible = true;
            addGradeButton.Visible = true;
            gradePanel.Visible = false;
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            bool isNewGrade = applyButton.Tag.Equals("Add");

            List<GradeModel> currentGrades = gradeDataGridView.DataSource as List<GradeModel>;

            StudentService.GradeModel gradeModel = new StudentService.GradeModel
            {
                StudentID = selectedStudent.StudentID,
                TeacherID = selectedTeacher.TeacherID
            };

            if (gradeDataGridView.SelectedRows.Count == 1)
            {
                int rowindex = gradeDataGridView.SelectedRows[0].Index;
                GradeModel selectedGrade = currentGrades[rowindex];
                gradeModel.GradeID = selectedGrade.GradeID;
                gradeModel.Grade = selectedGrade.Grade;
                gradeModel.GradeNotes = gradeNotesTextBox.Text;
            }

            ResponseModel<string> gradeResponseModel = new ResponseModel<string>(); 

            try
            {
                gradeResponseModel = encryptor.ResponseDeserializer<string>
                (studentService.ModifyGrades(isNewGrade, gradeModel, currentUser.AccessToken));
            }
            catch (TimeoutException)
            {
                {
                    gradeResponseModel.ErrorMessage = "Request timed out";
                }
            }

            if (!gradeResponseModel.IsSuccess)
            {
                errorMessage += gradeResponseModel.ErrorMessage + "\n";
                CheckResponseError(gradeResponseModel.ErrorAction);
            }

            RefreshGrades();

            editGradeButton.Visible = true;
            addGradeButton.Visible = true;
            gradePanel.Visible = false;

            ShowError();
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

                gradePanel.Visible = true;
                editGradeButton.Visible = false;
                addGradeButton.Visible = false;
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

                    gradePanel.Visible = true;
                    editGradeButton.Visible = false;
                    addGradeButton.Visible = false;
                }
            }              
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            errorMessage = "Logging out...";
            LogOut();
        }
    }
}
