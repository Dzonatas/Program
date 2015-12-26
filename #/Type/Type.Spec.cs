partial class A335
{
public partial class Type : Automatrix
	{
	public partial class Spec : Type
		{
		protected override C_Type c_type { get { return C_Type.Acquire( ResolveTypeSpec() ) ; } }
		public string[] ResolveTypeSpec()
			{
			string[] s = ResolveType() ;
			int i = 0 ;
			if( s[i] == "class" )
				i++ ;
			else
			if( s[i] == "valuetype" )
				i++ ;
			if( s[i] == "[" )
				i += 3 ;
			if( i == s.Length-1 )
				switch( s[i] )
					{
					case "object" : return new string[] { "System", "Object" } ;
					case "string" : return new string[] { "System", "String" } ;
					}
			string[] r = new string[s.Length-i] ;
			for( int x = 0 ; x < r.Length ; x++ )
				r[x] = s[x+i] ;
			return r ;
			}
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
			#if DEBUG
			string[] b = base.ResolveTypeSpec() ;
			#endif
			switch( s )
				{
				case "object":
				case "valuetype__corlib_System$Object": return new C699.c("System$Object") ;
				case "class__mscorlib_System$Console":
				case "class__corlib_System$Console": return new C699.c("System$Console") ;
				case "string": return new C699.c("System$String") ;
				}
			#if DEBUG
			if( s.IndexOf("corlib") > -1 )
				b = null ;
			#endif
			if( s.StartsWith("class_") ) return new C699.c( s.Substring(6) ) ;
			if( s.StartsWith("valuetype_") ) return new C699.c( s.Substring(10) ) ;
			throw new System.NotImplementedException() ;
			}
		}
	protected override C_Type c_type { get { return C_Type.Acquire( c ) ; } }
	}

public partial class   typeSpec_className
	: Type.Spec {
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

