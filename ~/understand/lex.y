L [a-zA-Z]
N [$`@_?]
F ({L}|{N})
D [0-9]
C ({L}|{D}|{N})
H ([a-fA-F]|{D})
P [;,.:\{\}\[\]\(\)=/]
WS [ \t\n\v\f]
%{
#include "grammar.tab.h"

int dottedname = 0 ;
char *text ;
char *buf ;

//#define PRINT() printf("<_%d/>%s",(int)(long)yylval_param,text) ;

#define INSTRUCTION(_1,_2,_3) INSTRUCTION_(#_1,_1,_2,_3)

#define OPDEF(_0,_1,_2,_3,_4,_5,_6,_7,_8,_9) { #_0, _1, #_2, #_3, #_4, #_5, #_6, #_7, #_8, #_9 },

struct _opcodes {
	char *cn ;
	char *sn ;
	char *sb1 ;
	char *sb2 ;
	char *op ;
	char *ok ;
	char *h, *b1, *b2 ;
	char *cf ;
	} opcodes[] =
	{
	
#include "opcode.def"
	};

%}
%%
"//".* 
"#line".*

"'.ctor'"		{ int i ; for( i = 5 ; i > 0 ; i-- ) unput( ".ctor"[i-1] ) ;  }
"'.cctor'"		{ int i ; for( i = 6 ; i > 0 ; i-- ) unput( ".cctor"[i-1] ) ;  }

".subsystem" { text= ".subsystem" ; return TERMINAL_( 282, text, yylval_param ) ; }
".corflags" { text= ".corflags" ; return TERMINAL_( 283, text, yylval_param ) ; }
".file" { text= ".file" ; return TERMINAL_( 284, text, yylval_param ) ; }
"alignment" { text= "alignment" ; return TERMINAL_( 285, text, yylval_param ) ; }
".imagebase" { text= ".imagebase" ; return TERMINAL_( 286, text, yylval_param ) ; }
".language" { text= ".language" ; return TERMINAL_( 287, text, yylval_param ) ; }
".custom" { text= ".custom" ; return TERMINAL_( 288, text, yylval_param ) ; }
".module" { text= ".module" ; return TERMINAL_( 289, text, yylval_param ) ; }
"extern" { text= "extern" ; return TERMINAL_( 290, text, yylval_param ) ; }
".vtfixup" { text= ".vtfixup" ; return TERMINAL_( 291, text, yylval_param ) ; }
"at" { text= "at" ; return TERMINAL_( 292, text, yylval_param ) ; }
"int32" { text= "int32" ; return TERMINAL_( 293, text, yylval_param ) ; }
"int64" { text= "int64" ; return TERMINAL_( 294, text, yylval_param ) ; }
"fromunmanaged" { text= "fromunmanaged" ; return TERMINAL_( 295, text, yylval_param ) ; }
"callmostderived" { text= "callmostderived" ; return TERMINAL_( 296, text, yylval_param ) ; }
".vtable" { text= ".vtable" ; return TERMINAL_( 297, text, yylval_param ) ; }
".namespace" { text= ".namespace" ; return TERMINAL_( 298, text, yylval_param ) ; }
".class" { text= ".class" ; return TERMINAL_( 299, text, yylval_param ) ; }
"public" { text= "public" ; return TERMINAL_( 300, text, yylval_param ) ; }
"private" { text= "private" ; return TERMINAL_( 301, text, yylval_param ) ; }
"value" { text= "value" ; return TERMINAL_( 302, text, yylval_param ) ; }
"enum" { text= "enum" ; return TERMINAL_( 303, text, yylval_param ) ; }
"interface" { text= "interface" ; return TERMINAL_( 304, text, yylval_param ) ; }
"sealed" { text= "sealed" ; return TERMINAL_( 305, text, yylval_param ) ; }
"abstract" { text= "abstract" ; return TERMINAL_( 306, text, yylval_param ) ; }
"auto" { text= "auto" ; return TERMINAL_( 307, text, yylval_param ) ; }
"sequential" { text= "sequential" ; return TERMINAL_( 308, text, yylval_param ) ; }
"explicit" { text= "explicit" ; return TERMINAL_( 309, text, yylval_param ) ; }
"ansi" { text= "ansi" ; return TERMINAL_( 310, text, yylval_param ) ; }
"unicode" { text= "unicode" ; return TERMINAL_( 311, text, yylval_param ) ; }
"autochar" { text= "autochar" ; return TERMINAL_( 312, text, yylval_param ) ; }
"import" { text= "import" ; return TERMINAL_( 313, text, yylval_param ) ; }
"serializable" { text= "serializable" ; return TERMINAL_( 314, text, yylval_param ) ; }
"nested" { text= "nested" ; return TERMINAL_( 315, text, yylval_param ) ; }
"family" { text= "family" ; return TERMINAL_( 316, text, yylval_param ) ; }
"assembly" { text= "assembly" ; return TERMINAL_( 317, text, yylval_param ) ; }
"famandassem" { text= "famandassem" ; return TERMINAL_( 318, text, yylval_param ) ; }
"famorassem" { text= "famorassem" ; return TERMINAL_( 319, text, yylval_param ) ; }
"beforefieldinit" { text= "beforefieldinit" ; return TERMINAL_( 320, text, yylval_param ) ; }
"specialname" { text= "specialname" ; return TERMINAL_( 321, text, yylval_param ) ; }
"rtspecialname" { text= "rtspecialname" ; return TERMINAL_( 322, text, yylval_param ) ; }
"extends" { text= "extends" ; return TERMINAL_( 323, text, yylval_param ) ; }
"implements" { text= "implements" ; return TERMINAL_( 324, text, yylval_param ) ; }
".size" { text= ".size" ; return TERMINAL_( 325, text, yylval_param ) ; }
".pack" { text= ".pack" ; return TERMINAL_( 326, text, yylval_param ) ; }
".override" { text= ".override" ; return TERMINAL_( 327, text, yylval_param ) ; }
"::" { text= "::" ; return TERMINAL_( 328, text, yylval_param ) ; }
"with" { text= "with" ; return TERMINAL_( 329, text, yylval_param ) ; }
".field" { text= ".field" ; return TERMINAL_( 330, text, yylval_param ) ; }
"field" { text= "field" ; return TERMINAL_( 331, text, yylval_param ) ; }
".ctor" { text= ".ctor" ; return TERMINAL_( 332, text, yylval_param ) ; }
".event" { text= ".event" ; return TERMINAL_( 333, text, yylval_param ) ; }
".addon" { text= ".addon" ; return TERMINAL_( 334, text, yylval_param ) ; }
".removeon" { text= ".removeon" ; return TERMINAL_( 335, text, yylval_param ) ; }
".fire" { text= ".fire" ; return TERMINAL_( 336, text, yylval_param ) ; }
".other" { text= ".other" ; return TERMINAL_( 337, text, yylval_param ) ; }
".property" { text= ".property" ; return TERMINAL_( 338, text, yylval_param ) ; }
".set" { text= ".set" ; return TERMINAL_( 339, text, yylval_param ) ; }
".get" { text= ".get" ; return TERMINAL_( 340, text, yylval_param ) ; }
".method" { text= ".method" ; return TERMINAL_( 341, text, yylval_param ) ; }
"marshal" { text= "marshal" ; return TERMINAL_( 342, text, yylval_param ) ; }
"static" { text= "static" ; return TERMINAL_( 343, text, yylval_param ) ; }
"final" { text= "final" ; return TERMINAL_( 344, text, yylval_param ) ; }
"virtual" { text= "virtual" ; return TERMINAL_( 345, text, yylval_param ) ; }
"privatescope" { text= "privatescope" ; return TERMINAL_( 346, text, yylval_param ) ; }
"hidebysig" { text= "hidebysig" ; return TERMINAL_( 347, text, yylval_param ) ; }
"newslot" { text= "newslot" ; return TERMINAL_( 348, text, yylval_param ) ; }
"unmanagedexp" { text= "unmanagedexp" ; return TERMINAL_( 349, text, yylval_param ) ; }
"reqsecobj" { text= "reqsecobj" ; return TERMINAL_( 350, text, yylval_param ) ; }
"pinvokeimpl" { text= "pinvokeimpl" ; return TERMINAL_( 351, text, yylval_param ) ; }
"as" { text= "as" ; return TERMINAL_( 352, text, yylval_param ) ; }
"nomangle" { text= "nomangle" ; return TERMINAL_( 353, text, yylval_param ) ; }
"lasterr" { text= "lasterr" ; return TERMINAL_( 354, text, yylval_param ) ; }
"winapi" { text= "winapi" ; return TERMINAL_( 355, text, yylval_param ) ; }
"cdecl" { text= "cdecl" ; return TERMINAL_( 356, text, yylval_param ) ; }
"stdcall" { text= "stdcall" ; return TERMINAL_( 357, text, yylval_param ) ; }
"thiscall" { text= "thiscall" ; return TERMINAL_( 358, text, yylval_param ) ; }
"fastcall" { text= "fastcall" ; return TERMINAL_( 359, text, yylval_param ) ; }
".cctor" { text= ".cctor" ; return TERMINAL_( 360, text, yylval_param ) ; }
"in" { text= "in" ; return TERMINAL_( 361, text, yylval_param ) ; }
"out" { text= "out" ; return TERMINAL_( 362, text, yylval_param ) ; }
"opt" { text= "opt" ; return TERMINAL_( 363, text, yylval_param ) ; }
"initonly" { text= "initonly" ; return TERMINAL_( 364, text, yylval_param ) ; }
"literal" { text= "literal" ; return TERMINAL_( 365, text, yylval_param ) ; }
"notserialized" { text= "notserialized" ; return TERMINAL_( 366, text, yylval_param ) ; }
"native" { text= "native" ; return TERMINAL_( 367, text, yylval_param ) ; }
"cil" { text= "cil" ; return TERMINAL_( 368, text, yylval_param ) ; }
"optil" { text= "optil" ; return TERMINAL_( 369, text, yylval_param ) ; }
"managed" { text= "managed" ; return TERMINAL_( 370, text, yylval_param ) ; }
"unmanaged" { text= "unmanaged" ; return TERMINAL_( 371, text, yylval_param ) ; }
"forwardref" { text= "forwardref" ; return TERMINAL_( 372, text, yylval_param ) ; }
"preservesig" { text= "preservesig" ; return TERMINAL_( 373, text, yylval_param ) ; }
"runtime" { text= "runtime" ; return TERMINAL_( 374, text, yylval_param ) ; }
"internalcall" { text= "internalcall" ; return TERMINAL_( 375, text, yylval_param ) ; }
"synchronized" { text= "synchronized" ; return TERMINAL_( 376, text, yylval_param ) ; }
"noinlining" { text= "noinlining" ; return TERMINAL_( 377, text, yylval_param ) ; }
".locals" { text= ".locals" ; return TERMINAL_( 378, text, yylval_param ) ; }
".emitbyte" { text= ".emitbyte" ; return TERMINAL_( 379, text, yylval_param ) ; }
".maxstack" { text= ".maxstack" ; return TERMINAL_( 380, text, yylval_param ) ; }
"init" { text= "init" ; return TERMINAL_( 381, text, yylval_param ) ; }
".entrypoint" { text= ".entrypoint" ; return TERMINAL_( 382, text, yylval_param ) ; }
".zeroinit" { text= ".zeroinit" ; return TERMINAL_( 383, text, yylval_param ) ; }
".export" { text= ".export" ; return TERMINAL_( 384, text, yylval_param ) ; }
".vtentry" { text= ".vtentry" ; return TERMINAL_( 385, text, yylval_param ) ; }
".param" { text= ".param" ; return TERMINAL_( 386, text, yylval_param ) ; }
"to" { text= "to" ; return TERMINAL_( 387, text, yylval_param ) ; }
".try" { text= ".try" ; return TERMINAL_( 388, text, yylval_param ) ; }
"filter" { text= "filter" ; return TERMINAL_( 389, text, yylval_param ) ; }
"catch" { text= "catch" ; return TERMINAL_( 390, text, yylval_param ) ; }
"finally" { text= "finally" ; return TERMINAL_( 391, text, yylval_param ) ; }
"fault" { text= "fault" ; return TERMINAL_( 392, text, yylval_param ) ; }
"handler" { text= "handler" ; return TERMINAL_( 393, text, yylval_param ) ; }
".data" { text= ".data" ; return TERMINAL_( 394, text, yylval_param ) ; }
"tls" { text= "tls" ; return TERMINAL_( 395, text, yylval_param ) ; }
"char" { text= "char" ; return TERMINAL_( 396, text, yylval_param ) ; }
"float32" { text= "float32" ; return TERMINAL_( 397, text, yylval_param ) ; }
"float64" { text= "float64" ; return TERMINAL_( 398, text, yylval_param ) ; }
"int16" { text= "int16" ; return TERMINAL_( 399, text, yylval_param ) ; }
"int8" { text= "int8" ; return TERMINAL_( 400, text, yylval_param ) ; }
"bool" { text= "bool" ; return TERMINAL_( 401, text, yylval_param ) ; }
"nullref" { text= "nullref" ; return TERMINAL_( 402, text, yylval_param ) ; }
"bytearray" { text= "bytearray" ; return TERMINAL_( 403, text, yylval_param ) ; }
"method" { text= "method" ; return TERMINAL_( 404, text, yylval_param ) ; }
"..." { text= "..." ; return TERMINAL_( 405, text, yylval_param ) ; }
"instance" { text= "instance" ; return TERMINAL_( 406, text, yylval_param ) ; }
"default" { text= "default" ; return TERMINAL_( 407, text, yylval_param ) ; }
"vararg" { text= "vararg" ; return TERMINAL_( 408, text, yylval_param ) ; }
"custom" { text= "custom" ; return TERMINAL_( 409, text, yylval_param ) ; }
"fixed" { text= "fixed" ; return TERMINAL_( 410, text, yylval_param ) ; }
"sysstring" { text= "sysstring" ; return TERMINAL_( 411, text, yylval_param ) ; }
"array" { text= "array" ; return TERMINAL_( 412, text, yylval_param ) ; }
"variant" { text= "variant" ; return TERMINAL_( 413, text, yylval_param ) ; }
"currency" { text= "currency" ; return TERMINAL_( 414, text, yylval_param ) ; }
"syschar" { text= "syschar" ; return TERMINAL_( 415, text, yylval_param ) ; }
"void" { text= "void" ; return TERMINAL_( 416, text, yylval_param ) ; }
"error" { text= "error" ; return TERMINAL_( 417, text, yylval_param ) ; }
"unsigned" { text= "unsigned" ; return TERMINAL_( 418, text, yylval_param ) ; }
"decimal" { text= "decimal" ; return TERMINAL_( 419, text, yylval_param ) ; }
"date" { text= "date" ; return TERMINAL_( 420, text, yylval_param ) ; }
"bstr" { text= "bstr" ; return TERMINAL_( 421, text, yylval_param ) ; }
"lpstr" { text= "lpstr" ; return TERMINAL_( 422, text, yylval_param ) ; }
"lpwstr" { text= "lpwstr" ; return TERMINAL_( 423, text, yylval_param ) ; }
"lptstr" { text= "lptstr" ; return TERMINAL_( 424, text, yylval_param ) ; }
"objectref" { text= "objectref" ; return TERMINAL_( 425, text, yylval_param ) ; }
"iunknown" { text= "iunknown" ; return TERMINAL_( 426, text, yylval_param ) ; }
"idispatch" { text= "idispatch" ; return TERMINAL_( 427, text, yylval_param ) ; }
"struct" { text= "struct" ; return TERMINAL_( 428, text, yylval_param ) ; }
"safearray" { text= "safearray" ; return TERMINAL_( 429, text, yylval_param ) ; }
"int" { text= "int" ; return TERMINAL_( 430, text, yylval_param ) ; }
"byvalstr" { text= "byvalstr" ; return TERMINAL_( 431, text, yylval_param ) ; }
"tbstr" { text= "tbstr" ; return TERMINAL_( 432, text, yylval_param ) ; }
"any" { text= "any" ; return TERMINAL_( 433, text, yylval_param ) ; }
"lpstruct" { text= "lpstruct" ; return TERMINAL_( 434, text, yylval_param ) ; }
"null" { text= "null" ; return TERMINAL_( 435, text, yylval_param ) ; }
"vector" { text= "vector" ; return TERMINAL_( 436, text, yylval_param ) ; }
"hresult" { text= "hresult" ; return TERMINAL_( 437, text, yylval_param ) ; }
"carray" { text= "carray" ; return TERMINAL_( 438, text, yylval_param ) ; }
"userdefined" { text= "userdefined" ; return TERMINAL_( 439, text, yylval_param ) ; }
"record" { text= "record" ; return TERMINAL_( 440, text, yylval_param ) ; }
"filetime" { text= "filetime" ; return TERMINAL_( 441, text, yylval_param ) ; }
"blob" { text= "blob" ; return TERMINAL_( 442, text, yylval_param ) ; }
"stream" { text= "stream" ; return TERMINAL_( 443, text, yylval_param ) ; }
"storage" { text= "storage" ; return TERMINAL_( 444, text, yylval_param ) ; }
"streamed_object" { text= "streamed_object" ; return TERMINAL_( 445, text, yylval_param ) ; }
"stored_object" { text= "stored_object" ; return TERMINAL_( 446, text, yylval_param ) ; }
"blob_object" { text= "blob_object" ; return TERMINAL_( 447, text, yylval_param ) ; }
"cf" { text= "cf" ; return TERMINAL_( 448, text, yylval_param ) ; }
"clsid" { text= "clsid" ; return TERMINAL_( 449, text, yylval_param ) ; }
"class" { text= "class" ; return TERMINAL_( 450, text, yylval_param ) ; }
"object" { text= "object" ; return TERMINAL_( 451, text, yylval_param ) ; }
"string" { text= "string" ; return TERMINAL_( 452, text, yylval_param ) ; }
"valuetype" { text= "valuetype" ; return TERMINAL_( 453, text, yylval_param ) ; }
"pinned" { text= "pinned" ; return TERMINAL_( 454, text, yylval_param ) ; }
"modreq" { text= "modreq" ; return TERMINAL_( 455, text, yylval_param ) ; }
"modopt" { text= "modopt" ; return TERMINAL_( 456, text, yylval_param ) ; }
"typedref" { text= "typedref" ; return TERMINAL_( 457, text, yylval_param ) ; }
"float" { text= "float" ; return TERMINAL_( 458, text, yylval_param ) ; }
".permission" { text= ".permission" ; return TERMINAL_( 459, text, yylval_param ) ; }
".permissionset" { text= ".permissionset" ; return TERMINAL_( 460, text, yylval_param ) ; }
"true" { text= "true" ; return TERMINAL_( 461, text, yylval_param ) ; }
"false" { text= "false" ; return TERMINAL_( 462, text, yylval_param ) ; }
"request" { text= "request" ; return TERMINAL_( 463, text, yylval_param ) ; }
"demand" { text= "demand" ; return TERMINAL_( 464, text, yylval_param ) ; }
"assert" { text= "assert" ; return TERMINAL_( 465, text, yylval_param ) ; }
"deny" { text= "deny" ; return TERMINAL_( 466, text, yylval_param ) ; }
"permitonly" { text= "permitonly" ; return TERMINAL_( 467, text, yylval_param ) ; }
"linkcheck" { text= "linkcheck" ; return TERMINAL_( 468, text, yylval_param ) ; }
"inheritcheck" { text= "inheritcheck" ; return TERMINAL_( 469, text, yylval_param ) ; }
"reqmin" { text= "reqmin" ; return TERMINAL_( 470, text, yylval_param ) ; }
"reqopt" { text= "reqopt" ; return TERMINAL_( 471, text, yylval_param ) ; }
"reqrefuse" { text= "reqrefuse" ; return TERMINAL_( 472, text, yylval_param ) ; }
"prejitgrant" { text= "prejitgrant" ; return TERMINAL_( 473, text, yylval_param ) ; }
"prejitdeny" { text= "prejitdeny" ; return TERMINAL_( 474, text, yylval_param ) ; }
"noncasdemand" { text= "noncasdemand" ; return TERMINAL_( 475, text, yylval_param ) ; }
"noncaslinkdemand" { text= "noncaslinkdemand" ; return TERMINAL_( 476, text, yylval_param ) ; }
"noncasinheritance" { text= "noncasinheritance" ; return TERMINAL_( 477, text, yylval_param ) ; }
".line" { text= ".line" ; return TERMINAL_( 478, text, yylval_param ) ; }
"nometadata" { text= "nometadata" ; return TERMINAL_( 479, text, yylval_param ) ; }
".hash" { text= ".hash" ; return TERMINAL_( 480, text, yylval_param ) ; }
".assembly" { text= ".assembly" ; return TERMINAL_( 481, text, yylval_param ) ; }
"noappdomain" { text= "noappdomain" ; return TERMINAL_( 482, text, yylval_param ) ; }
"noprocess" { text= "noprocess" ; return TERMINAL_( 483, text, yylval_param ) ; }
"nomachine" { text= "nomachine" ; return TERMINAL_( 484, text, yylval_param ) ; }
"algorithm" { text= "algorithm" ; return TERMINAL_( 485, text, yylval_param ) ; }
".ver" { text= ".ver" ; return TERMINAL_( 486, text, yylval_param ) ; }
".locale" { text= ".locale" ; return TERMINAL_( 487, text, yylval_param ) ; }
".publickey" { text= ".publickey" ; return TERMINAL_( 488, text, yylval_param ) ; }
".publickeytoken" { text= ".publickeytoken" ; return TERMINAL_( 489, text, yylval_param ) ; }
".mresource" { text= ".mresource" ; return TERMINAL_( 490, text, yylval_param ) ; }
"nop" { text="CEE_NOP" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"break" { text="CEE_BREAK" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldarg.0" { text="CEE_LDARG_0" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldarg.1" { text="CEE_LDARG_1" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldarg.2" { text="CEE_LDARG_2" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldarg.3" { text="CEE_LDARG_3" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldloc.0" { text="CEE_LDLOC_0" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldloc.1" { text="CEE_LDLOC_1" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldloc.2" { text="CEE_LDLOC_2" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldloc.3" { text="CEE_LDLOC_3" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"stloc.0" { text="CEE_STLOC_0" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"stloc.1" { text="CEE_STLOC_1" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"stloc.2" { text="CEE_STLOC_2" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"stloc.3" { text="CEE_STLOC_3" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldarg.s" { text="CEE_LDARG_S" ; return INSTRUCTION( INSTR_VAR, text, yylval_param ) ; } 
"ldarga.s" { text="CEE_LDARGA_S" ; return INSTRUCTION( INSTR_VAR, text, yylval_param ) ; } 
"starg.s" { text="CEE_STARG_S" ; return INSTRUCTION( INSTR_VAR, text, yylval_param ) ; } 
"ldloc.s" { text="CEE_LDLOC_S" ; return INSTRUCTION( INSTR_VAR, text, yylval_param ) ; } 
"ldloca.s" { text="CEE_LDLOCA_S" ; return INSTRUCTION( INSTR_VAR, text, yylval_param ) ; } 
"stloc.s" { text="CEE_STLOC_S" ; return INSTRUCTION( INSTR_VAR, text, yylval_param ) ; } 
"ldnull" { text="CEE_LDNULL" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldc.i4.m1" { text="CEE_LDC_I4_M1" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldc.i4.0" { text="CEE_LDC_I4_0" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldc.i4.1" { text="CEE_LDC_I4_1" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldc.i4.2" { text="CEE_LDC_I4_2" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldc.i4.3" { text="CEE_LDC_I4_3" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldc.i4.4" { text="CEE_LDC_I4_4" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldc.i4.5" { text="CEE_LDC_I4_5" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldc.i4.6" { text="CEE_LDC_I4_6" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldc.i4.7" { text="CEE_LDC_I4_7" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldc.i4.8" { text="CEE_LDC_I4_8" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldc.i4.s" { text="CEE_LDC_I4_S" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"ldc.i4" { text="CEE_LDC_I4" ; return INSTRUCTION( INSTR_I, text, yylval_param ) ; } 
"ldc.i8" { text="CEE_LDC_I8" ; return INSTRUCTION( INSTR_I8, text, yylval_param ) ; } 
"ldc.r4" { text="CEE_LDC_R4" ; return INSTRUCTION( INSTR_R, text, yylval_param ) ; } 
"ldc.r8" { text="CEE_LDC_R8" ; return INSTRUCTION( INSTR_R, text, yylval_param ) ; } 
"dup" { text="CEE_DUP" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"pop" { text="CEE_POP" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"jmp" { text="CEE_JMP" ; return INSTRUCTION( INSTR_METHOD, text, yylval_param ) ; } 
"call" { text="CEE_CALL" ; return INSTRUCTION( INSTR_METHOD, text, yylval_param ) ; } 
"calli" { text="CEE_CALLI" ; return INSTRUCTION( INSTR_SIG, text, yylval_param ) ; } 
"ret" { text="CEE_RET" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"br.s" { text="CEE_BR_S" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"brfalse.s" { text="CEE_BRFALSE_S" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"brtrue.s" { text="CEE_BRTRUE_S" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"beq.s" { text="CEE_BEQ_S" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"bge.s" { text="CEE_BGE_S" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"bgt.s" { text="CEE_BGT_S" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"ble.s" { text="CEE_BLE_S" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"blt.s" { text="CEE_BLT_S" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"bne.un.s" { text="CEE_BNE_UN_S" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"bge.un.s" { text="CEE_BGE_UN_S" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"bgt.un.s" { text="CEE_BGT_UN_S" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"ble.un.s" { text="CEE_BLE_UN_S" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"blt.un.s" { text="CEE_BLT_UN_S" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"br" { text="CEE_BR" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"brfalse" { text="CEE_BRFALSE" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"brtrue" { text="CEE_BRTRUE" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"beq" { text="CEE_BEQ" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"bge" { text="CEE_BGE" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"bgt" { text="CEE_BGT" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"ble" { text="CEE_BLE" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"blt" { text="CEE_BLT" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"bne.un" { text="CEE_BNE_UN" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"bge.un" { text="CEE_BGE_UN" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"bgt.un" { text="CEE_BGT_UN" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"ble.un" { text="CEE_BLE_UN" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"blt.un" { text="CEE_BLT_UN" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"switch" { text="CEE_SWITCH" ; return INSTRUCTION( INSTR_SWITCH, text, yylval_param ) ; } 
"ldind.i1" { text="CEE_LDIND_I1" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldind.u1" { text="CEE_LDIND_U1" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldind.i2" { text="CEE_LDIND_I2" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldind.u2" { text="CEE_LDIND_U2" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldind.i4" { text="CEE_LDIND_I4" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldind.u4" { text="CEE_LDIND_U4" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldind.i8" { text="CEE_LDIND_I8" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldind.i" { text="CEE_LDIND_I" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldind.r4" { text="CEE_LDIND_R4" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldind.r8" { text="CEE_LDIND_R8" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldind.ref" { text="CEE_LDIND_REF" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"stind.ref" { text="CEE_STIND_REF" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"stind.i1" { text="CEE_STIND_I1" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"stind.i2" { text="CEE_STIND_I2" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"stind.i4" { text="CEE_STIND_I4" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"stind.i8" { text="CEE_STIND_I8" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"stind.r4" { text="CEE_STIND_R4" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"stind.r8" { text="CEE_STIND_R8" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"add" { text="CEE_ADD" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"sub" { text="CEE_SUB" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"mul" { text="CEE_MUL" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"div" { text="CEE_DIV" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"div.un" { text="CEE_DIV_UN" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"rem" { text="CEE_REM" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"rem.un" { text="CEE_REM_UN" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"and" { text="CEE_AND" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"or" { text="CEE_OR" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"xor" { text="CEE_XOR" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"shl" { text="CEE_SHL" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"shr" { text="CEE_SHR" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"shr.un" { text="CEE_SHR_UN" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"neg" { text="CEE_NEG" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"not" { text="CEE_NOT" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.i1" { text="CEE_CONV_I1" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.i2" { text="CEE_CONV_I2" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.i4" { text="CEE_CONV_I4" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.i8" { text="CEE_CONV_I8" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.r4" { text="CEE_CONV_R4" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.r8" { text="CEE_CONV_R8" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.u4" { text="CEE_CONV_U4" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.u8" { text="CEE_CONV_U8" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"callvirt" { text="CEE_CALLVIRT" ; return INSTRUCTION( INSTR_METHOD, text, yylval_param ) ; } 
"cpobj" { text="CEE_CPOBJ" ; return INSTRUCTION( INSTR_TYPE, text, yylval_param ) ; } 
"ldobj" { text="CEE_LDOBJ" ; return INSTRUCTION( INSTR_TYPE, text, yylval_param ) ; } 
"ldstr" { text="CEE_LDSTR" ; return INSTRUCTION( INSTR_STRING, text, yylval_param ) ; } 
"newobj" { text="CEE_NEWOBJ" ; return INSTRUCTION( INSTR_METHOD, text, yylval_param ) ; } 
"castclass" { text="CEE_CASTCLASS" ; return INSTRUCTION( INSTR_TYPE, text, yylval_param ) ; } 
"isinst" { text="CEE_ISINST" ; return INSTRUCTION( INSTR_TYPE, text, yylval_param ) ; } 
"conv.r.un" { text="CEE_CONV_R_UN" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"unbox" { text="CEE_UNBOX" ; return INSTRUCTION( INSTR_TYPE, text, yylval_param ) ; } 
"throw" { text="CEE_THROW" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldfld" { text="CEE_LDFLD" ; return INSTRUCTION( INSTR_FIELD, text, yylval_param ) ; } 
"ldflda" { text="CEE_LDFLDA" ; return INSTRUCTION( INSTR_FIELD, text, yylval_param ) ; } 
"stfld" { text="CEE_STFLD" ; return INSTRUCTION( INSTR_FIELD, text, yylval_param ) ; } 
"ldsfld" { text="CEE_LDSFLD" ; return INSTRUCTION( INSTR_FIELD, text, yylval_param ) ; } 
"ldsflda" { text="CEE_LDSFLDA" ; return INSTRUCTION( INSTR_FIELD, text, yylval_param ) ; } 
"stsfld" { text="CEE_STSFLD" ; return INSTRUCTION( INSTR_FIELD, text, yylval_param ) ; } 
"stobj" { text="CEE_STOBJ" ; return INSTRUCTION( INSTR_TYPE, text, yylval_param ) ; } 
"conv.ovf.i1.un" { text="CEE_CONV_OVF_I1_UN" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.ovf.i2.un" { text="CEE_CONV_OVF_I2_UN" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.ovf.i4.un" { text="CEE_CONV_OVF_I4_UN" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.ovf.i8.un" { text="CEE_CONV_OVF_I8_UN" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.ovf.u1.un" { text="CEE_CONV_OVF_U1_UN" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.ovf.u2.un" { text="CEE_CONV_OVF_U2_UN" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.ovf.u4.un" { text="CEE_CONV_OVF_U4_UN" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.ovf.u8.un" { text="CEE_CONV_OVF_U8_UN" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.ovf.i.un" { text="CEE_CONV_OVF_I_UN" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.ovf.u.un" { text="CEE_CONV_OVF_U_UN" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"box" { text="CEE_BOX" ; return INSTRUCTION( INSTR_TYPE, text, yylval_param ) ; } 
"newarr" { text="CEE_NEWARR" ; return INSTRUCTION( INSTR_TYPE, text, yylval_param ) ; } 
"ldlen" { text="CEE_LDLEN" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldelema" { text="CEE_LDELEMA" ; return INSTRUCTION( INSTR_TYPE, text, yylval_param ) ; } 
"ldelem.i1" { text="CEE_LDELEM_I1" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldelem.u1" { text="CEE_LDELEM_U1" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldelem.i2" { text="CEE_LDELEM_I2" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldelem.u2" { text="CEE_LDELEM_U2" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldelem.i4" { text="CEE_LDELEM_I4" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldelem.u4" { text="CEE_LDELEM_U4" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldelem.i8" { text="CEE_LDELEM_I8" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldelem.i" { text="CEE_LDELEM_I" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldelem.r4" { text="CEE_LDELEM_R4" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldelem.r8" { text="CEE_LDELEM_R8" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldelem.ref" { text="CEE_LDELEM_REF" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"stelem.i" { text="CEE_STELEM_I" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"stelem.i1" { text="CEE_STELEM_I1" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"stelem.i2" { text="CEE_STELEM_I2" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"stelem.i4" { text="CEE_STELEM_I4" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"stelem.i8" { text="CEE_STELEM_I8" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"stelem.r4" { text="CEE_STELEM_R4" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"stelem.r8" { text="CEE_STELEM_R8" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"stelem.ref" { text="CEE_STELEM_REF" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.ovf.i1" { text="CEE_CONV_OVF_I1" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.ovf.u1" { text="CEE_CONV_OVF_U1" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.ovf.i2" { text="CEE_CONV_OVF_I2" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.ovf.u2" { text="CEE_CONV_OVF_U2" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.ovf.i4" { text="CEE_CONV_OVF_I4" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.ovf.u4" { text="CEE_CONV_OVF_U4" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.ovf.i8" { text="CEE_CONV_OVF_I8" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.ovf.u8" { text="CEE_CONV_OVF_U8" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"refanyval" { text="CEE_REFANYVAL" ; return INSTRUCTION( INSTR_TYPE, text, yylval_param ) ; } 
"ckfinite" { text="CEE_CKFINITE" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"mkrefany" { text="CEE_MKREFANY" ; return INSTRUCTION( INSTR_TYPE, text, yylval_param ) ; } 
"ldtoken" { text="CEE_LDTOKEN" ; return INSTRUCTION( INSTR_TOK, text, yylval_param ) ; } 
"conv.u2" { text="CEE_CONV_U2" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.u1" { text="CEE_CONV_U1" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.i" { text="CEE_CONV_I" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.ovf.i" { text="CEE_CONV_OVF_I" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.ovf.u" { text="CEE_CONV_OVF_U" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"add.ovf" { text="CEE_ADD_OVF" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"add.ovf.un" { text="CEE_ADD_OVF_UN" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"mul.ovf" { text="CEE_MUL_OVF" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"mul.ovf.un" { text="CEE_MUL_OVF_UN" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"sub.ovf" { text="CEE_SUB_OVF" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"sub.ovf.un" { text="CEE_SUB_OVF_UN" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"endfinally" { text="CEE_ENDFINALLY" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"leave" { text="CEE_LEAVE" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"leave.s" { text="CEE_LEAVE_S" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"stind.i" { text="CEE_STIND_I" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"conv.u" { text="CEE_CONV_U" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"prefix7" { text="CEE_PREFIX7" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"prefix6" { text="CEE_PREFIX6" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"prefix5" { text="CEE_PREFIX5" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"prefix4" { text="CEE_PREFIX4" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"prefix3" { text="CEE_PREFIX3" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"prefix2" { text="CEE_PREFIX2" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"prefix1" { text="CEE_PREFIX1" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"prefixref" { text="CEE_PREFIXREF" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"arglist" { text="CEE_ARGLIST" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ceq" { text="CEE_CEQ" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"cgt" { text="CEE_CGT" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"cgt.un" { text="CEE_CGT_UN" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"clt" { text="CEE_CLT" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"clt.un" { text="CEE_CLT_UN" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"ldftn" { text="CEE_LDFTN" ; return INSTRUCTION( INSTR_METHOD, text, yylval_param ) ; } 
"ldvirtftn" { text="CEE_LDVIRTFTN" ; return INSTRUCTION( INSTR_METHOD, text, yylval_param ) ; } 
"ldarg" { text="CEE_LDARG" ; return INSTRUCTION( INSTR_VAR, text, yylval_param ) ; } 
"ldarga" { text="CEE_LDARGA" ; return INSTRUCTION( INSTR_VAR, text, yylval_param ) ; } 
"starg" { text="CEE_STARG" ; return INSTRUCTION( INSTR_VAR, text, yylval_param ) ; } 
"ldloc" { text="CEE_LDLOC" ; return INSTRUCTION( INSTR_VAR, text, yylval_param ) ; } 
"ldloca" { text="CEE_LDLOCA" ; return INSTRUCTION( INSTR_VAR, text, yylval_param ) ; } 
"stloc" { text="CEE_STLOC" ; return INSTRUCTION( INSTR_VAR, text, yylval_param ) ; } 
"localloc" { text="CEE_LOCALLOC" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"endfilter" { text="CEE_ENDFILTER" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"unaligned." { text="CEE_UNALIGNED" ; return INSTRUCTION( INSTR_BRTARGET, text, yylval_param ) ; } 
"volatile." { text="CEE_VOLATILE" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"tail." { text="CEE_TAILCALL" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"initobj" { text="CEE_INITOBJ" ; return INSTRUCTION( INSTR_TYPE, text, yylval_param ) ; } 
"cpblk" { text="CEE_CPBLK" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"initblk" { text="CEE_INITBLK" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"rethrow" { text="CEE_RETHROW" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"sizeof" { text="CEE_SIZEOF" ; return INSTRUCTION( INSTR_TYPE, text, yylval_param ) ; } 
"refanytype" { text="CEE_REFANYTYPE" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"illegal" { text="CEE_ILLEGAL" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 
"endmac" { text="CEE_MACRO_END" ; return INSTRUCTION( INSTR_NONE, text, yylval_param ) ; } 


\".+\" { text=strndup(yytext+1,yyleng-2) ; return TERMINAL(QSTRING,text, yylval_param ); }
\'.+\' { text=strndup(yytext+1,yyleng-2) ; return TERMINAL(SQSTRING,text, yylval_param ); }

"0x"{H}+     { text=strndup(yytext,yyleng) ; return TERMINAL(INT64,text, yylval_param ); }
{H}{H}       { text=strndup(yytext,yyleng) ; return TERMINAL(HEXBYTE,text,yylval_param ); }
{D}+\.{D}+   { text=strndup(yytext,yyleng) ; return TERMINAL(FLOAT64,text, yylval_param ); }
{D}+         { text=strndup(yytext,yyleng) ; return TERMINAL(INT64,text, yylval_param ); }
{F}{C}*\.	 { buf=alloca(yyleng+1) ; strncpy(buf,yytext,yyleng) ; dottedname = 1 ; }
{F}{C}*		 { if( ! dottedname )
				{ text=strndup(yytext,yyleng) ; return TERMINAL(ID,text, yylval_param ); }
				else {
					 dottedname = 0 ;
					 int l = strlen(buf)+yyleng ;
					 text=malloc(l+1) ;
					 text=strcpy(text,buf) ;
					 strncat(text,yytext,yyleng) ;
					 return TERMINAL(DOTTEDNAME,text, yylval_param );
					 }
			 }

{P}          { return PUNCTUATION(yytext[0], yylval_param) ; }
{WS}
%%

int TERMINAL_( int n, char *str, YYSTYPE * yylval_param )
	{
	//if( str[0] != '.' )
		return TERMINAL( n, str, yylval_param ) ;
	//printf("<%s state=\"%d\"/>", &str[1], (int)yylval_param);
	//return n ;
	}


int TERMINAL( int n, char *str, YYSTYPE* yylval_param )
	{
			printf("&_%d_%d;%s", (unsigned long)yylval_param, n, str);
		/*
	switch( n )
		{
		case ID:
			printf("<ID-%d/>%s", (long)yylval_param, str);
			break ;
		case INT64:
			printf("<INT64-%d/>%s", (long)yylval_param, str);
			break ;
		case HEXBYTE:
			printf("<HEXBYTE-%d/>%s", (long)yylval_param, str);
			break ;
		case FLOAT64:
			printf("<FLOAT64-%d/>%s", (long)yylval_param, str);
			break ;
		case QSTRING:
			printf("<QSTRING-%d/>%s", (long)yylval_param, str);
			break ;
		case SQSTRING:
			printf("<SQSTRING-%d/>%s", (long)yylval_param, str);
			break ;
		case DOTTEDNAME:
			printf("<DOTTEDNAME-%d/>%s", (long)yylval_param, str);
			break ;
		default:
			printf("<_%d-%d/>%s", n, (int)yylval_param, str);
			break ;
		}
	*/
	return n ;
	}

int INSTRUCTION_( char *inst, int n, char *str, YYSTYPE* yylval_param )
	{
	int i;
	for( i = 0 ; i < ( sizeof( opcodes ) / sizeof( struct _opcodes ) ) ; i++ )
		{
		if( strcmp( opcodes[i].cn, str ) == 0 )
			{
			//printf("<%s-%d/>%s", inst, (long)yylval_param, opcodes[i].sn ) ;
			printf("<_%d-%d/>%s", n, (long)yylval_param, opcodes[i].sn ) ;
			/*
			printf("<i state=\"%d\" n=\"%d\" cn=\"%s\" sn=\"%s\" sb1=\"%s\" sb2=\"%s\" op=\"%s\" ok=\"%s\" h=\"%s\" bb=\"%s\" b=\"%s\" cf=\"%s\" />",
					(int)yylval_param,
				  	i, 
				 	opcodes[i].cn ,
					opcodes[i].sn ,
					opcodes[i].sb1 ,
					opcodes[i].sb2 ,
					opcodes[i].op ,
					opcodes[i].ok ,
					opcodes[i].h,
					opcodes[i].b1,
					opcodes[i].b2 ,
					opcodes[i].cf
					) ;
			*/
			return n ;
			}
		}
	return n ;
	}

int PUNCTUATION( int n, YYSTYPE* yylval_param )
	{
	printf("<_%d-%d/>%c", n, (unsigned long)yylval_param, n);
	return n ;
	}
int PUNCTUATION2( int n, int m )
	{
  	//printf("<p>%c%c</p>", n, m);
	return n ;
	}
