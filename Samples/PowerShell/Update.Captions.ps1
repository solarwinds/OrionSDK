Import-Module SwisPowerShell

$OrionServer = "localhost"
$Username = "admin"
$Password = ""

$swis = Connect-Swis -Hostname $OrionServer -Username $Username -Password $Password

$query = "
    SELECT
        Nodes.Caption
        , Nodes.URI
    FROM Orion.Nodes AS Nodes
"

$nodes = Get-SwisData -SwisConnection $swis -Query $query

foreach ($node in $nodes) {
    # make whatever adjustment you need to make to the caption here
    # for example, I'm replacing ".example.com" with nothing
    $newName = $node.Caption.Replace(".example.com", "")

    # skip over this node if it already has the right name
    if ($node.Caption -ceq $newName) {
        continue
    }

    Write-Output "Renaming node [$($node.Caption)] to [$newName]..."

    # uncomment the line below if you're seeing the output you expect abovee
    # Set-SwisObject -SwisConnection $swis -Uri $node.URI -Properties @{ "Caption" = $newName }
}
