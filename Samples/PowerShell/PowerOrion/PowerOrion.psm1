# initialize SWIS connection 
<#if (Get-PSSnapin -Name SwisSnapin -ErrorAction SilentlyContinue){
    remove-PSSnapin SwisSnapin
    }
    Add-PSSnapin SwisSnapin
#>
<#
    .Synopsis
    Add a new node to Orion
    .DESCRIPTION
    This cmdlet adds a new node to Orion. The default is an ICMP node, future versions will include SNMP and WMI options
    .EXAMPLE
    New-OrionNode -SwisConnection $swis -IPAddress "10.160.5.83" 
    .EXAMPLE
    $cred = get-OrionWMICredential -SwisConnection $swis | where-Object {$_.Name  -like "Local Admin 2"}
    New-OrionNode -SwisConnection $swis -ObjectSubType WMI -IPAddress 10.160.5.85 -CredentialID $cred.id -Verbose 
#>
function New-OrionNode
{
  [CmdletBinding(
      SupportsShouldProcess=$True
  )]
  [OutputType([int])]
  Param
  (
    #SolarWinds Information Service (SWIS) Connection
    [parameter(mandatory=$true)]
    [validatenotnullorempty()]
    [SolarWinds.InformationService.Contract2.InfoServiceProxy]
    $SwisConnection,
        
    [parameter()]
    [validatenotnullorempty()]
    [ValidateSet("ICMP","SNMPv2","WMI")]
    $ObjectSubType="ICMP",

    #The IP address of the node to be added for monitoring
    [Parameter(Mandatory=$true,
        ValueFromPipelineByPropertyName=$true,
        Position=0,
    Parametersetname="IP")]        
    [Alias("IP")]
    [String]$IPAddress,

    #The IP address of the node to be added for monitoring
    [Parameter(Mandatory=$true,
        Position=0,
    Parametersetname="NodeName")]
    [String]$NodeName,

    #The Polling Engine to add the node to (default = 1)
    [parameter()]
    [validatenotnullorempty()]
    [int32]$engineid=1,

    #The Status of the device (default = 1)
    [parameter()]
    [Alias("Credential","ID")]
    [int32]$CredentialID,

    #The Status of the device (default = 1)
    [parameter()]
    [validatenotnullorempty()]
    [int32]$status=1,

    #Whether the device is Unmanaged or not (default = false)
    [parameter()]
    [validatenotnullorempty()]
    $UnManaged=$false,
        
    [parameter()]
    [validatenotnullorempty()]
    $DynamicIP=$false,

    [parameter()]
    [validatenotnullorempty()]
    $Allow64BitCounters=$true,

    [parameter()]
    [validatenotnullorempty()]
    $Community="public"
  )

  Begin{
        
    Write-Verbose "Starting $($myinvocation.mycommand)"  
        
    $ipGuid = Convert-ip2OrionGuid($IPAddress)
        
    Switch($ObjectSubType)
    {
      "ICMP"{ # add a node
        $newNodeProps = @{
          EntityType="Orion.Nodes";
          IPAddress=$IPAddress;
          IPAddressGUID=$ipGuid;
          Caption=$IPAddress;
          DynamicIP=$DynamicIP;
          EngineID=$engineid;
          Status=$status;
          UnManaged=$UnManaged;
          Allow64BitCounters=$Allow64BitCounters;
          SysObjectID="";
          MachineType="";
          SysName="";
          External="";
          NodeDescription="";
          Location="";
          Contact="";
          IOSImage="";
          IOSVersion=""; 
          Vendor="Unknown";
          VendorIcon="Unknown.gif";
          PercentMemoryUsed="0";
          ObjectSubType="ICMP";                     
        }

        #next define the poller 
        $PollerTypes = @("N.IPAddress.ICMP.Generic","N.ResponseTime.ICMP.Native","N.Status.ICMP.Native")

      }#end of ICMP
                
      "SNMPv2"{ # add a node
        $newNodeProps = @{
          EntityType="Orion.Nodes";
          IPAddress=$IPAddress;
          IPAddressGUID=$ipGuid;
          Caption=$IPAddress;
          DynamicIP=$DynamicIP;
          EngineID=$engineid;
          Status=$status;
          UnManaged=$UnManaged;
          Allow64BitCounters=$Allow64BitCounters;
          Location = "";
          Contact = "";
          NodeDescription="";
          Vendor="";
          IOSImage="";
          IOSVersion="";
          SysObjectID="";
          MachineType="";
          VendorIcon="";
          # SNMP v2 specific
          ObjectSubType="SNMP";
          SNMPVersion=2;
          Community=$Community;
          BufferNoMemThisHour="-2"; 
          BufferNoMemToday="-2"; 
          BufferSmMissThisHour="-2"; 
          BufferSmMissToday="-2"; 
          BufferMdMissThisHour="-2"; 
          BufferMdMissToday="-2"; 
          BufferBgMissThisHour="-2"; 
          BufferBgMissToday="-2"; 
          BufferLgMissThisHour="-2"; 
          BufferLgMissToday="-2"; 
          BufferHgMissThisHour="-2"; 
          BufferHgMissToday="-2"; 
          PercentMemoryUsed="-2"; 
          TotalMemory="-2";                     
        }

                

        #next define the pollers 
        $PollerTypes = @("N.Details.SNMP.Generic","N.Uptime.SNMP.Generic","N.Cpu.SNMP.CiscoGen3","N.Memory.SNMP.CiscoGen3", "N.IPAddress.SNMP.Generic")

      }#end of SNMPv2
      "WMI"{ # add a node
        $newNodeProps = @{
          EntityType="Orion.Nodes";
          IPAddress=$IPAddress;
          IPAddressGUID=$ipGuid;
          Caption="";
          DynamicIP=$DynamicIP;
          EngineID=$engineid;
          Status=$status;
          UnManaged=$UnManaged;
          Allow64BitCounters=$Allow64BitCounters;
          Location = "";
          Contact = "";
          NodeDescription="";
          Vendor="";
          IOSImage="";
          IOSVersion="";
          SysObjectID="";
          MachineType="";
          VendorIcon="";
          # WMI specific
          ObjectSubType="WMI";
          SNMPVersion=0;
          Community="";
          BufferNoMemThisHour="-2"; 
          BufferNoMemToday="-2"; 
          BufferSmMissThisHour="-2"; 
          BufferSmMissToday="-2"; 
          BufferMdMissThisHour="-2"; 
          BufferMdMissToday="-2"; 
          BufferBgMissThisHour="-2"; 
          BufferBgMissToday="-2"; 
          BufferLgMissThisHour="-2"; 
          BufferLgMissToday="-2"; 
          BufferHgMissThisHour="-2"; 
          BufferHgMissToday="-2"; 
          PercentMemoryUsed="-2"; 
          TotalMemory="-2";  
                                                                              
        }
        #check to make sure there is a valid credential ID  
        if(!$CredentialID) {
          $CredentialID = "Please enter the ID of the Orion WMI Credential to be used" 
        }

        #next define the pollers 
        $PollerTypes = @("N.Status.ICMP.Native","N.ResponseTime.ICMP.Native","N.Details.WMI.Vista","N.Uptime.WMI.XP", "N.Cpu.WMI.Windows","N.Memory.WMI.Windows")
      } #end of WMI

    }#end of switch
        
  }
  Process
  {
    write-verbose "Adding $IPAddress to Orion Database"
    If ($PSCmdlet.ShouldProcess("$IPAddress","Add Node")) {
      $newNode = New-SwisObject $SwisConnection -EntityType "Orion.Nodes" -Properties $newNodeProps 
      $nodeProps = Get-SwisObject $SwisConnection -Uri $newNode
                
      #Add credentials for WMI nodes
      if($ObjectSubType = "WMI"){
        #Adding NodeSettings
        $nodeSettings = @{
          NodeID=$nodeProps["NodeID"];
          SettingName="WMICredential";
          SettingValue=($CredentialID.ToString());
        }
        write-debug "Node Settings:  $nodeSettings"
        write-debug "New Node:  $newNode"
        Write-Verbose "Adding WMI Credentials"

        #Creating node settings
        $newNodeSettings = New-SwisObject $SwisConnection -EntityType "Orion.NodeSettings" -Properties $nodeSettings
        Write-Debug "New Node Settings : $newNodeSettings"
      } #end of WMI nodes

    }
        
    write-verbose "Node added with URI = $newNode"

    write-verbose "Now Adding pollers for the node..." 
    $nodeProps = Get-SwisObject $SwisConnection -Uri $newNode
    #Loop through all the pollers 
    foreach ($PollerType in $PollerTypes){
      If ($PSCmdlet.ShouldProcess("$PollerTypes","Add Poller")) {
        New-OrionPollerType -PollerType $PollerType -NodeProperties $nodeProps -SwisConnection $SwisConnection
      }          
    }    
  }
  End
  {
    Write-Verbose "Finishing $($myinvocation.mycommand)"
  }
}

<#
    .Synopsis
    Discovers interfaces on an Orion Node, and adds them for monitoring
    .DESCRIPTION
    Discovers interfaces on an Orion Node, and adds them for monitoring. Possible to exclude certain interfaces, by passing the Interface types as a parameter
    .EXAMPLE
    Add-OrionDiscoveredInterfaces -SwisConnection $swis -NodeId 13 

    This example adds in all interfaces that have been discovered on a node
    .EXAMPLE
    Add-OrionDiscoveredInterfaces -SwisConnection $swis -NodeId 13 -ExcludedInterfaceType 22,101

    This example adds in all interfaces that have been discovered on a node, excluding Serial, and Voice Foreign Exchange Office type interfaces
#>
function Add-OrionDiscoveredInterfaces
{
  [CmdletBinding()]
  [OutputType([int])]
  Param
  (
    #SolarWinds Information Service (SWIS) Connection
    [parameter(mandatory=$true)]
    [validatenotnullorempty()]
    [SolarWinds.InformationService.Contract2.InfoServiceProxy]
    $SwisConnection,
        
    #The Node ID of the node that has the interface to be added for monitoring
    [Parameter(Mandatory=$true,
        ValueFromPipelineByPropertyName=$true,
    Position=0)]
    [Int32]$NodeId, 
        
    [Parameter()]
    [int32[]]$ExcludedInterfaceType       
  )

  Begin{
     
    Write-Verbose "Starting $($myinvocation.mycommand)"  
  }
  Process
  {        
    # Discover interfaces on the node
    $Interfaces = Invoke-SwisVerb $SwisConnection Orion.NPM.Interfaces DiscoverInterfacesOnNode $nodeId
    if ($Interfaces.Result -notlike "Succeed") {
      Write-Warning " Interface discovery failed on Node ID : $NodeId."
    }
    else {
      # Filter out any interface types marked for exclusion
      if ($ExcludedInterfaceType){
        $Interfaces.DiscoveredInterfaces.DiscoveredLiteInterface | Where-Object {$_.ifType -in $ExcludedInterfaceType } | foreach { 
          $Interfaces.DiscoveredInterfaces.RemoveChild($_) 
        }
      }
      # Add the remaining interfaces
      $result = Invoke-SwisVerb $SwisConnection Orion.NPM.Interfaces AddInterfacesOnNode @($nodeId, $Interfaces.DiscoveredInterfaces, "AddDefaultPollers") 
      if ($result.Result -notlike "Succeed") {
        Write-Warning " Adding discovered interfaces failed on Node ID : $NodeId."
      }
    }
  }
  End
  {
    Write-Verbose "Finishing $($myinvocation.mycommand)"  
    return $result
        
  }
}

<#
    .Synopsis
    Adds an interface to an Orion node
    .DESCRIPTION
    Discovers interfaces on an Orion Node. For information on values for InterfaceType, InterfaceTypeName, and InterfaceDescription
    .EXAMPLE
    New-OrionInterface -NodeId 3 -SwisConnection $swis -InterfaceName "GigabitEthernet0/0 · Test" -status 1 -IfName "Gi0/0" -InterfaceIndex 1 -PollInterval 120 -RediscoveryInterval 5 -StatCollection "1"

    
    
#>
function New-OrionInterface
{
  [CmdletBinding()]
  [OutputType([int])]
  Param
  (
    #SolarWinds Information Service (SWIS) Connection
    [parameter(mandatory=$true)]
    [validatenotnullorempty()]
    [SolarWinds.InformationService.Contract2.InfoServiceProxy]
    $SwisConnection,
        
    #The Node ID of the node that has the interface to be added for monitoring
    [Parameter(Mandatory=$true,
        ValueFromPipelineByPropertyName=$true,
    Position=0)]
    [Int32]$NodeId,

    #The Polling Engine to add the node to (default = 1)
    [parameter()]
    [validatenotnullorempty()]
    [string]$InterfaceName="FastEthernet0/0",
    
    [parameter()]
    [validatenotnullorempty()]
    [ValidateSet("ICMP","SNMPv2","WMI")]
    $ObjectSubType="SNMPv2",

    #The Status of the device (default = 1)
    [parameter()]
    [validatenotnullorempty()]
    [int32]$status=0,

        
    [parameter()]
    [validatenotnullorempty()]
    $IfName="Fa0/0",

        
    [parameter()]
    [validatenotnullorempty()]
    [int32]$InterfaceIndex=0,
        
    [parameter()]
    [validatenotnullorempty()]
    [int32]$PollInterval=120,

    [parameter()]
    [validatenotnullorempty()]
    [int32]$RediscoveryInterval=30,

    [parameter()]
    [validatenotnullorempty()]
    [int32]$StatCollection=9,
    
    [parameter()]
    [validatenotnullorempty()]
    [int32]$InterfaceType=6,
    
    [parameter()]
    [validatenotnullorempty()]
    [string]$InterfaceTypeName='ethernetCsmacd',
    
    [parameter()]
    [validatenotnullorempty()]
    [string]$InterfaceTypeDescription='Ethernet',
    
    [parameter()]
    [string]$Caption,
    
    [parameter()]
    [validatenotnullorempty()]
    [int32]$AdminStatus=0,
    
    [parameter()]
    [validatenotnullorempty()]
    [int32]$OperStatus=0,
    
   
    [parameter()]
    [validatenotnullorempty()]
    [string]$statusLED='Up.gif',
    
    [parameter()]
    [validatenotnullorempty()]
    $Unmanaged=$false
  )

  Begin{
    Write-Verbose "Starting $($myinvocation.mycommand)"  
    
    if (-not $Caption){
      $Caption = $InterfaceName
    }
        
    $newIfaceProps = @{
      NodeID=$NodeID; # NodeID on which the interface is working on
      InterfaceName=$InterfaceName; # description name of the interface to add
      IfName=$IfName;
      InterfaceIndex=$InterfaceIndex;
      ObjectSubType=$ObjectSubType;
      Status=$Status;
      RediscoveryInterval=$RediscoveryInterval;
      PollInterval=$PollInterval;
      StatCollection=$StatCollection;
      InterfaceType=$InterfaceType;
      InterfaceTypeName = $InterfaceTypeName;
      Caption =$Caption;
      AdminStatus = $AdminStatus;
      OperStatus = $OperStatus;
      StatusLED = $statusLED;
      Unmanaged = $Unmanaged;
      TypeDescription = $InterfaceTypeDescription;
    }

    $PollerTypes = @("I.Status.SNMP.IfTable","I.StatisticsTraffic.SNMP.Universal","I.StatisticsErrors32.SNMP.IfTable","I.Rediscovery.SNMP.IfTable")
  }
  Process
  {        
    $newIfaceUri = New-SwisObject $SwisConnection -EntityType "Orion.NPM.Interfaces" -Properties $newIfaceProps
    $ifaceProps = Get-SwisObject $SwisConnection -Uri $newIfaceUri

    # register specific pollers for the node
    $poller = @{
      NetObject="I:"+$ifaceProps["InterfaceID"];
      NetObjectType="I";
      NetObjectID=$ifaceProps["InterfaceID"];
    }
      
    <#$node = Get-OrionNode -id $NodeId -swisconnection $SwisConnection 
        Write-Debug "Node is : $node"
      
        $NodeURI = $node.uri
        Write-Debug "Node URI is : $NodeURI"
    #>    write-verbose "Now Adding pollers for the interface..." 
    #$nodeProps = Get-SwisObject $SwisConnection -Uri $NodeURI
    #Loop through all the pollers 
    foreach ($PollerType in $PollerTypes){
      New-OrionPollerType -PollerType $PollerType -InterfaceProperties $ifaceProps -SwisConnection $SwisConnection -PollerObjectType 'Interface'
    }    
  }
  End
  {
    Write-Verbose "Finishing $($myinvocation.mycommand)"
  }
}

<#
    .Synopsis
    Adds a new poller to a node in Orion
    .DESCRIPTION
    This cmdlet addes new pollers (CPU, memory, uptime etc) to nodes in Orion
    .EXAMPLE
    New-OrionPollerType -PollerType "N.ResponseTime.ICMP.Native" -NodeProperties $nodeProps -SwisConnection $SwisConnection

#>
function New-OrionPollerType
{ 
  [CmdletBinding()]
  [OutputType([int])]
  Param
  (
    # The type of poller to add (e.g. N.IPAddress.ICMP.Generic)
    [Parameter(Mandatory=$true,
        ValueFromPipelineByPropertyName=$true,
    Position=0)]
    $PollerType ="N.IPAddress.ICMP.Generic",

    # Node Properties used to build the pollers
    [Parameter(Mandatory=$true,
        ValueFromPipelineByPropertyName=$true,
        ParameterSetName='node',
    Position=1)]
    $NodeProperties,
    
    # Node Properties used to build the pollers
    [Parameter(Mandatory=$true,
        ValueFromPipelineByPropertyName=$true,
        ParameterSetName='interface',
    Position=1)]
    $InterfaceProperties,
    
    [validateset('Node','Interface')]
    $PollerObjectType = 'Node',

    #SolarWinds Information Service (SWIS) Connection
    [parameter(mandatory=$true)]
    [validatenotnullorempty()]
    [SolarWinds.InformationService.Contract2.InfoServiceProxy]
    $SwisConnection
  )

  Begin
  {
    Write-Verbose "Starting $($myinvocation.mycommand)"  
    
    if($PollerType -eq 'node'){
      $poller = @{
        NetObject="N:"+$NodeProperties["NodeID"];
        NetObjectType="N";
        NetObjectID=$NodeProperties["NodeID"];
      }
      $id = $NodeProperties["NodeID"];
    }
    else{
      $poller = @{
        NetObject = "I:" + $InterfaceProperties["InterfaceID"];
        NetObjectType = "I";
        NetObjectID = $InterfaceProperties["InterfaceID"];
      }
      $id = $InterfaceProperties["InterfaceID"];
    }
  }
  Process
  {
    $poller["PollerType"]=$PollerType;
    $pollerUri = New-SwisObject $SwisConnection -EntityType "Orion.Pollers" -Properties $poller
        
  }
  End
  {
    write-verbose " A $PollerType was added for  $id"
    Write-Verbose "Finishing $($myinvocation.mycommand)"
    return $pollerUri
  }
}

<#
    .Synopsis
    Returns the properties, or the custom properties, of a node monitored by Orion
    .DESCRIPTION
    This Cmdlet returns the properties of a node monitored by Orion. It can look up a node based on it's node id. If this is not explicitly available, it can call Get-OrionNodeID
    If passed the  -custom switch it can return

    .EXAMPLE
    Get-OrionNodeProperties -NodeID $nodeid -SwisConnection $swis  

    .EXAMPLE
    Get-OrionNodeProperties -NodeID $nodeid -SwisConnection $swis  -custom

    Key                                Value
    ---                                -----
    NodeID                             3
    City                               Austin
    IsMissionCritical                  False

#>
function Get-OrionNode
{
  [CmdletBinding()]
  [OutputType([psobject])]
  Param
  (
        
    [Parameter(ValueFromPipelineByPropertyName=$true,
    Parametersetname="ID")]
        
    [validatenotnullorempty()]
    [alias("ID")]
    [int32]
    $NodeID,
      
    #The IP Address of the node
    [Parameter(ValueFromPipelineByPropertyName=$true,
    Parametersetname="IP")]
    [String]$IPAddress,


    #SolarWinds Information Service (SWIS) Connection
    [parameter(mandatory=$true)]
    [validatenotnullorempty()]
    [SolarWinds.InformationService.Contract2.InfoServiceProxy]
    $SwisConnection,

    #Returns custom properties if set
    [switch]
    $custom
  )

  Begin
  {
    Write-Verbose "Starting $($myinvocation.mycommand)"  
    $OrionServer = Get-OrionHostFromSwisConnection -swisconnection $SwisConnection
    write-debug " The value of OrionServer is $OrionServer"

    if($IPAddress){
      write-debug " The value of IPAddress is $IPAddress"
      write-verbose " IP passed, calling Get-OrionNodeID for $IPAddress"
      $ID = Get-OrionNodeID -IPAddress $IPAddress -SwisConnection $SwisConnection
    }else {
            
      write-debug " The value of ID is $NodeID"
      write-verbose " Integer passed"
      $ID = $NodeID           
    }
           
        
    if ($custom){
      $uri = "swis://$OrionServer/Orion/Orion.Nodes/NodeID=$ID/CustomProperties"
    } else {
      $uri = "swis://$OrionServer/Orion/Orion.Nodes/NodeID=$ID"
    }
    Write-Debug " The URI is $uri"
  }
  Process
  {
    Write-Verbose " Getting properties at $uri"
    $nodeProps = Get-SwisObject $SwisConnection -Uri $uri
    $properties = New-Object -TypeName psobject -Property $nodeProps
    write-debug " The value of nodeprops is $nodeProps"
    write-debug " The value of properties is $($properties.gettype())"
  }
  End
  {        
    Write-Verbose "Finishing $($myinvocation.mycommand)"
    Write-Output $properties
  }
}

<#
    .Synopsis
    Returns the Node ID for a given node managed in Orion
    .DESCRIPTION
    This CmdLet returns the Node ID for a given node managed in Orion, by looking up either the node name or IP Address. 
    if Passed the -all switch it returns all node IDs, and the associated node caption
    .EXAMPLE
    Get-OrionNodeID -node "lab-hpinsight" -swisconnection $swis
    .EXAMPLE
    Get-OrionNodeID -IPAddress 10.199.1.100 -SwisConnection $swis
    .EXAMPLE 
    $swis = Connect-Swis -UserName admin -Password "" -Hostname 10.160.5.75
    Get-OrionNodeID -Node $TestNode -SwisConnection $swis
    
    3
    .EXAMPLE
    PS C:\Scripts\Modules\Orion> Get-OrionNodeID -all -SwisConnection $swis

    NodeID caption                                                                                                                         
    ------ -------                                                                                                                         
    2 se-cor-whd                                                                                                                      
    3 lab-apc5000                                                                                                                     
    5 ew-2951.ew.lab                                                                                                                  
    10 Tok-2811.lab.tok                                                                                                                
    12 Bas-Meru1500                                                                                                                    
 
#>
function Get-OrionNodeID
{
  [CmdletBinding()]
  [OutputType([int])]
  Param
  (
    ##returns ALL nodes
    [Parameter(Mandatory=$true,
    Parametersetname="All")]
    [switch]
    $all,
        
    #The Caption or Nodename used to reference the entity
    [Parameter(Mandatory=$true,
        ValueFromPipelineByPropertyName=$true,
        Position=0,
    Parametersetname="Name")]
    [validatenotnullorempty()]
    [alias("Node","Caption")]
    [string]
    $NodeName,

    [Parameter(Mandatory=$true,
        ValueFromPipelineByPropertyName=$true,
        Position=0,
    Parametersetname="IP")]
    [validatenotnullorempty()]
    [alias("IP")]
    [String]$IPAddress,
        
    #SolarWinds Information Service (SWIS) Connection
    [parameter(mandatory=$true)]
    [validatenotnullorempty()]
    [SolarWinds.InformationService.Contract2.InfoServiceProxy]
    $SwisConnection
  )

  Begin
  {
    Write-Verbose "Starting $($myinvocation.mycommand)"  
  }
  Process
  {   
    if (!$all){ #if it's a name or IP passed.
      if ($NodeName){
        write-verbose " Querying Orion Server for Node ID for $NodeName"
        $NodeID = Get-SwisData $SwisConnection "SELECT NodeID FROM Orion.Nodes WHERE Caption=@n" @{n=$NodeName}
      } else
      {
        write-verbose " Querying Orion Server for Node ID for $IPAddress"
        $NodeID = Get-SwisData $SwisConnection "SELECT NodeID FROM Orion.Nodes WHERE IP_Address=@ip" @{ip=$IPAddress}
      }
    } else #-all selected
    {
      write-verbose " Querying Orion Server for all nodes"
      $NodeID = Get-SwisData $SwisConnection "SELECT NodeID, caption FROM Orion.Nodes order by nodeid" 
    } # end of -all

  }
  End
  {
    Write-Verbose "Finishing $($myinvocation.mycommand)"
    Return $NodeID
  }
}

<#
    .Synopsis
    Converts an IP address to a Guid
    .DESCRIPTION
    Converts an IP address to a Guid. Used as a helper function by other modules
    .EXAMPLE
    Convert-ip2OrionGuid -ipaddress 127.0.0.1

#>
function Convert-IP2OrionGuid
{

  [CmdletBinding()]
  [OutputType([string])]
  Param
  (
    # Param1 help description
    [Parameter(Mandatory=$true,
        ValueFromPipelineByPropertyName=$true,
    Position=0)]
    [string]
    [alias("IP")]
    $IPAddress
  )    

  Begin
  {
    Write-Verbose "Starting $($myinvocation.mycommand)"  
    $ParsedIP = [System.Net.IPAddress]::Parse($IPAddress)
  }
  Process
  {
    $src = $ParsedIP.GetAddressBytes();
    $data = new-object byte[] 16
    $src.CopyTo($data, $data.Length - $src.Length)

    $dest = new-object byte[] 16
    [Array]::Copy($data, 12, $dest, 0, 4)
    [Array]::Copy($data, 10, $dest, 4, 2)
    [Array]::Copy($data, 8, $dest, 6, 2)
    [Array]::Copy($data, 6, $dest, 8, 2)
    [Array]::Copy($data, 0, $dest, 10, 6)
  }
  End
  {
    Write-Verbose "Finishing $($myinvocation.mycommand)"
    return (New-Object Guid (,$dest)).ToString()
  }    
}

<#
    .Synopsis
    Remove a node from the Orion database
    .DESCRIPTION
    This Cmdlet returns the properties of a node monitored by Orion. It can look up a node based on it's node id. If this is not explicitly available, it can call Get-OrionNodeID
    .EXAMPLE
    $swis = Connect-Swis -UserName admin -Password "" -Hostname 10.160.5.75
    Remove-OrionNode 71 -OrionServer "OrionServer" -SwisConnection $swis

#>
function Remove-OrionNode
{
  [CmdletBinding(SupportsShouldProcess=$True)]
  [OutputType([int])]
  Param
  (
    [Parameter(Mandatory=$true,
        ValueFromPipelineByPropertyName=$true,
        Position=0,
    Parametersetname="ID")]
        
    [validatenotnullorempty()]
    [alias("ID")]
    [int32]
    $NodeID,
       
    #The Caption or Nodename used to reference the entity               
    [Parameter(Mandatory=$true,
        ValueFromPipelineByPropertyName=$true,
        Position=0,
    Parametersetname="Name")]
    [validatenotnullorempty()]
    [alias("Node","Caption")]
    [string]$NodeName,

    #The IP Address of the node
    [Parameter(Mandatory=$true,                   
    Parametersetname="IP")]
    [Alias("IP")]
    [String]$IPAddress,

    #SolarWinds Information Service (SWIS) Connection
    [parameter(mandatory=$true)]
    [validatenotnullorempty()]
    [SolarWinds.InformationService.Contract2.InfoServiceProxy]
    $SwisConnection
  )

  Begin
  {
    Write-Verbose "Starting $($myinvocation.mycommand)"  
        
    $OrionServer = Get-OrionHostFromSwisConnection -swisconnection $SwisConnection
                
    #First get the node ID, either implicitly, or explicitly
    if ($NodeName){  
            
      write-verbose " Node passed, calling Get-OrionNodeID for $NodeName"
      $ID = Get-OrionNodeID -Node $NodeName -SwisConnection $SwisConnection             
    }elseif($IPAddress){
            
      write-verbose " IP passed, calling Get-OrionNodeID for $IPAddress"
      $ID = Get-OrionNodeID -IPAddress $IPAddress -SwisConnection $SwisConnection
    }else {
            
      write-verbose " Integer passed, calling Get-OrionNodeID for $NodeID"
      $ID = $NodeID
    }              
    $uri = "swis://$OrionServer/Orion/Orion.Nodes/NodeID=$ID"
  }    
  Process
  {
    If ($PSCmdlet.ShouldProcess("$uri","Removing Object")) {
      remove-SwisObject $SwisConnection -Uri $uri
    }
  }    
  End
  {
    Write-Verbose "Finishing $($myinvocation.mycommand)"
    $uri
  }
}

<#
    .Synopsis
    Gets ALL credentials used by Orion
    .DESCRIPTION
    Gets all credentials used by Orion to monitor nodes and applications. These are returned as an object, so standard Cmdlets such as Where-Object & Select-Object can be used to filter the data
    .EXAMPLE
    Get-OrionWMICredential -SwisConnection $swis 
    .EXAMPLE
    Get-OrionWMICredential -SwisConnection $swis | where-Object {$_.Name  -like "Local Admin 1"} | select id
#>
function Get-OrionWMICredential
{
  [CmdletBinding()]
  [OutputType([int])]
  Param
  (
    #SolarWinds Information Service (SWIS) Connection
    [parameter(mandatory=$true)]
    [validatenotnullorempty()]
    [SolarWinds.InformationService.Contract2.InfoServiceProxy]
    $SwisConnection           
  )

  Begin
  {
    Write-Verbose "Starting $($myinvocation.mycommand)"  
    $Credential=@()
  }
  Process
  {                  
    $Credential = Get-SwisData $SwisConnection "SELECT ID, Name, Description,CredentialOwner FROM Orion.Credential"
  }
  End
  {
    Write-Verbose "Finishing $($myinvocation.mycommand)"    
    write-output $Credential
  }
}


<#
    .Synopsis
    Returns an IP appddress based on a DNS resolution
    .DESCRIPTION
    This function does a forward DNS lookup to resolve a host back to an IP Address
    .EXAMPLE
    Get-IPAddressFromHostName -NodeName server.domain.com
    .EXAMPLE
    Get-IPAddressFromHostName -NodeName google.com -Verbose
#>
function Get-IPAddressFromHostName
{
  [CmdletBinding()]
  [OutputType([string])]
  Param
  (
    #NodeName to be resolved via DNS
    [Parameter(Mandatory=$true,
        ValueFromPipelineByPropertyName=$true,
    Position=0)]
    [string]
    [alias("Node","Caption")]
    $NodeName
  )

  Begin        
  {
    Write-Verbose "Starting $($myinvocation.mycommand)"  
  }
  Process
  {
    try {
      $result = [System.Net.Dns]::GetHostAddresses($NodeName)
    } Catch {
      Write-Warning ("{0}" -f $_.Exception.Message)
    }
  }
  End
  {
    Write-Verbose "Finishing $($myinvocation.mycommand)"
    return $result.IPAddressToString
  }
}

<#
    .Synopsis
    Returns an IP appddress based on a DNS resolution
    .DESCRIPTION
    This function does a reverse DNS lookup to resolve  an IP Address back to a hostname 
    .EXAMPLE
    Get-HostNamefromIPAddress 10.110.60.213
    .EXAMPLE
    Get-HostNamefromIPAddress 10.110.60.213 -Verbose
  
#>
function Get-HostNamefromIPAddress
{
  [CmdletBinding()]
  [OutputType([string])]
  Param
  (
    #NodeName to be resolved via DNS
    [Parameter(Mandatory=$true,
        ValueFromPipelineByPropertyName=$true,
    Position=0)]
    [string]
    [alias("IP")]
    $IPAddress
  )

  Begin        
  {
    Write-Verbose "Starting $($myinvocation.mycommand)"  
  }
  Process
  {
    try {
      $result = [System.Net.Dns]::GetHostEntry($IPAddress)
    } Catch {
      Write-Warning ("{0}" -f $_.Exception.Message)
    }
  }
  End
  {
    Write-Verbose "Finishing $($myinvocation.mycommand)"
    return $result.hostname
  }
}

<#
    .Synopsis
    Checks whether an IP address is valid or not
    .DESCRIPTION
    This function uses the the [ipaddress] type accelerator to test for IPv4 or IPv6 address validity. Returns true or false
    .EXAMPLE
    Test-IsValidIP 10.110.60.213
    True
    .EXAMPLE
    Test-IsValidIP 10.110.60.278
    WARNING: 10.110.60.278: Cannot convert value "10.110.60.278" to type "System.Net.IPAddress". Error: "An invalid IP address was specified."
    False
    .EXAMPLE
    Test-IsValidIP -IPAddress fe80::18be:22e5:f591:4a5%25
    True
#>
Function Test-IsValidIP 
{
 
  [CmdletBinding()]
 
  Param (
    [parameter(ValueFromPipeLine=$True,ValueFromPipeLineByPropertyName=$True)]
    [Alias("IP")]
    [string]$IPAddress
  )
  Begin        
  {
    Write-Verbose "Starting $($myinvocation.mycommand)"  
  }
  Process {
    Try {
      [ipaddress]$IPAddress | Out-Null
      Write-Output $True
    } Catch {
      Write-Warning ("{0}: {1}" -f $IPAddress,$_.Exception.Message)
      Write-Output $False
    }
  }
}

<#
    .Synopsis
    Extracts the name of the Orion server from a Swis connections
    .DESCRIPTION
    Long description
    .EXAMPLE
    Example of how to use this cmdlet
    .EXAMPLE
    Another example of how to use this cmdlet
#>
function Get-OrionHostFromSwisConnection
{
  [CmdletBinding()]
  [Alias()]
  [OutputType([string])]
  Param
  (
    # Swis Connection that from which to get the Orion Server Name
    [Parameter(Mandatory=$true,
        ValueFromPipelineByPropertyName=$true,
    Position=0)]
    [SolarWinds.InformationService.Contract2.InfoServiceProxy]
    $swisconnection    
  )

  Begin
  {
    Write-Verbose "Starting $($myinvocation.mycommand)"  
  }
  Process
  {
    try
    {
      $OrionHost = $swisconnection.ChannelFactory.Endpoint.Address.Uri.Host
    }
    catch 
    {
      Write-Error "Unable to Parse Host"
    }
        
  }
  End
  {
    Write-Verbose "Finishing $($myinvocation.mycommand)"
    Write-Output $OrionHost
  }
}

<#
    .Synopsis
    Returns the next available IP address from Orion
    .DESCRIPTION
    This returns the IP & subnet, that are next available in SolarWinds IPAM
    .EXAMPLE
    Get-OrionNextAvailableIPAddress -swisconnection $swis

    DisplayName                                                                                          Subnet                                                                                              
    -----------                                                                                          ------                                                                                              
    192.168.1.2                                                                                          192.168.1.0 /24 
    .EXAMPLE
    Get-OrionNextAvailableIPAddress -swisconnection $swis -Subnet DMZ

    DisplayName                                                                                          Subnet                                                                                              
    -----------                                                                                          ------                                                                                              
    192.168.2.2                                                                                          DMZ      
    .EXAMPLE
    Get-OrionNextAvailableIPAddress -swisconnection $swis -Subnet %160.2%

    DisplayName                                                                                          Subnet                                                                                              
    -----------                                                                                          ------                                                                                              
    10.160.2.2                                                                                           10.160.2.0 /24  
#>
function Get-OrionNextAvailableIPAddress
{
  [CmdletBinding()]
  [Alias()]
  [OutputType([string])]
  Param
  (
    # Swis Connection that from which to get the Orion Server Name
    [Parameter(Mandatory=$true,
        ValueFromPipelineByPropertyName=$true,
    Position=0)]
    [SolarWinds.InformationService.Contract2.InfoServiceProxy]
    $swisconnection,
        
    #single string containing the text describing the subnet name. Use % as wildcard
    [validatenotnullorempty()]
    [String]
    $Subnet
  )

  Begin
  {
    Write-Verbose "Starting $($myinvocation.mycommand)"
        
  }
  Process
  {
    #if a subnet is specificed get the first IP in that subnet, else just return the first overall
    if (!$Subnet){
      $IPAddress = Get-SwisData $SwisConnection "SELECT TOP 1  I.DisplayName , I.Subnet.DisplayName as Subnet FROM IPAM.IPNode I WHERE Status=2" 
    } else {
      $IPAddress = Get-SwisData $SwisConnection  "SELECT TOP 1  I.DisplayName , I.Subnet.DisplayName as Subnet FROM IPAM.IPNode I WHERE Status=2 AND I.Subnet.DisplayName like @subnet" @{subnet=$Subnet} 
    }       
  }
  End
  {
    Write-Verbose "Finishing $($myinvocation.mycommand)"
    Write-Output $IPAddress 
  }
}

<#
    .Synopsis
    Adds new custom properties to different Orion objects
    .DESCRIPTION
    This function calls CreateCustomProperty or CreateCustomPropertyWithValues, to create different custom properties, of different types for different objects.
    Optionally it can add a list of specified values
    .EXAMPLE
    New-OrionCustomProperty -swisconnection $swis -PropertyName "Test1" -BaseType Orion.NodesCustomProperties
    .EXAMPLE
    [string[]]$values = "QA", "Dev", "Prod"
    New-OrionCustomProperty -swisconnection $swis -PropertyName "AppType" -BaseType Orion.APM.ApplicationCustomProperties -values $values
#>
function New-OrionCustomProperty
{
  [CmdletBinding()]
  [Alias()]
  [OutputType([int])]
  Param
  (
    [Parameter(Mandatory=$true,
        ValueFromPipelineByPropertyName=$true,
        ValueFromPipeline=$true,
    Position=0)]
    [SolarWinds.InformationService.Contract2.InfoServiceProxy]
    $swisconnection,

    #The object type the custom property will be assigned to
    [Parameter(Mandatory=$true,
        ValueFromPipeline=$true,
        ValueFromPipelineByPropertyName=$true,
    Position=1)]
    [validateset("Orion.APM.ApplicationCustomProperties",
        "Orion.GroupCustomProperties",
        "Orion.NPM.InterfacesCustomProperties",
        "Orion.ReportsCustomProperties",
        "Orion.NodesCustomProperties",
        "Orion.AlertConfigurationsCustomProperties",
    "Orion.VolumesCustomProperties")]

    [string]
    $BaseType = "Orion.NodesCustomProperties",

    #the name of the property.        
    [Parameter(Mandatory=$true,
        ValueFromPipeline=$true,
        ValueFromPipelineByPropertyName=$true,
    Position=2)]
    [validatenotnullorempty()]
    [string]    
    $PropertyName,


    # a description of the property to be shown in editing UI.
    [Parameter(ValueFromPipelineByPropertyName=$true,
        ValueFromPipeline=$true,
    Position=3)]
    [string] 
    $Description,

    #the data type for the custom property. 
    [validateset('string', 'integer', 'datetime', 'single', 'double', 'boolean')]
    $ValueType = 'string', 

    # for string types, this is the maximum length of the values, in characters. Ignored for other types.
    [int]
    $Size = 4000,

    #Currently unused, pass null.
    $ValidRange = $null,

    #  Currently unused, pass null.
    $Parser = $null,

    # Currently unused, pass null.
    $Header = $null,

    #Currently unused, pass null.
    $Alignment = $null,

    # Currently unused, pass null.
    $Format = $null,

    # Currently unused, pass null.
    $Units = $null,

    # optional, restricts a custom property to a certain set of values
    [string[]]
    $values,

    # Optional. You can pass null for this.
    $Usages = $null, 

    # Optional. Defaults to false. If set to true, the Add Node wizard in the Orion web console will require that a value for this custom property be specified at node creation time.
    $Mandatory,

    #Optional. You can pass null for this. If you provide a value, this will be the default value for new nodes.
    $Default = $null
  )

  Begin
  {
    Write-Verbose "Starting $($myinvocation.mycommand)"
  }
  Process
  {
    #if there are no values create standard verb
    if ($values){
      Write-Verbose "$values passed in array"
      $result = Invoke-SwisVerb $swisconnection $BaseType CreateCustomPropertyWithValues @( $PropertyName,
        $Description, 
        $ValueType, 
        $size, 
        $ValidRange,
        $Parser,
        $Header, 
        $Alignment, 
        $Format, 
        $units,  
        $values,
        $Usages
        $Mandatory,
      $Default)
    } else
    {
      Write-Verbose "No values array passed"
      $result = Invoke-SwisVerb $swisconnection $BaseType CreateCustomProperty @( $PropertyName,
        $Description, 
        $ValueType, 
        $size, 
        $ValidRange,
        $Parser,
        $Header, 
        $Alignment, 
        $Format, 
        $units,                                                                                       
        $Usages
        $Mandatory,
      $Default)
    }

  } #end of process
  End
  {
    Write-Verbose "Finishing $($myinvocation.mycommand)"
    Write-Output $result
  }
}

<#
    .Synopsis
    Returns the Application ID for an assigned template, given it's name
    .DESCRIPTION
    Returns the Application ID for an assigned template, given it's name
    .EXAMPLE
    Get-Get-OrionApplicationTemplateId -ApplicationName 'apache' -SwisConnection $swis
   
    6
#>
function Get-OrionApplicationTemplateId
{
  [CmdletBinding()]
  [Alias()]
  [OutputType([int])]
  Param
  (
    # Param1 help description
    [Parameter(mandatory=$true)]
    [validatenotnullorempty()]
    [string]
    $ApplicationName,

    #SolarWinds Information Service (SWIS) Connection
    [parameter(mandatory=$true)]
    [validatenotnullorempty()]
    [SolarWinds.InformationService.Contract2.InfoServiceProxy]
    $SwisConnection
  )

  Begin
  {
    Write-Verbose "Starting $($myinvocation.mycommand)" 
  }
  Process
  {
    $ApplicationTemplateId = Get-SwisData $SwisConnection "SELECT ApplicationTemplateID FROM Orion.APM.ApplicationTemplate WHERE Name=@ApplicationName" @{ ApplicationName = $ApplicationName }
    if (!$applicationTemplateId) {
      Write-Error "Can't find template with name '$ApplicationName'."
        
    }
  }
  End
  {
    Write-Output $ApplicationTemplateId
    Write-Verbose "Finishing $($myinvocation.mycommand)" 
    
  }
} #end of Get-Get-OrionApplicationTemplateId

<#
    .Synopsis
    Gets ALL credentials used by Orion
    .DESCRIPTION
    Gets all credentials used by Orion to monitor nodes and applications. These are returned as an object, so standard Cmdlets such as Where-Object & Select-Object can be used to filter the data
    .EXAMPLE
    Get-OrionWMICredential -SwisConnection $swis 
    .EXAMPLE
    Get-OrionWMICredential -SwisConnection $swis | where-Object {$_.Name  -like "Local Admin 1"} | select id
#>
function Get-OrionApplicationCredential
{
  [CmdletBinding()]
  [OutputType([int])]
  Param
  (
    #SolarWinds Information Service (SWIS) Connection
    [parameter(mandatory=$true)]
    [validatenotnullorempty()]
    [SolarWinds.InformationService.Contract2.InfoServiceProxy]
    $SwisConnection,
        
    [parameter(mandatory=$true)]
    [validatenotnullorempty()]
    [String]
    $credential           
  )

  Begin
  {
    Write-Verbose "Starting $($myinvocation.mycommand)"  
         
  }
  Process
  {                  
    $credentialSetId = Get-SwisData $SwisConnection "SELECT ID FROM Orion.Credential WHERE CredentialOwner='APM' AND Name=@credential" @{ credential = $credential }
    if (!$credentialSetId) {
      Write-error "Can't find credential with name '$credential'."

    }
  }
  End
  {
    write-output $credentialSetId
    Write-Verbose "Finishing $($myinvocation.mycommand)"    
    
  }
}


#Code to unload PSSNappin when Module is unloaded
$mInfo = $MyInvocation.MyCommand.ScriptBlock.Module
$mInfo.OnRemove = {
  write-verbose "Unloading PowerOrion"
  remove-PSSnapin SwisSnapin
}