---
layout: default
title: "Possible Issues"
---

# Possible issues

## Date/time Functions

When using `GETUTCDATE()` function, please note that you will see an incorrect time offset if your SQL Server is in a different timezone than you.

We recommend that you leverage the `GETDATE()` function first to perform any time modifications and then use the `TOUTC()` function at the end if you are in another timezone.

### Details

In SWIS the SWQL query is converted into the SQL query:

```
SET DATEFIRST 7;
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
SELECT [T1].[EngineID] AS C1, [T1].[ServerName] AS C2, [T1].[IP] AS C3, [T1].[ServerType] AS C4, GETUTCDATE() AS C5, DateAdd(minute,-10,GETUTCDATE()) AS C6, DateAdd(second,-10,GETUTCDATE()) AS C7, DateAdd(millisecond,-10000,GETUTCDATE()) AS C8, DateAdd(hour,-10,GETUTCDATE()) AS C9
FROM dbo.Engines AS T1
WHERE [T1].[ServerType] = 'Primary'
```

and then executed on the MSSQL server, SWIS retrieves this data and sends it to the SWQL studio (client). 

All functions `ADDMINUTE`, `ADDSECONDS` etc. are converted to SQL function `DateAdd()` - [DATEADD (Transact-SQL) - SQL Server](https://learn.microsoft.com/en-us/sql/t-sql/functions/dateadd-transact-sql?view=sql-server-ver16). By definition, this function doesn’t work with time zone offset at all, so it doesn’t know that we want the time zone to be UTC by `GetUtcDate()` and it counts as it is in the local time zone. MSSQL server returns data with offset in which time zone it is when `DateAdd()` is used. SWIS then serializes it and sends data to the client in format with the time zone of the MSSQL server:

```
<queryResult
	xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
	xmlns="http://schemas.solarwinds.com/2007/08/informationservice">
	<template>
		<resultset>
			<column name="EngineID" type="Int32" ordinal="0" />
			<column name="ServerName" type="String" ordinal="1" />
			<column name="IP" type="String" ordinal="2" />
			<column name="ServerType" type="String" ordinal="3" />
			<column name="Time_Now" type="DateTime" ordinal="4" />
			<column name="Time_Past_Minute" type="DateTime" ordinal="5" />
			<column name="Time_Past_Second" type="DateTime" ordinal="6" />
			<column name="Time_Past_Milliseond" type="DateTime" ordinal="7" />
			<column name="Time_Past_Hour" type="DateTime" ordinal="8" />
		</resultset>
	</template>
	<data>
		<row>
			<c0>1</c0>
			<c1>hostname</c1>
			<c2>192.168.1.2</c2>
			<c3>Primary</c3>
			<c4>2024-05-17T10:37:27.8070000Z</c4>
			<c5>2024-05-17T10:27:27.8070000-05:00</c5>
			<c6>2024-05-17T10:37:17.8070000-05:00</c6>
			<c7>2024-05-17T10:37:17.8070000-05:00</c7>
			<c8>2024-05-17T00:37:27.8070000-05:00</c8>
		</row>
	</data>
</queryResult>
```

So column `C4` is in UTC (`<c4>2024-05-17T10:37:27.8070000Z</c4>`) and the other columns are with the offset of MSSQL server time zone (`<c5>2024-05-17T10:27:27.8070000-05:00</c5>`). 

SWQL studio will convert the values with the offset to the time zone of the machine where it is running and values in UTC stay the same. 

If you want to have all data values in UTC time, you need to adjust the query like this:

```
SELECT 
  EngineID
, ServerName
, IP, ServerType
, GETUTCDATE() AS [Time_Now]
, TOUTC(ADDMINUTE(-10, TOLOCAL(GETUTCDATE()))) AS [Time_Past_Minute]
, TOUTC(ADDSECOND(-10, TOLOCAL(GETUTCDATE()))) AS [Time_Past_Second]
, TOUTC(ADDMILLISECOND(-10000, TOLOCAL(GETUTCDATE()))) AS [Time_Past_Milliseond]
, TOUTC(ADDHOUR(-10, TOLOCAL(GETUTCDATE()))) AS [Time_Past_Hour]
FROM Orion.Engines
WHERE ServerType = 'Primary'
WITH LOGS
```

If you are using `AddMinute` etc. functions you need to first convert the value to the local time of the MSSQL server and then convert the result back to UTC time.