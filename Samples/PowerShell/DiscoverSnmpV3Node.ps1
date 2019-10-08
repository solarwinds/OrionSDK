# This sample script shows how to use the Orion Discovery API to discover and import one node using SNMPv3 credentials.

# Load SwisPowerShell
Import-Module SwisPowerShell

# Swis connection info
$OrionServer = "localhost"
$Username = "admin"
$Password = ""

# Discovery parameters
$ip = "10.199.4.3"
$snmpv3credentialname1 = "foo"
$snmpv3credentialname2 = "bar"
$engindId = 1
$DeleteProfileAfterDiscoveryCompletes = "true"

$swis = Connect-Swis $OrionServer -UserName $Username -Password $Password

# Get the ID of the named SNMPv3 credential
$snmpv3credentialid1 = Get-SwisData $swis "SELECT ID FROM Orion.Credential WHERE Name=@name" @{name = $snmpv3credentialname1}
$snmpv3credentialid2 = Get-SwisData $swis "SELECT ID FROM Orion.Credential WHERE Name=@name" @{name = $snmpv3credentialname2}

$CorePluginConfigurationContext = ([xml]"
<CorePluginConfigurationContext xmlns='http://schemas.solarwinds.com/2012/Orion/Core' xmlns:i='http://www.w3.org/2001/XMLSchema-instance'>
	<BulkList>
		<IpAddress>
			<Address>$ip</Address>
		</IpAddress>
	</BulkList>
	<Credentials>
		<SharedCredentialInfo>
			<CredentialID>$snmpv3credentialid1</CredentialID>
			<Order>1</Order>
		</SharedCredentialInfo>
		<SharedCredentialInfo>
			<CredentialID>$snmpv3credentialid2</CredentialID>
			<Order>2</Order>
		</SharedCredentialInfo>
	</Credentials>
	<WmiRetriesCount>1</WmiRetriesCount>
	<WmiRetryIntervalMiliseconds>1000</WmiRetryIntervalMiliseconds>
</CorePluginConfigurationContext>
").DocumentElement

$CorePluginConfiguration = Invoke-SwisVerb $swis Orion.Discovery CreateCorePluginConfiguration @($CorePluginConfigurationContext)

$StartDiscoveryContext = ([xml]"
<StartDiscoveryContext xmlns='http://schemas.solarwinds.com/2012/Orion/Core' xmlns:i='http://www.w3.org/2001/XMLSchema-instance'>
	<Name>Script Discovery $([DateTime]::Now)</Name>
	<EngineId>$engindId</EngineId>
	<JobTimeoutSeconds>3600</JobTimeoutSeconds>
	<SearchTimeoutMiliseconds>2000</SearchTimeoutMiliseconds>
	<SnmpTimeoutMiliseconds>2000</SnmpTimeoutMiliseconds>
	<SnmpRetries>1</SnmpRetries>
	<RepeatIntervalMiliseconds>1500</RepeatIntervalMiliseconds>
	<SnmpPort>161</SnmpPort>
	<HopCount>0</HopCount>
	<PreferredSnmpVersion>SNMP2c</PreferredSnmpVersion>
	<DisableIcmp>false</DisableIcmp>
	<AllowDuplicateNodes>false</AllowDuplicateNodes>
	<IsAutoImport>true</IsAutoImport>
	<IsHidden>$DeleteProfileAfterDiscoveryCompletes</IsHidden>
	<PluginConfigurations>
		<PluginConfiguration>
			<PluginConfigurationItem>$($CorePluginConfiguration.InnerXml)</PluginConfigurationItem>
		</PluginConfiguration>
	</PluginConfigurations>
</StartDiscoveryContext>
").DocumentElement

$DiscoveryProfileID = (Invoke-SwisVerb $swis Orion.Discovery StartDiscovery @($StartDiscoveryContext)).InnerText

Write-Host -NoNewline "Discovery profile #$DiscoveryProfileID running..."

# Wait until the discovery completes
do {
    Write-Host -NoNewline "."
    Start-Sleep -Seconds 1
    $Status = Get-SwisData $swis "SELECT Status FROM Orion.DiscoveryProfiles WHERE ProfileID = @profileId" @{profileId = $DiscoveryProfileID}
} while ($Status -eq 1)

# If $DeleteProfileAfterDiscoveryCompletes is true, then the profile will be gone at this point, but we can still get the result from Orion.DiscoveryLogs

$Result = Get-SwisData $swis "SELECT Result, ResultDescription, ErrorMessage, BatchID FROM Orion.DiscoveryLogs WHERE ProfileID = @profileId" @{profileId = $DiscoveryProfileID}

# Print the outcome
switch ($Result.Result) {
    0 {"Unknown"}
    1 {"InProgress"}
    2 {"Finished"}
    3 {"Error"}
    4 {"NotScheduled"}
    5 {"Scheduled"}
    6 {"NotCompleted"}
    7 {"Canceling"}
    8 {"ReadyForImport"}
}
$Result.ResultDescription
$Result.ErrorMessage

if ($Result.Result -eq 2) { # if discovery completed successfully
    # Find out what objects were discovered
    $Discovered = Get-SwisData $swis "SELECT EntityType, DisplayName, NetObjectID FROM Orion.DiscoveryLogItems WHERE BatchID = @batchId" @{batchId = $Result.BatchID}
    "$($Discovered.Count) items imported."
    $Discovered
}
