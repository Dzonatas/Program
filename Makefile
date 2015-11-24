ID              =5a7160ed-13d5-4923-a1f9-3e32a47d558a
XBUILD          =xbuild /p:NoWarn=169,649,414,219 /verbosity:quiet /nologo

auto_driver_cs     =$(abspath ./~/auto.driver.cs)
understand_exe  =$(abspath ./~/understand.exe)
grammar_xml     =$(abspath ./~/understand/grammar.xml)

.PHONY: help clean test1 test2 test3 test4 project driver parser

help:
	@echo "Options:"
	@echo "make tests"
	@echo "make project"
	@echo "make driver"
	@echo "make parser"
	@echo "make clean"
	@echo
	@echo "Tests:
	@echo "make test1"
	@echo "make test2"
	@echo "make test3"
	@echo
	@echo "Agenda:"
	@echo "make test4"

project: bin/Debug/ecma.exe
driver: bin/Debug/driver.exe
parser: $(understand_exe)

bin/Debug/ecma.exe: $(auto_driver_cs)
	@echo "build ecma.csproj"
	$(XBUILD) ecma.csproj


$(auto_driver_cs): /tmp/.$(ID).d/auto.cs
	cp /tmp/.$(ID).d/auto.cs $(auto_driver_cs)

/tmp/.$(ID).d/auto.cs: bin/Debug/driver.exe
	( cd ./bin/Debug && ./driver.exe )

bin/Debug/driver.exe: $(grammar_xml)
	@echo "build driver.csproj"
	$(XBUILD)  driver.csproj

$(understand_exe): $(grammar_xml)

$(grammar_xml):
	( cd ./~/understand && make )

clean: 
	rm -rf /tmp/.$(ID).d
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

.PHONY: tests
tests: test1 test2 test3
