#Requires -Modules @{ ModuleName = 'Pester'; ModuleVersion = '5.0.0' }
<#
    .DESCRIPTION
    Pester tests for the PowerOrion module (https://github.com/solarwinds/OrionSDK).

    These tests are fully offline and deterministic:
      * A real InfoServiceProxy is built with `Connect-Swis -Hostname localhost`, which
        constructs the proxy object WITHOUT contacting any server (the connection is lazy).
        This satisfies the module's mandatory [InfoServiceProxy] parameters.
      * Every SwisPowerShell cmdlet the module calls (Get-SwisData, New-SwisObject,
        Get-SwisObject, Remove-SwisObject, Invoke-SwisVerb) is mocked, so no network I/O
        ever occurs.

    Some tests assert *correct* behavior and are expected to fail until the corresponding
    bug is fixed in the streamlining phase. They are tagged 'KnownBug' so they can be
    isolated (Invoke-Pester -ExcludeTagFilter KnownBug) while refactoring.

    .NOTES
    Name: PowerOrion.Tests.ps1
    Author: Michael Halpin (original), modernized for Pester 5/6
#>

Import-Module SwisPowerShell -Force -ErrorAction Stop
Import-Module (Join-Path $PSScriptRoot 'PowerOrion.psd1') -Force -ErrorAction Stop

InModuleScope PowerOrion {

    BeforeAll {
        # Real proxy object, but no server is contacted (connection is lazy, and all
        # query cmdlets are mocked in the tests below).
        $script:swis = Connect-Swis -Hostname 'localhost' -UserName 'test' -Password 'test'
    }

    # ------------------------------------------------------------------ #
    #  Pure helper functions (no SWIS dependency)                        #
    # ------------------------------------------------------------------ #

    Describe 'Convert-IP2OrionGuid' {
        It 'returns the known GUID for 127.0.0.1' {
            Convert-IP2OrionGuid -IPAddress '127.0.0.1' |
                Should -Be '0100007f-0000-0000-0000-000000000000'
        }
        It 'returns the known GUID for 10.199.1.100' {
            Convert-IP2OrionGuid -IPAddress '10.199.1.100' |
                Should -Be '6401c70a-0000-0000-0000-000000000000'
        }
        It 'is deterministic for the same input' {
            $a = Convert-IP2OrionGuid -IPAddress '192.168.1.1'
            $b = Convert-IP2OrionGuid -IPAddress '192.168.1.1'
            $a | Should -Be $b
        }
        It 'produces a parseable GUID' {
            $result = Convert-IP2OrionGuid -IPAddress '8.8.8.8'
            { [guid]$result } | Should -Not -Throw
        }
    }

    Describe 'Test-IsValidIP' {
        It 'returns True for a valid IPv4 address' {
            Test-IsValidIP -IPAddress '10.0.0.1' | Should -BeTrue
        }
        It 'returns True for a valid IPv6 address' {
            Test-IsValidIP -IPAddress 'fe80::1' | Should -BeTrue
        }
        It 'returns False for an invalid address' {
            Test-IsValidIP -IPAddress '999.0.0.1' -WarningAction SilentlyContinue |
                Should -BeFalse
        }
    }

    Describe 'Get-IPAddressFromHostName' {
        It 'resolves localhost to a loopback address' {
            $result = Get-IPAddressFromHostName -NodeName 'localhost'
            ($result -join ',') | Should -Match '127\.0\.0\.1|::1'
        }
    }

    Describe 'Get-HostNamefromIPAddress' {
        It 'does not throw for a loopback address' {
            { Get-HostNamefromIPAddress -IPAddress '127.0.0.1' } | Should -Not -Throw
        }
    }

    # ------------------------------------------------------------------ #
    #  Connection helper                                                 #
    # ------------------------------------------------------------------ #

    Describe 'Get-OrionHostFromSwisConnection' {
        It 'extracts the host from a SWIS connection' {
            Get-OrionHostFromSwisConnection -swisconnection $script:swis |
                Should -Be 'localhost'
        }
    }

    # ------------------------------------------------------------------ #
    #  Query functions (Get-SwisData mocked)                             #
    # ------------------------------------------------------------------ #

    Describe 'Get-OrionNodeID' {
        BeforeAll { Mock Get-SwisData { 42 } }

        It 'returns the value from SWIS when queried by node name' {
            Get-OrionNodeID -NodeName 'router1' -SwisConnection $script:swis | Should -Be 42
        }
        It 'queries by Caption when a node name is supplied' {
            Get-OrionNodeID -NodeName 'router1' -SwisConnection $script:swis | Out-Null
            Should -Invoke Get-SwisData -Times 1 -Exactly `
                -ParameterFilter { $Query -match 'Caption=@n' }
        }
        It 'queries by IP_Address when an IP is supplied' {
            Get-OrionNodeID -IPAddress '10.0.0.1' -SwisConnection $script:swis | Out-Null
            Should -Invoke Get-SwisData -ParameterFilter { $Query -match 'IP_Address=@ip' }
        }
        It 'queries all nodes when -all is supplied' {
            Get-OrionNodeID -all -SwisConnection $script:swis | Out-Null
            Should -Invoke Get-SwisData -ParameterFilter { $Query -match 'order by nodeid' }
        }
    }

    Describe 'Get-OrionWMICredential' {
        BeforeAll { Mock Get-SwisData { [pscustomobject]@{ ID = 1; Name = 'Local Admin' } } }

        It 'queries the Orion.Credential entity' {
            Get-OrionWMICredential -SwisConnection $script:swis | Out-Null
            Should -Invoke Get-SwisData -ParameterFilter { $Query -match 'Orion\.Credential' }
        }
        It 'returns the credential object' {
            (Get-OrionWMICredential -SwisConnection $script:swis).Name | Should -Be 'Local Admin'
        }
    }

    Describe 'Get-OrionApplicationTemplateId' {
        It 'returns the template id for an existing application' {
            Mock Get-SwisData { 6 }
            Get-OrionApplicationTemplateId -ApplicationName 'apache' -SwisConnection $script:swis |
                Should -Be 6
        }
        It 'queries the ApplicationTemplate entity by name' {
            Mock Get-SwisData { 6 }
            Get-OrionApplicationTemplateId -ApplicationName 'apache' -SwisConnection $script:swis | Out-Null
            Should -Invoke Get-SwisData -ParameterFilter { $Query -match 'Orion\.APM\.ApplicationTemplate' }
        }
        It 'errors when the template does not exist' {
            Mock Get-SwisData { $null }
            { Get-OrionApplicationTemplateId -ApplicationName 'nope' -SwisConnection $script:swis -ErrorAction Stop } |
                Should -Throw
        }
    }

    Describe 'Get-OrionApplicationCredential' {
        It 'returns the credential id for an existing credential' {
            Mock Get-SwisData { 6 }
            Get-OrionApplicationCredential -credential 'AppCred' -SwisConnection $script:swis |
                Should -Be 6
        }
        It 'queries APM-owned credentials by name' {
            Mock Get-SwisData { 6 }
            Get-OrionApplicationCredential -credential 'AppCred' -SwisConnection $script:swis | Out-Null
            Should -Invoke Get-SwisData -ParameterFilter { $Query -match "CredentialOwner='APM'" }
        }
        It 'errors when the credential does not exist' {
            Mock Get-SwisData { $null }
            { Get-OrionApplicationCredential -credential 'nope' -SwisConnection $script:swis -ErrorAction Stop } |
                Should -Throw
        }
    }

    Describe 'Get-OrionNextAvailableIPAddress' {
        BeforeAll {
            Mock Get-SwisData { [pscustomobject]@{ DisplayName = '192.168.1.2'; Subnet = '192.168.1.0 /24' } }
        }
        It 'selects the first available IP' {
            Get-OrionNextAvailableIPAddress -swisconnection $script:swis | Out-Null
            Should -Invoke Get-SwisData -ParameterFilter { $Query -match 'TOP 1' -and $Query -match 'Status=2' }
        }
        It 'filters by subnet when one is supplied' {
            Get-OrionNextAvailableIPAddress -swisconnection $script:swis -Subnet 'DMZ' | Out-Null
            Should -Invoke Get-SwisData -ParameterFilter { $Query -match 'like @subnet' -and $Parameters.subnet -eq 'DMZ' }
        }
    }

    Describe 'Get-OrionNode' {
        BeforeAll {
            Mock Get-OrionHostFromSwisConnection { 'localhost' }
            Mock Get-SwisObject { @{ NodeID = 3; Caption = 'router1' } }
            Mock Get-OrionNodeID { 3 }
        }
        It 'builds the node URI from the node id' {
            Get-OrionNode -NodeID 3 -SwisConnection $script:swis | Out-Null
            Should -Invoke Get-SwisObject -ParameterFilter { $Uri -match 'Orion\.Nodes/NodeID=3$' }
        }
        It 'targets CustomProperties when -custom is supplied' {
            Get-OrionNode -NodeID 3 -SwisConnection $script:swis -custom | Out-Null
            Should -Invoke Get-SwisObject -ParameterFilter { $Uri -match '/CustomProperties$' }
        }
        It 'resolves the id via Get-OrionNodeID when an IP is supplied' {
            Get-OrionNode -IPAddress '10.0.0.1' -SwisConnection $script:swis | Out-Null
            Should -Invoke Get-OrionNodeID -Times 1
        }
        It 'returns a PSObject' {
            Get-OrionNode -NodeID 3 -SwisConnection $script:swis | Should -BeOfType [psobject]
        }
    }

    Describe 'Remove-OrionNode' {
        BeforeAll {
            Mock Get-OrionHostFromSwisConnection { 'localhost' }
            Mock Remove-SwisObject { }
            Mock Get-OrionNodeID { 5 }
        }
        It 'removes the object at the node URI (by id)' {
            Remove-OrionNode -NodeID 5 -SwisConnection $script:swis -Confirm:$false
            Should -Invoke Remove-SwisObject -ParameterFilter { $Uri -match 'Orion\.Nodes/NodeID=5$' }
        }
        It 'resolves the id via Get-OrionNodeID when a name is supplied' {
            Remove-OrionNode -NodeName 'router1' -SwisConnection $script:swis -Confirm:$false
            Should -Invoke Get-OrionNodeID -Times 1
        }
        It 'returns the node URI string' {
            $uri = Remove-OrionNode -NodeID 5 -SwisConnection $script:swis -Confirm:$false
            $uri | Should -BeOfType [string]
            $uri | Should -Be 'swis://localhost/Orion/Orion.Nodes/NodeID=5'
        }
    }

    # ------------------------------------------------------------------ #
    #  Poller creation                                                   #
    # ------------------------------------------------------------------ #

    Describe 'New-OrionPollerType' {
        BeforeAll { Mock New-SwisObject { 'swis://localhost/Orion/Orion.Pollers/PollerID=1' } }

        It 'builds an interface poller (I:) from interface properties' {
            New-OrionPollerType -PollerType 'I.Status.SNMP.IfTable' `
                -InterfaceProperties @{ InterfaceID = 9 } `
                -PollerObjectType 'Interface' -SwisConnection $script:swis | Out-Null
            Should -Invoke New-SwisObject -ParameterFilter {
                $EntityType -eq 'Orion.Pollers' -and
                $Properties.NetObject -eq 'I:9' -and $Properties.NetObjectType -eq 'I'
            }
        }

        It 'builds a node poller (N:) from node properties' -Tag 'KnownBug' {
            # BUG: the function tests `$PollerType -eq 'node'` (a poller-type string that is
            # never 'node') instead of `$PollerObjectType -eq 'Node'`, so the node branch is
            # dead. Expected correct behavior asserted here; fix in streamlining phase.
            New-OrionPollerType -PollerType 'N.Status.ICMP.Native' `
                -NodeProperties @{ NodeID = 7 } `
                -PollerObjectType 'Node' -SwisConnection $script:swis | Out-Null
            Should -Invoke New-SwisObject -ParameterFilter {
                $Properties.NetObject -eq 'N:7' -and $Properties.NetObjectType -eq 'N'
            }
        }
    }

    # ------------------------------------------------------------------ #
    #  Node creation                                                     #
    # ------------------------------------------------------------------ #

    Describe 'New-OrionNode' {
        BeforeAll {
            Mock New-SwisObject { 'swis://localhost/Orion/Orion.Nodes/NodeID=1' }
            Mock Get-SwisObject { @{ NodeID = 1 } }
            Mock New-OrionPollerType { }
        }

        It 'creates an Orion.Nodes object' {
            New-OrionNode -SwisConnection $script:swis -IPAddress '10.0.0.1' -Confirm:$false | Out-Null
            Should -Invoke New-SwisObject -ParameterFilter { $EntityType -eq 'Orion.Nodes' }
        }

        It 'adds pollers for the new node' {
            New-OrionNode -SwisConnection $script:swis -IPAddress '10.0.0.1' -Confirm:$false | Out-Null
            Should -Invoke New-OrionPollerType -Times 3   # ICMP defines 3 poller types
        }

        It 'does NOT add WMI node settings for an ICMP node' -Tag 'KnownBug' {
            # BUG: `if($ObjectSubType = "WMI")` is an assignment, not a comparison (-eq),
            # so WMI credential settings are added for every node type. Correct behavior:
            # an ICMP node should create no Orion.NodeSettings object.
            New-OrionNode -SwisConnection $script:swis -IPAddress '10.0.0.1' -Confirm:$false | Out-Null
            Should -Invoke New-SwisObject -Times 0 -Exactly `
                -ParameterFilter { $EntityType -eq 'Orion.NodeSettings' }
        }

        It 'adds WMI node settings for a WMI node' {
            New-OrionNode -SwisConnection $script:swis -IPAddress '10.0.0.2' `
                -ObjectSubType 'WMI' -CredentialID 5 -Confirm:$false | Out-Null
            Should -Invoke New-SwisObject -ParameterFilter { $EntityType -eq 'Orion.NodeSettings' }
        }
    }

    # ------------------------------------------------------------------ #
    #  Interface creation                                                #
    # ------------------------------------------------------------------ #

    Describe 'New-OrionInterface' {
        BeforeAll {
            Mock New-SwisObject { 'swis://localhost/Orion/Orion.NPM.Interfaces/InterfaceID=11' }
            Mock Get-SwisObject { @{ InterfaceID = 11 } }
            Mock New-OrionPollerType { }
        }

        It 'creates an Orion.NPM.Interfaces object with the supplied node id and name' {
            New-OrionInterface -SwisConnection $script:swis -NodeId 3 -InterfaceName 'Gi0/0' | Out-Null
            Should -Invoke New-SwisObject -ParameterFilter {
                $EntityType -eq 'Orion.NPM.Interfaces' -and
                $Properties.NodeID -eq 3 -and $Properties.InterfaceName -eq 'Gi0/0'
            }
        }

        It 'registers the four interface pollers' {
            New-OrionInterface -SwisConnection $script:swis -NodeId 3 -InterfaceName 'Gi0/0' | Out-Null
            Should -Invoke New-OrionPollerType -Times 4
        }
    }

    # ------------------------------------------------------------------ #
    #  Interface discovery                                               #
    # ------------------------------------------------------------------ #

    Describe 'Add-OrionDiscoveredInterfaces' {
        It 'adds discovered interfaces on success' {
            Mock Invoke-SwisVerb -ParameterFilter { $Verb -eq 'DiscoverInterfacesOnNode' } -MockWith {
                [pscustomobject]@{ Result = 'Succeed'; DiscoveredInterfaces = [pscustomobject]@{} }
            }
            Mock Invoke-SwisVerb -ParameterFilter { $Verb -eq 'AddInterfacesOnNode' } -MockWith {
                [pscustomobject]@{ Result = 'Succeed' }
            }

            $result = Add-OrionDiscoveredInterfaces -SwisConnection $script:swis -NodeId 13
            $result.Result | Should -Be 'Succeed'
            Should -Invoke Invoke-SwisVerb -ParameterFilter { $Verb -eq 'AddInterfacesOnNode' } -Times 1
        }

        It 'warns and does not add when discovery fails' {
            Mock Invoke-SwisVerb -ParameterFilter { $Verb -eq 'DiscoverInterfacesOnNode' } -MockWith {
                [pscustomobject]@{ Result = 'Fail' }
            }
            Mock Invoke-SwisVerb -ParameterFilter { $Verb -eq 'AddInterfacesOnNode' } -MockWith { }

            $result = Add-OrionDiscoveredInterfaces -SwisConnection $script:swis -NodeId 13 -WarningAction SilentlyContinue
            $result | Should -BeNullOrEmpty
            Should -Invoke Invoke-SwisVerb -ParameterFilter { $Verb -eq 'AddInterfacesOnNode' } -Times 0 -Exactly
        }

        It 'excludes interfaces of an excluded type before adding' {
            $script:removed = @()
            $discovered = [pscustomobject]@{
                DiscoveredLiteInterface = @(
                    [pscustomobject]@{ ifType = 6 },
                    [pscustomobject]@{ ifType = 22 }
                )
            }
            $discovered | Add-Member -MemberType ScriptMethod -Name RemoveChild -Value {
                param($child) $script:removed += $child
            }
            Mock Invoke-SwisVerb -ParameterFilter { $Verb -eq 'DiscoverInterfacesOnNode' } -MockWith {
                [pscustomobject]@{ Result = 'Succeed'; DiscoveredInterfaces = $discovered }
            }
            Mock Invoke-SwisVerb -ParameterFilter { $Verb -eq 'AddInterfacesOnNode' } -MockWith {
                [pscustomobject]@{ Result = 'Succeed' }
            }

            Add-OrionDiscoveredInterfaces -SwisConnection $script:swis -NodeId 13 -ExcludedInterfaceType 22 | Out-Null
            $script:removed.Count | Should -Be 1
            $script:removed[0].ifType | Should -Be 22
        }
    }

    # ------------------------------------------------------------------ #
    #  Custom properties                                                 #
    # ------------------------------------------------------------------ #

    Describe 'New-OrionCustomProperty' {
        It 'calls CreateCustomProperty when no values are supplied' {
            Mock Invoke-SwisVerb { 0 }
            New-OrionCustomProperty -swisconnection $script:swis -PropertyName 'Test1' `
                -BaseType 'Orion.NodesCustomProperties' | Out-Null
            Should -Invoke Invoke-SwisVerb -ParameterFilter { $Verb -eq 'CreateCustomProperty' }
        }
        It 'calls CreateCustomPropertyWithValues when values are supplied' {
            Mock Invoke-SwisVerb { 0 }
            [string[]]$values = 'QA', 'Dev', 'Prod'
            New-OrionCustomProperty -swisconnection $script:swis -PropertyName 'AppType' `
                -BaseType 'Orion.NodesCustomProperties' -values $values | Out-Null
            Should -Invoke Invoke-SwisVerb -ParameterFilter { $Verb -eq 'CreateCustomPropertyWithValues' }
        }
    }
}
