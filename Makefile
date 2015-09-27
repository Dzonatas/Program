ID=5a7160ed-13d5-4923-a1f9-3e32a47d558a

.PHONY: help clean project test1 test2 test3 test4

help:
	@echo "Options:"
	@echo "make project"
	@echo "make test1"
	@echo "make test2"
	@echo "make test3"
	@echo "make test4"
	@echo "make clean"

project:
	xbuild ecma.csproj

clean: 
	rm -rf /tmp/.$(ID).d
	rm -f /tmp/$(ID).il.xml
	rm -f /tmp/$(ID).hello.world.exe
	rm -rf bin
	rm -rf obj

test1:
	./~/test.sh

test2:
	./~/test2/test.sh

test3:
	./~/test3/test.sh

test4:
	./~/test4/test.sh
