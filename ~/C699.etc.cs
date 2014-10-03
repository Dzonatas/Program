//namespace C {
public partial class C699 {
public struct Stack {
static public c Offset(int i)
	{
	return new c("stack"+'['+i+']') ;
	}
}
public struct Goto {
static public c Label(string id)
	{
	return new c(KeyedWord.Goto+' '+id) ;
	}
}
static public c String {
	get { return new c(KeyedWord.Struct+' '+"_string") ; }
}
/* "actions" and "functions"
public struct _str {...}
*/
private static string[,] _obj = {{"_object"}/*,...{"_hurd"}*/} ;
static public c Object(int i)
	{
	return new c(KeyedWord.Struct+' '+_obj[i,i]) ;
	}
public static string[,] _IDE = null ;
}//}
