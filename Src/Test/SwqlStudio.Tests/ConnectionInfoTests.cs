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

        private class TestConnectionInfo : ConnectionInfo
        {
            public TestConnectionInfo(string server = "localhost", string user = "user", string pass = "pass", string type = "Orion (v3)", FakeInfoService infoService = null)
                : base(server, user, pass, type, infoService ?? new FakeInfoService())
            {
            }

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

            public UnopenableProxy LastProxy { get; private set; }

            public InfoServiceProxy OpenedProxy { get; private set; }

            public int CreateProxyCount { get; private set; }

            public override InfoServiceProxy CreateProxy(string server)
            {
                CreateProxyCount++;

                if (FirstProxyOpens && CreateProxyCount == 1)
                {
                    OpenedProxy = new LocalHttpProxy(_credentials);
                    return OpenedProxy;
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
    }
}
