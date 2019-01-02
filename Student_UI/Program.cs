using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Login login = new Login();
            if (login.IsCheckConnection())
            {                
                Application.Run(login);
            }            

            if (login.isAuthenticated)
            {                
                Application.Run(new Dashboard(login.userModel));                
            }
        }
    }
}
