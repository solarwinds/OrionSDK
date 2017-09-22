# This sample script demonstrates how to add a new node using CRUD operations and add WMI Polling.
# Please update the hostname and credential setup to match your configuration, and
# information about the node you would like to add for monitoring.

# Load SwisPowerShell
Import-Module SwisPowerShell

Clear-Host

function AddPoller($PollerType) {
    $poller["PollerType"] = $PollerType
    $pollerUri = New-SwisObject $swis -EntityType "Orion.Pollers" -Properties $poller
}

# Connect to SWIS with default admin credentials
$target="localhost"
$swis = Connect-Swis -host $target -UserName admin -Password ""

$ip = "10.100.1.1"
$credentialName = "ValidCredentialName" # Enter here the name under which the WMI credentials are stored. You can find it in the "Manage Windows Credentials" section of the Orion website (Settings)

# Node properties
$newNodeProps = @{
    IPAddress = $ip
    EngineID = 1
    ObjectSubType = "WMI"

    DNS = ""
    SysName = ""
}

#Creating the node
$newNodeUri = New-SwisObject $swis -EntityType "Orion.Nodes" -Properties $newNodeProps
$nodeProps = Get-SwisObject $swis -Uri $newNodeUri

#Getting the Credential ID
$credentialId = Get-SwisData $swis "SELECT ID FROM Orion.Credential where Name = '$credentialName'"
if (!$credentialId) {
	Throw "Can't find the Credential with the provided Credential name '$credentialName'."
}

#Adding NodeSettings
$nodeSettings = @{
    NodeID = $nodeProps["NodeID"]
    SettingName = "WMICredential"
    SettingValue = ($credentialId.ToString())
}

#Creating node settings
$newNodeSettings = New-SwisObject $swis -EntityType "Orion.NodeSettings" -Properties $nodeSettings

# register specific pollers for the node
$poller = @{
    NetObject = "N:" + $nodeProps["NodeID"]
    NetObjectType = "N"
    NetObjectID = $nodeProps["NodeID"]
}

#region Add Pollers for Status (Up/Down), Response Time, Details, Uptime, CPU, & Memory
# Status
$poller["PollerType"]="N.Status.ICMP.Native";
$pollerUri = New-SwisObject $swis -EntityType "Orion.Pollers" -Properties $poller

# Response time
$poller["PollerType"]="N.ResponseTime.ICMP.Native";
$pollerUri = New-SwisObject $swis -EntityType "Orion.Pollers" -Properties $poller

# Details
$poller["PollerType"]="N.Details.WMI.Vista";
$pollerUri = New-SwisObject $swis -EntityType "Orion.Pollers" -Properties $poller

# Uptime
$poller["PollerType"]="N.Uptime.WMI.XP";
$pollerUri = New-SwisObject $swis -EntityType "Orion.Pollers" -Properties $poller

# CPU
$poller["PollerType"]="N.Cpu.WMI.Windows";
$pollerUri = New-SwisObject $swis -EntityType "Orion.Pollers" -Properties $poller

# Memory
$poller["PollerType"]="N.Memory.WMI.Windows";
$pollerUri = New-SwisObject $swis -EntityType "Orion.Pollers" -Properties $poller 
#endregion Add Pollers for Status (Up/Down), Response Time, Details, Uptime, CPU, & Memory
