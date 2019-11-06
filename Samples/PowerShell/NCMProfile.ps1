Import-Module SwisPowerShell

# SolarWinds connection details
$hostname = 'localhost'
$username = 'admin'
$password = ''

$swis = Connect-Swis -Hostname $hostname -Username $username -Password $password

$query = "
    SELECT Uri
    FROM Cirrus.Nodes
    WHERE AgentIP = '192.0.2.0'
"
$uri = Get-SwisData $swis $query

$properties = @{
    ConnectionProfile = 1
}

Set-SwisObject $swis $uri $properties
