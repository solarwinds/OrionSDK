# Based on a conversation at the Seattle SWUG about using the API
# to clean up non-up volumes, this has been written/provided.

Import-Module SwisPowerShell

$OrionServer = 'localhost'
$Username = 'admin'
$Password = ''

$swis = Connect-Swis -Hostname $OrionServer -Username $Username -Password $Password

# query to get node name, interface name, and volume URI of each non-up
# volumes
$query = "
    SELECT
        Nodes.Caption AS NodeName
        ,Volumes.Caption AS VolumeName
        ,Volumes.URI
        ,Volumes.Status
    FROM Orion.Nodes AS Nodes
    JOIN Orion.Volumes AS Volumes ON Nodes.NodeID = Volumes.NodeID
    WHERE Volumes.Status != 1
"

$results = Get-SwisData $swis $query

foreach ($result in $results) {
    Write-Host ("Deleting volume [{0}] from node [{1}] with status [{2}]" -f $result.VolumeName, $result.NodeName, $result.Status)

    # un-comment this line to do the actual deletion
    # Remove-SwisObject $swis $results.URI
}
