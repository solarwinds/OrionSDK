---
id: CCMPhones
slug: CCMPhones
---

# Orion.IpSla.CCMPhones

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| CCMMonitoringID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MACAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Licensed | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| UnManaged | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| UnManageUntil | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| UnManageFrom | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| CallDetailsAsOrigin | [Orion.IpSla.VoipCallDetails](./../Orion.IpSla/VoipCallDetails) | Defined by relationship Orion.IpSla.VoipCallDetailsReferencesOriginPhone (System.Reference) |
| CallDetailsAsDestination | [Orion.IpSla.VoipCallDetails](./../Orion.IpSla/VoipCallDetails) | Defined by relationship Orion.IpSla.VoipCallDetailsReferencesDestinationPhone (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| CCMMonitoring | [Orion.IpSla.CCMMonitoring](./../Orion.IpSla/CCMMonitoring) | Defined by relationship Orion.Ipsla.CCMMonitoringHostsCCMPhones (System.Hosting) |

