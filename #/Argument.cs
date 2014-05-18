using System.Text.RegularExpressions ;
using System.Diagnostics ;

public partial class A335
{
class Argument
	{
	object arg ;
	public Argument( ref object o )
		{
		Debug.WriteLine( "<A Arg/> " + o.ToString() ) ;
		arg = o ;
		}
	public object this[int n]
		{
		get {
			if( arg is object[] )
				return ((object[])arg)[n] ;
			if( arg is Object )
				return ((Object)arg)[n] ;
			if( arg is Stack.Item.Token )
				return ((Object)arg)[n] ;
			return null ;
			}
		}
	public object[] Args		{ get { return arg as object[] ; } }
	public string Token
		{
		get {
			if( arg is Stack.Item.Token )
				return (arg as Stack.Item.Token)._Token._ ;
			if( arg is Automatrix )
				{
				Automatrix a = arg as Automatrix ;
				for( int i = 1 ; i < a.Length ; i++ )
					{
					if( a.Args[i] is Stack.Item.Token )
						return (a.Args[i] as Stack.Item.Token)._Token._ ;
					if( a.Args[i] is Automatrix )
						return new Argument( ref a.Args[i] ).Token ;
					}
				}
			throw new System.NotImplementedException( "Unresolved casts to dotted names." ) ;
			}
		}
	public string ResolveType()
		{
		string s = "" ;
		if( arg is Stack.Item.Token )
			{
			string t = (string) (Stack.Item.Token)arg ;
			t = Regex.Replace( t, "[^A-Za-z_0-9/]", "_" ).Replace( "/", "$" ) ;
			return t ;
			}
		if( arg is Automatrix )
			{
			return (arg as Automatrix).ResolveType() ;
			}
		for( int i = 1 ; i < Args.Length ; i++ )
			{
			if( Args[i] is Stack.Item.Token )
				{
				string t = (string) (Stack.Item.Token)Args[i] ;
				t = Regex.Replace( t, "[^A-Za-z_0-9/]", "_" ).Replace( "/", "$" ) ;
				if( s.EndsWith("$") || t == "$" )
					s += t ;
				else
					s += ( i == 1 ? "" : "_" ) + t ;
				}
			else
			if( Args[i] is Automatrix )
				s += ( ( i == 1 || s.EndsWith("$") || s.EndsWith("__") ) ? "" : "_" )
					+ ( Args[i] as Automatrix ).ResolveType() ;
			else
				throw new System.NotImplementedException( "Unresolved type." ) ;
			}
		return s ;
		}
	public string ResolveTypeSpec()
		{
		string s = (string) ResolveType() ;
		if( s.StartsWith( "class_" ) )
			s = s.Substring( 6 ) ;
		else
		if( s.StartsWith( "valuetype_" ) )
			s = s.Substring( 10 ) ;
		if( s.StartsWith( "__mscorlib__" ) )
			return /*"BCL$$" +*/ s.Substring( 12 ) ;
		else
		if( s.StartsWith( "__corlib__" ) )
			return /*"BCL$$" +*/ s.Substring( 10 ) ;
		switch( s )
			{
			case "object" : return /*"BCL$$"+*/"System_Object" ;
			case "string" : return /*"BCL$$"+*/"System_String" ;
			}
		return s ;
		}
	public bool ResolvedMethAttrContainsVirtual
		{
		get {
			if( arg is methAttr_methAttr__virtual_ )
				return true ;
			if( arg is Automatrix )
				return ( arg as Automatrix ).ResolvedMethAttrContainsVirtual ;
			if( arg is Stack.Item.Token )
				{
				string t = (string) (Stack.Item.Token) arg ;
				if( "virtual" == (string) t )
					return true ;
				return false ;
				}
			if( arg is Stack.Item.Empty )
				return false ;
			throw new System.NotImplementedException( "Unresolved methAttr." ) ;
			}
		}
	}
}