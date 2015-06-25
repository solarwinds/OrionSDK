using System;
using System.Collections.Generic;

namespace SwqlStudio
{
    internal class ServerList
    {
        private readonly Dictionary<string, ConnectionInfo> connections = new Dictionary<string, ConnectionInfo>();

        public void Add(ConnectionInfo connection)
        {
            connections.Add(GetKey(connection), connection);
        }

        public void Remove(ConnectionInfo connection)
        {
            connections.Remove(GetKey(connection));
        }

        public bool Exists(ConnectionInfo connection)
        {
            return connections.ContainsKey(GetKey(connection));
        }

        public bool TryGet(string serverType, string server, string username, out ConnectionInfo connection)
        {
            return connections.TryGetValue(GetKey(serverType, server, username), out connection);
        }

        private string GetKey(ConnectionInfo connection)
        {
            return GetKey(connection.ServerType, connection.Server, connection.UserName);
        }

        private string GetKey(string serverType, string server, string username)
        {
            return String.Format("{0},{1},{2}", serverType, server, username);

        }
    }
}
