#!/bin/bash

#################################################################################
# Script for update build version at AssemblyInfo.cs
#
# Author: Alexey Voloshkevich https://github.com/asvol
#
#################################################################################

# Input argument: path to AssemblyInfo.cs


if [ "$#" -ne 1 ]; then
    echo "Usage: $SCRIPTNAME <FILE_PATH>"
    exit 3
fi

FILE_PATH=$1   

if [ ! -f $FILE_PATH ]; then
    echo "Error: File '$FILE_PATH' not found!"
    exit 2
fi

if ! git describe; then
    echo "Tool tip: init git or add git tags"
    exit 1
fi



SHORT_VERSION=`git describe`

SHORT_VERSION=`expr match "$SHORT_VERSION" '.\([0-9]*[.][0-9]*[.][0-9]*\)'`
LONG_VERSION=`git describe --long`

echo "Begin update file '$FILE_PATH' by new short\long version '$SHORT_VERSION'\'$LONG_VERSION'"

sed -i "s/[0-9]*[.][0-9]*[.][0-9]*[.][*]/$SHORT_VERSION.*/g" $FILE_PATH
sed -i "s/[v][0-9]*[.][0-9]*[.][0-9]*[-][0-9]*[-][a-z0-9]*/$LONG_VERSION/g" $FILE_PATH

exit 0