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

InModuleScope PowerOrion{
      
    Describe "Get-OrionHostFromSwisConnection" {
        Context 'When a proper SWIS connection is passed' {
            It "extracts the Orion Host from a Swis Connection" {
                $OrionHost = "192.168.1.7"
                $swis = Connect-Swis -UserName admin -Password '' -Hostname $OrionHost
                Get-OrionHostFromSwisConnection -swisconnection $swis | Should Be $OrionHost
            } #end of It
        }#end of context 'When a proper SWIS connection is passed'
    }#end of describe Get-OrionHostFromSwisConnection



}#end of inmodulescope


Remove-Module PowerOrion