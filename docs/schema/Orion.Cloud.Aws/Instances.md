---
id: Instances
slug: Instances
---

# Orion.Cloud.Aws.Instances

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

↳ [Orion.Virtualization.Instance](./../Orion.Virtualization/Instance)

↳ [Orion.Cloud.Instances](./../Orion.Cloud/Instances)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| CloudRegionId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AvailabilityZone | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrionIdPrefix | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IamRole | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Owner | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RamdiskId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| KernelId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RootDeviceType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RootDeviceName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EbsOptimized | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Tenancy | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Architecture | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| InstanceLaunchTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| PlacementGroup | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Virtualization | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AmiLaunchIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Reservation | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SourceDestinationCheck | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| CloudWatchMonitored | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StateTransitionReason | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Provider | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Region | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Volumes | [Orion.Cloud.Aws.Volumes](./../Orion.Cloud.Aws/Volumes) | Defined by relationship Orion.Cloud.Aws.InstanceHostsVolumes (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| CloudRegion | [Orion.Cloud.Aws.Regions](./../Orion.Cloud.Aws/Regions) | Defined by relationship Orion.Cloud.AwsRegionReferencesInstances (System.Reference) |

## Verbs

### ForceStopInstance

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### TerminateInstance

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### TerminateInstanceAndRemoveNode

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

