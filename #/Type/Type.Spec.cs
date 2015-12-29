partial class A335
{
public partial class Type : Automatrix
	{
	public partial class Spec : Type
		{
		public Type GenericArgument(int n)
			{
			if( ! ( this is typeSpec_type ) )
				throw new System.NotImplementedException() ;
			var t = (type_type_____genArgs____) Argv[1] ;
			return (t.Argv[3] as GenArgs).Index(n) ;
			}
		}
	}

public partial class   typeSpec_type
	: Type.Spec {
	protected override C699.c c
		{
		get	{
			string s = (string) (Argv[1] as Type) ;
			if( s.StartsWith("_mscorlib_") )
				s = s.Substring(10) ;
			else
			if( s.StartsWith("_corlib_") )
				s = s.Substring(8) ;
			//else
			//if( s.StartsWith("_System$Core_") )
			//	s = s.Substring(13) ;
			switch( s )
				{
				case "object":
					return new C699.c("System$Object") ;
				case "console":
					return new C699.c("System$Console") ;
				case "string":
					return new C699.c("System$String") ;
				}
			return new C699.c(s) ;
			//throw new System.NotImplementedException() ;
			}
		}
	protected override C_Type c_type { get { return C_Type.Acquire( c ) ; } }
	}

public partial class   typeSpec_className
	: Type.Spec {
	protected override string symbol
		{
		get	{
			var className = Argv[1] as Class.Name ;
			return className ;
			}
		}
	protected override C_Type c_type
		{
		get { return C_Type.Acquire( c ) ; }
		}
	protected override C699.c c
		{
		get {
			var className = Argv[1] as Class.Name ;
			switch( className )
				{
				case "[mscorlib]System.String":
					throw new System.NotImplementedException() ;
				case "_mscorlib_System_String":
				case "_mscorlib_System$String":
					return C699.String.p ;
				default:
					return C699.C.Struct( new C699.c(className) ) ;
				}
			}
		}
	}
}

