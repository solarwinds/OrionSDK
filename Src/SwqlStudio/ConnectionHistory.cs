using System;
using System.Collections.Generic;
using SwqlStudio.Properties;

namespace SwqlStudio
{
    class ConnectionHistory
    {
        private static List<string> _previousServers;
        private static List<string> _previousUsers;

        public static string[] PreviousServers
        {
            get
            {
                if (_previousServers == null)
                {
                    _previousServers = LoadPreviousEntryList(Settings.Default.PreviousServers);
                }
                return _previousServers.ToArray();
            }
        }

        public static string[] PreviousUserNames
        {
            get
            {
                if (_previousUsers == null)
                {
                    _previousUsers = LoadPreviousEntryList(Settings.Default.PreviousUsers);
                }
                return _previousUsers.ToArray();
            }
        }

        public static string PreviousServerType
        {
            get { return Settings.Default.PreviousServerType; }
            set
            {
                Settings.Default.PreviousServerType = value;
                Settings.Default.Save();
            }
        }

        public static void AddServer(string server)
        {
            AddToList(_previousServers, server);
            Settings.Default.PreviousServers = string.Join(";", _previousServers.ToArray());
            Settings.Default.Save();
        }

        public static void AddUser(string user)
        {
            AddToList(_previousUsers, user);
            Settings.Default.PreviousUsers = string.Join(";", _previousUsers.ToArray());
            Settings.Default.Save();
        }

        private static List<string> LoadPreviousEntryList(string packedSetting)
        {
            string[] previousAsArray = packedSetting.Split(new[] { ';' });
            return new List<string>(previousAsArray);
        }

        private static void AddToList(List<string> list, string newItem)
        {
            list.Remove(newItem);
            list.Insert(0, newItem);
            // TODO: Should we trim this to the last N items?
        }

    }
}
