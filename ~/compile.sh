#!/bin/sh
ID="5a7160ed-13d5-4923-a1f9-3e32a47d558a"
XML=/tmp/$ID.il.xml
INPUT=$1
../../~/understand.exe <$INPUT >$XML && cat $XML
