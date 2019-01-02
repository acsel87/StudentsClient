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
                // send instructions
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
