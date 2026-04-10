---
layout: default
title: Documentation
---

The [SolarWinds Orion Platform](https://www.solarwinds.com/orion) is a unified suite of network and system management products. Orion is installed on one or more servers in your organization's intranet. IT professionals in your organization interact with Orion primarily through the Orion website, which provides a single pane of glass for monitoring your IT infrastructure.

The [SolarWinds Information Service (SWIS)](about-swis/) is a data access layer for Orion. It has its own SQL-like language called SolarWinds Query Language (SWQL). SWIS provides a kind of application programming interface (API) for the Orion platform.

The **Orion SDK** is open source software that makes it easier for system administrators and developers to use SWIS. It can help you to automate processes, integrate with other products, or access information from Orion. The Orion SDK includes **SWQL Studio**, which is a graphical query tool for running SWQL queries. It also includes the [SwisPowerShell PowerShell module](powershell/).

## Topics

* [About SWIS](about-swis/)
* [SWQL Functions](swql-functions/)
* [REST](rest/) - Request and response formats
* [PowerShell](powershell/) - How to access SWIS from Windows PowerShell
  * [PowerOrion - A Module for PowerShell](powershell/powerorion-a-module-for-powershell/)
* [Alerts](alerts/) - How to get information about active alerts and alert configurations, acknowledge, add notes, import/export configuration
* [Groups](groups/)
* [Creating custom properties](creating-custom-properties/)
* [Poller Types](poller-types/)
* Network Performance Monitor
  * [NPM Universal Device Pollers](network-performance-monitor/npm-universal-device-pollers/)
  * [How to assign specific poller to a node](network-performance-monitor/how-to-assign-specific-poller-to-a-node/)
  * [How to distribute load between pollers](network-performance-monitor/how-to-distribute-load-between-pollers/)
  * [How to set polling parameters on a Node](network-performance-monitor/how-to-set-polling-parameters-on-a-node/)
  * [How to specify interfaces, volumes, hw sensors, applications, components to be monitored on a Node](network-performance-monitor/how-to-specify-interfaces-volumes-hw-sensors-applications-components-to-be-monitored-on-a-node/)
  * [How to specify (SNMP) OIDs to be monitored on a Node](network-performance-monitor/how-to-specify-snmp-oids-to-be-monitored-on-a-node/)
* Netflow Traffic Analyzer
  * [NTA 4.0 Entity Model](netflow-traffic-analyzer/nta-4-0-entity-model/)
* Network Configuration Manager
  * [NCM Config Transfer](network-configuration-manager/ncm-config-transfer/)
  * [NCM Config Search](network-configuration-manager/ncm-config-search/)
* IP Address Manager
  * [IPAM API](ip-address-manager/ipam-api/)
* Server and Application Monitor
   * [SAM Application Monitoring Templates](server-and-application-monitor/sam-application-monitoring-templates/)
* Log Analyzer 
  * [Exporting log events](log-analyzer/exporting-log-events/)

[Schema reference](http://solarwinds.github.io/OrionSDK/)

[More information about the SWIS query language and important entity types](https://thwack.solarwinds.com/docs/DOC-186990)