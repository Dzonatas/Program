#include <alloca.h>
#include <unistd.h>
#include <string.h>
#include <malloc.h>

struct _mp  //regression: managed pointer -> string -> blob
	{
	int managed ;
	void* pointer ;
	} ;
