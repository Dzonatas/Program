partial class A335
{
public partial class ExtendsClause : Automatrix
	{
	static public implicit operator string( ExtendsClause n ) { return n.symbol ; }
	protected virtual string symbol { get { throw new System.NotImplementedException() ; } }
	static public implicit operator C699.c( ExtendsClause n ) { return n.c ; }
	protected virtual C699.c c { get { throw new System.NotImplementedException() ; } }
	static public implicit operator C_Type( ExtendsClause n ) { return n.c_type ; }
	protected virtual C_Type c_type { get { throw new System.NotImplementedException() ; } }
	}

public partial class   extendsClause__extends__className
	: ExtendsClause {
	protected override string symbol
		{
		get { return (string) c ; }
		}
	protected override C_Type c_type
		{
		get { return C_Type.Acquire( c ) ; }
		}
	protected override C699.c c
		{
		get {
			var className = Argv[2] as Class.Name ;
			switch( className )
				{
				case "_mscorlib_System$ValueType":
				case "_mscorlib_System_ValueType":
					return new C699.c("struct") ;
				case "_mscorlib_System_Object":
					return C699.Object(0) ;
				default :
					return new C699.c(className) ;
				}
			}
		}
	}
}

