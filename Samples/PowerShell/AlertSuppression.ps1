Import-Module SwisPowerShell

$OrionServer = 'localhost'
$Username = 'admin'
$Password = ''

$swis = Connect-Swis -Hostname $OrionServer -Username $Username -Password $Password

# List alert suppressions
Get-SwisData $swis "SELECT ID, EntityUri, SuppressFrom, SuppressUntil FROM Orion.AlertSuppression" | Format-Table

# Get Uris for a couple of nodes
$entityUris = Get-SwisData $swis "SELECT TOP 2 Uri FROM Orion.Nodes"
$entityUris = $entityUris |% {[string]$_}

# Test if some entities currently have alerts suppressed
$result = Invoke-SwisVerb $swis Orion.AlertSuppression GetAlertSuppressionState @(,$entityUris)
$result.EntityAlertSuppressionState

# Suppress alerts for one or more entities
$entityUris = Get-SwisData $swis "SELECT TOP 2 Uri FROM Orion.Nodes"
$entityUris = $entityUris |% {[string]$_}

Invoke-SwisVerb $swis Orion.AlertSuppression SuppressAlerts @($entityUris, [DateTime]::UtcNow) | Out-Null

# End alert suppression for one or more entities
Invoke-SwisVerb $swis Orion.AlertSuppression ResumeAlerts @(,$entityUris) | Out-Null
