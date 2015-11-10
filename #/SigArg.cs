partial class A335
{
public partial class SigArgs0 : Automatrix
	{
	public partial class   sigArgs0_sigArgs1
		: SigArgs0	{}
	public void ForEach( System.Action<SigArg> action )
		{
		foreach( Automatrix a in Argv[1] as Automatrix )
			if( a is SigArg )
				action( a as SigArg ) ;
		}
	public int Count()
		{
		int i = 0 ;
		ForEach( (s) => i++ ) ;
		return i ;
		}
	public string Types()
		{
		string i = null ;
		ForEach( (s) => i += "$" + (Type)s ) ;
		return i ;
		}
	}

public partial class SigArg : Automatrix
	{
	Type   type ;
	string id ;
	static public implicit operator Type( SigArg a ) { return a.type ; }
	static public implicit operator string( SigArg a ) { return a.id ; }
	public partial class   sigArg_paramAttr_type
		: SigArg	{
		protected override void main()
			{
			type = Argv[2] as Type ;
			}
		}
	public partial class   sigArg_paramAttr_type_id
		: SigArg {
		protected override void main()
			{
			type = Argv[2] as Type ;
			id   = Arg3.Token ;
			}
		}
	}

public partial class   sigArgs1_sigArgs1_____sigArg
	: Automatrix	{}

public partial class   sigArgs1_sigArg
	: Automatrix	{}
}
