---
layout: default
title: "How To Specify Interfaces Volumes Hw Sensors Applications Components To Be Monitored On A Node"
---


## How to discover Interfaces on Node?
To discover Interfaces on Node an INVOKE of the ``DiscoverInterfacesOnNode`` verb on ``Orion.NPM.Interfaces`` entity can be used.

``NodeID`` is needed.

### :red_circle: POST Query Request
```
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.NPM.Interfaces/DiscoverInterfacesOnNode
```

#### Headers
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_

#### Body raw
```
{
    "NodeID": 1
}
```
#### Example Response
Given example responded with one monitored Interface in Orion, and the other one is not monitored interface of a Node.
```
{
    "DiscoveredInterfaces": [
        {
            "ifIndex": 1,
            "Caption": "interface_caption",
            "ifType": 6,
            "ifSubType": 0,
            "InterfaceID": 1,
            "Manageable": true,
            "ifSpeed": 0.0,
            "ifAdminStatus": 1,
            "ifOperStatus": 1
        },
        {
            "ifIndex": 2,
            "Caption": "interface2_caption",
            "ifType": 6,
            "ifSubType": 0,
            "InterfaceID": 0,
            "Manageable": true,
            "ifSpeed": 0.0,
            "ifAdminStatus": 1,
            "ifOperStatus": 2
        }
    ],
    "Result": 0
}
```

``"Result": 0`` indicates that operation succeeded.

Other possible responses are ``"Result": 1``  for Invalid Node error, and ``"Result": 2`` for Generic Error.

## How to add interfaces on a Node?
``AddInterfacesOnNode`` verb of the ``Orion.NPM.Interfaces`` entity can be used to add certain interfaces for a Node.

To get Interfaces of the Node described above ``DiscoverInterfacesOnNode`` verb can be used.

``Node ID`` is needed.

### :red_circle: POST Query Request
```
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.NPM.Interfaces/AddInterfacesOnNode
```
#### Headers
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_

#### Body raw
```
{
    "nodeId": 38,
    "interfacesToAdd": [
        {
            "ifIndex": 3,
            "Caption": "interface_caption",
            "ifType": 6,
            "ifSubType": 0,
            "InterfaceID": 0,
            "Manageable": true,
            "ifSpeed": "0.0",
            "ifAdminStatus": 1,
            "ifOperStatus": 2
        }
    ],
    "pollers": "AddDefaultPollers" 
}
```
#### Example Response
Response contains new Interface Discovery Information, where InterfaceID obtains its new value, as the Interface started to be monitored by Orion.
```
{
    "DiscoveredInterfaces": [
        {
            "ifIndex": 3,
            "Caption": "interface_caption",
            "ifType": 6,
            "ifSubType": 0,
            "InterfaceID": 591,
            "Manageable": true,
            "ifSpeed": 0.0,
            "ifAdminStatus": 1,
            "ifOperStatus": 2
        }
    ],
    "Result": 0
}
```
``"Result": 0`` indicates that operation succeeded.

Other possible responses are ``"Result": 1``  for Invalid Node error, and ``"Result": 2`` for Generic Error.

## How to Remanage Interface on a Node?
``Remanage`` verb of the ``Orion.NPM.Interfaces`` entity can be used to start managing certain interfaces on a Node.

### :red_circle: POST Query Request
```
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.NPM.Interfaces/Remanage
```
#### Headers
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_

#### Body raw
```
{
    "netObjectId": "I:120"
}
```
#### Example Response
Returns Status 200 OK and updates data.

## How to Unmanage Interface on a Node?
``Umanage`` verb of the ``Orion.NPM.Interfaces`` entity can be used to start managing certain interfaces on a Node.

Parameters:
* netObjectId (System.String)
* Unmanage and Remanage time (System.DateTime)
* isRelative (System.Boolean)

:red_circle: POST Query Request
```
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.NPM.Interfaces/Umanage
```
#### Headers
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_

#### Body raw 
Current example is for unmanaging the Interface with ID 120 from today to unspecified time.
```
{
    "netObjectId": "I:120",
    "unmanageTime": "2024-04-17",
    "remanageTime": "9999-01-01",
    "isRelative" : 0
}
```
#### Example Response
Returns Status 200 OK and updates data.

## How to Remanage Volume on a Node?
``Remanage`` verb of the ``Orion.Volumes`` entity can be used to start managing certain Volumes on a Node.

Parameters:
* netObjectId (System.String)

### :red_circle: POST Query Request
```
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.Volumes/Remanage
```

#### Headers
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_

#### Body raw
```
{
    "netObjectId": "V:120"
}
```
#### Example Response
Returns Status 200 OK and updates data.

## How to Unmanage Volumes on a Node?
``Umanage`` verb of the ``Orion.Volumes`` entity can be used to start managing certain interfaces of the Node.

Parameters:
* netObjectId (System.String)
* Unmanage and Remanage time (System.DateTime)
* isRelative (System.Boolean)

### :red_circle: POST Query Request
```
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.Volumes/Umanage
```

#### Headers
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_

#### Body raw
```
{
    "netObjectId": "V:120"
}
```
#### Example Response
Current example is for unmanaging the Volume with ID 120 from today to unspecified time.
```
{
    "netObjectId": "V:120",
    "unmanageTime": "2024-04-17",
    "remanageTime": "9999-01-01",
    "isRelative" : 0
}
```

## How to Enable HW Sensors on a Node?

``EnableSensors`` verb of the ``Orion.HardwareHealth.HardwareItemBase`` entity can be used to enable certain HW Sensors of the Node.

### :red_circle: POST Query Request
```
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.HardwareHealth.HardwareItemBase/EnableSensors
```

#### Headers
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_

#### Body raw
```
{
    "hardwareItems": [
        {
            "HardwareInfoID": 2,
            "HardwareCategoryStatusId": 4,
            "UniqueName": "PowerSupplySensor.1006"
        }
    ]
}
```
#### Example Response
Returns null with 200 OK status.

## How to Disable HW Sensors on a Node?
``DisableSensors`` verb of the ``Orion.HardwareHealth.HardwareItemBase`` entity can be used to disable certain HW Sensors of the Node.

### :red_circle: POST Query Request
```
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.HardwareHealth.HardwareItemBase/DisableSensors
```

#### Headers
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_

#### Body raw
```
{
    "hardwareItems": [
        {
            "HardwareInfoID": 2,
            "HardwareCategoryStatusId": 4,
            "UniqueName": "PowerSupplySensor.1006"
        }
    ]
}
```
#### Example Response
Returns null with 200 OK status.

## How to Export APM Application Template?

``ExportTemplate`` verb on ``Orion.APM.ApplicationTemplate`` entity can be used to get the APM Application template to create APM Application.

### :red_circle: POST Query Request
```
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.ApplicationTemplate/ExportTemplate
```

#### Headers
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_

#### Body raw
```
{
    "templateId": 1
}
```
#### Example Response
```
<?xml version='1.0' encoding='utf-8'?> <ArrayOfApplicationTemplate xmlns:i...
```

## How to Import APM Application Template?

``ImportTemplate`` verb on ``Orion.APM.ApplicationTemplate`` entity can be used to import APM Application Template.

### :red_circle: POST Query Request
```
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.ApplicationTemplate/ImportTemplate
```

#### Headers
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_

#### Body raw
``templateData`` expects String input of APM Application template. Can be gotten from the existing APM Application template using ``ExportTemplate`` verb on ``Orion.APM.ApplicationTemplate`` entity.
```
{
    "templateData": "<?xml version='1.0' encoding='utf-8'?> <ArrayOfApplicationTemplate xmlns:i..."
}
```
#### Example Response
Returns ``netObjetId`` of new Application Template.

## How to create APM Application on a Node?

``CreateApplication`` verb on ``Orion.APM.Application`` entity can be used to create APM Application on a Node.

### :red_circle: POST Query Request
```
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.Application/CreateApplication 
```

#### Headers
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_

#### Body raw
``skipIfDuplicate`` property should be set to ``1`` if True, and ``0`` if False.

``applicationSettings`` is optional. Set to ``null`` if no additional settings.

```
{
    "nodeId": 1,
    "applicationTemplateId": 2,
    "credentialSetId": 3,
    "skipIfDuplicate": 1,
    "applicationSettings": null
}
```

#### Example Response

Returns ``applicationId`` if Application was created and ``-1`` if not.

## How to delete APM Application on a Node?

``DeleteApplication`` verb on ``Orion.APM.Application`` entity can be used to delete APM Application.

### :red_circle: POST Query Request
```
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.Application/DeleteApplication
```

#### Headers
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_

#### Body raw
```
{
    "applicationId": 1
}
```

#### Example Response
Returns null with Status 200 OK.

## How to Unmanage APM Application on a Node?

``Unmanage`` verb on ``Orion.APM.Application`` entity can be used to unmanage APM Application on a Node.

### :red_circle: POST Query Request
```
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.Application/Unmanage
```

#### Headers
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_

#### Body raw
Current example is for unmanaging APM Application from today to unspecified time.
```
{
    "netObjetId": "AA:1",
    "unmanageTime": "2024-04-17",
    "remanageTime": "9999-01-01",
    "isRelative": 0
}
```

#### Example Response
Returns null with Status 200 OK.

## How to Remanage APM Application on a Node?

``Remanage`` verb on ``Orion.APM.Application`` entity can be used to remanage APM Application on a Node.

### :red_circle: POST Query Request
```
https://{IP}:17774/SolarWinds/InformationService/v3/Json/Invoke/Orion.APM.Application/Remanage
```

#### Headers
**Authorization:** _{{basicAuthorization}}_ \
**Content-Type:** _application/json_

#### Body raw
```
{
    "netObjetId": "AA:1"
}
```

#### Example Response
Returns null with Status 200 OK.