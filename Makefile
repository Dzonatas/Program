ID              =5a7160ed-13d5-4923-a1f9-3e32a47d558a
XBUILD          =xbuild /p:NoWarn=169,649,414,219 /verbosity:quiet /nologo

auto_driver_cs  =$(abspath ./~/auto.driver.cs)
grammar_xml     =$(abspath ./~/ilxml/grammar.xml)

.PHONY: help clean test1 test2 test3 test4 test5 test6 project driver parser

help:
	@echo "Options:"
	@echo "make tests"
	@echo "make project"
	@echo "make driver"
	@echo "make parser"
	@echo "make clean"
	@echo
	@echo "Tests:"
	@echo "make test1"
	@echo "make test2"
	@echo "make test3"
	@echo "make test4"
	@echo "make test5"
	@echo "make test6"
	@echo "make test7"
	@echo
	@echo "Agenda:"
	@echo "make testseh"
	@echo "make cdriver"

project: bin/Debug/ecma.exe bin/Debug/ilxml.exe bin/Debug/driver.exe
driver: bin/Debug/driver.exe
parser: bin/Debug/ilxml.exe

bin/Debug/ecma.exe: $(auto_driver_cs)
	@echo "build ecma.csproj"
	$(XBUILD) ecma.csproj


$(auto_driver_cs): /tmp/.$(ID).d/auto.cs
	cp /tmp/.$(ID).d/auto.cs $(auto_driver_cs)

/tmp/.$(ID).d/auto.cs: bin/Debug/driver.exe
	( cd ./bin/Debug && ./driver.exe --build=automaton )

bin/Debug/driver.exe: $(grammar_xml)
	@echo "build driver.csproj"
	$(XBUILD) /p:Configuration=Debug  driver.csproj

bin/Debug/ilxml.exe: $(grammar_xml)
	( ( [ -d "./bin/Debug" ] && true ) || mkdir -p ./bin/Debug )
	cp "./~/ilxml/ilxml.exe" bin/Debug

$(grammar_xml):
	( cd ./~/ilxml && make )

clean: 
	rm -rf /tmp/.$(ID).d
	rm -rf bin
	rm -rf obj
	( cd ./~/ilxml && make clean )

test1: project
	./~/test.sh

test2: project
	./~/test2/test.sh

test3: project
	./~/test3/test.sh

test4: project
	./~/test4/test.sh

test5: project
	./~/test5/test.sh

test6: project
	./~/test6/test.sh

test7: project
	./~/test7/test.sh

testseh: project
	./~/testseh/test.sh

cdriver: project
	( cd ./bin/Debug && ./driver.exe --build=infrastructure --shell="../../~/compile.sh ../../~/hello.mono.world.il.text" )
	./~/cdriver/test.sh

.PHONY: tests
tests: test1 test2 test3 test4 test5 test6 test7
