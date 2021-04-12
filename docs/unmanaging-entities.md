---
title: Unmanaging Entities
---

You can tell the  Orion platform to pause monitoring for entities for a period of time.
This can be useful for maintenance windows or other periods of time where you know the device or application will be offline.
During this period no data will be collected for that entity - no up/down status, no response time, etc.
There will be a gap in charts for this time.

If you want to collect data but just mute alerts for an entity, use the [Alert Suppression feature](./alerts#orionalertsuppression) instead.

## Unmanaging Nodes

To unmanage a node, use the `Orion.Nodes.Unmanage` verb.
Its signature looks like this:

```csharp
void Unmanage(string netObjectId, DateTime unmanageFrom, DateTime unmanageUntil, bool isRelative)
```

These parameters have the following meanings:

* `netObjectId` - the identity of the node to unmanage.
It looks like `N:123` where 123 is the NodeID.
* `unmanageFrom` - the date and time (in UTC) to begin the unmanage period.
If this is in the past, the node will be unmanaged effective immediately.
* `unmanageUntil` - the date and time (in UTC) to end the unmanage period.
You can set this as far in the future as you like.
* `isRelative` - if `true`, then the `unmanageUntil` argument will be interpreted differently: the date portion will be ignored and the time portion will be treated as a *duration*.
I recommend passing `false` for `isRelative` - it makes the scripts more clear and consistent.

To call this verb from PowerShell, use a script like this:

```powershell
Import-Module SwisPowerShell
$swis = Connect-Swis # put your connection options here
$nodeId = 42
$start = [DateTime]::UtcNow
$end = $start.AddHours(1)
Invoke-SwisVerb -SwisConnection $swis -EntityName "Orion.Nodes" -Verb "Unmanage" -Arguments @("N:$nodeId", $start, $end, $false)
```

## Remanaging Nodes

To end the unmanage period for a node early (before the scheduled `unmanageUntil` time), you can call the `Orion.Nodes.Remanage` verb.
Its signature looks like this:

```csharp
void Remanage(string netObjectId)
```

To call this verb from PowerShell, use a script like this:

```powershell
Import-Module SwisPowerShell
$swis = Connect-Swis # put your connection options here
$nodeId = 42
Invoke-SwisVerb -SwisConnection $swis -EntityName "Orion.Nodes" -Verb "Remanage" -Arguments @("N:$nodeId")
```
