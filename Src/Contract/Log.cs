using System;
using System.Collections.Generic;
using System.Text;

namespace SolarWinds.Logging
{
    class Log
    {
        public bool IsErrorEnabled => true;
        public bool IsWarnEnabled => true;
        public bool IsInfoEnabled => true;
        public bool IsDebugEnabled => true;
        public bool IsVerboseEnabled => true;

        public void Error(string msg)
        {            
        }
        public void Error(string msg, Exception ex)
        {
        }
        public void Warn(string msg)
        {
        }
        public void Info(string msg)
        {
        }
        public void Debug(string msg)
        {
        }
        public void Verbose(string msg)
        {
        }

        public void ErrorFormat(string msg, params object[] objs)
        {
        }
        public void WarnFormat(string msg, params object[] objs)
        {
        }
        public void InfoFormat(string msg, params object[] objs)
        {
        }
        public void DebugFormat(string msg, params object[] objs)
        {
        }
        public void VerboseFormat(string msg, params object[] objs)
        {
        }
    }
}
