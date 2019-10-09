# This sample script demonstrates how to enable/disable Flow Source
# identified by its Caption.
# You need to be logged as a user with enabled Allow Node Management Rights.


# Connect to SWIS
$hostname = "swis-machine-hostname"                     # Update to match your configuration
$username = "admin"                                     # Update to match your configuration
$password = New-Object System.Security.SecureString     # Update to match your configuration
$cred = New-Object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
$swis = Connect-Swis -host $hostname -cred $cred


# Disable Flow Sources
$nodeCaption = "My test router"
$nodeId = Get-SwisData $swis "SELECT NodeID FROM Orion.Nodes WHERE Caption = '$nodeCaption'"
$flowSourcesIds = Get-SwisData $swis "SELECT NetflowSourceID FROM Orion.Netflow.Source WHERE NodeID = $nodeID"
$flowSourcesIds = $flowSourcesIds |% {[int]$_}
Invoke-SwisVerb $swis Orion.Netflow.Source DisableFlowSources @(,$flowSourcesIds) | Out-Null
$disableflowSourcesIds = Get-SwisData $swis "SELECT NetflowSourceID FROM Orion.Netflow.Source WHERE NodeID = $nodeID and Enabled = false"
Write-Host("Disabled $($disableflowSourcesIds.Count) Flow Sources for node with ID $nodeId. Total interface count $($flowSourcesIds.Count)")

# Enable Flow Sources
Invoke-SwisVerb $swis Orion.Netflow.Source EnableFlowSources @(,$flowSourcesIds) | Out-Null
$enabledflowSourcesIds = Get-SwisData $swis "SELECT NetflowSourceID FROM Orion.Netflow.Source WHERE NodeID = $nodeID and Enabled = true"
Write-Host("Enabled $($enabledflowSourcesIds.Count) Flow Sources for Node with ID $nodeId. Total interface count $($flowSourcesIds.Count)")
