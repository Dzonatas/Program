#!/bin/sh
# Run test from top directory of repository
# Example: sh ./~/testehtest.sh
ID="5a7160ed-13d5-4923-a1f9-3e32a47d558a"
export TERM="XHTML"

[ ! -d "/tmp/.$ID.d" ] && mkdir /tmp/.$ID.d
gmcs ./~/testseh/hello.world.seh.cs -out:/tmp/.$ID.d/dis.testseh.hello.world.exe
monodis /tmp/.$ID.d/dis.testseh.hello.world.exe --output=/tmp/.$ID.d/testseh.il.text

exec ./~/_test.sh /tmp/.$ID.d/testseh.il.text testseh
