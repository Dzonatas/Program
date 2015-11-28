#!/bin/sh
# Routine used by tests
# Example: sh ./~/_test.sh input.il test1

echo "---------------------------------------------"
echo "---------- $2 ----------------------------"
echo "---------------------------------------------"

export TERM="XHTML"
ID="5a7160ed-13d5-4923-a1f9-3e32a47d558a"
INPUT=$1
PREFIX=/tmp/.$ID.d/$2
MODULE=$2

[ ! -d "/tmp/.$ID.d" ] && mkdir /tmp/.$ID.d

cd ./bin/Debug

echo "--- Stats with .NET-VM: ---" \
  && ilasm $INPUT /out:$PREFIX.ilasm.hello.world.exe >/dev/null \
  && chmod +x $PREFIX.ilasm.hello.world.exe \
  && time $PREFIX.ilasm.hello.world.exe

echo "--- Stats with (native) .NET-AOT: ---" \
 && ( cd /tmp/.$ID.d && mono --aot=full -O=all $PREFIX.ilasm.hello.world.exe >/dev/null && time $PREFIX.ilasm.hello.world.exe )

echo "--- Stats for fully native compiled .exe by this program ---" \
  && ./ilxml.exe <$INPUT >$PREFIX.il.xml \
  && ./ecma.exe --input=$PREFIX.il.xml --output=$MODULE \
  && gcc -std=c99 -O3 -S -I ../../# $PREFIX.c -o $PREFIX.native.assembly.s \
  && gcc -std=c99 -S -I ../../# $PREFIX.c -o $PREFIX.unoptimized.s \
  && gcc -std=c99 -O3 $PREFIX.native.assembly.s -o $PREFIX.hello.world.exe \
  && time $PREFIX.hello.world.exe
