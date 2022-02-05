using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Production
{
    static class Program
    {
        private static Mutex mutex = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            try
            {
                //if (!Properties.Settings.Default.isActivated)
                {
               //     Application.Run(new ActivationFrm());
                }
                // else
                {
                    const string appname = "Digital Shubham";
                    bool creatnew;
                    mutex = new Mutex(true, appname, out creatnew);
                    if (!creatnew)
                    {
                        MessageBox.Show("Application is allready running . . . . . !");
                        return;
                    }
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FrmLogIn());
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
