# This sample script demonstrates how to execute a query against EOC Classic
# It returns list Uri of Orion Servers added to EOC
# Please update the hostname and credential setup to match your configuration,
# and reference to an existing node.

# This .dll will be created after building OrionSDK.sln
Add-Type -Path "..\..\Src\Contract\bin\Debug\SolarWinds.SDK.Swis.Contract.dll"

# Load SwisPowerShell
Import-Module SwisPowerShell

# Connect to SWIS. EOC Swis uses Windows Account Authentication only
$hostname = "localhost"
$username = "Administrator"
$password = "Password1" | ConvertTo-SecureString -asPlainText -Force

$cred = New-Object SolarWinds.InformationService.Contract2.WindowsCredential("",$username,$password)

$addr = New-Object Uri("net.tcp://$($hostname):17777/SolarWinds/InformationService/EOC")

$tcpBinding = New-Object System.ServiceModel.NetTcpBinding
$tcpBinding.Security.Mode = [System.ServiceModel.SecurityMode]::Transport
$tcpBinding.Security.Transport.ClientCredentialType = [System.ServiceModel.TcpClientCredentialType]::Windows

$swis = New-Object SolarWinds.InformationService.Contract2.InfoServiceProxy($addr, $tcpBinding, $cred)

# Returns list of Orions in EOC. EOC Swis limits available Orions based on Manage Orions access rights to see Orions.
# If user does not have rights to see Orion, query will not return its row
$orionList = Get-SwisData $swis "SELECT Uri FROM EOC.Orion"

Write-Host $orionList
