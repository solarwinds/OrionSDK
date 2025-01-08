<#

.EXAMPLE
$swis = Connect-Swis -Hostname localhost -UserName Admin -Password 123
.\ImportSelectedListResources_Routing.ps1 $swis 1

.SYNOPSIS
This script will enable Routing table poller on give node

.DESCRIPTION
The script itself will start ListResources job, waits until job is done, update XML-formatted result to enable Routing table poller and import it

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


$XMLBranch = 'DiscoveredRouting'


Write-Host "Starting List Resources job for NodeID: " $NodeID

$JobID = Invoke-SwisVerb $swis Orion.Nodes ScheduleListResources @($NodeID)
do
{
    Start-Sleep -Seconds 5
    $JobStatus = Invoke-SwisVerb $swis Orion.Nodes GetScheduledListResourcesStatus @($JobID.'#text', $NodeID)
    Write-Host "  NodeID: " $NodeID " - JobID:" $JobID.'#text' " - Status:" $JobStatus.'#text'
} while ($JobStatus.'#text' -ne "ReadyForImport")
$JobResults = Invoke-SwisVerb $swis Orion.Nodes GetListResourcesResult @($JobID.'#text', $NodeID)
$XMLBranchElement = ($JobResults.DiscoveryResultExportItem.Children.DiscoveryResultExportItem | Where-Object {$_.TypeName.'#text' -eq $XMLBranch}).Children.DiscoveryResultExportItem
foreach ($leef in $XMLBranchElement)
{
    $leef.IsSelected = 'true'
}
Invoke-SwisVerb $swis Orion.Nodes ImportSelectedListResourcesResult @($JobID.'#text', $NodeID, $JobResults)

Write-Host -ForegroundColor Green ("Script finished successfully.")
