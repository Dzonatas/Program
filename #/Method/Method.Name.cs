partial class A335
{
public partial class Method : Automatrix
	{
	public partial class Name : Automatrix
		{
		protected Method.Head head ;
		static public implicit operator string( Name n ) { return n.symbol ; }
		protected virtual string symbol { get { return null ; } }
		public Head MethodHead
			{
			set { head = value ; }
			}
		}
	}

public partial class   methodName___ctor_
	: Method.Name	{
	protected override string symbol { get { return "_ctor" ; } }
	}

public partial class   methodName___cctor_
	: Method.Name {
	protected override string symbol { get { return "_cctor" ; } }
	protected override void prerender()
		{
		head.ClassDecl.Node.Head.Cctor = head ;
		}
	}

public partial class   methodName_name1
	: Method.Name {
	protected override string symbol { get { return "$" + Arg1.Token ; } }
	}
}
