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
        public bool isConnected = false;
        public UserModel userModel;

        private Validation validation = new Validation();
        private ErrorHelper errorHelper = new ErrorHelper();        

        public Login()
        {
            InitializeComponent();
            Program.currentForm = this;
            errorHelper.CheckRequest(SetConnection, this);
            errorHelper.ShowError();
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
            ResetPassword resetPasswordWindow = new ResetPassword();            
            resetPasswordWindow.Show();            
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (validation.IsTextBoxValid(usernameTextBox.Text, passwordTextBox.Text, ref Program.outputMessage))
            {
                errorHelper.CheckRequest(GetLogin, this);                
            }

            errorHelper.ShowError();
        }
       
        private void Password_PreviewInput(object sender, KeyPressEventArgs e)
        {
            validation.Password_KeyPress(sender, e);
        }

        private void Username_PreviewInput(object sender, KeyPressEventArgs e)
        {
            validation.Username_KeyPress(sender, e);
        }

        private void GetLogin()
        {
            Encryptor encryptor = new Encryptor();

            StudentService.StudentServiceClient studentService = new StudentService.StudentServiceClient();

            ResponseModel<UserModel> userResponseModel = encryptor.ResponseDeserializer<UserModel>
               (studentService.Login(usernameTextBox.Text, passwordTextBox.Text));

            if (userResponseModel.IsSuccess)
            {
                userModel = userResponseModel.Model;
                isAuthenticated = true;
                this.Close();
            }
            else
            {
                Program.outputMessage += userResponseModel.OutputMessage;
            }
        }

        private void SetConnection()
        {
            StudentService.StudentServiceClient studentService = new StudentService.StudentServiceClient();

            isConnected = studentService.CheckConnection();

            if (!isConnected)
            {
                studentService.Abort();
                this.Close();
            }
        }
    }
}
