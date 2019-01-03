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
        private static UserModel currentUser = new UserModel();

        private StudentModel selectedStudent = new StudentModel();
        private TeacherModel selectedTeacher = new TeacherModel();

        string errorMessage;

        public Dashboard(UserModel userModel)
        {            
            InitializeComponent();
            currentUser = userModel;            
            CheckAuthentication();
            userLabel.Text = currentUser.Username;
            InitialBindings();
        }

        public class ResponseModel<T>
        {
            public T Model { get; set; }
            public bool IsSuccess { get; set; }
            public string ErrorMessage { get; set; } = "";
        }

        public static ResponseModel<T> ResponseDeserializer<T>(string serializedResponse)
        {
            return JsonConvert.DeserializeObject<ResponseModel<T>>(serializedResponse);
        }

        private void InitialBindings()
        {
            ResponseModel<List<StudentModel>> studentsResponseModel = ResponseDeserializer<List<StudentModel>>(studentService.GetStudents());
            ResponseModel<List<TeacherModel>> teachersResponseModel = ResponseDeserializer<List<TeacherModel>>(studentService.GetTeachers());

            studentComboBox.ValueMember = "StudentID";
            studentComboBox.DisplayMember = "StudentName";

            teacherComboBox.ValueMember = "TeacherID";
            teacherComboBox.DisplayMember = "Class";

            gradeDataGridView.AutoGenerateColumns = false;

            string errorMessage = string.Empty;

            if (teachersResponseModel.IsSuccess)
            {
                teacherComboBox.DataSource = teachersResponseModel.Model;
            }
            else
            {
                errorMessage += teachersResponseModel.ErrorMessage;
            }

            if (studentsResponseModel.IsSuccess)
            {  
                studentComboBox.DataSource = studentsResponseModel.Model;
            }
            else
            {
                errorMessage += studentsResponseModel.ErrorMessage;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage);
            }
        }

        private void StudentComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            errorMessage = string.Empty;

            if (studentComboBox.SelectedValue != null)
            {
                selectedStudent = studentComboBox.SelectedItem as StudentModel;
                RefreshStudentInfo();
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage);
            }
        }

        private void TeacherComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            errorMessage = string.Empty;

            if (teacherComboBox.SelectedValue != null)
            {
                selectedTeacher = teacherComboBox.SelectedItem as TeacherModel;
                RefreshTeacherInfo();
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage);
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
            ResponseModel<List<GradeModel>> gradesResponseModel = ResponseDeserializer<List<GradeModel>>(studentService.GetGrades(selectedStudent.StudentID, selectedTeacher.TeacherID));

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
            }
        }

        private void GetStudentRating()
        {
            ResponseModel<int> ratingResponseModel = ResponseDeserializer<int>(studentService.GetStudentRating(selectedStudent.StudentID, selectedTeacher.TeacherID));

            if (ratingResponseModel.IsSuccess)
            {
                rateTextBox.Text = ratingResponseModel.Model.ToString();
            }
            else
            {
                errorMessage += ratingResponseModel.ErrorMessage;
            }
        }

        private void CheckAuthentication()
        {
            if (currentUser.AccessToken == "")
            {
                MessageBox.Show("Authentication check failed");
                this.Close();
            }
        }

        private void RateButton_Click(object sender, EventArgs e)
        {

        }
    }
}
