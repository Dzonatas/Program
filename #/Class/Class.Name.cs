partial class A335
{
public partial class Class : Automatrix
	{
	public partial class Name : Class
		{
		static public implicit operator string( Name n ) { return n.fullName ; }
		protected virtual string fullName { get { throw new System.NotImplementedException() ; } }
		}
	}

public partial class   className_____name1_____slashedName
	: Class.Name {
	protected override string fullName
		{
		get { return "["+Arg2.Token+"]"+(Argv[4] as SlashedName) ; }
		}
	}

public partial class   className_slashedName
	: Class.Name {
	protected override string fullName
		{
		get { return Argv[1] as SlashedName ; }
		}
	}
}
