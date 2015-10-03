ID=5a7160ed-13d5-4923-a1f9-3e32a47d558a

.PHONY: help clean project test1 test2 test3 test4 driver parser

help:
	@echo "Options:"
	@echo "make project"
	@echo "make driver"
	@echo "make parser"
	@echo "make test1"
	@echo "make test2"
	@echo "make test3"
	@echo "make test4"
	@echo "make clean"

project: driver ./bin/Debug/ecma.exe

driver: parser ./bin/Debug/driver.exe
	( cd ./bin/Debug && ./driver.exe )
	cp /tmp/.$(ID).d/auto.cs ./~/auto.bis.cs

parser: ./~/understand.exe

./bin/Debug/driver.exe:
	xbuild driver.csproj

./bin/Debug/ecma.exe:
	xbuild ecma.csproj

./~/understand.exe:
	( cd ./~/understand && make )

clean: 
	rm -rf /tmp/.$(ID).d
	rm -f /tmp/$(ID).il.xml
	rm -f /tmp/$(ID).hello.world.exe
	rm -rf bin
	rm -rf obj
	( cd ./~/understand && make clean )

test1: project
	./~/test.sh

test2: project
	./~/test2/test.sh

test3: project
	./~/test3/test.sh

test4: project
	./~/test4/test.sh
