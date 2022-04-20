using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using Serilog;
using SwqlStudio.Properties;

namespace SwqlStudio
{
    internal static class Program
    {
        private static Microsoft.Extensions.Logging.ILogger log;

        internal static ILoggerFactory LoggerFactory { get; } = new LoggerFactory();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // Configure Serilog logging.
            string logFilePath = Environment.ExpandEnvironmentVariables(@"%ALLUSERSPROFILE%\Application Data\SolarWinds\Logs\SwqlStudio.log");
            var loggerConfig = new LoggerConfiguration()
                .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            LoggerFactory.AddSerilog(loggerConfig);
            log = LoggerFactory.CreateLogger("Program");

            AppDomain.CurrentDomain.UnhandledException += CurrentDomainUnhandledException;
            if (Settings.Default.UpdateRequired)
            {
                Settings.Default.Upgrade();

                if (string.IsNullOrWhiteSpace(Settings.Default.PreviousServers))
                {
                    SearchAndCopyLastUserConfig(new Version(Application.ProductVersion));
                    Settings.Default.Reload();
                }

                Settings.Default.UpdateRequired = false;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception)
                log.LogError((Exception)e.ExceptionObject, "Unhandled exception");
        }

        private static void SearchAndCopyLastUserConfig(Version currentVersion)
        {
            try
            {
                string userConfigFileName = "user.config";

                // Expected location of the current user config
                DirectoryInfo currentVersionConfigFileDir = new FileInfo(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath).Directory;
                if (currentVersionConfigFileDir != null)
                {
                    if (!currentVersionConfigFileDir.Exists)
                        currentVersionConfigFileDir.Create();

                    //1. Look for previous version with the same .net version
                    // grab the most recent folder from the list of user's settings folders, prior to the current version
                    var previousSettingsDir = (from dir in currentVersionConfigFileDir.Parent.EnumerateDirectories()
                                               let dirVer = new { Dir = dir, Ver = new Version(dir.Name) }
                                               where dirVer.Ver < currentVersion
                                               orderby dirVer.Ver descending
                                               select dir).FirstOrDefault();

                    if (previousSettingsDir != null)
                    {
                        CopyUserConfigSettings(currentVersion, userConfigFileName, currentVersionConfigFileDir, previousSettingsDir);
                    }
                    //2. If not present look for older version with different .net version
                    else
                    {
                        // grab the most recent folder from the list of user's settings folders, prior to the current version
                        previousSettingsDir = (from dir in currentVersionConfigFileDir.Parent.Parent.EnumerateDirectories("????.????.????.????", SearchOption.AllDirectories)
                                               let dirVer = new { Dir = dir, Ver = new Version(dir.Name) }
                                               where dirVer.Ver < currentVersion && dir.Parent.Name.ToLower().Contains("swqlstudio")
                                               orderby dirVer.Ver descending
                                               select dir).FirstOrDefault();

                        if (previousSettingsDir != null)
                            CopyUserConfigSettings(currentVersion, userConfigFileName, currentVersionConfigFileDir, previousSettingsDir);
                    }
                }
            }
            catch (Exception ex)
            {
                log.LogError(ex, "An error occurred while trying to upgrade user specific settings for the new version.");
            }
        }

        private static void CopyUserConfigSettings(Version currentVersion, string userConfigFileName, DirectoryInfo currentVersionConfigFileDir, DirectoryInfo previousSettingsDir)
        {
            string previousVersionConfigFile = Path.Combine(previousSettingsDir.FullName, userConfigFileName);
            string currentVersionConfigFile = Path.Combine(currentVersionConfigFileDir.FullName, userConfigFileName);

            if (!currentVersionConfigFileDir.Exists)
            {
                Directory.CreateDirectory(currentVersionConfigFileDir.FullName);
            }

            File.Copy(previousVersionConfigFile, currentVersionConfigFile, true);
        }
    }
}
