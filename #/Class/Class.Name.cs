partial class A335
{
public partial class Class : Automatrix
	{
	public partial class Name : Class
		{
		static public implicit operator string( Name n ) { return n.symbol ; }
		protected virtual string symbol { get { throw new System.NotImplementedException() ; } }
		}
	public partial class Names : Class {}
	}

public partial class   className_____name1_____slashedName
	: Class.Name {
	protected override string symbol
		{
		get { return "_"+Arg2.Token.Replace('.','$')+'_'+(Argv[4] as SlashedName) ; }
		}
	}

public partial class   className_slashedName
	: Class.Name {
	protected override string symbol
		{
		get { return Argv[1] as SlashedName ; }
		}
	}

public partial class   classNames_className
	: Class.Names {}
}
