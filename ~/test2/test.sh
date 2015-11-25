#!/bin/sh
# Run test from top directory of repository
# Example: sh ./~/test2/test.sh
ID="5a7160ed-13d5-4923-a1f9-3e32a47d558a"
export TERM="XHTML"

[ ! -d "/tmp/.$ID.d" ] && mkdir /tmp/.$ID.d
gmcs ./~/test2/hello.world.cs -out:/tmp/.$ID.d/dis.test2.hello.world.exe
monodis /tmp/.$ID.d/dis.test2.hello.world.exe --output=/tmp/.$ID.d/test2.il.text

cd ./bin/Debug \
  && ./ilxml.exe </tmp/.$ID.d/test2.il.text >/tmp/.$ID.d/test2.il.xml \
  && ./ecma.exe --input=/tmp/.$ID.d/test2.il.xml \
  && gcc -std=c99 -O3 -S -I ../../# /tmp/.$ID.d/program.c -o /tmp/.$ID.d/native.assembly.s \
  && gcc -std=c99 -S -I ../../# /tmp/.$ID.d/program.c -o /tmp/.$ID.d/unoptimized.s \
  && gcc -std=c99 -O3 /tmp/.$ID.d/native.assembly.s -o /tmp/.$ID.d/test2.hello.world.exe \
  && time /tmp/.$ID.d/test2.hello.world.exe
