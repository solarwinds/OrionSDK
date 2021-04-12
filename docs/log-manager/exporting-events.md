---
title: Exporting Log Manager for Orion events
---

Using a SWQL query it is possible to query for Log Manager events and export them to a CSV file.

The following example queries for all events during the last 12 hours:

```powershell
$swis = Connect-Swis -Hostname localhost -UserName admin -Password ""

$endDate = [DateTime]::UtcNow
$startDate = $endDate.AddHours(-12)

$query = @"
SELECT DateTime, 
       Level, 
       logEntry.LogMessageSource.IPAddress,
       logEntry.LogMessageSource.Caption AS NodeName,
       logEntry.LogType.Type AS SourceType,
       Message 
FROM Orion.OLM.LogEntry as logEntry 
WHERE DateTime >= @startDate AND DateTime <= @endDate
"@

Get-SwisData `
    -SwisConnection $swis `
    -Query $query `
    -Parameters @{startDate = $startDate;endDate = $endDate} | 
        Export-Csv -Path "LMExport.csv" -NoTypeInformation
```

It is important to specify at least a date range (in UTC) to limit the amount of data to search.
The SWQL Date/time functions are supported when specifying date values.

To search for a specific type of event, the following additional constraint can be added to the where clause

```powershell
AND logEntry.LogType.Type = @sourceType
```

The value to pass for sourceType can be one of

* Syslog
* Traps
