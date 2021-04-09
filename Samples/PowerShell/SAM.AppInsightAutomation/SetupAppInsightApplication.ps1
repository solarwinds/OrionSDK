Import-Module SwisPowerShell

#orion machine settings
$hostname = "hostname"
$username = "Admin"
$plainTextPassword = "a"
$password = $plainTextPassword | ConvertTo-SecureString -AsPlainText -Force

$cred = New-Object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
$swis = Connect-Swis -host $hostname -cred $cred

#target node settings
$nodeName = 'nodeName'
$nodeIp = 'nodeIp'
$nodeId = 1
$credentialSetId = 1

$template = "AppInsight for IIS"
$applicationTemplateId = Get-SwisData $swis "SELECT ApplicationTemplateID FROM Orion.APM.ApplicationTemplate WHERE Name=@template" @{ template = $template }

if (!$applicationTemplateId) {
	Write-Host "Can't find template with name '$template'."
	exit 1
}

Invoke-SwisVerb $swis "Orion.APM.Application" "SetupApplication" @(
    $nodeName,
    $nodeIp,
    $credentialSetId,
    $applicationTemplateId,
    $nodeId,
    'true'
)