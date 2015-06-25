paraffin -dir ..\Samples\VBClient -dirref SAMPLESDIR -alias ..\Samples\VBClient -groupname vbclient VBClient.wxs -e vspscc -e scc -x bin -x obj
paraffin -dir ..\Samples\JavaClient -dirref SAMPLESDIR  -alias ..\Samples\JavaClient -groupname javaclient JavaClient.wxs -e class -x bin
paraffin -dir ..\Samples\PerlClient -dirref SAMPLESDIR  -alias ..\Samples\PerlClient -groupname perlclient PerlClient.wxs
paraffin -dir ..\Samples\PowerShell -dirref SAMPLESDIR -alias ..\Samples\PowerShell -groupname pssamples PowerShellSamples.wxs
paraffin -dir ..\Samples\CSClient -dirref SAMPLESDIR -alias ..\Samples\CSClient -groupname csclient CSClient.wxs -x bin -x obj
paraffin -dir ..\..\Doc\Schema -dirref DOCDIR  -alias ..\..\Doc\Schema -groupname schemadoc SchemaDoc.wxs
