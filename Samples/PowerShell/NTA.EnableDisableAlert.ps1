# This sample script demonstrates how to enable/disable NTA alert identified
# by its name.
# You need to be logged as a user with Allow Alert Management rights.

Import-Module SwisPowerShell

# Connect to SWIS
$hostname = "swis-machine-hostname"                     # Update to match your configuration
$username = "admin"                                     # Update to match your configuration
$password = New-Object System.Security.SecureString     # Update to match your configuration
$cred = New-Object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
$swis = Connect-Swis -host $hostname -cred $cred

$alertName = "NTA Alert on machine-hostname"
$alertUri = Get-SwisData -SwisConnection $swis -Query "Select Uri FROM Orion.AlertConfigurations WHERE Name = @alertName" -Parameters @{alertName = $alertName}

# Disable alert
$enabledProps = @{
    Enabled = $false;
}
Set-SwisObject -SwisConnection $swis -Uri $alertUri -Properties $enabledProps | Out-Null

# Enable alert
$enabledProps = @{
    Enabled = $true;
}
Set-SwisObject -SwisConnection $swis -Uri $alertUri -Properties $enabledProps | Out-Null