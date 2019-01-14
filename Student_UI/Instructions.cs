using Student_UI.Helpers;
using Student_UI.Models;
using System;
using System.Windows.Forms;

namespace Student_UI
{
    public partial class Instructions : Form
    {
        string username;
        string token;

        public Instructions(string _username, string _token)
        {            
            InitializeComponent();

            if (!string.IsNullOrEmpty(_username) && !string.IsNullOrEmpty(_token))
            {
                username = _username;
                token = _token;
            }               

            InitializeEmail();
        }

        private void InitializeEmail()
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(token))
            {
                instructionsTextBox.Text = "You requested a password reset.\nClick the link below.\nLink expires in 30 minutes";
                linkButton.Visible = true;
            }
            else
            {
                instructionsTextBox.Text = "Username invalid";
            }
        }

        private void LinkButton_Click(object sender, EventArgs e)
        {
            Encryptor encryptor = new Encryptor();

            StudentService.StudentServiceClient studentServiceClient = new StudentService.StudentServiceClient();

            ResponseModel<string> linkResponseModel = encryptor.ResponseDeserializer<string>
                  (studentServiceClient.ActivateLink(username, token));

            if (linkResponseModel.IsSuccess)
            {
                ConfirmReset confirmResetWindow = new ConfirmReset(linkResponseModel.Model);
                confirmResetWindow.Show();
            }
            else
            {
                MessageBox.Show(linkResponseModel.ErrorMessage);
            }
        }
    }
}
