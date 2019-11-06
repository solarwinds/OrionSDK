Import-Module SwisPowerShell

# SolarWinds connection details
$hostname = 'localhost'
$username = 'admin'
$password = ''

$swis = Connect-Swis -Hostname $hostname -Username $username -Password $password

# get the node uri
$query = "
    SELECT Uri
    FROM Orion.Nodes
    WHERE IPAddress = '192.0.2.0'
"
$uri = Get-SwisData $swis $query

# SNMPv3 Properties
$properties = @{
    SNMPVersion      = '3' ;
    SNMPV3Context    = '';
    SNMPV3Username   = '';
    SNMPV3PrivMethod = ''; # None, DES56, AES128, AES192, AES256
    SNMPV3PrivKey    = ''
    SNMPV3AuthMethod = '' #None, MD5, SHA1
    SNMPV3AuthKey    = ''
}

# change SNMP version
Set-SwisObject $swis $uri $properties
