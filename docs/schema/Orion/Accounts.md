---
id: Accounts
slug: Accounts
---

# Orion.Accounts

SolarWinds Information Service 2020.2 Schema Documentation Index

ToDo

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| AccountID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Enabled | [System.Char](https://docs.microsoft.com/en-us/dotnet/api/system.char) |  | everyone |
| AllowNodeManagement | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AllowMapManagement | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AllowAdmin | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CanClearEvents | [System.Char](https://docs.microsoft.com/en-us/dotnet/api/system.char) |  | everyone |
| AllowReportManagement | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AllowAlertManagement | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AllowCustomize | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AllowUnmanage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AllowDisableAction | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AllowDisableAlert | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AllowDisableAllActions | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AlertSound | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MenuName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| HomePageViewID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DefaultNetObjectID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisableSessionTimeout | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ReportFolder | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AlertCategory | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Expires | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| LastLogin | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| LimitationID1 | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LimitationID2 | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LimitationID3 | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AccountSID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AccountType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| GroupInfo | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| GroupPriority | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| AllowViewCopCheck | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| AuditingEvents | [Orion.AuditingEvents](./../Orion/AuditingEvents) | Defined by relationship Orion.AccountHostsAuditingEvents (System.Reference) |
| FavoriteResources | [Orion.Web.FavoriteResource](./../Orion.Web/FavoriteResource) | Defined by relationship Orion.Web.AccountFavoriteResources (System.Reference) |
| WebResourceSettings | [Orion.Web.ResourceUserSetting](./../Orion.Web/ResourceUserSetting) | Defined by relationship Orion.Web.AccountResourceUserSettings (System.Reference) |
| WebViews | [Orion.Web.View](./../Orion.Web/View) | Defined by relationship Orion.Web.AccountUserWebViews (System.Reference) |

## Verbs

### CreateAccount

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### CreateOrionAccount

Creates a new Account with provided Account ID and Password.Required. Unique Account ID.Required. Account password.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### CreateSamlAccount

Adds SAML user account specified by its name into Orion.Required. A flag that indicates the type of account(s) to add. '5' for SAML User, '6' for SAML Group.Required. SAML User or Group name used to map the account. This value has to match the claim in the SAML response to log in as this user.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### CreateWindowsAccount

Adds Windows User accounts into Orion based on the provided account name search string.Required. A flag that indicates the type of Windows account(s) to add. '2' for Windows User, '3' for Windows Group.Required. Windows User or Group name to add. Use Domain\\Username or Domain\\Groupname format. All accounts that match the string provided will be added.Optional. User name of the account that has administrative access to Active Directory or local domain accounts.Optional. Password for the user account granted administrative access to Active Directory or local domain accounts.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### UpdateAccount

Updates properties of the specified Account with provided values.Required. Account ID as defined in Orion.Accounts.Required. A non-empty dictionary of name-value pairs that specify which properties to update.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### DeleteAccount

Deletes specified account.Required. Account ID as defined in Orion.Accounts.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### ChangePassword

Changes password of the specified Account with provided string.Required. Account ID as defined in Orion.Accounts.Required. New account password.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### ResetPassword

Resets password to empty password.Required. Account ID as defined in Orion.Accounts.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### CreateOneTimeLoginToken

Creates a one time login token.Required. Account ID as defined in Orion.Accounts.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### CreateVirtualAccount

Creates virtual user account.Required. Account ID as defined in Orion.Accounts.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

