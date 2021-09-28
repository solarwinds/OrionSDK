---
id: DomainTrust
slug: DomainTrust
---

# Orion.APM.ActiveDirectory.DomainTrust

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents Active Directory trust information.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| TrustingDomainName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of trusting domain. | everyone |
| TrustedDomainName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of trusted domain. | everyone |
| Type | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Trust type description. | everyone |
| TypeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of the Type. | everyone |
| Direction | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Trust direction description. | everyone |
| DirectionID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of the direction. | everyone |
| IsNonTransitive | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | If it's 'true' then trust cannot be used transitively. | everyone |
| IsUpLevelOnly | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | If it's 'true' then trust can only Windows 2000 or newer clients can use that trust. | everyone |
| IsQuarantinedDomain | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | If it's 'true' then trust is quarantined. | everyone |
| IsForestTransitive | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | If it's 'true' then trust is a cross-forest trust. | everyone |
| IsCrossOrganization | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | If it's 'true' then trust is to a domain or forset that is not part of the organization. | everyone |
| IsWithinForest | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | If it's 'true' then the trusted domain is within the same forest. | everyone |
| IsTreatAsExternal | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | If it's 'true' then trust is treated as external. | everyone |
| IsUsingRC4Encryption | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | If it's 'true' then trust is capable of using RC4 keys. | everyone |
| IsCrossOrganizationNoTgtDelegation | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | If it's 'true' then tickets granted under this trust MUST NOT be trusted for delegation. | everyone |
| IsPIMTrust | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | If it's 'true'  a cross-forest trust to a domain is to be treated as Privileged Identity Management trust. | everyone |

