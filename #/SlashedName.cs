partial class A335
{
public partial class SlashedName : Automatrix
	{
	static public implicit operator string( SlashedName n ) { return n.name ; }
	protected virtual string name { get { throw new System.NotImplementedException() ; } }
	}

public partial class   slashedName_name1
	: SlashedName {
	protected override string name
		{
		get { return Arg1.Token ; }
		}
	}

public partial class   slashedName_slashedName_____name1
	: SlashedName {
	protected override string name
		{
		get { return (Argv[1] as SlashedName)+'/'+Arg3.Token ; }
		}
	}
}