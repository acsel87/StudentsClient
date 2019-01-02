using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_UI.Helpers
{
    public class Validation
    {
        private const int usernameMinLength = 3;        
        private const int usernameMaxLength = 10;
        private const int passwordMinLength = 5;
        private const int passwordMaxLength = 10;

        public bool IsTextBoxValid(string username, string password, ref string errorMessage)
        {
            bool output = true;
            Regex usernameRegex = new Regex(@"^[\w._]*$");

            if (string.IsNullOrEmpty(username))
            {
                errorMessage += "Please enter username\n";
                output = false;
            }
            else
            {
                if (!usernameRegex.IsMatch(username))
                {
                    errorMessage += "Username can contain only letters, digits, underscore'_' and dot'.'\n";
                    output = false;
                }                

                if (!char.IsLetter(username[0]))
                {
                    errorMessage += "Username must start with a letter\n";
                    output = false;
                }

                if (username.Length < usernameMinLength)
                {
                    errorMessage += "Username must have at least " + usernameMinLength + " characters\n";
                    output = false;
                }
                else if (username.Length > usernameMaxLength)
                {
                    errorMessage += "Username can't have more than " + usernameMaxLength + " characters\n";
                    output = false;
                }
            }

            if (password != null)
            {
                if (string.IsNullOrEmpty(password))
                {
                    errorMessage += "Please enter password\n";
                    output = false;
                }
                else
                {
                    if (Regex.IsMatch(password, @"\s"))
                    {
                        errorMessage += "Password cannot contain spaces\n";
                        output = false;
                    }

                    if (password.Length < passwordMinLength)
                    {
                        errorMessage += "Password must have at least " + passwordMinLength + " characters\n";
                        output = false;
                    }
                    else if (password.Length > passwordMaxLength)
                    {
                        errorMessage += "Password can't have more than " + passwordMaxLength + " characters\n";
                        output = false;
                    }
                }
            }

            return output;
        }

        public void Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((sender as TextBox).Text.Length > passwordMaxLength - 1 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void Username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((sender as TextBox).Text.Length > usernameMaxLength - 1 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (!char.IsLetter(e.KeyChar) && (sender as TextBox).Text.Length == 0)
            {
                e.Handled = true;
            }

            if (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != 46 && e.KeyChar != 95)
            {
                e.Handled = true;
            }
        }
    }
}
