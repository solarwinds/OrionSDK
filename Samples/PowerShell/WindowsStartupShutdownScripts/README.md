# Windows Startup and Shutdown scripts

Scripts in this folder can be used to add machine to the Orion while it is starting and removing it on the machine shutdown.

Additionally scripts are able to deploy agent on startup and uninstall/remove on shutdown.
* Startup script contains flag `deploy_agent`. If this flag is set to `True` agent will be deployed. 
* Shutdown script contains flag `should_uninstall_agent_from_node`. If this flag is set to `True` agent will be uninstalled from monitored node. Otherwise only information about agent will be removed from Orion. 

## Script setup

Script should be placed in startup / shutdown scripts in Local Group Policy Editor, like described in this article:
[https://docs.microsoft.com/en-us/previous-versions/windows/it-pro/windows-server-2012-r2-and-2012/dn789190(v=ws.11)#:~:text=computer%20shutdown%20scripts-,To%20assign%20computer%20shutdown%20scripts,Scripts%20(Startup%2FShutdown).&text=In%20Script%20Parameters%2C%20type%20any,them%20on%20the%20command%20line]
