---
id: VSANs
slug: VSANs
---

# Orion.NPM.VSANs

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MediaType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AdminState | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LoadBalancingType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OperationalState | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| InteroperabilityValue | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PortCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MediaTypeDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AdminStateDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LoadBalancingTypeDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OperationalStateDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Ports | [Orion.NPM.FCPorts](./../Orion.NPM/FCPorts) | Defined by relationship Orion.NPM.VsanReferencesPorts (System.Reference) |
| Traffic | [Orion.NPM.VsanTraffic](./../Orion.NPM/VsanTraffic) | Defined by relationship Orion.NPM.VSANsHostsVsanTraffic (System.Hosting) |
| Errors | [Orion.NPM.VsanErrors](./../Orion.NPM/VsanErrors) | Defined by relationship Orion.NPM.VSANsHostsVsanErrors (System.Hosting) |
| CurrentStats | [Orion.NPM.VsanCurrentStats](./../Orion.NPM/VsanCurrentStats) | Defined by relationship Orion.NPM.VSANsHostsVsanCurrentStats (System.Hosting) |

