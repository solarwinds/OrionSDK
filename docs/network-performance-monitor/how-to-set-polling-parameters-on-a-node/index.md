---
layout: default
title: "How To Set Polling Parameters On A Node"
---

Node is created with default parameters and can be configured later via SDK.

## Basic polling parameters on a Node
``Orion.Nodes`` entity stores next basic polling parameters of the node:
* PollInterval - Node Status Polling Interval
* RediscoveryInterval  - Orion Rediscovery Interval

Note that some technologies rely on the Node Status Polling Interval for its specific settings.

### How to check current basic polling intervals on node?
 
### :red_circle: GET Query Request
```
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Query?query=SELECT+NodeID,+ipAddress,+PollInterval,+RediscoveryInterval+FROM+Orion.Nodes
```

#### Headers
**Authorization:** _{{basicAuthorization}}_

##### Example Response
```
"results": [
        {
            "NodeID": 1,
            "ipAddress": "ip_address",
            "PollInterval": 120,
            "RediscoveryInterval": 30
        }
       ]
```
### How to change basic polling intervals on node?

To set new values for given parameters, the UPDATE action on ``Orion.Nodes`` entity should be performed.

``Orion.Nodes.Uri`` is needed to specify the Node to change polling intervals for.
	
### :red_circle: POST Query Request

```
https://{IP}:17774/SolarWinds/InformationService/v3/Json/{NodeUri}
```

#### Headers
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_

#### Body raw
```
{
    "PollInterval": 60,
    "RediscoveryInterval": 30
}
```

#### Example Response
Returns _Status 200 OK_ and updates data.

## Polling settings on a Node ##

``Orion.NodeSettings`` entity contains custom node settings. For example, the setting to setup the port number for Cli polling on a Node with NodeID=10.

CREATE action for ``Orion.NodeSettings`` is needed for adding the setting for a Node.

### :red_circle: POST Query Request
```
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Create/Orion.NodeSettings
```

#### Headers
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_

#### Body raw
```
{
    "NodeID": 10,
    "SettingName": "CLI.Port",
    "SettingValue": "22"
}
```
#### Example Response
Returns the Uri of created setting.
```
swis://{hostname}./Orion/Orion.NodeSettings/NodeSettingID=54
```

## Global polling settings change
``Orion.Settings`` entity stores different Global Advanced settings, including polling intervals for specific areas like Default VRF poll interval ``'NPM_Settings_Routing_VRF_PollInterval'``.

For example, Default Node Poll Interval can be set globally for all nodes in ``Orion.Settings`` entity.

### How to check current value for a global setting?
To check the current value of the global setting the GET Query Request can be used.

Provided example below gets the current and default value for setting with SettingID ``WLP_Settings_PollRogues``.

### :green_circle: GET Query Request
```
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Query?query=SELECT+CurrentValue,+DefaultValue+FROM+Orion.Settings+WHERE+SettingID='WLP_Settings_PollRogues'
```

#### Headers
**Authorization:** _{{basicAuthorization}}_
#### Example Response
```
{
    "results": [
        {
            "CurrentValue": 0.0,
            "DefaultValue": 1.0
        }
    ]
}
```

### How to update global setting?
Provided example below updates the current value of global setting with given SettingID.

### :red_circle: POST Query Request
```
https://{IP}:17774/SolarWinds/InformationService/v3/Json/swis://{hostname}./Orion/Orion.Settings/SettingID="{SettingID}"
```

For instance, for updating the setting to enable Wireless Rogue AP Polling with SettingID ``WLP_Settings_PollRogues`` the POST query will look like:
```
https://{IP}:17774/SolarWinds/InformationService/v3/Json/swis://{hostname}./Orion/Orion.Settings/SettingID="WLP_Settings_PollRogues"
```

#### Headers
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_

#### Body raw
```
{
    "CurrentValue": 1
}
```
#### Example Response
Returns Status 200 OK and updates data.