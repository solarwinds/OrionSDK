---
title: Polling Engine Load Balancing
---

Orion polling can be scaled out by adding Additional Polling Engines.
Nodes are statically assigned to polling engines and all related monitoring jobs such as Interfaces, Applications, and Configs are run from the node's assigned polling engine.
The Orion admin is responsible for balancing the load between polling engines by reassigning nodes.

:::caution

Network security can be complex with many separate points of control.
When reassigning a node from one polling engine to another, be sure that the new polling engine is able to access the node for monitoring purposes.
If the new polling engine can't reach the node due to different IP address spaces, firewall rules, or SNMP access rules on the target node, then you will lose monitoring visibility.

:::

## Assessing polling engine load

There are two main considerations for polling engine load: configured load vs. performance; and configured load vs. licensed capacity.

### Detecting performance issues

Orion polling engines compute a number called "polling completion" that indicates whether they are completing their configured monitoring jobs on schedule.

A polling completion value of 100 indicates that all jobs are completed on schedule.
Polling completion should stay in the high 90s.
Anything less indicates a performance problem.
Orion admins will be notified of problems with polling completion by a message in the web console header.

The current polling completion numbers can be seen in the web console under Settings > All Settings > Polling Engines (`/Orion/Admin/Details/Engines.aspx`).
These numbers are also available through the API by querying `Orion.Engines` like this:

```sql
SELECT EngineID, ServerName, PollingCompletion
FROM Orion.Engines
```

As with any performance problem, there are many possible causes: too much load, insufficient hardware, software misconfiguration, software bugs, etc.
If the problem is too much load, then rebalancing some of the load to another polling engine can be a good solution.
If the problem is something else, then clearly another solution is needed.
The polling completion number can only tell you that there is a problem - it can't tell you the cause of the problem.

### Detecting licensed capacity issues

Orion Polling Engine licenses cover a certain polling rate expressed in abstract "job weight" that is proportional to the number of elements under monitoring and the polling frequency.
Twice as many elements have twice the job weight.
Polling twice as often (equivalent to cutting the polling intervals in half) has twice the job weight.

If you configure a polling engine with more job weight than its license allows, it will adjust polling intervals on the fly to bring the job weight down to the license limit.
So if the license allows "1000 job weight" and the configured elements and polling intervals work out to "1500 job weight", then polling intervals will be multiplied by 1500/1000 = 1.5 across the board.
So a node that is configured to be polled every 2 minutes would actually be polled every 2 * 1.5 = 3 minutes

SolarWinds has a [knowledge base article](http://www.solarwinds.com/documentation/kbloader.aspx?lang=en&kb=3227) on this topic.

Any polling rate greater than 100% indicates too much configured job weight.
To reduce configured job weight, you can remove some unnecessary monitoring (for example, if you don't care about monitoring loopback interfaces, just remove them); increase polling intervals for lower priority elements; or move some nodes from an overloaded polling engine to one with spare capacity.

The current polling rate numbers can be seen in the web console under Settings > All Settings > Polling Engines (`/Orion/Admin/Details/Engines.aspx`).
These numbers are also available through the API by querying `Orion.PollingUsage`, like this:

```sql
SELECT EngineID, ScaleFactor, CurrentUsage, IsExceeded
FROM Orion.PollingUsage
```

To simplify this and get just one row per polling engine, use a query like this:

```sql
SELECT EngineID, MAX(CurrentUsage) AS CurrentUsage, MAX(IsExceeded) AS IsExceeded
FROM Orion.PollingUsage
GROUP BY EngineID
```

## Rebalancing polling engines

At a high level, you rebalance polling engines by finding an engine with too much load and an engine with less load and reassigning some nodes from the first to the second, taking into account network access and security considerations.

Once you have selected which nodes to move and which engines to move them to, the actual reassignment is done by setting the `EngineID` property of the `Orion.Nodes` instance.
You need the node's SWIS Uri to do this.
In PowerShell, that looks like this:

```powershell
$swis = Connect-Swis   # connection options go here
$nodeIdToMove = 1234   # choose node somehow
$targetEngineId = 4    # choose an appropriate engine with spare capacity
$nodeUriToMove = Get-SwisData $swis "SELECT Uri FROM Orion.Nodes WHERE NodeID=@nodeId" @{nodeId = $nodeIdToMove}
Set-SwisObject $swis $nodeUriToMove @{EngineID = $targetEngineId}
```
