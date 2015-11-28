#!/bin/sh
# Routine used by tests
# Example: sh ./~/_test.sh input.il test1

export TERM="XHTML"
ID="5a7160ed-13d5-4923-a1f9-3e32a47d558a"
INPUT=$1
PREFIX=/tmp/.$ID.d/$2
MODULE=$2

[ ! -d "/tmp/.$ID.d" ] && mkdir /tmp/.$ID.d
cd ./bin/Debug \
  && ./ilxml.exe <$INPUT >$PREFIX.il.xml \
  && ./ecma.exe --input=$PREFIX.il.xml --output=$MODULE \
  && gcc -std=c99 -O3 -S -I ../../# $PREFIX.c -o $PREFIX.native.assembly.s \
  && gcc -std=c99 -S -I ../../# $PREFIX.c -o $PREFIX.unoptimized.s \
  && gcc -std=c99 -O3 $PREFIX.native.assembly.s -o $PREFIX.hello.world.exe \
  && time $PREFIX.hello.world.exe
