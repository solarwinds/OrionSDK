using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CSRestClient
{
    internal class Program
    {
        private const string Hostname = "localhost";
        private const string Username = "admin";
        private const string Password = "";

        private static void Main()
        {
            try
            {
                var swisClient = new SwisClient(Hostname, Username, Password);
                
                var alert = GetOneAlert(swisClient);
                var invokeResult = AcknowledgeAlert(swisClient, alert);
                Console.WriteLine(invokeResult);

                Console.WriteLine(AddNode(swisClient).Result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
            if (Debugger.IsAttached)
            {
                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();                
            }
        }

        private static JToken GetOneAlert(ISwisClient swisClient)
        {
            const string query = @"SELECT TOP 1 AlertDefID, ActiveObject, ObjectType 
FROM Orion.AlertStatus
WHERE Acknowledged=0
ORDER BY TriggerTimeStamp DESC";

            JToken queryResult = swisClient.QueryAsync(query).Result;
            Console.WriteLine(queryResult);

            var alert = queryResult["results"][0];
            return alert;
        }

        private static JToken AcknowledgeAlert(ISwisClient swisClient, JToken alert)
        {
            JToken invokeResult = swisClient.InvokeAsync("Orion.AlertStatus", "Acknowledge", new object[]
            {
                new[]
                {
                    new
                    {
                        DefinitionId = alert["AlertDefID"],
                        ObjectType = alert["ObjectType"],
                        ObjectId = alert["ActiveObject"]
                    }
                }
            }).Result;
            return invokeResult;
        }

        private static async Task<string> AddNode(ISwisClient swisClient)
        {
            string nodeUri = await swisClient.CreateAsync("Orion.Nodes",
                new
                {
                    IPAddress = "10.199.4.3",
                    EngineID = 1,
                    ObjectSubType = "SNMP",
                    SNMPVersion = 2,
                    Community = "public"
                });

            JObject node = await swisClient.ReadAsync(nodeUri);
            int nodeId = (int)node["NodeID"];

            string[] pollerTypes = {
                "N.Status.ICMP.Native",
                "N.ResponseTime.ICMP.Native",
                "N.Details.SNMP.Generic",
                "N.Uptime.SNMP.Generic",
                "N.Cpu.SNMP.CiscoGen3",
                "N.Memory.SNMP.CiscoGen3",
                "N.HardwareHealthMonitoring.SNMP.NPM.Cisco"
            };

            foreach (string pollerType in pollerTypes)
            {
                await swisClient.CreateAsync("Orion.Pollers", new
                {
                    NetObject = "N:" + nodeId,
                    NetObjectType = "N",
                    NetObjectID = nodeId,
                    PollerType = pollerType
                });
            }

            await swisClient.CreateAsync("Orion.NodeSettings", new
            {
                NodeID = nodeId,
                SettingName = "NeedsInventory",
                SettingValue = "HWH"
            });

            return nodeUri;
        }
    }
}
