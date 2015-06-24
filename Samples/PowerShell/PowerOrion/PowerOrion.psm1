# initialize SWIS connection 
if (Get-PSSnapin -Name SwisSnapin -ErrorAction SilentlyContinue){
    remove-PSSnapin SwisSnapin
}
Add-PSSnapin SwisSnapin

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
        [Alias("Crendential","ID")]
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
        
        write-verbose "$(Get-TimeStamp)Calling New-OrionNode..." 

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
        write-verbose "$(Get-TimeStamp)Adding $IPAddress to Orion Database"
        If ($PSCmdlet.ShouldProcess("$IPAddress","Add Node")) {
                $newNode = New-SwisObject $SwisConnection –EntityType "Orion.Nodes" –Properties $newNodeProps 
                $nodeProps = Get-SwisObject $swis -Uri $newNode
                
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
                    $newNodeSettings = New-SwisObject $swis –EntityType "Orion.NodeSettings" –Properties $nodeSettings
                   Write-Debug "New Node Settings : $newNodeSettings"
                } #end of WMI nodes

            }
        
       write-verbose "$(Get-TimeStamp)Node added with URI = $newNode"

       write-verbose "$(Get-TimeStamp)Now Adding pollers for the node..." 
       $nodeProps = Get-SwisObject $swis -Uri $newNode
       #Loop through all the pollers 
       foreach ($PollerType in $PollerTypes){
             If ($PSCmdlet.ShouldProcess("$PollerTypes","Add Poller")) {
                New-OrionPollerType -PollerType $PollerType -NodeProperties $nodeProps -SwisConnection $SwisConnection
            }          
       }    
    }
    End
    {
         write-verbose "$(Get-TimeStamp)Finishing New-OrionNode..." 
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
     
        write-verbose "$(Get-TimeStamp) Calling Add-OrionDiscoveredInterfaces..." 
    }
    Process
    {        
        # Discover interfaces on the node
        $Interfaces = Invoke-SwisVerb $swis Orion.NPM.Interfaces DiscoverInterfacesOnNode $nodeId
        if ($Interfaces.Result -notlike "Succeed") {
            Write-Warning "$(Get-TimeStamp) Interface discovery failed on Node ID : $NodeId."
        }
        else {
            # Filter out any interface types marked for exclusion
            if ($ExcludedInterfaceType){
                $Interfaces.DiscoveredInterfaces.DiscoveredLiteInterface | Where-Object {$_.ifType -in $ExcludedInterfaceType } | foreach { 
                    $Interfaces.DiscoveredInterfaces.RemoveChild($_) 
                }
            }
            # Add the remaining interfaces
           $result = Invoke-SwisVerb $swis Orion.NPM.Interfaces AddInterfacesOnNode @($nodeId, $Interfaces.DiscoveredInterfaces, "AddDefaultPollers") 
            if ($result.Result -notlike "Succeed") {
                Write-Warning "$(Get-TimeStamp) Adding discovered interfaces failed on Node ID : $NodeId."
            }
        }
    }
    End
    {
         write-verbose "$(Get-TimeStamp) Finishing Add-OrionDiscoveredInterfaces..." 
    }
}

function New-OrionInterface
{
    [CmdletBinding()]
    [OutputType([int])]
    Param
    (
        #SolarWinds Information Service (SWIS) Connection
        [parameter(mandatory=$true)]
        [validatenotnullorempty()]
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
        [int32]$RediscoveryInterval=5,

        [parameter()]
        [validatenotnullorempty()]
        [int32]$StatCollection=10
    )

    Begin{
        
        write-verbose "$(Get-TimeStamp) Calling New-OrionInterface..." 

        $newIfaceProps = @{
          NodeID=$NodeID; # NodeID on which the interface is working on
          InterfaceName=$InterfaceName; # description name of the interface to add
          IfName=$IfName;
          InterfaceIndex=$InterfaceIndex;
          ObjectSubType="SNMP";
          Status=$Status;
          RediscoveryInterval=$RediscoveryInterval;
          PollInterval=$PollInterval;
          StatCollection=$StatCollection;
        }

        $PollerTypes = @("I.Status.SNMP.IfTable","I.StatisticsTraffic.SNMP.Universal","I.StatisticsErrors32.SNMP.IfTable","I.Rediscovery.SNMP.IfTable")
    }
    Process
    {        
        $newIfaceUri = New-SwisObject $swis –EntityType "Orion.NPM.Interfaces" –Properties $newIfaceProps
        $ifaceProps = Get-SwisObject $swis -Uri $newIfaceUri

        # register specific pollers for the node
        $poller = @{
          NetObject="I:"+$ifaceProps["InterfaceID"];
          NetObjectType="I";
          NetObjectID=$ifaceProps["InterfaceID"];
        }
        
       write-verbose "$(Get-TimeStamp)Now Adding pollers for the interface..." 
       $nodeProps = Get-SwisObject $swis -Uri $newNode
       #Loop through all the pollers 
       foreach ($PollerType in $PollerTypes){
            New-OrionPollerType -PollerType $PollerType -NodeProperties $nodeProps -SwisConnection $SwisConnection
       }    
    }
    End
    {
         write-verbose "$(Get-TimeStamp) Finishing New-OrionInterface..." 
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
                   Position=1)]
        $NodeProperties,

         #SolarWinds Information Service (SWIS) Connection
        [parameter(mandatory=$true)]
        [validatenotnullorempty()]
        $SwisConnection
    )

    Begin
    {
        write-verbose "$(Get-TimeStamp) Calling New-PollerType..."
        $poller = @{
            NetObject="N:"+$NodeProperties["NodeID"];
            NetObjectType="N";
            NetObjectID=$NodeProperties["NodeID"];
        }
        $id = $NodeProperties["NodeID"];
    }
    Process
    {
        $poller["PollerType"]=$PollerType;
        $pollerUri = New-SwisObject $SwisConnection -EntityType "Orion.Pollers" -Properties $poller
        
    }
    End
    {
        write-verbose "$(Get-TimeStamp) A $PollerType was added for node ID  $id"
        write-verbose "$(Get-TimeStamp) Finishing New-PollerType..."
    }
}

<#
.Synopsis
   Returns the properties, or the custom properties, of a node monitored by Orion
.DESCRIPTION
   This Cmdlet returns the properties of a node monitored by Orion. It can look up a node based on it's node id. If this is not explicitly available, it can call Get-OrionNodeID
  If passed the  -custom switch it can return

.EXAMPLE
 PS C:\Scripts\Modules\Orion> Get-OrionNodeProperties -NodeID $nodeid -SwisConnection $swis -OrionServer $OrionServer 

.EXAMPLE
  PS C:\Scripts\Modules\Orion> Get-OrionNodeProperties -NodeID $nodeid -SwisConnection $swis -OrionServer $OrionServer -custom

Key                                Value
---                                -----
NodeID                             3
City                               Austin
IsMissionCritical                  False

#>
function Get-OrionNode
{
    [CmdletBinding()]
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
      
        #The IP Address of the node
        [Parameter(Mandatory=$true,
                   ValueFromPipelineByPropertyName=$true,
                   Position=0,
                   Parametersetname="IP")]
        [String]$IPAddress,

        #Orion Server Name
        [parameter(mandatory=$true)]
        [validatenotnullorempty()]
        [string]
        $OrionServer="localhost",

        #SolarWinds Information Service (SWIS) Connection
        [parameter(mandatory=$true)]
        [validatenotnullorempty()]
        [string]
        $SwisConnection,

        #Returns custom properties if set
        [switch]
        $custom
    )

    Begin
    {
        
        if($IPAddress){
            write-debug "$(Get-TimeStamp) The value of "IPAddress" is $IPAddress"
            write-verbose "$(Get-TimeStamp) IP passed, calling Get-OrionNodeID for $IPAddress"
            $ID = Get-OrionNodeID -IPAddress $IPAddress -SwisConnection $SwisConnection
        }else {
            write-debug "$(Get-TimeStamp) The value of ID is $NodeID"
            write-verbose "$(Get-TimeStamp) Integer passed"
            $ID = $NodeID
        }         
           
        if ($custom){
            $uri = "swis://$OrionServer/Orion/Orion.Nodes/NodeID=$ID/CustomProperties"
        } else {
            $uri = "swis://$OrionServer/Orion/Orion.Nodes/NodeID=$ID"
        }
        Write-Debug "$(Get-TimeStamp) The URI is $uri"
    }
    Process
    {
        $nodeProps = Get-SwisObject $swis -Uri $uri
    }
    End
    {        
        write-verbose "$(Get-TimeStamp) Finishing Get-OrionNode..."
        Write-Output (new-object psobject -property $nodeProps)
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
        $SwisConnection
    )

    Begin
    {
        write-verbose "$(Get-TimeStamp)Calling Get-OrionNodeID..."
    }
    Process
    {   
       if (!$all){ #if it's a name or IP passed.
           if ($NodeName){
                write-verbose "$(Get-TimeStamp) Querying Orion Server for Node ID for $NodeName"
                $NodeID = Get-SwisData $SwisConnection "SELECT NodeID FROM Orion.Nodes WHERE Caption=@n" @{n=$NodeName}
            } else
             {
                write-verbose "$(Get-TimeStamp) Querying Orion Server for Node ID for $IPAddress"
                $NodeID = Get-SwisData $SwisConnection "SELECT NodeID FROM Orion.Nodes WHERE IP_Address=@ip" @{ip=$IPAddress}
            }
        } else #-all selected
        {
                write-verbose "$(Get-TimeStamp) Querying Orion Server for all nodes"
                $NodeID = Get-SwisData $SwisConnection "SELECT NodeID, caption FROM Orion.Nodes order by nodeid" 
        } # end of -all

    }
    End
    {
        write-verbose "$(Get-TimeStamp) Finishing Get-OrionNodeID..."
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
        write-verbose "$(Get-TimeStamp) Calling Convert-ip2OrionGuid on $IPAddress"
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
        write-verbose "$(Get-TimeStamp) Finishing Convert-ip2OrionGuid on $IPAddress"
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

        #Orion Server Name
        [parameter(mandatory=$true)]
        [validatenotnullorempty()]
        [string]
        $OrionServer,

        #SolarWinds Information Service (SWIS) Connection
        [parameter(mandatory=$true)]
        [validatenotnullorempty()]
        [string]
        $SwisConnection
    )

    Begin
    {
        write-verbose "$(Get-TimeStamp) Calling Remove-OrionNode..."
        #First get the node ID, either implicitly, or explicitly
        if ($NodeName){  
            
            write-verbose "$(Get-TimeStamp) Node passed, calling Get-OrionNodeID for $NodeName"
            $ID = Get-OrionNodeID -Node $NodeName -SwisConnection $SwisConnection             
        }elseif($IPAddress){
            
            write-verbose "$(Get-TimeStamp) IP passed, calling Get-OrionNodeID for $IPAddress"
            $ID = Get-OrionNodeID -IPAddress $IPAddress -SwisConnection $SwisConnection
        }else {
            
            write-verbose "$(Get-TimeStamp) Integer passed, calling Get-OrionNodeID for $NodeID"
            $ID = $NodeID
        }              
        $uri = "swis://$OrionServer/Orion/Orion.Nodes/NodeID=$ID"
    }    
    Process
    {
        If ($PSCmdlet.ShouldProcess("$uri","Removing Object")) {
                remove-SwisObject $swis -Uri $uri
        }
    }    
    End
    {
        write-verbose "$(Get-TimeStamp) Finishing Remove-OrionNode..."
        $nodeProps
    }
}

<#
.Synopsis
   Gets credentials used by Orion
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
        $SwisConnection             
    )

    Begin
    {
         write-verbose "$(Get-TimeStamp) Calling Get-OrionWMICredential..."
         $Credential=@()
    }
    Process
    {                  
         $Credential = Get-SwisData $SwisConnection "SELECT ID, Name, Description,CredentialOwner FROM Orion.Credential"
    }
    End
    {
        write-verbose "$(Get-TimeStamp)Finishing Get-OrionWMICredential..."      
        write-output $Credential
    }
}

#Helper funcion that returns the datetime in a standard format
function Get-TimeStamp
{
    Get-Date -Format 'yyyy-MM-dd HH:mm:ss :'
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
        write-verbose "$(Get-TimeStamp) Calling Get-IPAddressFromHostName..."
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
        write-verbose "$(Get-TimeStamp) Finishing Get-IPAddressFromHostName..."
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
        write-verbose "$(Get-TimeStamp) Calling Get-HostNamefromIPAddress..."
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
        write-verbose "$(Get-TimeStamp) Finishing Get-HostNamefromIPAddress..."
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
        write-verbose "$(Get-TimeStamp) Calling Test-IsValidIP..."
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

#Code to unload PSSNappin when Module is unloaded
$mInfo = $MyInvocation.MyCommand.ScriptBlock.Module
$mInfo.OnRemove = {
    write-verbose "$(Get-TimeStamp): unloading PowerOrion"
    remove-PSSnapin SwisSnapin
}