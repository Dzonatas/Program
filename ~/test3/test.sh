#!/bin/sh
# Run test from top directory of repository
# Example: sh ./~/test3/test.sh
ID="5a7160ed-13d5-4923-a1f9-3e32a47d558a"

gmcs ./~/test3/hello.world.cs -out:/tmp/$ID.hello.world.exe
monodis /tmp/$ID.hello.world.exe --output=/tmp/$ID.il.text

cd ./bin/Debug \
  && ./ecma.exe --shell="sh ../../~/compile.sh /tmp/$ID.il.text" \
  && gcc -std=c99 -O3 -S -I ../../# /tmp/$ID.program.c -o /tmp/$ID.native.assembly.s \
  && gcc -std=c99 -S -I ../../# /tmp/$ID.program.c -o /tmp/$ID.unoptimized.s \
  && gcc -std=c99 -O3 /tmp/$ID.native.assembly.s -o /tmp/$ID.hello.world.exe \
  && time /tmp/$ID.hello.world.exe
