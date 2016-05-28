#!/bin/sh
# Run test from top directory of repository
# Example: sh ./~/test7/test.sh
ID="5a7160ed-13d5-4923-a1f9-3e32a47d558a"
export TERM="XHTML"

[ ! -d "/tmp/.$ID.d" ] && mkdir /tmp/.$ID.d
gmcs ./~/test7/hello.world.7.cs -out:/tmp/.$ID.d/dis.test7.hello.world.exe
monodis /tmp/.$ID.d/dis.test7.hello.world.exe --output=/tmp/.$ID.d/test7.il.text

exec ./~/_test.sh /tmp/.$ID.d/test7.il.text test7
