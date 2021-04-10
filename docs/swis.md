---
title: About the SolarWinds Information Service
---

The SolarWinds Information Service (SWIS) is a data access layer for the Orion product family that provides a hybrid of object-oriented and relational features.
It has its own SQL-like language called SolarWinds Query Language (SWQL).

## Benefits of SWIS

Why get data from SWIS instead of just querying the Orion database directly?

### Credentials

To access the Orion database directly, you need database credentials which a database administrator must create and manage using SQL tools.
By using SWIS to access the database, you effectively bypass the need for database credentials, using the same credentials you use to access the Orion website.
Thus, Orion administrators can manage SWIS access simply by using the Orion Web Console.

### Account Limitations

Orion administrators can associate Orion accounts with limitations that restrict what nodes and interfaces users can access.
SWIS respects these limitations when they provide information.
For example, SWIS will only return nodes the user has permission to see when the user runs a query for nodes.

### Insulation from Database Schema Changes

SWIS ultimately satisfies most queries by fetching data from the database, but the mapping between SWIS entities and the underlying database tables allows SolarWinds to evolve the database schema while providing a consistent, backward-compatible object model to SWIS clients.

### Higher-level Operation

By adding object-oriented features to the relational data model, SWIS allows for tools to operate at a higher level of abstraction.
Tools can query SWIS to find out what data is available and to tell which entities correspond to managed objects (like nodes, interfaces, and applications) and which entities contain statistical information.
SolarWinds uses this capability to build Network Atlas, which allows users to put any kind of managed object on a map, not just specific types.

## Entity Inheritance Hierarchy

SWIS entity types are arranged in an inheritance hierarchy or tree: each entity type has a parent entity type except the root type, `System.Entity`.

Properties declared on parent entity types are inherited by the child entity types. For example, `System.Entity` defines a `DisplayName` property.
Because all other entity types ultimately have `System.Entity` as a parent/ancestor type, all entities have a `DisplayName` property.

If you write a query against a base entity type, data from all entity types that have that base entity type as an ancestor will be returned.
So `SELECT TOP 10 DisplayName FROM System.ManagedEntity ORDER BY DisplayName` would return the first 10 display names (alphabetically) across all managed entity types (nodes, interfaces, applications, groups, etc.).

## Manipulating Data Using the Invoke Interface

The SWIS query interface is read-only and cannot be used to insert, update, or delete data.
SWIS provides an Invoke interface for users to make changes to Orion.
Some entity types define verbs that can be called through this interface.
For example, `Orion.AlertActive` defines an `Acknowledge` verb that users can use to mark alerts as acknowledged.
Because this goes through SWIS, the `Acknowledge` verb can securely validate that the current user has permission to acknowledge alerts and can record the name of the user doing the acknowledging and the corresponding timestamp.

## Manipulating Entities Using the CRUD Interface

SWIS supports an interface for creating, reading, updating, and deleting entities.
These create, read, update, and delete (CRUD) operations comprise a generic interface through which you can access any entity type exposed by SWIS and manipulate the entity in a uniform fashion.

However, there may be entity types that do not support this interface or provide only limited support due to technical or design reasons.
In these cases, the operations may reject requests.

CRUD operations operate on SWIS [[Uris]].
Create returns the Uri of the new entity.
Read, Update, and Delete take one or more Uris as input.
