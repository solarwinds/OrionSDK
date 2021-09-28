---
id: Container
slug: Container
---

# Orion.Container

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| read,invoke | manageNodes |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ContainerID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Owner | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Frequency | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| StatusCalculator | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| RollupType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IsDeleted | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| PollingEnabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| LastChanged | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| UnManageFrom | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| UnManageUntil | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| StatusCalculators | [Orion.StatusCalculators](./../Orion/StatusCalculators) | Defined by relationship Orion.ContainerHostsStatusCalculators (System.Hosting) |
| CustomProperties | [Orion.GroupCustomProperties](./../Orion/GroupCustomProperties) | Defined by relationship Orion.GroupHostsCustomProperties (System.Hosting) |
| Members | [Orion.ContainerMembers](./../Orion/ContainerMembers) | Defined by relationship Orion.ContainerHostsMembers (System.Hosting) |
| ContainerStatus | [Orion.ContainerStatus](./../Orion/ContainerStatus) | Defined by relationship Orion.ContainerHostsStatus (System.Hosting) |
| MemberSnapshots | [Orion.ContainerMemberSnapshots](./../Orion/ContainerMemberSnapshots) | Defined by relationship Orion.ContainerHostsMemberSnapshots (System.Hosting) |

## Verbs

### CreateContainer

#### Access control

everyone

### CreateContainerWithParent

#### Access control

everyone

### UpdateContainer

#### Access control

everyone

### DeleteContainer

#### Access control

everyone

### AddDefinition

#### Access control

everyone

### AddDefinitions

#### Access control

everyone

### UpdateDefinition

#### Access control

everyone

### SetDefinitions

#### Access control

everyone

### DeleteDefinition

#### Access control

everyone

### DeleteDefinitions

#### Access control

everyone

### GetDefinitionFilterQuery

#### Access control

everyone

