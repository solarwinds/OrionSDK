# This sample script demonstrates the use of verbs provided for manipulating
# applications and templates. The verbs are defined by "Orion.APM.Application"
# and "Orion.APM.ApplicationTemplate" entity types.
#
# The script progresses in several steps:
# 1. Creating a new application by assigning a template to a node.
# 2. Executing "Poll Now" on an application
# 3. Unmanage an application
# 4. Remanage an application
# 5. Deleting an application
# 6. Deleting an application template (commented out from the script execution)
#
# Please update the hostname and credential setup to match your configuration.

# Load SwisPowerShell
Import-Module SwisPowerShell

# Connect to SWIS
$hostname = "localhost"
$username = "admin"
$password = New-Object System.Security.SecureString
$cred = New-Object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
$swis = Connect-Swis -host $hostname -cred $cred

#
# ASSIGNING TEMPLATE TO A NODE
#
# Select the node, application template, and credential set, and create the application by the assigning template to node
# with the selected credential set.
#

# Select the node
$ip = "10.140.127.221"
$nodeId = Get-SwisData $swis "SELECT NodeID FROM Orion.Nodes WHERE IP_Address=@ip" @{ ip = $ip }

if (!$nodeId) {
	Write-Host "Can't find node with IP '$ip'."
	exit 1
}

# Select the template
$template = "Apache"
$applicationTemplateId = Get-SwisData $swis "SELECT ApplicationTemplateID FROM Orion.APM.ApplicationTemplate WHERE Name=@template" @{ template = $template }

if (!$applicationTemplateId) {
	Write-Host "Can't find template with name '$template'."
	exit 1
}

# Select the credential
$credential = "MyCredential"
$credentialSetId = Get-SwisData $swis "SELECT ID FROM Orion.Credential WHERE CredentialOwner='APM' AND Name=@credential" @{ credential = $credential }

if (!$credentialSetId) {
	Write-Host "Can't find credential with name '$credential'."
	exit 1
}

# Credentials from the SAM credential library are expected to have credentialSetId > 0.
# But the "CreateApplication" method accepts the following special IDs for credentials:
#
# <None>
#    $credentialSetId = 0 
#
# <Inherit Windows credential from node> (should be used only for WMI nodes)
#    $credentialSetId = -3
#
# <Inherit credentials from template>
#    $credentialSetId = -4

Write-Host "Creating application on node '$nodeId' using template '$applicationTemplateId' and credential '$credentialSetId'."

# Assign the application template to a node to create the application
$applicationId = (Invoke-SwisVerb $swis "Orion.APM.Application" "CreateApplication" @(
    # Node ID
    $nodeId,
    
	# Application Template ID
    $applicationTemplateId,
    
	# Credential Set ID
    $credentialSetId,
	
	# Skip if duplicate (in lowercase)
    "false"
)).InnerText

# Check if the application was created
if ($applicationId -eq -1) {
	Write-Host "Application wasn't created. Likely the template is already assigned to node and the skipping of duplications are set to 'true'."
	exit 1
}
else {
	Write-Host "Application created with ID '$applicationId'."
}

#
# EXECUTING "POLL NOW"
#
# Execute "Poll Now" on created application.
#
Write-Host "Executing Poll Now for application '$applicationId'."
Invoke-SwisVerb $swis "Orion.APM.Application" "PollNow" @($applicationId) | Out-Null
Write-Host "Poll Now for application '$applicationId' was executed."

#
# UNMANAGING APPLICATION
#
# Unmanaging created application.
#
Write-Host "Unmanaging application '$applicationId'."

$applicationNetObjectId = "AA:$applicationId"
$unmanageTime = Get-Date
$remanageTimeRelative = Get-Date -Date "1970-01-01 00:04:00"

Invoke-SwisVerb $swis "Orion.APM.Application" "Unmanage" @(
    # NetObjectID - for application has format "AA:<ApplicationID>"
	$applicationNetObjectId,
	
	# Unmanage time
	$unmanageTime,
	
	# Remanage time
	$remanageTimeRelative,
	
	# If the remanage time is relative (in lowercase). If "true" then the time of the day (hours, minutes and second)
	# is used for the calculation of remanage time.
	"true"
) | Out-Null

Write-Host "Application '$applicationId' is unmanaged."

#
# REMANAGING APPLICATION
#
# Remanaging created application.
#
Write-Host "Remanaging application '$applicationId'."
Invoke-SwisVerb $swis "Orion.APM.Application" "Remanage" @($applicationNetObjectId) | Out-Null
Write-Host "Application '$applicationId' is remanaged."

#
# DELETING APPLICATION
#
# Delete the created application.
#
Write-Host "Deleting application '$applicationId'."
Invoke-SwisVerb $swis "Orion.APM.Application" "DeleteApplication" @($applicationId) | Out-Null
Write-Host "Application '$applicationId' was deleted."

#
# DELETING APPLICATION TEMPLATE
#
# Delete the application template. Removing the template also removes all applications created from this template.
#
# Change the application template ID here
#$applicationTemplateId = 0
#Invoke-SwisVerb $swis "Orion.APM.ApplicationTemplate" "DeleteTemplate" @($applicationTemplateId) | Out-Null
#Write-Host "Application template '$applicationTemplateId' was deleted."
