---
title: SAM Application Monitoring Templates
---

In [Server and Application Monitor (SAM)](https://www.solarwinds.com/server-application-monitor), an application is a collection of component monitors inherited from a template when you assign the template to a node.
SAM includes over 250 out-of-the-box application monitor templates and access to a rich repository of templates shared by other SAM customers in our online IT community, [THWACK](https://thwack.solarwinds.com/community/systems-management/server-and-application-monitor-sam/content?filterID=contentstatus%5Bpublished%5D~objecttype~objecttype%5Bdocument%5D).
A template can be [customized](https://documentation.solarwinds.com/en/Success_Center/SAM/Content/SAM-Custom-Template-Guide-intro.htm), exported and imported to/from a file.
To learn more about the application/template relationship, see [Manage SAM templates and component monitors](https://documentation.solarwinds.com/en/Success_Center/SAM/Content/SAM-Using-Application-Monitor-Templates-sw1115.htm).
For details about individual templates, see the [SAM Template reference](https://documentation.solarwinds.com/en/Success_Center/SAM/Content/SAM-Template-Reference-intro.htm).

## How to list application monitoring templates

To list currently existing templates in your environment, use a `SELECT ... FROM Orion.APM.ApplicationTemplate` query.
See [Orion.APM.ApplicationTemplate Schema Reference](http://solarwinds.github.io/OrionSDK/schema/Orion.APM.ApplicationTemplate.html#properties) for all the available properties.
The following snippet generates a list of all available templates and displays them in the PowerShell console:

```powershell
$applicationTemplates = Get-SwisData -SwisConnection $swis -Query "SELECT ApplicationTemplateID, Name, Uri FROM Orion.APM.ApplicationTemplate"
$applicationTemplates | ForEach-Object { Write-Host "ID:" $_.ApplicationTemplateID; Write-Host "Name: " $_.Name; Write-Host "Uri: " $_.Uri; Write-Host }
```

## How to import an application monitoring template

The Orion SDK includes an `ImportTemplate` verb on the `Orion.APM.ApplicationTemplate` entity that you can use to automate the importing of templates into SAM.
For example, to import a template from a `MyTemplate.apm-template` file, invoke the following PowerShell code:

```powershell
# Load the template to a variable
$applicationTemplate = (Get-Content -Path ".\MyTemplate.apm-template" | Out-String)
# Import template
$result = Invoke-SwisVerb -Swis $swis Orion.APM.ApplicationTemplate ImportTemplate @($applicationTemplate)
$applicationTemplateId = $result.InnerText
Write-Host "Imported template Id: $applicationTemplateId"
```

## How to export an application monitoring template

Similarly, when you know the ID of a template, you can export it to a file.
The following code exports the template with ID 1 to `MyTemplate.apm-template`.

```powershell
$applicationTemplateId = 1
# Export the template to a variable
$result = Invoke-SwisVerb -Swis $swis Orion.APM.ApplicationTemplate ExportTemplate @($applicationTemplateId)
$exportedTemplate = $result.InnerText
# Save the template to a file
$exportedTemplate | Out-File ".\MyTemplate.apm-template"
```

## How to change the name of an application monitoring template

To change the name of a template, you need Uniform Resource Identifier (URI) of the template and the following call: `Set-SwisObject`.
The URI can be constructed as shown in the example below, or found by selecting the `Uri` column of the `ApplicationTemplate` entity (see the "How to list application monitoring templates" example above).

```powershell
$uri = "swis://$hostname/Orion/Orion.APM.ApplicationTemplate/ApplicationTemplateID=$templateId"
$properties = @{
    Name="My new template";
}
Set-SwisObject $swis -Uri $uri -Properties $properties
```

## How to delete an application monitoring template

`DeleteTemplate` verb can be used to delete a template of a given ID, as shown in this example:

```powershell
Invoke-SwisVerb -swis $swis Orion.Apm.ApplicationTemplate DeleteTemplate @($applicationTemplateId)
```

## How to list component monitors within templates

Templates are comprised of individual component monitors that pull specific data.
For example, the HTTPS Monitor template includes only one component monitor, HTTPS monitor.
The more complex AppInsight for Exchange template includes over 70 component monitors, such as Replication Status, Database Copies, Exchange Monitoring, and Active Client Logons.
Note: In the Orion SDK, entities related to component monitors have "ComponentTemplate" in their titles.
You can use the `Orion.APM.ComponentTemplate` entity to extract a list of all component monitors in a template.
(See [Orion.APM.ComponentTemplate Schema Reference](http://solarwinds.github.io/OrionSDK/schema/Orion.APM.ComponentTemplate.html#properties) for all the available properties.)
The following snippet generates a list of all component monitors in a given template.

```powershell
$componentTemplates = Get-SwisData -SwisConnection $swis -Query "SELECT ID, Name, ComponentType, IsDisabled, Uri FROM Orion.APM.ComponentTemplate WHERE ApplicationTemplateID = @applicationTemplateId" @{ applicationTemplateId = $applicationTemplateId }
$componentTemplates | ForEach-Object { Write-Host "ID:" $_.ID; Write-Host "Name: " $_.Name; Write-Host "IsDisabled: " $_.IsDisabled; Write-Host "Uri: " $_.Uri; Write-Host }
```

## How to enable or disable component monitors in templates

Similarly to how we changed the name of a template in the example above, we can change component monitor properties.
For example, to enable or disable a component, use the following code to change the `IsDisabled` property:

```powershell
$uri = "swis://$hostname/Orion/Orion.APM.ComponentTemplate/ID=$componentTemplateId"
$properties = @{
    IsDisabled="True";
}
Set-SwisObject $swis -Uri $uri -Properties $properties
```

## How to list component monitor settings

Component monitors have different settings, as represented by key-value pairs.
If you know the ID of a component monitor (its `$componentTemplateId` value), you can list the settings by running the following code:

```powershell
$componentTemplateSettings = Get-SwisData -SwisConnection $swis -Query "SELECT Key, Value, ValueType, Required, Uri FROM Orion.APM.ComponentTemplateSetting WHERE ComponentTemplateID = @componentTemplateId" @{ componentTemplateId = $componentTemplateId }
$componentTemplateSettings | ForEach-Object { Write-Host "Key:" $_.Key; Write-Host "Value: " $_.Value; Write-Host "ValueType: " $_.ValueType; Write-Host "Required: " $_.Required; Write-Host "Uri: " $_.Uri; Write-Host }
```

## How to change the settings of a component monitors

If you know the ID of a component monitor (`$componentTemplateId`) and the key of the setting (`$key`), you can set a new value (`$value`).

```powershell
$uri = "swis://$hostname/Orion/Orion.APM.ComponentTemplateSetting/ComponentTemplateID=$componentTemplateId,Key=`"$key`""
$properties = @{
    Value=$value;
}
Set-SwisObject $swis -Uri $uri -Properties $properties
```
