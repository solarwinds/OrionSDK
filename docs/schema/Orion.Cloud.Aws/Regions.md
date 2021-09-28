---
id: Regions
slug: Regions
---

# Orion.Cloud.Aws.Regions

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the AWS region.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| Id | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of AWS region. | everyone |
| SystemName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of AWS region. | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains AWS region display name. | everyone |
| Enabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if AWS region is enabled. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| CloudInstances | [Orion.Cloud.Aws.Instances](./../Orion.Cloud.Aws/Instances) | Defined by relationship Orion.Cloud.AwsRegionReferencesInstances (System.Reference) |

