---
id: ApplicationPool
slug: ApplicationPool
---

# Orion.APM.IIS.ApplicationPool

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents IIS application pool.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

↳ [Orion.APM.ApplicationItem](./../Orion.APM/ApplicationItem)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the unique name of the application pool. | everyone |
| State | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer representation of application pool state. | everyone |
| AutoStart | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean representation of application auto start setting. | everyone |
| ManagedPipelineMode | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The string value that indicates the managed pipeline mode. | everyone |
| ManagedRuntimeVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that indicates the version of the common language runtime (CLR) that the application pool preloads. | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that indicates application pool entity description. | everyone |
| IdentityType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that designates the account type under which an application pool will run. | everyone |
| UserName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that indicates the account name under which an application pool will run. | everyone |
| MaxProcesses | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The integer value that specifies the maximum number of worker processes in an application pool. | everyone |
| ApplicationsCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that specifies the number of web applications in an application pool. | everyone |
| StartMode | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer representation of application pool start mode. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that specifies the application pool details page URL. | everyone |
| WebUri | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that specifies the application pool details page URL. It is used by Network Atlas. | everyone |
| ErrorCode | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The ErrorCode value, assigning the category of an issue happened during polling the application pool. If pool was successful, value is 0. | everyone |
| ErrorMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The detail message explaining, why the ErrorCode is not OK. This value is empty in case no error happened. | everyone |
| DisplayState | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string representation of application pool state. | everyone |
| DisplayIdentityType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that designates the account type under which an application pool will run. | everyone |
| DisplayStartMode | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string representation of application pool start mode. | everyone |
| TotalWpCPUStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer representation of status for total worker processes CPU usage based on thresholds | everyone |
| TotalWpPMemStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer representation of status for total worker processes physical memory usage based on thresholds | everyone |
| TotalWpWMemStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer representation of status for total worker processes virtual memory usage based on thresholds | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The description of the status of an application pool. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The status of an application pool. | everyone |
| ItemType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The type of application item. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Site | [Orion.APM.IIS.Site](./../Orion.APM.IIS/Site) | Defined by relationship Orion.APM.IIS.SiteReferencesApplicationPool (System.Reference) |
| WorkerProcesses | [Orion.APM.IIS.WorkerProcess](./../Orion.APM.IIS/WorkerProcess) | Defined by relationship Orion.APM.IIS.ApplicationPoolReferencesWorkerProcess (System.Reference) |
| ApplicationPoolStatus | [Orion.APM.IIS.ApplicationPoolStatus](./../Orion.APM.IIS/ApplicationPoolStatus) | Defined by relationship Orion.APM.IIS.ApplicationPoolHostsStatus (System.Hosting) |
| Request | [Orion.SamAppOptics.Service.Requests](./../Orion.SamAppOptics.Service/Requests) | Defined by relationship AppOptics.ApplicationPoolToRequests (System.Hosting) |
| RequestForTransaction | [Orion.SamAppOptics.Service.Transactions.Requests](./../Orion.SamAppOptics.Service.Transactions/Requests) | Defined by relationship AppOptics.ApplicationPoolToTransactionsRequests (System.Hosting) |
| Transactions | [Orion.SamAppOptics.Service.Transactions.ResponseTime](./../Orion.SamAppOptics.Service.Transactions/ResponseTime) | Defined by relationship AppOptics.ApplicationPoolToTransactionsResponseTime (System.Hosting) |
| RequestsPerHttpMethod | [Orion.SamAppOptics.Service.RequestsPerHttpMethod](./../Orion.SamAppOptics.Service/RequestsPerHttpMethod) | Defined by relationship AppOptics.ApplicationPoolToHttpMethods (System.Hosting) |
| RequestsPerHttpStatus | [Orion.SamAppOptics.Service.RequestsPerHttpStatus](./../Orion.SamAppOptics.Service/RequestsPerHttpStatus) | Defined by relationship AppOptics.ApplicationPoolToHttpStatus (System.Hosting) |
| RequestsPerSecondValue | [Orion.SamAppOptics.Service.RequestsPerSecond](./../Orion.SamAppOptics.Service/RequestsPerSecond) | Defined by relationship AppOptics.ApplicationPoolToRequestsPerSecond (System.Hosting) |
| AverageResponseTimeValue | [Orion.SamAppOptics.Service.AverageResponseTime](./../Orion.SamAppOptics.Service/AverageResponseTime) | Defined by relationship AppOptics.ApplicationPoolToAverageResponseTime (System.Hosting) |
| ErrorRateValue | [Orion.SamAppOptics.Service.ErrorRate](./../Orion.SamAppOptics.Service/ErrorRate) | Defined by relationship AppOptics.ApplicationPoolToErrorRate (System.Hosting) |
| ResponseTimeBreakdown | [Orion.SamAppOptics.Service.ResponseTimeBreakdown](./../Orion.SamAppOptics.Service/ResponseTimeBreakdown) | Defined by relationship AppOptics.ApplicationPoolToResponseTimeBreakdown (System.Hosting) |
| TopRequestsPerSecond | [Orion.SamAppOptics.Service.TopRequestsPerSecond](./../Orion.SamAppOptics.Service/TopRequestsPerSecond) | Defined by relationship AppOptics.ApplicationPoolToTopRequestsPerSecond (System.Reference) |
| TopAverageResponseTime | [Orion.SamAppOptics.Service.TopAverageResponseTime](./../Orion.SamAppOptics.Service/TopAverageResponseTime) | Defined by relationship AppOptics.ApplicationPoolToTopAverageResponseTime (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Application | [Orion.APM.IIS.Application](./../Orion.APM.IIS/Application) | Defined by relationship Orion.APM.IIS.ApplicationHostsApplicationPool (System.Hosting) |

## Verbs

### Start

Start IIS application pool.

#### Access control

everyone

### Stop

Stop IIS application pool.

#### Access control

everyone

### Restart

Restart IIS application pool.

#### Access control

everyone

