Import-Module SwisPowerShell

$appSettings = @{};
#$appSettings.Add('InstanceName', ''); #instance name is not required, if not specified than default instance name will be used
$appSettings.Add('PortType', 'static');  #default or static, when static than PortNumber needs to be set
$appSettings.Add('PortNumber', '1433');

$hostname = "10.150.12.21"
$username = "admin"
$plainTextPassword = "admin"
$password = $plainTextPassword | ConvertTo-SecureString -AsPlainText -Force

$cred = New-Object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
$swis = Connect-Swis -host $hostname -cred $cred

$nodeId = 2
$credentialSetId = -3 #-3 means take it from node

$template = "AppInsight for SQL"
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