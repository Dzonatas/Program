#!/bin/sh
# Run test from top directory of repository
# Example: sh ./~/test.sh
ID="5a7160ed-13d5-4923-a1f9-3e32a47d558a"
export TERM="XHTML"

[ ! -d "/tmp/.$ID.d" ] && mkdir /tmp/.$ID.d
cd ./bin/Debug \
  && ../../~/understand.exe <../../~/hello.mono.world.il.text >/tmp/.$ID.d/il.xml \
  && ./ecma.exe --input=/tmp/.$ID.d/il.xml \
  && gcc -std=c99 -O3 -S -I ../../# /tmp/.$ID.d/program.c -o /tmp/.$ID.d/native.assembly.s \
  && gcc -std=c99 -S -I ../../# /tmp/.$ID.d/program.c -o /tmp/.$ID.d/unoptimized.s \
  && gcc -std=c99 -O3 /tmp/.$ID.d/native.assembly.s -o /tmp/.$ID.d/test1.hello.world.exe \
  && time /tmp/.$ID.d/test1.hello.world.exe
