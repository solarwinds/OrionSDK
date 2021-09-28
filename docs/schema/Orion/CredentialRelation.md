---
id: CredentialRelation
slug: CredentialRelation
---

# Orion.CredentialRelation

SolarWinds Information Service 2020.2 Schema Documentation Index

Relation to Orion.Credential. Serve for reuse same credentials for different Entity type.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete,invoke | manageNodes |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| CredentialRelationID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| EntityType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EntityID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| EntityUri | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CredentialID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Use | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ConnectionProfile | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Credential | [Orion.Credential](./../Orion/Credential) | Defined by relationship Orion.CredentialRelationCredential (System.Reference) |

