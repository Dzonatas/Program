partial class A335
{
public partial class Automatrix : Object, System.Collections.Generic.IEnumerable<Automatrix>
	{
	Program cc = null ;
	public Program C
		{
		get { if( cc != null ) return cc.Language ; else return new Program( this ) ; }
		}
	public Automatrix() : base( Stack.this_rule.RHS.Length )
		{
		main() ;
		}
	public new Argument this[int n]
		{
		get { return new Argument( ref o[n] ) ; }
		set { o[n] = value ; }
		}
	virtual protected void main() {}
	public Argument Arg0		{ get { return new Argument( ref o[0x00] ) ; } }
	public Argument Arg1		{ get { return new Argument( ref o[0x01] ) ; } }
	public Argument Arg2		{ get { return new Argument( ref o[0x02] ) ; } }
	public Argument Arg3		{ get { return new Argument( ref o[0x03] ) ; } }
	public Argument Arg4		{ get { return new Argument( ref o[0x04] ) ; } }
	public Argument Arg5		{ get { return new Argument( ref o[0x05] ) ; } }
	public Argument Arg6		{ get { return new Argument( ref o[0x06] ) ; } }
	public Argument Arg7		{ get { return new Argument( ref o[0x07] ) ; } }
	public Argument Arg8		{ get { return new Argument( ref o[0x08] ) ; } }
	public Argument Arg9		{ get { return new Argument( ref o[0x09] ) ; } }
	public Argument ArgA		{ get { return new Argument( ref o[0x0A] ) ; } }
	public Argument ArgB		{ get { return new Argument( ref o[0x0B] ) ; } }
	public Argument ArgC		{ get { return new Argument( ref o[0x0C] ) ; } }
	public Argument ArgD		{ get { return new Argument( ref o[0x0D] ) ; } }
	public Argument ArgE		{ get { return new Argument( ref o[0x0E] ) ; } }
	public Argument ArgF		{ get { return new Argument( ref o[0x0F] ) ; } }
	public object[] Argv		{ get { return o ; } }
	public int Length
		{
		get { return o.Length ; }
		}
	static char[] separators = new char[] { '/', '.' } ;
	public string[] ResolveType()
		{
		string[] s = new string[0] ;
		for( int i = 1 ; i < Argv.Length ; i++ )
			{
			if( Argv[i] is Stack.Item.Token )
				{
				string t = (string) (Stack.Item.Token)Argv[i] ;
				if( t != "[" && t != "]" )
					t = System.Text.RegularExpressions.Regex.Replace( t, "[^A-Za-z_0-9/.]", "_" ) ;
				foreach( string z in t.Split(separators) )
					{
					if( System.String.IsNullOrEmpty( z ) )
						continue ;
					System.Array.Resize( ref s, s.Length +1 ) ;
					s[s.Length-1] = z ;
					}
				}
			else
			if( Argv[i] is Stack.Item.Empty )
				{
				System.Array.Resize( ref s, s.Length +1 ) ;
				s[s.Length-1] = "$EMPTY$" ;
				}
			else
			if( Argv[i] == null )
				{
				System.Array.Resize( ref s, s.Length +1 ) ;
				s[s.Length-1] = "$NULL$" ;
				}
			else
			if( Argv[i] is Automatrix )
				{
				string[] ts = ( Argv[i] as Automatrix ).ResolveType() ;
				System.Array.Resize( ref s, s.Length + ts.Length ) ;
				ts.CopyTo( s, s.Length - ts.Length ) ;
				}
			else
				throw new System.NotImplementedException( "Unresolved type." ) ;
			}
		return s ;
		}
	public override string ToString()
		{
		return "[Automatrix] " + this.GetType().FullName ;
		}
	virtual protected void render() {}
	static public void Render( Stack.IStart start )
		{
		foreach( Automatrix a in (Automatrix)start )
			a.render() ;
		}
	virtual protected void prerender() {}
	static public void Prerender( Stack.IStart start )
		{
		foreach( Automatrix a in (Automatrix)start )
			a.prerender() ;
		}
	struct item
		{
		public Automatrix automatrix ;
		public int        index ;
		}
	public System.Collections.Generic.IEnumerator<Automatrix> GetEnumerator()
		{
		var stack = new System.Collections.Generic.Stack<item>() ;
		item i = new item() { automatrix = this , index = 0 } ;
		while( i.automatrix != null )
			{
			for( ++i.index ; i.index < i.automatrix.Argv.Length ; i.index++ )
				{
				if( i.automatrix.Argv[i.index] is Stack.Item.Token )
					{
					}
				else
				if( i.automatrix.Argv[i.index] is Stack.Item.Empty )
					{
					}
				else
				if( i.automatrix.Argv[i.index] == null )
					{
					}
				else
				if( i.automatrix.Argv[i.index] is Automatrix )
					{
					stack.Push(i) ;
					i.automatrix = i.automatrix.Argv[i.index] as Automatrix ;
					i.index = 0 ;
					//yield return i.automatrix ;
					}
				else
					throw new System.NotImplementedException( "Unresolved type." ) ;
				}
			yield return i.automatrix.Argv[0] as Automatrix ;
			if( stack.Count == 0 )
				yield break ;
			i = stack.Pop() ;
			}
		}
	System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
		return GetEnumerator() ;
		}
	}
}

