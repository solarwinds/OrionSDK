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


Import-Module C:\projects\OrionSDK\Samples\PowerShell\PowerOrion 
$OrionHost = "192.168.100.2"
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

    <#Describe "Get-OrionNextAvailableIPAddress" {
        Context 'returning an IP address' {
            It "should be in valid IP format" {
                $IPAddress = Get-OrionNextAvailableIPAddress -swisconnection $swis -Subnet %160.2% -Verbose
                test-isvalidIP -IPAddress $IPAddress.DisplayName | Should Be $true

            } #end of It
        }#end of context 'When a proper SWIS connection is passed'
    }#end of describe Get-OrionNextAvailableIPAddress

#>}#end of inmodulescope


# describes the function Get-OrionapplicationTemplateId
Describe 'Get-OrionapplicationTemplateId' {

  # scenario 1: call the function without arguments
  Context 'running with arguments'   {
    # test 1: it does not throw an exception:
    It 'runs without errors' {
      # Gotcha: to use the "Should Not Throw" assertion,
      # make sure you place the command in a 
      # scriptblock (braces):
      { Get-OrionapplicationTemplateId -ApplicationName 'apache' -SwisConnection $swis } | Should not Throw
    }
    It 'returns an integer for an existing application' {
      Get-OrionapplicationTemplateId -ApplicationName 'apache' -SwisConnection $swis | should be 6
    }
    # test 2: it returns nothing ($null):
    It 'throws an error when an application template does not exist'     {
      Get-OrionapplicationTemplateId -ApplicationName 'doesnotexist' -SwisConnection $swis -ErrorAction SilentlyContinue | Should throw 
    }
  }
}
Remove-Module PowerOrion