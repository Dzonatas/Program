partial class C699
{
static protected int stack_offset ;
static protected int stack_down ;
public struct Stack
	{
	static public int Offset
		{
		get { return stack_offset - stack_down ; }
		}
	static public c Element
		{
		get { return new c("stack"+'['+Offset+']') ; }
		}
	static public c Index(int i)
		{
		return new c("stack"+'['+i+']') ;
		}
	static public c Assign(c value)
		{
		return Element.Equate("(void*) ("+value+")" ) ;
		}
	static public c Pointer
		{
		get { return new c("stack"+'+'+Offset+' ') ; }
		}
	static public c Deref(c _struct)
		{
		//if( _struct == KeyedWord.Int )
		if( _struct == KeyedWord.Long+' ' )
			return new c("("+_struct+")"+Element) ;
		return new c("*("+_struct+" *)"+Element) ;
		}
	static public c CastIndex(string _struct)
		{
		return new c("("+_struct+" *)"+Element) ;
		}
	static public c Array(string i, string _struct)
		{
		return new c("(("+_struct+" **)"+Element+")["+i+"]") ;
		}
	}
}
