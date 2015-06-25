cd /d %~dp0
del /q/f/s ..\..\Doc\Schema\*

cd ..\..\bin\Debug
.\SchemaDocGen.exe v2.0 ..\..\Doc\Schema\2.0 ..\..\Src\Schemas
.\SchemaDocGen.exe v3.0 ..\..\Doc\Schema\3.0 ..\..\Src\Schemas\3.0 ..\..\Src\Schemas

cd ..\..\Src\Install
p4 edit SchemaDoc.wxs
paraffin -update SchemaDoc.wxs
move SchemaDoc.PARAFFIN SchemaDoc.wxs

cd ..\..\Doc\Schema
p4 diff -sd //depot/Dev/Main/Orion/SDK/Doc/Schema/... | p4 -x- delete
p4 edit 2.0\* 3.0\*
p4 add 2.0\* 3.0\*
p4 revert -a

cd ..\..\Src\Install
