Import-Module SwisPowerShell

$hostname = "localhost"
$swis = Connect-Swis -Hostname $hostname -Trusted

# get the first 10 volumes from the Orion.Volumes entity along with its current
# custom property setting by joining to the Orion.VolumesCustomProperties
# entity via the VolumeID field in both
$query = @"
    SELECT TOP 10
        v.VolumeID
        ,v.URI AS VolumeURI
        ,v.Caption AS VolumeName
        ,vcp.Bitlocker_Enabled
    FROM Orion.Volumes v
    JOIN Orion.VolumesCustomProperties vcp ON v.VolumeID = vcp.VolumeID
    ORDER BY v.VolumeID
"@

$volumes = Get-SwisData -SwisConnection $swis -Query $query

# for each volume, determine if the value is already set to true and set
# only if it's isn't already
foreach ($v in $volumes) {
    if ($v.Bitlocker_Enabled -eq "true") {
        continue
    }

    Write-Host "Setting volume [$($v.VolumeName)] property BitLocker_Enabled to true..."
    Set-SwisObject -SwisConnection $swis -Uri ("{0}/CustomProperties" -f $v.VolumeURI) @{ Bitlocker_Enabled = "true" }
}
