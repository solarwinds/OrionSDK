
$ErrorActionPreference = 'Stop';


$packageName= 'orionsdk'
$toolsDir   = "$(Split-Path -parent $MyInvocation.MyCommand.Definition)"
$url        = 'https://github.com/solarwinds/OrionSDK/releases/download/v3.2.0.50049/OrionSDK.msi'

$packageArgs = @{
  packageName   = $packageName
  unzipLocation = $toolsDir
  fileType      = 'msi'
  url           = $url

  silentArgs    = "/qn /norestart"
  validExitCodes= @(0, 3010, 1641)

  softwareName  = 'orionsdk*'
  checksum      = '6D356193507F65DAF9AEC8885B52319D754B3FDEDE308AA8E06CBF94D9CD2B05'
  checksumType  = 'sha256'
}

Install-ChocolateyPackage @packageArgs
