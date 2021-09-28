---
id: Proxy
slug: Proxy
---

# Orion.AgentManagement.Proxy

SolarWinds Information Service 2020.2 Schema Documentation Index

Proxy settings used in agent to AMS communications.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete | admin |
| create,read,update,delete,invoke | manageNodes |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ProxyId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of proxy | everyone |
| ProxyUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | A string value with is the URL to the proxy server. | everyone |
| UseProxyAuthentication | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | A boolean value indicating whether proxy authentication is to be used. | everyone |
| ProxyCredentialId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | ID of the Orion credentials to use for proxy authentication. | everyone |

## Verbs

### AddProxy

Adds a proxy entry.

#### Access control

everyone

### DeleteProxy

Delete a proxy entry.

#### Access control

everyone

