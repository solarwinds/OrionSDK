# This sample script demonstrates the use of verbs provided for manipulating with High Availability pools.
#
# The script progresses in several steps:
# 1. Selecting a pool by name.
# 2. Executing "Manual Failover" on the pool
# 3. Executing "Disable Pool" on the pool
#
# Please update the hostname and credential setup to match your configuration.
# Please note that this scripts can affect your pools!!!

if (-not (Get-PSSnapin | where {$_.Name -eq "SwisSnapin"})) {
    Add-PSSnapin "SwisSnapin"
}

# Connect to SWIS
$hostname = "localhost"
$username = "admin"
$password = New-Object System.Security.SecureString
$cred = New-Object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
$swis = Connect-Swis -host $hostname -cred $cred

# Select Pool by name
$mainPoolName = "Main Pool"
$poolId = Get-SwisData $swis "SELECT PoolId FROM Orion.HA.Pools WHERE DisplayName=@poolName" @{ poolName = $mainPoolName }

if (!$poolId) {
	Write-Warning "Can't find pool with name '$mainPoolName'."
	exit 1
}

# Get active server name
$activeServerName = Get-SwisData $swis "SELECT HostName FROM Orion.HA.PoolMembers WHERE PoolMembers.Engine.EngineId IS NOT NULL AND PoolId=@poolId" @{ poolId = $poolId }
Write-Host "Server '$activeServerName' is an active member in pool '$mainPoolName'."

$confirmation = Read-Host "Do you want to manually failover pool '$mainPoolName' (y = yes, otherwise no)"
if ($confirmation -ne 'y') {
  exit 1
}

# Force Failover in pool
$failOverResult = Invoke-SwisVerb $swis Orion.HA.Pools Switchover $poolId
if ($failOverResult.ErrorCode -eq 0) {
    Write-Host "Force Failover initiated successfuly."
} else {    
    Write-Warning "Force Failover failed with error: $($failOverResult.ErrorMessage.'#text')"
}

# Disable pool
$disableResult = Invoke-SwisVerb $swis Orion.HA.Pools DisablePool $poolId
if ($disableResult.ErrorCode -eq 0) {
    Write-Host "Pool disabled successfuly."
} else {    
    Write-Warning "Pool disable failed."
}
