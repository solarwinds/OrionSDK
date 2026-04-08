---
layout: default
title: "Credential Management"
---

# Credential Management

Various Orion processes ([discovery](../discovery/), polling) work with credentials that are stored in Orion. This page describes how to manage credentials using Orion SDK. 

## Verbs

The Orion.Credential entity provides following verbs to create Orion credentials. Parameters are listed in C# syntax.

### Create SNMP v1 and v2c credentials

```csharp
public long CreateSNMPCredentials(
	string name, 
	string community,
	string owner = "Orion")
```
Parameters:
* `name` - credentials name, required
* `community` - community string, required
* `owner` - credential owner, optional

Verb returns ID of the newly created Orion.Credential instance. Credential name must be unique for given credential type, exception is thrown otherwise.

_Supported since: Orion Platform 2017.3 (NPM 12.2)_

Example:
```powershell
# create SNMP credentials with name=custom, community=RO_permanent
# credentialId can be used in discovery plugin configuration
$credentialId = Invoke-SwisVerb $swis Orion.Credential CreateSNMPCredentials @( "custom",  "RO_permanent" )
```

### Update SNMP v1 and v2c credentials

```csharp
void UpdateSNMPCredentials(int credentialId,
            string name,
            string community)
```
Parameters:
* `credentialId` - ID of the credential to update (must be an SNMP v1/v2c credential)
* `name` - name to set for the credential (must not be empty)
* `community` - community string to set for the credential

_Supported since Orion Platform 2018.4 (NPM 12.4)_


### Create SNMP v3 credentials

```csharp
public long CreateSNMPv3Credentials(
	string name, 
	string username,
	string context, 
	string authenticationMethod, string authenticationPassword, bool isAuthenticationPasswordKey, 
	string privacyMethod, string privacyPassword, bool isPrivacyPasswordKey,
	string owner = "Orion")
```

Parameters:
* `name` - credentials name, required
* `username` - username, required
* `context` - context, required
* `authenticationMethod` - authentication method (None, MD5, SHA1), required
* `authenticationPassword` - authentication password, value can be empty for authentication method None, required
* `authenticationKeyIsPassword` - is authentication key password (True, False), required
* `privacyMethod` - privacy method (None, DES56, AES128, AES192, AES256), required
* `privacyPassword` - privacy password, value can be empty for privacy method None, required
* `privacyKeyIsPassword` - is privacy key password (True, False), required
* `owner` - credential owner, default value = Orion, optional

Verb returns ID of the newly created Orion.Credential instance. Credential name must be unique for given credential type, exception is thrown otherwise.

_Supported since: Orion Platform 2017.3 (NPM 12.2)_


### Update SNMP v3 credentials

```csharp
void UpdateSNMPv3Credentials(
	int credentialId,
	string name,
	string username,
	string context,
	string authenticationMethodValue,
	string authenticationPassword,
	bool authenticationKeyIsPassword,
	string privacyMethodValue,
	string privacyPassword,
	bool privacyKeyIsPassword)
```
Parameters:
* `credentialId` - ID of the credential to update (must be an SNMP v1/v2c credential)
* `name` - name to set for the credential (must not be empty)
* `username` - username, required
* `context` - context, required
* `authenticationMethodValue` - authentication method (None, MD5, SHA1), required
* `authenticationPassword` - authentication password, value can be empty for authentication method None, required
* `authenticationKeyIsPassword` - is authentication key password (True, False), required
* `privacyMethodValue` - privacy method (None, DES56, AES128, AES192, AES256), required
* `privacyPassword` - privacy password, value can be empty for privacy method None, required
* `privacyKeyIsPassword` - is privacy key password (True, False), required

_Supported since Orion Platform 2018.4 (NPM 12.4)_


### Create UserPassword (WMI) credentials

These credentials are applicable for WMI discovery configuration. 

```csharp
public long CreateUsernamePasswordCredentials(
	string name, 
	string username, 
	string password,
	string owner = "Orion")
```

Parameters:
* `name` - credentials name, required
* `username` - username, required
* `password` - password, required
* `owner` - credential owner, default value = Orion, optional

Verb returns ID of the newly created Orion.Credential instance. Credential name must be unique for given credential type, exception is thrown otherwise.

Example:
```powershell
# create WHMI credentials guest/guest with name=custom
# credentialId can be used in discovery plugin configuration
$credentialId = Invoke-SwisVerb $swis Orion.Credential CreateUsernamePasswordCredentials @( "custom",  "guest", "guest" )
```


### Update UserPassword (WMI) credentials

```csharp
void UpdateUsernamePasswordCredentials(
	int credentialId,
	string name,
	string username,
	string password)
```
Parameters:
* `credentialId` - ID of the credential to update (must be an SNMP v1/v2c credential)
* `name` - name to set for the credential (must not be empty)
* `username` - username to set for the credential
* `password` - password to set for the credential

_Supported since Orion Platform 2018.4 (NPM 12.4)_

## Shared Credentials Verbs

Shared credentials verbs allow managing credentials of different types. The SolarWinds Platform 2022.4 introduced two verbs for managing shared credentials: `CreateCredentials` and `UpdateCredentials`; these verbs support most common credential types. 

See the table below for the full list of supported credential types.

### Verb: CreateCredentials

```csharp
Orion.Credential CreateCredentials (string type, Dictionary<string, string> properties, string owner)
```
Use this verb to create a credential set of a given type. Requires the following parameters:
* `type` - corresponds to the `CredentialType` property of Orion.Credential entity; see the table below for all available formats
* `Properties` - configuration of the credential set listed in the form of a dictionary; see the table below for all example configurations
* `Owner` - same as `CredentialOwner` property of Orion.Credential entity; see the table below for all available values.

To prevent potential issues, the verb does not allow you to create duplicates. The following arguments determine that the credential set is unique: `Name`, which is read from the `Properties` parameter, & `Type` & `Owner`.

Note: The Type and Owner properties of the credential set cannot be changed afterward.

_Supported since: SolarWinds Platform 2022.4_

### Verb: UpdateCredentials

```csharp
Orion.Credential UpdateCredentials (int id, Dictionary<string, string> properties)
```
Use this verb to update an already existing credential set of a given type. Requires the following arguments:
* `ID` - corresponds to the `ID` property of Orion.Credential entity; an ID of an existing credential set to be updated
* `Properties` - configuration of the credential set listed in the form of a dictionary; see the table below for all example configurations.

_Supported since: SolarWinds Platform 2022.4_

### Supported credential types and example properties

The following table lists all supported credential types, their default owners, and example properties (in the format applicable for invoking the verbs in SWQL Studio).

Note: The first two keys `<Key>Name</Key>` and `<Key>Description</Key>` are properties of the credentials set itself and are not part of the credentials data (e.g. username, password).
<html>
<body>
<!--StartFragment-->

Credential Type `Type` | Description | Default Owner `Owner` | Configuration Example (SWQL Studio) `Properties` | Supported in
-- | -- | -- | -- | --
SolarWinds.Orion.Core.SharedCredentials.Credentials.UsernamePasswordCredential | Username & Password combo; used throughout the product (e.g. discovery, alerting\reporting actions etc.). | Orion | <details><summary>Properties</summary><code>\<ArrayOfKeyValueOfstringstring xmlns:i="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.microsoft.com/2003/10/Serialization/Arrays" \>\<KeyValueOfstringstring\>\<Key\>Name\</Key\>\<Value\>UserPass_credset\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>Description\</Key\>\<Value\>UserPass_description\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>Username\</Key\>\<Value\>UserPass_username\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>Password\</Key\>\<Value\>UserPass_username\</Value\>\</KeyValueOfstringstring\>\</ArrayOfKeyValueOfstringstring\></code></details> | 2022.4. and later
SolarWinds.APM.Common.Credentials.ApmUsernamePasswordCredential | SAM module’s version of the UsernamePasswordCredentials; used in SAM specific features (e.g. applications discovery). | APM | <details><summary>Properties</summary><code>\<ArrayOfKeyValueOfstringstring xmlns:i="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.microsoft.com/2003/10/Serialization/Arrays" \>\<KeyValueOfstringstring\>\<Key\>Name\</Key\>\<Value\>SAMUserPass_credset\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>Description\</Key\>\<Value\>SAMUserPass_desc\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>Username\</Key\>\<Value\>UserPass_username\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>Password\</Key\>\<Value\>UserPass_password\</Value\>\</KeyValueOfstringstring\>\</ArrayOfKeyValueOfstringstring\></code></details> | 2022.4. and later
SolarWinds.Orion.Core.SharedCredentials.Credentials.ApiKeyCredential | Used in “Send GET\POST Request” Alerting action for the Token Authentication option. | Orion | <details><summary>Properties</summary><code>\<ArrayOfKeyValueOfstringstring xmlns:i="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.microsoft.com/2003/10/Serialization/Arrays" \>\<KeyValueOfstringstring\>\<Key\>Name\</Key\>\<Value\>APIKey_credset\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>Description\</Key\>\<Value\>APIKey_desc\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>ApiKeyName\</Key\>\<Value\>APIKey_tokenname\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>ApiKey\</Key\>\<Value\>APIKey_tokenvalue\</Value\>\</KeyValueOfstringstring\>\</ArrayOfKeyValueOfstringstring\></code></details> | 2022.4. and later
SolarWinds.Orion.Core.SharedCredentials.Credentials.SmtpServerCredential | Basic authentication credentials for an SMTP Server (used by alert\reporting actions). | Orion | <details><summary>Properties</summary><code>\<ArrayOfKeyValueOfstringstring xmlns:i="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.microsoft.com/2003/10/Serialization/Arrays" \>\<KeyValueOfstringstring\>\<Key\>Name\</Key\>\<Value\>SMTP_credset\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>Description\</Key\>\<Value\>SMTP_desc\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>Username\</Key\>\<Value\>SMTP_username\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>Password\</Key\>\<Value\>SMTP_password\</Value\>\</KeyValueOfstringstring\>\</ArrayOfKeyValueOfstringstring\></code></details> | 2022.4. and later
SolarWinds.Orion.Core.Models.Credentials.SnmpCredentialsV3 | Node SNMPv3 credentials | Orion | <details><summary>Properties</summary><code>\<ArrayOfKeyValueOfstringstring xmlns:i="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.microsoft.com/2003/10/Serialization/Arrays" \>\<KeyValueOfstringstring\>\<Key\>Name\</Key\>\<Value\>SNMPv3_credset\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>Description\</Key\>\<Value\>SNMPv3_desc\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>UserName\</Key\>\<Value\>SNMPv3_username\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>Context\</Key\>\<Value\>SNMPv3_context\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>PrivacyType\</Key\>\<Value\>AES128\</Value\>\<!--None = 0, DES56 = 1, AES128 = 2, AES192 = 3, AES256 = 4--\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>AuthenticationType\</Key\>\<Value\>SHA256\</Value\>\<!--None = 0, MD5 = 1, SHA1 = 2, SHA256 = 3, SHA512 = 4--\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>PrivacyPassword\</Key\>\<Value\>SNMPv3_privpassword\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>AuthenticationPassword\</Key\>\<Value\>SNMPv3_authpassword\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>PrivacyKeyIsPassword\</Key\>\<Value\>true\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>AuthenticationKeyIsPassword\</Key\>\<Value\>false\</Value\>\</KeyValueOfstringstring\>\</ArrayOfKeyValueOfstringstring\></code></details> | 2022.4. and later
SolarWinds.Orion.Core.Models.Credentials.SnmpCredentialsV2 | Node SNMPv2 credentials (only for discovery), include regular SNMPv1. | Orion | <details><summary>Properties</summary><code>\<ArrayOfKeyValueOfstringstring xmlns:i="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.microsoft.com/2003/10/Serialization/Arrays" \>\<KeyValueOfstringstring\>\<Key\>Name\</Key\>\<Value\>SNMPv2_credset\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>Description\</Key\>\<Value\>SNMPv2_desc\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>Community\</Key\>\<Value\>SNMPv2_community\</Value\>\</KeyValueOfstringstring\>\</ArrayOfKeyValueOfstringstring\></code></details> | 2022.4. and later
SolarWinds.Orion.Core.SharedCredentials.Credentials.CliCredential | Node credentials for CLI polling | CLI | <details><summary>Properties</summary><code>\<ArrayOfKeyValueOfstringstring xmlns:i="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.microsoft.com/2003/10/Serialization/Arrays" \>\<KeyValueOfstringstring\>\<Key\>Name\</Key\>\<Value\>CLI_credset\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>Description\</Key\>\<Value\>CLI_desc\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>Username\</Key\>\<Value\>CLI_username\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>Password\</Key\>\<Value\>CLI_password\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>EnablePassword\</Key\>\<Value\>CLI_credset_enablepass\</Value\>\</KeyValueOfstringstring\>\</ArrayOfKeyValueOfstringstring\></code></details> | 2022.4. and later
SolarWinds.Orion.Core.SharedCredentials.Credentials.BearerTokenCredential | API Poller credentials | Orion | <details><summary>Properties</summary><code>\<ArrayOfKeyValueOfstringstring xmlns:i="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.microsoft.com/2003/10/Serialization/Arrays" \>\<KeyValueOfstringstring\>\<Key\>Name\</Key\>\<Value\>bearer_token_credset\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>Description\</Key\>\<Value\>bearer_token_desc\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>Token\</Key\>\<Value\>bearer_token\</Value\>\</KeyValueOfstringstring\>\</ArrayOfKeyValueOfstringstring\></code></details> | 2023.2. and later 
SolarWinds.Orion.Core.SharedCredentials.Credentials.OAuth2Credential | SMTP server and API Poller credentials | Orion | <details><summary>Properties</summary><code>\<ArrayOfKeyValueOfstringstring xmlns:i="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.microsoft.com/2003/10/Serialization/Arrays" \>\<KeyValueOfstringstring\>\<Key\>Name\</Key\>\<Value\>oAuth2.0Cred\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>Description\</Key\>\<Value\>oAuth2.0Cred_desc\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>ClientSecret\</Key\>\<Value\>client secret value\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>ClientId\</Key\>\<Value\>client id\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>Scope\</Key\>\<Value\>scope\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>AccessTokenUrl\</Key\>\<Value\>access token url\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>Tenant\</Key\>\<Value\>tenant\</Value\>\</KeyValueOfstringstring\>\</ArrayOfKeyValueOfstringstring\></code></details> | 2023.2. and later
SolarWinds.CloudMonitoring.Contract.Credentials.AwsCredentials | AWS Cloud account credentials | CLM | <details><summary>Properties</summary><code>\<ArrayOfKeyValueOfstringstring xmlns:i="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.microsoft.com/2003/10/Serialization/Arrays" \>\<KeyValueOfstringstring\>\<Key\>Owner\</Key\>\<Value\>CLM\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>Name\</Key\>\<Value\>AWSName\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>Description\</Key\>\<Value\>Desc1\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>AccessKeyId\</Key\>\<Value\>Key1\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>SecretAccessKey\</Key\>\<Value\>Secret1\</Value\>\</KeyValueOfstringstring\>\</ArrayOfKeyValueOfstringstring\></code></details> | 2023.4. and later
SolarWinds.CloudMonitoring.Contract.Credentials.AzureCredentials | Azure Cloud account credentials | CLM | <details><summary>Properties</summary><code>\<ArrayOfKeyValueOfstringstring xmlns:i="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.microsoft.com/2003/10/Serialization/Arrays" \>\<KeyValueOfstringstring\>\<Key\>Owner\</Key\>\<Value\>CLM\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>Name\</Key\>\<Value\>AzureName\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>Description\</Key\>\<Value\>Desc1\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>SubscriptionId\</Key\>\<Value\>Sbuscription1\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>TenantId\</Key\>\<Value\>Tenant1\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>ClientId\</Key\>\<Value\>Client1\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>ApplicationSecretKey\</Key\>\<Value\>Secret1\</Value\>\</KeyValueOfstringstring\>\</ArrayOfKeyValueOfstringstring\></code></details> | 2023.4. and later
SolarWinds.Orion.Core.SharedCredentials.Credentials.UsernameWithOauth2Credentials | Used for Oauth 2.0 authentication with password Grant type | Orion | <details><summary>Properties</summary><code>\<ArrayOfKeyValueOfstringstring xmlns:i="http://www.w3.org/2001/XMLSchema-instance" xmlns="http://schemas.microsoft.com/2003/10/Serialization/Arrays" \>\<KeyValueOfstringstring\>\<Key\>Name\</Key\>\<Value\>secret1\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>CustomerId\</Key\>\<Value\>secret1\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>Username\</Key\>\<Value\>username1\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>Password\</Key\>\<Value\>password1\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>ClientId\</Key\>\<Value\>secret2\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>ClientSecret\</Key\>\<Value\>secret3\</Value\>\</KeyValueOfstringstring\>\<KeyValueOfstringstring\>\<Key\>AccessTokenUrl\</Key\>\<Value\>url\</Value\>\</KeyValueOfstringstring\>\</ArrayOfKeyValueOfstringstring\></code></details> | 2024.2. and later
SolarWinds.Orion.Core.SharedCredentials.Credentials.GcpCredential | Uses GCP credentials details. Used by CLM to monitor GCP cloud resources, defined by user during cloud integration wizard. | CLM | <details><summary>Properties</summary><code>\<dictionary xmlns="http://schemas.solarwinds.com/2007/08/informationservice/propertybag"\>\<item\>\<key\>Name\</key\>\<type\>System.String\</type\>\<value\>Gcpname555\</value\>\</item\>\<item\>\<key\>Description\</key\>\<type\>System.String\</type\>\<value\>Gcp details\</value\>\</item\>\<item\>\<key\>KeyId\</key\>\<type\>System.String\</type\>\<value\>1234\</value\>\</item\>\<item\>\<key\>Scopes\</key\>\<type\>System.String\</type\>\<value\>Scope\</value\>\</item\>\<item\>\<key\>Url\</key\>\<type\>System.String\</type\>\<value\>https://GcpUrl\</value\>\</item\>\<item\>\<key\>PrivateKey\</key\>\<type\>System.String\</type\>\<value\>1233\</value\>\</item\>\</dictionary\></code></details> | 2025.2. and later

### API Poller credentials support

API Poller use the following credentials types with owner parameter set to `ApiPoller`:
* Api Key credentials - SolarWinds.Orion.Core.SharedCredentials.Credentials.ApiKeyCredential type.
* Basic Auth credentials - SolarWinds.Orion.Core.SharedCredentials.Credentials.UsernamePasswordCredential type.
* Bearer Token credentials - SolarWinds.Orion.Core.SharedCredentials.Credentials.BearerTokenCredential type.
* oAuth 2.0 credentials - SolarWinds.Orion.Core.SharedCredentials.Credentials.OAuth2Credential type.

_Supported since: SolarWinds Platform 2023.2_

<!--EndFragment-->
</body>
</html>