---
layout: default
title: "How To Distribute Load Between Pollers"
---

HCO provides ability to distribute load between Polling engines. Node polling is assigned to a specific Poller Engine and can be moved between Poller Engines later via SDK.  

## Get all Polling engines
```text
https://{IP}:17778/SolarWinds/InformationService/v3/Json/Query?query=SELECT EngineID, ServerName, IP, ServerType, Elements FROM Orion.Engines
```

#### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_

#### Example Response
```json
{
    "results": [
        {
            "EngineID": 1,
            "ServerName": "Hostname1",
            "IP": "10.10.10.10",
            "ServerType": "Primary",
            "Elements": 3
        },
        {
            "EngineID": 2,
            "ServerName": "Hostname2",
            "IP": "10.10.10.11",
            "ServerType": "Additional",
            "Elements": 6
        }
    ]
}
```
_Elements_ property shows the number of elements (Nodes, Interfaces, etc.) assigned to the Polling engine.

## Assign node to specific Polling engine
`Orion.Nodes.Uri` is needed to specify the Node to change Polling engine for.

### :orange_circle: POST Query Request
```text
https://{IP}:17778/SolarWinds/InformationService/v3/Json/{NodeUri}
```

#### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
#### Body raw
```json
{
    "EngineID": 2
}
```
#### Example Response
Returns null with Status 200 OK.
