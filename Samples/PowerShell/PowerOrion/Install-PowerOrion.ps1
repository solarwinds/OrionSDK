<#
.Synopsis
   Install PowerOrion module
.DESCRIPTION
  Installs PowerOrion module, defaults to the User Module Path 
.EXAMPLE
   Example of how to use this cmdlet
.EXAMPLE
   C:\windows\system32\WindowsPowerShell\v1.0\Modules\
#>


[CmdletBinding()]
[Parameter(Mandatory=$true,
            ValueFromPipelineByPropertyName=$true,
            Position=0)]
$Path = "$env:userProfile\documents\WindowsPowerShell\Modules\PowerOrion"

Write-Verbose "Installing PowerOrion to $Path"
$files =  "PowerOrion.psm1","PowerOrion.psd1"

if(-not (Test-Path -Path $Path )){
    Write-Verbose "$Path does not exist, so creating it"
    New-Item -type Directory -Path $Path 
}

$files | foreach {  Copy-Item -Path $_  -Destination $Path -Force -Verbose}