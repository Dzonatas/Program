partial class A335
{
public partial class SigArgs0 : Automatrix
	{
	SigArg list ;
	public partial class   sigArgs0_sigArgs1
		: SigArgs0
		{
		protected override void main()
			{
			list = SigArg.List ;
			}
		}
	public int Count()
		{
		int i = 0 ;
		for( SigArg s = list ; s is SigArg ; s = s.Next )
			i++ ;
		return i ;
		}
	public string Types()
		{
		string i = null ;
		for( SigArg s = list ; s is SigArg ; s = s.Next )
			{
			i += "$" + (Type)s ;
			}
		return i ;
		}
	public void ForEach( System.Action<SigArg> action )
		{
		for( SigArg s = list ; s is SigArg ; s = s.Next )
			action( s ) ;
		}
	}

public partial class SigArg : Automatrix
	{
	static SigArg current = null ;
	SigArg previous ;
	SigArg next ;
	Type   type ;
	string _ID ;
	static public implicit operator Type( SigArg a ) { return a.type ; }
	static public implicit operator string( SigArg a ) { return a._ID ; }
	protected Argument ID
		{
		set { _ID = value.Token ; }
		}
	protected void Enlist()
		{
		previous = current ;
		current = this ;
		}
	static public SigArg List
		{
		get {
			SigArg i ;
			for( i = current ; i is SigArg ; i = i.previous )
				{
				if( i.previous == null )
					{
					current = null ;
					return i ;
					}
				else
					i.previous.next = i ;
				}
			return i ;
			}
		}
	public SigArg Next
		{
		get { return next ; }
		}
	public SigArg Previous
		{
		get { return previous ; }
		}
	public partial class   sigArg_paramAttr_type
		: SigArg	{
		protected override void main()
			{
			type = Argv[2] as Type ;
			Enlist() ;
			}
		}
	public partial class   sigArg_paramAttr_type_id
		: SigArg {
		protected override void main()
			{
			type = Argv[2] as Type ;
			ID   = Arg3 ;
			Enlist() ;
			}
		}
	public partial class   sigArgs1_sigArgs1_____sigArg
		: Automatrix	{}
	public partial class   sigArgs1_sigArg
		: Automatrix	{}
	}
}
