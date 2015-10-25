//namespace C {
public partial class C699 {
public struct Stack {
static public c Index(int i)
	{
	return new c("stack"+'['+i+']') ;
	}
static public c Assign(int i, C699.c value)
	{
	return Index(i).Equate("(void*) "+value) ;
	}
static public c Pointer(int i)
	{
	return new c("stack"+'+'+i+' ') ;
	}
static public c Deref(int i, string _struct)
	{
	//if( _struct == KeyedWord.Int )
	if( _struct == KeyedWord.Long+' ' )
		return new c("("+_struct+")stack["+i+']') ;
	return new c("*("+_struct+" *)stack["+i+']') ;
	}
static public c CastIndex(int i, string _struct)
	{
	return new c("("+_struct+" *)stack["+i+']') ;
	}
static public c Array(int i, string _i, string _struct)
	{
	return new c("(("+_struct+" **)stack["+i+"])["+_i+"]") ;
	}
}
static readonly c _string = C.Struct(new c("_string")) ;
static public   c String {
	get { return _string ; }
}
static public c SizeOf( C699.c type, C699.c items )
	{
	return new c( "sizeof("+type+" *)*"+items ) ;
	}
static public c Array(C699.c c, string _i, string _struct)
	{
	return new c("(("+_struct+" **)"+c+")["+_i+"]") ;
	}
/* "actions" and "functions"
public struct _str {...}
*/
private static string[,] _obj =
	{
	{ "_object", null },
	{ null, "*" }
	} ;
static public c Object(int i)
	{
	c c ;
	if( i == 1 )
		{
		c = C.Struct(new c(_obj[i-1,i-1]+_obj[i,i])) ;
		c.Bits = Bit.Object ;
		return c ;
		}
	c = C.Struct(new c(_obj[i,i])) ;
	c.Bits = Bit.Object ;
	return c ;
	}
public static string[,] _IDE = null ;
//	[System.Runtime.InteropServices.DllImport( LIBC_so )]
//public extern  static int                          write( int fd, string, string.Length ) ;
public         static c                             Write( int fd, string _string, string _length )
	{
	return C.Function("write",new c(fd.ToString()+','+_string+','+_length)) ;
	}
public         static c                             Strncpy( string o, string _string, string _length )
	{
	return C.Function("strncpy",new c(o+','+_string+','+_length)) ;
	}
public         static c                             Alloca( string expr )
	{
	return C.Function("alloca",new c(expr)) ;
	}
}//}
