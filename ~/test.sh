#!/bin/sh
# Run test from top directory of repository
# Example: sh ./~/test.sh
ID="5a7160ed-13d5-4923-a1f9-3e32a47d558a"
export TERM="XHTML"
PREFIX=/tmp/.$ID.d/test1

[ ! -d "/tmp/.$ID.d" ] && mkdir /tmp/.$ID.d
cd ./bin/Debug \
  && ./ilxml.exe <../../~/hello.mono.world.il.text >$PREFIX.il.xml \
  && ./ecma.exe --input=$PREFIX.il.xml --output=test1 \
  && gcc -std=c99 -O3 -S -I ../../# $PREFIX.c -o $PREFIX.native.assembly.s \
  && gcc -std=c99 -S -I ../../# $PREFIX.c -o $PREFIX.unoptimized.s \
  && gcc -std=c99 -O3 $PREFIX.native.assembly.s -o $PREFIX.hello.world.exe \
  && time $PREFIX.hello.world.exe
