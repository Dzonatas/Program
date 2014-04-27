#!/bin/sh
echo "<xslt>" >opcode.xml &&
cpp -E opcode.c | grep "^<" | grep -v "unused" >>opcode.xml &&
echo "</xslt>" >>opcode.xml &&
#xsltproc opcode.xslt.xml opcode.xml | grep "^CEE" >opcode.y &&
cpp -E opcode.t.c | sort -u | grep -v "^$\|#" >opcode.t.y &&
xsltproc opcode.part.xslt.xml opcode.xml | grep -v "^<?xml" >opcode.y &&
#echo >opcode.y &&
#( for i in `cat opcode.t.y` ; 
#  do
#   grep "type=\"$i\"\|xslt" opcode.xml |
#   xsltproc opcode.part.xslt.xml - | grep -v "^<?xml" >>opcode.y ;
#  done ) &&
#xsltproc opcode.all.xslt.xml opcode.xml | grep -v "^<?xml" >>opcode.y &&
cat "ecma335 grammar.txt" >grammar.y &&
#cat "ecma335 grammar.txt" opcode.y >grammar.y &&
bison -r all -dx grammar.y &&
  cat lex.head >lex.y &&
  xsltproc template.xslt.xml grammar.xml | grep "^\"" >>lex.y &&
  cat opcode.y >>lex.y &&
  #xsltproc template.xslt.xml "ecma335 grammar.xml" | grep "^\"" >>lex.y &&
  cat lex.footer >>lex.y &&
  lex -v --bison-bridge lex.y &&
  cc -DYYDEBUG=1 main.c grammar.tab.c lex.yy.c -lfl -o ../understand.exe
