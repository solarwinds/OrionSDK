---
id: AzureMonitoringCredential
slug: AzureMonitoringCredential
---

# Cortex.Orion.NetMan.CloudMonitoring.AzureMonitoringCredential

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [Cortex.System.ElementInstance](./../Cortex.System/ElementInstance)

↳ [Cortex.Orion.Credential](./../Cortex.Orion/Credential)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,update,delete,invoke | admin |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| TenantId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SubscriptionId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ClientId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ApplicationSecretKey | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RelatedCloudAccount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| CloudAccount | [Cortex.Orion.NetMan.CloudMonitoring.CloudAccount](./../Cortex.Orion.NetMan.CloudMonitoring/CloudAccount) | Defined by relationship Cortex.Orion.NetMan.CloudMonitoring.CloudAccountToAzureMonitoringCredential (System.Hosting) |

