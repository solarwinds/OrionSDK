---
id: Credential
slug: Credential
---

# Orion.Credential

SolarWinds Information Service 2020.2 Schema Documentation Index

Entity represents Orion Credential objects that are used in discovery and polling processes

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,update,delete,invoke | manageNodes |
| create,read,update,delete,invoke | manageReports |
| create,read,update,delete,invoke | manageAlerts |
| create,read,update,delete,invoke | admin |
| create,read,update,delete,invoke | system |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CredentialType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CredentialOwner | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| CloudAccounts | [Orion.Cloud.Accounts](./../Orion.Cloud/Accounts) | Defined by relationship Orion.CloudMonitoring.CloudAccountReferencesCredential (System.Reference) |
| IncidentIntegration | [Orion.ESI.IncidentService](./../Orion.ESI/IncidentService) | Defined by relationship IncidentServiceToOrionCredential (System.Reference) |
| CredentialRelation | [Orion.CredentialRelation](./../Orion/CredentialRelation) | Defined by relationship Orion.CredentialRelationCredential (System.Reference) |

## Verbs

### CreateSNMPCredentials

Creates SNMP v1 or v2c credentialsRequired. Credentials name.Required. Community stringOptional. Credential owner. Default value = OrionID of the newly created Orion.Credential instance.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### CreateSNMPv3Credentials

Creates SNMP v3 credentialsRequired. Credentials name.Required. Username.Required. Context.Required. Authentication method (None, MD5, SHA1).Required. Authentication password. Value can be empty.Required. Is authentication key password (True, False).Required. Privacy method (None, DES56, AES128, AES192, AES256).Required. Privacy password. Value can be empty.Required. Is privacy key password (True, False).Optional. Credential owner. Default value = OrionID of the newly created Orion.Credential instance.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### CreateUsernamePasswordCredentials

Creates credentials with username and password, these are used for example by WMI polling.Required. Credentials name.Required. Credential usernameRequired. Credential password.Optional. Credential owner. Default value = OrionID of the newly created Orion.Credential instance.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### CreateUsernamePasswordWithContentCredentials

Creates credentials with username, password and content, these are used for example by PaloAlto REST polling.Required. Credentials name.Required. Credential usernameRequired. Credential password.Optional. Credential content.Optional. Credential owner. Default value = OrionID of the newly created Orion.Credential instance.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### UpdateSNMPCredentials

Updates SNMP v1 or v2c credentials.Required. The credential ID.Required. The credentials name.Required. The community string.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### UpdateSNMPv3Credentials

Updates SNMPv3 credentials.Required. The credential ID.Required. The credentials name.Required. The username.Required. The context.Required. Authentication method (None, MD5, SHA1).Required. Authentication password. Value can be empty.Required. Is authentication key password (True, False).Required. Privacy method (None, DES56, AES128, AES192, AES256).Required. Privacy password. Value can be empty.Required. Is privacy key password (True, False).

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### UpdateUsernamePasswordCredentials

Updates credentials with username and password. These are used, for example, by WMI polling.Required. The credential ID.Required. The credentials name.Required. The username.Required. The password.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### UpdateUsernamePasswordWithContentCredentials

Updates credentials with username, password and content. These are used for example by PaloAlto REST polling.Required. The credential ID.Required. The credentials name.Required. The username.Required. The password.Optional. The content.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

