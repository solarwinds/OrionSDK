---
title: SWIS URIs
---

SWIS uses a URI format to identify entities.
Various features in Orion use SWIS URIs to reference entities, including Alerts, Reports, and Groups.

You can find the URI for an entity with a `SELECT` query like this:

```sql
SELECT URI
FROM Orion.Nodes
WHERE IP='8.8.8.8'
```

Result:

|URI|
|:---|
|`swis://abcdef/Orion/Orion.Nodes/NodeID=1`|

Not all SWIS entities have a URI.
SWIS does not define a URI for entity types without at least one key property defined, so you cannot use these entities with CRUD operations.
You can view the key properties for an entity type in the tree pane of SWQL Studio.

## URI Format

```
swis://<system-identifier>/<endpoint>/<entity type>/<key filter>[/<nav property>[/<key filter>][…]]
```

## System Identifier

When you create a new Orion database, the system identifier is set to the FQDN of the server you are installing on and saved in the database.
Even if that server is later renamed or replaced with a different one, this Orion database has been permanently tattooed with the system identifier that was set when it was created.
This is important, because these URIs get saved in various places - Alerts, Reports, Groups, etc.

The system identifier is not used for addressing.
Even if the system identifier no longer matches the FQDN of the primary Orion server, the URIs will not change and will still work.

## Examples

```
swis://abcdef/Orion/Orion.Nodes/NodeID=1
swis://abcdef/Orion/Orion.Nodes/NodeID=1/Interfaces/InterfaceID=2
swis://abcdef/Orion/Orion.Nodes/NodeID=1/CustomProperties
```
