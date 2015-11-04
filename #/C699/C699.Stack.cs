partial class C699
{
public struct Stack
	{
	static public c Index(int i)
		{
		return new c("stack"+'['+i+']') ;
		}
	static public c Assign(int i, C699.c value)
		{
		return Index(i).Equate("(void*) ("+value+")" ) ;
		}
	static public c Pointer(int i)
		{
		return new c("stack"+'+'+i+' ') ;
		}
	static public c Deref(int i, C699.c _struct)
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
}
