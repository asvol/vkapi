#!/bin/bash

#################################################################################
# Script for build release and publish project
#
# Author: Alexey Voloshkevich https://github.com/asvol
#
#################################################################################

MSBBUILD="C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild"

./update_version.sh ../src/VkApi/Properties/AssemblyInfo.cs
./update_version.sh ../src/VkShell/Properties/AssemblyInfo.cs

cmd /C "$MSBBUILD" '..\src\VkApi.sln' /t:Build /p:Configuration=Release
./merge_release.sh ../bin/release/VkShell.exe ../bin/publish/vkshell.exe
