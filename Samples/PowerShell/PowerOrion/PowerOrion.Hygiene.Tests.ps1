#Requires -Modules @{ ModuleName = 'Pester'; ModuleVersion = '5.0.0' }
<#
    .DESCRIPTION
    Structural / hygiene tests for the PowerOrion module: manifest validity, clean import,
    export contract, comment-based help coverage, and static analysis.
#>

BeforeDiscovery {
    # Runs during Pester's discovery phase so -ForEach lists are populated in time.
    Import-Module (Join-Path $PSScriptRoot 'PowerOrion.psd1') -Force -ErrorAction Stop
    $PublicFns = (Get-Command -Module 'PowerOrion' -CommandType Function).Name
}

BeforeAll {
    $script:ModuleRoot   = $PSScriptRoot
    $script:ManifestPath = Join-Path $ModuleRoot 'PowerOrion.psd1'
    $script:ModuleName   = 'PowerOrion'

    # The module's parameters are typed as [SolarWinds...InfoServiceProxy]. That type is
    # loaded lazily by SwisPowerShell only after Connect-Swis is first invoked. Get-Help
    # re-parses the param blocks, so the type must be resolvable or the help tests error.
    # (No server is contacted -- the connection is lazy.)
    Import-Module SwisPowerShell -Force -ErrorAction Stop
    $null = Connect-Swis -Hostname 'localhost' -UserName 'test' -Password 'test'
}

Describe 'Module manifest' {
    It 'exists' {
        Test-Path $script:ManifestPath | Should -BeTrue
    }
    It 'is a valid manifest' {
        { Test-ModuleManifest -Path $script:ManifestPath -ErrorAction Stop } | Should -Not -Throw
    }
    It 'imports without error' {
        { Import-Module $script:ManifestPath -Force -ErrorAction Stop } | Should -Not -Throw
    }
}

Describe 'Module lifecycle' {
    It 'removes without writing errors (OnRemove handler is safe)' {
        Import-Module $script:ManifestPath -Force
        $stream = Remove-Module $script:ModuleName -Force 2>&1
        $errors = @($stream | Where-Object { $_ -is [System.Management.Automation.ErrorRecord] })
        $errors | Should -BeNullOrEmpty -Because ($errors | Out-String)
    }
    AfterAll { Import-Module $script:ManifestPath -Force }
}

Describe 'Export contract' {
    BeforeAll {
        Import-Module $script:ManifestPath -Force
        $script:Exported = (Get-Command -Module $script:ModuleName).Name
    }

    It 'exports the documented public functions' {
        $expected = @(
            'Add-OrionDiscoveredInterfaces', 'Get-OrionApplicationCredential',
            'Get-OrionApplicationTemplateId', 'Get-OrionHostFromSwisConnection',
            'Get-OrionNextAvailableIPAddress', 'Get-OrionNode', 'Get-OrionNodeID',
            'Get-OrionWMICredential', 'New-OrionCustomProperty', 'New-OrionInterface',
            'New-OrionNode', 'New-OrionPollerType', 'Remove-OrionNode'
        )
        foreach ($fn in $expected) {
            $script:Exported | Should -Contain $fn
        }
    }

    It 'does not leak internal helpers' {
        # Internal helpers should NOT be exported.
        $script:Exported | Should -Not -Contain 'Convert-IP2OrionGuid'
        $script:Exported | Should -Not -Contain 'Test-IsValidIP'
    }
}

Describe 'Comment-based help' {
    BeforeAll {
        Import-Module $script:ManifestPath -Force
    }

    It '<_> has a synopsis' -ForEach $PublicFns {
        (Get-Help $_ -ErrorAction SilentlyContinue).Synopsis.Trim() | Should -Not -BeNullOrEmpty
    }

    It '<_> has at least one example' -ForEach $PublicFns {
        @((Get-Help $_ -ErrorAction SilentlyContinue).Examples.Example).Count |
            Should -BeGreaterThan 0
    }
}

Describe 'Static analysis (PSScriptAnalyzer)' -Skip:(-not (Get-Module -ListAvailable PSScriptAnalyzer)) {
    BeforeAll {
        Import-Module PSScriptAnalyzer -Force
        $script:Analysis = Invoke-ScriptAnalyzer -Path (Join-Path $script:ModuleRoot 'PowerOrion.psm1')
    }

    It 'produces no Error-severity findings' {
        $errors = $script:Analysis | Where-Object Severity -eq 'Error'
        $errors | Should -BeNullOrEmpty -Because ($errors | Out-String)
    }

    # Informational: surfaces warnings (e.g. assignment-in-condition) without failing the
    # build. Tighten to a hard assertion once the streamlining phase clears them.
    It 'reports its warning count (informational)' {
        $warnings = @($script:Analysis | Where-Object Severity -eq 'Warning')
        Write-Host "  PSScriptAnalyzer warnings: $($warnings.Count)"
        $true | Should -BeTrue
    }
}
