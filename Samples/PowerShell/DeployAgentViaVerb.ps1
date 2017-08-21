# This sample script demonstrates the use of verbs to deploy SolarWinds Agents.
# It contains multiple examples how the verb can be used in different scenarios.
#
# Please note that this script is not runnable as is. You should get only parts 
# valid for your scenario.

# =============================================================================
# Full verb signature with comments
# =============================================================================

Invoke-SwisVerb $swis Orion.AgentManagement.Agent Deploy @(
    # ID of polling engine to which the Agent should be connected after deployment
    # [required]
    $engineId,` 
    # Name of the agent to show in UI
    # [required]
    $agentName,`
    # Hostname to which agent should be deployed. Can contain also IP address. 
    # [can be empty or $null if $ip argument below is defined]
    $hostname,`
    # IP Address to which agent should be deployed.
    # [can be empty or $null if $hostname argument above is defined]
    $ip,` # can be empty or $null if $hostname is set
    # Username for deployment. This user is used to remotelly connect to target machine.
    # [required]
    $machineUsername,`
    # Password to connect to target machine or a private key in PEM format 
    # in case of SSH certificate authentication. $passwordIsPrivateKey argument must be $true
    # when passing certificate.
    # [required]
    $machinePassword,`
    # SUDO username. Can be empty or $null if running SUDO using $machineUsername.
    # [optional]
    $additionalUsername,`
    # SUDO password.
    # [optional, unless $additionalUsername is defined]
    $additionalPassword,`
    # Should be $true if $machinePassword is not a password but an SSH private key.
    # Should be $false if $machinePassword is a a password.
    # [optional]
    $passwordIsPrivateKey,`
    # If $machinePassword contains SSH private key protected by a password the password goes here.
    # [optional]
    $privateKeyPassword,`
    # Allows to manually select agent mode.
    # 0 - automatic detection, 1 - force active agent, 2 - force passive agent
    # [optional]
    $agentMode,` 
    # If deploying to unsupported Linux distribution this argument should contain ID of supported 
    # install package in format <distro>-<version>-<arch>. List of supported packages can 
    # be found in database in table [AgentManagement_InstallPackages]. 
    # Look for [PackageId] column and use one of values here.
    # [optional]
    $installPackageFallbackId` 
)

# =============================================================================
# Real examples of verb usage
# =============================================================================

# Load SwisPowerShell
Import-Module SwisPowerShell

# connect to SWIS - use your connection details and credentials
$hostname = "localhost"
$username = "admin"
$password = ""
$swis = Connect-Swis -Username $username -Password $password

$engineId = 1
$agentName = "agent1"
$hostname = "MyMachine"
$ip = "1.2.3.4"
$machineUsername = "user"
$machinePassword = "password"
# following arguments are optional and these are their default values
$additionalUsername = $null
$additionalPassword = $null
$passwordIsPrivateKey = $false
$privateKeyPassword = $null
$agentMode = 0
$installPackageFallbackId = $null

# Now based on target machine OS and settings you can use following combinations:

# =============================================================================
# Windows or Linux machine - define just username and password
# =============================================================================

Invoke-SwisVerb $swis Orion.AgentManagement.Agent Deploy @(
    $engineId,`
    $agentName,`
    $hostname,`
    $ip,`
    $machineUsername,`
    $machinePassword)
    
# =============================================================================
# Linux machine with required SUDO credentials
# =============================================================================

# SUDO credentials
$additionalUsername = "sudouser"
$additionalPassword = "sudopassword"

Invoke-SwisVerb $swis Orion.AgentManagement.Agent Deploy @(
    $engineId,`
    $agentName,`
    $hostname,`
    $ip,`
    $machineUsername,`
    $machinePassword,`
    $additionalUsername,`
    $additionalPassword)
    
# =============================================================================
# Linux machine using SSH certificate without password
# =============================================================================

$machinePassword = "-----BEGIN RSA PRIVATE KEY-----
Proc-Type: 4,ENCRYPTED
DEK-Info: AES-128-CBC,5A9CEF9457BB240FBF6B3630D13611AF

1rGhcwwx ... FULL CERTIFICATE DATA HERE ...0hqG
-----END RSA PRIVATE KEY----- ";
$passwordIsPrivateKey = $true
# If you don't need SUDO credentials use $null, 
# otherwise use valid credentials for SUDO
$additionalUsername = $null
$additionalPassword = $null

Invoke-SwisVerb $swis Orion.AgentManagement.Agent Deploy @(
    $engineId,`
    $agentName,`
    $hostname,`
    $ip,`
    $machineUsername,`
    $machinePassword,`
    $additionalUsername,`
    $additionalPassword,`
    $passwordIsPrivateKey)
    
# =============================================================================
# Linux machine using SSH certificate with password
# =============================================================================

$machinePassword = "-----BEGIN RSA PRIVATE KEY-----
Proc-Type: 4,ENCRYPTED
DEK-Info: AES-128-CBC,5A9CEF9457BB240FBF6B3630D13611AF

1rGhcwwx ... FULL CERTIFICATE DATA HERE ...0hqG
-----END RSA PRIVATE KEY----- ";
$passwordIsPrivateKey = $true
$privateKeyPassword = "privatekyepassword"
# If you don't need SUDO credentials use $null, 
# otherwise use valid credentials for SUDO
$additionalUsername = $null
$additionalPassword = $null

Invoke-SwisVerb $swis Orion.AgentManagement.Agent Deploy @(
    $engineId,`
    $agentName,`
    $hostname,`
    $ip,`
    $machineUsername,`
    $machinePassword,`
    $additionalUsername,`
    $additionalPassword,`
    $passwordIsPrivateKey,`
    $privateKeyPassword)
    
    
# =============================================================================
# Any machine using username and password but forcing passive agent
# =============================================================================

$machinePassword = "password"
# set unused arguments to default values
$additionalUsername = $null
$additionalPassword = $null
$passwordIsPrivateKey = $false
$privateKeyPassword = $null
# force passive agent
$agentMode = 2

Invoke-SwisVerb $swis Orion.AgentManagement.Agent Deploy @(
    $engineId,`
    $agentName,`
    $hostname,`
    $ip,`
    $machineUsername,`
    $machinePassword,`
    $additionalUsername,`
    $additionalPassword,`
    $passwordIsPrivateKey,`
    $privateKeyPassword,`
    $agentMode)
    
# =============================================================================
# Unsupported Linux machine using username and password and CentOS 7.1 x64 install package
# =============================================================================

$machinePassword = "password"
# set unused arguments to default values
$additionalUsername = $null
$additionalPassword = $null
$passwordIsPrivateKey = $false
$privateKeyPassword = $null
$agentMode = 0
# set install package for CentOS 7.1 x64
$installPackageFallbackId = "centos-7.1-x64"

Invoke-SwisVerb $swis Orion.AgentManagement.Agent Deploy @(
    $engineId,`
    $agentName,`
    $hostname,`
    $ip,`
    $machineUsername,`
    $machinePassword,`
    $additionalUsername,`
    $additionalPassword,`
    $passwordIsPrivateKey,`
    $privateKeyPassword,`
    $agentMode,`
    $installPackageFallbackId)
    
    
