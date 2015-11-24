using System.Diagnostics ;

partial class A335
{
public class Argument
	{
	object arg ;
	public Argument( ref object o )
		{
		#if DEBUG_ARG
		Debug.WriteLine( "<A Arg/> " + o.ToString() ) ;
		#endif
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
	static public explicit operator Automatrix( Argument a )
		{
		return a.arg as Automatrix ;
		}
	}
}