---
id: Component
slug: Component
---

# Orion.APM.Component

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents component.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| read,update,delete,invoke | manageNodes |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ComponentID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of component. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of component. | everyone |
| ShortName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the component short name. | everyone |
| ComponentType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the component type. | everyone |
| ComponentEvidenceType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the component evidence type. | everyone |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent application. | everyone |
| TemplateID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of parent application template. | everyone |
| ComponentName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of component. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | URL to component details page. Used in alerting. | everyone |
| FullyQualifiedName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the fully qualified name of parent node. | everyone |
| UserDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the component user description. | everyone |
| UserNotes | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the component user notes. | everyone |
| ComponentOrder | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the component position. | everyone |
| ApplicationItemID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of application item. | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains component description. | everyone |
| UnManaged | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if component is unmanaged. | everyone |
| UnManageFrom | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time from which component is unmanaged. | everyone |
| UnManageUntil | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time until which component is unmanaged. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The status of a component. | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains component status description. | everyone |
| Disabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if component is disabled. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| OutApplicationTcpConnections | [Orion.APM.ApplicationTcpConnection](./../Orion.APM/ApplicationTcpConnection) | Defined by relationship Orion.APM.ApplicationTcpConnectionReferencesClientProcessComponent (System.Reference) |
| InApplicationTcpConnections | [Orion.APM.ApplicationTcpConnection](./../Orion.APM/ApplicationTcpConnection) | Defined by relationship Orion.APM.ApplicationTcpConnectionReferencesServerProcessComponent (System.Reference) |
| InApplicationTcpConnectionsForPort | [Orion.APM.ApplicationTcpConnection](./../Orion.APM/ApplicationTcpConnection) | Defined by relationship Orion.APM.ApplicationTcpConnectionReferencesServerPortComponent (System.Reference) |
| WebUri | [Orion.APM.ComponentWebUri](./../Orion.APM/ComponentWebUri) | Defined by relationship Orion.APM.ComponentHostsWebUri (System.Hosting) |
| CurrentStatus | [Orion.APM.CurrentComponentStatus](./../Orion.APM/CurrentComponentStatus) | Defined by relationship Orion.APM.ComponentHostsCurrentStatus (System.Hosting) |
| CurrentStatistics | [Orion.APM.CurrentStatistics](./../Orion.APM/CurrentStatistics) | Defined by relationship Orion.APM.ComponentCurrentStatistics (System.Hosting) |
| ComponentStatus | [Orion.APM.ComponentStatus](./../Orion.APM/ComponentStatus) | Defined by relationship Orion.APM.ComponentHostsStatus (System.Hosting) |
| PortEvidenceChart | [Orion.APM.PortEvidenceChart](./../Orion.APM/PortEvidenceChart) | Defined by relationship Orion.APM.ComponentHostsPortEvidenceChart (System.Hosting) |
| DynamicEvidenceChart | [Orion.APM.DynamicEvidenceChart](./../Orion.APM/DynamicEvidenceChart) | Defined by relationship Orion.APM.ComponentHostsDynamicEvidenceChart (System.Hosting) |
| ProcessEvidenceChart | [Orion.APM.ProcessEvidenceChart](./../Orion.APM/ProcessEvidenceChart) | Defined by relationship Orion.APM.ComponentHostsProcessEvidenceChart (System.Hosting) |
| WindowsEvent | [Orion.APM.WindowsEvent](./../Orion.APM/WindowsEvent) | Defined by relationship Orion.APM.ComponentHostsWindowsEvent (System.Hosting) |
| ChartEvidence2 | [Orion.APM.ChartEvidence2](./../Orion.APM/ChartEvidence2) | Defined by relationship Orion.APM.ComponentHostsChartEvidence2 (System.Hosting) |
| ResponseTime | [Orion.APM.ResponseTime](./../Orion.APM/ResponseTime) | Defined by relationship Orion.APM.ComponentResponseTime (System.Hosting) |
| HistoricalCPULoad | [Orion.APM.HistoricalCPULoad](./../Orion.APM/HistoricalCPULoad) | Defined by relationship Orion.APM.ComponentHistoricalCPULoadHosting (System.Hosting) |
| HistoricalMemory | [Orion.APM.HistoricalMemory](./../Orion.APM/HistoricalMemory) | Defined by relationship Orion.APM.ComponentHistoricalMemoryHosting (System.Hosting) |
| HistoricalIOOperations | [Orion.APM.HistoricalIOOperations](./../Orion.APM/HistoricalIOOperations) | Defined by relationship Orion.APM.ComponentHostsHistoricalIOOperations (System.Hosting) |
| StatisticsUsage | [Orion.APM.StatisticsUsage](./../Orion.APM/StatisticsUsage) | Defined by relationship Orion.APM.ComponentStatisticsUsageHosting (System.Hosting) |
| ComponentAlert | [Orion.APM.ComponentAlert](./../Orion.APM/ComponentAlert) | Defined by relationship Orion.APM.ComponentAlertReferencesComponent (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Application | [Orion.APM.Application](./../Orion.APM/Application) | Defined by relationship Orion.APM.ApplicationHostsComponent (System.Hosting) |
| ComponentDefinition | [Orion.APM.ComponentDefinition](./../Orion.APM/ComponentDefinition) | Defined by relationship Orion.APM.ComponentDefinitionReferencesComponent (System.Reference) |
| MultipleStatisticData | [Orion.APM.MultipleStatisticData](./../Orion.APM/MultipleStatisticData) | Defined by relationship Orion.APM.MultipleStatisticDataReferencesComponent (System.Reference) |
| ComponentAlertThresholds | [Orion.APM.ComponentAlertThresholds](./../Orion.APM/ComponentAlertThresholds) | Defined by relationship Orion.APM.ComponentAlertThresholdsReferencesComponent (System.Reference) |

## Verbs

### CalculateBaselineThresholds

Calculates and sets baseline thresholds for component thresholdComponent idThreshold name, for dynamic components it can be taken from APM.DynamicEvidenceColumnSchema.Name, for non dynamic component it can be taken from Orion.APM.Threshold.ThresholdName

#### Access control

everyone

