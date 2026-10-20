
$ErrorActionPreference = 'Stop';


$packageName= 'orionsdk'
$toolsDir   = "$(Split-Path -parent $MyInvocation.MyCommand.Definition)"
$url        = 'https://github.com/solarwinds/OrionSDK/releases/download/v3.4.0.50128/OrionSDK.msi'

$packageArgs = @{
  packageName   = $packageName
  unzipLocation = $toolsDir
  fileType      = 'msi'
  url           = $url

  silentArgs    = "/qn /norestart"
  validExitCodes= @(0, 3010, 1641)

  softwareName  = 'orionsdk*'
  checksum      = 'b88e2e7f4522c7b09400d56c3691de0e1017886e18d733fd89087fc6a82a0e41'
  checksumType  = 'sha256'
}

Install-ChocolateyPackage @packageArgs
