---
title: SwisPowerShell A Module for PowerShell
---

## What is it?

SwisPowerShell is a PowerShell Module, based on the Orion SDK.
Essentially it is an attempt to take some of the sample scripts included in the SDK, and to convert those to PowerShell Cmdlets.

## Why A Module?

Converting this code into a module has several benefits:

1. By creating Cmdlets, actions can be performed much faster. For example, to add nodes, rather than editing a script and calling that, you can now just call something like

 ```powershell
 $swis = Connect-Swis -UserName admin -Password "" -Hostname 10.160.5.75 
 New-OrionNode -SwisConnection $swis -IPAddress 10.160.5.10
 ```

 What this boils down to is when writing your own scripts, these can now be much smaller in size, and faster to develop, as a lot of the “plumbing” is already done (instead of having to copy and paste a 75 line script, you can now achieve the same in a couple of lines).

2. It’s more intuitive, and fits conventional PowerShell Verb-Noun naming conventions

3. By building in error handling, and through the use of defaults and parameter sets, there is less chance for user error.
For example, when building statements in either the console or the IDE it can prompt on possible options for parameters.

4. Built-in documentation. By using native functionality in PowerShell help and examples can be included with the modules.

## Installing the Module

To install SwisPowerShell, follow these steps:

1. Visit [https://github.com/solarwinds/OrionSDK](https://github.com/solarwinds/OrionSDK), click the green "Clone or download" button, and then click "Download ZIP".

1. Extract the zip to a temp directory.

1. Copy the `SwisPowerShell` directory from the `Samples\PowerShell` directory you just extract to either:

   1. `$pshome\Modules` (`%windir%\System32\WindowsPowerShell\v1.0\Modules`) - this will install SwisPowerShell system-wide.

   1. `$home\Documents\WindowsPowerShell\Modules` (`%UserProfile%\Documents\WindowsPowerShell\Modules`) - this will install PowerShell for the current user only.

Alternatively you can try installing the module from an admin PowerShell session:

```powershell
Install-Module SwisPowerShell
```

Now that SwisPowerShell is installed, you can load it into the current PowerShell session with:

```powershell
Import-Module SwisPowerShell
```

To see a list of all commands:

```powershell
Get-Command -Module SwisPowerShell
```

For more information on installing and using modules see

```powershell
Get-Help About_Modules
```
