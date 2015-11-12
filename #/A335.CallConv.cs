partial class A335
{
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
	}

public partial class   callConv__instance__callConv
	: CallConv	{}

public partial class   callConv_callKind
	: CallConv {}
}

