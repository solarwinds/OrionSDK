---
title: Account Management
---

The Orion platform provides an API for most account management tasks through the `Orion.Accounts` SWIS entity type.

Orion supports three categories of accounts:

* "Orion accounts" exist only in the Orion database.
The default "admin" and "guest" accounts that are created by default when you create a new Orion database fall into this category.
The database stores a salted hash of the account's password for authentication.
* "Windows accounts" or "AD accounts" are either local Windows accounts on the Orion server or Active Directory accounts that have been authorized to access Orion.
* "SAML accounts SSO" works by transferring the user’s identity from one place (the identity provider) to another (the service provider).

For "Windows" or "SAML", both individual accounts and group accounts are supported.
If group accounts are used, any user who is a member of that group can access Orion.
Users who are authorized via group membership inherit permissions from the group but have separate individual storage for preferences.

:::note

If it makes sense in your environment, configuring Active Directory or SAML integration for Orion, authorizing an appropriate set of AD/LDAP groups in Orion, and doing account management in AD/LDAP is preferable to directly managing Orion accounts.

:::

For Windows, the process is described in [this article](https://support.solarwinds.com/Success_Center/Network_Performance_Monitor_(NPM)/Network_Performance_Monitor_Getting_Started_Guide/060_User_accounts/030_Use_Active_Directory_credentials_for_users).

For SAML, the process is described in [this article](https://documentation.solarwinds.com/en/Success_Center/orionplatform/Content/core-users-SAML-authentication.htm).

All operations except querying accounts require the `AllowAdmin` user right.

## Querying accounts

To list the accounts or find a particular account, query [`Orion.Accounts`](http://solarwinds.github.io/OrionSDK/schema/Orion.Accounts.html).

## Creating accounts

### Orion accounts

To create a new **Orion account**, invoke the `Orion.Accounts.CreateOrionAccount` verb, which has two parameters:

1. `accountID` - the account ID (username) of the new user
2. `password` - the password for the new user

The account will be created with minimal user rights but no account limitations.
They can see any object but can't change anything.
To add rights for the user, invoke `UpdateAccount` (see below).

### Windows accounts

To authorize an existing Windows or Active Directory account to access Orion, invoke the `Orion.Accounts.CreateWindowsAccount` verb, which has four parameters:

1. `accountType` - this should be `2` if you are adding an individual user account or `3` if you are adding a group account
2. `userOrGroupName` - the name of the user or group account to add. Use the `domain\username` format
3. `adminUser` _(optional)_ - if the Orion services do not have rights to query Active Directory, provide the credentials of an account that does
4. `adminPassword` _(optional)_ - the password for `adminUser`, if needed

As with `CreateOrionAccount`, the resulting account has minimal user rights but no account limitations.
The `accountID` of the new account will be the `userOrGroupName` provided.

### SAML accounts

To authorize an existing SAML user to access Orion, invoke the `Orion.Accounts.CreateSAMLAccount` verb, which has two parameters:

1. `accountType` - this should be `5` if you are adding an individual user account or `6` if you are adding a group account
2. `userOrGroupName` - the name of the user or group account to add.

As with `CreateOrionAccount`, the resulting account has minimal user rights but no account limitations.
The `accountID` of the new account will be the `userOrGroupName` provided.

## Modifying accounts

To adjust user rights, invoke the `Orion.Accounts.UpdateAccount` verb, which has two parameters:

1. `accountID` - identifies the account that should be updated
2. `properties` - a dictionary (JSON object) containing the properties to update

The various `AllowXYZ` properties (plus `CanClearEvents`) that control user rights show up as `"Y"` or `"N"` if you query them like `SELECT AllowNodeManagement FROM Orion.Accounts WHERE AccountID='bob'`, but when setting them using `UpdateAccount`, specify them as a boolean: `true` or `false` in JSON, `$true`/`$false` in PowerShell.

## Deleting accounts

To remove a user account, invoke the `Orion.Accounts.DeleteAccount` verb, which has one parameter:

1. `accountID` - identifies the account to delete

## Changing passwords

To change a user's password, invoke the `Orion.Accounts.ChangePassword` verb, which has two parameters:

1. `accountID` - identifies the account whose password will be changed
2. `password` - the new password for the account
