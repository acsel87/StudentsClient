using Student_UI.Helpers;
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
    public partial class SignUp : Form
    {
        Validation validation = new Validation();

        public SignUp()
        {
            InitializeComponent();
        }

        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            string errorMessage = "";

            if (validation.IsTextBoxValid(usernameTextBox.Text, passwordTextBox.Text, ref errorMessage) & IsSignUpValid(ref errorMessage))
            {
                StudentService.StudentServiceClient studentService = new StudentService.StudentServiceClient();
                StudentService.ResponseModelOfstring responseModel = new StudentService.ResponseModelOfstring();
                responseModel = studentService.SignUp(usernameTextBox.Text, passwordTextBox.Text, accountTypeComboBox.SelectedItem.ToString());

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
