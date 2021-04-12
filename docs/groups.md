---
title: Groups
---

Orion Groups allow you to create arbitrary collections of managed entities.
Once created, a group tracks the aggregate status of its members.
A group is itself a managed entity, which means that groups can be nested.

Entities can be added to a group either statically or dynamically.
A static group rule is a reference to a specific entity.
A dynamic group rule is a pattern that is continuously reevaluated to determine which entities match and are therefore considered group members.

Orion Groups can be fully managed through the API.
Within Orion, Groups are a specific type of the more general "container" system (no relationship to Docker containers!), so the API refers to them this way.

## Creating Groups

Groups are created using the `Orion.Container.CreateContainer` verb, which expects 7 arguments:

1. Group name (string)
2. Owner (string). This is not the user the group belongs to (groups do not have an owner in this sense), but rather the system component that manages the group. For our purposes this should always be `Core`.
3. Refresh interval in seconds (int). This is how often the group's status is recalculated. 60 is a reasonable value.
4. Status rollup mode (int). 0 means "Mixed status shows warning", 1 means "Show worst status", and 2 means "Show best status". For more information about these modes, see [the product documentation on that topic](http://www.solarwinds.com/documentation/en/flarehelp/orionplatform/content/core-managing-the-display-of-group-status-sw1691.htm?cshid=OrionCoreAGManagingDisplayGroupStatus).
5. Group description (string)
6. Keep status history (boolean). `true` to store a history of the status values of this group or `false` to not.
7. Group members (array of `MemberDefinitionInfo` objects). Explained below.

`CreateContainer` returns the ID of the new group (an int).

### MemberDefinitionInfo

A `MemberDefinitionInfo` object is a simple object with two string properties: `Name` and `Definition`. `Name` is just a label and can be whatever you want.
`Definition` must take one of two forms: a URI or a filter.

To create a static group member, use the SWIS URI of the entity as the definition.
For example, to put the node with NodeID 42 in a group, use `swis://my-orion-instance/Orion/Orion.Nodes/NodeID=42` as the defintion.
You can find the URI for any object in SWIS by querying to get its `Uri` property.

To create a dynamic group membership rule, specify a filter.
These take the form:

`filter:/`_entity type name_`[`_property_`=`_value_`]`

When value is a string, wrap it in single quotes, just as you would in a SWQL query.
For example, to include all Cisco nodes in a group, use this filter rule:

`filter:/Orion.Nodes[Vendor='Cisco']`

You can use navigation properties in the filter rule.
This is helpful for things like custom properties.
To include all nodes in Austin in a group, use this filter rule:

`filter:/Orion.Nodes[CustomProperties.City='Austin']`

### MemberDefinitionInfo array in JSON

This is pretty simple in JSON.
Here's what the three examples above look like:

```json
[
    {"Name": "Node 42", "Definition": "swis://my-orion-instance/Orion/Orion.Nodes/NodeID=42"},
    {"Name": "Cisco gear", "Definition": "filter:/Orion.Nodes[Vendor='Cisco']"},
    {"Name": "ATX", "Definition": "filter:/Orion.Nodes[CustomProperties.City='Austin']"}
]
```

### MemberDefinitionInfo array in XML

It's a bit more complex in XML.
This is only needed if you are working in PowerShell.

```xml
<ArrayOfMemberDefinitionInfo xmlns='http://schemas.solarwinds.com/2008/Orion'>
    <MemberDefinitionInfo>
        <Name>Node 42</Name>
        <Definition>swis://my-orion-instance/Orion/Orion.Nodes/NodeID=42</Definition>
    </MemberDefinitionInfo>
    <MemberDefinitionInfo>
        <Name>Cisco gear</Name>
        <Definition>filter:/Orion.Nodes[Vendor='Cisco']</Definition>
    </MemberDefinitionInfo>
    <MemberDefinitionInfo>
        <Name>ATX</Name>
        <Definition>filter:/Orion.Nodes[CustomProperties.City='Austin']</Definition>
    </MemberDefinitionInfo>
</ArrayOfMemberDefinitionInfo>
```

### REST request body

Putting it all together, here's a complete request body for creating our group.
POST this to `/SolarWinds/InformationService/v3/Json/Invoke/Orion.Container/CreateContainer`.

```json
[
    "Sample API group",
    "Core",
    60,
    0,
    "Group created by REST API request",
    true,
    [
        {"Name": "Node 42", "Definition": "swis://my-orion-instance/Orion/Orion.Nodes/NodeID=42"},
        {"Name": "Cisco gear", "Definition": "filter:/Orion.Nodes[Vendor='Cisco']"},
        {"Name": "ATX", "Definition": "filter:/Orion.Nodes[CustomProperties.City='Austin']"}
    ]
]
```

### PowerShell sample

For a PowerShell example of this and other group-related API calls, see [Groups.ps1](https://github.com/solarwinds/OrionSDK/blob/master/Samples/PowerShell/Groups.ps1).

## Adding members to an existing group

To add a single member to an existing group, invoke the `Orion.Container.AddDefinition` verb.
It expects two arguments:

1. The container ID (int)
2. A single `MemberDefinitionInfo` object

### REST request body

```json
[
    13,
    {"Name": "Down applications", "Definition": "filter:/Orion.APM.Application[Status=2]"}
]
```

To add multiple members to an existing group in a single operation, invoke the `Orion.Container.AddDefinitions` verb.
It expects two arguments:

1. The container ID (int)
2. An array of `MemberDefinitionInfo` objects

### REST request body

```json
[
    13,
    [
        {"Name": "A subgroup", "Definition": "swis://my-orion-instance/Orion/Orion.Groups/ContainerID=9"},
        {"Name": "Another subgroup", "Definition": "swis://my-orion-instance/Orion/Orion.Groups/ContainerID=10"}
    ]
]
```

## Updating an existing group member

You can replace a group member definition using the `Orion.Container.UpdateDefintion` verb.
It expects two arguments:

1. The DefinitionID of the definition to update. You can find this with a SWQL query like `SELECT DefinitionID FROM Orion.ContainerMemberDefinition WHERE ContainerID=@containerID AND Name=@name`.
2. A `MemberDefintionInfo` object to replace the old one

## Deleting a group member

To remove an existing group member definition from a group, invoke the `Orion.Container.DeleteDefinition` verb.
It expects only one argument: the DefinitionID to remove.

## Updating group properties

To change the properties of the group, invoke the `Orion.Container.UpdateContainer` verb.
It expects 7 arguments:

1. The container ID to modify
2. Group name (string)
3. Owner (string). Always use `Core`. (See above.)
4. Refresh interval in seconds (int)
5. Status rollup mode (int)
6. Group description (string)
7. Keep status history (boolean)

See the section on creating groups for more information about these parameters.

## Deleting groups

To delete a group, invoke the `Orion.Container.DeleteContainer` verb. It expects a single argument: the container ID to delete.
