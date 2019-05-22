# Based on a conversation at the Seattle SWUG about using the API
# to clean up non-up interfaces, this has been written/provided.

Import-Module SwisPowerShell

$OrionServer = 'localhost'
$Username = 'admin'
$Password = ''

$swis = Connect-Swis -Hostname $OrionServer -Username $Username -Password $Password

# query to get node name, interface name, and interface URI of each non-up
# interface
$query = "
    SELECT
        Nodes.Caption AS NodeName
        ,Interfaces.Caption AS InterfaceName
        ,Interfaces.URI
    FROM Orion.Nodes AS Nodes
    JOIN Orion.NPM.Interfaces AS Interfaces ON Nodes.NodeID = Interfaces.NodeID
    WHERE Interfaces.Status != 1
"

$results = Get-SwisData $swis $query

foreach ($result in $results) {
    Write-Host ("Deleting interface [{0}] from node [{1}] with status [{2}]" -f $result.InterfaceName, $result.NodeName)

    # un-comment this line to do the actual deletion
    # Remove-SwisObject $swis $results.URI
}
