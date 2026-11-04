using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;
using FluentAssertions;
using SolarWinds.InformationService.Contract2;
using SolarWinds.InformationService.InformationServiceClient;
using SwqlStudio;
using Xunit;

namespace SwqlStudio.Tests
{
    public class ConnectionInfoTests
    {
        [Fact]
        public void DoWithExceptionTranslation_Retries_On_CommunicationObjectFaulted()
        {
            int tries = 0;
            int result = ConnectionInfo.DoWithExceptionTranslation(() =>
            {
                if (tries++ == 0)
                    throw new CommunicationObjectFaultedException("faulted");
                return 42;
            });

            result.Should().Be(42);
            tries.Should().Be(2);
        }

        [Fact]
        public void DoWithExceptionTranslation_Wraps_FaultException()
        {
            Action act = () => ConnectionInfo.DoWithExceptionTranslation<int>(() =>
            {
                throw new FaultException("boom");
            });

            act.Should().Throw<ApplicationException>()
                .WithMessage("boom");
        }

        [Fact]
        public void NextReconnectDelay_StaysFlatForFastWindow_ThenGrowsByHalf_UpToFiveMinutes()
        {
            ConnectionInfo.NextReconnectDelay(TimeSpan.FromSeconds(10), TimeSpan.FromMinutes(2)).Should().Be(TimeSpan.FromSeconds(10));
            ConnectionInfo.NextReconnectDelay(TimeSpan.FromSeconds(10), TimeSpan.FromMinutes(3)).Should().Be(TimeSpan.FromSeconds(15));
            ConnectionInfo.NextReconnectDelay(TimeSpan.FromSeconds(250), TimeSpan.FromMinutes(10)).Should().Be(TimeSpan.FromMinutes(5));
            ConnectionInfo.NextReconnectDelay(TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(20)).Should().Be(TimeSpan.FromMinutes(5));
        }

        [Fact]
        public void DescribeConnectionFailure_NamesTheFailingPart_AndKeepsTheDetails()
        {
            ApplicationException Wrap(Exception inner) => new ApplicationException(inner.Message, inner);
            var rejected = new FaultException("At least one security token in the message could not be validated.",
                new FaultCode("Sender", new FaultCode("FailedAuthentication")));

            ConnectionInfo.DescribeConnectionFailure(Wrap(new EndpointNotFoundException("TCP error code 10060")))
                .Should().StartWith("The server could not be reached.").And.Contain("TCP error code 10060");
            ConnectionInfo.DescribeConnectionFailure(Wrap(new EndpointNotFoundException(
                    "Could not connect to net.tcp://my-orion:17777/SolarWinds/InformationService/v3/Orion/ssl. The connection attempt lasted for a time span of 00:00:21.0534225. TCP error code 10060")))
                .Should().StartWith("Server 'my-orion' did not respond on port 17777 (timed out after 21 s).");
            ConnectionInfo.DescribeConnectionFailure(Wrap(new TimeoutException(
                    "Connecting to via net.tcp://my-orion:17777/SolarWinds/InformationService/v3/Orion/ssl timed out after 00:00:05. Connection attempts were made to 1 of 1 available addresses (10.0.0.1:17777).")))
                .Should().StartWith("Server 'my-orion' did not respond on port 17777 (timed out after 5 s).");
            ConnectionInfo.DescribeConnectionFailure(Wrap(rejected))
                .Should().StartWith("The server rejected the user name or password.");
            ConnectionInfo.DescribeConnectionFailure(Wrap(new System.ServiceModel.Security.SecurityAccessDeniedException("denied")))
                .Should().StartWith("The server rejected the user name or password.");
            ConnectionInfo.DescribeConnectionFailure(Wrap(new InvalidOperationException("boom")))
                .Should().Be("Unable to connect to Information Service.\nboom");
        }

        [Fact]
        public void PositiveOrDefault_FallsBack_ForNonPositiveConfigValues()
        {
            var fallback = TimeSpan.FromSeconds(10);
            ConnectionInfo.PositiveOrDefault(TimeSpan.FromSeconds(30), fallback).Should().Be(TimeSpan.FromSeconds(30));
            ConnectionInfo.PositiveOrDefault(TimeSpan.Zero, fallback).Should().Be(fallback);
            ConnectionInfo.PositiveOrDefault(TimeSpan.FromSeconds(-1), fallback).Should().Be(fallback);
        }

        [Fact]
        public void IsServerUnreachable_MatchesTransportFailures_NotServiceFaults()
        {
            ApplicationException Wrap(Exception inner) => new ApplicationException(inner.Message, inner);

            ConnectionInfo.IsServerUnreachable(Wrap(new EndpointNotFoundException())).Should().BeTrue();
            ConnectionInfo.IsServerUnreachable(Wrap(new CommunicationObjectAbortedException())).Should().BeTrue();
            ConnectionInfo.IsServerUnreachable(Wrap(new CommunicationException())).Should().BeTrue();
            ConnectionInfo.IsServerUnreachable(Wrap(new FaultException("bad query"))).Should().BeFalse();
            ConnectionInfo.IsServerUnreachable(Wrap(new TimeoutException())).Should().BeFalse();
            ConnectionInfo.IsServerUnreachable(new ApplicationException("boom")).Should().BeFalse();
        }

        [Fact]
        public void IsStaleSecuritySession_MatchesBadContextToken_Only()
        {
            var badToken = new FaultException("The security context token is expired or is not valid.",
                new FaultCode("Sender", new FaultCode("BadContextToken", "http://schemas.xmlsoap.org/ws/2005/02/sc")));
            var otherFault = new FaultException("boom", new FaultCode("Sender", new FaultCode("InvalidSecurity")));

            ConnectionInfo.IsStaleSecuritySession(new ApplicationException(badToken.Message, badToken)).Should().BeTrue();
            ConnectionInfo.IsStaleSecuritySession(new ApplicationException(otherFault.Message, otherFault)).Should().BeFalse();
            ConnectionInfo.IsStaleSecuritySession(new ApplicationException("boom")).Should().BeFalse();
        }

        [Fact]
        public void IsAuthenticationFailure_IgnoresExpiredSession_AfterSwisRestart()
        {
            var badToken = new FaultException("The security context token is expired or is not valid.",
                new FaultCode("Sender", new FaultCode("BadContextToken", "http://schemas.xmlsoap.org/ws/2005/02/sc")));
            var rejected = new FaultException("At least one security token in the message could not be validated.",
                new FaultCode("Sender", new FaultCode("FailedAuthentication")));

            // Stopping here would leave a valid user disconnected after every SWIS restart.
            ConnectionInfo.IsAuthenticationFailure(new System.ServiceModel.Security.MessageSecurityException(badToken.Message, badToken)).Should().BeFalse();
            ConnectionInfo.IsAuthenticationFailure(new System.ServiceModel.Security.MessageSecurityException(rejected.Message, rejected)).Should().BeTrue();
        }

        [Fact]
        public void IsAuthenticationFailure_RecognisesSecurityRejections_Only()
        {
            ConnectionInfo.IsAuthenticationFailure(new System.ServiceModel.Security.SecurityAccessDeniedException()).Should().BeTrue();
            ConnectionInfo.IsAuthenticationFailure(new System.ServiceModel.Security.SecurityNegotiationException()).Should().BeTrue();
            ConnectionInfo.IsAuthenticationFailure(new System.ServiceModel.Security.MessageSecurityException()).Should().BeTrue();
            ConnectionInfo.IsAuthenticationFailure(new EndpointNotFoundException()).Should().BeFalse();
            ConnectionInfo.IsAuthenticationFailure(new TimeoutException()).Should().BeFalse();
        }

        [Fact]
        public void ProbeServer_DiscardsTheProxy_WhenServerDoesNotRespond()
        {
            var previous = SynchronizationContext.Current;
            SynchronizationContext.SetSynchronizationContext(null);
            try
            {
                // The fake opens without contacting anything, so it reports Opened while no server listens.
                var info = new TestConnectionInfo(infoService: new FakeInfoService { FirstProxyOpens = true });
                info.Connect();
                info.IsConnected.Should().BeTrue();

                bool lost = false;
                info.ConnectionClosed += (s, e) => lost = true;

                info.ProbeServer();

                info.IsConnected.Should().BeFalse();
                lost.Should().BeTrue();
                info.Close();
            }
            finally
            {
                SynchronizationContext.SetSynchronizationContext(previous);
            }
        }

        [Fact]
        public void Connect_RaisesConnectionRestored_WhenItInstallsANewProxy()
        {
            var previous = SynchronizationContext.Current;
            SynchronizationContext.SetSynchronizationContext(null);
            try
            {
                var info = new TestConnectionInfo(infoService: new FakeInfoService { FirstProxyOpens = true });
                int restored = 0;
                info.ConnectionRestored += (s, e) => restored++;

                // Without this the execute button stays gold after a query reconnects on its own.
                info.Connect();

                restored.Should().Be(1);
                info.Close();
            }
            finally
            {
                SynchronizationContext.SetSynchronizationContext(previous);
            }
        }

        [Fact]
        public void IsConnected_IsFalse_When_NoProxy()
        {
            var info = new TestConnectionInfo();
            info.IsConnected.Should().BeFalse();
        }

        [Fact]
        public void Copy_Clones_Credentials_And_Type()
        {
            var info = new TestConnectionInfo("server1", "user", "pass", "Orion (v3)")
            {
                QueryParameters = new PropertyBag { { "k", "v" } }
            };

            var clone = info.Copy();

            clone.Server.Should().Be("server1");
            clone.UserName.Should().Be("user");
            clone.Password.Should().Be("pass");
            clone.ServerType.Should().Be("Orion (v3)");
            clone.QueryParameters.Should().ContainKey("k");
        }

        [Fact]
        public void OnConnectionRestored_IsSuppressed_AfterClose()
        {
            // Built without a SynchronizationContext so the event fires synchronously and the assertion is deterministic.
            var info = CreateWithoutSyncContext();
            bool restoredRaised = false;
            info.ConnectionRestored += (s, e) => restoredRaised = true;

            info.Close();

            // A reconnect that committed just before Close() must not report the connection as up again.
            info.TriggerRestored();

            restoredRaised.Should().BeFalse();
        }

        [Fact]
        public void OnConnectionRestored_IsRaised_WhenNotClosed()
        {
            var info = CreateWithoutSyncContext();
            bool restoredRaised = false;
            info.ConnectionRestored += (s, e) => restoredRaised = true;

            info.TriggerRestored();

            restoredRaised.Should().BeTrue();
        }

        [Fact]
        public void Connect_DisposesTheProxy_WhenOpeningFails()
        {
            var service = new FakeInfoService();
            var info = new TestConnectionInfo(infoService: service);

            Action act = () => info.Connect();

            act.Should().Throw<Exception>();

            // The caller never received the proxy, so nobody else can dispose it.
            service.LastProxy.WasDisposed.Should().BeTrue();
        }

        [Fact]
        public void Connect_DiscardsTheStaleProxy_WhenReplacingItFails()
        {
            var service = new FakeInfoService { FirstProxyOpens = true };
            var info = new TestConnectionInfo(infoService: service);

            info.Connect();

            // Closes the channel without clearing it, so the next Connect() takes the replacement path.
            service.OpenedProxy.Abort();

            Action act = () => info.Connect();

            // Sets up the state under test: disposes the stale proxy, then fails to open its replacement.
            act.Should().Throw<Exception>();

            // The attempt under test. Both throw, so only the call count tells recovery from tripping
            // over the disposed proxy: reaching CreateProxy a third time means _proxy was cleared.
            act.Should().Throw<Exception>();
            service.CreateProxyCount.Should().Be(3);

            info.Close();
        }

        [Fact]
        public void IsConnected_DoesNotBlock_WhileConnectIsOpeningTheProxy()
        {
            using (var entered = new ManualResetEventSlim())
            using (var release = new ManualResetEventSlim())
            {
                var service = new FakeInfoService { OnCreateProxy = () => { entered.Set(); release.Wait(); } };
                var info = new TestConnectionInfo(infoService: service);

                var connect = System.Threading.Tasks.Task.Run(() => info.Connect());
                entered.Wait(TimeSpan.FromSeconds(5)).Should().BeTrue();

                try
                {
                    // The UI polls this; it must not wait for an unreachable SWIS.
                    var probe = System.Threading.Tasks.Task.Run(() => info.IsConnected);
                    probe.Wait(TimeSpan.FromSeconds(2)).Should().BeTrue();
                    probe.Result.Should().BeFalse();
                }
                finally
                {
                    release.Set();
                }

                Action awaitConnect = () => connect.GetAwaiter().GetResult();
                awaitConnect.Should().Throw<Exception>();
            }
        }

        private static TestConnectionInfo CreateWithoutSyncContext()
        {
            var previous = SynchronizationContext.Current;
            SynchronizationContext.SetSynchronizationContext(null);
            try
            {
                return new TestConnectionInfo();
            }
            finally
            {
                SynchronizationContext.SetSynchronizationContext(previous);
            }
        }

        private static void WithoutSyncContext(Action action)
        {
            var previous = SynchronizationContext.Current;
            SynchronizationContext.SetSynchronizationContext(null);
            try
            {
                action();
            }
            finally
            {
                SynchronizationContext.SetSynchronizationContext(previous);
            }
        }

        [Fact]
        public void Close_RaisesClosingAndClosed_AfterTheProxyWasDropped()
        {
            WithoutSyncContext(() =>
            {
                var info = new TestConnectionInfo(infoService: new FakeInfoService { FirstProxyOpens = true });
                info.Connect();
                info.ProbeServer();
                info.Proxy.Should().BeNull("the probe drops a proxy whose server does not answer");

                int closing = 0, closed = 0;
                info.ConnectionClosing += (s, e) => closing++;
                info.ConnectionClosed += (s, e) => closed++;

                // Otherwise the server stays listed after the user disconnects it.
                info.Close();

                closing.Should().Be(1);
                closed.Should().Be(1);
                info.Connection.Should().BeNull();
            });
        }

        [Fact]
        public void Close_RaisesEventsOnlyOnce()
        {
            WithoutSyncContext(() =>
            {
                var info = new TestConnectionInfo(infoService: new FakeInfoService { FirstProxyOpens = true });
                info.Connect();

                int closing = 0;
                info.ConnectionClosing += (s, e) => closing++;

                info.Close();
                info.Close();

                closing.Should().Be(1);
            });
        }

        [Fact]
        public void Close_DoesNotHoldTheLock_WhileRaisingEvents()
        {
            WithoutSyncContext(() =>
            {
                var info = new TestConnectionInfo(infoService: new FakeInfoService { FirstProxyOpens = true });
                info.Connect();

                bool closingUnblocked = false, closedUnblocked = false;
                info.ConnectionClosing += (s, e) =>
                    closingUnblocked = System.Threading.Tasks.Task.Run(() => info.IsConnected).Wait(TimeSpan.FromSeconds(2));
                info.ConnectionClosed += (s, e) =>
                    closedUnblocked = System.Threading.Tasks.Task.Run(() => info.IsConnected).Wait(TimeSpan.FromSeconds(2));

                info.Close();

                closingUnblocked.Should().BeTrue();
                closedUnblocked.Should().BeTrue();
            });
        }

        [Fact]
        public void TryReconnect_InstallsTheReplacement_AndDisposesTheOldProxy()
        {
            WithoutSyncContext(() =>
            {
                var service = new FakeInfoService { AllProxiesOpen = true };
                var info = new TestConnectionInfo(infoService: service);
                info.Connect();
                var oldProxy = (LocalHttpProxy)info.Proxy;
                var oldConnection = info.Connection;

                int? generation = info.TryReconnect(CancellationToken.None);

                generation.Should().HaveValue();
                info.Proxy.Should().NotBeSameAs(oldProxy);
                info.Connection.Should().NotBeSameAs(oldConnection);
                oldProxy.WasDisposed.Should().BeTrue();
                info.Close();
            });
        }

        [Fact]
        public void TryReconnect_DiscardsTheReplacement_WhenClosedWhileOpening()
        {
            WithoutSyncContext(() =>
            {
                var service = new FakeInfoService { AllProxiesOpen = true };
                var info = new TestConnectionInfo(infoService: service);
                info.Connect();

                service.OnCreateProxy = () => info.Close();

                int? generation = info.TryReconnect(CancellationToken.None);

                generation.Should().NotHaveValue();
                info.Proxy.Should().BeNull("a reconnect must not reopen a connection the user closed");
                service.LastOpenedProxy.WasDisposed.Should().BeTrue();
            });
        }

        [Fact]
        public void TryReconnect_KeepsTheLiveProxy_WhenOpeningTheReplacementFails()
        {
            WithoutSyncContext(() =>
            {
                var service = new FakeInfoService { FirstProxyOpens = true };
                var info = new TestConnectionInfo(infoService: service);
                info.Connect();
                var liveProxy = info.Proxy;

                int? generation = info.TryReconnect(CancellationToken.None);

                generation.Should().NotHaveValue();
                info.Proxy.Should().BeSameAs(liveProxy);
                service.LastProxy.WasDisposed.Should().BeTrue();
                info.Close();
            });
        }

        [Fact]
        public void OAuthConstructor_DispatchesEvents_ToTheCreatingContext()
        {
            var previous = SynchronizationContext.Current;
            var context = new RecordingSynchronizationContext();
            SynchronizationContext.SetSynchronizationContext(context);
            OAuthStyleConnectionInfo info;
            try
            {
                info = new OAuthStyleConnectionInfo(new FakeInfoService());
            }
            finally
            {
                SynchronizationContext.SetSynchronizationContext(previous);
            }

            bool raised = false;
            info.ConnectionRestored += (s, e) => raised = true;

            // UI handlers would otherwise run on the keep-alive thread.
            info.TriggerRestored();

            raised.Should().BeFalse();
            context.Posted.Should().Be(1);
        }

        [Fact]
        public void QueryXml_ReconnectsInsteadOfFailingWithNullReference_WhenTheProxyIsDroppedConcurrently()
        {
            WithoutSyncContext(() =>
            {
                var service = new FakeInfoService { AllProxiesOpen = true };

                // Reports connected while no proxy is installed, as when the monitor drops it after the check.
                var info = new TestConnectionInfo(infoService: service) { ConnectedOverride = true };

                Action act = () => info.QueryXml("SELECT 1 FROM Metadata.Entity", out _, out _, out _);

                act.Should().Throw<ApplicationException>()
                    .Where(e => !(e.InnerException is NullReferenceException));
                service.CreateProxyCount.Should().Be(1, "the lost connection is retried through Connect()");
                info.Close();
            });
        }

        private class TestConnectionInfo : ConnectionInfo
        {
            public TestConnectionInfo(string server = "localhost", string user = "user", string pass = "pass", string type = "Orion (v3)", FakeInfoService infoService = null)
                : base(server, user, pass, type, infoService ?? new FakeInfoService())
            {
            }

            public bool? ConnectedOverride { get; set; }

            public override bool IsConnected => ConnectedOverride ?? base.IsConnected;

            public void TriggerRestored() => OnConnectionRestored();

            internal new ConnectionInfo Copy()
            {
                return new TestConnectionInfo(Server, UserName, Password, ServerType)
                {
                    QueryParameters = QueryParameters
                };
            }
        }

        private class FakeInfoService : InfoServiceBase
        {
            private readonly string _serviceType;

            public FakeInfoService(string serviceType = "Orion (v3)")
            {
                _serviceType = serviceType;
                _binding = new CustomBinding();
                _credentials = new FakeServiceCredentials();
                _endpoint = string.Empty;
                _endpointConfigName = string.Empty;
            }

            public override string ServiceType => _serviceType;

            /// <summary>Makes the first proxy openable, so a later Connect() has a live proxy to replace.</summary>
            public bool FirstProxyOpens { get; set; }

            public bool AllProxiesOpen { get; set; }

            public UnopenableProxy LastProxy { get; private set; }

            public InfoServiceProxy OpenedProxy { get; private set; }

            public LocalHttpProxy LastOpenedProxy { get; private set; }

            public int CreateProxyCount { get; private set; }

            public Action OnCreateProxy { get; set; }

            public override InfoServiceProxy CreateProxy(string server)
            {
                CreateProxyCount++;
                OnCreateProxy?.Invoke();

                if (AllProxiesOpen || (FirstProxyOpens && CreateProxyCount == 1))
                {
                    LastOpenedProxy = new LocalHttpProxy(_credentials);
                    OpenedProxy = OpenedProxy ?? LastOpenedProxy;
                    return LastOpenedProxy;
                }

                LastProxy = new UnopenableProxy(_credentials);
                return LastProxy;
            }
        }

        /// <summary>An HTTP channel opens without contacting the server, so nothing has to listen on the port.</summary>
        private class LocalHttpProxy : InfoServiceProxy
        {
            public LocalHttpProxy(ServiceCredentials credentials)
                : base(new Uri("http://127.0.0.1:1/unused"), CreateBinding(), credentials)
            {
            }

            public bool WasDisposed { get; private set; }

            protected override void Dispose(bool disposing)
            {
                WasDisposed = true;
                base.Dispose(disposing);
            }

            // Disposal probes the dead endpoint; skipping proxy discovery keeps that from taking seconds.
            private static BasicHttpBinding CreateBinding()
            {
                return new BasicHttpBinding
                {
                    UseDefaultWebProxy = false,
                    OpenTimeout = TimeSpan.FromMilliseconds(200),
                    SendTimeout = TimeSpan.FromMilliseconds(200),
                    CloseTimeout = TimeSpan.FromMilliseconds(200)
                };
            }
        }

        /// <summary>Its binding carries no transport element, so Open() fails while creating the channel.</summary>
        private class UnopenableProxy : InfoServiceProxy
        {
            public UnopenableProxy(ServiceCredentials credentials)
                : base(new Uri("http://localhost/unused"), new CustomBinding(), credentials)
            {
            }

            public bool WasDisposed { get; private set; }

            protected override void Dispose(bool disposing)
            {
                WasDisposed = true;
                base.Dispose(disposing);
            }
        }

        private class FakeServiceCredentials : ServiceCredentials
        {
            public override CredentialType CredentialType => CredentialType.Username;

            public override void ApplyTo(ChannelFactory channelFactory)
            {
                // no-op for tests
            }
        }

        private class OAuthStyleConnectionInfo : ConnectionInfo
        {
            public OAuthStyleConnectionInfo(InfoServiceBase infoService)
                : base("localhost", "user", infoService)
            {
            }

            public void TriggerRestored() => OnConnectionRestored();
        }

        private class RecordingSynchronizationContext : SynchronizationContext
        {
            public int Posted { get; private set; }

            public override void Post(SendOrPostCallback d, object state) => Posted++;
        }
    }
}
