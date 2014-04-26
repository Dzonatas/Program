#!/bin/sh
ID="5a7160ed-13d5-4923-a1f9-3e32a47d558a"

gcc -std=c99 -O3 -S /tmp/$ID.program.c -o /tmp/$ID.native.assembly.s \
  && gcc -std=c99 -S /tmp/$ID.program.c -o /tmp/$ID.unoptimized.s \
  && gcc -std=c99 -O3 /tmp/$ID.native.assembly.s -o /tmp/$ID.hello.world.exe \
  && time /tmp/$ID.hello.world.exe
