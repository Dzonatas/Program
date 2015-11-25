#!/bin/sh
#Used by ../ecma.csproj for $(ecma --shell) test from ../bin/Debug
ID="5a7160ed-13d5-4923-a1f9-3e32a47d558a"
INPUT=$1
exec ./ilxml.exe <$INPUT
