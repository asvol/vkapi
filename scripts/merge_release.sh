#!/bin/bash

#################################################################################
# Script for merge project to one exe file
#
# Author: Alexey Voloshkevich https://github.com/asvol
#
#################################################################################

MERGE_TOOL="../tools/ILRepack.exe"
PLATFORM=v4,"C:\Windows\Microsoft.NET\Framework64\v4.0.30319"


if [ "$#" -ne 2 ]; then
    echo "Usage: $SCRIPTNAME <SRC> <OUT>"
    exit 3
fi

SRC=$1
OUT=$2

if [ ! -f $SRC ]; then
    echo "Error: File '$SRC' not found!"
    exit 2
fi

SRC_FOLDER=$(dirname "${SRC}")


$MERGE_TOOL /log /wildcards /ndebug /copyattrs /targetplatform:$PLATFORM /out:$OUT $SRC $SRC_FOLDER/*.dll