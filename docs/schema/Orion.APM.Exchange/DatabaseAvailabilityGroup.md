---
id: DatabaseAvailabilityGroup
slug: DatabaseAvailabilityGroup
---

# Orion.APM.Exchange.DatabaseAvailabilityGroup

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the Exchange database availability group information.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of database availability group. | everyone |
| DagIdentity | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The unique string representation of database availability group. | everyone |
| DagGuid | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | The database availability group GUID. | everyone |
| WitnessServer | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of witness server. | everyone |
| WitnessDirectory | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the witness server directory. | everyone |
| AlternativeWitnessServer | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of alternative witness server. | everyone |
| AlternativeWitnessDirectory | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the alternative witness server directory. | everyone |
| WitnessShareInUse | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the witness server share. | everyone |

