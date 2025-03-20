#!/bin/bash

WORKSPACE=../..
LUBAN_DLL=$WORKSPACE/LubanConfig/MiniTemplate/Luban/Luban.dll
CONF_ROOT=.

dotnet $LUBAN_DLL \
    -t all \
    -d json \
    -c cs-simple-json\
    --conf $CONF_ROOT/luban.conf \
    -x outputDataDir=$WORKSPACE/Assets/Config/Data\
    -x outputCodeDir=$WORKSPACE/Assets/Config/Code
    