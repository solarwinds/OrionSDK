using System;
using log4net.Core;
using log4net.Util;
using System.Globalization;

namespace SolarWinds.Logging.Ext.EventID
{
    public class EventIDLogImpl : LogImpl, IEventIDLog
    {
        /// <summary>
        /// The declaring type of the method that is the stack boundary into the logging system for this call.
        /// </summary>
        private Type ThisDeclaringType = typeof(SolarWinds.Logging.Log);

        public EventIDLogImpl(ILogger logger) : base(logger)
        {
        }

        #region Implementation of IEventIDLog

        public void Debug(int eventId, object message)
        {
            Debug(eventId, message, null);
        }

        public void Debug(int eventId, object message, Exception t)
        {
            if (IsDebugEnabled)
            {
                LoggingEvent loggingEvent = new LoggingEvent(ThisDeclaringType, Logger.Repository, Logger.Name, Level.Debug, message, t);
                loggingEvent.Properties["EventID"] = eventId;
                Logger.Log(loggingEvent);
            }
        }

        public void Info(int eventId, object message)
        {
            Info(eventId, message, null);
        }

        public void Info(int eventId, object message, System.Exception t)
        {
            if (IsInfoEnabled)
            {
                LoggingEvent loggingEvent = new LoggingEvent(ThisDeclaringType, Logger.Repository, Logger.Name, Level.Info, message, t);
                loggingEvent.Properties["EventID"] = eventId;
                Logger.Log(loggingEvent);
            }
        }

        public void Warn(int eventId, object message)
        {
            Warn(eventId, message, null);
        }

        public void Warn(int eventId, object message, System.Exception t)
        {
            if (IsWarnEnabled)
            {
                LoggingEvent loggingEvent = new LoggingEvent(ThisDeclaringType, Logger.Repository, Logger.Name, Level.Warn, message, t);
                loggingEvent.Properties["EventID"] = eventId;
                Logger.Log(loggingEvent);
            }
        }

        public void Error(int eventId, object message)
        {
            Error(eventId, message, null);
        }

        public void Error(int eventId, object message, System.Exception t)
        {
            if (IsErrorEnabled)
            {
                LoggingEvent loggingEvent = new LoggingEvent(ThisDeclaringType, Logger.Repository, Logger.Name, Level.Error, message, t);
                loggingEvent.Properties["EventID"] = eventId;
                Logger.Log(loggingEvent);
            }
        }

        public void Fatal(int eventId, object message)
        {
            Fatal(eventId, message, null);
        }

        public void Fatal(int eventId, object message, System.Exception t)
        {
            if (IsFatalEnabled)
            {
                LoggingEvent loggingEvent = new LoggingEvent(ThisDeclaringType, Logger.Repository, Logger.Name, Level.Fatal, message, t);
                loggingEvent.Properties["EventID"] = eventId;
                Logger.Log(loggingEvent);
            }
        }

        public void Verbose(int eventId, object message)
        {
            Verbose(eventId, message, null);
        }

        public void Verbose(int eventId, object message, System.Exception t)
        {
            if (IsVerboseEnabled)
            {
                LoggingEvent loggingEvent = new LoggingEvent(ThisDeclaringType, Logger.Repository, Logger.Name, Level.Verbose, message, t);
                loggingEvent.Properties["EventID"] = eventId;
                Logger.Log(loggingEvent);
            }
        }

        public bool IsVerboseEnabled
        {
            get { return Logger.IsEnabledFor(Level.Verbose); }
        }

        public void Trace(int eventId, object message)
        {
            Trace(eventId, message, null);
        }

        public void Trace(int eventId, object message, System.Exception t)
        {
            if (IsTraceEnabled)
            {
                LoggingEvent loggingEvent = new LoggingEvent(ThisDeclaringType, Logger.Repository, Logger.Name, Level.Trace, message, t);
                loggingEvent.Properties["EventID"] = eventId;
                Logger.Log(loggingEvent);
            }
        }

        public bool IsTraceEnabled
        {
            get { return Logger.IsEnabledFor(Level.Trace); }
        }

        #endregion Implementation of IEventIDLog

        #region Forward Debug logs
        public override void Debug(object msg)
        {
            Log(Level.Debug, msg);
        }

        public override void Debug(object msg, Exception exc)
        {
            Log(Level.Debug, msg, exc);
        }

        public override void DebugFormat(string format, object arg0)
        {
            LogFormat(Level.Debug, format, arg0);
        }

        public override void DebugFormat(string format, params object[] args)
        {
            LogFormat(Level.Debug, format, args);
        }

        public override void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            LogFormat(Level.Debug, provider, format, args);
        }

        public override void DebugFormat(string format, object arg0, object arg1)
        {
            LogFormat(Level.Debug, format, arg0, arg1);
        }

        public override void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
            LogFormat(Level.Debug, format, arg0, arg1, arg2);
        }
        #endregion

        #region Forward Error logs
        public override void Error(object msg)
        {
            Log(Level.Error, msg);
        }

        public override void Error(object msg, Exception exc)
        {
            Log(Level.Error, msg, exc);
        }

        public override void ErrorFormat(string format, object arg0)
        {
            LogFormat(Level.Error, format, arg0);
        }

        public override void ErrorFormat(string format, params object[] args)
        {
            LogFormat(Level.Error, format, args);
        }

        public override void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            LogFormat(Level.Error, provider, format, args);
        }

        public override void ErrorFormat(string format, object arg0, object arg1)
        {
            LogFormat(Level.Error, format, arg0, arg1);
        }

        public override void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            LogFormat(Level.Error, format, arg0, arg1, arg2);
        }

        public override void Fatal(object msg)
        {
            Log(Level.Fatal, msg);
        }
        #endregion

        #region Foward Fatal errors
        public override void Fatal(object msg, Exception exc)
        {
            Log(Level.Fatal, msg, exc);
        }

        public override void FatalFormat(string format, object arg0)
        {
            LogFormat(Level.Fatal, format, arg0);
        }

        public override void FatalFormat(string format, params object[] args)
        {
            LogFormat(Level.Fatal, format, args);
        }

        public override void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            LogFormat(Level.Fatal, provider, format, args);
        }

        public override void FatalFormat(string format, object arg0, object arg1)
        {
            LogFormat(Level.Fatal, format, arg0, arg1);
        }

        public override void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
            LogFormat(Level.Fatal, format, arg0, arg1, arg2);
        }
        #endregion

        #region Forward Info logs
        public override void Info(object msg)
        {
            Log(Level.Info, msg);
        }

        public override void Info(object msg, Exception exc)
        {
            Log(Level.Info, msg, exc);
        }

        public override void InfoFormat(string format, object arg0)
        {
            LogFormat(Level.Info, format, arg0);
        }

        public override void InfoFormat(string format, params object[] args)
        {
            LogFormat(Level.Info, format, args);
        }

        public override void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            LogFormat(Level.Info, provider, format, args);
        }

        public override void InfoFormat(string format, object arg0, object arg1)
        {
            LogFormat(Level.Info, format, arg0, arg1);
        }

        public override void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            LogFormat(Level.Info, format, arg0, arg1, arg2);
        }
        #endregion

        #region Forward Verbose logs
        public void Verbose(object msg)
        {
            Log(Level.Verbose, msg);
        }

        public void Verbose(object msg, Exception exc)
        {
            Log(Level.Verbose, msg, exc);
        }

        public void VerboseFormat(string format, object arg0)
        {
            LogFormat(Level.Verbose, format, arg0);
        }

        public void VerboseFormat(string format, params object[] args)
        {
            LogFormat(Level.Verbose, format, args);
        }

        public void VerboseFormat(IFormatProvider provider, string format, params object[] args)
        {
            LogFormat(Level.Verbose, provider, format, args);
        }

        public void VerboseFormat(string format, object arg0, object arg1)
        {
            LogFormat(Level.Verbose, format, arg0, arg1);
        }

        public void VerboseFormat(string format, object arg0, object arg1, object arg2)
        {
            LogFormat(Level.Verbose, format, arg0, arg1, arg2);
        }
        #endregion

        #region Forward Warn logs
        public override void Warn(object msg)
        {
            Log(Level.Warn, msg);
        }

        public override void Warn(object msg, Exception exc)
        {
            Log(Level.Warn, msg, exc);
        }

        public override void WarnFormat(string format, object arg0)
        {
            LogFormat(Level.Warn, format, arg0);
        }

        public override void WarnFormat(string format, params object[] args)
        {
            LogFormat(Level.Warn, format, args);
        }

        public override void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            LogFormat(Level.Warn, provider, format, args);
        }

        public override void WarnFormat(string format, object arg0, object arg1)
        {
            LogFormat(Level.Warn, format, arg0, arg1);
        }

        public override void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
            LogFormat(Level.Warn, format, arg0, arg1, arg2);
        }
        #endregion

        #region Forward logs based on the LogLevel - private methods
        private void Log(Level logLevel, object msg)
        {
            if (Logger.IsEnabledFor(logLevel))
            {
                Logger.Log(ThisDeclaringType, logLevel, msg, null);
            }
        }

        private void Log(Level logLevel, object msg, Exception exc)
        {
            if (Logger.IsEnabledFor(logLevel))
            {
                Logger.Log(ThisDeclaringType, logLevel, msg, exc);
            }
        }

        private void LogFormat(Level logLevel, string format, object arg0)
        {
            if (Logger.IsEnabledFor(logLevel))
            {
                Logger.Log(ThisDeclaringType, logLevel, new SystemStringFormat(CultureInfo.InvariantCulture, format, new object[] { arg0 }), null);
            }
        }

        private void LogFormat(Level logLevel, string format, params object[] args)
        {
            if (Logger.IsEnabledFor(logLevel))
            {
                Logger.Log(ThisDeclaringType, logLevel, new SystemStringFormat(CultureInfo.InvariantCulture, format, args), null);
            }
        }

        private void LogFormat(Level logLevel, IFormatProvider provider, string format, params object[] args)
        {
            if (Logger.IsEnabledFor(logLevel))
            {
                Logger.Log(ThisDeclaringType, logLevel, new SystemStringFormat(provider, format, args), null);
            }
        }

        private void LogFormat(Level logLevel, string format, object arg0, object arg1)
        {
            if (Logger.IsEnabledFor(logLevel))
            {
                Logger.Log(ThisDeclaringType, logLevel, new SystemStringFormat(CultureInfo.InvariantCulture, format, new object[] { arg0, arg1 }), null);
            }
        }

        private void LogFormat(Level logLevel, string format, object arg0, object arg1, object arg2)
        {
            if (Logger.IsEnabledFor(logLevel))
            {
                Logger.Log(ThisDeclaringType, logLevel, new SystemStringFormat(CultureInfo.InvariantCulture, format, new object[] { arg0, arg1, arg2 }), null);
            }
        }
        #endregion
    }
}
