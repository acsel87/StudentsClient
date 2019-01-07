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
    public partial class Login : Form
    {        
        public bool isAuthenticated;
        public UserModel userModel;

        Validation validation = new Validation();

        public Login()
        {
            InitializeComponent();
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            using (SignUp signUpWindow = new SignUp())
            {
                signUpWindow.ShowDialog();
            } 
        }

        private void ResetPasswordButton_Click(object sender, EventArgs e)
        {
            using (ResetPassword resetPasswordWindow = new ResetPassword())
            {
                resetPasswordWindow.ShowDialog();
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string errorMessage = string.Empty;

            if (validation.IsTextBoxValid(usernameTextBox.Text, passwordTextBox.Text, ref errorMessage))
            {
                Encryptor encryptor = new Encryptor();

                StudentService.StudentServiceClient studentService = new StudentService.StudentServiceClient();

                ResponseModel<UserModel> userResponseModel = encryptor.ResponseDeserializer<UserModel>
                   (studentService.Login(usernameTextBox.Text, passwordTextBox.Text));
               
                if (userResponseModel.IsSuccess)
                {
                    userModel = new UserModel() { Username = userResponseModel.Model.Username, AccessToken = userResponseModel.Model.AccessToken };
                    isAuthenticated = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(userResponseModel.ErrorMessage);
                }                
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }
       
        private void Password_PreviewInput(object sender, KeyPressEventArgs e)
        {
            validation.Password_KeyPress(sender, e);
        }

        private void Username_PreviewInput(object sender, KeyPressEventArgs e)
        {
            validation.Username_KeyPress(sender, e);
        }

        public bool IsCheckConnection()
        {
            StudentService.StudentServiceClient studentService = new StudentService.StudentServiceClient();
            string message = string.Empty;
            try
            {
                message = studentService.CheckConnection();
                return true;
            }
            catch (System.ServiceModel.EndpointNotFoundException)
            {
                MessageBox.Show("Connection to service failed");
                studentService.Abort();
                this.Close();
                return false;
            }
        }
    }
}
