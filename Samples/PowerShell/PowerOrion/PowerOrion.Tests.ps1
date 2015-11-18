#Requires -Version 3.0 
<# 
  
   .DESCRIPTION   
    This script contains the pester tests used to validate the PowerOrion module (https://github.com/solarwinds/OrionSDK)    

   .NOTES 
    Name: PowerOrion.Tests.ps1
    Author: Michael Halpin 
    Date: 03/11/2015
    Keywords: 
   .LINK 
    http://michaelhalpin.azurewebsites.net/

#> 


Import-Module C:\repo\Samples\PowerShell\PowerOrion 
$OrionHost = "orion"
$swis = Connect-Swis -UserName admin -Password '' -Hostname $OrionHost
InModuleScope PowerOrion{
      
    Describe "Get-OrionHostFromSwisConnection" {
        Context 'When a proper SWIS connection is passed' {
            It "extracts the Orion Host from a Swis Connection" {
                $OrionHost = "Orion"
                $swis = Connect-Swis -UserName admin -Password '' -Hostname $OrionHost
                Get-OrionHostFromSwisConnection -swisconnection $swis | Should Be $OrionHost
            } #end of It
        }#end of context 'When a proper SWIS connection is passed'
    }#end of describe Get-OrionHostFromSwisConnection

    Describe "Get-Get-OrionNextAvailableIPAddress" {
        Context 'returning an IP address' {
            It "should be in valid IP format" {
                $IPAddress = Get-OrionNextAvailableIPAddress -swisconnection $swis -Subnet %160.2% -Verbose
                test-isvalidIP -IPAddress $IPAddress.DisplayName | Should Be $true

            } #end of It
        }#end of context 'When a proper SWIS connection is passed'
    }#end of describe Get-OrionHostFromSwisConnection

}#end of inmodulescope


Remove-Module PowerOrion