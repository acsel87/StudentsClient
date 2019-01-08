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
            ResponseModel<List<StudentModel>> studentsResponseModel = encryptor.ResponseDeserializer<List<StudentModel>>
                (studentService.GetStudents(currentUser.AccessToken));
            ResponseModel<List<TeacherModel>> teachersResponseModel = encryptor.ResponseDeserializer<List<TeacherModel>>
                (studentService.GetTeachers(currentUser.AccessToken));

            studentComboBox.ValueMember = "StudentID";
            studentComboBox.DisplayMember = "StudentName";

            teacherComboBox.ValueMember = "TeacherID";
            teacherComboBox.DisplayMember = "Class";

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
            }
            else
            {
                errorMessage += teachersResponseModel.ErrorMessage + "\n";
                errorMessage += studentsResponseModel.ErrorMessage;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
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

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage);
                errorMessage = string.Empty;
            }
        }

        private void TeacherComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (teacherComboBox.SelectedValue != null)
            {
                selectedTeacher = teacherComboBox.SelectedItem as TeacherModel;
                RefreshTeacherInfo();
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage);
                errorMessage = string.Empty;
            }
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

        private void RefreshGrades()
        {
            ResponseModel<List<GradeModel>> gradesResponseModel = encryptor.ResponseDeserializer<List<GradeModel>>
                (studentService.GetGrades(selectedStudent.StudentID, selectedTeacher.TeacherID, currentUser.AccessToken));

            if (gradesResponseModel.IsSuccess)
            {
                gradeDataGridView.Columns[0].DataPropertyName = "Grade";
                gradeDataGridView.Columns[1].DataPropertyName = "GradeDate";
                gradeDataGridView.Columns[2].DataPropertyName = "GradeNotes";
                gradeDataGridView.DataSource = gradesResponseModel.Model;
            }
            else
            {
                errorMessage += gradesResponseModel.ErrorMessage;
                CheckResponseError(gradesResponseModel.ErrorAction);                
            }
        }

        private void GetStudentRating()
        {
            ResponseModel<int> ratingResponseModel = encryptor.ResponseDeserializer<int>(studentService.GetStudentRating
                (selectedStudent.StudentID, selectedTeacher.TeacherID, currentUser.AccessToken));

            if (ratingResponseModel.IsSuccess)
            {
                rateComboBox.SelectedIndex = ratingResponseModel.Model;
            }
            else
            {
                errorMessage += ratingResponseModel.ErrorMessage;
                CheckResponseError(ratingResponseModel.ErrorAction);                
            }
        }

        public void CheckResponseError(string errorAction)
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
            DialogResult result = MessageBox.Show(errorMessage);
            errorMessage = string.Empty;
            if (result == DialogResult.OK)
            {
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
            
            ResponseModel<string> rateResponseModel = encryptor.ResponseDeserializer<string>
            (studentService.RateTeacher(selectedTeacher.TeacherID, rate, currentUser.AccessToken));

            if (rateResponseModel.IsSuccess)
            {
                MessageBox.Show(rateResponseModel.Model);
            }
            else
            {
                MessageBox.Show(rateResponseModel.ErrorMessage);
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
            int rowindex = gradeDataGridView.SelectedRows[0].Index;
            GradeModel selectedGrade = currentGrades[rowindex];

            StudentService.GradeModel gradeModel = new StudentService.GradeModel()
            {
                GradeID = selectedGrade.GradeID,
                StudentID = selectedGrade.StudentID,
                TeacherID = selectedGrade.TeacherID,
                Grade = gradeComboBox.SelectedItem.ToString(),
                // assign GradeDate in api
                GradeNotes = gradeNotesTextBox.Text
            };

            ResponseModel<string> gradeResponseModel = encryptor.ResponseDeserializer<string>
                (studentService.ModifyGrades(isNewGrade, gradeModel, currentUser.AccessToken));

            if (!gradeResponseModel.IsSuccess)
            {
                errorMessage += gradeResponseModel.ErrorMessage;
            }

            RefreshGrades();

            editGradeButton.Visible = true;
            addGradeButton.Visible = true;
            gradePanel.Visible = false;

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage);
                errorMessage = string.Empty;
            }
        }

        private void ShowGradePanel(bool newGrade)
        {
            if (gradeDataGridView.SelectedRows.Count == 1)
            {
                if (newGrade)
                {
                    applyButton.Tag = "Add";

                    gradeNotesTextBox.Text = "Add notes";
                    gradeNotesTextBox.Font = new Font(this.Font, FontStyle.Italic);
                    gradeNotesTextBox.ForeColor = Color.Gray;
                    gradeComboBox.SelectedIndex = 0;
                }
                else
                {
                    applyButton.Tag = "Edit";
                    gradeNotesTextBox.Font = this.Font;
                    gradeNotesTextBox.ForeColor = Color.Black;

                    gradeNotesTextBox.Text = gradeDataGridView.SelectedCells[2].Value.ToString();
                    gradeComboBox.SelectedIndex = grades[gradeDataGridView.SelectedCells[0].Value.ToString()];
                }

                gradePanel.Visible = true;
                editGradeButton.Visible = false;
                addGradeButton.Visible = false;
            }            
        }
    }
}
