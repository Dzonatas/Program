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
		public virtual C699.c newarr(C699.c length) { throw new System.NotImplementedException() ; }
		}
	}

public partial class   typeSpec_type
	: Type.Spec {}

public partial class   typeSpec_className
	: Type.Spec {
	protected override C_Type c_type
		{
		get {
			var className = Argv[1] as Class.Name ;
			switch( className )
				{
				case "[mscorlib]System.String":
					return C_Type.Acquire( C699.String ) ;
				}
			throw new System.NotImplementedException() ;
			}
		}
	public override C699.c newarr(C699.c length)
		{
		var className = Argv[1] as Class.Name ;
		switch( className )
			{
			case "[mscorlib]System.String":
				return C699.Malloc( C699.SizeOf( C699.String, length ) ) ;
			}
		throw new System.NotImplementedException() ;
		}
	}
}

