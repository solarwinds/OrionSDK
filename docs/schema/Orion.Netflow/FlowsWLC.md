---
id: FlowsWLC
slug: FlowsWLC
---

# Orion.Netflow.FlowsWLC

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| AdvancedApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| ToSID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ObservationTimestamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| IngressBytes | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| EgressBytes | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| IngressPackets | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| EgressPackets | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Bytes | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| TotalBytes | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| TotalPackets | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| ClientIP | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ClientMAC | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SSID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PostDSCPID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| WtpMAC | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.Netflow.NodesReferencesFlowsWLC (System.Reference) |
| AdvancedApplication | [Orion.Netflow.AdvancedApplications](./../Orion.Netflow/AdvancedApplications) | Defined by relationship Orion.Netflow.AdvancedApplicationReferencesFlowsWLC (System.Reference) |
| ToS | [Orion.Netflow.TypesOfService](./../Orion.Netflow/TypesOfService) | Defined by relationship Orion.Netflow.TypesOfServiceReferencesFlowsWLC (System.Reference) |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.Netflow.NodesReferencesFlowsWLC (System.Reference) |
| AdvancedApplication | [Orion.Netflow.AdvancedApplications](./../Orion.Netflow/AdvancedApplications) | Defined by relationship Orion.Netflow.AdvancedApplicationReferencesFlowsWLC (System.Reference) |
| ToS | [Orion.Netflow.TypesOfService](./../Orion.Netflow/TypesOfService) | Defined by relationship Orion.Netflow.TypesOfServiceReferencesFlowsWLC (System.Reference) |

