Import-Module SwisPowerShell

$OrionServer = 'localhost'
$Username = 'admin'
$Password = ''

$swis = Connect-Swis -Hostname $OrionServer -Username $Username -Password $Password

$query = "
    SELECT TOP 5
        Nodes.NodeID
    FROM Orion.Nodes AS Nodes
"

$nodeids = Get-SwisData -SwisConnection $swis -Query $query

# details about the reason for the arguments format can be found here:
# https://github.com/solarwinds/OrionSDK/wiki/Alerts#verb-resumealerts
Invoke-SwisVerb -SwisConnection $swis -Entity 'Orion.ADM.NodeInventory' -Verb 'Enable' -Arguments @( , [int[]] $nodeids ) | Out-Null
