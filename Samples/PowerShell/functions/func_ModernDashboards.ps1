#Requires -Module @{ ModuleName = 'SwisPowerShell'; ModuleVersion = '3.0.0' }

<#
.Synopsis
    Export Modern Dashboards from SolarWinds Orion system
.DESCRIPTION
    Connects to SolarWinds Information Service, extracts the JSON content of a Modern Dashboard and exports it to the file system
.EXAMPLE
    $SwisConnection = Connect-Swis -Hostname "192.168.11.165" -Username "admin" -Password "MyComplexPassword"
    PS C:\> Set-Location -Path "C:\Exports"
    PS C:\Exports> Export-ModernDashboard -SwisConnection $SwisConnection

    This exports all of the Modern Dashboards to the 'C:\Exports' folder
.EXAMPLE
    $SwisConnection = Connect-Swis -Hostname "192.168.11.165" -Username "admin" -Password "MyComplexPassword"
    PS C:\> Export-ModernDashboard -SwisConnection $SwisConnection -DashboardId 9 -OutputFolder "D:\OrionServer\Modern Dashboards\"

    This exports the Modern Dashboard with ID 9 to the 'D:\OrionServer\Modern Dashboards\' folder
.EXAMPLE
    $SwisConnection = Connect-Swis -Hostname "192.168.11.165" -Username "admin" -Password "MyComplexPassword"
    PS C:\> Export-ModernDashboard -SwisConnection $SwisConnection -DashboardId 9 -IncludeId

    This exports the Modern Dashboard with ID 9 to the current folder with the naming format "9_<Dashboard Name>.json"
.NOTES
    Author:  Kevin M. Sparenberg (https://thwack.solarwinds.com/members/kmsigma)
    Version: 0.9
    Last Updated: 2021-06-28
    Validated: Orion Platform 2020.2.5

    TBD List:
        * -PassThru [switch]
            Mimic a -PassThru parameter that just returns the JSON data to the pipeline
            -AsPsObject [switch] (child of -PassThru)
                Allows for the raw Json to be returned as a PowerShell object
        * Validate that the script works on non-Windows
#>
function Export-ModernDashboard {
    [CmdletBinding(
        DefaultParameterSetName = 'Normal', 
        SupportsShouldProcess = $true, 
        PositionalBinding = $false,
        HelpUri = 'https://documentation.solarwinds.com/en/success_center/orionplatform/content/core-fusion-dashboard-import-export.htm',
        ConfirmImpact = 'Medium')]
    [Alias()]
    [OutputType([String])]
    Param
    (
        # The connection to the SolarWinds Information Service
        [Parameter(
            Mandatory = $true, 
            ValueFromPipeline = $true,
            ValueFromPipelineByPropertyName = $true, 
            ValueFromRemainingArguments = $false, 
            Position = 0,
            ParameterSetName = 'Normal')]
        [ValidateNotNull()]
        [ValidateNotNullOrEmpty()]
        [Alias("Swis")] 
        [SolarWinds.InformationService.Contract2.InfoServiceProxy]$SwisConnection,

        # The dashboard Id we'll export
        [Parameter(
            ValueFromPipeline = $true,
            ValueFromPipelineByPropertyName = $true,
            Position = 1,
            ParameterSetName = 'Normal')]
        [AllowNull()]
        [int32[]]$DashboardId,

        # Specifies the path to the output file.
        [Parameter(ParameterSetName = 'Normal')]
        [AllowNull()]
        [string]$OutputFolder = ( Get-Location ),

        # Should we include system Dashboards?
        [Parameter(ParameterSetName = 'Normal')]
        [AllowNull()]
        [switch]$IncludeSystem,

        # Should we include the Dashboard ID number in the name.
        [Parameter(ParameterSetName = 'Normal')]
        [AllowNull()]
        [switch]$IncludeId,

        # Omits white space and indented formatting in the output string.
        [Parameter(ParameterSetName = 'Normal')]
        [AllowNull()]
        [switch]$Compress,

        # Overrides the read-only attribute and overwrites an existing read-only file. The Force parameter does not override security restrictions.
        [Parameter(ParameterSetName = 'Normal')]
        [AllowNull()]
        [switch]$Force

    )

    Begin {
        # if no dashboard ids are provided, assume we export them all, so get the list
        if ( ( -not $DashboardId ) -and ( $IncludeSystem ) ) {
            Write-Verbose -Message "EXPORT ALL: No DashboardIds Provided - exporting all (including system dashboards)"
            $Swql = "SELECT DashboardID FROM Orion.Dashboards.Instances WHERE ParentID IS NULL"
            $DashboardId = Get-SwisData -SwisConnection $SwisConnection -Query $Swql
        } elseif ( -not $DashboardId ) {
            Write-Verbose -Message "EXPORT ALL: No DashboardIds Provided - exporting all (excluding system dashboards)"
            $Swql = "SELECT DashboardID FROM Orion.Dashboards.Instances WHERE ParentID IS NULL AND IsSystem = 'FALSE'"
            $DashboardId = Get-SwisData -SwisConnection $SwisConnection -Query $Swql
        }

        # How deep does the Json go?  From initial testing it looks like 25 is sufficient, this gives flexibility
        $JsonDepth = 25
    }
    Process {
        ForEach ( $d in $DashboardId ) {
            $DashboardText = Invoke-SwisVerb -SwisConnection $SwisConnection -EntityName Orion.Dashboards.Instances -Verb Export -Arguments $d
            
            # The name is stored within the Json file, so we need to load it as Json and interpret it.
            $DashboardObject = $DashboardText.'#text' | ConvertFrom-Json
            $DashboardName = $DashboardObject.dashboards.name
            if ( $DashboardObject.dashboards.unique_key -notmatch '[a-f,0-9]{8}-[a-f,0-9]{4}-[a-f,0-9]{4}-[a-f,0-9]{4}-[a-f,0-9]{12}' ) {
                # This is a system dashboard, so add "SYSTEM" to the name
                $DashboardName = "SYSTEM_$( $DashboardName )"
            }

            $ExportFileName = "$( Remove-InvalidFileNameChars -Name $DashboardName -Replacement "-" ).json"
            if ( $IncludeId ) {
                $ExportFileName = "$( $d )_$ExportFileName"
            }

            $ExportFilePath = Join-Path -Path $OutputFolder -ChildPath $ExportFileName
            
            # Check to see if the export file already exists and we are not forcing overwrite
            if ( ( -not ( Test-Path -Path $ExportFilePath -ErrorAction SilentlyContinue ) ) -or ( $Force ) ) {
                # Ask if we want to export - skip this check by passing '-Confirm:$false'
                if ( $pscmdlet.ShouldProcess("to '$OutputFolder'", "Export '$DashboardName'") ) {
                    # Actually do the export
                    Write-Verbose -Message "Exporting '$DashboardName'"
                    $DashboardObject | ConvertTo-Json -Depth $JsonDepth -Compress:$Compress | Out-File -FilePath $ExportFilePath -Force:$Force
                }
            }
            else {
                Write-Warning -Message "Skipping export of '$DashboardName' because '$ExportFilePath' already exists.  If you wish to overwrite, use the '-Force' parameter."
            }
        }
    }
    End {
        # nothing to do here
    }
}

<#
.Synopsis
    Import Modern Dashboards to a SolarWinds Orion system
.DESCRIPTION
    Opens files in the file system and imports them as custom Modern Dashboards into an Orion Server.
.EXAMPLE
    $SwisConnection = Connect-Swis -Hostname "192.168.11.165" -Username "admin" -Password "MyComplexPassword"
    PS C:\> Set-Location -Path "C:\Exports"
    PS C:\Exports> Import-ModernDashboard -SwisConnection $SwisConnection

    This imports all of the Modern Dashboards files in the 'C:\Exports' folder to the server running on 192.168.11.165
.EXAMPLE
    $SwisConnection = Connect-Swis -Hostname "192.168.11.165" -Username "admin" -Password "MyComplexPassword"
    PS C:\> Import-ModernDashboard -SwisConnection $SwisConnection -Path "C:\Imports\KevinsDashboard.json"

    This imports a single dashboard from the "C:\Imports\KevinsDashboard.json" file
.EXAMPLE
    $SwisConnection = Connect-Swis -Hostname "192.168.11.165" -Username "admin" -Password "MyComplexPassword"
    PS C:\> Import-ModernDashboard -SwisConnection $SwisConnection -Path "C:\Imports\KevinsDashboard.json"

    PS C:\> Import-ModernDashboard -SwisConnection $SwisConnection -Path "C:\Imports\KevinsDashboard.json"
    This will fail with an error because there already exists this import.  To forcibly import (destructive):
    PS C:\> Import-ModernDashboard -SwisConnection $SwisConnection -Path "C:\Imports\KevinsDashboard.json" -Force
.NOTES
    Author:  Kevin M. Sparenberg (https://thwack.solarwinds.com/members/kmsigma)
    Version: 0.9
    Last Updated: 2021-06-28
    Validated: Orion Platform 2020.2.5

    TBD List:
        * Validate that the script works on non-Windows
#>
function Import-ModernDashboard {
    [CmdletBinding(DefaultParameterSetName = 'Normal', 
        SupportsShouldProcess = $true, 
        PositionalBinding = $false,
        HelpUri = 'https://documentation.solarwinds.com/en/success_center/orionplatform/content/core-fusion-dashboard-import-export.htm',
        ConfirmImpact = 'High')]
    [Alias()]
    [OutputType([String])]
    Param
    (
        # The connection to the SolarWinds Information Service
        [Parameter(Mandatory = $true, 
            ValueFromPipeline = $true,
            ValueFromPipelineByPropertyName = $true, 
            ValueFromRemainingArguments = $false, 
            Position = 0,
            ParameterSetName = 'Normal')]
        [ValidateNotNull()]
        [ValidateNotNullOrEmpty()]
        [Alias("Swis")] 
        [SolarWinds.InformationService.Contract2.InfoServiceProxy]$SwisConnection,

        # If a pre-existing dashboard name matches, use a different name
        [Parameter(Position = 1,
            ParameterSetName = 'Normal')]
        [string[]]$Path = ( Get-Location ),

        # If a pre-existing dashboard name matches, overwrite it
        [Parameter(ParameterSetName = 'Normal')]
        [AllowNull()]
        [switch]$Force

    )

    Begin {
        # How deep does the Json go?  From initial testing it looks like 25 is sufficient, this gives flexibility
        $JsonDepth = 25

        # Need a list of existing Modern Dashboards
        $Swql = "SELECT DisplayName, UniqueKey FROM Orion.Dashboards.Instances WHERE ParentID IS NULL"
        $Dashboards = Get-SwisData -SwisConnection $SwisConnection -Query $Swql
    }
    Process {
        $FileList = @()
        # Build a list of files to work on.
        # Since this function can take an array of files/folders, we need to parse through each of them
        ForEach ( $P in $Path ) {
            $P = Get-Item -Path $P
            if ( $P.PSIsContainer ) {
                Write-Verbose -Message "PATH DETECTION: Directory Detected"
                $FileList += Get-ChildItem -Path $P
            } else {
                Write-Verbose -Message "PATH DETECTION: Single File"
                $FileList += $P
            }
        }
        
        ForEach ( $File in $FileList ) {
            Write-Verbose -Message "FILE: Processing '$( $File.FullName )'"
            try {
                # Read the file put it into a JSON object
                $TemplateObject = Get-Content -Path $File | ConvertFrom-Json -Depth $JsonDepth
                # Quick check to see if the template already exists (check to see if the name OR the unique key matches)
                $DashboardExists = ( $TemplateObject.dashboards.Name -in $Dashboards.DisplayName ) -or ( $TemplateObject.dashboards.unique_key -in $Dashboards.UniqueKey )

                # Ask if we want to do the import for each file - skip this check by passing '-Confirm:$false'
                if ( $pscmdlet.ShouldProcess("Orion Server: [$( $SwisConnection.Channel.Via.Host )]", "Import Dashboard [$( $TemplateObject.dashboards.name )]") ) {
                    # If the dashboard doesn't already exist OR we are forcing the import, try to import it
                    if ( ( -not ( $DashboardExists ) ) -or ( $Force ) ) {
                        Write-Verbose -Message "Importing Dashboard '$( $TemplateObject.dashboards.name )' to Orion Server: [$( $SwisConnection.Channel.Via.Host )]"
                        try {
                            # Execute the import - the JSON object is converted back to text and sent as the argument
                            Invoke-SwisVerb -SwisConnection $SwisConnection -EntityName "Orion.Dashboards.Instances" -Verb "Import" -Arguments ( $TemplateObject | ConvertTo-Json -Depth $JsonDepth -Compress ) | Out-Null
                        }
                        catch {
                            Write-Error -Message "Error importing '$( $File.Fullname )'" -RecommendedAction "Validate that this is a proper JSON file"
                        }
                    } else {
                        Write-Error -Message "SKIPPED: Dashboard with name '$( $TemplateObject.dashboards.Name )' or key [$( $TemplateObject.dashboards.unique_key )] already exists." -RecommendedAction "Use '-Force' to forcibly import (destructive)."
                    }
                }
            }
            catch {
                Write-Error -Message "File content of '$( $File.Fullname )' does not match JSON format" -RecommendedAction "Remove non-JSON files or statically pass specific files to the '-Path' parameter."
            }
        }

    }
    End {
        # nothing to do here
    }
}


<#
.SYNOPSIS
    Removes characters from a string that are not valid in Windows file names.

.DESCRIPTION
    Remove-InvalidFileNameChars accepts a string and removes characters that are invalid in Windows file names.  It then outputs the cleaned string.  By default the space character is ignored, but can be included using the RemoveSpace parameter.

    The Replacement parameter will replace the invalid characters with the specified string. Its companion RemoveOnly will exempt given invalid characters from being replaced, and will simply be removed. Charcters in this list can be given as a string or their decimal or hexadecimal representation.

    The Name parameter can also clean file paths. If the string begins with "\\" or a drive like "C:\", it will then treat the string as a file path and clean the strings between "\".  This has the side effect of removing the ability to actually remove the "\" character from strings since it will then be considered a divider.
.PARAMETER Name
    Specifies the file name to strip of invalid characters.

.PARAMETER Replacement
    Specifies the string to use as a replacement for the invalid characters.

.PARAMETER RemoveOnly
    Specifes the list of invalid characters to remove from the string instead of being replaced by the Replacement parameter value. This may be given as one character strings, or their decimal or hexidecimal values.

.PARAMETER RemoveSpace
    The RemoveSpace parameter will include the space character (U+0020) in the removal process.

.INPUTS
    System.String
    Remove-InvalidFileNameChars accepts System.String objects in the pipeline.
    Remove-InvalidFileNameChars accepts System.String objects in a property Name from objects in the pipeline.

.OUTPUTS
    System.String

.EXAMPLE
    PS C:\> Remove-InvalidFileNameChars -Name "<This /name \is* an :illegal ?filename>.txt"
    Output: This name is an illegal filename.txt

    This command will strip the invalid characters from the string and output a clean string.
.EXAMPLE
    PS C:\> Remove-InvalidFileNameChars -Name "<This /name \is* an :illegal ?filename>.txt" -RemoveSpace
    Output: Thisnameisanillegalfilename.txt

    This command will strip the invalid characters from the string and output a clean string, removing the space character (U+0020) as well.
.EXAMPLE
    PS C:\> Remove-InvalidFileNameChars -Name '\\Path/:|?*<\With:*?>\:Illegal /Characters>?*.txt"'
    Output: \\Path\With\Illegal Characters.txt

    This command will strip the invalid characters from the path and output a valid path. Note: it would not be able to remove the "\" character.
.EXAMPLE
    PS C:\> Remove-InvalidFileNameChars -Name '\\Path/:|?*<\With:*?>\:Illegal /Characters>?*.txt"' -RemoveSpace
    Output: \\Path\With\IllegalCharacters.txt

    This command will strip the invalid characters from the path and output a valid path, also removing the space character (U+0020) as well. Note: it would not be able to remove the "\" character.
.EXAMPLE
    PS C:\> Remove-InvalidFileNameChars -Name "<This /name \is* an :illegal ?filename>.txt" -Replacement +
    Output: +This +name +is+ an +illegal +filename+.txt

    This command will strip the invalid characters from the string, replacing them with a "+", and outputting the result string.
.EXAMPLE
    PS  C:\> Remove-InvalidFileNameChars -Name "<This /name \is* an :illegal ?filename>.txt" -Replacemet + -RemoveOnly "*", 58, 0x3f
    Output: +This +name +is an illegal filename+.txt

    This command will strip the invalid characters from the string, replacing them with a "+", except the "*", the charcter with a decimal value of 58 (:), and the character with a hexidecimal value of 0x3f (?). These will simply be removed, and the resulting string output.
.NOTES
    Author:  Chris Carter
    Version: 1.5.1
    Last Updated: August 8, 2016
.Link
    System.RegEx
.Link
    about_Join
.Link
    about_Operators
#>

#Requires -Version 2.0
function Remove-InvalidFileNameChars {

    [CmdletBinding(
        DefaultParameterSetName = "Normal",
        HelpURI = 'https://gallery.technet.microsoft.com/scriptcenter/Remove-Invalid-Characters-39fa17b1'
    )]

    Param(
        [Parameter(Mandatory = $true,
            Position = 0,
            ValueFromPipeline = $true,
            ValueFromPipelineByPropertyName = $true,
            ParameterSetName = "Normal")]
        [Parameter(Mandatory = $true,
            Position = 0,
            ValueFromPipeline = $true,
            ValueFromPipelineByPropertyName = $true,
            ParameterSetName = "Replace")]
        [string[]]$Name,

        [Parameter(Mandatory = $true,
            Position = 1,
            ParameterSetName = "Replace")]
        [string]$Replacement,

        [Parameter(Position = 2,
            ParameterSetName = "Replace")]
        [Alias("RO")]
        [object[]]$RemoveOnly,
    
        [Parameter(ParameterSetName = "Normal")]
        [Parameter(ParameterSetName = "Replace")]
        [Alias("RS")]
        [switch]$RemoveSpace
    )

    Begin {
        #Get an array of invalid characters
        $arrInvalidChars = [System.IO.Path]::GetInvalidFileNameChars()

        #Cast into a string. This will include the space character
        $invalidCharsWithSpace = [RegEx]::Escape( [string]$arrInvalidChars )

        #Join into a string. This will not include the space character
        $invalidCharsNoSpace = [RegEx]::Escape( -join $arrInvalidChars )

        #Check that the Replacement does not have invalid characters itself
        if ( $RemoveSpace ) {
            if ( $Replacement -match "[$invalidCharsWithSpace]" ) {
                Write-Error "The replacement string also contains invalid filename characters."
                exit
            }
        }
        else {
            if ( $Replacement -match "[$invalidCharsNoSpace]" ) {
                Write-Error "The replacement string also contains invalid filename characters."
                exit
            }
        }

        Function Remove-Chars($String) {
            #Test if any charcters should just be removed first instead of replaced.
            if ($RemoveOnly) {
                $String = Remove-ExemptCharsFromReplacement -String $String
            }

            #Replace the invalid characters with a blank string(removal) or the replacement value
            #Perform replacement based on whether spaces are desired or not
            if ($RemoveSpace) {
                [RegEx]::Replace($String, "[$invalidCharsWithSpace]", $Replacement)
            }
            else {
                [RegEx]::Replace($String, "[$invalidCharsNoSpace]", $Replacement)
            }
        }
    
        Function Remove-ExemptCharsFromReplacement($String) {
            #Remove the characters in RemoveOnly first before returning to the potential replacement

            #Test that the entries are invalid filename characters, and are able to be converted to chars
            $RemoveOnly = [RegEx]::Escape( 
                -join $(
                    ForEach ( $entry in $RemoveOnly ) {
                        #Try to cast to an int in case a valid integer as a string is passed.
                        try {
                            $entry = [int]$entry
                        }
                        catch {
                            #Silently ignore if it fails. 
                        }

                        try {
                            $char = [char]$entry
                        }
                        catch {
                            Write-Error "The entry `"$entry`" in RemoveOnly cannot be converted to a type of System.Char. Make sure the entry is either an integer or a one character string."
                            exit
                        }
            
                        if ( ( $arrInvalidChars -contains $char ) -or ( $char -eq [char]32 ) ) {
                            #Honor the RemoveSpace parameter
                            if ( ( !$RemoveSpace ) -and ( $char -eq [char]32 ) ) {
                                Write-Warning "The entry `"$char`" in RemoveOnly is a valid filename character, and does not need to be removed. This entry will be ignored."
                            }
                            else { $char }
                        }
                        else {
                            Write-Warning "The entry `"$char`" in RemoveOnly is a valid filename character, and does not need to be removed. This entry will be ignored."
                        }
                    }
                )
            )

            #Remove the exempt characters first before sending back
            [RegEx]::Replace( $String, "[$RemoveOnly]", '')
        }       
    }

    Process {
        ForEach ( $n in $Name ) {
            #Check if the string matches a valid path
            if ( $n -match '(?<start>^[a-zA-z]:\\|^\\\\)(?<path>(?:[^\\]+\\)+)(?<file>[^\\]+)$' ) {
                #Split the path into separate directories
                $path = $Matches.path -split '\\'

                #This will remove any empty elements after the split, eg. double slashes "\\"
                $path = $path | Where-Object { $_ }
                #Add the filename to the array
                $path += $Matches.file

                #Send each part of the path, except the start, to the removal function
                $cleanPaths = foreach ($p in $path) {
                    Remove-Chars -String $p
                }
                #Remove any blank elements left after removal.
                $cleanPaths = $cleanPaths | Where-Object { $_ }
            
                #Combine the path together again
                $Matches.start + ( $cleanPaths -join '\' )
            }
            else {
                #String is not a path, so send immediately to the removal function
                Remove-Chars -String $n
            }
        }
    }
}