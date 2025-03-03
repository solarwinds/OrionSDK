Import-Module SwisPowerShell

$appSettings = @{};
$appSettings.Add('NodeIpAddress', '10.150.12.21'); 
$appSettings.Add('PsUrlWindowsValue', 'https://${IP}:5986/wsman/');

$hostname = "10.150.12.21"
$username = "admin"
$plainTextPassword = "admin"
$password = $plainTextPassword | ConvertTo-SecureString -AsPlainText -Force

$cred = New-Object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
$swis = Connect-Swis -host $hostname -cred $cred

$nodeId = 2
$credentialSetId = -3 #-3 means take it from node

$template = "AppInsight for IIS"
$applicationTemplateId = Get-SwisData $swis "SELECT ApplicationTemplateID FROM Orion.APM.ApplicationTemplate WHERE Name=@template" @{ template = $template }

if (!$applicationTemplateId) {
	Write-Host "Can't find template with name '$template'."
	exit 1
}

Write-Host "Creating application on node '$nodeId' using template '$applicationTemplateId' and credential '$credentialSetId'."

$applicationId = (Invoke-SwisVerb $swis "Orion.APM.Application" "CreateApplication" @(
    $nodeId,
    $applicationTemplateId,
    $credentialSetId,
    "true",
	$appSettings
)).InnerText

# Check if the application was created
if ($applicationId -eq -1) {
	Write-Host "Application wasn't created. Likely the template is already assigned to node and the skipping of duplications are set to 'true'."
	exit 1
}
else {
	Write-Host "Application created with ID '$applicationId'."
}

# Default condition for configuring IIS Server
$shouldConfigureIISServer = $true

# Configure IIS if the condition is true
if ($shouldConfigureIISServer) {
	Write-Host "Scheduling IIS configuration for Application ID '$applicationId'."

$maxRetries = 10
$retryCount = 0
$executionKey = (Invoke-SwisVerb $swis "Orion.APM.IIS.Application" "ScheduleConfiguration" @($applicationId, $credentialSetId)).InnerText

while ($retryCount -lt $maxRetries) {
    Start-Sleep -Seconds 15  # Wait for a few seconds before retrying
	$configResult = (Invoke-SwisVerb $swis "Orion.APM.IIS.Application" "GetConfigurationResult" @($executionKey)).InnerText
	
	Write-Host "Configuration Result: Configuration in progress, please wait..."
	
    if ($configResult -eq "0true") {
        Write-Host "Configuration Result: Configuration finished."
        break
    } else {
        Write-Host "Configuration not yet complete..."
        $retryCount++
    }
  }
  
  if ($configResult -eq "false") {
        Write-Host "Configuration Result: Configuration failed."
        break
    }
}
