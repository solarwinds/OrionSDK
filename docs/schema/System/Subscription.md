---
id: Subscription
slug: Subscription
---

# System.Subscription

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,delete | system |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| Id | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| EndpointAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Query | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LastSuccessfulDelivery | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| FailedDeliveryAttempts | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Binding | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DataFormat | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CredentialType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Version | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| TTL | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ReliableDelivery | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Username | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | create: system&amp;lt;br/&amp;gt;read: everyone |
| Password | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | create: system&amp;lt;br/&amp;gt;read: everyone |

