---
id: PerformanceOverview
slug: PerformanceOverview
---

# DPA.PerformanceOverview

SolarWinds Information Service 2020.2 Schema Documentation Index

High level overview across monitored databases

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DatabaseId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Reference to Orion.DPA.DatabaseInstance.Id | everyone |
| GlobalDatabaseId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique ID of database instance in Orion | everyone |
| CPUAlarmLevel | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | CPU alarm level integer (See DPA.AlarmLevel entity for more details). | everyone |
| DiskAlarmLevel | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Disk alarm level integer (See DPA.AlarmLevel entity for more details). | everyone |
| MemoryAlarmLevel | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Memory alarm level integer (See DPA.AlarmLevel entity for more details). | everyone |
| OverallAlarmLevel | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Overall alarm level integer (See DPA.AlarmLevel entity for more details). | everyone |
| QueriesAlarmLevel | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Query Advice alarm level integer (See DPA.AlarmLevel entity for more details). | everyone |
| SessionAlarmLevel | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Sessions alarm level integer (See DPA.AlarmLevel entity for more details). | everyone |
| WaitTimeAlarmLevel | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Wait-Time category alarm level integer (Normal(2), Critical(5) or Unknown(3)). This property is calculated from WaitTimeCategory property: -1 equals to Unknown, 0-5 equals to Normal and 6-10 equals to Critical | everyone |
| WaitTimeCategory | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Type of the "Wait" meter. Contains numeric values -1..10, meaning DOWN(-1), IDLE(0), LOW(1), ..., HIGH(5), LOW_ABNORMAL(6), ..., HIGH_ABNORMAL(10).
In DPA UI, values 1-5 are shown as blue meter, abnormal values 6-10 have red meter.
Normal/abnormal is an intra-instance information, indicating whether wait time of this particular instance is higher than usual for this instance, based on historical data.
Values LOW - HIGH (normal as well as abnormal) represent inter-instance comparison, ie. how big/significant is today's wait time of this particular instance when compared to today's wait times of the other monitored instances. | everyone |
| WaitTimeSecs | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Total wait time today in seconds (in DPA, shows when you hover over the "Wait" meter). | everyone |
| WaitTimeEnd | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | This date should represent the last date/time wait time related indicators were calculated for. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DatabaseInstance | [Orion.DPA.DatabaseInstance](./../Orion.DPA/DatabaseInstance) | Defined by relationship Orion.DatabaseInstancePerformanceOverview (System.Reference) |

