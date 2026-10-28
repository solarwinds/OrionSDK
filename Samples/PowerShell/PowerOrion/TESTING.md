# PowerOrion tests

Automated tests for the `PowerOrion` module, written for **Pester 5+**.

| File | Purpose |
|------|---------|
| `PowerOrion.Tests.ps1` | Functional tests for every public function and internal helper. |
| `PowerOrion.Hygiene.Tests.ps1` | Manifest validity, comment-based help coverage, export contract, module lifecycle, and PSScriptAnalyzer. |

## Requirements

### Pester 5 or later (required)

These tests use Pester 5+ syntax (`BeforeAll`/`BeforeDiscovery` scoping, `-ForEach`, `Should -Invoke`, `New-PesterConfiguration`). They **will not run** on the Pester **3.4** that ships in the box with Windows PowerShell 5.1 — that version silently mis-parses the files or errors on discovery.

Install a current Pester side-by-side with the built-in one (per-user, no admin needed):

```powershell
Install-Module Pester -Scope CurrentUser -Force -SkipPublisherCheck -MinimumVersion 5.5.0
```

`-SkipPublisherCheck` is required because you are installing over a Microsoft-signed module.

Because 3.4 auto-loads first, **always import the modern version explicitly** before running:

```powershell
Import-Module Pester -MinimumVersion 5.0.0 -Force
Get-Module Pester | Select-Object Name, Version   # confirm 5.x / 6.x
```

### Other modules

- **PSScriptAnalyzer** — used by the hygiene tests:
  ```powershell
  Install-Module PSScriptAnalyzer -Scope CurrentUser -Force
  ```
- **SwisPowerShell** — the module's parameters are typed as
  `[SolarWinds.InformationService.Contract2.InfoServiceProxy]`, so this must be
  installed for the module (and its help) to load. No Orion server is contacted
  (see below).

## Running the tests

From this folder:

```powershell
Import-Module Pester -MinimumVersion 5.0.0 -Force
Invoke-Pester -Output Detailed
```

Or with a configuration object (also enables the exit code for CI):

```powershell
$cfg = New-PesterConfiguration
$cfg.Run.Path      = $PSScriptRoot
$cfg.Output.Verbosity = 'Detailed'
Invoke-Pester -Configuration $cfg
```

## No live server required

The suite is fully **offline and deterministic**:

- A real `InfoServiceProxy` is created with `Connect-Swis -Hostname localhost`. The
  connection is lazy, so no network call is made — it just gives the tests a real,
  correctly-typed object to pass around and loads the SWIS type used in parameter
  signatures.
- Every SWIS call (`New-SwisObject`, `Get-SwisData`, `Invoke-SwisVerb`, …) is
  **mocked** with Pester `Mock`, so the tests never read from or write to an Orion
  database.

You can run them on any machine with the modules above — no Orion, no credentials.

## The `KnownBug` tag

A couple of tests are tagged `KnownBug`. They pin the **correct** behavior for defects
that were fixed during the streamlining work. They pass on the current code; the tag
lets you isolate them (for example, to reproduce a regression):

```powershell
Invoke-Pester -ExcludeTagFilter KnownBug   # skip them
Invoke-Pester -TagFilter KnownBug          # run only them
```
