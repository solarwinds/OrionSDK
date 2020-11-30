# This sample script demonstrates how to add a new node using CRUD operations.
#
# Please update the hostname and credential setup to match your configuration, and
# information about the node you would like to add for monitoring.

#Install Nuget and SwisPowerShell modules
#On some environments we encountered an issue with executing below command, in that case try adding this command before: [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12, it will set tls version to 1.2
Find-PackageProvider -Name "Nuget"  -RequiredVersion "2.8.5.208" | Install-PackageProvider -Force

#The below line can be deleted if SwisPowerShell is already installed
Install-Module -Name SwisPowerShell -Force 
Import-Module SwisPowerShell -Force

#Decide if you want monitor machine by Agent
$deployAgent = $true

# Connect to SWIS
# Orion Host IP
$hostname = "10.150.16.130"
# Orion username
$username = "admin"
# Orion password
$password = ConvertTo-SecureString -String "123" -AsPlainText -Force
$cred = New-Object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
$swis = Connect-Swis -host $hostname -cred $cred
$engineId = 1

# Get local IP adress
$ip = (
    Get-NetIPConfiguration |
    Where-Object {
        $_.IPv4DefaultGateway -ne $null -and
        $_.NetAdapter.Status -ne "Disconnected"
    }
).IPv4Address.IPAddress

if ($deployAgent) {
    $agentName = $ip
    $hostname = $ip
    # localhost username and password used to deploy agent 
    $machineUsername = "Administrator"
    $machinePassword = "Password1"
    
    Invoke-SwisVerb $swis Orion.AgentManagement.Agent Deploy @(
        $engineId, `
            $agentName, `
            $hostname, `
            $ip, `
            $machineUsername, `
            $machinePassword)
}
else {
    # add a node
    $newNodeProps = @{
        IPAddress     = $ip;
        EngineID      = $engineId;
  
        # SNMP v2 specific
        ObjectSubType = "SNMP";

        SNMPVersion   = 2;

        DNS           = "";
        SysName       = "";
        Caption       = $ip;
    
        # === default values ===

        # EntityType = 'Orion.Nodes'
        # Caption = ''
        # DynamicIP = false
        # PollInterval = 120
        # RediscoveryInterval = 30
        # StatCollection = 10  
    }

    $newNodeUri = New-SwisObject $swis -EntityType "Orion.Nodes" -Properties $newNodeProps
    $nodeProps = Get-SwisObject $swis -Uri $newNodeUri

    # register specific pollers for the node
    $poller = @{
        NetObject     = "N:" + $nodeProps["NodeID"];
        NetObjectType = "N";
        NetObjectID   = $nodeProps["NodeID"];
    }

    # Status
    $poller["PollerType"] = "N.Status.ICMP.Native";
    $pollerUri = New-SwisObject $swis -EntityType "Orion.Pollers" -Properties $poller

    # Response time
    $poller["PollerType"] = "N.ResponseTime.ICMP.Native";
    $pollerUri = New-SwisObject $swis -EntityType "Orion.Pollers" -Properties $poller

    # Details
    $poller["PollerType"] = "N.Details.SNMP.Generic";
    $pollerUri = New-SwisObject $swis -EntityType "Orion.Pollers" -Properties $poller

    # Uptime
    $poller["PollerType"] = "N.Uptime.SNMP.Generic";
    $pollerUri = New-SwisObject $swis -EntityType "Orion.Pollers" -Properties $poller

    # CPU
    $poller["PollerType"] = "N.Cpu.SNMP.CiscoGen3";
    $pollerUri = New-SwisObject $swis -EntityType "Orion.Pollers" -Properties $poller

    # Memory
    $poller["PollerType"] = "N.Memory.SNMP.CiscoGen3";
    $pollerUri = New-SwisObject $swis -EntityType "Orion.Pollers" -Properties $poller
}