using CalculatorRatedPowerAvailable.Helper.Encrypts;
using System;
using System.Threading;
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
            var ss = EncryptHelper.Encrypt(DateTime.Now.AddMonths(5).ToString());
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

            Application.Run(new CentralForm());
        }
    }
}
