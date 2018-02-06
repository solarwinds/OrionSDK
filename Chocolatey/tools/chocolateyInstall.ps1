
$ErrorActionPreference = 'Stop';


$packageName= 'orionsdk'
$toolsDir   = "$(Split-Path -parent $MyInvocation.MyCommand.Definition)"
$url        = 'https://github.com/solarwinds/OrionSDK/releases/download/v2.3.123/OrionSDK.msi'
$url64      = $url

$packageArgs = @{
  packageName   = $packageName
  unzipLocation = $toolsDir
  fileType      = 'msi'
  url           = $url
  url64bit      = $url64

  silentArgs    = "/qn /norestart"
  validExitCodes= @(0, 3010, 1641)

  softwareName  = 'orionsdk*'
  checksum      = '4bade89485b5b9a4013aa59272b0bf3c43e8c94ea2c75ec675f7e3a5a31f1e66'
  checksumType  = 'sha256'
  checksum64    = '4bade89485b5b9a4013aa59272b0bf3c43e8c94ea2c75ec675f7e3a5a31f1e66'
  checksumType64= 'sha256'
}

Install-ChocolateyPackage @packageArgs
