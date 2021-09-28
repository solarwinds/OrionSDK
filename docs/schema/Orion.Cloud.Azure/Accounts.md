---
id: Accounts
slug: Accounts
---

# Orion.Cloud.Azure.Accounts

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the Azure Cloud account information.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [Orion.Cloud.Accounts](./../Orion.Cloud/Accounts)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| SubscriptionName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| CortexCloudAccount | [Cortex.Orion.NetMan.CloudMonitoring.CloudAccount](./../Cortex.Orion.NetMan.CloudMonitoring/CloudAccount) | Defined by relationship Cortex.Cortex.Orion.NetMan.CloudMonitoring.CortexToOrionCloudAccount (System.Reference) |
| AzurePollingCounters | [Orion.Cloud.Azure.AzurePollingCounters](./../Orion.Cloud.Azure/AzurePollingCounters) | Defined by relationship Orion.CloudMonitoring.CloudAccountReferencesAzurePollingCounters (System.Reference) |

