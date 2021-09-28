---
id: Accounts
slug: Accounts
---

# Orion.Cloud.Aws.Accounts

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the Aws Cloud account information.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [Orion.Cloud.Accounts](./../Orion.Cloud/Accounts)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DisableCloudWatch | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if CloudWatch is polled for this cloud account. | everyone |
| CloudWatchRequestsMadeThisMonth | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Approximate amount of CloudWatch requests made by our polling using given account in current month. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Ec2PollingCounters | [Orion.Cloud.Aws.Ec2PollingCounters](./../Orion.Cloud.Aws/Ec2PollingCounters) | Defined by relationship Orion.CloudMonitoring.CloudAccountReferencesEc2PollingCounters (System.Reference) |

