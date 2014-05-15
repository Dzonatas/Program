#include <alloca.h>
#include <unistd.h>
#include <string.h>
#include <malloc.h>

union _  //regression: string (void*) -> managed pointer (void**) -> atomic matrix (void***…)
	{
	struct _base
		{
		void* managed ;
		void* pointer ;
		} base;
	} ;
