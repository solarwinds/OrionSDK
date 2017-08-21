param (
    [int]$nodeID,
    [int]$portID,
    [string]$orionhostname="latest-builds",
    [string]$username="admin",
    [string]$password=""
    )

# Load SwisPowerShell
Import-Module SwisPowerShell

$swis = Connect-Swis -v2 -h $orionhostname -u $username -p $password
Invoke-SwisVerb $swis Orion.UDT.Port AdministrativeShutdown @( $nodeID, [int[]]@( $portID ) )
