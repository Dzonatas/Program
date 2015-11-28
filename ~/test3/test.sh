#!/bin/sh
# Run test from top directory of repository
# Example: sh ./~/test3/test.sh
ID="5a7160ed-13d5-4923-a1f9-3e32a47d558a"
export TERM="XHTML"

[ ! -d "/tmp/.$ID.d" ] && mkdir /tmp/.$ID.d
gmcs ./~/test3/hello.world.cs -out:/tmp/.$ID.d/dis.test3.hello.world.exe
monodis /tmp/.$ID.d/dis.test3.hello.world.exe --output=/tmp/.$ID.d/test3.il.text

exec ./~/_test.sh /tmp/.$ID.d/test3.il.text test3
