using System;
using System.Collections;
using System.Management.Automation;
using System.ServiceModel;
using System.ServiceModel.Security;
using SolarWinds.InformationService.Contract2;

namespace SwisPowerShell
{
    public abstract class BaseSwisCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public InfoServiceProxy SwisConnection { get; set; }

        protected void ReportException(FaultException<InfoServiceFaultContract> faultEx)
        {
            WriteError(new ErrorRecord(faultEx, "SwisError", ErrorCategory.InvalidOperation, null)
                           {ErrorDetails = new ErrorDetails(faultEx.Detail.Message)});
        }

        protected void CheckConnection()
        {
            if (SwisConnection.Channel != null && SwisConnection.Channel.State == CommunicationState.Faulted)
            {
                SwisConnection.Close();
                SwisConnection.Open();
            }
        }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            using (CreateSwisContext())
                DoWithExceptionReporting(InternalProcessRecord);
        }

        protected virtual IDisposable CreateSwisContext()
        {
            return new SwisSettingsContext {ApplicationTag = "SwisPowerShell", AppendErrors = true};
        }

        protected void DoWithExceptionReporting(Action work)
        {
            try
            {
                work();
            }
            catch (FaultException<InfoServiceFaultContract> faultEx)
            {
                ReportException(faultEx);
            }
            catch (MessageSecurityException ex)
            {
                ReportException(ex);
            }
            catch (FaultException ex)
            {
                ReportException(ex);
            }
        }

        protected abstract void InternalProcessRecord();

        protected void ReportException(MessageSecurityException ex)
        {
            string msg;
            if (ex.InnerException is FaultException)
                msg = (ex.InnerException as FaultException).Message;
            else
                msg = ex.Message;
            WriteError(new ErrorRecord(ex, "SwisError", ErrorCategory.InvalidOperation, null) {ErrorDetails = new ErrorDetails(msg)});
        }

        protected void ReportException(FaultException ex)
        {
            WriteError(new ErrorRecord(ex, "SwisError", ErrorCategory.InvalidOperation, null) {ErrorDetails = new ErrorDetails(ex.Reason.ToString())});
        }

        protected void ReportException(Exception ex)
        {
            WriteError(new ErrorRecord(ex, "SwisError", ErrorCategory.InvalidOperation, null) {ErrorDetails = new ErrorDetails(ex.Message)});
        }

        protected static PropertyBag PropertyBagFromHashtable(Hashtable properties)
        {
            return (PropertyBag)PropertyBagFromDictionary(properties);
        }

        protected internal static object PropertyBagFromDictionary(object obj)
        {
            var psObject = obj as PSObject;
            if (psObject != null)
                obj = psObject.BaseObject;

            var dict = obj as IDictionary;
            if (dict != null)
            {
                var bag = new PropertyBag();
                foreach (object key in dict.Keys)
                    bag[key.ToString()] = PropertyBagFromDictionary(dict[key]);
                return bag;
            }
            
            return obj;
        }
    }
}
