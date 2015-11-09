partial class A335
{
static object[] freeset = new object[0] ;

public partial class CallConv : Automatrix
	{
	static CallConv current = null ;
	CallConv next ;
	protected override void main()
		{
		next = current ;
		current = this ;
		}
	public CallConv List
		{
		get { current = null ; return this ; }
		}
	public bool Instance
		{
		get {
			for( CallConv i = this ; i is CallConv ; i = i.next )
				if( i is callConv__instance__callConv )
					return true ;
			return false ;
			}
		}
	public partial class   callConv__instance__callConv
		: CallConv	{}

	public partial class   callConv_callKind
		: CallConv {}
	}

public partial class   compQstring_QSTRING
	: Automatrix	{
	static public explicit operator string(compQstring_QSTRING qs )
		{
		return qs.Arg1.Token ;
		}
	}

public partial class   _accept_START__end
	: Automatrix	{
	protected override void main()
		{
		if( o[1] != null && o[2] != null )
			return ;
		log( "[OOP!] _accept_START__end != {START,.end}" ) ;
		}
	}

public partial class   customType_callConv_type_typeSpec________ctor______sigArgs0____
	: Automatrix {}

}


namespace org.com.net.edu.mil.us
	{
	//(([zero-copy|copy-paste]-buffer))-to-the-wall.
	}