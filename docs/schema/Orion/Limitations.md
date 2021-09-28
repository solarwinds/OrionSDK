---
id: Limitations
slug: Limitations
---

# Orion.Limitations

SolarWinds Information Service 2020.2 Schema Documentation Index

All defined limitations in Orion.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| LimitationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LimitationTypeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Definition | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| WhereClause | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Verbs

### CreateLimitation

Creates Limitations and optionally assignes them to Accounts.required. LimitationTypeID from Orion.LimitationTypes.required if Limitation is of type "Selection" as defined in Orion.LimitationTypes. A string that will be used to match one value against the Table &amp; Field defined by corresponding Orion.LimitationType.required if Limitation is of type "Checkbox" as defined in Orion.LimitationTypes. An array of strings used to match multiple values against the Table &amp; Field defined by corresponding Orion.LimitationType.required if Limitation is of type "Pattern" as defined in Orion.LimitationTypes. A string that will be used to match multiple values as a text search pattern against the Table &amp; Field defined by corresponding Orion.LimitationType.optional. Account ID as defined in Orion.Accounts. Recommended to always specify this parameter. Advanced usage: omit this parameter to create an un-assigned Limitation, as such it will only be used if explicitly specified using "WITH LIMITATION ID" SWQL expression.ID of the newly created Orion.Limitation instance.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### UpdateLimitation

Updates Limitation to a new definition i.e. new set of items it shoud match.required. Limitation ID from Orion.Limitations.required if Limitation is of type "Selection" as defined in Orion.LimitationTypes. A string that will be used to match one value against the Table &amp; Field defined by corresponding Orion.LimitationType.required if Limitation is of type "Checkbox" as defined in Orion.LimitationTypes. An array of strings used to match multiple values against the Table &amp; Field defined by corresponding Orion.LimitationType.required if Limitation is of type "Pattern" as defined in Orion.LimitationTypes. A string that will be used to match multiple values as a text search pattern against the Table &amp; Field defined by corresponding Orion.LimitationType.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### DeleteLimitation

Deletes Limitation and removes it from an Account it was assigned to previously.required. Limitation ID from Orion.Limitations.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

