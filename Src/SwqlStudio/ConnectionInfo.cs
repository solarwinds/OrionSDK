using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Xml;
using System.Xml.Serialization;
using SolarWinds.InformationService.Contract2;
using SolarWinds.InformationService.Contract2.PubSub;
using SolarWinds.InformationService.InformationServiceClient;
using SwqlStudio.Properties;
using SwqlStudio.Subscriptions;

namespace SwqlStudio
{
    public class ConnectionInfo : IDisposable
    {
        public string ServerType { get; set; }
        private string _server;
        private string _username;
        private string _password;

        private InfoServiceProxy _proxy;
        private readonly InfoServiceBase _infoServiceType;

        public event EventHandler<EventArgs> ConnectionClosed;
        public event EventHandler<EventArgs> ConnectionClosing;

        public ConnectionInfo(string server, string username, string password, string serverType)
        {
            ServerType = serverType;
            _server = server;
            _username = username;
            _password = password;

            _infoServiceType = InfoServiceFactory.Create(serverType, username, password);
            QueryParameters = new PropertyBag();
        }

        public Binding Binding
        {
            get { return _infoServiceType.Binding; }
        }

        public string Server
        {
            get { return _server; }
            set { _server = value; }
        }

        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public bool CanCreateSubscription { get; set; }

        public bool SupportsActiveSubscriptions
        {
            get { return _infoServiceType.SupportsActiveSubscriber; }
        }

        public string Title
        {
            get
            {
                return String.Format("{0} : {1}{2}", Server, ServerType, FormattedUserName);
            }
        }

        private string FormattedUserName
        {
            get
            {
                if (!string.IsNullOrEmpty(UserName))
                    return string.Format(" [{0}]", UserName);

                return UserName;
            }
        }

        public InfoServiceProxy Proxy
        {
            get { return _proxy; }
        }

        public InformationServiceConnection Connection { get; private set; }

        public static List<ServerType> AvailableServerTypes
        {
            get
            {
                List<ServerType> serverTypes = new List<ServerType>
                {
                    new ServerType() { Type = "Orion (v3)", IsAuthenticationRequired = true },
                    new ServerType() { Type = "Orion (v3) AD", IsAuthenticationRequired = false },
                    new ServerType() { Type = "Orion (v3) Certificate", IsAuthenticationRequired = false },
                    new ServerType() { Type = "Orion (v3) over HTTPS", IsAuthenticationRequired = true },
                    new ServerType() { Type = "Orion (v2)", IsAuthenticationRequired = true },
                    new ServerType() { Type = "Orion (v2) AD", IsAuthenticationRequired = false },
                    new ServerType() { Type = "Orion (v2) Certificate", IsAuthenticationRequired = false },
                    new ServerType() { Type = "Orion (v2) over HTTPS", IsAuthenticationRequired = true },
                    new ServerType() { Type = "EOC", IsAuthenticationRequired = true },
                    new ServerType() { Type = "NCM", IsAuthenticationRequired = true },
                    new ServerType() { Type = "NCM (Windows Authentication)", IsAuthenticationRequired = false },
                    new ServerType() { Type = "NCM Integration", IsAuthenticationRequired = true },
                    new ServerType() { Type = "Java over HTTP", IsAuthenticationRequired = true }
                };

                if (Settings.Default.ShowCompressedModes)
                {
                    serverTypes.AddRange(new[]
                                        {
                                            new ServerType() { Type = "Orion (v2) Compressed", IsAuthenticationRequired = true },
                                            new ServerType() { Type = "Orion (v2) AD Compressed", IsAuthenticationRequired = false },
                                            new ServerType() { Type = "Orion (v3) Compressed", IsAuthenticationRequired = true },
                                            new ServerType() { Type = "Orion (v3) AD Compressed", IsAuthenticationRequired = false },
                                        });

                }

                return serverTypes;

            }
        }

        public PropertyBag QueryParameters { get; set; }

        public void Connect()
        {
            if (_proxy == null || (_proxy != null && (_proxy.Channel.State == CommunicationState.Closed || _proxy.Channel.State == CommunicationState.Faulted)))
            {
                if (_proxy != null)
                    _proxy.Dispose();

                _proxy = _infoServiceType.CreateProxy(_server);
                _proxy.OperationTimeout = TimeSpan.FromMinutes(Settings.Default.OperationTimeout);
                _proxy.ChannelFactory.Endpoint.Behaviors.Add(new LogHeaderReaderBehavior());
                _proxy.Open();
            }

            Connection = new InformationServiceConnection((IInformationService)_proxy);
            Connection.Open();
        }

        public bool IsConnected
        {
            get { return _proxy != null && _proxy.ClientChannel.State == CommunicationState.Opened; }
        }

        internal NotificationDeliveryServiceProxy CreateActiveListenerProxy(INotificationSubscriber listener)
        {
            if (!_infoServiceType.SupportsActiveSubscriber)
                throw new InvalidOperationException("This connection type doesn't support active subscriptions");

            return _infoServiceType.CreateNotificationDeliveryServiceProxy(_server, listener);
        }

        private void EnsureConnection()
        {
            if (!IsConnected)
                Connect();
        }

        public IEnumerable<T> Query<T>(string swql) where T : new()
        {
            EnsureConnection();

            using (var context = new InformationServiceContext(_proxy))
            using (var serviceQuery = context.CreateQuery<T>(swql))
            {
                var enumerator = serviceQuery.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    yield return enumerator.Current;
                }
            }
        }

        public DataTable Query(string swql)
        {
            XmlDocument dummy;
            XmlDocument dummy2;
            return Query(swql, out dummy, out dummy2);
        }

        public DataTable Query(string swql, out XmlDocument queryPlan, out XmlDocument queryStats)
        {
            XmlDocument tmpQueryPlan = null; // can't reference out parameter from closure
            XmlDocument tmpQueryStats = null; // can't reference out parameter from closure

            DataTable result = DoWithExceptionTranslation(
                delegate
                    {
                        EnsureConnection();

                        using (InformationServiceCommand command = new InformationServiceCommand(swql, Connection) { ApplicationTag = "SWQL Studio" })
                        {
                            foreach (var param in QueryParameters)
                                command.Parameters.AddWithValue(param.Key, param.Value);

                            InformationServiceDataAdapter dataAdapter = new InformationServiceDataAdapter(command);
                            DataTable resultDataTable = new DataTable();
                            dataAdapter.Fill(resultDataTable);

                            tmpQueryPlan = dataAdapter.QueryPlan;
                            tmpQueryStats = dataAdapter.QueryStats;
                            return resultDataTable;
                        }
                    });

            queryPlan = tmpQueryPlan;
            queryStats = tmpQueryStats;
            return result;
        }

        public static void DoWithExceptionTranslation(Action action)
        {
            DoWithExceptionTranslation(delegate
                                           {
                                               action();
                                               return 0;
                                           });
        }

        public static T DoWithExceptionTranslation<T>(Func<T> action, bool retryOnConnectionError = true)
        {
            string msg;
            Exception inner;
            bool couldRetry = false;

            try
            {
                return action();
            }
            catch (FaultException<InfoServiceFaultContract> ex)
            {
                msg = ex.Detail.Message;
                inner = ex;
            }
            catch (SecurityNegotiationException ex)
            {
                msg = ex.Message;
                inner = ex;
            }
            catch (FaultException ex)
            {
                msg = ex.InnerException?.Message ?? ex.Message;
                inner = ex.InnerException ?? ex;
            }
            catch (MessageSecurityException ex)
            {
                if (ex.InnerException is FaultException fault)
                {
                    msg = fault.Message;
                    inner = fault;
                    couldRetry = fault.Code?.SubCode?.Name == "BadContextToken";
                }
                else
                {
                    msg = ex.Message;
                    inner = ex;
                }
            }
            catch (CommunicationObjectFaultedException ex)
            {
                msg = ex.Message;
                inner = ex;
                couldRetry = true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                inner = ex;
            }

            if (couldRetry && retryOnConnectionError)
            {
                return DoWithExceptionTranslation(action, false);
            }

            throw new ApplicationException(msg, inner);
        }

        public XmlDocument QueryXml(string query, out XmlDocument queryPlan, out List<ErrorMessage> errorMessages, out XmlDocument queryStats)
        {
            EnsureConnection();
            Message results;
            errorMessages = null;

            using (new SwisSettingsContext { DataProviderTimeout = TimeSpan.FromSeconds(30), ApplicationTag = "SWQL Studio", AppendErrors = true })
            {
                results = _proxy.Query(new QueryXmlRequest(query, QueryParameters));
            }

            XmlReader reader = results.GetReaderAtBodyContents();
            var body = new XmlDocument(reader.NameTable);
            body.Load(reader);

            var nsmgr = new XmlNamespaceManager(reader.NameTable);
            nsmgr.AddNamespace("is", Constants.Namespace);

            bool hasErrors = false;
            if (results.Headers.FindHeader("hasErrors", Constants.Namespace) > -1)
            {
                hasErrors = results.Headers.GetHeader<bool>("hasErrors", Constants.Namespace);
            }

            if (hasErrors)
            {
                XmlNode errorsNode = body.SelectSingleNode("/is:QueryXmlResponse/is:QueryXmlResult/errors", nsmgr);

                if (errorsNode != null)
                {
                    errorMessages = new List<ErrorMessage>();

                    foreach (XmlNode node in errorsNode.ChildNodes)
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(ErrorMessage));
                        ErrorMessage message = (ErrorMessage)serializer.Deserialize(new StringReader(node.OuterXml));

                        if (message != null)
                            errorMessages.Add(message);
                    }

                    errorsNode.ParentNode.RemoveChild(errorsNode);
                }
            }

            // Extract query plan if present
            XmlNode queryPlanNode = body.SelectSingleNode("/is:QueryXmlResponse/is:QueryXmlResult/is:queryResult/is:queryPlan", nsmgr);
            if (queryPlanNode != null)
            {
                queryPlan = new XmlDocument();
                queryPlan.LoadXml(queryPlanNode.OuterXml);
                queryPlanNode.ParentNode.RemoveChild(queryPlanNode);
            }
            else
            {
                queryPlan = null;
            }

            queryStats = null;

            return body;
        }

        public void Dispose()
        {
            Close();
        }

        public void Close()
        {
            if (_proxy != null)
            {
                var listeners = ConnectionClosing;
                listeners?.Invoke(this, EventArgs.Empty);

                _proxy.Dispose();
                _proxy = null;

                listeners = ConnectionClosed;
                listeners?.Invoke(this, EventArgs.Empty);
            }
        }

        internal ConnectionInfo Copy()
        {
            return new ConnectionInfo(_server, _username, _password, _infoServiceType.ServiceType)
            {
                QueryParameters = QueryParameters
            };
        }

        protected bool Equals(ConnectionInfo other)
        {
            return string.Equals(_server, other._server) && string.Equals(_username, other._username) && string.Equals(ServerType, other.ServerType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ConnectionInfo)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = _server.GetHashCode();
                hashCode = (hashCode * 397) ^ _username.GetHashCode();
                hashCode = (hashCode * 397) ^ ServerType.GetHashCode();
                return hashCode;
            }
        }
    }
}
