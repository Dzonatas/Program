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

	struct _string
		{
		unsigned int length ;
		char *       string ;
		} string ;

	struct _object
		{
		struct _object*  this ;
		struct _string (*$ToString)(const void**) ;
		struct _string (*ToStemString)(const void**) ;
		//struct _string (*$ToObjectNotation)(const void**) ;
		} object ;
	} ;

/*
static inline void BCL$$System_Object_ctor(const void** args) {  }

static inline void BCL$$System_Console$WriteLine$string(const void** args)
	{
	const struct _string* s = *args ;
	write( 0 , s->string , s->length ) ;
	write( 0 , "\n" , 1 ) ;
	}

static inline const struct _string BCL$$System_String$Concat$object$object$object(const void** args)
	{
	struct _string a, b, c ;
	if( ((union _*)args[0])->base.managed && ((union _*)args[0])->base.pointer )
		a =  ((union _*)args[0])->string ;
	else
		a =  ((struct _object *)args[0])->this->$ToString( args+0 ) ;
	if( ((union _*)args[1])->base.managed && ((union _*)args[1])->base.pointer )
		b =  ((union _*)args[1])->string ;
	else
		b =  ((struct _object *)args[1])->this->$ToString( args+1 ) ;
	if( ((union _*)args[2])->base.managed && ((union _*)args[2])->base.pointer )
		c =  ((union _*)args[2])->string ;
	else
		c =  ((struct _object *)args[2])->this->$ToString( args+2 ) ;
	static struct _string s ;
	s.length = a.length + b.length + c.length ;
	s.string = malloc(a.length + b.length + c.length) ;
	strncpy( s.string, a.string, a.length ) ;
	strncpy( &s.string[a.length], b.string, b.length ) ;
	strncpy( &s.string[a.length+b.length], c.string, c.length ) ;
	return s ;
	}
*/