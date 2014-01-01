using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controller
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
            try {
                Application.Run(new Main());
            } catch (Exception err) {
                MessageBox.Show("Critical error: " + Environment.NewLine + err.ToString());
                Trace.TraceError("Critical error." + Environment.NewLine + err.ToString());
            }
        }
    }
}
