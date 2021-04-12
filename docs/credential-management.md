---
title: Credential Management
---

Various Orion processes ([discovery](./discovery), polling) work with credentials that are stored in Orion.
This page describes how to manage credentials using Orion SDK.

## Verbs

The Orion.Credential entity provides following verbs to create Orion credentials.Parameters are listed in C# syntax.

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

Verb returns ID of the newly created Orion.Credential instance.
Credential name must be unique for given credential type, exception is thrown otherwise.

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

Verb returns ID of the newly created Orion.Credential instance.
Credential name must be unique for given credential type, exception is thrown otherwise.

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

Verb returns ID of the newly created Orion.Credential instance.
Credential name must be unique for given credential type, exception is thrown otherwise.

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
