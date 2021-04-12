---
title: Managing Custom Properties
---

## Creating Custom Properties

To create a custom property for nodes, call the `Orion.NodesCustomProperties.CreateCustomProperty` verb.
It has these parameters:

1. `PropertyName` - the name of the property.
2. `Description` - a description of the property to be shown in editing UI.
3. `ValueType` - the data type for the custom property. The following types are allowed: `string`, `integer`, `datetime`, `single`, `double`, `boolean`.
4. `Size` - for string types, this is the maximum length of the values, in characters. Ignored for other types.
5. `ValidRange` - unused, pass null.
6. `Parser` - unused, pass null.
7. `Header` - unused, pass null.
8. `Alignment` - unused, pass null.
9. `Format` - unused, pass null.
10. `Units` - unused, pass null.
11. `Usages` - optional. You can pass null for this.
12. `Mandatory` - optional. Defaults to false. If set to true, the Add Node wizard in the Orion web console will require that a value for this custom property be specified at node creation time.
13. `Default` - optional. You can pass null for this. If you provide a value, this will be the default value for new nodes.

PowerShell example:

```powershell
$swis = Connect-Swis -Hostname localhost -Username admin -Password ""
Invoke-SwisVerb $swis Orion.NodesCustomProperties CreateCustomProperty @("Test1", "this is my description", "string", 4000, $null, $null, $null, $null, $null, $null)
```

To restrict a custom property to a certain set of values, call the `CreateCustomPropertyWithValues` verb instead.
This verb has the same parameters as `CreateCustomProperty`, but with an extra parameter `Values` between `Units` and `Usages`.
This parameter has type `string[]`.
You can do that in PowerShell like this:

```powershell
$swis = Connect-Swis -Hostname localhost -Username admin -Password ""
$values = New-Object string[] 3
$values[0] = "value1"
$values[1] = "value2"
$values[2] = "value3"
Invoke-SwisVerb $swis Orion.NodesCustomProperties CreateCustomPropertyWithValues @("Test2", "this one has a value list", "string", 4000, $null, $null, $null, $null, $null, $null, $values)
```

## Modifying Custom Properties

To modify a custom property for nodes, call the `Orion.NodesCustomProperties.ModifyCustomProperty` verb. It has these parameters:

1. `PropertyName` - name of the property to modify.
2. `Description` - a description of the property to be shown in editing UI.
3. `Size` - for string types, this is the maximum length of the values, in characters. Ignored for other types.
4. `Values` - a list (in `string[]` format) of allowed values for this property. An empty or `null` list has the effect of allowing any value.
5. `Usages` - optional. Defaults to not changing the allowed usages of the existing property.
6. `Mandatory` - optional. Defaults to `false`. If set to `true`, the Add Node wizard in the Orion web console will require that a value for this custom property be specified at node creation time.
7. `Default` - optional. Defaults to `null`. If you provide a value, this will be the default value for new nodes.

To add a value to the `Values` list for a property, you need to first query for the existing value list (`SELECT Value FROM Orion.CustomPropertyValues WHERE Table='NodesCustomProperties' AND Field='your-property-name'`), add the new value to that list, and then call `Orion.NodesCustomProperties.ModifyCustomProperty`. Like this:

```powershell
$swis = Connect-Swis -Hostname localhost -Username admin -Password ''
$propertyName = 'FavoriteColor'
$existingProperty = Get-SwisData $swis "SELECT Description, MaxLength FROM Orion.CustomProperty WHERE Table='NodesCustomProperties' AND Field=@property'" @{property=$propertyName}
$values = Get-SwisData $swis "SELECT Value FROM Orion.CustomPropertyValues WHERE Table='NodesCustomProperties' AND Field=@property" @{property=$propertyName}
$values += 'Purple'
Invoke-SwisVerb $swis Orion.NodesCustomProperties ModifyCustomProperty @($propertyName, $existingProperty.Description, $existingProperty.MaxLength, [string[]]$values)
```
