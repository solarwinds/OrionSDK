---
title: Connecting to SWIS
---

## Connecting to SWIS with SWQL Studio

When you open SWQL Studio, the **Connect to Information Service** dialog appears.
There are several options for connecting to SWIS.

### Server Name

Enter the name or IP address of the Orion server you would like to connect to.
Do not specify the port number.
Examples:

* myorion.mydomain.local
* 12.153.24.2

### Server Type

Server Type | Description
--- | ---
Orion (v3) | You must supply a **User Name** and **Password** below. These are sent to the Orion server for authentication.  The user name and password can be for an [Active Directory](https://docs.microsoft.com/en-us/windows-server/identity/ad-ds/get-started/virtual-dc/active-directory-domain-services-overview) account, if applicable.
Orion (v3) AD | SWQL Studio sends your current Windows ([Kerberos](https://docs.microsoft.com/en-us/windows-server/security/kerberos/kerberos-authentication-overview)) token to the Orion server for authentication.  See [Enable Windows Authentication with Active Directory in the Orion Platform](https://documentation.solarwinds.com/en/Success_Center/orionplatform/Content/Core-Windows-Authentication-with-Active-Directory-sw2411.htm) for details on how to enable Windows Authentication on the Orion server.
Orion (v3) Certificate | SWQL Studio looks for a certificate with the common name **SolarWinds-Orion** on the local machine.  It uses this as the client certificate in a [TLS handshake](https://docs.microsoft.com/en-us/windows/win32/secauthn/tls-handshake-protocol) with the Orion server. Generally this will only be available if SWQL Studio is running on the Orion server, and if SWQL Studio is running elevated (UAC) to be able to read the private key for this certificate. This corresponds to using the `-Certificate` option in the `Connect-Swis` PowerShell commandlet.
Orion (v3) over HTTPS | This is identical to the username/password authentication with the **Orion (v3)** option, but it connecting using HTTPS on port 17778 rather than net.tcp over port 17777. Expect a warning popup about the self-signed certificate that SWIS will present in this case.
Orion (v2) | This works like **Orion (v3)**, but it connects to the legacy SWISv2 service on the Orion server. Avoid this mode unless you are connecting to a very old version of Orion that does not support SWISv3.
Orion (v2) AD | This works like **Orion (v3) AD**, but it connects to the legacy SWISv2 service on the Orion server. Avoid this mode unless you are connecting to a very old version of Orion that does not support SWISv3.
Orion (v2) Certificate | This works like **Orion (v3) Certificate**, but it connects to the legacy SWISv2 service on the Orion server. Avoid this mode unless you are connecting to a very old version of Orion that does not support SWISv3.
Orion (v2) over HTTPS | This works like **Orion (v3) over HTTPS**, but it connects to the legacy SWISv2 service on the Orion server. Avoid this mode unless you are connecting to a very old version of Orion that does not support SWISv3.
EOC | This mode connects to the old [Enterprise Operations Console (EOC)](https://www.solarwinds.com/enterprise-operations-console) product that had its own platform. This mode is not relevant to the current Orion Platform-based EOC.
NCM | This mode connects to old versions of [Network Configuration Manager (NCM)](https://www.solarwinds.com/network-configuration-manager) from the transition period when it was a separate standalone product, but had an Orion integration module. It uses username/password authentication.
NCM (Windows Authentication) | This is like the **NCM** mode, but it uses your Windows token instead of a username and password.
NCM Integration | This is similar to the **NCM** mode, but it connects to a different endpoint over SSL.
Java over HTTP | This is similar to **Orion (v3) over HTTPS**, but you must specify the full URL instead of just the hostname. This allows for connecting to other implementations of the SWIS SOAP interface. Now that [Virtualization Manager (VMAN)](https://www.solarwinds.com/virtualization-manager) has fully transitioned to just being an Orion module, this mode is no longer useful.

### User Name

The user name for the account.
This field is only enabled when a **Server Type** is selected that allows a user name to be specified.

### Password

The password for the account.
This field is only enabled when a **Server Type** is selected that allows a password to be specified.

## Connecting to SWIS with PowerShell

Below are examples for connecting to SWIS with PowerShell via the most common methods.

### Orion User Name and Password

This corresponds to the **Orion (v3)** mode above.

``` pwsh
$host = '12.153.24.2'
$user = 'admin'
$password = 'swordfish'
$swis = Connect-Swis -Hostname $host -Username $user -Password $password
```

### Windows (Active Directory) Authentication

This corresponds to the **Orion (v3) AD** mode above.
You can use the Active Directory credentials of the current user...

``` pwsh
$host = 'myorion.mydomain.local'
$swis = Connect-Swis -Hostname $host -Trusted
```

... or supply credentials for a different user account.

``` pwsh
$host = 'myorion.mydomain.local'
$creds = Get-Credential  # display a window asking for credentials
$swis = Connect-Swis -Hostname $host -Credential $creds
```

See [Get-Credential](https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.security/get-credential?view=powershell-6) for more details about creating `PSCredential` objects.

### Certificate

This corresponds to the **Orion (v3) Certificate** mode above.

``` pwsh
$host = 'localhost'
$swis = Connect-Swis -Hostname $host -Certificate
```
