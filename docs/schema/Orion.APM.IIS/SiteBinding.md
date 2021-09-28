---
id: SiteBinding
slug: SiteBinding
---

# Orion.APM.IIS.SiteBinding

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents details of site's bindings.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of site binding. | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string representation of site binding name. | everyone |
| SiteID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of request target site. | everyone |
| Protocol | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The protocol used for the site binding. | everyone |
| HostName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The host name used to access the site. | everyone |
| Port | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The port on which HTTP.sys must listen for requests made to a site. | everyone |
| IpAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The IP address that users can use to access a site. | everyone |
| BindingInformation | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The nonempty read/write string value with three colon-delimited fields that specify binding information for a Web site. The first field is a specific IP address or an asterisk (an asterisk specifies all unassigned IP addresses). The second field is the port number; the default is 80. The third field is an optional host header. | everyone |
| SslSubject | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The subject distinguished name from the certificate. | everyone |
| SslValidDate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date in local time on which a certificate becomes valid. | everyone |
| SslExpiryDate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date in local time after which a certificate is no longer valid. | everyone |
| SslPolicyErrors | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The property which enumerates Secure Socket Layer (SSL) policy errors. | everyone |
| SslDaysRemaining | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The number of remaining days for SSL certificate. | everyone |
| SslCommonName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the certificate common name. | everyone |
| SslCertificateUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the certificate common name and port. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | URL to site details page. Used in alerting. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Site | [Orion.APM.IIS.Site](./../Orion.APM.IIS/Site) | Defined by relationship Orion.APM.IIS.SiteHostsSiteBinding (System.Hosting) |

