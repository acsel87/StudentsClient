using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_UI
{
    static class Program
    {
        public static Form currentForm;
        public static string outputMessage = string.Empty;        

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Login login = new Login();
            if (login.isConnected)
            {
                Application.Run(login);
            }

            if (login.isAuthenticated)
            {
                Dashboard dashboard = new Dashboard(login.userModel);
                Application.Run(dashboard);

                if (dashboard.IsDisposed && dashboard.loggedOut)
                {
                    Application.Restart();
                }
            }
        }
    }
}
