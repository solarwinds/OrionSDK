---
layout: default
title: "SAM AppInsight Applications"
---

Applnsight applications provide a level of detail and expert knowledge far beyond what a simple template can provide, allowing you to monitor virtually every aspect of the assigned application.

Like any unassigned application in SAM, Appinsight applications are considered templates until applied. Therefore, it is a member of the Application Monitor Templates collection.

Once applied to a node, Applnsight applications are considered applications like any SAM application, Applnsight applications are comprised of multiple component monitors, also known as performance counters.

Currently, SAM offers 4 different Applnsight Applications:
* AppInsight for Active Directory
* AppInsight for Exchange
* AppInsight for IIS
* AppInsight for SQL

Orion SDK provides different endpoints and examples for configurations of the AppInsights.
See PowerShell [samples](https://github.com/solarwinds/OrionSDK/tree/master/Samples/PowerShell/SAM.AppInsightAutomation)

# General REST Endpoints for AppInsight
To set up any application within the Server & Application Monitor (SAM), you are required to furnish both the _applicationTemplateId_ and _credentialSetId_. These identifiers play crucial roles in defining the application's template and specifying the credentials necessary for its configuration. 

## How to list the necessary application template for AppInsight ?
### :green_circle: GET Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Query?query=SELECT+ApplicationTemplateID%2c+Name%2c+CustomApplicationType+FROM+Orion.APM.ApplicationTemplate+WHERE+Name+LIKE+%27%25AppInsight%25%27
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Example Response
```json
{
    "results": [
        {
            "ApplicationTemplateID": 10,
            "Name": "AppInsight for Active Directory",
            "CustomApplicationType": "ABAA"
        },
        {
            "ApplicationTemplateID": 11,
            "Name": "AppInsight for IIS",
            "CustomApplicationType": "ABIA"
        },
        {
            "ApplicationTemplateID": 12,
            "Name": "AppInsight for Exchange",
            "CustomApplicationType": "ABXA"
        },
        {
            "ApplicationTemplateID": 13,
            "Name": "AppInsight for SQL",
            "CustomApplicationType": "ABSA"
        }
    ]
}
```
## How to list existing credentials for AppInsight ?
### :green_circle: GET Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Query?query=SELECT+ID%2c+Name%2c+CredentialType%2c+CredentialOwner+FROM+Orion.Credential+WHERE+CredentialOwner+%3d+%27APM%27
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Example Response
```json
{
    "results": [
        {
            "ID": 9,
            "Name": "sqlcred",
            "CredentialType": "SolarWinds.APM.Common.Credentials.ApmUsernamePasswordCredential",
            "CredentialOwner": "APM"
        },
        {
            "ID": 10,
            "Name": "iiscred",
            "CredentialType": "SolarWinds.APM.Common.Credentials.ApmUsernamePasswordCredential",
            "CredentialOwner": "APM"
        },
        {
            "ID": 12,
            "Name": "activeDirectory",
            "CredentialType": "SolarWinds.APM.Common.Credentials.ApmUsernamePasswordCredential",
            "CredentialOwner": "APM"
        },
        {
            "ID": 14,
            "Name": "exchangeSrver",
            "CredentialType": "SolarWinds.APM.Common.Credentials.ApmUsernamePasswordCredential",
            "CredentialOwner": "APM"
        }
    ]
}
```
## How to create credentials for AppInsight ?
### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.Credential/CreateCredentials
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{
    "type": "SolarWinds.APM.Common.Credentials.ApmUsernamePasswordCredential",
    "properties": {
        "Name": "Credential Name",
        "Username": "New Username",
        "Password": "New Password"
    },
    "owner": "APM"
}
```
### Example Response
Returns _credentialId_ if the operation is successful
## How to update credentials for AppInsight ?
### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.Credential/UpdateCredentials
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{
    "id": 17,
    "properties": {
        "Username": "Updated Username",
        "Password": "Updated Password"
    }
}
```
### Example Response
Returns _null_ if the operation is successful.
# REST Endpoints AppInsight for SQL
## How to create AppInsight for SQL application?
To create an application it is needed to provide _applicationSettings_ related to AppInsight for SQL template. 
### UI
![image](https://github.com/solarwinds/OrionSDK/assets/67432351/f2cd8f5c-7c87-4f46-96c0-ac470492c0c8)
### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.SqlServerApplication/CreateApplication
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{
  "nodeId": 1,
  "applicationTemplateId": 13,
  "credentialSetId": 9,
  "skipIfDuplicate": true,
  "applicationSettings": {
      "PortType": "default"
   }
}
```
Or 

```json
{
  // Other fields
  "applicationSettings": {
      "PortType": "static",
      "PortNumber": "1433",
   }
}
```
### Example Response
Returns _applicationId_ if the application was created. \
Returns _-1_ if the application already exists.
## How to delete AppInsight for SQL application?
### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.SqlServerApplication/DeleteApplication
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{
    "applicationId": 1
}
```
### Example Response
Returns _null_ if the operation is successful.
## How to poll fresh data for AppInsight for SQL application?
### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.SqlServerApplication/PollNow
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{
    "applicationId": 1
}
```
### Example Response
Returns _null_ if the operation is successful.
## How to unmanage the AppInsight for SQL application?
To unmanage the application you need to provide _netObjectId_. It consists of 2 parts NetObjectType for Application (AA) and ApplicationId. 
 ### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.SqlServerApplication/Unmanage
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{
  "netObjetId": "AA:1",
  "unmanageTime": "2024-02-19T18:16:16.113Z",
  "remanageTime": "2024-02-20T18:16:16.113Z",
  "isRelative": true
}
```
### Example Response
Returns _null_ if the operation is successful.
## How to remanage the AppInsight for SQL application?
 ### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.SqlServerApplication/Remanage
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{
  "netObjetId": "AA:1"
}
```
### Example Response
Returns _null_ if the operation is successful.
# REST Endpoints AppInsight for IIS
## How to create AppInsight for IIS application?
To create an application it is needed to provide _applicationSettings_ related to AppInsight for IIS template.
### UI
![image](https://github.com/solarwinds/OrionSDK/assets/67432351/8a03d735-4168-4d01-891c-1e50b58fea5d)
### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/JsonInvoke/Orion.APM.IIS.Application/CreateApplication
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{
  "nodeId": 2,
  "applicationTemplateId": 11,
  "credentialSetId": 10, 
  "skipIfDuplicate": true,
  "applicationSettings": {
      "NodeIpAddress": "Target Node Ip address",
      "PsUrlWindowsValue": "https://${IP}:5986/wsman/"
   }
}
```
### Example Response
Returns _applicationId_ if the application was created. \
Returns _-1_ if the application already exists.
## How to delete AppInsight for IIS application?
### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.IIS.Application/DeleteApplication
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{
    "applicationId": 2
}
```
### Example Response
Returns _null_ if the operation is successful.
## How to schedule configuration for application of AppInsight for IIS?
### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.IIS.Application/ScheduleConfiruation
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{
    "applicationId": 2,
    "credentialsId": 10
}
```
### Example Response
Returns _executionKey_ if the operation is successful.
```text
solarwinds.apm.remoteiisconfiguratorfull.exe-{node-ip}
```
## How to get configuration result for application of AppInsight for IIS?
### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.IIS.Application/GetConfigurationResult
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{
    "executionKey":  "solarwinds.apm.remoteiisconfiguratorfull.exe-{node-ip}"
}
```
### Example Response
Returns _ConfigurationResult_ if the operation is successful.
```json
{
    "IsFinished": true,
    "ExitCode": 0,
    "ErrorDescription": null
}
```
```json
{
    "IsFinished": true,
    "ExitCode": 16013,
    "ErrorDescription": "Unable to access the remote administrator share (Error code: 16013)"
}
```
## How to poll fresh data for AppInsight for IIS application?
### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.IIS.Application/PollNow
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{
    "applicationId": 2
}
```
### Example Response
Returns _null_ if the operation is successful.
## How to unmanage the AppInsight for IIS application?
To unmanage the application you need to provide _netObjectId_. It consists of 2 parts NetObjectType for Application (AA) and ApplicationId.  
### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.IIS.Application/Unmanage
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{
  "netObjetId": "AA:2",
  "unmanageTime": "2024-02-19T18:16:16.113Z",
  "remanageTime": "2024-02-20T18:16:16.113Z",
  "isRelative": true
}
```
### Example Response
Returns _null_ if the operation is successful
## How to remanage the AppInsight for IIS application?
### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.IIS.Application/Remanage
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{
  "netObjetId": "AA:2"
}
```
### Example Response
Returns _null_ if the operation is successful
# REST Endpoints AppInsight for Active Directory
## How to create AppInsight for Active Directory application?
To create an application it is needed to provide _applicationSettings_ related to AppInsight for Active Directory template.
### UI
![image](https://github.com/solarwinds/OrionSDK/assets/67432351/5667bd6a-d3f5-4e19-a5ce-bb332bff05ae)
### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/JsonInvoke/Orion.APM.ActiveDirectory.Application/CreateApplication
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{
  "nodeId": 3,
  "applicationTemplateId": 10,
  "credentialSetId": 9,
  "skipIfDuplicate": true,
  "applicationSettings": {
      "Port": "389",
      "GCPort": "3268",
      "EncryptionMethod": "0",  
      "AuthenticationMethod": "2", 
      "IgnoreCertificateErrors": "true"
   }
}
```
> [!NOTE]
>  **EncryptionMethod:**  
>  0 - None \
>  1 - SSL 

> [!NOTE]
>  **AuthenticationMethod:** \
>    0 - Anonymus \
>    1 - Simple \
>    2 - Ntlm \
>    3 - Kerberos \
>    4 - Negotiate 
### Example Response
Returns _applicationId_ if the application was created. \
Returns _-1_ if the application already exists.
## How to assign AppInsight for an Active Directory application?
The process of assigning the application is basically the same as creating an application. 
You need to provide application settings in xml format. Instead of _applicationSettings_ we use _serializedSettings_.
### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/JsonInvoke/Orion.APM.ActiveDirectory.Application/AssignApplication
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{ 
  "nodeId": 3, 
  "serializedSettings": "Active Directory Settings in XML format" 
}
```
### Example of Settings
```xml
<Settings xmlns="http://schemas.datacontract.org/2004/07/SolarWinds.APM.BlackBox.ActiveDirectory.Common.Models" xmlns:i="http://www.w3.org/2001/XMLSchema-instance">
  <settings xmlns:a="http://schemas.microsoft.com/2003/10/Serialization/Arrays">
    <a:KeyValueOfstringSettingValueyR_SGpLPx>
      <a:Key>CredentialSetId</a:Key>
      <a:Value xmlns:b="http://schemas.solarwinds.com/2007/08/APM">
        <b:Required>false</b:Required>
        <b:SettingLevel>Instance</b:SettingLevel>
        <b:Value>9</b:Value>
        <b:ValueType>String</b:ValueType>
        <b:Key>CredentialSetId</b:Key>
      </a:Value>
    </a:KeyValueOfstringSettingValueyR_SGpLPx>
    <a:KeyValueOfstringSettingValueyR_SGpLPx>
      <a:Key>__Timeout</a:Key>
      <a:Value xmlns:b="http://schemas.solarwinds.com/2007/08/APM">
        <b:Required>true</b:Required>
        <b:SettingLevel>Template</b:SettingLevel>
        <b:Value>1800</b:Value>
        <b:ValueType>String</b:ValueType>
        <b:Key>__Timeout</b:Key>
      </a:Value>
    </a:KeyValueOfstringSettingValueyR_SGpLPx>
    <a:KeyValueOfstringSettingValueyR_SGpLPx>
      <a:Key>Port</a:Key>
      <a:Value xmlns:b="http://schemas.solarwinds.com/2007/08/APM">
        <b:Required>true</b:Required>
        <b:SettingLevel>Instance</b:SettingLevel>
        <b:Value>389</b:Value>
        <b:ValueType>String</b:ValueType>
        <b:Key>Port</b:Key>
      </a:Value>
    </a:KeyValueOfstringSettingValueyR_SGpLPx>
    <a:KeyValueOfstringSettingValueyR_SGpLPx>
      <a:Key>GCPort</a:Key>
      <a:Value xmlns:b="http://schemas.solarwinds.com/2007/08/APM">
        <b:Required>true</b:Required>
        <b:SettingLevel>Instance</b:SettingLevel>
        <b:Value>3268</b:Value>
        <b:ValueType>String</b:ValueType>
        <b:Key>GCPort</b:Key>
      </a:Value>
    </a:KeyValueOfstringSettingValueyR_SGpLPx>
    <a:KeyValueOfstringSettingValueyR_SGpLPx>
      <a:Key>AuthenticationMethod</a:Key>
      <a:Value xmlns:b="http://schemas.solarwinds.com/2007/08/APM">
        <b:Required>true</b:Required>
        <b:SettingLevel>Instance</b:SettingLevel>
        <b:Value>Ntlm</b:Value>
        <b:ValueType>String</b:ValueType>
        <b:Key>AuthenticationMethod</b:Key>
      </a:Value>
    </a:KeyValueOfstringSettingValueyR_SGpLPx>
    <a:KeyValueOfstringSettingValueyR_SGpLPx>
      <a:Key>EncryptionMethod</a:Key>
      <a:Value xmlns:b="http://schemas.solarwinds.com/2007/08/APM">
        <b:Required>true</b:Required>
        <b:SettingLevel>Instance</b:SettingLevel>
        <b:Value>None</b:Value>
        <b:ValueType>String</b:ValueType>
        <b:Key>EncryptionMethod</b:Key>
      </a:Value>
    </a:KeyValueOfstringSettingValueyR_SGpLPx>
    <a:KeyValueOfstringSettingValueyR_SGpLPx>
      <a:Key>IgnoreCertificateErrors</a:Key>
      <a:Value xmlns:b="http://schemas.solarwinds.com/2007/08/APM">
        <b:Required>true</b:Required>
        <b:SettingLevel>Instance</b:SettingLevel>
        <b:Value>True</b:Value>
        <b:ValueType>Boolean</b:ValueType>
        <b:Key>IgnoreCertificateErrors</b:Key>
      </a:Value>
    </a:KeyValueOfstringSettingValueyR_SGpLPx>
  </settings>
</Settings>
```
### Example Response
Returns _applicationId_ if the application was created. \
Returns _-1_ if the application already exists.
## How to delete AppInsight for Active Directory application?
### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.ActiveDirectory.Application/DeleteApplication
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{
    "applicationId": 3
}
```
### Example Response
Returns _null_ if the operation is successful. 
## How to disable domain components data of AppInsight for Active Directory application?
### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.ActiveDirectory.Application/DisableDomainComponents
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{
    "applicationId": 3
}
```
### Example Response
Returns _null_ if the operation is successful.
## How to delete domain components data of AppInsight for Active Directory application?
### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.ActiveDirectory.Application/DeleteDisabledComponentsData
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{
    "applicationId": 3
}
```
### Example Response
Returns _null_ if the operation is successful.
## How to poll fresh data for AppInsight for Active Directory application?
### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.ActiveDirectory.Application/PollNow
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{
    "applicationId": 3
}
```
### Example Response
Returns _null_ if the operation is successful.
## How to unmanage the AppInsight for Active Directory application?
To unmanage the application you need to provide _netObjectId_. It consists of 2 parts NetObjectType for Application (AA) and ApplicationId. 
### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.ActiveDirectory.Application/Unmanage
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{
  "netObjetId": "AA:3",
  "unmanageTime": "2024-02-19T18:16:16.113Z",
  "remanageTime": "2024-02-20T18:16:16.113Z",
  "isRelative": true
}
```
### Example Response
Returns _null_ if the operation is successful.
## How to remanage the AppInsight for Active Directory application?
### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.ActiveDirectory.Application/Remanage
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{
  "netObjetId": "AA:3"
}
```
### Example Response
Returns _null_ if the operation is successful.
# REST Endpoints AppInsight for Exchange
## How to create AppInsight for Active Directory application?
To create an application it is needed to provide _applicationSettings_ related to AppInsight for Exchange template. 
### UI
![image](https://github.com/solarwinds/OrionSDK/assets/67432351/a55adcac-740c-4c5d-b960-2658b8ef7353)
### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/JsonInvoke/Orion.APM.Exchange.Application/CreateApplication
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{
  "nodeId": 4,
  "applicationTemplateId": 12,
  "credentialSetId": 14,
  "skipIfDuplicate": true,
  "applicationSettings": {
      "PsUrlWindows": "https://${IP}:5986/wsman/",
      "PsUrlExchange": "https://${IP}/powershell/"
   }
}
```
### Example Response
Returns _applicationId_ if the application was created. \
Returns _-1_ if the application already exists.
## How to delete AppInsight for Exchange application?
### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.Exchange.Application/DeleteApplication
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{
    "applicationId": 4
}
```
### Example Response
Returns _null_ if the operation is successful.
## How to schedule configuration for application of AppInsight for Exchange ?
### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.Exchange.Application/ScheduleConfiruation
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{
    "applicationId": 4,
    "credentialsId": 14,
}
```
### Example Response
Returns _executionKey_ if the operation is successful.
```text
solarwinds.apm.remotewinrmconfiguratorfull.exe-{node-ip}
```
## How to get configuration result for application of AppInsight for Exchange ?
### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.Exchange.Application/GetConfigurationResult
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{
    "executionKey":  "solarwinds.apm.remotewinrmconfiguratorfull.exe-{node-ip}"
}
```
### Example Response
Returns _ConfigurationResult_ if the operation is successful.
```json
{
    "IsFinished": true,
    "ExitCode": 0,
    "ErrorDescription": null
}
```
```json
{
    "IsFinished": true,
    "ExitCode": 16013,
    "ErrorDescription": "Unable to access the remote administrator share (Error code: 16013)"
}
```
## How to poll fresh data for AppInsight for Exchange application?
### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.Exchange.Application/PollNow
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{
    "applicationId": 4
}
```
### Example Response
Returns _null_ if the operation is successful.
## How to unmanage the AppInsight for Exchange application?
To unmanage the application you need to provide _netObjectId_. It consists of 2 parts NetObjectType for Application (AA) and ApplicationId. 
### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.Exchange.Application/Unmanage
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{
  "netObjetId": "AA:4",
  "unmanageTime": "2024-02-19T18:16:16.113Z",
  "remanageTime": "2024-02-20T18:16:16.113Z",
  "isRelative": true
}
```
### Example Response
Returns _null_ if the operation is successful.
## How to remanage the AppInsight for Exchange application?
### :orange_circle: POST Query Request 
```text
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.Exchange.Application/Remanage
```
### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
### Body _raw_
```json
{
  "netObjetId": "AA:4"
}
```
### Example Response
Returns _null_ if the operation is successful.