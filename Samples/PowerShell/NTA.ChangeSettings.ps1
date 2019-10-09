# This sample script demonstrates how to change Netflow related Orion Settings
# for example to enable/disable CBQoS polling.
# You need to be logged as a user with admin rights.


# Connect to SWIS
$hostname = "swis-machine-hostname"                     # Update to match your configuration
$username = "admin"                                     # Update to match your configuration
$password = New-Object System.Security.SecureString     # Update to match your configuration
$cred = New-Object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
$swis = Connect-Swis -host $hostname -cred $cred

# List available Orion Settings
# Uncomment if you want to get  all available Orion Settings
# Get-SwisData $swis "SELECT SettingID, Name, Description, Units, Minimum, Maximum, CurrentValue, DefaultValue, Hint FROM Orion.Settings"

# Enable/Disable CBQoS polling
$settingId = 'CBQoS_Enabled'
$settingUri = Get-SwisData $swis "SELECT Uri FROM Orion.Settings WHERE SettingID = '$settingId'"
$props = @{
    CurrentValue = 0;   # Change this value to 1 to enable setting
}
Set-SwisObject $swis -Uri $settingUri -Properties $props | Out-Null
$settingUri = Get-SwisData $swis "SELECT CurrentValue FROM Orion.Settings WHERE SettingID = '$settingId'"
Write-Host("Setting $settingId has value $currentValue")
