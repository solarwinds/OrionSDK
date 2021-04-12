---
title: UDT vNext API
---

## Create UDT Port

| Parameter            | Type   | Required | Default |  Comment  |
| -------------------- | ------ | -------- | ------- | --------- |
| NodeID               | int    | yes      |         | NodeID must exists in Nodes table |
| PortIndex            | int    | yes      |         |  |
| Name                 | string | yes      |         | Maximum 255 symbols |
| MACAddress           | string | yes      |         | 12 symbols 0-9, A-F, possible deilmiters : or - |
| IsMonitored          | bool   | no       | true    |   |
| PortType             | int    | no       | 6       | Values 0-258 and 555 are allowed |
| Speed                | int    | no       | 0       | Zero positive value only |
| Duplex               | int    | no       | 0       | Allowed values:<br /> 0 - Unknown <br /> 1 - FullDuplex <br /> 2 - HalfDuplex <br /> 3 - Disagree <br /> 4 -  AutoNegotiate |
| TrunkMode            | int    | no       | 0       | Allowed values:<br /> 0 - Unknown <br /> 1 - Trunking <br /> 2 - NonTrunking |
| PortDescription      | string | no       |         | Maximum 255 symbols |
| OperationalStatus    | int    | no       | 1       | Allowed values:<br /> 1 - Up <br /> 2 - Down <br /> 3 - Testing <br /> 4 - Unknown <br /> 5 - Dormant <br /> 6 - NotPresent |
| AdministrativeStatus | int    | no       | 0       | Allowed values:<br /> 0 - Unknown  <br /> 1 - Up <br /> 2 - Down <br /> 3 - Testing |
| IgnorePortRules      | bool   | no       | false   |   |
| Flag                 | int    | no       | 0       |   |
| IsExcluded           | bool   | no       | false   |   |

## Updated UDT Port

Only IsMonitored property is allowed to be updated
Sample

```powershell
Set-SwisObject $swis -Uri 'swis://localhost/Orion/Orion.Nodes/NodeID={node_id_here}/Ports/PortID={port_id_here}'  -Properties @{IsMonitored=0;}
```

## Delete UDT Port

Sample

```powershell
Remove-SwisObject $swis -Uri 'swis://localhost/Orion/Orion.Nodes/NodeID={node_id_here}/Ports/PortID={port_id_here}'
```
