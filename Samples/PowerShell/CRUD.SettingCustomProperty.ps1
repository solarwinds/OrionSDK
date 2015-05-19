# This sample script demonstrates how to set a custom property of a node
# or an interface using CRUD operations.
#
# Please update the hostname and credential setup to match your configuration, and
# reference to an existing node and interface which custom property you want to set.

# Connect to SWIS
$hostname = "localhost"
$username = "admin"
$password = New-Object System.Security.SecureString
$cred = New-Object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
$swis = Connect-Swis -host $hostname -cred $cred

$nodeId=8 # NodeID of a node which custom properties you want to change
$ifaceId=58 # InterfaceID of an interface on the node

# prepare a custom property value
$customProps = @{
  Comments="Custom comment";
}

# build the node URI
$uri = "swis://localhost/Orion/Orion.Nodes/NodeID=$nodeId/CustomProperties";
# set the custom property
Set-SwisObject $swis -Uri $uri -Properties $customProps
# build the interface URI
$uri = "swis://localhost/Orion/Orion.Nodes/NodeID=$nodeId/Interfaces/InterfaceID="+$ifaceId+"/CustomProperties";
# set the custom property
Set-SwisObject $swis -Uri $uri -Properties $customProps