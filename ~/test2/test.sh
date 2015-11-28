#!/bin/sh
# Run test from top directory of repository
# Example: sh ./~/test2/test.sh
ID="5a7160ed-13d5-4923-a1f9-3e32a47d558a"

[ ! -d "/tmp/.$ID.d" ] && mkdir /tmp/.$ID.d
gmcs ./~/test2/hello.world.cs -out:/tmp/.$ID.d/dis.test2.hello.world.exe
monodis /tmp/.$ID.d/dis.test2.hello.world.exe --output=/tmp/.$ID.d/test2.il.text

exec ./~/_test.sh /tmp/.$ID.d/test2.il.text test2
