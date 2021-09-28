---
id: SqlClusterNode
slug: SqlClusterNode
---

# Orion.APM.SqlClusterNode

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents SQL cluster node.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of application. | everyone |
| NodeName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains SQL server cluster node name. | everyone |
| Current | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if cluster node is active. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| SqlServer | [Orion.APM.SqlServerApplication](./../Orion.APM/SqlServerApplication) | Defined by relationship Orion.APM.SqlServerHostsSqlClusterNodes (System.Hosting) |

