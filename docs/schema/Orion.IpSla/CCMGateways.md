---
id: CCMGateways
slug: CCMGateways
---

# Orion.IpSla.CCMGateways

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| GatewayID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| CCMMonitoringID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| GatewayIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RegionID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IpAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LastStatusUpdatedUTC | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| LastRegisteredUTC | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| ProductType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IpAddressV4 | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| UnManaged | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| UnManageUntil | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| UnManageFrom | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| CallDetailsAsOrigin | [Orion.IpSla.VoipCallDetails](./../Orion.IpSla/VoipCallDetails) | Defined by relationship Orion.IpSla.VoipCallDetailsReferencesOriginGateway (System.Reference) |
| CallDetailsAsDestination | [Orion.IpSla.VoipCallDetails](./../Orion.IpSla/VoipCallDetails) | Defined by relationship Orion.IpSla.VoipCallDetailsReferencesDestinationGateway (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| CCMMonitoring | [Orion.IpSla.CCMMonitoring](./../Orion.IpSla/CCMMonitoring) | Defined by relationship Orion.Ipsla.CCMMonitoringHostsCCMGateways (System.Hosting) |
| Region | [Orion.IpSla.CCMRegions](./../Orion.IpSla/CCMRegions) | Defined by relationship Orion.Ipsla.CCMGatewaysReferencesCCMRegions (System.Reference) |

