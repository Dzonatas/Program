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
					if( a.Argv[i] is Stack.Item.Token )
						return (a.Argv[i] as Stack.Item.Token)._Token._ ;
					if( a.Argv[i] is Automatrix )
						return new Argument( ref a.Argv[i] ).Token ;
					}
				}
			throw new System.NotImplementedException( "Unresolved casts to dotted names." ) ;
			}
		}
	static char[] separators = new char[] { '/', '.' } ;
	public string[] ResolveType()
		{
		if( arg is Stack.Item.Token )
			{
			string t = (string) (Stack.Item.Token)arg ;
			t = Regex.Replace( t, "[^A-Za-z_0-9/.]", "_" ) ;
			return t.Split( separators ) ;
			}
		if( arg is Automatrix )
			{
			return (arg as Automatrix).ResolveType() ;
			}
		string[] s = new string[0] ;
		for( int i = 1 ; i < Args.Length ; i++ )
			{
			if( Args[i] is Stack.Item.Token )
				{
				string t = (string) (Stack.Item.Token)Args[i] ;
				if( t != "[" && t != "]" )
					t = Regex.Replace( t, "[^A-Za-z_0-9/.]", "_" ) ;
				foreach( string z in t.Split(separators) )
					{
					if( System.String.IsNullOrEmpty( z ) )
						continue ;
					System.Array.Resize( ref s, s.Length +1 ) ;
					s[s.Length-1] = z ;
					}
				}
			else
			if( Args[i] is Automatrix )
				{
				string[] ts = ( Args[i] as Automatrix ).ResolveType() ;
				System.Array.Resize( ref s, s.Length + ts.Length ) ;
				ts.CopyTo( s, s.Length - ts.Length ) ;
				}
			else
				throw new System.NotImplementedException( "Unresolved type." ) ;
			}
		return s ;
		}
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
	static public explicit operator Automatrix( Argument a )
		{
		return a.arg as Automatrix ;
		}
	}
}