---
title: NPM Universal Device Pollers
---

SolarWinds Network Performance Monitor (NPM) has a feature called Universal Device Pollers (UnDP) for polling arbitrary SNMP values, counters, and tables from network devices and anything else that supports SNMP.
These are also called "custom pollers".

There are two main pieces to managing custom pollers: defining the custom poller, which includes selecting the SNMP OID and making some choices about how it will be queried, processed, and displayed; and assigning the custom poller to the nodes you want that data collected from.

## Creating custom pollers

Defining the custom poller is handled through the "Universal Device Poller" Windows application, which you run on the Orion server.
This is best handled interactively, but you can use that application to export these definitions to a file and import them to another Orion server or just keep them around as a backup.

## Assigning custom pollers to nodes

In NPM 11.5 and later, you can manage custom poller assignments programmatically using the `Orion.NPM.CustomPollerAssignmentOnNode` entity.
To assign a custom poller to a node, you need the custom poller's ID (a GUID) and the NodeID (an int).

If you have the custom poller's name (like `ciscoEnvMonFanState`) you can get the `CustomPollerID` with a query like this:

```sql
SELECT CustomPollerID
FROM Orion.NPM.CustomPollers
WHERE UniqueName='ciscoEnvMonFanState'
```

Once you have the NodeID and CustomPollerID values, use them to create an instance of `Orion.NPM.CustomPollerAssignmentOnNode`.
In PowerShell, that looks like this:

```powershell
$swis = Connect-Swis -Hostname localhost -Username admin -Password ""
$nodeId = 14
$customPollerId = 'cb0010a2-76c3-4230-b858-9448ad579758'
New-SwisObject $swis Orion.NPM.CustomPollerAssignmentOnNode @{NodeID=$nodeId;CustomPollerID=$customPollerId}
```

In [[REST]], that looks like this:

```bash
POST https://localhost:17778/SolarWinds/InformationService/v3/Json/Create/Orion.NPM.CustomPollerAssignmentOnNode
```

```json
{
    "NodeID":14,
    "CustomPollerID": "cb0010a2-76c3-4230-b858-9448ad579758"
}
```

## Removing custom poller assignments

To remove a custom poller assignment, find the Uri for that assignment and tell SWIS to delete it.
You can find the Uri for an assignment with a query like this:

```sql
SELECT Uri
FROM Orion.NPM.CustomPollerAssignmentOnNode
WHERE NodeID=14 AND CustomPollerID='cb0010a2-76c3-4230-b858-9448ad579758'
```
