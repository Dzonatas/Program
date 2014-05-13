#!/bin/sh
# Run test from top directory of repository
# Example: sh ./~/test3/test.sh
ID="5a7160ed-13d5-4923-a1f9-3e32a47d558a"

mkdir /tmp/.$ID.d
gmcs ./~/test3/hello.world.cs -out:/tmp/.$ID.d/hello.world.exe
monodis /tmp/.$ID.d/hello.world.exe --output=/tmp/.$ID.d/il.text

cd ./bin/Debug \
  && ./ecma.exe --shell="sh ../../~/compile.sh /tmp/.$ID.d/il.text" \
  && gcc -std=c99 -O3 -S -I ../../# /tmp/.$ID.d/program.c -o /tmp/.$ID.d/native.assembly.s \
  && gcc -std=c99 -S -I ../../# /tmp/.$ID.d/program.c -o /tmp/.$ID.d/unoptimized.s \
  && gcc -std=c99 -O3 /tmp/.$ID.d/native.assembly.s -o /tmp/$ID.hello.world.exe \
  && time /tmp/$ID.hello.world.exe
