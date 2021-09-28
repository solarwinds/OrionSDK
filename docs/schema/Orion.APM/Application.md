---
id: Application
slug: Application
---

# Orion.APM.Application

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents all applications.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| read,update,invoke | manageNodes |
| invoke | allowUnmanage |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of application. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of the application. | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a user friendly name of the Application. | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent node. | everyone |
| ApplicationTemplateID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of application template. | everyone |
| UnManaged | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if application is unmanaged. | everyone |
| UnManageFrom | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time from which application is unmanaged. | everyone |
| UnManageUntil | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time until which application is unmanaged. | everyone |
| Created | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time when application was created. | everyone |
| LastModified | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time of the last application modification. | everyone |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of application. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | URL to application details page. Used in alerting. | everyone |
| FullyQualifiedName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the fully qualified name of parent node. | everyone |
| ComponentOrderSettingLevel | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the component order setting level. | everyone |
| CustomApplicationType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the custom application type. | everyone |
| HasCredentials | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if application has credentials. | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains application entity description. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The status of a application. | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains application status description. | everyone |
| Image | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | This property is not used. | everyone |
| Uri | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing SWIS Entity URI path. | everyone |
| PrimaryGroupID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that specifies the Orion group identifier if the application is created by template group assignment functionality. | everyone |
| InstanceType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a concrete type of the Application. | everyone |
| InstanceSiteId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Inherited property that we need to override and mark it as final. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ClientDependencyTcpStatistic | [Orion.APM.DependencyTcpStatistics](./../Orion.APM/DependencyTcpStatistics) | Defined by relationship Orion.APM.DependencyTcpStatisticsReferencesClientApplication (System.Reference) |
| ServerDependencyTcpStatistic | [Orion.APM.DependencyTcpStatistics](./../Orion.APM/DependencyTcpStatistics) | Defined by relationship Orion.APM.DependencyTcpStatisticsReferencesServerApplication (System.Reference) |
| OutApplicationTcpConnections | [Orion.APM.ApplicationTcpConnection](./../Orion.APM/ApplicationTcpConnection) | Defined by relationship Orion.APM.ApplicationTcpConnectionReferencesClientApplication (System.Reference) |
| InApplicationTcpConnections | [Orion.APM.ApplicationTcpConnection](./../Orion.APM/ApplicationTcpConnection) | Defined by relationship Orion.APM.ApplicationTcpConnectionReferencesServerApplication (System.Reference) |
| CustomProperties | [Orion.APM.ApplicationCustomProperties](./../Orion.APM/ApplicationCustomProperties) | Defined by relationship Orion.APM.ApplicationHostsCustomProperties (System.Hosting) |
| WebUri | [Orion.APM.ApplicationWebUri](./../Orion.APM/ApplicationWebUri) | Defined by relationship Orion.APM.ApplicationHostsWebUri (System.Hosting) |
| CurrentStatus | [Orion.APM.CurrentApplicationStatus](./../Orion.APM/CurrentApplicationStatus) | Defined by relationship Orion.APM.ApplicationHostsCurrentStatus (System.Hosting) |
| Components | [Orion.APM.Component](./../Orion.APM/Component) | Defined by relationship Orion.APM.ApplicationHostsComponent (System.Hosting) |
| ApplicationStatus | [Orion.APM.ApplicationStatus](./../Orion.APM/ApplicationStatus) | Defined by relationship Orion.APM.ApplicationHostsStatus (System.Hosting) |
| RelyNode | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.Rely.APM.ApplicationRelyOnNodes (System.Reliance) |
| ApplicationAlert | [Orion.APM.ApplicationAlert](./../Orion.APM/ApplicationAlert) | Defined by relationship Orion.APM.ApplicationAlertReferencesApplication (System.Reference) |
| ScheduledTasks | [Orion.APM.Wstm.Task](./../Orion.APM.Wstm/Task) | Defined by relationship Orion.APM.ApplicationHostsScheduledTasks (System.Hosting) |
| RelyDatabaseInstances | [Orion.DPA.DatabaseInstance](./../Orion.DPA/DatabaseInstance) | Defined by relationship Orion.Rely.DPA.ApplicationsRelyOnDatabaseInstances (System.Reliance) |
| DatabaseInstance | [Orion.DPA.DatabaseInstance](./../Orion.DPA/DatabaseInstance) | Defined by relationship Orion.DatabaseInstanceServerApplication (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.APM.NodeHostsApplication (System.Hosting) |
| Template | [Orion.APM.ApplicationTemplate](./../Orion.APM/ApplicationTemplate) | Defined by relationship Orion.APM.ApplicationTemplateReferencesApplication (System.Reference) |
| DatabaseInstanceReference | [Orion.DPA.DatabaseInstanceApplication](./../Orion.DPA/DatabaseInstanceApplication) | Defined by relationship Orion.DatabaseInstanceApplicationApplication (System.Reference) |
| UsingDatabaseInstanceReference | [Orion.DPA.DatabaseInstanceClientApplication](./../Orion.DPA/DatabaseInstanceClientApplication) | Defined by relationship Orion.DatabaseInstanceClientApplicationApplication (System.Reference) |

## Verbs

### Unmanage

Unmanage existed application.

#### Access control

everyone

### Remanage

Remanage existed application.

#### Access control

everyone

### CreateApplication

Create new application.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### DeleteApplication

Delete existed application.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### PollNow

Poll existed application.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

