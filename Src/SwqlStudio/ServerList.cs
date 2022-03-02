using System;
using System.Collections.Generic;
using SwqlStudio.Metadata;

namespace SwqlStudio
{
    internal class ServerList
    {
        internal delegate void ConnectionsEventHandler(object sender, ConnectionsEventArgs e);
        private readonly Dictionary<string, ConnectionInfo> connections = new Dictionary<string, ConnectionInfo>();

        private readonly Dictionary<ConnectionInfo, IMetadataProvider> metadataProviders =
            new Dictionary<ConnectionInfo, IMetadataProvider>();

        public event ConnectionsEventHandler ConnectionAdded;

        public event ConnectionsEventHandler ConnectionRemoved;

        public void Add(ConnectionInfo connection)
        {
            string key = GetKey(connection);
            connections.Add(key, connection);
            var provider = new SwisMetaDataProvider(connection);
            metadataProviders[connection] = provider;
            var e = new ConnectionsEventArgs(connection);
            ConnectionAdded?.Invoke(this, e);
        }

        public void Remove(ConnectionInfo connection)
        {
            string key = GetKey(connection);
            connections.Remove(key);
            metadataProviders.Remove(connection);
            var e = new ConnectionsEventArgs(connection);
            ConnectionRemoved?.Invoke(this, e);
        }

        public bool Exists(ConnectionInfo connection)
        {
            string key = GetKey(connection);
            return connections.ContainsKey(key);
        }

        public bool TryGet(string serverType, string server, string username, out ConnectionInfo connection)
        {
            string key = GetKey(serverType, server, username);
            return connections.TryGetValue(key, out connection);
        }

        private string GetKey(ConnectionInfo connection)
        {
            return GetKey(connection.ServerType, connection.Server, connection.UserName);
        }

        private string GetKey(string serverType, string server, string username)
        {
            return string.Format("{0},{1},{2}", serverType, server, username);
        }

        public bool TryGetProvider(ConnectionInfo connection, out IMetadataProvider provider)
        {
            return metadataProviders.TryGetValue(connection, out provider);
        }
    }
}
