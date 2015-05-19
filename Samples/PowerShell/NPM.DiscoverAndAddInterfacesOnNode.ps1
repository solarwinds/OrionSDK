# This sample script demonstrates the use of two verbs provided for adding
# NPM interfaces:
# o  Orion.NPM.Intefaces.DiscoverInterfacesOnNode
# o  Orion.NPM.Interfaces.AddInterfacesOnNode
#
# Note: These verbs are provided by SWISv3 only.
#
# The script lists all interfaces on a specified node and adds only
# FastEthernet interfaces to monitor.
#
# Please update the hostname and credential setup below to match your
# configuration, as well as the nodeId variable to refer the existing node to use.

# Connect to SWIS
$hostname = "localhost"
$username = "admin"
$password = New-Object System.Security.SecureString
$cred = New-Object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
$swis = Connect-Swis -host $hostname -cred $cred

# The node ID to discovery interfaces on
$nodeId = 1

# Discover interfaces on the node
$discovered = Invoke-SwisVerb $swis Orion.NPM.Interfaces DiscoverInterfacesOnNode $nodeId
if ($discovered.Result -ne "Succeed") {
  Write-Host "Interface discovery failed."
}
else {
  # Filter the resulting list to include only ifType 6 (fast ethernet)
  $discovered.DiscoveredInterfaces.DiscoveredLiteInterface |? {$_.ifType -ne 6} |% { $discovered.DiscoveredInterfaces.RemoveChild($_) | Out-Null }

  # Add the remaining interfaces
  Invoke-SwisVerb $swis Orion.NPM.Interfaces AddInterfacesOnNode @($nodeId, $discovered.DiscoveredInterfaces, "AddDefaultPollers") | Out-Null
}
