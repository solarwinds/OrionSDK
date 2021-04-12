---
title: NCM Config Search
---

The Network Configuration Manager search interface can be called through the API using the `ConfigSearch` verb on `Cirrus.ConfigArchive`.

## Cirrus.ConfigArchive

### Verb: ConfigSearch

Search for configs matching a query.

```csharp
string[] ConfigSearch(string searchString, string configType, 
    string coreNodeIdList, bool matchWholeWord, bool searchOnlyMostRecent = false,
    DateTime? startTime = null, DateTime? endTime = null)
```

The parameters for `ConfigSearch` are:

* `searchString` - the text to search for
* `configType` - the name of a config type (such as "Running" or "Startup") or `null` to just search all config types
* `coreNodeIdList` - a list of `NodeID` values (ints from `Orion.Nodes`, not Guids from `Cirrus.Nodes`) as a comma-separated string, or `null` to just search configs from all nodes
* `matchWholeWord` - `true` if the words in `searchString` must occur as written in the config or `false` if they can appear as a substring or a larger word in the config
* `searchOnlyMostRecent` - `true` to only consider the current config of each type or `false` to search history as well. This parameter can be omitted; if so, history will be searched.
* `startTime` - to search configs from a particular date range, provide the start time here; provide `null` or just omit the parameter to search all history
* `endTime` - to search configs from a particular date range, provide the end time here; provide `null` or just omit the parmater to search all history newer than `startTime`

The return value of `ConfigSearch` is a list of id values for configs that match the query.
To get the details of each matching config, including what node it came from, when it was obtained, and the full text of the config, use these ids to query `Cirrus.ConfigArchive`.
