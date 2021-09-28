---
id: Probes
slug: Probes
---

# Orion.DPI.Probes

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,update,delete,invoke | admin |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ProbeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | read: everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AgentID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Mode | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| Enabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Status | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | read: everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Statistics | [Orion.DPI.QoeStatistics](./../Orion.DPI/QoeStatistics) | Defined by relationship Orion.DPI.ProbesToQoeStatistics (System.Reference) |
| Settings | [Orion.DPI.ProbeSettings](./../Orion.DPI/ProbeSettings) | Defined by relationship Orion.DPI.ProbeToSettings (System.Reference) |
| Properties | [Orion.DPI.ProbeProperties](./../Orion.DPI/ProbeProperties) | Defined by relationship Orion.DPI.ProbeToProperties (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ProbeAssignment | [Orion.DPI.ProbeAssignments](./../Orion.DPI/ProbeAssignments) | Defined by relationship Orion.DPI.ProbeAssignmentToProbe (System.Reference) |

## Verbs

### ReloadProbeSettings

#### Access control

everyone

### ReloadAppDefinitions

#### Access control

everyone

### GetProbeCapabilities

#### Access control

everyone

### DeployLocalTrafficProbe

#### Access control

everyone

### DeploySpanPortProbe

#### Access control

everyone

