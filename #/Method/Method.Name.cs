partial class A335
{
public partial class Method : Automatrix
	{
	public partial class Name : Automatrix
		{
		protected C_Symbol     name ;
		protected Method.Head  head ;
		static public implicit operator string( Name n )
			{
			return n.name ;
			}
		static public implicit operator C_Symbol( Name n )
			{
			return n.name ;
			}
		public Head MethodHead
			{
			set { head = value ; }
			}
		}
	}

public partial class   methodName___ctor_
	: Method.Name	{
	static C_Symbol symbol = C_Symbol.Acquire( "_ctor" ) ;
	protected override void main()
		{
		name = symbol ;
		}
	}

public partial class   methodName___cctor_
	: Method.Name {
	static C_Symbol symbol = C_Symbol.Acquire( "_cctor" ) ;
	protected override void main()
		{
		name = symbol ;
		}
	protected override void prerender()
		{
		head.ClassDecl.Node.Head.Cctor = head ;
		}
	}

public partial class   methodName_name1
	: Method.Name {
	protected override void main()
		{
		name = C_Symbol.Acquire( "$" + Arg1.Token ) ;
		}
	}
}
