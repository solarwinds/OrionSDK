# This sample script demonstrates the use of verbs provided for manipulating
# with groups. The verbs are defined by Orion.Container entity type.
#
# The script progresses in several steps, it:
# 1. Creates a new group with initial members.
# 2. Adds a new member in the group.
# 3. Adds multiple new members in the group using a single service call.
# 4. Updates an existing member with a new definition.
# 5. Deletes an existing member from the group.
# 6. Updates the group properties (e.g. name and refresh frequency)
# 7. Replaces the group members with a new set of members.
# 8. Deletes the group.
#
# Please update the hostname and credential setup to match your configuration.

# Connect to SWIS
$hostname = "localhost"
$username = "admin"
$password = New-Object System.Security.SecureString
$cred = New-Object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
$swis = Connect-Swis -host $hostname -cred $cred

#
# CREATING A NEW GROUP
#
# Creating a new group with initial Cisco and Windows devices.
#

$members = @(
  @{ Name = "Cisco Devices"; Definition = "filter:/Orion.Nodes[Vendor='Cisco']" },
  @{ Name = "Windows Devices"; Definition = "filter:/Orion.Nodes[Vendor='Windows']" }
)

$groupId = (Invoke-SwisVerb $swis "Orion.Container" "CreateContainer" @(
    # group name
    "Sample PowerShell Group",
    # owner, must be 'Core'
    "Core",
    # refresh frequency
    60,
    # Status rollup mode:
    # 0 = Mixed status shows warning
    # 1 = Show worst status
    # 2 = Show best status
    0,
    # group description
    "Group created by the PowerShell sample script.",
    # polling enabled/disabled = true/false (in lowercase)
    "true",
    # group members
    ([xml]@(
       "<ArrayOfMemberDefinitionInfo xmlns='http://schemas.solarwinds.com/2008/Orion'>",
       [string]($members |% {
         "<MemberDefinitionInfo><Name>$($_.Name)</Name><Definition>$($_.Definition)</Definition></MemberDefinitionInfo>"
         }
       ),
       "</ArrayOfMemberDefinitionInfo>"
    )).DocumentElement
  )).InnerText

#
# ADDING A NEW GROUP MEMBER
#
# Adding up devices in the group.
#

Invoke-SwisVerb $swis "Orion.Container" "AddDefinition" @(
    # group ID
    $groupId,
    # group member to add
    ([xml]"
       <MemberDefinitionInfo xmlns='http://schemas.solarwinds.com/2008/Orion'>
         <Name>Up Devices</Name>
         <Definition>filter:/Orion.Nodes[Status=1]</Definition>
       </MemberDefinitionInfo>"
    ).DocumentElement
  ) | Out-Null


#
# ADDING A SUBGROUP
#
# Adding up devices in the group.
#  
$subgroupmembers = @(
  @{ Name = "Subgroup Devices-Up"; Definition = "filter:/Orion.Nodes[Status=1]" },
  @{ Name = "Subgroup Devices-NotReachable"; Definition = "filter:/Orion.Nodes[Status=12]" }
)

$subgroupId = (Invoke-SwisVerb $swis "Orion.Container" "CreateContainer" @(
    # group name 
    "Sample PowerShell SubGroup",
    # owner, must be 'Core'
    "Core",
    # refresh frequency
    60,
    # Status rollup mode:
    # 0 = Mixed status shows warning
    # 1 = Show worst status
    # 2 = Show best status
    0,
    # group description
    "Sub Group created by the PowerShell sample script.",
    # polling enabled/disabled = true/false (in lowercase)
    "true",
    # group members
    ([xml]@(
       "<ArrayOfMemberDefinitionInfo xmlns='http://schemas.solarwinds.com/2008/Orion'>",
       [string]($subgroupmembers |% {
         "<MemberDefinitionInfo><Name>$($_.Name)</Name><Definition>$($_.Definition)</Definition></MemberDefinitionInfo>"
         }
       ),
       "</ArrayOfMemberDefinitionInfo>"
    )).DocumentElement
  )).InnerText 

#Add the SubGroup to a group

$subgroupUri = Get-SwisData $swis "SELECT Uri FROM Orion.Container WHERE ContainerID=@id" @{id=$subgroupId}

Invoke-SwisVerb $swis "Orion.Container" "AddDefinition" @(
	# group ID
	$groupId,
	# group member to add
		([xml]"
		   <MemberDefinitionInfo xmlns='http://schemas.solarwinds.com/2008/Orion'>
			 <Name></Name>
			 <Definition>$subgroupUri</Definition>
		   </MemberDefinitionInfo>"
		).DocumentElement
	) | Out-Null 
  

#
# ADDING MULTIPLE NEW GROUP MEMBERS
#
# Adding down and unreachable devices in the group.
#

$members = @(
  @{ Name = "Down Devices"; Definition = "filter:/Orion.Nodes[Status=2]" },
  @{ Name = "Unreachable Devices"; Definition = "filter:/Orion.Nodes[Status=12]" }
)

Invoke-SwisVerb $swis "Orion.Container" "AddDefinitions" @(
    # group ID
    $groupId,
    # group member to add
    ([xml]@(
       "<ArrayOfMemberDefinitionInfo xmlns='http://schemas.solarwinds.com/2008/Orion'>",
       [string]($members |% {
         "<MemberDefinitionInfo><Name>$($_.Name)</Name><Definition>$($_.Definition)</Definition></MemberDefinitionInfo>"
         }
       ),
       "</ArrayOfMemberDefinitionInfo>"
    )).DocumentElement
  ) | Out-Null

#
# UPDATE AN EXISTING MEMBER
#
# Replace unreachable to critical devices in the group.
#

$definitionId = Get-SwisData $swis "
SELECT DefinitionID
FROM Orion.ContainerMemberDefinition
WHERE ContainerID=@containerID AND Name LIKE 'Unreachable%'" @{ containerID=$groupId }

Invoke-SwisVerb $swis "Orion.Container" "UpdateDefinition" @(
    # group member definition ID
    $definitionId,
    # group member to add
    ([xml]"
       <MemberDefinitionInfo xmlns='http://schemas.solarwinds.com/2008/Orion'>
         <Name>Critical Devices</Name>
         <Definition>filter:/Orion.Nodes[Status=14]</Definition>
       </MemberDefinitionInfo>"
    ).DocumentElement
  ) | Out-Null

#
# DELETE AN EXISTING MEMBER
#
# Delete up devices from the group.
#

$definitionId = Get-SwisData $swis "
SELECT DefinitionID
FROM Orion.ContainerMemberDefinition
WHERE ContainerID=@containerID AND Name LIKE 'Up%'" @{ containerID=$groupId }

Invoke-SwisVerb $swis "Orion.Container" "DeleteDefinition" @(
    # group member definition ID
    $definitionId
  ) | Out-Null

#
# UPDATE THE GROUP PROPERTIES
#
# Update the name and refresh frequency of the group.

$containerProps = Get-SwisData $swis "
SELECT Name, Owner, Frequency, StatusCalculator, Description, PollingEnabled
FROM Orion.Container
WHERE ContainerID=$groupId"

Invoke-SwisVerb $swis "Orion.Container" "UpdateContainer" @(
    # group ID
    $groupId,
    # group name
    "Sample PowerShell Group (renamed)",
    # owner, must be 'Core'
    $containerProps.Owner,
    # refresh frequency
    120,
    # Status rollup mode:
    # 0 = Mixed status shows warning
    # 1 = Show worst status
    # 2 = Show best status
    $containerProps.StatusCalculator,
    # group description
    $containerProps.Description,
    # polling enabled/disabled = true/false (in lowercase)
    $containerProps.PollingEnabled
  ) | Out-Null

#
# SET A NEW SET OF MEMBERS
#
# Replace the group member with only devices located in Austin that are up.
#

$members = @(
  @{ Name = "Austin Up Devices"; Definition = "filter:/Orion.Nodes[CustomProperties.City='Austin' AND Status=1]" }
)

Invoke-SwisVerb $swis "Orion.Container" "SetDefinitions" @(
    # group ID
    $groupId,
    # group members
    ([xml]@(
       "<ArrayOfMemberDefinitionInfo xmlns='http://schemas.solarwinds.com/2008/Orion'>",
       [string]($members |% {
         "<MemberDefinitionInfo><Name>$($_.Name)</Name><Definition>$($_.Definition)</Definition></MemberDefinitionInfo>"
         }
       ),
       "</ArrayOfMemberDefinitionInfo>"
    )).DocumentElement
  ) | Out-Null

#
# DELETE THE GROUP
#
# Delete the group from the system.
#

Invoke-SwisVerb $swis "Orion.Container" "DeleteContainer" @(
    # group ID
    $groupId
  ) | Out-Null
