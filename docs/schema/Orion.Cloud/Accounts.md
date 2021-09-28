---
id: Accounts
slug: Accounts
---

# Orion.Cloud.Accounts

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the Cloud account information.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete,invoke | admin |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| Id | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of cloud account. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of the cloud account. | everyone |
| CredentialId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of shared credential. | everyone |
| AutoMonitoring | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if cloud account is monitored. | everyone |
| DisableMonitorApiRequests | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if polling for this cloud account is disabled. | everyone |
| PollingIntervalInSeconds | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Polling interval in seconds. | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value containing description of the credentials related with this cloud account. | everyone |
| MonitorApiRequestsMadePerMonth | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Approximate amount of free requests made by our polling using given account in current month. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Relative address of Edit Properties page for given account. | everyone |
| ProviderId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Credential | [Orion.Credential](./../Orion/Credential) | Defined by relationship Orion.CloudMonitoring.CloudAccountReferencesCredential (System.Reference) |
| Counters | [Orion.Cloud.AccountCounters](./../Orion.Cloud/AccountCounters) | Defined by relationship Orion.CloudMonitoring.CloudAccountReferencesCounters (System.Reference) |
| CloudInstances | [Orion.Cloud.Instances](./../Orion.Cloud/Instances) | Defined by relationship Orion.Cloud.CloudAccountReferencesInstance (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Provider | [Orion.Cloud.Providers](./../Orion.Cloud/Providers) | Defined by relationship Orion.CloudMonitoring.ProviderAccounts (System.Reference) |

