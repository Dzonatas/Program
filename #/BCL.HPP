#include <alloca.h>
#include <unistd.h>
#include <string.h>
#include <malloc.h>

struct _string
	{
	unsigned int length ;
	char *       string ;
	} ;

struct _object
	{
	void* this ;
	struct _string (*$ToString)(const void**) ;
	} ;

static inline void BCL$$System_Object_ctor(const void** args) {}

static inline void BCL$$System_Console$WriteLine$string(const void** args)
	{
	const struct _string* s = *args ;
	write( 0 , s->string , s->length ) ;
	write( 0 , "\n" , 1 ) ;
	}

static inline const struct _string BCL$$System_String$Concat$object$object$object(const void** args)
	{
	struct _string a, b, c ;
	a = (*(struct _object *) ((struct _object *)args[0])->this).$ToString( args+0 ) ;
	b =  *(struct _string *) ((struct _object *)args[1])->this ;
	c = (*(struct _object *) ((struct _object *)args[2])->this).$ToString( args+2 ) ;
	static struct _string s ;
	s.length = a.length + b.length + c.length ;
	s.string = malloc(a.length + b.length + c.length) ;
	strncpy( s.string, a.string, a.length ) ;
	strncpy( &s.string[a.length], b.string, b.length ) ;
	strncpy( &s.string[a.length+b.length], c.string, c.length ) ;
	return s ;
	}
