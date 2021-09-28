---
id: DpaServer
slug: DpaServer
---

# Orion.DPA.DpaServer

SolarWinds Information Service 2020.2 Schema Documentation Index

Integrated DPA server

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete,invoke | admin |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DpaServerId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | ID of DPA server | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of DPA server | everyone |
| JSwisAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Address of jSwis endpoint | everyone |
| JSwisObjectUriBase | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Scheme and hostname for URIs of entities from this DPA server | everyone |
| JSwisCredentialId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | ID of credentials (SQL table Credential) to DPA jSwis | everyone |
| OrionHostname | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | IP/Address of Orion, which was used for integration with DPA | everyone |
| OrionHostnameSetByUser | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Flag if OrionHostname was changed by user during the integration | everyone |
| DpaServiceUserAccountId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | ID of account in Orion for DPA | everyone |
| IntegrationStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Integration status | everyone |
| IntegrationStatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Description of integration status | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Status of DPA server | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Description of status | everyone |
| FeaturesCatalogDiff | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | URL to details view of DPA server | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| RemoteSwis | [SWISf.RemoteSWIS](./../SWISf/RemoteSWIS) | Defined by relationship Orion.DpaServerRemoteSwis (System.Reference) |
| ProductInfo | [DPA.ProductInfo](./../DPA/ProductInfo) | Defined by relationship Orion.DpaServerProductInfo (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DatabaseInstance | [Orion.DPA.DatabaseInstance](./../Orion.DPA/DatabaseInstance) | Defined by relationship Orion.DpaServerDatabaseInstance (System.Reference) |

## Verbs

### RefreshSchema

Refresh federation schema of for particular DPA Server

#### Access control

everyone

