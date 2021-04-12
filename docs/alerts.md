---
title: Alerts
---

## Alert Entities

Orion Alerts are reported by a collection of related SWIS entities.
All of these are new in Orion Platform 2015.1, which is the basis of NPM 11.5, SAM 6.2, and other early 2015 releases, except for Orion.AlertSuppression which was introduced in Orion Platform 2017.1 (NPM 12.1, SAM 6.4 and other early 2017 releases).

### Orion.AlertActive

Each instance of `Orion.AlertActive` represents one active alert.
One alert configuration may be active on many objects at once; each of these objects would be tracked by its own instance of `Orion.AlertActive`.
When the alert resets or is cleared, the instance of `Orion.AlertActive` is removed.
If you need information about alerts after they have cleared, try `Orion.AlertHistory`.
Notable properties include:

* `AlertActiveID` - Primary key for this instance of an active alert.
* `AlertObjectID` - Foreign key to `Orion.AlertObjects`, which has more details about the object that triggered the alert.
* `Acknowledged`, `AcknowledgedBy`, `AcknowledgedDateTime` - Details about the acknowledgement of this alert.

For additional details about the object that triggered the alert, join to `Orion.AlertObjects` on `AlertObjectID` or use the `AlertObjects` navigation property on `Orion.AlertActive`.

(The `AcknowledgedNote` is not currently used.)

#### Verb: Acknowledge

```csharp
bool Acknowledge(int[] alertObjectIds, string note)
```

To acknowledge alerts, pass the AlertObjectID values and a note to `Orion.AlertActive.Acknowledge`.
It will return success or failure as a boolean.

#### Verb: AppendNote

```csharp
bool AppendNote(int[] alertObjectIds, string note)
```

To append a note without acknowledging the alert, pass the AlertObjectID values and a note to `Orion.AlertActive.AppendNote`.
It will return success or failure as a boolean.

#### Verb: Unacknowledge

```csharp
bool Unacknowledge(int[] alertObjectIds)
```

To clear the acknowledgement of alerts, pass their AlertObjectID values to `Orion.AlertActive.Unacknowledge`.
The alerts will no longer be acknowledged.
It will return success or failure as a boolean.

#### Verb: ClearAlert

```csharp
bool ClearAlert(int[] alertObjectIds)
```

To clear an active alert manually, pass the AlertObjectID values to `Orion.AlertActive.ClearAlert`.
It will return success or failure as a boolean.
This will clear the alerts without running the normal Reset actions and without regards to the state of the trigger condition for that alert.
If the condition that triggered the alert still holds, the alert will be triggered again the next time the condition is evaluated.

### Orion.AlertObjects

Instances of `Orion.AlertObjects` exist to hold additional details about objects that have ever triggered alerts.
There will be one instance of `Orion.AlertObjects` for each pair of (alert configuration, object) that has triggered.
These instances don't go away when that pair resets.
The recommended way to access this entity is to query `Orion.AlertActive` and join to `Orion.AlertObjects`.
Notable properties:

* `AlertID` - foreign key to `Orion.AlertConfigurations`
* `AlertObjectID` - primary key for this instance
* `EntityType` - type of the object that triggered this alert
* `EntityUri` - Uri for the object that triggered this alert
* `EntityCaption` - The display name for the triggering object
* `EntityDetailsUrl` - relative URL for the details view for the triggering object.
Combine this with the http\[s]://\[servername] to produce an absolute URL.
You can query `Orion.Websites` to get the protocol and server name instead of hard-coding it.
* `RelatedNodeUri`, `RelatedNodeCaption`, `RelatedNodeDetailsUrl` - For objects that are related to nodes (such as interfaces, applications, and volumes), these properties give details about the associated node.
Not all object types are related to nodes, so these property may be empty.

For global alert configurations that examine the state of the whole monitored environment, `EntityUri`, `EntityDetailsUrl`, and the `RelatedNode...` properties will be blank; `EntityCaption` will be something like "38 interfaces" rather than being the name of a specific object.
For these types of alerts, the details of what objects triggered the alert together can be found in `Orion.AlertActiveObject` instead.

### Orion.AlertActiveObjects

This entity is used for tracking cumulative alerts.
A cumulative alert is an alert whose condition spans multiple objects, such as "at least 5 nodes have high CPU" or "Both Web Server 1 and Web Server 2 are down".

You can get more information about cumulative alerts and how to set up them here from the KB article [Wait for multiple objects to meet the trigger condition](http://www.solarwinds.com/documentation/en/flarehelp/orionplatform/content/core-waiting-for-multiple-objects-to-meet-the-trigger-condition-sw983.htm?CMPSource=THW&CMP=DIRECT).

When a cumulative alert exists then active objects related to this alert are stored in `Orion.AlertActiveObjects` and each instance tracks one of the objects that contributed to triggering the cumulative alert.
The `Orion.AlertActiveObjects` entity is used only for cumulative alert resolution and otherwise is empty.

Important properties:

* `AlertActiveID` - The active alert instance that this object contributes to triggering
* `EntityUri` - The SWIS Uri for the object that contributed to triggering the alert
* `EntityType` - The SWIS entity type of the triggering object
* `EntityCaption` - The display name for the triggering object
* `EntityDetailsUrl` - relative URL for the details view for the triggering object.
Combine this with the http\[s]://\[servername] to produce an absolute URL.
You can query `Orion.Websites` to get the protocol and server name instead of hard-coding it.
* `RelatedNodeUri`, `RelatedNodeCaption`, `RelatedNodeDetailsUrl` - For objects that are related to nodes (such as interfaces, applications, and volumes), these properties give details about the associated node.
Not all object types are related to nodes, so these property may be empty.

### Orion.AlertHistory

This is a log of important events related to alerts.
Records are not removed when an alert resets.
Notable properties are:

* `AlertHistoryID` - primary key for this history record.
This is just a counter.
* `EventType` - an enumerated value denoting what type of event this history record represents.
The possible values are:
  * 0 - The alert was triggered
  * 1 - The alert was reset
  * 2 - The alert was acknowledged
  * 3 - A note was appended to the alert record.
  * 4 - Added to incident. Not currently used.
  * 5 - Action failed.
  There was an error performing an alert action (such as failure to send an email).
  * 6 - Action succeeded. An action was performed successfully.
  * 7 - Unacknowledge. The acknowledge state was cleared.
  * 8 - Cleared. The alert was explicitly cleared.
* `Message` - Varies by type of event.
For notes (type 2 and 3), this will be the text of the note.
* `Timestamp` - when the event occurred
* `AccountID` - the responsible user, if any. For actions of the system, this will be blank.
* `AlertActiveID` - a reference to the `Orion.AlertActive` instance this event relates to.
* `AlertObjectID` - a reference to the `Orion.AlertObject` instance this event relates to.
* `ActionID` - a reference to the `Orion.Actions` instance this event relates to.

### Orion.AlertConfigurations

Each instance of `Orion.AlertConfigurations` represents one alert definition.
Notable properties include:

* `AlertID` - the primary key for the alert.
This appears in some related entities.
* `Name` - the name of the alert
* `Enabled` - true if this alert is currently being evaluated
* `Severity` - one of the following values:
  * 0 - Information
  * 1 - Warning
  * 2 - Critical
  * 3 - Serious
  * 4 - Notice

#### Verb: Export

```csharp
string Export(int alertId)
```

This verb can be used to export an alert for the purpose of backup, transfer to another Orion system, or programmatic modification.
The returned string is in XML format.

#### Verb: Import

```csharp
class AlertImportResult
{
    int? AlertId;
    string Name;
    string MigrationMessage;
}

AlertImportResult Import(string alertXml)
```

This verb can be used to import an alert definition.
The format for the `alertXml` parameter is the same as the string returned by the `Export` verb.
It is also the file format used when you export an alert definition from the alert management UI.

#### PowerShell and alert export/import

A logical thing to do when exporting an alert is to write it to a file.
If you are using the [PowerShell](./powershell) cmdlets for SWIS there are a few pitfalls to avoid.
`Invoke-SwisVerb` returns an XML element, so you need to access the `InnerText` property to get just a plain string, like this:

```powershell
$swis = Connect-Swis -Hostname myorion -Username me -Password swordfish
$ExportedAlert = Invoke-SwisVerb $swis Orion.AlertConfigurations Export @(42)
Set-Content MeaningOfLifeAlert.xml $ExportedAlert.InnerText
```

To read that file back as a string, you would expect to use `Get-Content`, but beware: the default behavior of `Get-Content` is to split the file into an array of lines.
To get the whole file as a single string, add the `-Raw` switch, like this:

```powershell
$AlertXml = Get-Content MeaningOfLifeAlert.xml -Raw
Invoke-SwisVerb $swis Orion.AlertConfigurations Import @($AlertXml)
```

### Orion.AlertSuppression

Each instance of `Orion.AlertSuppression` represents one scheduled occurence of muting alerts for one entity.
This is different from unmanaging the entity—unmanaging an entity sets the entities status to "Unmanaged" and pauses statistics collection for that entity; muting alerts merely causes alerts to not trigger.

The properties of `Orion.AlertSuppression` are:

* `ID` - unique identifier for this `Orion.AlertSuppression` record
* `EntityUri` - the Uri of the entity to suppress alerts for.
Children of this entity will also have alerts suppressed.
* `SuppressFrom` - date/time to start suppressing alerts
* `SuppressUntil` - date/time to stop suppression alerts.
If this is `NULL`, then alerts will be suppressed until alerts are explicitly resumed.

#### Verb: GetAlertSuppressionState

```csharp
EntityAlertSuppressionState[] GetAlertSuppressionState(string[] entityUris);

class EntityAlertSuppressionState
{
    // The URI of entity which is this state about
    string EntityUri { get; set; }

    // URI of parent which suppress the entity, can be null.
    string SuppressedParentUri { get; set; }

    // Mode of the suppression
    EntityAlertSuppressionMode SuppressionMode { get; set; }

    // Datetime of suppression start
    DateTime? SuppressedFrom { get; set; }

    // Datetime of suppression end, can be null for infinite suppression
    DateTime? SuppressedUntil { get; set; }
}

enum EntityAlertSuppressionMode
{
    NotSuppressed = 0,
    SuppressedByItself = 1,
    SuppressedByParent = 2,
    SuppressionScheduledForItself = 3,
    SuppressionScheduledForParent = 4
}
```

`GetAlertSuppressionState` can be used to verify the current alert suppression state of an entity, taking into account possible alert suppression inherited from a parent entity and alert suppression that may be scheduled in the future.

#### Verb: SuppressAlerts

```csharp
void SuppressAlerts(string[] entityUris, DateTime? suppressFrom = null, DateTime? suppressUntil = null);
```

`SuppressAlerts` creates alert suppression records for the specified entity Uris.
The `suppressFrom` parameter is optional; if omitted, "now" will be used.
The `suppressUntil` parameter is also optional; if omitted, "forever" will be used (the alert suppression must be ended manually in this case.)

#### Verb: ResumeAlerts

```csharp
void ResumeAlerts(string[] entityUris)
```

`ResumeAlerts` ends alert suppression for the specified Uris.

_PowerShell note_: `Invoke-SwisVerb` needs an array of the argument values.
When there is only one argument and that argument itself is an array, as in `ResumeAlerts`, it is easy to hit a PowerShell pitfall where you think you are making an array containing one array of strings, but you actually just create an array of strings.
Also, you may have values of type `PSObject` that look like strings when you need actual strings.
To work around this, prefix a comma and explicitly cast the argument to type `string[]`.
Like this:

```powershell
Invoke-SwisVerb -SwisConnection $swis -EntityName Orion.AlertSuppression -Verb ResumeAlerts `
    -Arguments @( , [string[]] $uris )
```
