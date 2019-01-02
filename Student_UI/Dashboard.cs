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
        StudentService.StudentServiceClient studentService = new StudentService.StudentServiceClient();
        Validation validation = new Validation();
        static UserModel currentUser = new UserModel();
        
        public Dashboard(UserModel userModel)
        {            
            InitializeComponent();
            currentUser = userModel;
            CheckAuthentication();
            userLabel.Text = currentUser.Username;            
        }

        private void CheckAuthentication()
        {
            if (currentUser.AccessToken == "")
            {
                MessageBox.Show("Authentication check failed");
                this.Close();
            }
        }
    }
}
