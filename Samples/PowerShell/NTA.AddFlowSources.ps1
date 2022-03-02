# This sample script demonstrates how to add enabled Flow Sources with
# required Orion node and interfaces. Interfaces are discovered with NPM 
# discovery feature.
# You need to be logged as a user with enabled Allow Node Management Rights.

Import-Module SwisPowerShell

# Connect to SWIS
$hostname = "swis-machine-hostname"                     # Update to match your configuration
$username = "admin"                                     # Update to match your configuration
$password = New-Object System.Security.SecureString     # Update to match your configuration
$cred = New-Object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
$swis = Connect-Swis -host $hostname -cred $cred

# Default engine ID
$engineId = 1

# Create Orion Node
# Update to match your configuration
$nodeCaption = "example.com"
$newSNMPV2NodeProps = @{
    IPAddress = "1.1.1.1"
    EngineID = $engineId
    Caption = $nodeCaption
    ObjectSubType ="SNMP"
    Community = "public"
    SNMPVersion = 2
    DNS = ""
    SysName = ""
}
New-SwisObject -SwisConnection $swis -EntityType Orion.Nodes -Properties $newSNMPV2NodeProps
$nodeId = Get-SwisData -SwisConnection $swis -Query "SELECT NodeID FROM Orion.Nodes WHERE Caption = @nodeCaption" -Parameters @{nodeCaption = $nodeCaption}
Write-Host "New node with ID $nodeId created"

# Discover and create interfaces for Node
$discovered = Invoke-SwisVerb -SwisConnection $swis -EntityName Orion.NPM.Interfaces -Verb DiscoverInterfacesOnNode -Arguments $nodeId
if($discovered.Result -ne "Succeed") {
    Write-Error "Interface discovery for node with ID $nodeId failed" -ErrorAction Stop
}
Invoke-SwisVerb -SwisConnection $swis -EntityName Orion.NPM.Interfaces -Verb AddInterfacesOnNode -Arguments @($nodeId, $discovered.DiscoveredInterfaces, 'AddDefaultPollers') | Out-Null
$interfaceIds = Get-SwisData -SwisConnection $swis -Query "SELECT InterfaceID FROM Orion.NPM.Interfaces WHERE NodeID = @nodeID" -Parameters @{nodeID = $nodeId}
$interfaceIds = $interfaceIds | ForEach-Object {[int]$_}
Write-Host "Discovered $($interfaceIds.Count) interfaces for new node with ID $nodeId" 

# Enable Flow Collection on every interface of the router - Create Netflow Sources
Invoke-SwisVerb -SwisConnection $swis -EntityName Orion.Netflow.Source -Verb EnableFlowSources -Arguments @(,$interfaceIds) | Out-Null
$flowSourcesIds = Get-SwisData -SwisConnection $swis -Query "SELECT NetflowSourceID FROM Orion.Netflow.Source WHERE NodeID = @nodeID" -Parameters @{nodeID = $nodeId}
Write-Host("$($flowSourcesIds.Count) Netflow Sources created")
