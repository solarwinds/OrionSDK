SWQL is built on the framework of SQL and as such supports most of the standard clauses as part of a query. A very simple example query is:

```
SELECT Caption, IPAddress, Vendor, ResponseTime
FROM Orion.Nodes
```

Dissecting this query is relatively straightforward: show some fields (Caption, IP address, Vendor, and Response Time) from an entity (Orion.Nodes). Because we’ve defined no filters, this will return all the records from the entity but just display those four fields.

If you wish to filter your results, you use a WHERE clause and provide a comparison.

```
SELECT Caption, IPAddress, Vendor, ResponseTime
FROM Orion.Nodes
WHERE Vendor = 'Linux'
```

If you wish to define a sort, it can be done with the ORDER BY clause and providing a field on which to sort.

```
SELECT Caption, IPAddress, Vendor, ResponseTime
FROM Orion.Nodes
WHERE Vendor = 'Linux'
ORDER BY ResponseTime
```

Multiple ORDER BY fields are processed in order, so the below will sort by the Response Time and then by the Caption.

```
SELECT Caption, IPAddress, Vendor, ResponseTime
FROM Orion.Nodes
WHERE Vendor = 'Linux'
ORDER BY ResponseTime, Caption
```

Sorting by default is in ascending order. If you wish to instead sort descending, append DESC after the field name in question.

```
SELECT Caption, IPAddress, Vendor, ResponseTime
FROM Orion.Nodes
WHERE Vendor = 'Linux'
ORDER BY ResponseTime DESC, Caption
```

## Aliases

Both fields and the entities can be aliased with labels. The keyword AS is used to alias a field to another name.  Strictly speaking the AS keyword is not mandatory, but it is good practice and makes your queries easier to read.  For such a reason, this book will use it when defining aliases.

```
SELECT Caption AS [Node Name]
     , IPAddress AS [IP]
     , Vendor AS [VendorName]
     , ResponseTime AS [Response Time]
FROM Orion.Nodes
WHERE Vendor = 'Linux'
ORDER BY ResponseTime DESC, Caption
```

Entities can also be aliased. For single entity queries (those which remain in a single entity) it isn’t necessary, but it’s a good habit as you extend to include other entities in your results. The below query is functionally identical to the one above.

```SELECT [Nodes].Caption AS [Node Name]
     , [Nodes].IPAddress AS [IP]
     , [Nodes].Vendor AS [VendorName]
     , [Nodes].ResponseTime AS [Response Time]
FROM Orion.Nodes AS [Nodes]
WHERE [Nodes].Vendor = 'Linux'
ORDER BY [Nodes].ResponseTime DESC, [Nodes].Caption
```

The hard brackets are optional unless the alias contains a space or other non-standard character.