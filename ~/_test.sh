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
  && ilasm $INPUT /out:$PREFIX.ilasm.exe >/dev/null \
  && chmod +x $PREFIX.ilasm.exe \
  && time ( $PREFIX.ilasm.exe ) 2>$PREFIX.a.time.txt

echo "--- Stats with (native) .NET-AOT: ---" \
  && ( cd /tmp/.$ID.d \
     && mono --aot=full -O=all $PREFIX.ilasm.exe >/dev/null \
     && time ( $PREFIX.ilasm.exe ) 2>$PREFIX.b.time.txt \
     )

echo "--- Stats for fully compiled native .exe by this program ---" \
  && ./ilxml.exe <$INPUT >$PREFIX.il.xml \
  && ./ecma.exe --input=$PREFIX.il.xml --output=$MODULE \
  && gcc -std=c99 -O3 -S -I ../../# $PREFIX.c -o $PREFIX.native.assembly.s \
  && gcc -std=c99 -S -I ../../# $PREFIX.c -o $PREFIX.unoptimized.s \
  && gcc -std=c99 -O3 $PREFIX.native.assembly.s -o $PREFIX.exe \
  && time ( $PREFIX.exe ) 2>$PREFIX.c.time.txt

echo "        VM      AOT      this"
join $PREFIX.a.time.txt $PREFIX.b.time.txt | join - $PREFIX.c.time.txt | sed 's/sys/ sys/' | sed 1d
