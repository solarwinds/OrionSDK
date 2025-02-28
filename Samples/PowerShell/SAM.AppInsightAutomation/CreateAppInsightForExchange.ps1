Import-Module SwisPowerShell

$appSettings = @{};
$appSettings.Add('PsUrlWindows', 'https://${IP}:5986/wsman/');
$appSettings.Add('PsUrlExchange', 'https://${IP}/powershell/');

$hostname = "10.150.12.21"
$username = "admin"
$plainTextPassword = "admin"
$password = $plainTextPassword | ConvertTo-SecureString -AsPlainText -Force

$cred = New-Object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
$swis = Connect-Swis -host $hostname -cred $cred

$nodeId = 5
$credentialSetId = -3 #-3 means take it from node

$template = "AppInsight for Exchange"
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

# Default condition for configuring Exchange Server
$shouldConfigureExchangeServer = $true

# Configure Exchange if the condition is true
if ($shouldConfigureExchangeServer) {
	Write-Host "Scheduling Exchange configuration for Application ID '$applicationId'."

$maxRetries = 5
$retryCount = 0
$executionKey = (Invoke-SwisVerb $swis "Orion.APM.Exchange.Application" "ScheduleConfiguration" @($applicationId, $credentialSetId)).InnerText

while ($retryCount -lt $maxRetries) {
	$configResult = (Invoke-SwisVerb $swis "Orion.APM.Exchange.Application" "GetConfigurationResult" @($executionKey)).InnerText
	
	Write-Host "Configuration Result: Configuration in progress, please wait..."
    Start-Sleep -Seconds 30  # Wait for a few seconds before retrying
	
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
