---
id: ProductInfo
slug: ProductInfo
---

# DPA.ProductInfo

SolarWinds Information Service 2020.2 Schema Documentation Index

Information about DPA, version, SWIP ID, SWIS schema version, http(s) port(s)

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ProductVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Version of DPA | everyone |
| SwisSchemaVersion | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Version of SWIS schema | everyone |
| SwipUserUUID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | ID of SWIP user | everyone |
| HttpPort | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Number of HTTP port, NULL if not enabled | everyone |
| HttpsPort | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Number of HTTPS port, NULL if not enabled | everyone |
| FeatureCatalog | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DpaServer | [Orion.DPA.DpaServer](./../Orion.DPA/DpaServer) | Defined by relationship Orion.DpaServerProductInfo (System.Reference) |

