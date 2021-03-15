using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorRatedPowerAvailable
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());

            var splashForm = new SplashForm();
            DateTime endDate = DateTime.Now + TimeSpan.FromSeconds(7);
            splashForm.Show();
            while (endDate > DateTime.Now)
            {
                Application.DoEvents();
            }
            splashForm.Close();
            splashForm.Dispose();

            Application.Run(new ResultForm());
        }
    }
}
