---
layout: default
title: "NCM Connection Profiles"
---

# Connection Profiles
The Network Configuration Manager connection profiles can be managed through the API using verbs on the `Cirrus.Nodes` entity.

## Data Model
Connection profiles data is stored in the `ConnectionProfile` data model. It contains the following properties:
```csharp
int ID  //connection profile id
string Name //connection profile name
string UserName //cli login user name
string Password //cli login password
string EnableLevel //indicate if login into enable mode is required on the device. Possible values are "<No Enable Login>" and "Enable"
string EnablePassword  //enable mode password
string ExecuteScriptProtocol //protocol to execute scripts on the device. Possible values are: "SSH Auto", "SSH1", "SSH2", "TELNET"     
string RequestConfigProtocol //protocol to initiate config transfer on the device. Possible values are: "SSH Auto", "SSH1", "SSH2", "TELNET", "SNMP"     
string TransferConfigProtocol //protocol to execute config transfer on the device. Possible values are: "SSH Auto", "SSH1", "SSH2", "TFTP", "SCP"     
int TelnetPort //port number for communication over telnet protocol
int SSHPort //port number for communication over SSH protocol
bool UseForAutoDetect  //indicate if the profile can be used for auto detect functionality
```


## Cirrus.Nodes


### SWIS Verbs
To manage NCM Connection profiles use the SWIS verbs described below. 

The user needs Orion `Node management rights` with the NCM role `Web Viewer` or higher to call these verbs.

#### Verb: GetAllConnectionProfiles

Retrieve an array of all connection profiles created in NCM.

```csharp
ConnectionProfile[] GetAllConnectionProfiles()
```
Returns an array of all `ConnectionProfile` objects.

PowerShell Sample:
```powershell
# Load SwisPowerShell
Import-Module SwisPowerShell
 
$hostname = "127.0.0.1"
$username = "admin"
$password = "password"
$swis = Connect-Swis -Hostname $hostname -Username $username -Password $password
$result = Invoke-SwisVerb $swis Cirrus.Nodes GetAllConnectionProfiles @()
Write-Host $result.InnerXml
```



#### Verb: GetConnectionProfile

	
Retrieve a single connection profile.

```csharp
ConnectionProfile GetConnectionProfile(int id)
```

* `Id` - The connection profile ID

Returns a `ConnectionProfile` object.

PowerShell Sample:
```powershell
# Load SwisPowerShell
Import-Module SwisPowerShell
 
$hostname = "127.0.0.1"
$username = "admin"
$password = "password"
$profileId = 1
$swis = Connect-Swis -Hostname $hostname -Username $username -Password $password
$result = Invoke-SwisVerb $swis Cirrus.Nodes GetConnectionProfile  @($profileId)
Write-Host $result.InnerXml
```

#### Verb: AddConnectionProfile

Create a new connection profile.

```csharp
int AddConnectionProfile(ConnectionProfile profile)
```
* `ConnectionProfile` - The profile object to create

Returns the ID of the newly created connection profile.

PowerShell Sample:
```powershell
# Load SwisPowerShell
Import-Module SwisPowerShell
 
$hostname = "127.0.0.1"
$username = "admin"
$password = "password"
$swis = Connect-Swis -Hostname $hostname -Username $username -Password $password
 
$connectionProfile = ([xml]"
<ConnectionProfile xmlns:i='http://www.w3.org/2001/XMLSchema-instance' xmlns='http://schemas.solarwinds.com/2007/08/informationservice/propertybag'>
<ConnectionData xmlns:d2p1='http://schemas.solarwinds.com/2013/Ncm'><d2p1:EnableLevel></d2p1:EnableLevel><d2p1:EnablePassword></d2p1:EnablePassword><d2p1:Password></d2p1:Password><d2p1:SshPort>0</d2p1:SshPort><d2p1:TelnetPort>0</d2p1:TelnetPort><d2p1:Username></d2p1:Username></ConnectionData>
  <EnableLevel>enable</EnableLevel>
  <EnablePassword>somePassword</EnablePassword>
  <ExecuteScriptProtocol>SSH Auto</ExecuteScriptProtocol>
  <ID>0</ID>
  <Name>Profile Name</Name>
  <Password>somePassword</Password>
  <RequestConfigProtocol>SSH Auto</RequestConfigProtocol>
  <SSHPort>22</SSHPort>
  <TelnetPort>23</TelnetPort>
  <TransferConfigProtocol>SSH Auto</TransferConfigProtocol>
  <UseForAutoDetect>false</UseForAutoDetect>
  <UserName>someUser</UserName>
</ConnectionProfile>
").DocumentElement
 
$result = Invoke-SwisVerb $swis Cirrus.Nodes AddConnectionProfile @($connectionProfile)
Write-Host $result.InnerXml
```

#### Verb: UpdateConnectionProfile

Update an existing connection profile.

```csharp
void UpdateConnectionProfile(ConnectionProfile profile)
```
* `ConnectionProfile` - The profile to update, with the exisiting profile ID filled in

PowerShell Sample:
```powershell
# Load SwisPowerShell
Import-Module SwisPowerShell
 
$hostname = "127.0.0.1"
$username = "admin"
$password = "password"
$swis = Connect-Swis -Hostname $hostname -Username $username -Password $password
$profileIdToUpdate= 3
 
$connectionProfile = ([xml]"
<ConnectionProfile xmlns:i='http://www.w3.org/2001/XMLSchema-instance' xmlns='http://schemas.solarwinds.com/2007/08/informationservice/propertybag'>
  <EnableLevel>enable</EnableLevel>
  <EnablePassword>somePassword</EnablePassword>
  <ExecuteScriptProtocol>SSH Auto</ExecuteScriptProtocol>
  <ID>$profileIdToUpdate</ID>
  <Name>Updated Name</Name>
  <Password>somePassword</Password>
  <RequestConfigProtocol>SSH Auto</RequestConfigProtocol>
  <SSHPort>22</SSHPort>
  <TelnetPort>23</TelnetPort>
  <TransferConfigProtocol>SSH Auto</TransferConfigProtocol>
  <UseForAutoDetect>false</UseForAutoDetect>
  <UserName>someUser</UserName>
</ConnectionProfile>
").DocumentElement
 
Invoke-SwisVerb $swis Cirrus.Nodes UpdateConnectionProfile @($connectionProfile)
```

#### Verb: DeleteConnectionProfile

Delete an existing connection profile.
```csharp
void DeleteConnectionProfile(int id)
```
* `id` - The ID of the profile to delete

PowerShell Sample:
```powershell
# Load SwisPowerShell
Import-Module SwisPowerShell
 
$hostname = "127.0.0.1"
$username = "admin"
$password = "password"
$swis = Connect-Swis -Hostname $hostname -Username $username -Password $password
$profileIdToDelete= 3
 
Invoke-SwisVerb $swis Cirrus.Nodes DeleteConnectionProfile @($profileIdToDelete)
```

### Assign a connection profile to a node

Assigning a connection profile to a node is done by updating the `ConnectionProfile` node property using SWIS CRUD operations.

The ConnectionProfile property should be set to match an existing connection profile ID. It can also contain the following values with special meanings:
* `-1` - No profile is assigned to the node.
* `0` - Use auto detect to find the right connection profile for the node. Before using it, make sure that there is at least one profile with the "UseForAutoDetect"  property set to true.

PowerShell Sample:
```powershell
# Load SwisPowerShell 
Import-Module SwisPowerShell
$hostname = "127.0.0.1"
$username = "admin"
$password = "password"
$swis = Connect-Swis -Hostname $hostname -Username $username -Password $password
$query = "
    SELECT Uri
    FROM Cirrus.Nodes
    WHERE AgentIP = '1.1.1.1'
"
$uri = Get-SwisData $swis $query
 
$properties = @{
    ConnectionProfile = 1
} 
Set-SwisObject $swis $uri $properties
```