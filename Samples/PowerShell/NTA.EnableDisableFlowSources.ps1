# This sample script demonstrates how to enable/disable Flow Source
# identified by its Caption.
# You need to be logged as a user with enabled Allow Node Management Rights.

Import-Module SwisPowerShell

# Connect to SWIS
$hostname = "swis-machine-hostname"                     # Update to match your configuration
$username = "admin"                                     # Update to match your configuration
$password = New-Object System.Security.SecureString     # Update to match your configuration
$cred = New-Object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
$swis = Connect-Swis -host $hostname -cred $cred


# Disable Node and Interface Flow Sources
$nodeCaption = "example.com"
$nodeId = Get-SwisData -SwisConnection $swis -Query "SELECT NodeID FROM Orion.Nodes WHERE Caption = @nodeCaption" -Parameters @{nodeCaption = $nodeCaption}
$interfaceIds = Get-SwisData -SwisConnection $swis -Query "SELECT InterfaceID FROM Orion.NPM.Interfaces WHERE NodeID = @nodeID" -Parameters @{nodeID = $nodeId}
$interfaceIds = $interfaceIds | ForEach-Object {[int]$_}
Invoke-SwisVerb -SwisConnection $swis -EntityName Orion.Netflow.NodeSources -Verb DisableFlowNodeSources  -Arguments @(,@([int]$nodeId)) | Out-Null
Invoke-SwisVerb -SwisConnection $swis -EntityName Orion.Netflow.InterfaceSources -Verb DisableFlowInterfaceSources  -Arguments @(,$interfaceIds) | Out-Null
$disableflowSourcesIds = Get-SwisData -SwisConnection $swis -Query "SELECT EntityID FROM Orion.Netflow.InterfaceSources WHERE NodeID = @nodeID and Enabled = false" -Parameters @{nodeID = $nodeId}
Write-Host "Disabled $($disableflowSourcesIds.Count) Flow Interface Sources for node with ID $nodeId. Total interface count $($interfaceIds.Count)"

# Enable Node and Interface Flow Sources
Invoke-SwisVerb -SwisConnection $swis -EntityName Orion.Netflow.NodeSources -Verb EnableFlowNodeSources  -Arguments @(,@([int]$nodeId)) | Out-Null
Invoke-SwisVerb -SwisConnection $swis -EntityName Orion.Netflow.InterfaceSources -Verb EnableFlowInterfaceSources -Arguments @(,$interfaceIds) | Out-Null
$enabledflowSourcesIds = Get-SwisData -SwisConnection $swis -Query "SELECT EntityID FROM Orion.Netflow.InterfaceSources WHERE NodeID = @nodeID and Enabled = true" -Parameters @{nodeID = $nodeId}
Write-Host "Enabled $($enabledflowSourcesIds.Count) Flow Interface Sources for Node with ID $nodeId. Total interface count $($interfaceIds.Count)"
