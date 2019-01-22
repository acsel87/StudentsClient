using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_UI.Helpers
{
    public class ErrorHelper
    {
        public void CheckRequest(Action action, Form activeForm)
        {
            try
            {
                if (Program.currentForm != null && !Program.currentForm.IsDisposed)
                {
                    action();
                }                
            }
            catch (TimeoutException)
            {                
                Program.outputMessage = "Request timed out";                
            }
            catch (System.ServiceModel.FaultException)
            {                
                Program.outputMessage = "Service down";                
            }
            catch (System.ServiceModel.EndpointNotFoundException)
            {                
                Program.outputMessage = "Connection to service failed";
            }
        }

        public void ShowError()
        {
            if (!string.IsNullOrEmpty(Program.outputMessage))
            {
                MessageBox.Show(Program.outputMessage);
                Program.outputMessage = string.Empty;
            }
        }
    }
}
