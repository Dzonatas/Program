partial class A335
{
public partial class CallConv : Automatrix
	{
	public bool Instance
		{
		get {
			foreach( Automatrix a in this )
				if( a is callConv__instance__callConv )
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

