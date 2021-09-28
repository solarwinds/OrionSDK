---
id: ResourceData
slug: ResourceData
---

# DPA.ResourceData

SolarWinds Information Service 2020.2 Schema Documentation Index

Provides data-points of DB resources. It has single parameter that is required (DatabaseId) and two more that specifies what data will be returned for a given query. If one specifies both ResourceName and CategoryName in a WHERE clause than result set will contain single-resource data-points for specified time-frame (or default time-frame if Time property was not limited in WHERE clause). If at least one of these two parameters is missing than the result set will contain multiple-metric data-points limited by one data-point per metric (i.e. result set will contain a set of last data-point collected for each metric, if such data-point exists in last 60 minutes)

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
| DatabaseId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Specifies for which DB instance should resource data-points be fetched. Reference to Orion.DPA.DatabaseInstance.Id | everyone |
| GlobalDatabaseId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique ID of database instance in Orion | everyone |
| ResourceName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Specifies a name of a resource (e.g. Active Sessions, Memory Utilization, Signal Waits Percent) that must be equal to one of the records from DPA.ResourceDefinition.Name | everyone |
| CategoryName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Specifies a name of a category a resource belongs (e.g. CPU, Memory, Sessions) that must be equal to one of the records from DPA.ResourceDefinition.CategoryName | everyone |
| Time | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Specifies a time of a data-point | everyone |
| Value | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Specifies a double-precision value of this data-point in given time | everyone |
| TimeUnit | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Specifies a time-frame for which data-points should be fetched. If both Time &amp;gt; ABC and Time &amp;lt; XYZ are specified in WHERE clause this property will be ignored. It can take one of the following values: hour (3), day (4), week (5), month (6), six moths (61) or year (7). If Time is limited only by one side (&amp;lt; or &amp;gt;) than a time-frame will be specified as Time-TimeUnit to Time respectively Time to Time+TimeUnit | everyone |
| TimesliceUnit | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Force granularity of records within Time interval (by default there is auto detection based on the Time interval), supported values: as collected ('-1'), ten minutes (22), hour (3), day (4) | everyone |

