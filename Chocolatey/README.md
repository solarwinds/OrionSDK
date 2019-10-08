# Chocolatey package source

This directory contains the source for the [SolarWinds Orion SDK Chocolatey package](https://chocolatey.org/packages/orionsdk), which installs the Orion SDK.

To build a version of this package for private use, change to this directory and just run `cpack`. Only Package Maintainers can upload the package publicly. If you have Package Maintainer rights to this package with your Chocolately account, you can log in and find your API key on Chocolatey's [My Account](https://chocolatey.org/account) page.

## To update this package for a new Orion SDK version

1. Edit `OrionSDK.nuspec` and change the `<version>` and `<releaseNotes>` elements.
2. Find the SHA-256 hash for `OrionSDK.msi` by opening PowerShell, changing directory to the folder containing the MSI, and typing `Get-FileHash .\OrionSDK.msi`.
3. Edit `tools\chocolateyInstall.ps1` and change the `$url` variable to point to the new version of `OrionSDK.msi`. Update the sha256 values for `OrionSDK.msi`.
4. Run `cpack` from the `OrionSDK\Chocolatey` directory.
5. Run `cpush .\orionsdk-1.2.3.nupkg --api-key 00000000-0000-0000-0000-000000000000`. Change the filename to the one with the correct version and replace the zeros with the actual API key, of course.
6. Expect some automated emails from the Chocolatey.org package verification system.
