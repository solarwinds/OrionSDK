# This sample script demonstrates how to enable/disable CBQoS source
# identified by its Caption
# You need to be logged as a user with enabled Allow Node Management Rights.


# Connect to SWIS
$hostname = "swis-machine-hostname"                     # Update to match your configuration
$username = "admin"                                     # Update to match your configuration
$password = New-Object System.Security.SecureString     # Update to match your configuration
$cred = New-Object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
$swis = Connect-Swis -host $hostname -cred $cred

# Disable CBQoS Sources
$nodeCaption = "My testing router"
$nodeId = Get-SwisData $swis "SELECT NodeID FROM Orion.Nodes WHERE Caption = '$nodeCaption'"
$cbqosSourcesUris = Get-SwisData $swis "SELECT Uri FROM Orion.Netflow.CBQoSSource WHERE NodeID = $nodeID"

$disableProps = @{
    Enabled = $false;
}
foreach ($cbqosSourcesUri in $cbqosSourcesUris)
{
    Set-SwisObject $swis -Uri $cbqosSourcesUri -Properties $disableProps | Out-Null
}
$disableCbqosSourcesIds = Get-SwisData $swis "SELECT CBQoSSourceID FROM Orion.Netflow.CBQoSSource WHERE NodeID = $nodeID and Enabled = false"
Write-Host("Disabled $($disableCbqosSourcesIds.Count) CBQoS Sources for Node with ID $nodeId. Total interface count $($cbqosSourcesUris.Count).")

# Enable CBQoS Sources
$enabledProps = @{
    Enabled = $true;
}
foreach ($cbqosSourcesUri in $cbqosSourcesUris)
{
    Set-SwisObject $swis -Uri $cbqosSourcesUri -Properties $enabledProps | Out-Null
}
$enabledCbqosSourcesIds = Get-SwisData $swis "SELECT CBQoSSourceID FROM Orion.Netflow.CBQoSSource WHERE NodeID = $nodeID and Enabled = true"
Write-Host("Enabled $($enabledCbqosSourcesIds.Count) CBQoS sources for Node with ID $nodeId. Total interface count $($cbqosSourcesUris.Count).")
