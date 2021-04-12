---
title: IPAM 4.7 API
---

Starting with IPAM 4.6, an API is available for managing IP addresses.

## Add PTR record

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

## Remove PTR Record

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

## Get first available IP Address for specific subnet

Method returns first available IP node for the existing subnet.
Error will be returned if non-existing subnet will be specified.
It doesn't change status of the returned node.

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

## Get first available IP Address for specific subnet in specific Hierarchy group

Method returns first available IP node for the existing subnet in the specific Hierarchy group.
Error will be returned if non-existing subnet will be specified. It doesn't change status of the returned node.

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

## Change IpNode Status

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

## Change IpNode Status for specific Hierarchy group

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

## IP address reservation

When reservation time expires IP node status is set to available.

```csharp
/// <summary>
/// Start IpAddress Reservation
/// </summary>
/// <param name="subnetAddress">Subnet IpAddress. Like "199.10.1.1"</param>
/// <param name="subnetCidr">Subnet CIDR</param>
/// <param name="reservationTimeInMinutes">Reservation Time In Minutes. Default value is "10"</param>
/// <returns>Reserved IpAddress</returns>
string StartIpReservation(string subnetAddress, string subnetCidr, int reservationTimeInMinutes = 10)
  
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
Invoke-SwisVerb $swis IPAM.SubnetManagement StartIpReservation @("199.10.1.0", "24", "15")
  
Invoke-SwisVerb $swis IPAM.SubnetManagement FinishIpReservation @("199.10.1.1", "Reserved")
 
Invoke-SwisVerb $swis IPAM.SubnetManagement CancelIpReservation @("199.10.1.1")
```  

## IP address reservation for specific Hierarchy group

When reservation time expires IP node status is set to available.

```csharp
/// <summary>
/// Start IpAddress Reservation if it exists into specific Hierarchy group.
/// </summary>
/// <param name="subnetAddress">Subnet IpAddress. Like "199.10.1.1"</param>
/// <param name="subnetCidr">Subnet CIDR</param>
/// <param name="hierarchyGroup">Hierarchy group name</param>
/// <param name="reservationTimeInMinutes">Reservation Time In Minutes. Default value is "10"</param>
/// <returns>Reserved IpAddress</returns>
public string StartIpReservationForGroup(string subnetAddress, string subnetCidr, string hierarchyGroup, int reservationTimeInMinutes = 10)
  
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
Invoke-SwisVerb $swis IPAM.SubnetManagement StartIpReservationForGroup @("199.10.1.0", "24", "Hierarchy Group", "15")

Invoke-SwisVerb $swis IPAM.SubnetManagement FinishIpReservationForGroup @("199.10.1.1", "Reserved", "Hierarchy Group")

Invoke-SwisVerb $swis IPAM.SubnetManagement CancelIpReservationForGroup @("199.10.1.1", "Hierarchy Group")
```

## Create new subnet

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

## Create new subnet for Hierarchy group

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

## Create new IPv6 subnet

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

## Create new IPv6 subnet for specific Hierarchy group

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

## Add DNS 'AAAA' record for IP address

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

## Change DNS 'AAAA' record for IP address

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

## Remove DNS 'AAAA' record for IP address

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

## Add DNS 'A' record for IP address

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

## Change DNS 'A' record for IP address

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

## Remove DNS 'A' record for IP address

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

## Add 'A' record with associated PTR for zone

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

## Add PTR record

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

## Remove PTR record

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

## Add PTR To DNS 'A' record

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

## Create IP Address reservation on DHCP server

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

## Remove IP address reservation from DHCP server

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

## Get 'A' record an PTR records for DNS zone

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

## Create Custom Property

```csharp
/// <summary>
/// Create new Custom Property (IPAM.AttrDefine entity)
/// </summary>
/// <param name="propertyName">New unique Property name</param>
/// <param name="description">Property Description</param>
/// <param name="maxStringLength">Property ValueDbType size 'nvarchar(maxStringLength)'</param>
/// <param name="attributeType">Property AttributeType.  AttributeType values: "Text", "Url"</param>
/// <param name="linkTitle">Property LinkTitle. Available for AttributeType.URL</param>
/// <param name="addToIpAddress">Add to IP addresses. ('True' or 'False' )</param>
/// <param name="addToGroups">Add to groups, supernets, subnets, DHCP servers, scopes and DNS servers, zones. ('True' or 'False' )</param>
/// <returns>Operation result. True='Operation was successful', False='Operation failed'</returns>
bool AddCustomProperty(string propertyName, string description, int maxStringLength, string attributeType = "Text", string linkTitle = "", bool addToIpAddress = false, bool addToGroups = false)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.AttrDefine AddCustomProperty @('Custom_12','description',10,'Text','','false','false')
```

## Update custom property

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

## Reorder custom property

```csharp
/// <summary>
/// Resequence Custom Property (IPAM.AttrDefine entity)
/// </summary>
/// <param name="propertyName">Property name to Resequence</param>
/// <param name="moveUp">Resequence operation {Up or Down}. True=Up; False=Down</param>
/// <returns>Operation result. True='Operation was successful', False='Operation failed'</returns>
bool ResequenceCustomProperty(string propertyName, bool moveUp)
```

Sample

```powershell
Invoke-SwisVerb $swis IPAM.AttrDefine ResequenceCustomProperty @('Custom_2','false')
```

## Delete Custom Property

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

## Change Disable Auto Scanning

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

## CRUD operations for IPAM.Subnet

Available properties for changing:

| Property name            | Type   | Default value    | Create required | Comment           |
|--------------------------|--------|------------------|-----------------|-------------------|
| SubnetId                 | int    |                  |                 | [Non editable]    |
| ParentId                 | int    | 0                |                 |                   |
| Address                  | string |                  | required        | must not be blank |
| AddressMask              | string |                  |                 | [Non editable]    |
| CIDR                     | int    |                  | required        | [Non editable] For IpV4 Address CIDR must be greater than 21 and less than or equal to 32. must not be blank|                  |
| FriendlyName             | string | 'Address'/'CIDR' |                 | must not be blank |
| Comments                 | string | undefined        |                 |                   |
| VLAN                     | string | undefined        |                 |                   |
| Location                 | string | undefined        |                 |                   |
| ScanInterval             | int    | 240              |                 |                   |

Sample

```powershell
Delete: Remove-SwisObject $swis -Uri 'swis://localhost/Orion/IPAM.Subnet/SubnetId=106,ParentId=101'
 
Update: Set-SwisObject $swis -Uri 'swis://localhost/Orion/IPAM.Subnet/SubnetId=100,ParentId=2' -Properties @{VLAN='test'}

Create: New-SwisObject $swis -EntityType 'IPAM.Subnet' -Properties @{Address='10.199.252.1'; CIDR=24;}
```

## CRUD operations for IPAM.IpNode

Available properties:

| Property name  | Type                   | Default value | Create required | Comment |
|----------------|------------------------|---------------|-----------------|---------|
| IpNodeId       | int                    |               |                 | [Non editable] |
| SubnetId       | int                    |               | required        | [Non editable] |
| IPAddress      | string                 |               | required        | [Non editable] |
| IPMapped       | string                 | undefined     |                 | must be undefined when Status is Available |
| Alias          | string                 | undefined     |                 | must be undefined when Status is Available |
| MAC            | string                 | undefined     |                 | must be undefined when Status is Available   <br /> must be defined when DHCP Reservation is going to be created MAC Address <br /> must follow this format: '00:00:00:00:00:00' |
| DnsBackward    | string                 | undefined     |                 | must be undefined when Status is Available |
| DhcpClientName | string                 | undefined     |                 | must be undefined when Status is Available   <br /> must be defined when DHCP Reservation is going to be created |
| Comments       | string                 | undefined     |                 | must be undefined when Status is Available |
| ResponseTime   | int                    | undefined     |                 | |
| Status         | string (IPNodeStatus)  | "Available"   |                 | IPNodeStatus values: "Used", "Available", "Reserved", "Transient", "Blocked" |
| AllocPolicy    | string (IPAllocPolicy) | undefined     |                 | IPAllocPolicy values: "Static", "Dynamic" |
| SkipScan       | bool                   | true          |                 |  |

Sample

```powershell
Delete: Remove-SwisObject $swis -Uri 'swis://localhost/Orion/IPAM.IPNode/IpNodeId=2'
 
Update: Set-SwisObject $swis -Uri 'swis://localhost/Orion/IPAM.IPNode/IpNodeId=2' -Properties @{ Alias = 'test1' }
  
Create: New-SwisObject $swis -EntityType 'IPAM.IPNode' -Properties @{ SubnetId=22; IPAddress='10.20.30.40' }
```

## CRUD operations for IPAM.IpNodeAttr

By default IPAM.IpNodeAttr doesn't have any predefined properties.
User should create custom property before applying CRUD operation to it.

Sample

```powershell
Create: New-SwisObject $swis -EntityType 'IPAM.IPNodeAttr' -Properties @{ IPNodeId = 1; }

Update: Set-SwisObject $swis -Uri 'swis://localhost/Orion/IPAM.IPNode/IpNodeId=1/Custom' -Properties @{ Custom_1 = 'test1' }

Delete: Remove-SwisObject $swis -Uri 'swis://localhost/Orion/IPAM.IPNode/IpNodeId=1/Custom'
```

## CRUD operations for IPAM.GroupNodeAttr

By default IPAM.GroupNodeAttr doesn't have any predefined properties.
User should create custom property before applying CRUD operation to it.

Sample

```powershell
Create: New-SwisObject $swis -EntityType 'IPAM.GroupNodeAttr' -Properties @{ GroupId = 101; Custom_1 = 'initialValue'; }

Update: Set-SwisObject $swis -Uri 'swis://localhost/Orion/IPAM.GroupReport/GroupId=101/Custom' -Properties @{ Custom_1 = 'test1' }

Delete: Remove-SwisObject $swis -Uri 'swis://localhost/Orion/IPAM.GroupReport/GroupId=101/Custom'  
```
