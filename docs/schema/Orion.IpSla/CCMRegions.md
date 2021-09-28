---
id: CCMRegions
slug: CCMRegions
---

# Orion.IpSla.CCMRegions

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| RegionID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| CCMMonitoringID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RegionIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RegionName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| CallDetailsAsOrigin | [Orion.IpSla.VoipCallDetails](./../Orion.IpSla/VoipCallDetails) | Defined by relationship Orion.IpSla.VoipCallDetailsReferencesOriginRegion (System.Reference) |
| CallDetailsAsDestination | [Orion.IpSla.VoipCallDetails](./../Orion.IpSla/VoipCallDetails) | Defined by relationship Orion.IpSla.VoipCallDetailsReferencesDestinationRegion (System.Reference) |
| CCMGateways | [Orion.IpSla.CCMGateways](./../Orion.IpSla/CCMGateways) | Defined by relationship Orion.Ipsla.CCMGatewaysReferencesCCMRegions (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| CCMMonitoring | [Orion.IpSla.CCMMonitoring](./../Orion.IpSla/CCMMonitoring) | Defined by relationship Orion.Ipsla.CCMMonitoringHostsCCMRegions (System.Hosting) |

