#include <alloca.h>
#include <unistd.h>

struct _string
        {
        unsigned int length ;
        char *       string ;
        } ;

static inline void corlib$$System_Object_ctor(const void** args) {}

static inline void corlib$$System_Console$WriteLine$string(const void** args)
        {
        const struct _string* s = *args ;
        write( 0 , s->string , s->length ) ;
        write( 0 , "\n" , 1 ) ;
        }

