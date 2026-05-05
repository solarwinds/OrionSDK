---
layout: default
title: "IPAM Observability 2022.2"
---

# IPAM Observability 2022.2 API

# Add PTR record

We can use this method in order to add PTR record to DNS zone without adding A record.

```csharp
// <summary>
/// Create PTR record
/// </summary>
/// <param name="recordName">Dns Record Name</param>
/// <param name="recordData">Dns Zone Name</param>
/// <param name="dnsIpAddress">DnsServer IpAddress</param>
/// <param name="dnsZoneName">DnsServer Zone name</param>
/// <returns>Message about result status</returns>
public string AddPtrRecord(string recordName, string recordData, string dnsIpAddress, string dnsZoneName)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.IPAddressManagement AddPtrRecord @("10.10.11.111", "roman.zone.", "10.199.1.149", "10.10.in-addr.arpa")
```

# Remove PTR Record

We can use this method in order to remove PTR record.

```csharp
/// <summary>
/// Removes PTR record
/// </summary>
/// <param name="recordName">Dns Record Name</param>
/// <param name="dnsIpAddress">DnsServer IpAddress.</param>
/// <param name="dnsZoneName">DnsServer Zone name</param>
/// <param name="isRetryingDnsZoneSearch">Enables search into other dnsZones e.x. when we specify if record doesn't  exist in "10.10.10.in-addr.arpa" verb will check "10.10.in-addr.arpa" and "10.in-addr.arpa" </param>
public string RemovePtrRecord(string recordName, string dnsIpAddress, string dnsZoneName, bool isRetryingDnsZoneSearch = false)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.IPAddressManagement RemovePtrRecord @("1.10.10.10.in-addr.arpa.","10.199.1.149", "10.10.10.in-addr.arpa")
```

# Get first available IP Address for specific subnet

Method returns first available IP node for the existing subnet. Error will be returned if non-existing subnet will be specified. It doesn't change status of the returned node.

```csharp
/// <summary>
/// Get first available IP Address for specific subnet
/// </summary>
/// <param name="subnetAddress">Subnet IpAddress. Like "199.10.1.1" or "0000:0000:0000:0000:0000:0000:0000:0000"</param>
/// <param name="subnetCidr">Subnet CIDR.</param>
/// <returns>First Available IpAddress from Subnet</returns>
string GetFirstAvailableIp(string subnetAddress, string subnetCidr)
```

Sample
IPv4

```powershell
Invoke-SwisVerb $swis IPAM.SubnetManagement GetFirstAvailableIp @("199.10.1.0", "24")
```

IPv6

```powershell
Invoke-SwisVerb $swis IPAM.SubnetManagement GetFirstAvailableIp @("1212::3", "24")
```

# Get first available IP Address for specific subnet via friendly name

Method returns first available IP node for the existing subnet using friendly name only. Error will be returned if non-existing subnet will be specified. It doesn't change status of the returned node.

```csharp
/// <summary>
/// Get first available IP Address for subnet with specific friendly name
/// </summary>
/// <param name="friendlyName">Friendly name of the subnet</param>
/// <returns>First Available IpAddress from Subnet</returns>
public string GetFirstAvailableIpViaFriendlyName(string friendlyName)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.SubnetManagement GetFirstAvailableIpViaFriendlyName @("FriendlyName")
```

# Get first available IP Address for specific subnet in specific Hierarchy group

Method returns first available IP node for the existing subnet in the specific Hierarchy group. Error will be returned if non-existing subnet will be specified. It doesn't change status of the returned node.

```csharp
/// <summary>
/// Get first available IP Address for specific subnet in a specific Hierarchy group
/// </summary>
/// <param name="subnetAddress">Subnet IpAddress. Like "199.10.1.1" or "0000:0000:0000:0000:0000:0000:0000:0000"</param>
/// <param name="subnetCidr">Subnet CIDR.</param>
/// <param name="hierarchyGroup">Hierarchy group name</param>
/// <returns>First Available IpAddress from Subnet</returns>
public string GetFirstAvailableIpForGroup(string subnetAddress, string subnetCidr, string hierarchyGroup)
```

Sample
IPv4

```powershell
Invoke-SwisVerb $swis IPAM.SubnetManagement GetFirstAvailableIpForGroup @("199.10.1.0", "24", "Hierarchy Group")
```

IPv6

```powershell
Invoke-SwisVerb $swis IPAM.SubnetManagement GetFirstAvailableIpForGroup @("1212::3", "24", "Hierarchy Group")
```

# Change IpNode Status

```csharp
/// <summary>
/// Change IpNode Status
/// </summary>
/// <param name="ipAddress">IpNode Address. Like "199.10.1.1"</param>
/// <param name="status">New Status value. Status values: "Used", "Available", "Reserved", "Transient", "Blocked"</param>
void ChangeIpStatus(string ipAddress, string status)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.SubnetManagement ChangeIPStatus  @("199.10.1.1", "Used")
```

# Change IpNode Status for specific Hierarchy group

```csharp
/// <summary>
/// Change IpNode Status into specific Hierarchy group.
/// </summary>
/// <param name="ipAddress">IpNode Address. Like "199.10.1.1"</param>
/// <param name="status">New Status value. Status values: "Used", "Available", "Reserved", "Transient", "Blocked"</param>
/// <param name="hierarchyGroup">Hierarchy group name</param>
public void ChangeIpStatusForGroup(string ipAddress, string status, string hierarchyGroup)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.SubnetManagement ChangeIPStatusForGroup  @("199.10.1.1", "Used", "Hierarchy Group")
```

# IP address reservation

When reservation time expires IP node status is set to available.

```csharp
/// <summary>
/// Start IpAddress Reservation
/// </summary>
/// <param name="subnetAddress">Subnet IpAddress. Like "199.10.1.1"</param>
/// <param name="subnetCidr">Subnet CIDR</param>
/// <param name="reservationTimeInMinutes">Reservation Time In Minutes. Default value is "10"</param>
/// <param name="addressToStart">Address from which available addresses will be reserved. By default addresses will be reserved from first available address in subnet.</param>
/// <returns>Reserved IpAddress</returns>
string StartIpReservation(string subnetAddress, string subnetCidr, int reservationTimeInMinutes = 10, string addressToStart = "")

/// <summary>
/// Finish IpAddress Reservation with specific status.
/// Call after 'StartIpReservation'
/// </summary>
/// <param name="ipAddress">IpAddress for Reservation. Like "199.10.1.1"</param>
/// <param name="finalIpStatus">IpAddress Status. Possible status values: "Used", "Available", "Reserved", "Transient", "Blocked"</param>
void FinishIpReservation(string ipAddress, string finalIpStatus)

/// <summary>
/// Cancel IpAddress Reservation.
/// Call after 'StartIpReservation'
/// </summary>
/// <param name="reservedIpAddress">IpAddress for Reservation. Like "199.10.1.1"</param>
void CancelIpReservation(string reservedIpAddress)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.SubnetManagement StartIpReservation @("199.10.1.0", "24", "15", "199.10.1.24")

Invoke-SwisVerb $swis IPAM.SubnetManagement FinishIpReservation @("199.10.1.1", "Reserved")

Invoke-SwisVerb $swis IPAM.SubnetManagement CancelIpReservation @("199.10.1.1")
```

# IP address reservation for specific Hierarchy group

When reservation time expires IP node status is set to available.

```csharp
/// <summary>
/// Start IpAddress Reservation if it exists into specific Hierarchy group.
/// </summary>
/// <param name="subnetAddress">Subnet IpAddress. Like "199.10.1.1"</param>
/// <param name="subnetCidr">Subnet CIDR</param>
/// <param name="hierarchyGroup">Hierarchy group name</param>
/// <param name="reservationTimeInMinutes">Reservation Time In Minutes. Default value is "10"</param>
/// <param name="addressToStart">Address from which available addresses will be reserved. By default addresses will be reserved from first available address in subnet.</param>
/// <returns>Reserved IpAddress</returns>
public string StartIpReservationForGroup(string subnetAddress, string subnetCidr, string hierarchyGroup, int reservationTimeInMinutes = 10, string addressToStart = "")

/// <summary>
/// Finish IpAddress Reservation with specific status if it exists into specific Hierarchy group.
/// Call after 'StartIpReservation'
/// </summary>
/// <param name="ipAddress">IpAddress for Reservation. Like "199.10.1.1"</param>
/// <param name="finalIpStatus">IpAddress Status. Possible status values: "Used", "Available", "Reserved", "Transient", "Blocked"</param>
/// <param name="hierarchyGroup">Hierarchy group name</param>
public void FinishIpReservationForGroup(string ipAddress, string finalIpStatus, string hierarchyGroup)

/// <summary>
/// Cancel IpAddress Reservation into specific Hierarchy group.
/// Call after 'StartIpReservation'
/// </summary>
/// <param name="reservedIpAddress">IpAddress for Reservation. Like "199.10.1.1"</param>
/// <param name="hierarchyGroup">Hierarchy group name</param>
public void CancelIpReservationForGroup(string reservedIpAddress, string hierarchyGroup)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.SubnetManagement StartIpReservationForGroup @("199.10.1.0", "24", "Hierarchy Group", "15", "199.10.1.24")

Invoke-SwisVerb $swis IPAM.SubnetManagement FinishIpReservationForGroup @("199.10.1.1", "Reserved", "Hierarchy Group")

Invoke-SwisVerb $swis IPAM.SubnetManagement CancelIpReservationForGroup @("199.10.1.1", "Hierarchy Group")
```

# Create new (Hierarchy) Group

Available since 2025.1

```csharp
/// <summary>
/// Create new Group
/// </summary>
/// <param name="groupName">Group name</param>
/// <param name="comments">Comments</param>
/// <param name="parentGroupId">Parent GroupId. If creating Hierarchy Group, pass $null</param>
public void CreateGroup(string groupName, string comments, int? parentGroupId)
```

Creating Hierarchy Group example

```powershell
Invoke-SwisVerb $swis IPAM.GroupManagement CreateGroup @("New Hierarchy Group", "Example Comment", $null)
```

Creating Group example

```powershell
Invoke-SwisVerb $swis IPAM.GroupManagement CreateGroup @("New Group", "Example comment", 0)
```

# Get (Hierarchy) Groups by name

Available since 2025.1

```csharp
/// <summary>
/// Get all Groups (including Hierarchy Groups) with given name
/// </summary>
/// <param name="groupName">Group name</param>
/// <returns>
/// List of (Hierarchy) Groups, where Group is type like:
/// {
///     int GroupId;
///     int ParentId;
/// }
/// in case when ParentId=-1, the group is a Hierarchy Group
/// </returns>
public List<GetGroupNodeDto> GetGroupsByName(string groupName)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.GroupManagement GetGroupsByName @("Example group")
```

# Create new subnet

```csharp
Created subnet will be plaeced under the root folder in the IPAM group tree. Possible errors: overlapping with existing subnets.
/// <summary>
/// Create new Subnet
/// </summary>
/// <param name="subnetAddress">Subnet IpAddress.</param>
/// <param name="rawCidr">Subnet CIDR</param>
void CreateSubnet(string subnetAddress, string rawCidr)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.SubnetManagement CreateSubnet @("10.10.1.0", "21")
```

# Create new subnet for Hierarchy group

```csharp
Created subnet will be placed in the root of Hierarchy group tree. Possible errors: overlapping with existing subnets.
/// <summary>
/// Create new Subnet in specific Hierarchy group
/// </summary>
/// <param name="subnetAddress">Subnet IpAddress. Like "199.10.1.1"</param>
/// <param name="rawCidr">Subnet CIDR</param>
/// <param name="hierarchyGroup">Hierarchy Group name</param>
public void CreateSubnetForGroup(string subnetAddress, string rawCidr, string hierarchyGroup)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.SubnetManagement CreateSubnetForGroup @("10.10.1.0", "21", "Hierarchy Group")
```

# Create new subnet under specific Supernet, Group or Hierarchy Group

Available since 2025.1

```csharp
/// <summary>
/// Create new Subnet under specific Supernet, Group or Hierarchy Group
/// </summary>
/// <param name="subnetAddress">Subnet IpAddress. Like "199.10.1.0"</param>
/// <param name="rawCidr">Subnet CIDR</param>
/// <param name="parentGroupId">Parent node's GroupId</param>
public void CreateSubnetForGivenParentNode(string subnetAddress, string rawCidr, int parentGroupId)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.SubnetManagement CreateSubnetForGivenParentNode("10.10.1.0", "21", 0)
```

# Create new IPv6 subnet

```csharp
Creates Global IPv6 prefix and  subnet will be plaeced under the root folder in the IPAM group tree. Possible errors: overlapping with existing subnets.
/// <summary>
/// Create new IpV6 Subnet
/// </summary>
/// <param name="prefix">IPv6 subnet global prefix, like 2001:10:100</param>
/// <param name="prefixName">IPv6 subnet global prefix name</param>
/// <param name="isNewPrefix">Create new or use existing</param>
/// <param name="subnetAddress">Subnet IpV6Address like : 2001:10:100:112::</param>
/// <param name="rawCidr">Subnet CIDR</param>
public void CreateIPv6Subnet(string prefix, string prefixName, bool isNewPrefix, string subnetAddress, string rawCidr)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.SubnetManagement CreateIPv6Subnet @("2001:10:100","Test","false"," 2001:10:100:112::","48")
```

# Create new IPv6 subnet for specific Hierarchy group

```csharp
Creates Global IPv6 prefix and subnet will be placed in the root of Hierarchy group tree. Possible errors: overlapping with existing subnets.
/// <summary>
/// Create new IpV6 Subnet for specific Hierarchy group
/// </summary>
/// <param name="prefix">IPv6 subnet global prefix, like 2001:10:100</param>
/// <param name="prefixName">IPv6 subnet global prefix name</param>
/// <param name="isNewPrefix">Create new or use existing</param>
/// <param name="subnetAddress">Subnet IpV6Address like : 2001:10:100:112::</param>
/// <param name="rawCidr">Subnet CIDR</param>
/// <param name="hierarchyGroup">Hierarchy Group name</param>
public void CreateIPv6SubnetForGroup(string prefix, string prefixName, bool isNewPrefix, string subnetAddress, string rawCidr, string hierarchyGroup)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.SubnetManagement CreateIPv6SubnetForGroup @("2001:10:100","Test","false"," 2001:10:100:112::","48", "Hierarchy Group")
```

# Create Supernet under specific group

Available since 2025.1

```csharp
/// <summary>
/// Create new Supernet under specific group
/// </summary>
/// <param name="supernetName">Supernet name</param>
/// <param name="address">Supernet IP address"</param>
/// <param name="cidr">Supernet CIDR</param>
/// <param name="description">Description e.g. department, region, sub allocation notes</param>
/// <param name="parentGroupId">Parent GroupId</param>
public void CreateSupernet(string supernetName, string address, int cidr, string description, int parentGroupId)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.SupernetManagement CreateSupernet @("Example Supernet", "7.7.7.0", 29, "Example Description", 0)
```

# Get all Supernets by name

Available since 2025.1

```csharp
/// <summary>
/// Get all Supernets with given name
/// </summary>
/// <param name="supernetName">Supernet name</param>
/// <returns>
/// List of Supernets, where Supernet is type like:
/// {
///     int GroupId;
///     int ParentId;
/// }
/// </returns>
public List<GetGroupNodeDto> GetSupernetsByName(string supernetName)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.SupernetManagement GetSupernetsByName("Example Supernet")
```

# Add DNS 'AAAA' record for IP address

```csharp
/// <summary>
/// Add DNS AAAA for IP Address
/// </summary>
/// <param name="recordName">Dns Record Name</param>
/// <param name="nodeIPv6Address">IpNode Address.</param>
/// <param name="dnsIpAddress">DnsServer IpAddress.</param>
/// <param name="dnsZoneName">DnsServer Zone neme</param>
public string AddDnsAaaaRecord(string recordName, string nodeIPv6Address, string dnsIpAddress, string dnsZoneName)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.IPAddressManagement AddDnsAaaaRecord @("zzz", "0200:0200::3", "10.199.1.150", "iis.lab")
```

# Change DNS 'AAAA' record for IP address

```csharp
/// <summary>
/// Change DNS AAAA for IP Address
/// </summary>
/// <param name="recordName">Dns Record Name</param>
/// <param name="nodeIPv6Address">IpNode Address.</param>
/// <param name="dnsIpAddress">DnsServer IpAddress.</param>
/// <param name="dnsZoneName">DnsServer Zone neme</param>
/// <param name="nodeIPv6AddressNew">New IpNode Address.</param>
public string ChangeDnsAaaaRecord(string recordName, string nodeIpV6Address, string dnsIpAddress, string dnsZoneName, string newNodeIpV6Address)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.IPAddressManagement ChangeDnsAaaaRecord @("zzz", "0200:0200::3", "10.199.1.150", "iis.lab", "0100:0100::3")
```

# Remove DNS 'AAAA' record for IP address

```csharp
/// <summary>
/// Remove DNS A for IP Address
/// </summary>
/// <param name="recordName">Dns Record Name</param>
/// <param name="nodeIPv4Address">IpNode Address.</param>
/// <param name="dnsIpAddress">DnsServer IpAddress.</param>
/// <param name="dnsZoneName">DnsServer Zone neme</param>
public string RemoveDnsAaaaRecord(string recordName, string nodeIpV6Address, string dnsIpAddress, string dnsZoneName)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.IPAddressManagement RemoveDnsAaaaRecord @("zzz", "0200:0200::3", "10.199.1.150", "iis.lab")
```

# Add DNS 'A' record for IP address

```csharp
If we have no connection issues this operation will be executed on the DNS server immediately (around 30 seconds). Admin can query IPAM.DnsZone, IPAM.DnsServer, IPAM.DnsRecord entities.
/// <summary>
/// Add  DNS 'A' record  for IP Address
/// </summary>
/// <param name="recordName">Dns Record Name</param>
/// <param name="nodeIPv4Address">IpNode Address. Like "199.10.1.1"</param>
/// <param name="dnsIpAddress">DnsServer IpAddress.</param>
/// <param name="dnsZoneName">DnsServer Zone name</param>
void AddDnsARecord(string recordName, string nodeIPv4Address, string dnsIpAddress, string dnsZoneName)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.IPAddressManagement AddDnsARecord @("zzz", "10.11.78.22", "10.199.7.83", "testZone")
```

# Change DNS 'A' record for IP address

```csharp
/// <summary>
/// Change DNS 'A' record for IP Address
/// </summary>
/// <param name="recordName">Dns Record Name</param>
/// <param name="nodeIPv4Address">IpNode Address.</param>
/// <param name="dnsIpAddress">DnsServer IpAddress.</param>
/// <param name="dnsZoneName">DnsServer Zone name</param>
/// <param name="nodeIPv4AddressNew">New IpNode Address.</param>
void ChangeDnsARecord(string recordName, string nodeIPv4Address, string dnsIpAddress, string dnsZoneName, string nodeIPv4AddressNew)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.IPAddressManagement ChangeDnsARecord @("zzz.testZone.", "10.11.78.22", "10.199.7.83", "testZone", "10.11.78.33")
```

# Remove DNS 'A' record for IP address

```csharp
/// <summary>
/// Remove DNS 'A' record for IP Address
/// </summary>
/// <param name="recordName">Dns Record Name</param>
/// <param name="nodeIPv4Address">IpNode Address.</param>
/// <param name="dnsIpAddress">DnsServer IpAddress.</param>
/// <param name="dnsZoneName">DnsServer Zone name</param>
void RemoveDnsARecord(string recordName, string nodeIPv4Address, string dnsIpAddress, string dnsZoneName)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.IPAddressManagement RemoveDnsARecord @("zzz.testZone.", "10.11.78.33", "10.199.7.83", "testZone")
```

# Add 'A' record with associated PTR for zone

```csharp
/// <summary>
/// Creates 'A' record with associated PTR for zone
/// </summary>
/// <param name="recordName">Dns Record Name</param>
/// <param name="nodeIPv4Address">IpNode Address.</param>
/// <param name="dnsIpAddress">DnsServer IpAddress.</param>
/// <param name="dnsZoneName">DnsServer Zone name</param>
void AddDnsARecordWithPtr(string recordName, string nodeIPv4Address, string dnsIpAddress, string dnsZoneName)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.IPAddressManagement AddDnsARecordWithPtr @("QQQ.TestZone.", "10.11.78.25", "10.199.7.82", "TestZone")
```

# Add PTR record

```csharp
/// <summary>
/// Create PTR record
/// </summary>
/// <param name="recordName">Dns Record Name</param>
/// <param name="recordData">Dns Zone Name</param>
/// <param name="dnsIpAddress">DnsServer IpAddress</param>
/// <param name="dnsZoneName">DnsServer Zone name</param>
/// <returns>Message about result status</returns>
public string AddPtrRecord(string recordName, string recordData, string dnsIpAddress, string dnsZoneName)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.IPAddressManagement AddPtrRecord @("10.10.11.111", "roman.zone.", "10.199.1.149", "10.10.in-addr.arpa")
```

# Remove PTR record

```csharp
/// <summary>
/// Removes PTR record
/// </summary>
/// <param name="recordName">Dns Record Name</param>
/// <param name="dnsIpAddress">DnsServer IpAddress.</param>
/// <param name="dnsZoneName">DnsServer Zone name</param>
/// <param name="isRetryingDnsZoneSearch">Enables search into other dnsZones e.x. when we specify if record doesn't  exist in "10.10.10.in-addr.arpa" verb will check "10.10.in-addr.arpa" and "10.in-addr.arpa" </param>
public string RemovePtrRecord(string recordName, string dnsIpAddress, string dnsZoneName, bool isRetryingDnsZoneSearch = false)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.IPAddressManagement RemovePtrRecord @("1.10.10.10.in-addr.arpa.","10.199.1.149", "10.10.10.in-addr.arpa")
```

# Add PTR To DNS 'A' record

```csharp
/// <summary>
/// Crate PTR record to existing 'A' record
/// </summary>
/// <param name="recordName">Dns Record Name</param>
/// <param name="nodeIPv4Address">IpNode Address.</param>
/// <param name="dnsIpAddress">DnsServer IpAddress.</param>
/// <param name="dnsZoneName">DnsServer Zone name</param>
void AddPtrToDnsARecord(string recordName, string nodeIPv4Address, string dnsIpAddress, string dnsZoneName)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.IPAddressManagement AddPtrToDnsARecord @("EEEwithPTR", "10.11.78.28", "10.199.7.82", "TestZone")
```

# Delete DHCP server

```csharp
/// <summary>
/// Remove DHCP server
/// </summary>
/// <param name="groupId">Server group id</param>
/// <param name="removeScopesFromServer">Whether the scopes should be removed from the DHCP server</param>
/// <param name="removeCorrespondingSubnets">Whether the corresponding subnets should be removed from the IPAM</param>
/// <returns>Operation result: "Operation was successful" or "Operation failed"</returns>
public string DeleteDhcpServer(int groupId, bool removeCorrespondingSubnets = false, bool removeScopesFromServer = false)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement DeleteDhcpServer@(100, 1, 1)
```

# Delete DNS server

```csharp
/// <summary>
/// Remove DNS server
/// </summary>
/// <param name="groupId">Server group id</param>
/// <param name="removeZonesFromServer">Whether the zones should be removed from the DNS server</param>
/// <returns>Operation result: "Operation was successful" or "Operation failed"</returns>
public string DeleteDnsServer(int groupId, bool removeZonesFromServer = false)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement DeleteDnsServer@(100, 1)
```

# Add DHCP server

```csharp
/// <summary>
/// Add DHCP server
/// </summary>
/// <param name="nodeId">Node Id</param>
/// <param name="newHierarchyGroupName">New hierarchy group name. If not creating a new group pass null</param>
/// <param name="newCredentialName">New Credential name. If not creating new credentials pass null</param>
/// <param name="newCredentialUserName">New credential user name. If not creating new credentials pass null</param>
/// <param name="newCredentialPassword">New credential password. If not creating new credentials pass null</param>
/// <param name="newCredentialProtocol">New credential protocol. Telnet = 0, SSH = 1. If not creating new credentials pass null. Default value is SSH (1)</param>
/// <param name="newCredentialClientPort">New credential port. If not creating new credentials pass null. Default value is 22</param>
/// <param name="newCredentialEnableLevel">New credential enable level property. No enable login = -2, enable = -1, enable 0 = 0 ... . If not creating new credentials pass null. Default value is -2 (No enable login)</param>
/// <param name="newCredentialEnablePassword">New credential enable password property. If not creating new credentials pass null</param>
/// <param name="credentialId">Credential Id. For new credentials, pass null. For inherit credentials pass -1 (by default)</param>
/// <param name="clusterId">Cluster Id. If creating new hierarchy group pass null. Default value is 0 (IP Networks)</param>
/// <param name="scopesScanInterval">Scopes scan interval in minutes. Default value is 240 minutes</param>
/// <param name="scanInterval">Scan interval in minutes. Default value is 240 minutes</param>
/// <param name="serverType">Type of the DHCP server. Unknown = 0, Windows = 1, CISCO = 2, ASA = 3, ISC = 4, Infoblox = 5. Default value is Windows (1)</param>
/// <param name="autoAddNewScopes">Is the automatic addition of the new scopes enabled. Default value is true</param>
/// <param name="enableSubnetScanning">Is subnet scanning enabled. Default value is true</param>
/// <returns>Operation result: "Operation was successful" or "Operation failed"</returns>
public string AddDhcpServer(int nodeId, string newHierarchyGroupName, string newCredentialName, string newCredentialUserName,
string newCredentialPassword, string newCredentialEnablePassword, int? newCredentialProtocol = 1, int? newCredentialClientPort = 22,
int? newCredentialEnableLevel = -2, int? credentialId = -1, int? clusterId = 0, double scopesScanInterval = 240,
double scanInterval = 240, int serverType = 1, bool autoAddNewScopes = true, bool enableSubnetScanning = true)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement AddDhcpServer @(1, "newHierarchyGroupName", "newCredentialName", "username", "password", $null, $null, $null, $null, $null, $null, 240, 240, 1, 1, 1)
```

# Add DHCP scope

Create a new DHCP scope on a managed DHCP server.
The verb supports Windows (IPv4 and IPv6), ISC (IPv4 and IPv6), Kea (IPv4 and IPv6), CISCO IOS (IPv4 and IPv6), and CISCO ASA (IPv4) servers.

Available since 2026.2

```csharp
/// <summary>
/// Create a new DHCP scope on a DHCP server.
/// </summary>
/// <param name="dhcpServerId">GroupId of the DHCP server.</param>
/// <param name="scopeAddress">Scope network address (e.g. "192.168.1.0").</param>
/// <param name="scopeCidr">CIDR prefix length (e.g. 24). For Windows IPv6 must be 64.</param>
/// <param name="scopeName">Display name of the scope. For CISCO ASA must match the interface name.</param>
/// <param name="description">Optional description.</param>
/// <param name="disabledAtServer">Whether the scope is created as disabled on the server.</param>
/// <param name="autoAddIpAddresses">When true, IP addresses are auto-populated in IPAM DB.</param>
/// <param name="scopeRangeStart">Start of the allocatable IP range. Required for Windows IPv4 and ASA. Ignored for IPv6 (computed from network + CIDR).</param>
/// <param name="scopeRangeEnd">End of the allocatable IP range. Required for Windows IPv4 and ASA.</param>
/// <param name="offerDelay">Initial offer delay in milliseconds (0–65535). Windows IPv4 only.</param>
/// <param name="defaultLeaseTime">Default/valid lease time in seconds. Windows and ISC IPv4; also valid-lifetime for Kea (IPv4 and IPv6).</param>
/// <param name="maxLeaseTime">Maximum lease time in seconds. Windows IPv4 only. Silently ignored for ISC, Kea, CISCO, and ASA.</param>
/// <param name="preferredLifeTime">Preferred lifetime in seconds. Required for Windows IPv6 and CISCO IPv6. Optional for ISC IPv6 and Kea IPv6 (defaults to defaultLeaseTime when omitted).</param>
/// <param name="validLifeTime">Valid lifetime in seconds. Required for Windows IPv6 and CISCO IPv6. Not used for ISC or Kea (use defaultLeaseTime instead).</param>
/// <param name="preference">DHCPv6 preference value. Required for Windows IPv6 only.</param>
/// <param name="exclusions">JSON array of exclusion ranges: [{"start":"x.x.x.x","end":"x.x.x.x"}]. Windows and CISCO. CISCO exclusions do not need to fall within the scope subnet. Silently ignored for ISC, Kea, and ASA.</param>
/// <param name="options">JSON array of DHCP options: [{"code":"3","value":"10.0.0.1"}]. Supported for all server types.</param>
/// <param name="ranges">JSON array of address ranges for ISC and Kea. Each entry: {"start":"x","end":"y"}. Add "poolId" (integer >= 1) to group ranges into a pool{} block; entries sharing the same poolId go into the same pool. Without poolId the range is written as a bare range statement. For Kea every range must have a poolId.</param>
/// <param name="sharedNetworkName">Shared network to place the scope in. ISC and Kea only.</param>
/// <param name="dhcpGroupId">Group ID for scope placement. ISC only.</param>
/// <param name="dhcpGroupName">Group name for scope placement. ISC only.</param>
/// <param name="vlan">VLAN label to associate with the scope.</param>
/// <param name="location">Location label to associate with the scope.</param>
/// <returns>Operation result: "Operation was successful"</returns>
public string AddDhcpScope(
    int dhcpServerId,
    string scopeAddress,
    int scopeCidr,
    string scopeName,
    string description = null,
    bool disabledAtServer = false,
    bool autoAddIpAddresses = true,
    string scopeRangeStart = null,
    string scopeRangeEnd = null,
    int? offerDelay = null,
    long? defaultLeaseTime = null,
    long? maxLeaseTime = null,
    long? preferredLifeTime = null,
    long? validLifeTime = null,
    int? preference = null,
    string exclusions = null,
    string options = null,
    string ranges = null,
    string sharedNetworkName = null,
    int? dhcpGroupId = null,
    string dhcpGroupName = null,
    string vlan = null,
    string location = null)
```

The 23-element positional array passed to `Invoke-SwisVerb`:

| #   | Parameter            | Notes                                                                   |
| --- | -------------------- | ----------------------------------------------------------------------- |
| 0   | `dhcpServerId`       | GroupId of the DHCP server node                                         |
| 1   | `scopeAddress`       | Network address of the scope                                            |
| 2   | `scopeCidr`          | CIDR prefix length                                                      |
| 3   | `scopeName`          | Display name                                                            |
| 4   | `description`        | Optional                                                                |
| 5   | `disabledAtServer`   | `"true"` / `"false"`                                                    |
| 6   | `autoAddIpAddresses` | `"true"` / `"false"`                                                    |
| 7   | `scopeRangeStart`    | **Required** for Windows IPv4 and ASA; ignored for IPv6                 |
| 8   | `scopeRangeEnd`      | **Required** for Windows IPv4 and ASA; ignored for IPv6                 |
| 9   | `offerDelay`         | Windows IPv4 only                                                       |
| 10  | `defaultLeaseTime`   | Windows & ISC IPv4; `valid-lifetime` source for Kea IPv4/IPv6           |
| 11  | `maxLeaseTime`       | Windows IPv4 only                                                       |
| 12  | `preferredLifeTime`  | **Required** for Windows IPv6 and CISCO IPv6; optional for ISC/Kea IPv6 |
| 13  | `validLifeTime`      | **Required** for Windows IPv6 and CISCO IPv6                            |
| 14  | `preference`         | **Required** for Windows IPv6 only                                      |
| 15  | `exclusions`         | JSON array; Windows and CISCO; ignored for ISC, Kea, ASA                |
| 16  | `options`            | JSON array; all server types                                            |
| 17  | `ranges`             | JSON array; ISC and Kea; Kea requires `poolId` on every entry           |
| 18  | `sharedNetworkName`  | ISC and Kea only                                                        |
| 19  | `dhcpGroupId`        | ISC only                                                                |
| 20  | `dhcpGroupName`      | ISC only                                                                |
| 21  | `vlan`               | Optional                                                                |
| 22  | `location`           | Optional                                                                |

Sample Windows IPv4

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement AddDhcpScope @(
    201,
    "192.168.1.0",
    24,
    "Windows IPv4 Scope",
    "Lab scope",
    "false",
    "true",
    "192.168.1.100",
    "192.168.1.200",
    "0",
    "86400",
    "172800",
    $null,
    $null,
    $null,
    '[{"start":"192.168.1.1","end":"192.168.1.10"}]',
    '[{"code":"3","value":"192.168.1.1"},{"code":"6","value":"8.8.8.8"}]',
    $null,
    $null, $null, $null,
    "VLAN-10",
    "Server Room A"
)
```

Sample Windows IPv6

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement AddDhcpScope @(
    201,
    "2001:db8:1::",
    64,
    "Windows IPv6 Scope",
    "Lab IPv6 scope",
    "false", "true",
    $null, $null,
    $null, $null, $null,
    "43200",
    "86400",
    "0",
    $null,
    '[{"code":"23","value":"2001:4860:4860::8888"}]',
    $null, $null, $null, $null,
    "VLAN-IPv6-10", "Data Center"
)
```

Sample ISC IPv4 — bare range (no pool block)

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement AddDhcpScope @(
    332,
    "101.10.14.0", 24,
    "ISC IPv4 Bare Range",
    "Bare range, no pool block",
    "false", "true",
    "101.10.14.100",
    "101.10.14.200",
    $null,
    "86400",
    $null,
    $null, $null, $null,
    $null,
    '[{"code":"3","value":"101.10.14.1"},{"code":"6","value":"8.8.8.8"}]',
    '[{"start":"101.10.14.100","end":"101.10.14.200"}]',
    "Shared Network 1",
    $null, $null,
    "VLAN-14", "Test Lab"
)
```

Sample ISC IPv4 — two ranges in one `pool {}` block

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement AddDhcpScope @(
    332,
    "103.10.16.0", 24,
    "ISC IPv4 Shared Pool",
    "Two ranges sharing poolId=1",
    "false", "true",
    "103.10.16.100", "103.10.16.220",
    $null, "86400", $null, $null, $null, $null,
    $null,
    $null,
    '[{"start":"103.10.16.100","end":"103.10.16.150","poolId":"1"},{"start":"103.10.16.170","end":"103.10.16.220","poolId":"1"}]',
    $null, $null, $null,
    "VLAN-16", "Test Lab"
)
```

Sample ISC IPv4 — mixed bare range and pool block

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement AddDhcpScope @(
    332,
    "104.10.17.0", 24,
    "ISC IPv4 Mixed",
    "Bare range and pool range mixed",
    "false", "true",
    "104.10.17.100", "104.10.17.220",
    $null, "86400", $null, $null, $null, $null,
    $null,
    '[{"code":"6","value":"8.8.8.8"}]',
    '[{"start":"104.10.17.100","end":"104.10.17.150"},{"start":"104.10.17.170","end":"104.10.17.220","poolId":"1"}]',
    $null, $null, $null,
    "VLAN-17", "Test Lab"
)
```

Sample ISC IPv6

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement AddDhcpScope @(
    488,
    "2001:db8:b::", 64,
    "ISC IPv6 Basic",
    "IPv6 bare range",
    "false", "true",
    $null, $null,
    $null,
    "86400",
    $null,
    "43200",
    $null, $null, $null,
    '[{"code":"23","value":"2001:4860:4860::8888"}]',
    '[{"start":"2001:db8:b::100","end":"2001:db8:b::1ff"}]',
    $null, $null, $null,
    $null, "Test Lab"
)
```

Sample Kea IPv4 — single pool

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement AddDhcpScope @(
    351,
    "110.10.1.0", 24,
    "Kea IPv4 Basic",
    "Single pool with gateway and DNS options",
    "false", "true",
    "110.10.1.100", "110.10.1.200",
    $null,
    "86400",
    $null, $null, $null, $null, $null,
    '[{"code":"3","value":"110.10.1.1"},{"code":"6","value":"8.8.8.8"}]',
    '[{"start":"110.10.1.100","end":"110.10.1.200","poolId":"1"}]',
    $null, $null, $null,
    "VLAN-Kea-1", "Test Lab"
)
```

Sample Kea IPv4 — two ranges in one pool block

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement AddDhcpScope @(
    351,
    "110.10.3.0", 24,
    "Kea IPv4 Shared Pool",
    "Two ranges sharing poolId=1",
    "false", "true",
    "110.10.3.100", "110.10.3.220",
    $null, "86400", $null, $null, $null, $null, $null, $null,
    '[{"start":"110.10.3.100","end":"110.10.3.150","poolId":"1"},{"start":"110.10.3.170","end":"110.10.3.220","poolId":"1"}]',
    $null, $null, $null,
    "VLAN-Kea-3", "Test Lab"
)
```

Sample Kea IPv4 — two separate pool blocks

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement AddDhcpScope @(
    351,
    "110.10.4.0", 24,
    "Kea IPv4 Two Pools",
    "Separate pool blocks per poolId",
    "false", "true",
    "110.10.4.100", "110.10.4.220",
    $null, "86400", $null, $null, $null, $null, $null, $null,
    '[{"start":"110.10.4.100","end":"110.10.4.150","poolId":"1"},{"start":"110.10.4.170","end":"110.10.4.220","poolId":"2"}]',
    $null, $null, $null,
    "VLAN-Kea-4", "Test Lab"
)
```

Sample Kea IPv6

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement AddDhcpScope @(
    351,
    "2003:db8:1::", 64,
    "Kea IPv6 Basic",
    "Single IPv6 pool",
    "false", "true",
    $null, $null,
    $null,
    "86400",
    $null,
    "43200",
    $null, $null, $null,
    '[{"code":"23","value":"2001:4860:4860::8888"}]',
    '[{"start":"2003:db8:1::100","end":"2003:db8:1::1ff","poolId":"1"}]',
    $null, $null, $null,
    "VLAN-Kea-v6-1", "Test Lab"
)
```

Sample CISCO IPv4 — with exclusions and options

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement AddDhcpScope @(
    302,
    "10.200.7.0", 24,
    "CISCO IPv4 Scope",
    "Exclusions and DNS options",
    "false", "true",
    $null, $null,
    $null, $null, $null,
    $null, $null, $null,
    '[{"start":"10.200.7.1","end":"10.200.7.10"},{"start":"192.168.99.50","end":"192.168.99.60"}]',
    '[{"code":"3","value":"10.200.7.1"},{"code":"6","value":"8.8.8.8"},{"code":"15","value":"lab.example.com"}]',
    $null, $null, $null, $null,
    "VLAN-CISCO-7", "Test Lab"
)
```

Sample CISCO IPv6

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement AddDhcpScope @(
    302,
    "2001:db8:200:1::", 64,
    "CISCO IPv6 Scope",
    "Standard lifetimes 12h/24h",
    "false", "true",
    $null, $null,
    $null, $null, $null,
    "43200",
    "86400",
    $null,
    $null,
    '[{"code":"23","value":"2001:4860:4860::8888"}]',
    $null, $null, $null, $null,
    "VLAN-CISCO-v6-1", "Test Lab"
)
```

Sample CISCO ASA IPv4

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement AddDhcpScope @(
    331,
    "1.1.1.0", 24,
    "ipamtest",
    "Full allowed range",
    "false", "true",
    "1.1.1.1",
    "1.1.1.20",
    $null, $null, $null,
    $null, $null, $null,
    $null,
    '[{"code":"3","value":"1.1.1.1"},{"code":"6","value":"8.8.8.8"}]',
    $null, $null, $null, $null,
    "VLAN-ASA-1", "Perimeter Zone"
)
```

# Edit DHCP scope

Edit an existing scope on a DHCP server.

Available since 2026.4

```csharp
/// <summary>
/// Edit an existing DHCP scope on a DHCP server.
/// The scope's network address and CIDR prefix length are fixed and cannot be changed.
/// </summary>
/// <param name="dhcpScopeGroupId">GroupId of the DHCP scope to edit.</param>
/// <param name="description">Optional. Omit to keep the existing description unchanged.</param>
/// <param name="scopeRangeStart">Start of the allocatable IP range. Windows IPv4 and ASA only; omit to keep unchanged.</param>
/// <param name="scopeRangeEnd">End of the allocatable IP range. Windows IPv4 and ASA only; omit to keep unchanged.</param>
/// <param name="offerDelay">Initial offer delay in milliseconds. Windows IPv4 only.</param>
/// <param name="defaultLeaseTime">Default lease time in seconds. Windows/ISC IPv4; Kea IPv4 and IPv6 (maps to valid-lifetime on Kea).</param>
/// <param name="maxLeaseTime">Maximum lease time in seconds. Windows/ISC IPv4 only.</param>
/// <param name="preferredLifeTime">Preferred lifetime in seconds. Windows IPv6 and CISCO IPv6 only; omit to keep unchanged.</param>
/// <param name="validLifeTime">Valid lifetime in seconds. Windows IPv6 and CISCO IPv6 only; omit to keep unchanged.</param>
/// <param name="preference">Preference value. Windows IPv6 only; omit to keep unchanged.</param>
/// <param name="exclusions">JSON array of exclusion ranges. Windows and CISCO only (silently ignored for ISC/Kea/ASA).
/// Replace-all: null keeps existing; "[]" removes all; non-empty array replaces the full set.
/// Each entry: {"start":"x.x.x.x","end":"x.x.x.x"}.</param>
/// <param name="options">JSON array of DHCP options. Windows, CISCO, ISC, Kea.
/// Replace-all: null keeps existing; "[]" removes all; non-empty array replaces the full set.
/// Each entry: {"code":"6","value":"8.8.8.8"}.</param>
/// <param name="ranges">JSON array of address ranges. ISC and Kea only.
/// Replace-all: null keeps existing; non-empty array replaces all ranges.
/// For Kea each entry may include a "poolId" (integer >= 1).
/// Each entry: {"start":"x.x.x.x","end":"x.x.x.x","poolId":"1"}.</param>
/// <param name="sharedNetworkName">Shared network name. ISC and Kea.</param>
/// <param name="vlan">VLAN identifier to associate with the scope.</param>
/// <param name="location">Location label to associate with the scope.</param>
/// <returns>Operation result: "Operation was successful"</returns>
public string EditDhcpScope(
    int dhcpScopeGroupId,
    string description = null,
    string scopeRangeStart = null,
    string scopeRangeEnd = null,
    int? offerDelay = null,
    long? defaultLeaseTime = null,
    long? maxLeaseTime = null,
    long? preferredLifeTime = null,
    long? validLifeTime = null,
    int? preference = null,
    string exclusions = null,
    string options = null,
    string ranges = null,
    string sharedNetworkName = null,
    string vlan = null,
    string location = null)
```

The 16-element positional array passed to `Invoke-SwisVerb`:

| #   | Parameter           | Notes                                                             |
| --- | ------------------- | ----------------------------------------------------------------- |
| 0   | `dhcpScopeGroupId`  | GroupId of the DHCP scope                                         |
| 1   | `description`       | `$null` keeps existing                                            |
| 2   | `scopeRangeStart`   | Windows IPv4 and ASA only; `$null` keeps existing                 |
| 3   | `scopeRangeEnd`     | Windows IPv4 and ASA only; `$null` keeps existing                 |
| 4   | `offerDelay`        | Windows IPv4 only                                                 |
| 5   | `defaultLeaseTime`  | Windows/ISC IPv4; `valid-lifetime` for Kea IPv4 and IPv6          |
| 6   | `maxLeaseTime`      | Windows/ISC IPv4 only                                             |
| 7   | `preferredLifeTime` | Windows IPv6 and CISCO IPv6 only; `$null` keeps existing          |
| 8   | `validLifeTime`     | Windows IPv6 and CISCO IPv6 only; `$null` keeps existing          |
| 9   | `preference`        | Windows IPv6 only; `$null` keeps existing                         |
| 10  | `exclusions`        | Replace-all JSON array; Windows and CISCO; `$null` keeps existing |
| 11  | `options`           | Replace-all JSON array; all server types; `$null` keeps existing  |
| 12  | `ranges`            | Replace-all JSON array; ISC and Kea; `$null` keeps existing       |
| 13  | `sharedNetworkName` | ISC and Kea only                                                  |
| 14  | `vlan`              | Optional                                                          |
| 15  | `location`          | Optional                                                          |

Sample Windows IPv4 — change range, update options, extend lease time

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement EditDhcpScope @(
    501,
    "Updated description",
    "192.168.1.50",
    "192.168.1.250",
    "0",
    "172800",
    "345600",
    $null, $null, $null,
    '[{"start":"192.168.1.1","end":"192.168.1.10"}]',
    '[{"code":"3","value":"192.168.1.1"},{"code":"6","value":"8.8.8.8"}]',
    $null, $null,
    "VLAN-10",
    "Server Room A"
)
```

Sample Windows IPv4 — remove all exclusions

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement EditDhcpScope @(
    501,
    $null,
    $null, $null, $null, $null, $null,
    $null, $null, $null,
    '[]',
    $null, $null, $null,
    $null, $null
)
```

Sample Windows IPv6 — update lifetimes and preference

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement EditDhcpScope @(
    502,
    "Updated IPv6 scope",
    $null, $null, $null, $null, $null,
    "86400",
    "172800",
    "1",
    $null,
    '[{"code":"23","value":"2001:4860:4860::8888"}]',
    $null, $null,
    "VLAN-IPv6-10",
    "Data Center"
)
```

Sample CISCO IPv4 — replace exclusions and options

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement EditDhcpScope @(
    503,
    $null,
    $null, $null, $null, $null, $null,
    $null, $null, $null,
    '[{"start":"10.200.7.1","end":"10.200.7.5"}]',
    '[{"code":"3","value":"10.200.7.1"},{"code":"6","value":"8.8.8.8"},{"code":"15","value":"lab.example.com"}]',
    $null, $null,
    "VLAN-CISCO-7",
    "Test Lab"
)
```

Sample CISCO IPv6 — update lifetimes

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement EditDhcpScope @(
    504,
    $null,
    $null, $null, $null, $null, $null,
    "86400",
    "172800",
    $null, $null,
    '[{"code":"23","value":"2001:4860:4860::8888"}]',
    $null, $null,
    "VLAN-CISCO-v6-1",
    "Test Lab"
)
```

Sample ISC IPv4 — replace ranges and options

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement EditDhcpScope @(
    505,
    $null,
    $null, $null, $null,
    "86400",
    $null, $null, $null, $null, $null,
    '[{"code":"3","value":"101.10.14.1"},{"code":"6","value":"8.8.8.8"}]',
    '[{"start":"101.10.14.50","end":"101.10.14.150"},{"start":"101.10.14.170","end":"101.10.14.200","poolId":"1"}]',
    "Shared Network 1",
    "VLAN-14",
    "Test Lab"
)
```

Sample Kea IPv4 — replace ranges with two pool blocks

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement EditDhcpScope @(
    506,
    $null,
    $null, $null, $null,
    "172800",
    $null, $null, $null, $null, $null,
    '[{"code":"3","value":"110.10.1.1"},{"code":"6","value":"8.8.8.8"}]',
    '[{"start":"110.10.1.50","end":"110.10.1.100","poolId":"1"},{"start":"110.10.1.150","end":"110.10.1.200","poolId":"2"}]',
    $null,
    "VLAN-Kea-1",
    "Test Lab"
)
```

Sample Kea IPv6 — update valid-lifetime and ranges

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement EditDhcpScope @(
    507,
    $null,
    $null, $null, $null,
    "172800",
    $null, $null, $null, $null, $null,
    '[{"code":"23","value":"2001:4860:4860::8888"}]',
    '[{"start":"2003:db8:1::200","end":"2003:db8:1::2ff","poolId":"1"}]',
    $null,
    "VLAN-Kea-v6-1",
    "Test Lab"
)
```

Sample CISCO ASA — update range

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement EditDhcpScope @(
    508,
    $null,
    "1.1.1.5",
    "1.1.1.30",
    $null, $null, $null,
    $null, $null, $null, $null,
    '[{"code":"3","value":"1.1.1.1"},{"code":"6","value":"8.8.8.8"}]',
    $null, $null,
    "VLAN-ASA-1",
    "Perimeter Zone"
)
```

# Delete DHCP scope

Delete an existing scope from IPAM and optionally from the DHCP server.

Available since 2026.4

```csharp
/// <summary>
/// Delete a DHCP scope from IPAM and optionally from the DHCP server.
/// </summary>
/// <param name="scopeId">Group ID of the DHCP scope.</param>
/// <param name="removeCorrespondingSubnets">Whether the corresponding subnets should be removed from IPAM.</param>
/// <param name="deleteFromServer">Whether the scope should be removed from the DHCP server.</param>
/// <returns>Operation result: "Operation was successful"</returns>
public string DeleteDhcpScope(int scopeId, bool removeCorrespondingSubnets = false, bool deleteFromServer = false)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement DeleteDhcpScope @(346, 'true', 'true')
```

# Delete DHCP scopes (bulk)

Delete existing scopes from IPAM and optionally from the DHCP server(s).

Available since 2026.4

```csharp
/// <summary>
/// Delete multiple DHCP scopes from IPAM and optionally from the DHCP server.
/// </summary>
/// <param name="scopeIds">Array of Group IDs of the DHCP scopes.</param>
/// <param name="removeCorrespondingSubnets">Whether the corresponding subnets should be removed from IPAM.</param>
/// <param name="deleteFromServer">Whether the scopes should be removed from the DHCP server.</param>
/// <returns>Operation result: "Operation was successful"</returns>
public string DeleteDhcpScopes(int[] scopeIds, bool removeCorrespondingSubnets = false, bool deleteFromServer = false)
```

Note: Scopes can belong to different servers. If `deleteFromServer` is set to `true`, the verb will try to remove scopes from each server separately, so if a call to any server fails, the rest may still execute properly. Examine the verb output to learn which scopes were not removed.

Sample

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement DeleteDhcpScopes @((220, 222, 224), 'true', 'false')
```

# Add DNS server

```csharp
/// <summary>
/// Add DNS server
/// </summary>
/// <param name="nodeId">Node Id</param>
/// <param name="newCredentialName">New Credential name. If not creating new credentials pass null</param>
/// <param name="newCredentialUserName">New credential user name. If not creating new credentials pass null</param>
/// <param name="newCredentialPassword">New credential password. If not creating new credentials pass null</param>
/// <param name="newCredentialProtocol">New credential protocol. Telnet = 0, SSH = 1. If not creating new credentials pass null. Default value is SSH (1)</param>
/// <param name="newCredentialClientPort">New credential port. If not creating new credentials pass null. Default value is 22</param>
/// <param name="credentialId">Existing credential Id. For new credentials, pass null. For inherit credentials pass -1 (by default)</param>
/// <param name="enableScanning">Is scanning enabled. Default value is true</param>
/// <param name="incrementalZoneTransfer">Is incremental zone transfer enabled. Default value is true</param>
/// <param name="scanInterval">Scan interval in minutes. Default value is 240 minutes</param>
/// <param name="serverType">Type of the DNS server. Unknown = 0, Windows = 1, Bind = 2, Infoblox = 3. Default value is Windows (1)</param>
/// <returns>Operation result: "Operation was successful" or "Operation failed"</returns>
public string AddDnsServer(int nodeId, string newCredentialName, string newCredentialUserName, string newCredentialPassword,
int? newCredentialProtocol = 1, int? newCredentialClientPort = 22, int? credentialId = -1, bool enableScanning = true,
bool incrementalZoneTransfer = true, double scanInterval = 240, int serverType = 1)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement AddDnsServer @(1, "newCredentialName", "username", "password", $null, $null, $null, 1, 1, 240, 1)
```

# Create IP Address reservation on DHCP server

```csharp
Operation affects both IPAM and target DHCP server. When verb returns "Operation was successful" , operation is done on DHCP server side. If it fails, "Operation failed" returns.
/// <summary>
/// Create IP Address reservation on DHCP server
/// </summary>
/// <param name="ipAddressToReserve">IpNode Address</param>
/// <param name="dhcpServerIpAddress">DHCP Server Address</param>
/// <param name="reservationName">ClientName</param>
/// <param name="reservationMAC">Reservation MAC Address. MAC Address must follow this format: 00:00:00:00:00:00"</param>
/// <param name="reservationType">Dhcp Reservation Type.  ReservationType values: "DhcpOnly", "BootpOnly", "Both". Default value is "DhcpOnly"</param>
/// <returns>Operation result: "Operation was successful" or "Operation failed"</returns>
string CreateIpReservation(string ipAddressToReserve, string dhcpServerIpAddress, string reservationName, string reservationMAC, string reservationType = "DhcpOnly")
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.DhcpDnsManagement CreateIpReservation @("199.10.1.1","199.10.1.0","testName", "01:23:45:67:89:AB","DhcpOnly")
```

# Remove IP address reservation from DHCP server

```csharp
/// <summary>
/// Remove IP Address reservation from DHCP
/// </summary>
/// <param name="ipRemoveReservation">IpNode Address</param>
/// <param name="dhcpServerIpAddress">DHCP Server Address</param>
/// <returns>Operation result: "Operation was successful" or "Operation failed"</returns>
string RemoveIpReservation(string ipRemoveReservation, string dhcpServerIpAddress)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.DhcpdnsManagement RemoveIPReservation  @("10.1.1.2", "10.199.1.150")
```

# Get 'A' record an PTR records for DNS zone

When there's no matching A/PTR record pairs - empty list will be returned.
For finding of matching pairs we use query with INNER JOIN.

```csharp
/// <summary>
///  Get A &amp; PTR pair from a specific zone of the given DNS server.
/// </summary>
/// <param name="zoneName">DnsServer Zone name</param>
/// <param name="dnsServerIp">DnsServer address</param>
/// <returns>
/// List of APtrRecordsPair.
/// where APtrRecordPair is type like :
/// {
///     string ARecordName;
///     string ARecordData;
///     string PtrRecordName;
///     string PtrRecordData
/// }
/// </returns>
List<APtrRecordsPair> GetAandPTRrecordsForDnsZone(string zoneName, string dnsServerIp)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.DhcpdnsManagement GetAandPTRrecordsForDnsZone  @("255.in-addr.arpa","10.199.7.82")
```

# Create Custom Property

```csharp
/// <summary>
/// Create new Custom Property (IPAM.AttrDefine entity)
/// </summary>
/// <param name="propertyName">New unique Property name</param>
/// <param name="description">Property Description</param>
/// <param name="maxStringLength">Property ValueDbType size 'nvarchar(maxStringLength)'</param>
/// <param name="attributeType">Custom Property attribute, possible attribute: String, Integer, Datetime, Float and Boolean</param>
/// <param name="linkTitle">Property LinkTitle. Unused, pass null</param>
/// <param name="addToIpAddress">Add to IP addresses. ('True' or 'False' )</param>
/// <param name="addToGroups">Add to groups, supernets, subnets, DHCP servers, scopes and DNS servers, zones. ('True' or 'False' )</param>
/// <returns>Operation result. True='Operation was successful', False='Operation failed'</returns>
public bool AddCustomProperty(string propertyName, string description, int maxStringLength, string attributeType = "String", string linkTitle = "", bool addToIpAddress = false, bool addToGroups = false)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.AttrDefine AddCustomProperty @('Custom_12','description',10,'String','','true','false')
```

# Update custom property

```csharp
/// <summary>
/// Update Custom Property (IPAM.AttrDefine entity)
/// </summary>
/// <param name="propertyName">Property name to update</param>
/// <param name="description">Property Description</param>
/// <param name="maxStringLength">Property ValueDbType size 'nvarchar(maxStringLength)'</param>
/// <param name="linkTitle">Property LinkTitle. Available for AttributeType.URL</param>
/// <param name="addToIpAddress">Add to IP addresses. ('True' or 'False' )</param>
/// <param name="addToGroups">Add to groups, supernets, subnets, DHCP servers, scopes and DNS servers, zones. ('True' or 'False' )</param>
/// <returns>Operation result. True='Operation was successful', False='Operation failed'</returns>
bool UpdateCustomProperty(string propertyName, string description, int maxStringLength, string linkTitle, bool addToIpAddress, bool addToGroups)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.AttrDefine UpdateCustomProperty @('Custom_2','description',10,'','false','false')
```

# Delete Custom Property

```csharp
/// <summary>
/// Delete Custom Property (IPAM.AttrDefine entity)
/// </summary>
/// <param name="propertyName">Property name to delete</param>
/// <returns>Operation result. True='Operation was successful', False='Operation failed'</returns>
bool DeleteCustomProperty(string propertyName)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.AttrDefine DeleteCustomProperty @('Custom_1')
```

# Change Disable Auto Scanning

```csharp
/// <summary>
/// Change DisableAutoScanning flag for a specific Group Node
/// </summary>
/// <param name="groupId">Group Node Id</param>
/// <param name="disableAutoScanning">disableAutoScanning flag value</param>
void ChangeDisableAutoScanning(int groupId, bool disableAutoScanning)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.SubnetManagement ChangeDisableAutoScanning  @(102, "false")
```

# CRUD operations for IPAM.Subnet

Available properties for changing:

| Property name | Type   | Default value    | Create required | Comment                                                                                                      |
| ------------- | ------ | ---------------- | --------------- | ------------------------------------------------------------------------------------------------------------ | --- |
| SubnetId      | int    |                  |                 | [Non editable]                                                                                               |
| ParentId      | int    | 0                |                 |                                                                                                              |
| Address       | string |                  | required        | must not be blank                                                                                            |
| AddressMask   | string |                  |                 | [Non editable]                                                                                               |
| CIDR          | int    |                  | required        | [Non editable] For IpV4 Address CIDR must be greater than 21 and less than or equal to 32. must not be blank |     |
| FriendlyName  | string | 'Address'/'CIDR' |                 | must not be blank                                                                                            |
| Comments      | string | undefined        |                 |                                                                                                              |
| VLAN          | string | undefined        |                 |                                                                                                              |
| Location      | string | undefined        |                 |                                                                                                              |
| ScanInterval  | int    | 240              |                 |                                                                                                              |

Sample

```powershell
Delete: Remove-SwisObject $swis -Uri 'swis://localhost/Orion/IPAM.Subnet/SubnetId=106,ParentId=101'

Update: Set-SwisObject $swis -Uri 'swis://localhost/Orion/IPAM.Subnet/SubnetId=100,ParentId=2' -Properties @{VLAN='test'}

Create: New-SwisObject $swis -EntityType 'IPAM.Subnet' -Properties @{Address='10.199.252.1'; CIDR=24;}
```

# CRUD operations for IPAM.IpNode

Available properties:

| Property name  | Type                   | Default value | Create required | Comment                                                                                                                                                                    |
| -------------- | ---------------------- | ------------- | --------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| IpNodeId       | int                    |               |                 | [Non editable]                                                                                                                                                             |
| SubnetId       | int                    |               | required        | [Non editable]                                                                                                                                                             |
| IPAddress      | string                 |               | required        | [Non editable]                                                                                                                                                             |
| IPMapped       | string                 | undefined     |                 | must be undefined when Status is Available                                                                                                                                 |
| Alias          | string                 | undefined     |                 | must be undefined when Status is Available                                                                                                                                 |
| MAC            | string                 | undefined     |                 | must be undefined when Status is Available <br> must be defined when DHCP Reservation is going to be created MAC Address <br> must follow this format: '00:00:00:00:00:00' |
| DnsBackward    | string                 | undefined     |                 | must be undefined when Status is Available                                                                                                                                 |
| DhcpClientName | string                 | undefined     |                 | must be undefined when Status is Available <br> must be defined when DHCP Reservation is going to be created                                                               |
| Comments       | string                 | undefined     |                 | must be undefined when Status is Available                                                                                                                                 |
| ResponseTime   | int                    | undefined     |                 | [Non editable]                                                                                                                                                             |
| Status         | string (IPNodeStatus)  | "Available"   |                 | IPNodeStatus values: "Used", "Available", "Reserved", "Transient", "Blocked"                                                                                               |
| AllocPolicy    | string (IPAllocPolicy) | undefined     |                 | IPAllocPolicy values: "Static", "Dynamic"                                                                                                                                  |
| SkipScan       | bool                   | false         |                 |                                                                                                                                                                            |

Sample

```powershell
Delete: Remove-SwisObject $swis -Uri 'swis://localhost/Orion/IPAM.IPNode/IpNodeId=2'

Update: Set-SwisObject $swis -Uri 'swis://localhost/Orion/IPAM.IPNode/IpNodeId=2' -Properties @{ Alias = 'test1' }

Create: New-SwisObject $swis -EntityType 'IPAM.IPNode' -Properties @{ SubnetId=22; IPAddress='10.20.30.40' }
```

# CRUD operations for IPAM.IpNodeAttr

By default IPAM.IpNodeAttr doesn't have any predefined properties. User should create custom property before applying CRUD operation to it.

Sample

```powershell
Create: New-SwisObject $swis -EntityType 'IPAM.IPNodeAttr' -Properties @{ IPNodeId = 1; }

Update: Set-SwisObject $swis -Uri 'swis://localhost/Orion/IPAM.IPNode/IpNodeId=1/Custom' -Properties @{ Custom_1 = 'test1' }

Delete: Remove-SwisObject $swis -Uri 'swis://localhost/Orion/IPAM.IPNode/IpNodeId=1/Custom'
```

# CRUD operations for IPAM.GroupNodeAttr

IPAM 4.8 and newer does not use own Custom Fields anymore. Create and Remove operations are not valid anymore. See sample of Update operation

Sample

```powershell
Set-SwisObject $swis -Uri 'swis://localhost/Orion/IPAM.GroupNodeDisplayCustomProperties/GroupId=285/CustomProperties' -Properties @ { Custom_1 = 'test1'  }

```
