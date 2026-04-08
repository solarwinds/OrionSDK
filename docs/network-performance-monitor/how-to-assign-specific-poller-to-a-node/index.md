---
layout: default
title: "How To Assign Specific Poller To A Node"
---

The assignment is done automatically based on OID support by that specific Node. Specific Poller can be assigned to the Node via SDK using its name.

## Assigning specific poller to a node
In order to assign a poller you should use the `Orion.Pollers` entity. To assign a custom poller to a node, you need the poller's name (`N.Status.SNMP.Native` in the example below) and the node id (_123_).

### :orange_circle: POST Query Request
```text
https://{IP}:17778/SolarWinds/InformationService/v3/Json/Create/Orion.Pollers
```

#### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_
#### Body raw
```json
{
    "NetObject": "N:123",
    "NetObjectType": "N",
    "NetObjectID": 123,
    "PollerType": "N.Status.SNMP.Native"
}
```

#### Example Response
Returns new record's _Uri_ if the operation is successful.

## Removing specific poller assignment
You can also unassign specific poller by removing it from the `Orion.Pollers` entity using its _Uri_. To get the Poller Uri for specific node you can use the following request:

### :green_circle: GET Query Request
```text
https://{IP}:17778/SolarWinds/InformationService/v3/Json/Query?query=SELECT Uri, PollerType FROM Orion.Pollers WHERE NetObject = 'N:{Node ID}'
```

#### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_

#### Example Response
```json
{
    "results": [
        {
            "Uri": "swis://HOSTNAME/Orion/Orion.Pollers/PollerID=7105",
            "PollerType": "N.ResponseTime.ICMP.Native"
        }
    ]
}
```

### :red_circle: DELETE Query Request
```text
https://{IP}:17778/SolarWinds/InformationService/v3/Json/{SwisUri}
```

#### Headers 
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_ 

## Assigning custom (UnDP) poller
See [NPM Universal Device Pollers](../npm-universal-device-pollers/) section for the instructions.

## Additional resources
- [Managing Node Pollers Via API - Orion SDK - The Orion Platform - THWACK (solarwinds.com)](https://thwack.solarwinds.com/products/the-orion-platform/f/orion-sdk/92133/managing-node-pollers-via-api)
