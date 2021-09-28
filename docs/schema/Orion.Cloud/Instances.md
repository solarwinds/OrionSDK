---
id: Instances
slug: Instances
---

# Orion.Cloud.Instances

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

↳ [Orion.Virtualization.Instance](./../Orion.Virtualization/Instance)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrionIdColumn | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CloudAccountId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| InstanceId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IOPSTotal | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| IOPSRead | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| IOPSWrite | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| DiskReadInBytesPerSecond | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| DiskWriteInBytesPerSecond | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| Type | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StatusLED | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Image | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| State | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LastPoll | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| LastSuccessfulPoll | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| SubnetId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Platform | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| VpcId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| KeyPairName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AutoScalingGroupName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ImageId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PublicDNSName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PrivateDNSName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Provider | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Region | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Statistics | [Orion.Cloud.InstanceStatistics](./../Orion.Cloud/InstanceStatistics) | Defined by relationship Orion.Cloud.InstanceInstanceStatistics (System.Hosting) |
| MetricsStatus | [Orion.Cloud.InstanceStatus](./../Orion.Cloud/InstanceStatus) | Defined by relationship Orion.Cloud.InstanceHostsInstanceStatus (System.Hosting) |
| MetricsStatusMacro | [Orion.Cloud.InstanceStatusMacro](./../Orion.Cloud/InstanceStatusMacro) | Defined by relationship Orion.Cloud.InstanceHostsInstanceStatusMacro (System.Hosting) |
| Thresholds | [Orion.Cloud.InstanceThresholds](./../Orion.Cloud/InstanceThresholds) | Defined by relationship Orion.VIM.CloudInstancesThresholds (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.Cloud.NodesToInstances (System.Reliance) |
| CloudAccount | [Orion.Cloud.Accounts](./../Orion.Cloud/Accounts) | Defined by relationship Orion.Cloud.CloudAccountReferencesInstance (System.Reference) |

## Verbs

### Unmanage

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | allowUnmanage |

### Remanage

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | allowUnmanage |

### PollNow

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### StartInstance

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### StopInstance

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### RebootInstance

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### DeleteInstance

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### DeleteInstanceWithNode

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

