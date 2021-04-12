---
title: SWIS REST/JSON Endpoint
---

The easiest way to explain the formats of the requests and responses for various operations with the REST endpoint is by illustration.

## REST Request and Response Formats

### Query Request

```text
GET https://localhost:17778/SolarWinds/InformationService/v3/Json/Query?query=SELECT+Uri+FROM+Orion.Pollers+ORDER+BY+PollerID+WITH+ROWS+1+TO+3+WITH+TOTALROWS HTTP/1.1
Authorization: Basic YWRtaW46
User-Agent: curl/7.20.0 (i386-pc-win32) libcurl/7.20.0 OpenSSL/0.9.8l zlib/1.2.3
Host: localhost:17778
Accept: */*
```

### Query Response

```json
HTTP/1.1 200 OK
Content-Length: 244
Content-Type: application/json
Server: Microsoft-HTTPAPI/2.0
Date: Fri, 27 Jul 2012 19:38:52 GMT

{"totalRows":13,"results":[{"Uri":"swis://tdanner-dev.swdev.local/Orion/Orion.Pollers/PollerID=4"},{"Uri":"swis://tdanner-dev.swdev.local/Orion/Orion.Pollers/PollerID=6"},{"Uri":"swis://tdanner-dev.swdev.local/Orion/Orion.Pollers/PollerID=7"}]}
```

Body reformatted for easier reading

```json
{
    "totalRows": 13,
    "results": [
        { "Uri": "swis://tdanner-dev.swdev.local/Orion/Orion.Pollers/PollerID=4" },
        { "Uri": "swis://tdanner-dev.swdev.local/Orion/Orion.Pollers/PollerID=6" },
        { "Uri": "swis://tdanner-dev.swdev.local/Orion/Orion.Pollers/PollerID=7" }
    ]
}
```

### Query with Parameters Request

```text
POST https://localhost:17778/SolarWinds/InformationService/v3/Json/Query HTTP/1.1
Authorization: Basic YWRtaW46
User-Agent: curl/7.20.0 (i386-pc-win32) libcurl/7.20.0 OpenSSL/0.9.8l zlib/1.2.3
Host: localhost:17778
Accept: */*
Content-Type: application/json
Content-Length: 130

{"query":"SELECT Uri FROM Orion.Pollers WHERE PollerID=@p ORDER BY PollerID WITH ROWS 1 TO 3 WITH TOTALROWS","parameters":{"p":9}}
```

Request body reformatted for easier reading:

```json
{
  "query": "SELECT Uri FROM Orion.Pollers WHERE PollerID=@p ORDER BY PollerID WITH ROWS 1 TO 3 WITH TOTALROWS",
  "parameters": {
    "p": 9
  }
}
```

### Query with Parameters Response

```text
HTTP/1.1 200 OK
Content-Length: 99
Content-Type: application/json
Server: Microsoft-HTTPAPI/2.0
Date: Tue, 07 Aug 2012 17:36:27 GMT

{"totalRows":1,"results":[{"Uri":"swis://tdanner-dev.swdev.local/Orion/Orion.Pollers/PollerID=9"}]}
```

#### Example query request with a multi-valued parameter

To send a multi-valued parameter for use with a `WHERE x IN (...)`-style query, encode the value as a JSON array, like this:

```json
{
  "query": "SELECT NodeID, Caption FROM Orion.Nodes WHERE NodeID IN @ids",
  "parameters": {
    "ids": [2,4,6]
  }
}
```

### Invoke Request

```json
POST https://localhost:17778/SolarWinds/InformationService/v3/Json/Invoke/Metadata.Entity/GetAliases HTTP/1.1
Authorization: Basic YWRtaW46
User-Agent: curl/7.20.0 (i386-pc-win32) libcurl/7.20.0 OpenSSL/0.9.8l zlib/1.2.3
Host: localhost:17778
Accept: */*
Content-Type: application/json
Content-Length: 39

["SELECT B.Caption FROM Orion.Nodes B"]
```

### Invoke Response

```json
HTTP/1.1 200 OK
Content-Length: 19
Content-Type: application/json
Server: Microsoft-HTTPAPI/2.0
Date: Fri, 27 Jul 2012 19:23:27 GMT

{"B":"Orion.Nodes"}
```

The Metadata.GetAliases verb takes one string argument and returns a PropertyBag.

### Create Request

```json
POST https://localhost:17778/SolarWinds/InformationService/v3/Json/Create/Orion.Pollers HTTP/1.1
Authorization: Basic YWRtaW46
User-Agent: curl/7.20.0 (i386-pc-win32) libcurl/7.20.0 OpenSSL/0.9.8l zlib/1.2.3
Host: localhost:17778
Accept: */*
Content-Type: application/json
Content-Length: 92

{"PollerType":"hi from curl 2", "NetObject":"N:123", "NetObjectType":"N", "NetObjectID":123}
```

### Create Response

```json
HTTP/1.1 200 OK
Content-Length: 69
Content-Type: application/json; charset=utf-8
Server: Microsoft-HTTPAPI/2.0
Date: Fri, 27 Jul 2012 19:27:11 GMT

"swis:\/\/tdanner-dev.swdev.local\/Orion\/Orion.Pollers\/PollerID=19"
```

### Read Request

```text
GET https://localhost:17778/SolarWinds/InformationService/v3/Json/swis://tdanner-dev.swdev.local/Orion/Orion.Pollers/PollerID=6 HTTP/1.1
Authorization: Basic YWRtaW46
User-Agent: curl/7.20.0 (i386-pc-win32) libcurl/7.20.0 OpenSSL/0.9.8l zlib/1.2.3
Host: localhost:17778
Accept: */*
```

### Read Response

```json
HTTP/1.1 200 OK
Content-Length: 245
Content-Type: application/json
Server: Microsoft-HTTPAPI/2.0
Date: Fri, 27 Jul 2012 19:30:02 GMT

{"PollerID":6,"PollerType":"V.Details.SNMP.Generic","NetObject":"V:1","NetObjectType":"V","NetObjectID":1,"DisplayName":null,"Description":null,"InstanceType":"Orion.Pollers","Uri":"swis://tdanner-dev.swdev.local/Orion/Orion.Pollers/PollerID=6"}
```

### Update Request

```json
POST https://localhost:17778/SolarWinds/InformationService/v3/Json/swis://tdanner-dev.swdev.local/Orion/Orion.Pollers/PollerID=6 HTTP/1.1
Authorization: Basic YWRtaW46
User-Agent: curl/7.20.0 (i386-pc-win32) libcurl/7.20.0 OpenSSL/0.9.8l zlib/1.2.3
Host: localhost:17778
Accept: */*
Content-Type: application/json
Content-Length: 29

{"PollerType":"hi from curl"}
```

### Update Response

```text
HTTP/1.1 200 OK
Content-Length: 0
Server: Microsoft-HTTPAPI/2.0
Date: Fri, 27 Jul 2012 19:32:06 GMT
```

### BulkUpdate Request

```json
POST https://localhost:17778/SolarWinds/InformationService/v3/Json/BulkUpdate HTTP/1.1
Authorization: Basic YWRtaW46
User-Agent: curl/7.20.0 (i386-pc-win32) libcurl/7.20.0 OpenSSL/0.9.8l zlib/1.2.3
Host: localhost:17778
Accept: */*
Content-Type: application/json
Content-Length: 314

{
"uris":[
"swis://dev-che-mjag-01./Orion/Orion.Nodes/NodeID=4/Volumes/VolumeID=1",
"swis://dev-che-mjag-01./Orion/Orion.Nodes/NodeID=4/Volumes/VolumeID=2",
"swis://dev-che-mjag-01./Orion/Orion.Nodes/NodeID=4/Volumes/VolumeID=3"
],
"properties":
{
"NextPoll":"7/1/2014 9:06:19 AM",
"NextRediscovery":"7/1/2014 2:59:09 PM"
}
}
```

### BulkUpdate Response

```text
HTTP/1.1 200 OK
Content-Length: 0
Server: Microsoft-HTTPAPI/2.0
Date: Fri, 03 Jul 2014 19:32:06 GMT
```

### BulkUpdate Request (Custom Properties)

```json
POST https://localhost:17778/SolarWinds/InformationService/v3/Json/BulkUpdate HTTP/1.1
Authorization: Basic YWRtaW46
User-Agent: curl/7.20.0 (i386-pc-win32) libcurl/7.20.0 OpenSSL/0.9.8l zlib/1.2.3
Host: localhost:17778
Accept: */*
Content-Type: application/json
Content-Length: 148

{
  "uris":[
    "swis://mrxinu.local/Orion/Orion.Nodes/NodeID=81/CustomProperties",
    "swis://mrxinu.local/Orion/Orion.Nodes/NodeID=82/CustomProperties",
    "swis://mrxinu.local/Orion/Orion.Nodes/NodeID=83/CustomProperties",
    "swis://mrxinu.local/Orion/Orion.Nodes/NodeID=84/CustomProperties"
  ],
  "properties":{
    "City": "Serenity Valley"
  }
}
```

### BulkUpdate Response (Custom Properties)

```text
HTTP/1.1 200 OK
Content-Length: 0
Server: Microsoft-HTTPAPI/2.0
Date: Fri, 03 Jul 2014 19:32:06 GMT
```

### Delete Request

```text
DELETE https://localhost:17778/SolarWinds/InformationService/v3/Json/swis://tdanner-dev.swdev.local/Orion/Orion.Pollers/PollerID=16 HTTP/1.1
Authorization: Basic YWRtaW46
User-Agent: curl/7.20.0 (i386-pc-win32) libcurl/7.20.0 OpenSSL/0.9.8l zlib/1.2.3
Host: localhost:17778
Accept: */*
```

### Delete Response

```text
HTTP/1.1 200 OK
Content-Length: 0
Server: Microsoft-HTTPAPI/2.0
Date: Fri, 27 Jul 2012 19:37:33 GMT
```

### BulkDelete Request

```json
POST https://localhost:17778/SolarWinds/InformationService/v3/Json/BulkDelete HTTP/1.1
Authorization: Basic YWRtaW46
User-Agent: curl/7.20.0 (i386-pc-win32) libcurl/7.20.0 OpenSSL/0.9.8l zlib/1.2.3
Host: localhost:17778
Accept: */*
Content-Type: application/json
Content-Length: 232

{
"uris":[
"swis://dev-che-mjag-01./Orion/Orion.Nodes/NodeID=4/Volumes/VolumeID=548",
"swis://dev-che-mjag-01./Orion/Orion.Nodes/NodeID=4/Volumes/VolumeID=545",
"swis://dev-che-mjag-01./Orion/Orion.Nodes/NodeID=4/Volumes/VolumeID=546"]
}
```

### BulkDelete Response

```text
HTTP/1.1 200 OK
Content-Length: 0
Server: Microsoft-HTTPAPI/2.0
Date: Fri, 03 Jul 2014 19:32:06 GMT
```

:::note

When calling SWIS verbs with REST API, you need to provide the arguments as a JSON array. Verb arguments are positional, not named.

:::
