
$ErrorActionPreference = 'Stop';


$packageName= 'orionsdk'
$toolsDir   = "$(Split-Path -parent $MyInvocation.MyCommand.Definition)"
$url        = 'https://github.com/solarwinds/OrionSDK/releases/download/v2.5.0.214/OrionSDK.msi'

$packageArgs = @{
  packageName   = $packageName
  unzipLocation = $toolsDir
  fileType      = 'msi'
  url           = $url

  silentArgs    = "/qn /norestart"
  validExitCodes= @(0, 3010, 1641)

  softwareName  = 'orionsdk*'
  checksum      = 'A61FB923EC3D73E18061AD1F04B26C483E2526DDD5ABBEA9ABF6870CCD497AC6'
  checksumType  = 'sha256'
}

Install-ChocolateyPackage @packageArgs
