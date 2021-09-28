---
id: InstallPackage
slug: InstallPackage
---

# Orion.AgentManagement.InstallPackage

SolarWinds Information Service 2020.2 Schema Documentation Index

The types of install packages for Linux distributions

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| PackageId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | A unique value describing the install package. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | A string value which is a user friendly description of the package. | everyone |
| OsType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | A string value describing operating system which this package was made for | everyone |
| OsDistro | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | A string value indicating the distribution which this package was made for. | everyone |
| OsVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | A string value indicating the version of operating system for which this package was made for. | everyone |
| OsArchitecture | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | A string value indicating the architecture for which this package was made for. | everyone |
| PackageType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | A string value representing the flavor of the package.  (i.e. RPM or Deb) | everyone |
| PackageManagementTool | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The package management tool used to install this package. | everyone |

