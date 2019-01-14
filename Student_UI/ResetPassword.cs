using Student_UI.Helpers;
using Student_UI.Models;
using System;
using System.Windows.Forms;

namespace Student_UI
{
    public partial class ResetPassword : Form
    {
        Validation validation = new Validation();

        public ResetPassword()
        {
            InitializeComponent();
        }

        private void SendInstructionsButton_Click(object sender, EventArgs e)
        {
            string errorMessage = "";

            if (validation.IsTextBoxValid(usernameTextBox.Text, null, ref errorMessage))
            {
                Encryptor encryptor = new Encryptor();

                StudentService.StudentServiceClient studentService = new StudentService.StudentServiceClient();

                ResponseModel<string[]> resetPasswordResponseModel = encryptor.ResponseDeserializer<string[]>
                  (studentService.ResetPassword(usernameTextBox.Text));

                if (resetPasswordResponseModel.IsSuccess)
                {
                    Instructions instructionsWindow = new Instructions(resetPasswordResponseModel.Model[0], resetPasswordResponseModel.Model[1]);
                    instructionsWindow.Show();

                    usernameTextBox.ReadOnly = true;
                    instructionsLabel.Visible = true;
                    sendInstructionsButton.Visible = false;
                }
                else
                {
                    MessageBox.Show(resetPasswordResponseModel.ErrorMessage);
                }
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }

        private void Username_PreviewInput(object sender, KeyPressEventArgs e)
        {
            validation.Username_KeyPress(sender, e);
        }
    }
}
