<#

.EXAMPLE
$swis = Connect-Swis -Hostname localhost -UserName Admin -Password 123
.\ImportListResources.ps1 $swis 1 60

.EXAMPLE
$swis = Connect-Swis -Hostname localhost -UserName Admin -Password 123
.\ImportListResources.ps1 -nodeId 1 -swis $swis -timeBetweenChecks 3

.SYNOPSIS
This is a simple Powershell script to import list resources of given node

.DESCRIPTION
The script itself will start ListResources job, waits until job is done and import results

.LINK
Prerequisity: https://www.powershellgallery.com/packages/SwisPowerShell

#>

[CmdletBinding()]
Param(
    [Parameter(Position=0,mandatory=$true)]
    # Swis connection created via Connect-Swis command
    [Object]$swis,
    [Parameter(Position=1,mandatory=$true)]
    # ID of node to import resources
    [int]$nodeId,
    [Parameter(Position=2,mandatory=$false)]
    # Timeout in seconds for wait for 'ReadyForImport' status
    [int]$timeout = 30,
    [Parameter(Position=3,mandatory=$false)]
    # Time to wait before next status check
    [int]$timeBetweenChecks = 2
)
# It takes a while before job will turn to 'InProgress' status from 'Unknown'
$ensureJobWasCreatedWait = 3

$sw = [diagnostics.stopwatch]::StartNew()

Write-Host ("Creating schedule list resources job...")
do
{
    if ($sw.Elapsed.TotalSeconds -gt $timeout)
    {
        throw ("Timeout elapsed when creating job. This is probably caused by calling this script with same nodeId. Please wait few minutes or extend timeout.")
    }
    $result = Invoke-SwisVerb $swis "orion.nodes" "ScheduleListResources" @($nodeId)
    $jobId = $result.'#text'
    Write-Debug ("Created job with guid: " + $jobId)

    Start-Sleep -Seconds $ensureJobWasCreatedWait
    $status = Invoke-SwisVerb $swis "orion.nodes" "GetScheduledListResourcesStatus" @($jobId, $nodeId)
    Write-Debug ("Job status is: " + $status.'#text')
} while ($status.'#text' -eq "Unknown")

Write-Host ("Waiting until job status will be 'ReadyForImport'...")
while ($status.'#text' -ne "ReadyForImport")
{
    if ($sw.Elapsed.TotalSeconds -gt $timeout)
    {
        throw ("Timeout elapsed when waiting for status 'ReadyForImport'")
    }
    Start-Sleep -Seconds $timeBetweenChecks

    $status = Invoke-SwisVerb $swis "orion.nodes" "GetScheduledListResourcesStatus" @($jobId, $nodeId)
    Write-Debug ("Job status is: " + $status.'#text')
}

Write-Host ("Importing list resources...")
$importResult = Invoke-SwisVerb $swis "orion.nodes" "ImportListResourcesResult" @($jobId, $nodeId)

if (![System.Convert]::ToBoolean($importResult.'#text'))
{
    throw ("Import of ListResources result for NodeId:" + $nodeId + " finished with errors.")
}

Write-Host -ForegroundColor Green ("Script finished successfully")