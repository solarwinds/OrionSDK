---
id: L2LTunnel
slug: L2LTunnel
---

# Orion.VPN.L2LTunnel

SolarWinds Information Service 2020.2 Schema Documentation Index

List of Site-to-Site Tunnels on VPN device

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| TunnelID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SourceIPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SourceHostname | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TargetIPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TargetHostname | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AuthenticationMethodPhase1 | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EncryptionAlgPhase1 | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| HashAlgPhase1 | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AuthenticationAlgPhase2 | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EncryptionAlgPhase2 | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| InBitsPerSecond | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| OutBitsPerSecond | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| StartTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| FailPhase | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AuthenticationMethodPhase1Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EncryptionAlgPhase1Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| HashAlgPhase1Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AuthenticationAlgPhase2Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EncryptionAlgPhase2Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| FailPhaseDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Statistics | [Orion.VPN.L2LTunnelStatistics](./../Orion.VPN/L2LTunnelStatistics) | Defined by relationship Orion.VPN.L2LTunnelStatistics (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodeReferencesVPNL2LTunnel (System.Reference) |
| AsaDevice | [Orion.ASA.Node](./../Orion.ASA/Node) | Defined by relationship Orion.AsaDeviceHostsVpnSiteToSiteTunnels (System.Hosting) |

## Verbs

### SetFavorite

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### RemoveFavorite

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

