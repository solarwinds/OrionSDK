# ------------------------------------------------------------
# ModernDashboard.Tests.ps1
# ------------------------------------------------------------
# PURPOSE:
#   Pester 5 test suite for:
#     - Export-ModernDashboard
#     - Import-ModernDashboard
#     - Get-ModernDashboard
#
# REQUIREMENTS:
#   - PowerShell 7+
#   - Pester 5+
#   - SwisPowerShell >= 3.0.0
#
# ------------------------------------------------------------

# ------------------------------------------------------------
# GLOBAL TEST CONFIG
# ------------------------------------------------------------

$ErrorActionPreference = 'Stop'

# Cross-platform temp path
$script:TestDriveRoot = Join-Path ([System.IO.Path]::GetTempPath()) "Pester_ModernDashboard"
if ( -not ( Test-Path -Path $script:TestDriveRoot ) ) {
    New-Item -ItemType Directory -Path $script:TestDriveRoot -Force | Out-Null
}

# ------------------------------------------------------------
# BEFORE ALL: MODULE VALIDATION
# ------------------------------------------------------------
BeforeAll {

    #Requires -Version 7.0

    # Dot-source the functions file
    . "$PSScriptRoot\func_ModernDashboards.ps1"

    # ------------------------------------------------------------------------------------------------------------------------
    # Credentials for integration tests are saved in a separate XML file that is not checked into source control. 
    # This file should contain a serialized PSCredential object with an additional NoteProperty for the OrionHost. 
    # This allows the tests to connect to a real SolarWinds instance without hardcoding credentials in the test script.
    #
    # You can create this file with the following PowerShell command (run in the same folder as this test script):
    # ( ( Get-Credential -Message "Enter credentials for Orion test server" ) |
    #   Add-Member -MemberType NoteProperty -Name OrionHost -Value "your-orion-host or IP Address" -Force -PassThru ) |
    #   Export-Clixml -Path '.orionsdk-test-credentials.xml'
    # By default, this file is blocked by .gitignore to prevent accidental check-in of sensitive information.
    # ------------------------------------------------------------------------------------------------------------------------

    function Get-OrionTestCredential {
        <#
        .SYNOPSIS
            Retrieves the test credential for the Orion server.
        .DESCRIPTION
            This function imports the serialized PSCredential object from the specified XML file.
        .PARAMETER Path
            The path to the XML file containing the test credentials. [Defaults to .orionsdk-test-credentials.xml in the same folder as this script]
        .EXAMPLE
            Get-OrionTestCredential
        .OUTPUTS
            System.Management.Automation.PSCredential
        #>
        [CmdletBinding()]
        param(
            [Parameter(Mandatory = $false)]
            [string]$Path = "$PSScriptRoot\.orionsdk-test-credentials.xml"
        )

        if (-not (Test-Path -Path $Path)) {
            throw "Orion test credential file not found: $Path. Please create this file with:`n( ( Get-Credential -Message `"Enter credentials for Orion test server`" ) | Add-Member -MemberType NoteProperty -Name OrionHost -Value `"your-orion-host or IP Address`" -Force -PassThru ) | Export-Clixml -Path $Path"
        }

        $c = Import-Clixml -Path $Path
        $credential = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $c.UserName, $c.Password
        if (-not $credential -or -not ($credential -is [System.Management.Automation.PSCredential])) {
            throw "Invalid credential data in: $Path"
        }

        return $credential
    }

    function Get-OrionTestServer {
        <#
        .SYNOPSIS
            Retrieves the test server hostname for the Orion instance.
        .DESCRIPTION
            This function imports the serialized PSCredential object from the specified XML file and extracts the OrionHost value.
        .PARAMETER Path
            The path to the XML file containing the test credentials. [Defaults to .orionsdk-test-credentials.xml in the same folder as this script]
        .EXAMPLE
            Get-OrionTestServer
        .OUTPUTS
            System.String
        #>
        [CmdletBinding()]
        param(
            [Parameter(Mandatory = $false)]
            [string]$Path = "$PSScriptRoot\.orionsdk-test-credentials.xml"
        )

        if (-not (Test-Path -Path $Path)) {
            throw "Orion test credential file not found: $Path. Please create this file with:`n( ( Get-Credential -Message `"Enter credentials for Orion test server`" ) | Add-Member -MemberType NoteProperty -Name OrionHost -Value `"your-orion-host or IP Address`" -Force -PassThru ) | Export-Clixml -Path $Path"
        }

        $hostname = Import-Clixml -Path $Path | Select-Object -ExpandProperty OrionHost
        if (-not $hostname) {
            throw "Invalid hostname data in: $Path"
        }

        return $hostname
    }

    # ------------------------------------------------------------
    # MOCK DATA HELPERS
    # ------------------------------------------------------------
    function New-FakeDashboardJson {
        <#
        .SYNOPSIS
            Creates a fake dashboard JSON object for testing purposes.
        .DESCRIPTION
            This function generates a JSON string representing a mock dashboard for integration testing.
        .PARAMETER Name
            The name of the fake dashboard. [Defaults to "Test Dashboard"]
        .EXAMPLE
            New-FakeDashboardJson -Name "My Test Dashboard"
        .OUTPUTS
            System.String
        #>
        param(
            [string]$Name = "Test Dashboard"
        )


        return @"
{
    "version": 1,
    "dashboards": [
        {
            "widgets": [],
            "parent": null,
            "feature": null,
            "groupId": null,
            "groupRank": null,
            "groupMemberName": null,
            "groupName": null,
            "dashboardType": null,
            "routeId": "",
            "dashboardRoutes": [],
            "configuration": null,
            "legacyUrl": null,
            "isLegacyDefaultNewAccount": false,
            "isLegacyDefaultExistingAccount": false,
            "unique_key": "$( $Name.ToLower().Replace(' ', '-') )",
            "name": "$Name",
            "private": null
        }
    ],
    "widgets": [],
    "remove": null
}
"@
    }

    # Basic validation to ensure the required module is available before running any tests
    Write-Host "Validating SwisPowerShell module availability..."

    $module = Get-Module -ListAvailable -Name 'SwisPowerShell' | 
                 Where-Object { $_.Version -ge [version]'3.0.0' } |
                 Sort-Object Version -Descending |
                 Select-Object -First 1

    if (-not $module) {
        Throw "Required module 'SwisPowerShell' (>=3.0.0) not found. Install via: Install-Module SwisPowerShell"
    }

    Import-Module $module -Force

    Write-Host "Loaded SwisPowerShell version $($module.Version)"
}



# ------------------------------------------------------------
# CONTEXT: Integration Tests (REAL SWIS)
# ------------------------------------------------------------
Describe "ModernDashboard - Integration Tests" -Tag "Integration" {

    # These tests REQUIRE:
    #   - Real SolarWinds instance
    #   - Valid credentials
    #   - Network connectivity
    #

    Context "Real SWIS Connection" {

        BeforeAll {
            # NOTE: Credentials saved in .orionsdk-test-credentials.xml (hidden by .gitignore) in the same folder as this test script
            $script:SwisConnection = Connect-Swis -Hostname ( Get-OrionTestServer ) -Credential ( Get-OrionTestCredential )
        }

        It "Can retrieve user dashboards" {
            if ( -not ( Get-ModernDashboard -SwisConnection $script:SwisConnection ) ) {
                Import-ModernDashboard -SwisConnection $script:SwisConnection -JsonBody ( New-FakeDashboardJson -Name "Test Dashboard" ) -Force -Confirm:$false | Out-Null
            }
            $result = Get-ModernDashboard -SwisConnection $script:SwisConnection
            $result | Should -Not -BeNullOrEmpty
        }

        It "Can retrieve system dashboards" {
            $result = Get-ModernDashboard -SwisConnection $script:SwisConnection -IncludeSystem
            $result | Should -Not -BeNullOrEmpty
        }

        It "Can export and re-import a dashboard (round-trip)" {

            $dashboardId = Get-ModernDashboard -SwisConnection $script:SwisConnection -IncludeSystem | Get-Random | Select-Object -ExpandProperty DashboardID

            $json = Export-ModernDashboard `
                -SwisConnection $script:SwisConnection `
                -DashboardId $dashboardId `
                -PassThru `
                -Confirm:$false

            $json | Should -Not -BeNullOrEmpty

            # Rename the dashboard in the JSON to avoid conflicts on import
            $obj = $json | ConvertFrom-Json -Depth 25
            $obj.dashboards[0].name = "Round-Trip Test Dashboard $(Get-Date -Format 'yyyyMMddHHmmss')"
            $obj.dashboards[0].unique_key = $obj.dashboards[0].name.ToLower().Replace(' ', '-')
            $json = $obj | ConvertTo-Json -Depth 25

            $importId = Import-ModernDashboard `
                -SwisConnection $script:SwisConnection `
                -JsonBody $json `
                -Force `
                -Confirm:$false

            $importId | Should -BeGreaterThan 0

            Remove-ModernDashboard -SwisConnection $script:SwisConnection -DashboardId $importId -Confirm:$false
        }

        It "Can export dashboards to a folder" {

            $outDir = Join-Path -Path $TestDriveRoot -ChildPath "integration_export"
            if ( -not ( Test-Path -Path $outDir ) ) {
                New-Item -ItemType Directory -Path $outDir -Force | Out-Null
            }

            Export-ModernDashboard `
                -SwisConnection $script:SwisConnection `
                -IncludeSystem `
                -OutputFolder $outDir `
                -Confirm:$false

            $files = Get-ChildItem $outDir
            $files.Count | Should -BeGreaterThan 0

            Remove-Item -Path $outDir -Recurse -Force -Confirm:$false
        }

        It "Can import a dashboard from a file" {

            $json = New-FakeDashboardJson -Name "Integration Import Test"

            $file = Join-Path -Path $TestDriveRoot -ChildPath "integration_import.json"
            $json | Out-File -Path $file -Confirm:$false -Force

            $importId = Import-ModernDashboard `
                -SwisConnection $script:SwisConnection `
                -Path $file `
                -Confirm:$false

            $importId | Should -BeGreaterThan 0

            Remove-ModernDashboard -SwisConnection $script:SwisConnection -DashboardId $importId -Confirm:$false
            Remove-Item -Path $file -Force -Confirm:$false
        }

        It "Can import a dashboards from a folder" {

            $outDir = Join-Path -Path $TestDriveRoot -ChildPath "integration_import_folder"
            if ( -not ( Test-Path -Path $outDir -Verbose ) ) {
                New-Item -ItemType Directory -Path $outDir -Force | Out-Null
            }

            # Create multiple dashboard files
            1..3 | ForEach-Object {
                $json = New-FakeDashboardJson -Name "Import Test $( $_ )"
                $filePath = Join-Path -Path $outDir -ChildPath "import_test_$( $_ ).json"
                $json | Out-File -Path $filePath -Confirm:$false -Force
            }

            $importIds = Import-ModernDashboard `
                -SwisConnection $script:SwisConnection `
                -Path $outDir `
                -Confirm:$false

            $importIds.Count | Should -Be 3
            foreach ($id in $importIds) {
                $id | Should -BeGreaterThan 0
            }
    
            # Cleanup
            foreach ($id in $importIds) {
                Remove-ModernDashboard -SwisConnection $script:SwisConnection -DashboardId $Id -Confirm:$false
            }
            Remove-Item -Path $outDir -Recurse -Force -Confirm:$false
        }
    }
}