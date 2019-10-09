# This sample script demonstrates how to enable/disable NTA alert identified
# by its name.
# You need to be logged as a user with Allow Alert Management rights.


# Connect to SWIS
$hostname = "swis-machine-hostname"                     # Update to match your configuration
$username = "admin"                                     # Update to match your configuration
$password = New-Object System.Security.SecureString     # Update to match your configuration
$cred = New-Object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
$swis = Connect-Swis -host $hostname -cred $cred

$alertName = "NTA Alert on machine-hostname"
$alertUri = Get-SwisData $swis "Select Uri FROM Orion.AlertConfigurations WHERE Name = '$alertName'"

# Disable alert
$enabledProps = @{
    Enabled = $false;
}
Set-SwisObject $swis -Uri $alertUri -Properties $enabledProps | Out-Null

# Enable alert
$enabledProps = @{
    Enabled = $true;
}
Set-SwisObject $swis -Uri $alertUri -Properties $enabledProps | Out-Null