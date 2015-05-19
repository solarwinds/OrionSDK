# This sample script demonstrates how to add a new node using CRUD operations.
#
# Please update the hostname and credential setup to match your configuration, and
# information about the node you would like to add for monitoring.

# Connect to SWIS
$hostname = "localhost"
$username = "admin"
$password = New-Object System.Security.SecureString
$cred = New-Object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
$swis = Connect-Swis -host $hostname -cred $cred

$ip = "10.0.0.1"

# add a node
$newNodeProps = @{

  IPAddress=$ip;
  EngineID=1;
  
  # SNMP v2 specific
  ObjectSubType="SNMP";

  SNMPVersion=2;

  # === default values ===

  # EntityType = 'Orion.Nodes'
  # Caption = ''
  # DynamicIP = false
  # PollInterval = 120
  # RediscoveryInterval = 30
  # StatCollection = 10  
}

$newNodeUri = New-SwisObject $swis -EntityType "Orion.Nodes" -Properties $newNodeProps
$nodeProps = Get-SwisObject $swis -Uri $newNodeUri

# register specific pollers for the node
$poller = @{
  NetObject="N:"+$nodeProps["NodeID"];
  NetObjectType="N";
  NetObjectID=$nodeProps["NodeID"];
}
# Details
$poller["PollerType"]="N.Details.SNMP.Generic";
$pollerUri = New-SwisObject $swis -EntityType "Orion.Pollers" -Properties $poller
# Uptime
$poller["PollerType"]="N.Uptime.SNMP.Generic";
$pollerUri = New-SwisObject $swis -EntityType "Orion.Pollers" -Properties $poller
# CPU
$poller["PollerType"]="N.Cpu.SNMP.CiscoGen3";
$pollerUri = New-SwisObject $swis -EntityType "Orion.Pollers" -Properties $poller
# Memory
$poller["PollerType"]="N.Memory.SNMP.CiscoGen3";
$pollerUri = New-SwisObject $swis -EntityType "Orion.Pollers" -Properties $poller
