# This sample script demonstrates the use of verbs provided for manipulating with High Availability pools.
#
# The script progresses in several steps:
# 1. Creating a main pool.
# 2. Selecting a pool by name.
# 3. Updating a pool configuration.
# 4. Executing "Disable Pool" on the pool
# 5. Executing "Enable Pool" on the pool
# 6. Executing "Manual Failover" on the pool
#
# Please update the hostname and credential setup to match your configuration.
# Please note that this scripts can affect your pools!!!

# Load SwisPowerShell
Import-Module SwisPowerShell

# Connect to SWIS
$hostname = "localhost"
$username = "admin"
$password = ""
$swis = Connect-Swis -host $hostname -UserName $username -Password $password

# Create main pool
$mainPoolName = "Main Pool"

$firstPoolMemberId = Get-SwisData $swis "SELECT PoolMemberId FROM Orion.HA.PoolMembers WHERE PoolMemberType = 'MainPoller'"
$secondPoolMemberId = Get-SwisData $swis "SELECT PoolMemberId FROM Orion.HA.PoolMembers WHERE PoolMemberType = 'MainPollerStandby'"

# setup properties for CreatePool verb
$poolMemebersIds = [int[]]@( $firstPoolMemberId, $secondPoolMemberId )
$properties = @{
    poolConfiguration = @{ preferredMemberId = $firstPoolMemberId; };
    virtualIpResource = @{ ipAddress = "1.1.0.2"; };
    virtualHostNameResource = @{
        hostName = "TestHostName";
        dnsIp = "10.140.100.101";
        dnsType = "Other";
        dnsZone = "fake.com";
    };
}

$operationResult = Invoke-SwisVerb $swis Orion.HA.Pools CreatePool @($mainPoolName, $poolMemebersIds, $properties)
if ($operationResult.Code -eq 0) {
     Write-Host $operationResult.Result.'#text'
} else {
     Write-Warning "Operation failed with error: $($operationResult.Message.'#text')"
}

# Select Pool by name
$poolId = Get-SwisData $swis "SELECT PoolId FROM Orion.HA.Pools WHERE DisplayName=@poolName" @{ poolName = $mainPoolName }

if (!$poolId) {
    Write-Warning "Can't find pool with name '$mainPoolName'."
    exit 1
}

# Edit pool via swis verb
# User may update
#  1. Pool name,
#  2. preferred member setting, virtual IP resource and virtual hostname resource.
#     (If either of these three configurations are removed from $properties corresponding plugin will be removed from pool after update.)
# Pool members cannot be updated (user must perform delete/create sequence to select different members).

$pool = Get-SwisData $swis "SELECT VirtualIpAddress, VirtualHostName, DnsZone FROM Orion.HA.Pools WHERE PoolId=@poolId" @{ poolId = $poolId }
$preferredMemberId = Get-SwisData $swis "SELECT PoolMemberId FROM Orion.HA.PoolMembers WHERE PoolId=@poolId AND Priority = 0" @{ poolId = $poolId }
$properties = @{
    virtualHostNameResource = @{
        hostName = $pool.VirtualHostName;
        dnsIP = "10.140.100.102";       # DNS IP
        dnsType = "Microsoft";          # Modify DNS type
        dnsUserName = "admin@fake.com"; # Credentials must be always provided, cannot be retrieved via SWIS query
        dnsPassword = "adminpsswrd1";
        dnsZone = $pool.DnsZone;
    };
}
if ($pool.VirtualIpAddress) { $properties.Add("virtualIpResource", @{ ipAddress = $pool.VirtualIpAddress; }) } # keep vip setting
if ($preferredMemberId) { $properties.Add("poolConfiguration", @{ preferredMemberId = $preferredMemberId; }) } # keep preferred member setting
 
$operationResult = Invoke-SwisVerb $swis Orion.HA.Pools EditPool @($poolId, $mainPoolName, $properties)
if ($operationResult.Code -eq 0) {
    Write-Host $operationResult.Result.'#text'
} else {
    Write-Warning "Operation failed with error: $($operationResult.Message.'#text')"
}

# Get active server name and its status
$activeServerQuery = @"
SELECT pm.HostName, s.StatusName
FROM Orion.HA.PoolMembers pm
JOIN Orion.StatusInfo s ON s.StatusId = pm.status
WHERE pm.Engine.EngineId IS NOT NULL AND PoolId=@poolId
"@
$activeServer = Get-SwisData $swis $activeServerQuery @{ poolId = $poolId }
Write-Host "Server '$($activeServer.HostName)' (Status = '$($activeServer.statusName)') is an active member in pool '$mainPoolName'."

# Disable pool
$disableResult = Invoke-SwisVerb $swis Orion.HA.Pools DisablePool $poolId
if ($disableResult.Code -eq 0) {
    Write-Host "Pool disabled successfuly."
} else {
    Write-Warning "Pool disable failed."
}

# Enable pool
$enableResult = Invoke-SwisVerb $swis Orion.HA.Pools EnablePool $poolId
if ($enableResult.Code -eq 0) {
    Write-Host "Pool enabled successfuly."
} else {
    Write-Warning "Pool enable failed."
}

# Force Failover in pool
#   Dialog to confirm manual failover
$confirmation = Read-Host "Do you want to manually failover pool '$mainPoolName' (y = yes, otherwise no)"
if ($confirmation -ne 'y') {
    exit 1
}

$failOverResult = Invoke-SwisVerb $swis Orion.HA.Pools Switchover $poolId
if ($failOverResult.Code -eq 0) {
    Write-Host "Force Failover initiated successfuly."
} else {
    Write-Warning "Force Failover failed with error: $($failOverResult.ErrorMessage.'#text')"
}
