public partial class A335
{
public partial class Method : Automatrix
	{
	public partial class Name : Automatrix
		{
		static public implicit operator string( Name n ) { return n.symbol ; }
		protected virtual string symbol { get { return null ; } }
		}
	}

public partial class   methodName___ctor_
	: Method.Name	{
	protected override string symbol { get { return "_ctor" ; } }
	}

public partial class   methodName___cctor_
	: Method.Name {
	protected override string symbol { get { return "_cctor" ; } }
	}

public partial class   methodName_name1
	: Method.Name {
	protected override string symbol { get { return "$" + Arg1.Token ; } }
	}
}
