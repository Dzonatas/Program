//namespace C {
public partial class C699 {
public struct Stack {
static public c Index(int i)
	{
	return new c("stack"+'['+i+']') ;
	}
static public c Pointer(int i)
	{
	return new c("stack"+'+'+i+' ') ;
	}
}
public struct Goto {
static public c Label(string id)
	{
	return new c(KeyedWord.Goto+' '+id) ;
	}
}
static readonly c _string = C.Struct(new c("_string")) ;
static public   c String {
	get { return _string ; }
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
	if( i == 1 )
		return C.Struct(new c(_obj[i-1,i-1]+_obj[i,i])) ;
	return C.Struct(new c(_obj[i,i])) ;
	}
public static string[,] _IDE = null ;
}//}
