# This sample script demonstrates how to execute a script on a device managed
# by NCM and display the results.
#
# Please update the hostname and credential setup to match your configuration,
# and reference to an existing node.

if (! (Get-PSSnapin | where {$_.Name -eq "SwisSnapin"})) {
    Add-PSSnapin "SwisSnapin"
}

$hostname = "tdanner-vm-08r2"
$username = "admin"
$password = New-Object System.Security.SecureString
$cred = New-Object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
$swis = Connect-Swis -v2 -host $hostname -cred $cred

$ip = '10.199.252.6'
$nodeId = get-swisdata $swis "SELECT NodeID FROM Cirrus.Nodes WHERE AgentIP=@ip" @{ip=$ip}

$script = "show clock"

$nodeIdList = New-Object -TypeName "System.Guid[]" 1
$nodeIdList[0] = $nodeId

Invoke-SwisVerb $swis Cirrus.ConfigArchive Execute @($nodeIdList, $script, $username) | Out-Null

$transferID = "{$nodeId}:${username}:ExecuteScript"

do {
    Start-Sleep -Seconds 1
    $status = Get-SwisData $swis "SELECT T.Status, T.Error FROM Cirrus.TransferQueue T WHERE T.TransferID=@transfer" @{transfer=$transferID}
    Write-Host $status.Status
}
while (($status.Status -ne 'Complete') -and (-not $status.Error))

$output = Get-SwisData $swis "SELECT T.Log FROM Cirrus.TransferQueue T WHERE T.TransferID=@transfer" @{transfer=$transferID}

Write-Host $output

