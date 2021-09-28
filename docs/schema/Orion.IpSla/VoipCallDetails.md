---
id: VoipCallDetails
slug: VoipCallDetails
---

# Orion.IpSla.VoipCallDetails

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| CcmID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| CallManagerSysName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CallManagerName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CallID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CallDetailsRecordName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DateTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| DateTimeOrigination | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| DateTimeDisconnect | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| CallingPartyNumber | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OriginalCalledPartyNumber | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| FinalCalledPartyNumber | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Duration | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OrigDeviceName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrigCCMPhoneMacAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrigCCMPhoneStatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrigCCMPhoneIPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrigCCMPhoneExtension | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrigCCMRegionName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DestDeviceName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DestCCMPhoneMacAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DestCCMPhoneStatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DestCCMPhoneIPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DestCCMPhoneExtension | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DestCCMRegionName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrigCause_value | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DestCause_value | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OrigJitter | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OrigLatency | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OrigMOS | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| OrigPacketLoss | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OrigNumberPacketsSent | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DestJitter | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DestLatency | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DestMOS | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| DestPacketLoss | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DestNumberPacketsSent | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OriginGatewayDeviceName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OriginGatewayIPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OriginGatewayStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DestGatewayDeviceName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DestGatewayIPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DestGatewayStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OrigIPAddressFromCDR | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DestIPAddressFromCDR | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrigRegionID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DestRegionID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OrigLegIdentifier | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DestLegIdentifier | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OrigIpAddr | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DestIpAddr | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LastRedirectDn | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LastRedirectRedirectReason | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OrigConversationId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DestConversationId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OrigDateTimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| DestDateTimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| OrigCalledPartyRedirectReason | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| CallSuccess | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| ZeroDurationCall | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| ConferenceCall | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| AvayaConditionCode | [System.Char](https://docs.microsoft.com/en-us/dotnet/api/system.char) |  | everyone |
| DestGatewayID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OrigGatewayID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DestPhoneID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OrigPhoneID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| CallWithIssue | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| OrigFailedCall | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DestFailedCall | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| OriginRegion | [Orion.IpSla.CCMRegions](./../Orion.IpSla/CCMRegions) | Defined by relationship Orion.IpSla.VoipCallDetailsReferencesOriginRegion (System.Reference) |
| DestinationRegion | [Orion.IpSla.CCMRegions](./../Orion.IpSla/CCMRegions) | Defined by relationship Orion.IpSla.VoipCallDetailsReferencesDestinationRegion (System.Reference) |
| OriginGateway | [Orion.IpSla.CCMGateways](./../Orion.IpSla/CCMGateways) | Defined by relationship Orion.IpSla.VoipCallDetailsReferencesOriginGateway (System.Reference) |
| DestinationGateway | [Orion.IpSla.CCMGateways](./../Orion.IpSla/CCMGateways) | Defined by relationship Orion.IpSla.VoipCallDetailsReferencesDestinationGateway (System.Reference) |
| OriginPhone | [Orion.IpSla.CCMPhones](./../Orion.IpSla/CCMPhones) | Defined by relationship Orion.IpSla.VoipCallDetailsReferencesOriginPhone (System.Reference) |
| DestinationPhone | [Orion.IpSla.CCMPhones](./../Orion.IpSla/CCMPhones) | Defined by relationship Orion.IpSla.VoipCallDetailsReferencesDestinationPhone (System.Reference) |
| CCMMonitoring | [Orion.IpSla.CCMMonitoring](./../Orion.IpSla/CCMMonitoring) | Defined by relationship Orion.Ipsla.CCMMonitoringHostsVoipCallDetails (System.Hosting) |

