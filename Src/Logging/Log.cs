using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Reflection;
using System.Xml;
using log4net.Util;
using System.Globalization;
using System.Linq;

namespace SolarWinds.Logging
{
    /// <summary>
    /// 2014-07-18: Modifyed to allow configure log4net from multiple configuration files.
    /// Aseembly which needs to add own "log4net" configuration together with application 
    /// "log4net" configuration file should call Log.Configure([configuration file]). 
    /// Assembly loading event is not handling.
    /// Be careful with overidding "log4net" settings.
    /// Example: host and plugin configuration files
    /// As well, allows properly using paterns %method and %line for log4net layout
    /// </summary>
    public class Log
    {
        private const string MasterNamespace = "SolarWinds";

        private readonly SolarWinds.Logging.Ext.EventID.IEventIDLog _log;

        private static HashSet<string> _configurations = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private static HashSet<string> _assemblies = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        
        /// <summary>
        /// SpecialFolder CommonApplicationData + Solarwinds directory
        /// </summary>
        private static readonly string FolderCommonApplicationData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Solarwinds");

        /// <summary>
        /// Initializes static members of the <see cref="Log"/> class.
        /// XP/2003 -&gt; C:\Documents and Settings\All Users\Application Data
        /// Vista/Win7/2008 -&gt; C:\ProgramData
        /// </summary>
        static Log()
        {
            Environment.SetEnvironmentVariable("SWLogDir", FolderCommonApplicationData, EnvironmentVariableTarget.Process);

            Initialize();

            /*
             Handle assembly loading event is disabled because next loaded assembly configuration file 
             which has "log4net" section can override "log4net" configuration loaded from the 
             main application configuration file or, even worse, mext loaded assembly configuration file
             can override "log4net" configruation loaded from other assemnly. 
             As result, logging is going to wrong log file.
             
             Assembly still has ability to configure "log4net" with own configuration file, basically add 
             own configuration to already loaded "log4net" configuration from the appication configuration file, 
             by calling Log.Configure(<configuration file>)
            */
            // AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void Initialize()
        {
            try
            {
                Assembly currentAssembly = typeof(Log).Assembly;

                List<Assembly> asmList = new StackTrace().GetFrames()
                    .Where(frame => 
                        {
                            MethodBase method = frame.GetMethod();
                            return method != null && method.DeclaringType != null && method.DeclaringType.Assembly != null;
                        })
                    .Select(frame => frame.GetMethod().DeclaringType.Assembly)
                    .ToList();
                int currentAssemblyIndex = asmList.FindLastIndex(asm => 
                    asm.FullName.Equals(currentAssembly.FullName, StringComparison.OrdinalIgnoreCase)) + 1;

                Assembly entryAssembly = null;
                if (currentAssemblyIndex < asmList.Count)
                {
                    entryAssembly = asmList
                        .Skip(currentAssemblyIndex)
                        .LastOrDefault(asm => asm.FullName.IndexOf(MasterNamespace, StringComparison.OrdinalIgnoreCase) != -1);
                }
                else
                {
                    entryAssembly = asmList.LastOrDefault(asm => asm.FullName.IndexOf(MasterNamespace, StringComparison.OrdinalIgnoreCase) != -1);
                }

                if (entryAssembly == null)
                {
                    if (currentAssemblyIndex < asmList.Count)
                    {
                        entryAssembly = asmList
                            .Skip(currentAssemblyIndex)
                            .LastOrDefault(asm => !asm.GlobalAssemblyCache);
                    }
                    else
                    {
                        entryAssembly = asmList.LastOrDefault(asm => !asm.GlobalAssemblyCache);
                    }
                }

                if (entryAssembly == null)
                {
                    MethodBase method = new StackTrace().GetFrames().Last().GetMethod();
                    if (method != null && method.DeclaringType != null && method.DeclaringType.Assembly != null)
                        entryAssembly = method.DeclaringType.Assembly;
                }

                Version asmVer = entryAssembly.GetName().Version;

                log4net.GlobalContext.Properties["Assembly.Version"] = asmVer.ToString();
                log4net.GlobalContext.Properties["Assembly.Version.Short"] = string.Format("{0}_{1}", asmVer.Major, asmVer.Minor);
                log4net.GlobalContext.Properties["Assembly.FullName"] = entryAssembly.FullName;
                log4net.GlobalContext.Properties["Runtime.Version"] = entryAssembly.ImageRuntimeVersion;
            }
            catch
            {
                // unable to set up log4net properties
            }

            // Configure log4net within application configuration file
            // For web apps, this will work if the config info is in web.config:
            Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        }

        static void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            try
            {
                Configure(string.Format("{0}.config", args.LoadedAssembly.Location));
            }
            catch
            {
                // NotSupportedException is raised for dynamic library - access to Location property
                // Simply ignore exception to allow normal behaviour for the caller
            }
        }

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Log() : this(GetCallerMethod())
		{
		}

        private Log(MethodBase callerMethod)
        {
            Type callerType;
            if ((callerType = callerMethod.DeclaringType) != null)
            {
                _log = SolarWinds.Logging.Ext.EventID.EventIDLogManager.GetLogger(callerType.Assembly, callerType);

                LogAssemblyVersion(callerType.Assembly);
            }
            else
            {
                _log = SolarWinds.Logging.Ext.EventID.EventIDLogManager.GetLogger(callerMethod.Name);
            }
        }

        public Log(Type callerType)
        {
            _log = SolarWinds.Logging.Ext.EventID.EventIDLogManager.GetLogger(callerType.Assembly, callerType);

            LogAssemblyVersion(callerType.Assembly);
        }

        public Log(String Name)
        {
            _log = SolarWinds.Logging.Ext.EventID.EventIDLogManager.GetLogger(Name);
        }

        /// <summary>
        /// Record assembly version which initialize logging, assembly version is recorded only once per AppDomain
        /// If assembly loaded as plugin, log header information (log4net.GlobalContext.Properties) 
        /// already initialized and contains host assembly information
        /// </summary>
        /// <param name="assembly"></param>
        private void LogAssemblyVersion(Assembly assembly)
        {
            if (assembly != null)
            {
                lock (_assemblies)
                {
                    if (!_assemblies.Contains(assembly.FullName))
                    {
                        string message = string.Format("*** Assembly {0}, .NET version {1} ***", assembly.FullName, assembly.ImageRuntimeVersion);
                        ForceMessageLog.Log(_log, message);

                        _assemblies.Add(assembly.FullName);
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static MethodBase GetCallerMethod()
        {
            return new StackFrame(2, false).GetMethod();
        }

        public static void Configure(string configFile = null)
        {
            foreach (string fn in EnumFile(configFile))
            {
                if (string.IsNullOrEmpty(fn)) continue;

                FileInfo fi = new FileInfo(fn);
                if (fi.Exists)
                {
                    lock (_configurations)
                    {
                        if (_configurations.Contains(fi.FullName)) continue;
                    }

                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(fi.FullName);
                        XmlNodeList nodes = doc.GetElementsByTagName("log4net");
                        if (nodes != null && nodes.Count > 0)
                        {
                            lock (_configurations)
                            {
                                if (!_configurations.Contains(fi.FullName))
                                {
                                    log4net.Config.XmlConfigurator.ConfigureAndWatch(fi);
                                    _configurations.Add(fi.FullName);
                                }
                            }
                        }
                    }
                    catch { }
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static IEnumerable<string> EnumFile(string fileName)
        {
            yield return fileName;

            MethodBase callerMethod = new StackFrame(2).GetMethod();
            if (callerMethod != null && callerMethod.DeclaringType != null)
            {
                Assembly callingAssembly = callerMethod.DeclaringType.Assembly;
                if (callingAssembly != null)
                {
                    yield return callingAssembly.Location + ".config";
                    if (!string.IsNullOrEmpty(fileName))
                        yield return Path.Combine(Path.GetDirectoryName(callingAssembly.Location), Path.GetFileName(fileName));
                }
            }

            Assembly entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly != null)
            {
                yield return entryAssembly.Location + ".config";
                if (!string.IsNullOrEmpty(fileName))
                    yield return Path.Combine(Path.GetDirectoryName(entryAssembly.Location), Path.GetFileName(fileName));
            }

            yield return AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
        }
        
        #region Log Forwarding Members

        public void Debug(object message)
        {
            _log.Debug(message);
        }

        public void Debug(object message, Exception exception)
        {
            _log.Debug(message, exception);
        }

        public void DebugFormat(string format, params object[] args)
        {
            _log.DebugFormat(format, args);
        }

        public void DebugFormat(string format, object arg0)
        {
            _log.DebugFormat(format, arg0);
        }

        public void DebugFormat(string format, object arg0, object arg1)
        {
            _log.DebugFormat(format, arg0, arg1);
        }

        public void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.DebugFormat(format, arg0, arg1, arg2);
        }

        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log.DebugFormat(provider, format, args);
        }

        public void Debug(int eventId, object message)
        {
            _log.Debug(eventId, message);
        }

        public void Debug(int eventId, object message, Exception exception)
        {
            _log.Debug(eventId, message, exception);
        }

        public void Info(object message)
        {
            _log.Info(message);
        }

        public void Info(object message, Exception exception)
        {
            _log.Info(message, exception);
        }

        public void InfoFormat(string format, params object[] args)
        {
            _log.InfoFormat(format, args);
        }

        public void InfoFormat(string format, object arg0)
        {
            _log.InfoFormat(format, arg0);
        }

        public void InfoFormat(string format, object arg0, object arg1)
        {
            _log.InfoFormat(format, arg0, arg1);
        }

        public void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.InfoFormat(format, arg0, arg1, arg2);
        }

        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log.InfoFormat(provider, format, args);
        }

        public void Info(int eventId, object message)
        {
            _log.Info(eventId, message);
        }

        public void Info(int eventId, object message, Exception exception)
        {
            _log.Info(eventId, message, exception);
        }

        public void Warn(object message)
        {
            _log.Warn(message);
        }

        public void Warn(object message, Exception exception)
        {
            _log.Warn(message, exception);
        }

        public void WarnFormat(string format, params object[] args)
        {
            _log.WarnFormat(format, args);
        }

        public void WarnFormat(string format, object arg0)
        {
            _log.WarnFormat(format, arg0);
        }

        public void WarnFormat(string format, object arg0, object arg1)
        {
            _log.WarnFormat(format, arg0, arg1);
        }

        public void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.WarnFormat(format, arg0, arg1, arg2);
        }

        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log.WarnFormat(provider, format, args);
        }

        public void Warn(int eventId, object message)
        {
            _log.Warn(eventId, message);
        }

        public void Warn(int eventId, object message, Exception exception)
        {
            _log.Warn(eventId, message, exception);
        }

        public void Error(object message)
        {
            _log.Error(message);
        }

        public void Error(object message, Exception exception)
        {
            _log.Error(message, exception);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            _log.ErrorFormat(format, args);
        }

        public void ErrorFormat(string format, object arg0)
        {
            _log.ErrorFormat(format, arg0);
        }

        public void ErrorFormat(string format, object arg0, object arg1)
        {
            _log.ErrorFormat(format, arg0, arg1);
        }

        public void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.ErrorFormat(format, arg0, arg1, arg2);
        }

        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log.ErrorFormat(provider, format, args);
        }

        public void Error(int eventId, object message)
        {
            _log.Error(eventId, message);
        }

        public void Error(int eventId, object message, Exception exception)
        {
            _log.Error(eventId, message);
        }

        public void Fatal(object message)
        {
            _log.Fatal(message);
        }

        public void Fatal(object message, Exception exception)
        {
            _log.Fatal(message, exception);
        }

        public void FatalFormat(string format, params object[] args)
        {
            _log.FatalFormat(format, args);
        }

        public void FatalFormat(string format, object arg0)
        {
            _log.FatalFormat(format, arg0);
        }

        public void FatalFormat(string format, object arg0, object arg1)
        {
            _log.FatalFormat(format, arg0, arg1);
        }

        public void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.FatalFormat(format, arg0, arg1, arg2);
        }

        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log.FatalFormat(provider, format, args);
        }

        public void Fatal(int eventId, object message)
        {
            _log.Fatal(eventId, message);
        }

        public void Fatal(int eventId, object message, Exception exception)
        {
            _log.Fatal(eventId, message, exception);
        }

        public void Verbose(object message)
        {
            _log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                log4net.Core.Level.Verbose, message, null);
        }

        public void Verbose(object message, Exception exception)
        {
            _log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                log4net.Core.Level.Verbose, message, exception);
        }

        public void VerboseFormat(string format, params object[] args)
        {
            VerboseFormat(CultureInfo.InvariantCulture, format, args);
        }

        public void VerboseFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                log4net.Core.Level.Verbose, new SystemStringFormat(provider, format, args), null);
        }

        public void Verbose(int eventId, object message)
        {
            _log.Verbose(eventId, message);
        }

        public void Verbose(int eventId, object message, Exception exception)
        {
            _log.Verbose(eventId, message, exception);
        }

        public void Trace(object message)
        {
            _log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                log4net.Core.Level.Trace, message, null);
        }

        public void Trace(object message, Exception exception)
        {
            _log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                log4net.Core.Level.Trace, message, exception);
        }

        public void TraceFormat(string format, params object[] args)
        {
            TraceFormat(CultureInfo.InvariantCulture, format, args);
        }

        public void TraceFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log.Logger.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType,
                log4net.Core.Level.Trace, new SystemStringFormat(provider, format, args), null);
        }

        public void Trace(int eventId, object message)
        {
            _log.Trace(eventId, message);
        }

        public void Trace(int eventId, object message, Exception exception)
        {
            _log.Trace(eventId, message, exception);
        }

        public bool IsDebugEnabled
        {
            get { return _log.IsDebugEnabled; }
        }

        public bool IsInfoEnabled
        {
            get { return _log.IsInfoEnabled; }
        }

        public bool IsWarnEnabled
        {
            get { return _log.IsWarnEnabled; }
        }

        public bool IsErrorEnabled
        {
            get { return _log.IsErrorEnabled; }
        }

        public bool IsFatalEnabled
        {
            get { return _log.IsFatalEnabled; }
        }

        public bool IsVerboseEnabled
        {
            get { return _log.IsVerboseEnabled; }
        }

        public bool IsTraceEnabled
        {
            get { return _log.IsTraceEnabled; }
        }

		[MethodImpl(MethodImplOptions.NoInlining)]
		public IDisposable Block()
		{
			return Block(new StackFrame(1, false).GetMethod().Name);
		}

		public IDisposable Block(string blockName)
		{
			return new LogBlock(this, blockName);
		}

        #endregion
    }

	class LogBlock : IDisposable
	{
		string _blockName;
		Log _log;
		IDisposable _threadContextStackPopper;

		public LogBlock(Log log, string blockName)
		{
            _log = log;
            _blockName = blockName;
            _threadContextStackPopper = log4net.ThreadContext.Stacks["NDC"].Push(blockName);
            _log.DebugFormat("{{ {0} entered", _blockName);
		}

		#region IDisposable Members

		public void Dispose()
		{
			if (_threadContextStackPopper != null)
			{
				_log.DebugFormat("}} {0} exited", _blockName);
				_threadContextStackPopper.Dispose();
				_threadContextStackPopper = null;
			}
			//GC.SuppressFinalize(this); // no finalizer on this object, so SuppressFinalize is not needed
		}

		#endregion
	}
}
