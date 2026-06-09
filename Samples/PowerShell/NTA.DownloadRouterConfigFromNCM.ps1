# This sample script demonstrates how to download configuration for Router
# from NCM. You can use it to verify Netflow related configuration on the Router.

Import-Module SwisPowerShell

# Connect to SWIS
$hostname = "swis-machine-hostname"                     # Update to match your configuration
$username = "admin"                                     # Update to match your configuration
$password = New-Object System.Security.SecureString     # Update to match your configuration
$cred = New-Object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
$swis = Connect-Swis -host $hostname -cred $cred

# Get Orion Node, Interface, Netflow Interface Source information and Router identifiers for concrete Netflow Interface Source
# You can use these alternative conditions
# If you know NodeName: WHERE s.Node.NodeName = '$nodeName'
# If you know InterfaceName: WHERE s.Interface.InterfaceName = '$interfaceName'
$nodeName = "example.com"               # Update to match your configuration
$interfaceName = "GigabitEthernet0/1"   # Update to match your configuration

$query= "
SELECT s.NodeID, s.EntityID as InterfaceID, s.Enabled, s.LastTime, ns.EngineID, 
    ns.Node.NodeName,
    i.InterfaceName, s.InterfaceIndex as RouterIndex
FROM Orion.Netflow.InterfaceSources s
JOIN Orion.Netflow.NodeSources ns ON s.NodeID = ns.NodeID
JOIN Orion.NPM.Interfaces i ON s.EntityID = i.InterfaceID
WHERE s.EntityType = 'Orion.NPM.Interfaces' 
    AND ns.Node.NodeName = @nodeName 
    AND i.InterfaceName = @interfaceName
"
$params = @{
    nodeName = $nodeName
    interfaceName = $interfaceName
}

$netflowSourceInfo = Get-SwisData -SwisConnection $swis -Query $query -Parameters $params
if(!$netflowSourceInfo) {
    Write-Error "Netflow Source information not found" -ErrorAction Stop
}

# Works only if NCM is installed
# Retrieve latest NCM configuration file for concrete node identified by Orion Node ID
# You can use it to check node configuration - for example verify Netflow configuration
$orionNodeId = $netflowSourceInfo.NodeID
$query = "
SELECT TOP 1 C.NodeID AS NcmNodeId, C.NodeProperties.CoreNodeId, C.DownloadTime, C.ConfigType, C.Config
FROM NCM.ConfigArchive C
WHERE C.NodeProperties.CoreNodeID = @orionNodeId
ORDER BY C.DownloadTime DESC
"
$params = @{
    orionNodeId = $orionNodeId
}

$lastConfigData = Get-SwisData -SwisConnection $swis -Query $query -Parameters $params
if(!$lastConfigData) {
    Write-Error "Node with ID $orionNodeId is not configured in NCM or no configuration for this node has been loaded yet" -ErrorAction Stop
}
Write-Host "Configuration for node with name $nodeName, Orion ID $orionNodeId, NCM Node ID = $($lastConfigData.NcmNodeId)"
# Uncomment if you want to write configuration to console
# Write-Host $lastConfigData.Config

# You can analyze configuration manually or write some parser. To identify data related to concrete Netflow Node Source 
# you can use retrieved information in $netflowSourceInfo object like: $netflowSourceInfo.InterfaceName, $netflowSourceInfo.RouterIndex
