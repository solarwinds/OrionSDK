---
id: Environment
slug: Environment
---

# Orion.Environment

SolarWinds Information Service 2020.2 Schema Documentation Index

ToDo

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| MachineName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OSVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TimeZone | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SqlServer | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SqlDatabase | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SqlLogin | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Verbs

### CanInstall

ToDo

#### Access control

everyone

### AuthorizeWindowsAccountForDatabase

Adds provided user to Orion database with db_owner permissions.User name to be added to Orion DB logins otherwise local machine will be added, if it is in domain

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### GetConnectionString

Returns connection string

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### GetSqlServerIpAddresses

Returns array of IP addresses of current SQL server

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### GetDatabaseAccessCredential

Returns credential used to access Orion database when system is configured to use Windows authentication

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### GetOrionServerCertificate

Returns Orion certificate

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### UninstallAll

Uninstalls all SolarWinds products

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### StartPreStaging

Pre-download all bits required by selected update modeRequired. A flag that indicates the type of update mode. '1' for latest upgrades, '2' for hotfixes, '3' for evaluations only.Optional. Names of evaluation products you want to pre-download.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

