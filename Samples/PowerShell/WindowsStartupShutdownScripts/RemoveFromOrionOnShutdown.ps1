# This sample script demonstrates how to remove a node from orion and remove agnent information from orion/actually uninstall agent from a node, 
# if the node is monitored by an agent.
#
# Please update the hostname and credential setup to match your configuration, and
# information about the node you would like to add for monitoring.

#Install Nuget and SwisPowerShell modules
#On some environments we encountered an issue with executing below command, in that case try adding this command before: [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12, it will set tls version to 1.2
Find-PackageProvider -Name "Nuget"  -RequiredVersion "2.8.5.208" | Install-PackageProvider -Force

#The below line can be deleted if SwisPowerShell is already installed
Install-Module -Name SwisPowerShell -Force
Import-Module SwisPowerShell -Force

#Decide if you want to only remove information about agent from Orion or also uninstall it from monitored node, this flag is important only when the node is monitored by agent.
$shouldUninstallAgentFromNode = $false

# Connect to SWIS
# Orion Host IP
$hostname = "10.150.16.71"
# Orion username
$username = "admin"
# Orion password
$password = ConvertTo-SecureString -String "123" -AsPlainText -Force
$cred = New-Object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
$swis = Connect-Swis -host $hostname -cred $cred

# Get local IP adress
$ip=(
    Get-NetIPConfiguration |
    Where-Object {
        $_.IPv4DefaultGateway -ne $null -and
        $_.NetAdapter.Status -ne "Disconnected"
    }
).IPv4Address.IPAddress


# query to get Node SWIS URI
# interface
$getNodeUriQuery = "SELECT Uri
FROM Orion.Nodes
WHERE IPAddress = '$ip'"

Write-Host $getNodeUriQuery

$getNodeUriQueryResults = Get-SwisData $swis $getNodeUriQuery

if ($getNodeUriQueryResults.Length -gt 0) {
    #remove node
    Remove-SwisObject $swis $getNodeUriQueryResults
}

# query to get the agent id
$getAgentIdQuery = "SELECT AgentId
FROM Orion.AgentManagement.Agent
WHERE IP = '$ip'"

$getAgentIdQueryResults = Get-SwisData $swis $getAgentIdQuery

#this if checks if orion contains agent information for this node
if ($getAgentIdQueryResults.Length -gt 0) { 
    if($shouldUninstallAgentFromNode) { 
		#Uninstalling the agent from the node
		$uninstallAgent = Invoke-SwisVerb $swis "Orion.AgentManagement.Agent" "Uninstall"  @(
			$getAgentIdQueryResults
		)
	} 
	else {
		#Removing information about an agent from orion without uninstalling it
		$deleteAgent = Invoke-SwisVerb $swis "Orion.AgentManagement.Agent" "Delete"  @(
			$getAgentIdQueryResults
		)
	}		
}
