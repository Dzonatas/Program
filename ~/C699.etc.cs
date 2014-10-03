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
public struct _obj {...}
*/
}//}
