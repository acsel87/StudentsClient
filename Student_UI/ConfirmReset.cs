using JWT.Algorithms;
using JWT.Builder;
using Student_UI.Helpers;
using Student_UI.Models;
using System;
using System.Windows.Forms;

namespace Student_UI
{
    public partial class ConfirmReset : Form
    {
        private const string secretKey = "NdR4Ce6gS7fGrFkPagzFj5gn7qfDRWt25GDspxxCEuTEFtKvW3yJg2xZZkDtyyYDkEPEdFLqRDf4wUkb7tB2cpxyjWD9EVXQhm6ecUxHaAsaWjyJMGKmbJSsBR7EvwrY";

        Validation validation = new Validation();
        string username;

        public ConfirmReset(string _username)
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(_username))
            {
                username = _username;
            }
            else
            {
                ToggleExpired();
            }            
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            string errorMessage = string.Empty;

            if (validation.IsTextBoxValid(username, newPasswordTextBox.Text, ref errorMessage) & IsSignUpValid(ref errorMessage))
            {
                Encryptor encryptor = new Encryptor();

                StudentService.StudentServiceClient studentService = new StudentService.StudentServiceClient();

                string userToken = CreateUserToken();

                ResponseModel<string> confirmResetResponseModel = encryptor.ResponseDeserializer<string>
                  (studentService.ConfirmReset(userToken, newPasswordTextBox.Text));

                if (confirmResetResponseModel.IsSuccess)
                {                    
                    passwordResetLabel.Text = confirmResetResponseModel.Model;

                    passwordResetLabel.Visible = true;
                    newPasswordTextBox.Enabled = false;
                    confirmPasswordTextBox.Enabled = false;
                    resetButton.Visible = false;
                                       
                }
                else
                {
                    if ( !string.IsNullOrEmpty(confirmResetResponseModel.ErrorAction) &&
                        confirmResetResponseModel.ErrorAction.Equals("[LinkExpired]"))
                    {
                        ToggleExpired();
                    }
                    else
                    {
                        MessageBox.Show(confirmResetResponseModel.ErrorMessage);
                    }
                }
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }

        public string CreateUserToken()
        {            
            return new JwtBuilder()
                        .WithAlgorithm(new HMACSHA256Algorithm())
                        .WithUrlEncoder(new JWT.JwtBase64UrlEncoder())
                        .WithSecret(secretKey)
                        .AddClaim("sub", username)
                        .AddClaim("exp", DateTimeOffset.UtcNow.AddMinutes(5).ToUnixTimeSeconds())
                        .Build();
        }

        private void Password_PreviewInput(object sender, KeyPressEventArgs e)
        {
            validation.Password_KeyPress(sender, e);
        }

        private bool IsSignUpValid(ref string errorMessage)
        {
            if (!newPasswordTextBox.Text.Equals(confirmPasswordTextBox.Text))
            {
                errorMessage += "Password is not confirmed";
                return false;
            }

            return true;
        }

        private void ToggleExpired()
        {
            newPasswordTextBox.Visible = false;
            confirmPasswordTextBox.Visible = false;
            newPassLabel.Visible = false;
            confirmPassLabel.Visible = false;
            resetButton.Visible = false;
            this.Size = new System.Drawing.Size(500, 100);


            passwordResetLabel.Text = "Link expired";
            passwordResetLabel.Visible = true;
        }
    }
}
