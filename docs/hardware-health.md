---
title: Hardware Health
---

Hardware health information can be queried using various entities in the `Orion.HardwareHealth` namespace.

## Enabling Hardware Health Polling

To enable hardware health polling for a node, invoke the `EnableHardwareHealth` verb on the `Orion.HardwareHealth.HardwareInfoBase` entity, which expects two arguments:

1. netObject (string) - the NodeID prefixed with `N:` (for example, `N:123`)
2. pollingMethod (int) - one of the `HardwareHealthPollingMethod` values; see table below

### HardwareHealthPollingMethod

|Value|Meaning|
|-----|-------|
|0 |Unknown |
|1 |VMware |
|2 |SnmpDell |
|3 |SnmpHP |
|4 |SnmpIBM |
|5 |VMwareAPI |
|6 |WmiDell |
|7 |WmiHP |
|8 |WmiIBM |
|9 |SnmpCisco |
|10 |SnmpJuniper |
|11 |SnmpNPMHP |
|12 |SnmpF5 |
|13 |SnmpDellPowerEdge |
|14 |SnmpDellPowerConnect |
|15 |SnmpDellBladeChassis |
|16 |SnmpHPBladeChassis |
|17 |Forwarded |
|18 |SnmpArista |

## Disabling Hardware Health Polling

To stop collecting hardware health information for a node, invoke the `DisableHardwareHealth` verb on the `Orion.HardwareHealth.HardwareInfoBase` entity, which expects one argument:

1. netObject (string) - the NodeID prefixed with `N:` (for example, `N:123`)

This will not remove the previously collected hardware information for that node, only stop collecting it.

## Deleting collected Hardware Health Information

To remove collected hardware health information for a node, invoke the `DeleteHardwareHealth` verb on the `Orion.HardwareHealth.HardwareInfoBase` entity, which expects one argument:

1. netObject (string) - the NodeID prefixed with `N:` (for example, `N:123`)
