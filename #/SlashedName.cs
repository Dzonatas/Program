partial class A335
{
public partial class SlashedName : Automatrix
	{
	static public implicit operator string( SlashedName n ) { return n.symbol ; }
	protected virtual string symbol { get { throw new System.NotImplementedException() ; } }
	}

public partial class   slashedName_name1
	: SlashedName {
	protected override string symbol
		{
		get { return Arg1.Token.Replace('.','$').Replace('`','_') ; }
		}
	}

public partial class   slashedName_slashedName_____name1
	: SlashedName {
	protected override string symbol
		{
		get { return (Argv[1] as SlashedName)+'_'+Arg3.Token.Replace('.','$').Replace('`','_') ; }
		}
	}
}