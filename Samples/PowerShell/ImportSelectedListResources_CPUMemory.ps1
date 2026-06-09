<#

.EXAMPLE
$swis = Connect-Swis -Hostname localhost -UserName Admin -Password 123
.\ImportSelectedListResources_CPUMemory.ps1 $swis 1

.SYNOPSIS
This script will enable CPU & Memory poller on give node

.DESCRIPTION
The script itself will start ListResources job, waits until job is done, update XML-formatted result to enable CPU & Memory poller and import it

.LINK
Prerequisity: https://www.powershellgallery.com/packages/SwisPowerShell

#>

[CmdletBinding()]
Param(
    [Parameter(Position=0,mandatory=$true)]
    # Swis connection created via Connect-Swis command
    [Object]$swis,
    [Parameter(Position=1,mandatory=$true)]
    # ID of node to enable CPU/Memory poller
    [int]$nodeId
)


$XMLElementPoller = 'CPU & Memory'
$XMLLeefPoller = 'CPU & Memory by SolarWinds'


Write-Host "Starting List Resources job for NodeID: " $NodeID

$JobID = Invoke-SwisVerb $swis Orion.Nodes ScheduleListResources @($NodeID)
do
{
    Start-Sleep -Seconds 5
    $JobStatus = Invoke-SwisVerb $swis Orion.Nodes GetScheduledListResourcesStatus @($JobID.'#text', $NodeID)
    Write-Host "  JobID:" $JobID.'#text' " - Status:" $JobStatus.'#text'
} while ($JobStatus.'#text' -ne "ReadyForImport")

$JobResults = Invoke-SwisVerb $swis Orion.Nodes GetListResourcesResult @($JobID.'#text', $NodeID)
$XMLElementBranch = $JobResults.DiscoveryResultExportItem.Children.DiscoveryResultExportItem | Where-Object {$_.DisplayName.'#text' -eq $XMLElementPoller} 
$XMLElementBranch.IsSelected = 'true'
$XMLElementBranch.DisplayName.'#text' = 'CPU &amp; Memory'
$XMLLeefPollerID = $JobResults.DiscoveryResultExportItem.Children.DiscoveryResultExportItem.Children.DiscoveryResultExportItem.DisplayName | Where-Object '#text' -eq $XMLLeefPoller | Select-Object Id
$XMLLeefPollerID = [int]$XMLLeefPollerID.Id - 1
$XMLLeef = $JobResults.DiscoveryResultExportItem.Children.DiscoveryResultExportItem.Children.DiscoveryResultExportItem | Where-Object Id -EQ $XMLLeefPollerID 
$XMLLeef.IsSelected = 'true'
$XMLLeef.DisplayName.'#text' = 'CPU &amp; Memory by SolarWinds'
Invoke-SwisVerb $swis Orion.Nodes ImportSelectedListResourcesResult @($JobID.'#text', $NodeID, $JobResults)

Write-Host -ForegroundColor Green ("Script finished successfully.")