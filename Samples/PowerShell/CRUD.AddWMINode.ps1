# This sample script demonstrates how to add a new node using CRUD operations and add WMI Polling.
# Please update the hostname and credential setup to match your configuration, and
# information about the node you would like to add for monitoring.

#Region PSSnapin presence check/add
if (-not (Get-PSSnapin -Name "SwisSnapin" -ErrorAction SilentlyContinue))
{    
    Add-PSSnapin SwisSnapin -ErrorAction SilentlyContinue
}
#EndRegion

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

#Status
AddPoller("N.Status.ICMP.Native")

#ResponseTime
AddPoller("N.ResponseTime.ICMP.Native")

#Details
AddPoller("N.Details.WMI.Vista")

#Uptime
AddPoller("N.Uptime.WMI.XP")

#CPU
AddPoller("N.Cpu.WMI.Windows")

#Memory
AddPoller("N.Memory.WMI.Windows")
