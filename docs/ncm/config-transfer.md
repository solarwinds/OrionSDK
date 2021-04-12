---
title: NCM Config Transfer
---

Network Configuration Manager 7.4 (released in 2015) introduced a new API for managing configuration transfer operations, including downloading device configs, uploading device configs, and executing scripts on devices.
This API consists of a set of verbs on the existing `Cirrus.ConfigArchive` entity type and a new `NCM.TransferResults` entity type you can query to check on the status of config transfer operations.

## Cirrus.ConfigArchive

### Verb: DownloadConfig

Download configs for multiple devices and store them in NCM database.

```csharp
Guid[] DownloadConfig(Guid[] nodeId, string configType)
```

* `nodeId` - list of NCM node Ids to download configs from
* `ConfigType` - Config Type to download

Returns a list of TransferID values, one per specified node.
Query `NCM.TransferResults` with these TransferID values to track the status of the operations.

### Verb: UploadConfig

Upload config changes for multiple devices.

```csharp
Guid[] UploadConfig(Guid[] nodeId, string configType, string ConfigText, bool RebootDevice)
```

* `nodeId` - list of NCM node Ids to upload config changes to
* `ConfigType` - Config Type to upload
* `ConfigText` - config text to upload
* `RebootDevice` - `true` to reboot the device after uploading the new config

Returns a list of TransferID values, one per specified node.
Query `NCM.TransferResults` with these TransferID values to track the status of the operations.

### Verb: ExecuteScript

Execute script on multiple devices

```csharp
Guid[] ExecuteScript(Guid[] nodeId, string script)
```

Run a script (specified as a string in the `script` parameter) on each of the nodes (specified by NCM NodeID GUID in the `nodeId` parameter).
Returns a list of TransferID values, one per specified node.
Query `NCM.TransferResults` with these TransferID values to track the status of the operations.

### Verb: ClearTransfers

```csharp
void ClearTransfers(Guid[] TransferTickets)
```

Remove the history record from `NCM.TransferResults` for the transfers with the TransferID values specified in `TransferTickets`.
No return value.

### Verb: CancelTransfers

```csharp
void CancelTransfers(Guid[] TransferTickets)
```

Cancel any ongoing or queued transfers with the TransferID values specified in `TransferTickets`.
No return value.

## NCM.TransferResults

Query `NCM.TransferResults` to see the status of queued and completed config transfer operations.

* `TransferID` - unique ID of transfer ticket returned to client by one of transfer verbs
* `NodeId` - NCM Node Id from `NCM.NodeProperties` entity
* `Action` - enum type of transfer: Download = 1, Upload = 2, Execute Script = 3 
* `RequestedConfigType` - originally requested type of config to perform transfer. Value is `NULL` for execute script action 
* `RequestedScript` - Original script requested to execute on device. Value is NULL for download config action 
* `RequestedReboot` - flag indicating if reboot was requested. Value is populated only for upload config action
* `ConfigID` - ID of newly downloaded by this transfer config in `Cirrus.ConfigArchive` table. Value if populated only for Config Download action
* `TransferProtocol` - textual description of protocols combination used to perform transfer (for example Telnet - TFTP)
* `Status` - enum status of transfer: Queued = 0 - means transfer is waiting for execution in queue, Transferring = 1 - means transfer is executing right now, Complete = 2, Error = 3
* `ErrorMessage` - transfer error message. Value is populating only in case Status is equal to Error
* `DeviceOutput` - store script execution results. Value is empty for download config action
* `DateTime` - time when transfer was requested
* `UserName` - name of user who requested transfer
