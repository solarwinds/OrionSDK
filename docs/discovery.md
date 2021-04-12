---
title: Discovery
---

Orion's Network Sonar Discovery feature can be scripted to discover and add nodes.
Using the Discovery API involves a few phases:

1. Constructing the discovery context
2. Running the discovery
3. Tracking the progress of the discovery job
4. Examining the results of the discovery

These phases will be described here.
Code samples will be in PowerShell, though like all Orion APIs this can also be done using HTTP calls from any language.
When working in PowerShell, some objects will be expressed in XML.
When using other languages accessing the [REST](./rest) API, JSON would be used instead.

## Building a discovery context

A discovery context is a document that describes the scope of the discovery, various options for controlling what gets discovered and how, and the credentials used for the discovery.
A discovery context consists of a set of plugin configuration items and a few top-level values.
Plugin configuration items are created using verb calls that produce a string that you then embed in the complete discovery context.

### Core Plugin Configuration

To create the Core plugin configuration, call the `Orion.Discovery.CreateCorePluginConfiguration` verb with one argument, a `CorePluginConfigurationContext`.
In PowerShell, that code looks like this:

```powershell
$CorePluginConfigurationContext = ([xml]"
<CorePluginConfigurationContext xmlns='http://schemas.solarwinds.com/2012/Orion/Core' xmlns:i='http://www.w3.org/2001/XMLSchema-instance'>
    <BulkList>
        <IpAddress>
            <Address>10.199.2.5</Address>
        </IpAddress>
    </BulkList>
    <IpRanges>
        <IpAddressRange>
            <StartAddress>10.199.3.10</StartAddress>
            <EndAddress>10.199.3.15</EndAddress>
        </IpAddressRange>
    </IpRanges>
    <Subnets>
        <AddressSubnet>
            <SubnetIP>10.199.5.0</SubnetIP>
            <SubnetMask>255.255.255.0</SubnetMask>
        </AddressSubnet>
    </Subnets>
    <Credentials>
        <SharedCredentialInfo>
            <CredentialID>$credentialid1</CredentialID>
            <Order>1</Order>
        </SharedCredentialInfo>
        <SharedCredentialInfo>
            <CredentialID>$credentialid2</CredentialID>
            <Order>2</Order>
        </SharedCredentialInfo>
    </Credentials>
    <WmiRetriesCount>1</WmiRetriesCount>
    <WmiRetryIntervalMiliseconds>1000</WmiRetryIntervalMiliseconds>
</CorePluginConfigurationContext>
").DocumentElement

$CorePluginConfiguration = Invoke-SwisVerb $swis Orion.Discovery CreateCorePluginConfiguration @($CorePluginConfigurationContext)
```

There are three ways to specify what IP addresses to discover: individual IP addresses (`<BulkList>`), ranges of IP addresses (`<IpRanges>`), and subnets (`<Subnets>`).
Each of these is optional, though you need to include at least one of them or there will be nothing to discover.

The `<BulkList>` element can contain multiple `<IpAddress>` elements, though each one of those can only have one `<Address>` element.

The `<IpRanges>` element can contain multiple `<IpAddressRange>` elements.
A range can span subnets.

The `<Subnets>` element can contain multiple `<AddressSubnet>` elements.
The size of the subnet is specified using subnet mask syntax, not CIDR.
So a /24 (class C) subnet would be 255.255.255.0, a /16 (class B) subnet would be 255.255.0.0, and so on.
Scanning a /8 (class A) subnet is not recommended for performance reasons.

The `<Credentials>` element can contain multiple `<SharedCredentialInfo>` elements.
Each one must have a `<CredentialID>` value.
The credential IDs are integers that can be found by querying the `Orion.Credential` entity.
There is simple API for adding credentials ([Credential management](./credential-management)), changing or removing credentials is currently not supported in API.
Adding, changing, or removing credentials can be done also in UI manually.
The `<Order>` element in a `<SharedCredentialInfo>` indicates the order that credentials will be tested against each discovered node, in ascending order.
The `<Order>` values do not need to be consecutive, but there must be no duplicates.

### Interfaces Plugin Configuration

To control how network interfaces are discovered, create an interfaces plugin configuration item and include it in the discovery context.
The interfaces plugin configuration item is created by the `Orion.NPM.Interfaces.CreateInterfacesPluginConfiguration` verb.
In PowerShell, that code looks like this:

```powershell
$InterfacesPluginConfigurationContext = ([xml]"
<InterfacesDiscoveryPluginContext xmlns='http://schemas.solarwinds.com/2008/Interfaces' 
                                  xmlns:a='http://schemas.microsoft.com/2003/10/Serialization/Arrays'>
    <AutoImportStatus>
        <a:string>Up</a:string>
        <a:string>Down</a:string>
        <a:string>Shutdown</a:string>
    </AutoImportStatus>
    <AutoImportVirtualTypes>
        <a:string>Virtual</a:string>
        <a:string>Physical</a:string>
    </AutoImportVirtualTypes>
    <AutoImportVlanPortTypes>
        <a:string>Trunk</a:string>
        <a:string>Access</a:string>
        <a:string>Unknown</a:string>
    </AutoImportVlanPortTypes>
    <UseDefaults>false</UseDefaults>
</InterfacesDiscoveryPluginContext>
").DocumentElement

$InterfacesPluginConfiguration = Invoke-SwisVerb $swis Orion.NPM.Interfaces CreateInterfacesPluginConfiguration @($InterfacesPluginConfigurationContext)
```

This sample includes all available values for the `AutoImportStatus`, `AutoImportVirtualTypes`, and `AutoImportVlanPortTypes`.
Just remove the ones that describe interfaces you _don't_ want to monitor.

The `UseDefaults` option, if set to `true`, will override all the other interface filter options and just use the defaults.
The default behavior is to import all "Up" (active) interfaces regardless of type.

### Building the discovery context from the plugin configurations

Once the plugin configuration items have been created, the next step is to combine them, along with some other important discovery parameters, into the discovery context.
The plugin configuration items are XML and you must embed them into the discovery context _as strings_.
And when you are embedding XML into other XML as a string, that means the inner XML must be quoted (`<` changed to `&lt;`, `&` changed to `&amp;`, and so on).
PowerShell makes this pretty straightforward.

```powershell
$EngineID = 1
$DeleteProfileAfterDiscoveryCompletes = "true"

$StartDiscoveryContext = ([xml]"
<StartDiscoveryContext xmlns='http://schemas.solarwinds.com/2012/Orion/Core' xmlns:i='http://www.w3.org/2001/XMLSchema-instance'>
    <Name>Script Discovery $([DateTime]::Now)</Name>
    <EngineId>$EngineID</EngineId>
    <JobTimeoutSeconds>3600</JobTimeoutSeconds>
    <SearchTimeoutMiliseconds>2000</SearchTimeoutMiliseconds>
    <SnmpTimeoutMiliseconds>2000</SnmpTimeoutMiliseconds>
    <SnmpRetries>1</SnmpRetries>
    <RepeatIntervalMiliseconds>1500</RepeatIntervalMiliseconds>
    <SnmpPort>161</SnmpPort>
    <HopCount>0</HopCount>
    <PreferredSnmpVersion>SNMP2c</PreferredSnmpVersion>
    <DisableIcmp>false</DisableIcmp>
    <AllowDuplicateNodes>false</AllowDuplicateNodes>
    <IsAutoImport>true</IsAutoImport>
    <IsHidden>$DeleteProfileAfterDiscoveryCompletes</IsHidden>
    <PluginConfigurations>
        <PluginConfiguration>
            <PluginConfigurationItem>$($CorePluginConfiguration.InnerXml)</PluginConfigurationItem>
            <PluginConfigurationItem>$($InterfacesPluginConfiguration.InnerXml)</PluginConfigurationItem>
        </PluginConfiguration>
    </PluginConfigurations>
</StartDiscoveryContext>
").DocumentElement
```

Discovery jobs run on a single polling engine specified in this context.
The Name is just for display purposes.

If you set `IsAutoImport` to `false`, then the discovered nodes will not be added automatically.
In that case, you can see the discovered nodes in the Network Sonar section of the Orion website and import some, all, or none of them as you choose.

Set the `IsHidden` option to `true` to cause the discovery profile to be removed after the discovery completes.
Leave it `false` for the discovery profile to stick around, which would allow you to run it again in the future from the Orion website.

## Running the discovery

Once the discovery context is prepared, starting the discovery is fairly simple:

```powershell
$DiscoveryProfileID = (Invoke-SwisVerb $swis Orion.Discovery StartDiscovery @($StartDiscoveryContext)).InnerText
```

The discovery profile ID is an integer that comes back wrapped in an XML element.
We can use `.InnerText` to extract it.

## Tracking the progress of the discovery job

Now that we have a discovery profile ID, we can query the `Orion.DiscoveryProfiles` entity to see when it finishes:

```powershell
do {
    Start-Sleep -Seconds 1
    $Status = Get-SwisData $swis "SELECT Status FROM Orion.DiscoveryProfiles WHERE ProfileID = @profileId" @{profileId = $DiscoveryProfileID}
} while ($Status -eq 1)
```

## Examining the results of the discovery

At this point the discovery job has finished.
The `Orion.DiscoveryLogs` and `Orion.DiscoveryLogItems` entities have the details.
First, query `Orion.DiscoveryLogs` to see what the outcome was:

```powershell
$Result = Get-SwisData $swis "SELECT Result, ResultDescription, ErrorMessage, BatchID FROM Orion.DiscoveryLogs WHERE ProfileID = @profileId" @{profileId = $DiscoveryProfileID}
```

`Result` has these meanings:

| Value | Description |
| ----: | ----------- |
| 0 | Unknown - something strange happened |
| 1 | In progress - the discovery is still running |
| 2 | Finished - completed successfully |
| 3 | Error - the discovery was aborted with an error |
| 4 | Not scheduled - a discovery profile that has not run and is not scheduled to run |
| 5 | Scheduled - this discovery profile has not run yet, but will in the future |
| 6 | Not completed - this discovery profile was canceled |
| 7 | Canceling - cancelation was requested but not yet processed |
| 8 | Ready for import - discovery completed, but without auto-import; go to the website to import nodes |

If the discovery completed successfully (Result = 2), then the `Orion.DiscoveryLogItems` table has the list of nodes and other objects that was imported:

```powershell
Get-SwisData $swis "SELECT EntityType, DisplayName, NetObjectID FROM Orion.DiscoveryLogItems WHERE BatchID = @batchId" @{batchId = $Result.BatchID}
```

## Importing discovery results

When discovery is started with property IsAutoImport=FALSE, discovery results are not imported automatically but are stored and can be imported later.
Results can be imported when discovery is finished (see the check of discovery results above) using following script:

```powershell
$ImportConfiguration = ([xml]"
<DiscoveryImportConfiguration xmlns='http://schemas.solarwinds.com/2008/Core'>
    <DeleteProfileAfterImport>true</DeleteProfileAfterImport>
    <NodeIDs xmlns:a='http://schemas.microsoft.com/2003/10/Serialization/Arrays' />
    <ProfileID>214</ProfileID>
</DiscoveryImportConfiguration>
").DocumentElement

$id = Invoke-SwisVerb $swis Orion.Discovery ImportDiscoveryResults @($ImportConfiguration)
```

Input parameter of verb `ImportDiscoveryResults` is object with three properties:

1. ProfileID - profile ID of discovery run
1. NodeIDs - array of nodes that should be imported. Discovered nodeIDs can be resolved using query `SELECT NodeID, ProfileID FROM Orion.DiscoveredNodes WHERE ProfileID = 2  #replace with specific profileID` Providing empty array import all discovered nodes but does not import child objects (e.g. interfaces).
1. DeleteProfileAfterImport - flag to specify if profile should be deleted after import

It is currently not possible to filter node child objects (e.g. import only specific node interfaces, volumes etc.) when using IsAutoImport=FALSE and calling `ImportDiscoveryResults` later.
You can filter interfaces (but not volumes or other objects) when using IsAutoImport=TRUE - see [here](#interfaces-plugin-configuration).

Below is example how discovered nodes can be filtered before import.
Node IDs can be found in `Orion.DiscoveredNodes` entity.

```powershell
$ImportConfiguration = ([xml]"
<DiscoveryImportConfiguration xmlns='http://schemas.solarwinds.com/2008/Core'>
    <DeleteProfileAfterImport>true</DeleteProfileAfterImport>
    <NodeIDs xmlns:a='http://schemas.microsoft.com/2003/10/Serialization/Arrays' >
        <a:int>1</a:int>
    </NodeIDs>
    <ProfileID>214</ProfileID>
</DiscoveryImportConfiguration>
").DocumentElement
```

The value returned from `ImportDiscoveryResults` is a GUID for tracking the progress of the import process. You can send this value to `Orion.Discovery.GetImportDiscoveryResultsProgress` to get an object with status.

```powershell
$status Invoke-SwisVerb $swis Orion.Discovery GetImportDiscoveryResultsProgress @($id)
```

The status object has these properties:

1. Finished - boolean indicating whether the import has completed or is still running
2. OverallProgress - percent complete for the import process
3. PhaseProgress - percent complete for the current import phase
4. PhaseName - a string indicating what phase of the import is currently running
5. NewLogText - text describing what has been imported so far. In a large discovery job, this text will be capped at 128kB and subsequent calls to `GetImportDiscoveryResultsProgress` will page through the complete text
