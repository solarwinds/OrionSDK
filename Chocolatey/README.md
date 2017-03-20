# Chocolatey package source

This directory contains the source for the Chocolatey package that installs the Orion SDK.

To build a version of this package for private use, change to this directory and just run `cpack`. You need the right chocolatey.org API key to be able to upload the package publicly. Tim Danner has this key.

## To update this package for a new Orion SDK version

1. Edit `OrionSDK.nuspec` and change the `<version>` and `<releaseNotes>` elements.
2. Edit `tools\chocolateyInstall.ps1` and change the `$url` variable to point to the new version of `OrionSDK.msi`.
3. Run `cpack` from the `OrionSDK\Chocolatey` directory.
4. Run `cpush .\orionsdk-1.2.3.nupkg --api-key 00000000-0000-0000-0000-000000000000`. Change the filename to the one with the correct version and replace the zeros with the actual API key, of course.
5. Expect some automated emails from the Chocolatey.org package verification system.
