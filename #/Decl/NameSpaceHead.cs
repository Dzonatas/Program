partial class A335
{
public partial class NameSpaceHead : Automatrix
	{
	protected NameSpaceHead outer ;
	public NameSpaceHead _NameSpaceHead
		{
		set { outer = value ; }
		}
	static public implicit operator string( NameSpaceHead n )
		{
		return n.Arg2.Token.Replace('.','$') ;
		}
	}

public partial class nameSpaceHead___namespace__name1 : NameSpaceHead
	{
	static public implicit operator string( nameSpaceHead___namespace__name1 n )
		{
		return n.Arg2.Token.Replace('.','$') ;
		}
	}
}
