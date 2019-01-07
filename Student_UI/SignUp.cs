using Student_UI.Helpers;
using Student_UI.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Student_UI
{
    public partial class SignUp : Form
    {
        Validation validation = new Validation();

        public SignUp()
        {
            InitializeComponent();
            GetAccountTypes();
        }
        
        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            string errorMessage = string.Empty;

            if (validation.IsTextBoxValid(usernameTextBox.Text, passwordTextBox.Text, ref errorMessage) & IsSignUpValid(ref errorMessage))
            {
                Encryptor encryptor = new Encryptor();

                StudentService.StudentServiceClient studentService = new StudentService.StudentServiceClient();

                ResponseModel<string> responseModel = encryptor.ResponseDeserializer<string>
                    (studentService.SignUp(usernameTextBox.Text, passwordTextBox.Text, Convert.ToInt16(accountTypeComboBox.SelectedValue)));

                if (responseModel.IsSuccess)
                {
                    DialogResult result = MessageBox.Show(responseModel.Model);

                    if (result == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show(responseModel.ErrorMessage);
                }                
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }

        private void GetAccountTypes()
        {
            Encryptor encryptor = new Encryptor();

            StudentService.StudentServiceClient studentService = new StudentService.StudentServiceClient();

            ResponseModel<List<KeyValuePair<int, string>>> responseModel = encryptor.ResponseDeserializer<List<KeyValuePair<int, string>>>
                (studentService.GetAccountTypes());

            if (responseModel.IsSuccess)
            {
                accountTypeComboBox.ValueMember = "Key";
                accountTypeComboBox.DisplayMember = "Value";
                accountTypeComboBox.DataSource = responseModel.Model;
            }
            else
            {
                MessageBox.Show(responseModel.ErrorMessage);
            }
            
        }

        private bool IsSignUpValid(ref string errorMessage)
        {            
            bool isValid = true;

            if (accountTypeComboBox.SelectedItem == null)
            {
                isValid = false;
                errorMessage += "An Account Type must be selected\n";
            }

            if (!passwordTextBox.Text.Equals(confirmPasswordTextBox.Text))
            {
                isValid = false;
                errorMessage += "Password is not confirmed\n";
            }           

            return isValid;
        }

        private void Password_PreviewInput(object sender, KeyPressEventArgs e)
        {
            validation.Password_KeyPress(sender, e);
        }

        private void Username_PreviewInput(object sender, KeyPressEventArgs e)
        {
            validation.Username_KeyPress(sender, e);
        }
    }
}
