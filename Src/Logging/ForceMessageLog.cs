using System.Collections.Generic;
using System.IO;
using System.Linq;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace SolarWinds.Logging
{
    /// <summary>
    /// Allow force log message to log file in-depend from the log level
    /// </summary>
    internal static class ForceMessageLog
    {
        private static readonly SimpleLayout _simpleLayout = new SimpleLayout();

        private class SimpleLayout : ILayout
        {
            private readonly PatternLayout _layout = new PatternLayout("%message%newline");

            public string ContentType { get { return "text/plain"; } }

            public string Footer { get { return null; } }

            public string Header { get { return null; } }

            public bool IgnoresException { get { return false; } }

            public void Format(TextWriter writer, LoggingEvent loggingEvent)
            {
                _layout.Format(writer, loggingEvent);
            }
        }

        public static void Log(ILog log, object message)
        {
            if (log == null) return;

            Logger logger = log.Logger as Logger;

            if (logger != null)
            {
                try
                {
                    // Save current log level and layouts
                    Dictionary<AppenderSkeleton, ILayout> existingLayout = new Dictionary<AppenderSkeleton, ILayout>();
                    Level existingLevel = logger.Level;

                    foreach (var appender in logger.Repository.GetAppenders().OfType<AppenderSkeleton>())
                    {
                        existingLayout[appender] = appender.Layout;
                        appender.Layout = _simpleLayout;
                    }

                    logger.Level = Level.Verbose;

                    logger.Log(Level.Verbose, message, null);

                    // Restore layouts and log level
                    foreach (KeyValuePair<AppenderSkeleton, ILayout> kv in existingLayout)
                    {
                        kv.Key.Layout = kv.Value;
                    }

                    logger.Level = existingLevel;
                }
                catch { } // Ignore exception
            }
        }
    }
}
