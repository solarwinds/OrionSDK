---
id: Polling
slug: Polling
---

# Orion.AssetInventory.Polling

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PollingDescriptionName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LastPollDateTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Enabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ServerInformation | [Orion.AssetInventory.ServerInformation](./../Orion.AssetInventory/ServerInformation) | Defined by relationship Orion.AssetInventory.NodesAIServerInformation (System.Reference) |
| WindowsUpdates | [Orion.AssetInventory.WindowsUpdates](./../Orion.AssetInventory/WindowsUpdates) | Defined by relationship Orion.AssetInventory.NodesAIWindowsUpdates (System.Reference) |
| Processor | [Orion.AssetInventory.Processor](./../Orion.AssetInventory/Processor) | Defined by relationship Orion.AssetInventory.NodesAIProcessor (System.Reference) |
| MemoryModule | [Orion.AssetInventory.MemoryModule](./../Orion.AssetInventory/MemoryModule) | Defined by relationship Orion.AssetInventory.NodesAIMemoryModule (System.Reference) |
| HardDrive | [Orion.AssetInventory.HardDrive](./../Orion.AssetInventory/HardDrive) | Defined by relationship Orion.AssetInventory.NodesAIHardDrive (System.Reference) |
| LogicalDrive | [Orion.AssetInventory.LogicalDrive](./../Orion.AssetInventory/LogicalDrive) | Defined by relationship Orion.AssetInventory.NodesAILogicalDrive (System.Reference) |
| Software | [Orion.AssetInventory.Software](./../Orion.AssetInventory/Software) | Defined by relationship Orion.AssetInventory.NodesAISoftware (System.Reference) |
| Driver | [Orion.AssetInventory.Driver](./../Orion.AssetInventory/Driver) | Defined by relationship Orion.AssetInventory.NodesAIDriver (System.Reference) |
| USBController | [Orion.AssetInventory.USBController](./../Orion.AssetInventory/USBController) | Defined by relationship Orion.AssetInventory.NodesAIUSBController (System.Reference) |
| NetworkInterface | [Orion.AssetInventory.NetworkInterface](./../Orion.AssetInventory/NetworkInterface) | Defined by relationship Orion.AssetInventory.NodesAINetworkInterface (System.Reference) |
| VideoCard | [Orion.AssetInventory.VideoCard](./../Orion.AssetInventory/VideoCard) | Defined by relationship Orion.AssetInventory.NodesAIVideoCard (System.Reference) |
| SoundCard | [Orion.AssetInventory.SoundCard](./../Orion.AssetInventory/SoundCard) | Defined by relationship Orion.AssetInventory.NodesAISoundCard (System.Reference) |
| Monitor | [Orion.AssetInventory.Monitor](./../Orion.AssetInventory/Monitor) | Defined by relationship Orion.AssetInventory.NodesAIMonitor (System.Reference) |
| Peripherals | [Orion.AssetInventory.Peripherals](./../Orion.AssetInventory/Peripherals) | Defined by relationship Orion.AssetInventory.NodesAIPeripherals (System.Reference) |
| RemovableMedia | [Orion.AssetInventory.RemovableMedia](./../Orion.AssetInventory/RemovableMedia) | Defined by relationship Orion.AssetInventory.NodesAIRemovableMedia (System.Reference) |
| Firmware | [Orion.AssetInventory.Firmware](./../Orion.AssetInventory/Firmware) | Defined by relationship Orion.AssetInventory.NodesAIFirmware (System.Reference) |
| StorageController | [Orion.AssetInventory.StorageController](./../Orion.AssetInventory/StorageController) | Defined by relationship Orion.AssetInventory.NodesAIStorageController (System.Reference) |
| OutOfBandManagement | [Orion.AssetInventory.OutOfBandManagement](./../Orion.AssetInventory/OutOfBandManagement) | Defined by relationship Orion.AssetInventory.NodesAIOutOfBandManagement (System.Reference) |
| OSUpdates | [Orion.AssetInventory.OSUpdates](./../Orion.AssetInventory/OSUpdates) | Defined by relationship Orion.AssetInventory.NodesAIOSUpdates (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.AssetInventory.NodesAIPolling (System.Reference) |

## Verbs

### PollNow

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### EnablePollingForNodes

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### DisablePollingForNodes

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

