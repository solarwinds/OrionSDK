using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.ServiceModel;
using System.ServiceModel.Channels;
using SolarWinds.InformationService.Contract2;
using FluentAssertions;
using SwqlStudio;
using Xunit;

namespace SwqlStudio.Tests
{
    public class ConnectionVisualTests
    {
        private static void RunInSta(Action action)
        {
            Exception ex = null;
            var thread = new Thread(() =>
            {
                try
                {
                    action();
                }
                catch (Exception e)
                {
                    ex = e;
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            if (ex != null)
                throw ex;
        }

        [Fact]
        public void QueryTab_ShowsDisconnected_OnConnectionClosed()
        {
            RunInSta(() =>
            {
                var tab = new QueryTab();
                var connection = new TestConnectionInfoWrapper("localhost", "user", "pass", "Orion (v3)");
                tab.ConnectionInfo = connection;

                // Simulate auto-disconnect event
                connection.TriggerClosed();
                System.Windows.Forms.Application.DoEvents(); // Process queued messages

                tab.CurrentStatus.Should().Be("Disconnected");
            });
        }

        [Fact]
        public void QueryTab_ShowsConnected_OnConnectionRestored()
        {
            RunInSta(() =>
            {
                var tab = new QueryTab();
                var connection = new TestConnectionInfoWrapper("localhost", "user", "pass", "Orion (v3)");
                tab.ConnectionInfo = connection;

                // Simulate disconnect then restore
                connection.TriggerClosed();
                System.Windows.Forms.Application.DoEvents(); // Process queued messages
                connection.SimulatedConnected = true; // a real restore means the channel is back up
                connection.TriggerRestored();
                System.Windows.Forms.Application.DoEvents(); // Process queued messages

                tab.CurrentStatus.Should().Be("Connected");
            });
        }

        [Fact]
        public void QueryTab_Resubscribes_WhenConnectionInfoChanges()
        {
            RunInSta(() =>
            {
                var tab = new QueryTab();
                var c1 = new TestConnectionInfoWrapper("server1", "user", "pass", "Orion (v3)");
                var c2 = new TestConnectionInfoWrapper("server2", "user", "pass", "Orion (v3)");

                tab.ConnectionInfo = c1;
                c1.TriggerClosed();
                System.Windows.Forms.Application.DoEvents(); // Process queued messages
                tab.CurrentStatus.Should().Be("Disconnected");

                tab.ConnectionInfo = c2;
                c2.SimulatedConnected = true; // a real restore means the channel is back up
                c2.TriggerRestored();
                System.Windows.Forms.Application.DoEvents(); // Process queued messages
                tab.CurrentStatus.Should().Be("Connected");
            });
        }

        [Fact]
        public void QueryTab_ShowsDisconnected_WhenConnectionIsNotOpen()
        {
            RunInSta(() =>
            {
                var tab = new QueryTab();
                var connection = new TestConnectionInfoWrapper("offline-server", "user", "pass", "Orion (v3)");

                tab.ConnectionInfo = connection;

                tab.CurrentStatus.Should().Be("Disconnected");
            });
        }

        [Fact]
        public void QueryTab_KeepsDisconnected_WhenConnectionIsReassigned()
        {
            RunInSta(() =>
            {
                var tab = new QueryTab();
                var connection = new TestConnectionInfoWrapper("offline-server", "user", "pass", "Orion (v3)");
                tab.ConnectionInfo = connection;

                connection.TriggerClosed();
                System.Windows.Forms.Application.DoEvents();
                tab.CurrentStatus.Should().Be("Disconnected");

                // Switching tabs reassigns the same connection; status must not revert to Connected
                tab.ConnectionInfo = connection;

                tab.CurrentStatus.Should().Be("Disconnected");
            });
        }

        [Fact]
        public void QueryTab_ShowsDisconnected_WhenRestoredHandlerRunsAfterClose()
        {
            RunInSta(() =>
            {
                var tab = new QueryTab();
                var connection = new TestConnectionInfoWrapper("server", "user", "pass", "Orion (v3)");
                connection.SimulatedConnected = true;
                tab.ConnectionInfo = connection;
                tab.CurrentStatus.Should().Be("Connected");

                connection.Close();
                connection.SimulatedConnected = false; // Close() drops the proxy

                // The handler itself is invoked after Close(); the tab must still render the real state.
                InvokeConnectionRestoredHandler(tab, connection);
                System.Windows.Forms.Application.DoEvents();

                tab.CurrentStatus.Should().Be("Disconnected");
            });
        }

        /// <summary>Calls the handler directly to simulate a stale event delivered after Close().</summary>
        private static void InvokeConnectionRestoredHandler(QueryTab tab, ConnectionInfo connection)
        {
            var handler = typeof(QueryTab).GetMethod(
                "_connectionInfo_ConnectionRestored",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            handler.Should().NotBeNull("the test targets the QueryTab connection-restored handler");
            handler.Invoke(tab, new object[] { connection, EventArgs.Empty });
        }

        [Fact]
        public void QueryStatusBar_IdleStateReflectsConnection_RatherThanReadyLiteral()
        {
            RunInSta(() =>
            {
                var statusBar = new QueryStatusBar();
                var connection = new TestConnectionInfoWrapper("offline-server", "user", "pass", "Orion (v3)");
                statusBar.Initialize(connection);

                // What a finished query now shows instead of "Ready"
                statusBar.ShowConnectionState();

                statusBar.ConnectionStatus.Should().Be("Disconnected");
            });
        }

        [Fact]
        public void QueryTab_IgnoresConnectionEvents_AfterDisposal()
        {
            RunInSta(() =>
            {
                var connection = new TestConnectionInfoWrapper("server", "user", "pass", "Orion (v3)");
                var tab = new QueryTab();
                tab.ConnectionInfo = connection;

                tab.Dispose();

                Action raiseAfterDisposal = () =>
                {
                    connection.TriggerClosed();
                    connection.TriggerRestored();
                    System.Windows.Forms.Application.DoEvents();
                };

                raiseAfterDisposal.Should().NotThrow();
            });
        }

        [Fact]
        public void QueryTab_IsNotRetainedByConnection_AfterDisposal()
        {
            RunInSta(() =>
            {
                var connection = new TestConnectionInfoWrapper("server", "user", "pass", "Orion (v3)");

                WeakReference tabReference = CreateAndDisposeTab(connection);

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();

                // A still-attached event handler would keep the disposed tab alive.
                tabReference.IsAlive.Should().BeFalse();
            });
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static WeakReference CreateAndDisposeTab(ConnectionInfo connection)
        {
            var tab = new QueryTab { ConnectionInfo = connection };
            tab.Dispose();
            return new WeakReference(tab);
        }

        private class TestConnectionInfoWrapper : ConnectionInfo
        {
            public TestConnectionInfoWrapper(string server, string username, string password, string serverType)
                : base(server, username, password, serverType, new FakeInfoService())
            {
            }

            public void TriggerClosed() => OnConnectionLost();
            public void TriggerRestored() => OnConnectionRestored();

            /// <summary>Stands in for a live channel, which a fake proxy cannot provide.</summary>
            public bool SimulatedConnected { get; set; }

            public override bool IsConnected => SimulatedConnected;
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

            public override InfoServiceProxy CreateProxy(string server)
            {
                return null;
            }
        }

        private class FakeServiceCredentials : ServiceCredentials
        {
            public override CredentialType CredentialType => CredentialType.Username;

            public override void ApplyTo(ChannelFactory channelFactory)
            {
                // no-op
            }
        }
    }
}
