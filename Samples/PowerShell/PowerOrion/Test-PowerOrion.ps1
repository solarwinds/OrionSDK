#Module Name
$modulename = "PowerOrion"
#Display -Verbose by default
#$VerbosePreference ="continue"
$VerbosePreference ="silentlycontinue"

$TestNode="10.160.5.58"

$OrionServer ="10.160.5.75"

cls

#perform a clean load of the module
if(Get-Module -Name $modulename){
    Remove-Module -Name PowerOrion -Force
}
Import-Module .\PowerOrion.psm1

$swis = Connect-Swis -UserName admin -Password "" -Hostname 10.160.5.75
$cred = get-OrionWMICredential -SwisConnection $swis | where-Object {$_.Name  -like "Local Admin 2"}
 Get-OrionWMICredential -SwisConnection $swis

Get-OrionNodeID -all -SwisConnection $swis 
 Get-OrionNode -NodeID 3 -SwisConnection $swis -OrionServer $OrionServer -Verbose


New-OrionNode -SwisConnection $swis -IPAddress $TestNode -ObjectSubType SNMPv2 
Remove-OrionNode 92 -OrionServer $OrionServer -SwisConnection $swis -Verbose 

$nodes | select nodeid | Get-orionNode -SwisConnection $swis -OrionServer $OrionServer

New-OrionNode -SwisConnection $swis -ObjectSubType WMI -IPAddress $TestNode -CredentialID $cred.id -Verbose 

New-OrionNode -SwisConnection $swis -ObjectSubType 