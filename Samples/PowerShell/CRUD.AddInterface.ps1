# This sample script demonstrates how to add a new interface using CRUD operations.
#
# Please update the hostname and credential setup to match your configuration, and
# reference to an existing node and interface you would like to add for monitoring.

# Connect to SWIS
$hostname = "localhost"
$username = "admin"
$password = New-Object System.Security.SecureString
$cred = New-Object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
$swis = Connect-Swis -host $hostname -cred $cred

# add an interface, please fill in the correct values you need
$newIfaceProps = @{
    NodeID = 1;  # NodeID where the interface appears
    InterfaceName = "FastEthernet0/0";  # Name of the interface to add
    IfName = "Fa0/0";
    InterfaceIndex = 0;
    ObjectSubType = "SNMP";
    Status = 0;
    RediscoveryInterval = 5;
    PollInterval = 120;
    StatCollection = 10;
}
$newIfaceUri = New-SwisObject $swis -EntityType "Orion.NPM.Interfaces" -Properties $newIfaceProps
$ifaceProps = Get-SwisObject $swis -Uri $newIfaceUri

# register specific pollers for the node
$poller = @{
    NetObject = "I:" + $ifaceProps["InterfaceID"];
    NetObjectType = "I";
    NetObjectID = $ifaceProps["InterfaceID"];
}

# Status
$poller["PollerType"]="I.Status.SNMP.IfTable";
$pollerUri = New-SwisObject $swis -EntityType "Orion.Pollers" -Properties $poller

# Interface Traffic
$poller["PollerType"]="I.StatisticsTraffic.SNMP.Universal";
$pollerUri = New-SwisObject $swis -EntityType "Orion.Pollers" -Properties $poller

# Interface Errors
$poller["PollerType"]="I.StatisticsErrors32.SNMP.IfTable";
$pollerUri = New-SwisObject $swis -EntityType "Orion.Pollers" -Properties $poller

# Rediscovery
$poller["PollerType"]="I.Rediscovery.SNMP.IfTable";
$pollerUri = New-SwisObject $swis -EntityType "Orion.Pollers" -Properties $poller
