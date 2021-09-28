---
id: Networks
slug: Networks
---

# Orion.NetPath.Networks

SolarWinds Information Service 2020.2 Schema Documentation Index

Contains BGP information about the nodes and endpoints discovered during probing. This includes the autonomous system the node belongs to, the network address block, and the contact information associated with it.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,update,delete,invoke | manageNodes |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| CidrBlockFrom | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CidrBlockTo | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CidrBlockPrefix | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CidrBlockLength | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OrganizationName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AbusePocs | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OriginAs | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

