using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;

namespace Mirrors_Edge_Catalyst_SpeedOMeter
{
    class Program : ApplicationContext
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Checks if launched with Administrator
            if (LaunchedAsAdministrator())
            {
                Application.Run(new Menu()); // Starts Menu
            }
            else
            {
                MessageBox.Show("Please run SpeedOMeter as Administrator");
            }
        }

        private static bool LaunchedAsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
