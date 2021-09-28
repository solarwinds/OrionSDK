---
id: AccountCounters
slug: AccountCounters
---

# Orion.Cloud.AccountCounters

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the CloudWatch requests statistics for cloud accound in given month.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| Id | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of cloud account which requests are counted. | everyone |
| CloudWatchRequestsMadeThisMonth | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | This property is not used. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| CloudAccounts | [Orion.Cloud.Accounts](./../Orion.Cloud/Accounts) | Defined by relationship Orion.CloudMonitoring.CloudAccountReferencesCounters (System.Reference) |

