all: ../understand.exe

.PHONY: clean

../understand.exe : make.sh lex.footer lex.head
	sh make.sh

clean:
	rm -f ../understand.exe
	rm -f opcode.xml
	rm -f opcode.xml
	rm -f opcode.t.y
	rm -f opcode.y
	rm -f grammar.y
	rm -f grammar.output
	rm -f grammar.xml
	rm -f grammar.tab.h
	rm -f grammar.tab.c
	rm -f lex.y
	rm -f lex.yy.c
	rm -f a.out
