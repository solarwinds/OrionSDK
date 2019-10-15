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


# Disable Flow Sources
$nodeCaption = "My test router"
$nodeId = Get-SwisData -SwisConnection $swis -Query "SELECT NodeID FROM Orion.Nodes WHERE Caption = @nodeCaption" -Parameters @{nodeCaption = $nodeCaption}
$flowSourcesIds = Get-SwisData -SwisConnection $swis -Query "SELECT NetflowSourceID FROM Orion.Netflow.Source WHERE NodeID = @nodeID" -Parameters @{nodeID = $nodeId}
$flowSourcesIds = $flowSourcesIds | ForEach-Object {[int]$_}
Invoke-SwisVerb -SwisConnection $swis -EntityName Orion.Netflow.Source -Verb DisableFlowSources -Arguments @(,$flowSourcesIds) | Out-Null
$disableflowSourcesIds = Get-SwisData -SwisConnection $swis -Query "SELECT NetflowSourceID FROM Orion.Netflow.Source WHERE NodeID = @nodeID and Enabled = false" -Parameters @{nodeID = $nodeId}
Write-Host "Disabled $($disableflowSourcesIds.Count) Flow Sources for node with ID $nodeId. Total interface count $($flowSourcesIds.Count)"

# Enable Flow Sources
Invoke-SwisVerb -SwisConnection $swis -EntityName Orion.Netflow.Source -Verb EnableFlowSources -Arguments @(,$flowSourcesIds) | Out-Null
$enabledflowSourcesIds = Get-SwisData -SwisConnection $swis -Query "SELECT NetflowSourceID FROM Orion.Netflow.Source WHERE NodeID = @nodeID and Enabled = true" -Parameters @{nodeID = $nodeId}
Write-Host "Enabled $($enabledflowSourcesIds.Count) Flow Sources for Node with ID $nodeId. Total interface count $($flowSourcesIds.Count)"
