using System;
using log4net;

namespace SolarWinds.Logging.Ext.EventID
{
    public interface IEventIDLog : ILog
	{
        void Debug(int eventId, object message);
        void Debug(int eventId, object message, Exception exception);

        void Info(int eventId, object message);
        void Info(int eventId, object message, Exception exception);

        void Warn(int eventId, object message);
        void Warn(int eventId, object message, Exception exception);

        void Error(int eventId, object message);
        void Error(int eventId, object message, Exception exception);

        void Fatal(int eventId, object message);
        void Fatal(int eventId, object message, Exception exception);

        void Verbose(int eventId, object message);
        void Verbose(int eventId, object message, Exception exception);
        bool IsVerboseEnabled { get; }

        void Trace(int eventId, object message);
        void Trace(int eventId, object message, Exception exception);
        bool IsTraceEnabled { get; }
	}
}

