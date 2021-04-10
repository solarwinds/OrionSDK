---
title: Using the SolarWinds Information Service from PowerShell
---

SolarWinds provides a Windows PowerShell module called [SwisPowerShell](https://www.powershellgallery.com/packages/SwisPowerShell) for working with the SolarWinds Information Service.
To install this module from the PowerShell Gallery, use `Install-Module -Name SwisPowerShell`.
You'll need to be running PowerShell as an administrator.

## Using SwisPowerShell

After installing `SwisPowerShell`, use the following steps to run a query from PowerShell:

1. Start Windows PowerShell.
2. Run the command, `Import-Module SwisPowerShell` to load `SwisPowerShell` into the current PowerShell runspace.
3. Run the command, `$swis = Connect-Swis`, and then provide your Orion credentials.
4. Run the command, `Get-SwisData $swis 'SELECT NodeID, Caption FROM Orion.Nodes'`. SWIS returns the results in PowerShell.

In PowerShell terms, the results from Step 4 are returned as a set of objects with two properties: `NodeID` and `Caption` so you can manipulate them using the standard PowerShell syntax and commands.
For example, use `Get-SwisData $swis 'SELECT NodeID, Caption FROM Orion.Nodes' | Export-Csv nodes.csv` to create a CSV file from the query results.

## Cmdlets Provided by SwisPowerShell

SwisPowerShell provides the following PowerShell cmdlets.

### Connect-Swis

Arguments:

* Hostname (optional, defaults to `localhost`)
* V2 (optional, opens a connection to SWISv2 instead of default SWISv3)
* An authentication option. One of:
  * Credential (a PSCredential object, see [Get-Credential](https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.security/get-credential?view=powershell-6) for details)
  * Username and Password (strings)
  * Trusted (uses the current Windows token for authentication)
  * Certificate (uses the local Orion server certificate.
  This will only work when running `SwisPowerShell` on an Orion server)

This returns a SWIS connection object. For example:

```powershell
$creds = Get-Credential  # display a window asking for credentials
$swis = Connect-Swis -Credential $creds -Hostname localhost  # create a SWIS connection object
```

#### Connecting to the Legacy Virtualization Manager appliance

Installations utilizing the legacy SolarWinds Virtualization Manager appliance also support SWIS.
You can connect to the appliance using `Connect-Swis`, but the options needed are different. Use this command line:

```powershell
$hostname = 'vmanserver'
$username = 'guest'
$password = 'guest'
$vmanswis = Connect-Swis -Soap12 https://$hostname/swvm/services/InformationService -UserName $username -Password $password -IgnoreSslErrors
```

This `$vmanswis` connection object can be used with the other PowerShell cmdlets.

### Get-SwisData

Takes three arguments:

* SwisConnection (mandatory)
* Query (mandatory)
* Parameters (optional)

This returns a set of PowerShell objects representing the query results.
The Parameters argument can be used to supply the values of query parameters. For example:

```powershell
Get-SwisData -SwisConnection $swis -Query 'SELECT NodeID, Caption FROM Orion.Nodes WHERE Vendor= @v' -Parameters @{ v = 'Cisco' }
```

You can omit the names of the switches for a shorter command line:

```powershell
Get-SwisData $swis 'SELECT NodeID, Caption FROM Orion.Nodes WHERE Vendor= @v' @{ v = 'Cisco' }
```

When building a PowerShell script that runs SWIS queries, it can be helpful to supply the values of filters and other things using query parameters, as this avoids the need to deal with encoding embedded quote characters and other syntactical issues.

### Invoke-SwisVerb

Takes four arguments, all mandatory:

* SwisConnection
* EntityName
* Verb
* Arguments

For example:

```powershell
$now=[DateTime]::UtcNow
$later=$now.AddDays(1)
Invoke-SwisVerb $swis Orion.Nodes Unmanage @("N:1", $now, $later, "false")
```

Returns an XmlElement object representing the complete response from the verb.

### New-SwisObject

Invokes the Create operation from the CRUD Operations interface and takes three arguments:

* SwisConnection (mandatory)
* EntityType (mandatory)
* Properties (mandatory)

EntityType indicates the entity type to be created.
The Properties argument accepts a hash table object containing property/value pairs with which to initialize the new entity’s properties.
This returns a URI string for an entity that has been newly created and can be used as the URI argument of the other CRUD operations.
For example:

```powershell
New-SwisObject $swis -EntityType 'Orion.Pollers' -Properties @{ PollerType = 'N.Details.SNMP.Generic'; NetObject = 'N:1'; NetObjectType = 'N'; NetObjectID = 1 }
```

### Get-SwisObject

Invokes the Read operation from the CRUD Operations interface and takes two arguments:

* SwisConnection (mandatory)
* Uri (mandatory)

Uri identifies the entity of which you want to read the properties.
This returns a hash table object containing property/value pairs corresponding to the current state of the entity property values.
For example:

```powershell
Get-SwisObject $swis -Uri 'swis://localhost/Orion/Orion.Nodes/NodeID=1/CustomProperties'
```

Note: The Read operation provides an alternative to the query operation.

### Set-SwisObject

Invokes the Update operation of the CRUD Operations interface and takes three arguments:

* SwisConnection (mandatory)
* Uri (mandatory, but can be provided from the pipeline)
* Properties (mandatory)

Uri identifies the entity you are about to change.
The Properties argument accepts a hash table object containing property/value pairs to set in the entity.
For example:

```powershell
Set-SwisObject $swis -Uri 'swis://localhost/Orion/Orion.Nodes/NodeID=1' -Properties @{ Caption = 'New Name' }
```

To set properties to the same values on multiple objects at the same time, omit the Uri argument and instead, pass the Uri for each entity you want to modify through the PowerShell pipeline.
These Uri values can come from a Get-SwisData query or just a list of strings:

```powershell
# Example passing a list of strings
$uris = @('swis://localhost/Orion/Orion.Nodes/NodeID=3', 'swis://localhost/Orion/Orion.Nodes/NodeID=5', 'swis://localhost/Orion/Orion.Nodes/NodeID=7')
$uris | Set-SwisObject $swis -Properties @{PollInterval=300}

# Example passing Uris from a query
Get-SwisData $swis 'SELECT Uri FROM Orion.Nodes WHERE PollInterval=300' | Set-SwisObject $swis -Properties @{ PollInterval = 120 }
```

### Remove-SwisObject

Invokes the Delete operation of the CRUD Operations interface and takes two arguments:

* SwisConnection (mandatory)
* Uri (mandatory, but can be provided from the pipeline)

Uri identifies an entity to remove.
For example:

```powershell
Remove-SwisObject $swis -Uri 'swis://localhost/Orion/Orion.Pollers/PollerID=1'
```

Remove-SwisObject also supports deleting multiple objects in one operation by omitting the Uri argument and passing the Uri values through the PowerShell pipeline.
See Set-SwisObject for some examples of how to do this.

## Migrating from SwisSnapin

Previously, the recommended way to access SWIS from PowerShell was to use a PowerShell snapin called `SwisSnapin`.
PowerShell modules have replaced snapins as the recommended way to extend PowerShell, so the `SwisPowerShell` module replaces the older `SwisSnapin`.
The Orion SDK installer still include `SwisSnapin`, so your existing scripts that use it will still work.

The cmdlets provided by the `SwisPowerShell` module and `SwisSnapin` are the same (literally—it is the same code).
To convert scripts written for `SwisSnapin` to use `SwisPowerShell` instead, the only change required is to replace the `Add-PSSnapin SwisSnapin` line with `Import-Module SwisPowerShell` instead.

It is not a problem to have both `SwisPowerShell` and `SwisSnapin` installed.
