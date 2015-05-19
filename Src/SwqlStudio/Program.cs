using System;
using System.Windows.Forms;
using SwqlStudio.Properties;

namespace SwqlStudio
{
    static class Program
    {
        private static readonly SolarWinds.Logging.Log log = new SolarWinds.Logging.Log();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SolarWinds.Logging.Log.Configure(string.Empty);

            AppDomain.CurrentDomain.UnhandledException += CurrentDomainUnhandledException;

            if (Settings.Default.UpdateRequired)
            {
                Settings.Default.Upgrade();
                Settings.Default.UpdateRequired = false;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception)
                log.Error("Unhandled exception", (Exception)e.ExceptionObject);
        }
    }
}
