# This script copies nodes from one Orion system to another. If the target Orion system has NCM 
# installed, then the script will cause those nodes to be managed in NCM as well.
# For more details, see this blog post on thwack: 
# http://thwack.solarwinds.com/community/solarwinds-community/product-blog/blog/2012/03/06/how-to-automate-the-creation-of-orion-platform-aka-core-nodes-from-the-api

$ErrorActionPreference = 'Stop'

# Change this to $true if you want Volumes to be copied as well
$CopyVolumes = $false

# Change this to $true if you want interfaces to be copied as well
$CopyInterfaces = $false

# Set up the hostname, username, and password for the source system
$hostname1 = "10.199.15.78";
$password1 = New-Object System.Security.SecureString  #"" | ConvertTo-SecureString -asPlainText -Force
$username1 = "admin"

# Set up the hostname, username, and password for the target system
$hostname2 = "10.199.15.79";
$password2 = New-Object System.Security.SecureString  #"" | ConvertTo-SecureString -asPlainText -Force
$username2 = "admin"

# Load SwisPowerShell
Import-Module SwisPowerShell

# Connect to the source system
$credential1 = New-Object System.Management.Automation.PSCredential($username1,$password1)
$source = Connect-Swis -Credential $credential1 -Hostname $hostname1

# Connect to the target system
$credential2 = New-Object System.Management.Automation.PSCredential($username2,$password2)
$target = Connect-Swis -Credential $credential2 -Hostname $hostname2

# SWISv2 connection to target system is needed for calling AddNodeToNCM verb
$targetV2 = Connect-Swis -v2 -Credential $credential2 -Hostname $hostname2

function IsEmpty($str) {
    $str -eq $null -or $str -eq '' -or $str.GetType() -eq [DBNull]
}

# Define which properties will be copied from the source to the target for Nodes, Interfaces, and Volumes
$nodePropsToCopy = @("AgentPort", "Allow64BitCounters", "BufferBgMissThisHour", "BufferBgMissToday", "BufferHgMissThisHour", "BufferHgMissToday",
    "BufferLgMissThisHour", "BufferLgMissToday", "BufferMdMissThisHour", "BufferMdMissToday", "BufferNoMemThisHour", "BufferNoMemToday",
    "BufferSmMissThisHour", "BufferSmMissToday", "Caption", "ChildStatus", "CMTS", "Community", "Contact", "DNS", "DynamicIP", "External",
    "EntityType", "GroupStatus", "IOSImage", "IOSVersion", "IPAddress", "IPAddressGUID", "IPAddressType", "LastSystemUpTimePollUtc", 
    "Location", "MachineType", "NodeDescription", "ObjectSubType", "PollInterval", "RediscoveryInterval", "Severity", "SNMPVersion",
    "StatCollection", "Status", "StatusDescription", "StatusLED", "SysName", "SysObjectID", "TotalMemory", "Vendor", "VendorIcon",
    "RWCommunity", "SNMPV3AuthKey", "SNMPV3AuthKeyIsPwd", "SNMPV3AuthMethod", "SNMPV3Context", "SNMPV3PrivKey", "SNMPV3PrivKeyIsPwd",
    "SNMPV3PrivMethod", "SNMPV3Username", "RWSNMPV3AuthKey", "RWSNMPV3AuthKeyIsPwd", "RWSNMPV3AuthMethod", "RWSNMPV3Context", "RWSNMPV3PrivKey",
    "RWSNMPV3PrivKeyIsPwd", "RWSNMPV3PrivMethod", "RWSNMPV3Username")

$interfacePropsToCopy = @("AdminStatus", "AdminStatusLED", "Caption", "Counter64", "CustomBandwidth", "FullName", 
    "IfName", "InBandwidth", "Inbps", "InDiscardsThisHour", "InDiscardsToday", "InErrorsThisHour", "InErrorsToday", 
    "InMcastPps", "InPercentUtil", "InPktSize", "InPps", "InterfaceAlias", "InterfaceIcon", "InterfaceIndex", 
    "InterfaceMTU", "InterfaceName", "InterfaceSpeed", "InterfaceSubType", "InterfaceType", "InterfaceTypeDescription", 
    "InterfaceTypeName", "InUcastPps", "MaxInBpsToday", "MaxOutBpsToday", "ObjectSubType", "OperStatus", "OutBandwidth", 
    "Outbps", "OutDiscardsThisHour", "OutDiscardsToday", "OutErrorsThisHour", "OutErrorsToday", "OutMcastPps", 
    "OutPercentUtil", "OutPktSize", "OutPps", "OutUcastPps", "PhysicalAddress", "PollInterval", "RediscoveryInterval", 
    "Severity", "StatCollection", "Status", "StatusLED", "UnManaged", "UnPluggable")

$volumePropsToCopy = @("Icon", "Index", "Caption", "StatusIcon", "Type", "Size", "Responding", "FullName", 
    "VolumePercentUsed", "VolumeAllocationFailuresThisHour", "VolumeDescription", "VolumeSpaceUsed", 
    "VolumeAllocationFailuresToday", "VolumeSpaceAvailable")
    
# Create the property ImportedByAPI in the remote system
if ((Get-SwisData $target "SELECT Name FROM Metadata.Property where entityname = 'Orion.NodesCustomProperties' and Name = 'ImportedByAPI'") -eq $null) {
    Invoke-SwisVerb -Swis $target Orion.NodesCustomProperties CreateCustomProperty @("ImportedByAPI", "created from PowerShell", "System.String", 100, "", "", "", "", "", "")
}

# Check whether both the source and target have NPM installed
$sourceHasInterfaces = (Get-SwisData $source "SELECT Name FROM Metadata.Entity WHERE FullName='Orion.NPM.Interfaces'") -ne $null
$targetHasInterfaces = (Get-SwisData $target "SELECT Name FROM Metadata.Entity WHERE FullName='Orion.NPM.Interfaces'") -ne $null

# Check whether the target has NCM installed
$targetHasNCM = (Get-SwisData $target "SELECT CanInvoke FROM Metadata.Verb WHERE EntityName='Cirrus.Nodes' AND Name='AddNodeToNCM'") -ne $null

# Get the complete list of Nodes from the source system
# You can add a WHERE clause to this query if you only want to copy certain nodes
$sourceNodes = Get-SwisData $source "SELECT Uri, IPAddress, Caption, NodeID FROM Orion.Nodes"

foreach ($sourceNode in $sourceNodes) {
    # See if there is aleady a node on the target with the same IP address
    $targetNodeUri = Get-SwisData $target "SELECT Uri FROM Orion.Nodes WHERE IPAddress=@ip" @{ip=$sourceNode.IPAddress}

    if ($targetNodeUri -ne $null) {
        Write-Host "Skipping" $sourceNode.Caption "(" $sourceNode.IPAddress ") because it is already managed by " $hostname2
        continue
    }

    # Fetch all properties of the source node
    $sourceNodeProps = Get-SwisData $source "SELECT AgentPort, Allow64BitCounters, BufferBgMissThisHour, BufferBgMissToday, BufferHgMissThisHour, BufferHgMissToday, BufferLgMissThisHour,
        BufferLgMissToday, BufferMdMissThisHour, BufferMdMissToday, BufferNoMemThisHour, BufferNoMemToday, BufferSmMissThisHour, BufferSmMissToday,
        Caption, ChildStatus, CMTS, Community, Contact, DNS, DynamicIP, External, EntityType, GroupStatus, IOSImage, IOSVersion, IPAddress, IPAddressGUID,
        IPAddressType, LastSystemUpTimePollUtc, Location, MachineType, NodeDescription, ObjectSubType, PollInterval, RediscoveryInterval, Severity, SNMPVersion,
        StatCollection, Status, StatusDescription, StatusLED, SysName, SysObjectID, TotalMemory, Vendor, VendorIcon, RWCommunity,
        Nodes.SNMPv3Credentials.Username AS SNMPV3Username, Nodes.SNMPv3Credentials.Context AS SNMPV3Context, 
        Nodes.SNMPv3Credentials.PrivacyMethod AS SNMPV3PrivMethod, Nodes.SNMPv3Credentials.PrivacyKey AS SNMPV3PrivKey, 
        Nodes.SNMPv3Credentials.PrivacyKeyIsPassword AS SNMPV3PrivKeyIsPwd, Nodes.SNMPv3Credentials.AuthenticationMethod AS SNMPV3AuthMethod, 
        Nodes.SNMPv3Credentials.AuthenticationKey AS SNMPV3AuthKey, Nodes.SNMPv3Credentials.AuthenticationKeyIsPassword AS SNMPV3AuthKeyIsPwd, 
        Nodes.SNMPv3Credentials.RWUsername AS RWSNMPV3Username, Nodes.SNMPv3Credentials.RWContext AS RWSNMPV3Context, 
        Nodes.SNMPv3Credentials.RWPrivacyMethod AS RWSNMPV3PrivMethod, Nodes.SNMPv3Credentials.RWPrivacyKey AS RWSNMPV3PrivKey, 
        Nodes.SNMPv3Credentials.RWPrivacyKeyIsPassword AS RWSNMPV3PrivKeyIsPwd, Nodes.SNMPv3Credentials.RWAuthenticationMethod AS RWSNMPV3AuthMethod, 
        Nodes.SNMPv3Credentials.RWAuthenticationKey AS RWSNMPV3AuthKey, Nodes.SNMPv3Credentials.RWAuthenticationKeyIsPassword AS RWSNMPV3AuthKeyIsPwd
        From Orion.Nodes Where NodeID = @nodeid" @{nodeid=$sourceNode.Nodeid}

    # Skip WMI nodes - this script does not support copying Windows credentials
    if ($sourceNodeProps.ObjectSubType -eq "WMI") {
        Write-Host "Skipping" $sourceNode.Caption "(" $sourceNode.IPAddress ") because it uses WMI."
        continue
    }

    # Make an in-memory copy of the node
    Write-Host "Copying" $sourceNode.Caption "(" $sourceNode.IPAddress ")"
    $targetNodeProps = @{}
    $nodePropsToCopy | %{ $targetNodeProps[$_] = $sourceNodeProps.$_ }
    $targetNodeProps["EngineID"] = 1  # Assign all copied nodes to engine 1

    # Create the node on the target system
    $newUri = New-SwisObject $target -EntityType "Orion.Nodes" -Properties $targetNodeProps
    $newNode = Get-SwisObject $target $newUri

    # Associate the custom property "ImportedByAPI" with this node and set its value to "true"
    Set-SwisObject $target ($newUri+"/CustomProperties") @{ "ImportedByAPI"="true" }
 
    # Copy the pollers for the new node
    $pollerTypes = Get-SwisData $source "SELECT PollerType FROM Orion.Pollers WHERE NetObject=@netobject" @{ netobject='N:' + $sourceNode.NodeID }
    
    foreach ($pollerType in $pollerTypes) {
        $poller = @{
            PollerType = "$pollerType";
            NetObject = "N:" + $newNode.NodeID;
            NetObjectType = "N";
            NetObjectID = $newNode.NodeID;
        }
        Write-Host "    Adding poller $pollerType"
        New-SwisObject $target -EntityType "Orion.Pollers" -Properties $poller | Out-Null
    }

    # If NPM is installed on both the source and target systems...
    if ($CopyInterfaces) {
        if ($sourceHasInterfaces -and $targetHasInterfaces) {
            # Get the interfaces on the source node
            $sourceInterfaces = Get-SwisData $source "SELECT Nodes.Interfaces.Uri FROM Orion.Nodes WHERE NodeID=@node" @{ node=$sourceNode.NodeID }

            foreach ($sourceInterface in $sourceInterfaces) {
                if (IsEmpty($sourceInterface)) {
                    continue
                }

                $sourceIfProps = Get-SwisObject $source $sourceInterface
                Write-Host "  Copying" $sourceNode.Caption "/" $sourceIfProps.Caption
                $targetIfProps = @{}
                $interfacePropsToCopy | %{ $targetIfProps[$_] = $sourceIfProps[$_] }
                $targetIfProps["NodeID"] = $newNode.NodeID

                # Create the copy
                $newIfUri = New-SwisObject $target -EntityType "Orion.NPM.Interfaces" -Properties $targetIfProps
                $newIf = Get-SwisObject $target $newIfUri

                # Copy the pollers for the new interface
                $ifPollerTypes = Get-SwisData $source "SELECT PollerType FROM Orion.Pollers WHERE NetObject=@netobject" @{ netobject = 'I:'+$sourceIfProps.InterfaceID }
        
                foreach ($ifPollerType in $ifPollerTypes) {
                    $ifPoller = @{
                        PollerType = "$ifPollerType";
                        NetObject = "I:" + $newIf.InterfaceID;
                        NetObjectType = "I";
                        NetObjectID = $newIf.InterfaceID;
                    }
                    Write-Host "      Adding poller $ifPollerType"
                    New-SwisObject $target -EntityType "Orion.Pollers" -Properties $ifPoller | Out-Null
                }
            }
        }
    }

    # Get the volumes on the source node
    if ($CopyVolumes) {
        $sourceVolumes = Get-SwisData $source "SELECT Nodes.Volumes.Uri FROM Orion.Nodes WHERE NodeID=@node" @{ node = $sourceNode.NodeID }

        foreach ($sourceVolume in $sourceVolumes) {
            if (IsEmpty($sourceVolume)) {
                continue
            }

            $sourceVolProps = Get-SwisObject $source $sourceVolume
            Write-Host "  Copying" $sourceNode.Caption "/" $sourceVolProps.Caption
            $targetVolProps = @{}
            $volumePropsToCopy | %{ $targetVolProps[$_] = $sourceVolProps[$_] }
            $targetVolProps["NodeID"] = $newNode.NodeID

            # Create the copy
            $newVolUri = New-SwisObject $target -EntityType "Orion.Volumes" -Properties $targetVolProps
            $newVol = Get-SwisObject $target $newVolUri

            # Copy the pollers for the new Volume
            $volPollerTypes = Get-SwisData $source "SELECT PollerType FROM Orion.Pollers WHERE NetObject=@netobject" @{ netobject='V:' + $sourceVolProps.VolumeID }
    
            foreach ($volPollerType in $volPollerTypes) {
                $volPoller = @{
                    PollerType = "$volPollerType";
                    NetObject = "V:"+$newVol.VolumeID;
                    NetObjectType = "V";
                    NetObjectID = $newVol.VolumeID;
                }
                Write-Host "      Adding poller $volPollerType"
                New-SwisObject $target -EntityType "Orion.Pollers" -Properties $volPoller | Out-Null
            }
        }
    }

    # If the target has NCM installed, add the new node to NCM
    if ($targetHasNCM) {
        Invoke-SwisVerb $targetV2 Cirrus.Nodes AddNodeToNCM $newNode.NodeID
    }
}
