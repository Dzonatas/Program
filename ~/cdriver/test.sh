#!/bin/sh
# Run test from top directory of repository
# Example: sh ./~/cdriver/test.sh
ID="5a7160ed-13d5-4923-a1f9-3e32a47d558a"
export TERM="XHTML"

#[ ! -d "/tmp/.$ID.d" ] && mkdir /tmp/.$ID.d
monodis /tmp/.$ID.d/infrastructure.exe --output=/tmp/.$ID.d/infrastructure.dis.il.text

exec ./~/_test.sh /tmp/.$ID.d/infrastructure.dis.il.text cdriver
