partial class A335
{
public partial class Stack
	{
	static global::Item[] stack = new global::Item[0] ;
	public partial class Item : global::Item
		{
		public IRule Rule ;
		public Item()
			{
			this.Rule = this_rule ;
			}
		public partial class Token : Item
			{
			//public planet  State ;
			public Tokenset.Token _Token ;
			public Token( /*planet _0,*/ Tokenset.Token _1 ) : base()
				{
				//State = _0 ;
				_Token = _1 ;
				}
			static public explicit operator string( Token t )
				{
				return t._Token._ ;
				}
			public override string ToString()
				{
				return _Token.ToString() ;
				}
			}
		public partial class Empty : Item
			{
			public string Assertive ;
			public Empty( string assertive ) : base()
				{
				log( "[empty] " + assertive ) ;
				Assertive = assertive ;
				}
			public override string ToString()
				{
				return "[Empty] " + Assertive ;
				}
			}
		}
	static public IStart FindIStart()
		{
		for( int i = stack.Length ; i-- > 0 ; )
			foreach( System.Type t in stack[i].GetType().GetInterfaces() )
				if( t == typeof(IStart) )
					return (IStart)stack[i] ;
		return null ;
		}
	#if DEBUG_DUMP
	static void writeline()
		{
		if( args.Length == 0 )
			return ;
		switch( X.Auto["A"] )
			{
			#if DEBUG
			case "{.assembly":
				b_list += C.Array.assembly.argv(args).asm + "; \n" ;
				break ;
			#endif
			default:
				X.Auto["argv"] = ", "+string.Join(", ", args)+", 0 }" ;
				b_list += Xo_t.put("fasm_c" ) ;
				break ;
			}
		args = new string[0] ;
		}
	static void write( string s )
		{
		Array.Resize( ref args, args.Length+1 ) ;
		args[args.Length-1] = '"'+s+'"' ;
		}
	static void write_( string s )
		{
		if( args.Length == 0 )
			return ;
		Array.Resize( ref args, args.Length+1 ) ;
		args[args.Length-1] = s ;
		}
	static string[] args = new string[0] ;
	static public void dump( Automatrix a )
		{
		if( args.Length == 0 )
			X.Auto["A"] = "{"+a.Arg0.Token ;
		for( int i = 1 ; i < a.Argv.Length ; i++ )
			{
			if( a.Argv[i] is Stack.Item.Token )
				{
				string t = (string) (Stack.Item.Token)a.Argv[i] ;
				if( t.Length > 0 && t[0] == '.' && t != ".ctor" && t != ".cctor" )
					{
					writeline() ;
					if( args.Length == 0 )
						X.Auto["A"] = "{"+a.Arg0.Token ;
					}
				write( t ) ;
				if( t.Length > 0 && t[0] == '{' )
					writeline() ;
				}
			else
			if( a.Argv[i] is Automatrix )
				dump( a.Argv[i] as Automatrix ) ;
			else
			if( a.Argv[i] is Stack.Item.Empty )
				write_( "/*empty*/0" ) ;
			else
			if( a.Argv[i] == null )
				write_( "/*null*/0" ) ;
			else
				System.Console.Write( "["+a.Argv[i].GetType()+"]" ) ;
			}
		}
	static public void Dump()
		{
		X.Auto["A"] = "" ;
		foreach( global::Item o in stack )
			{
			if( o is Stack.Item.Token )
				{
				string t = (string) (Stack.Item.Token)o ;
				if( t == "$end" )
					continue ;
				System.Console.WriteLine( "[stack.t] "+ t ) ;
				}
			else
			if( o is Automatrix )
				dump( o as Automatrix ) ;
			else
				System.Console.WriteLine( "[stack] "+o.ToString() ) ;
			}
		writeline() ;
		}
	#endif
	static public void Push( Item o )
		{
		System.Array.Resize( ref stack, stack.Length+1 ) ;
		stack[stack.Length-1] = o ;
		}
	static public void Push( object[] o )
		{
		System.Array.Resize( ref stack, stack.Length+1 ) ;
		stack[stack.Length-1] = (Object) o[0] ;
		}
	static private object stack_pop()
		{
		object o = stack[stack.Length-1] ;
		System.Array.Resize( ref stack, stack.Length-1 ) ;
		string s ;
		if( o is object[] )
			{
			s = "{ " ;
			foreach( object i in (object[])o )
				s += ( i == null ? "null" : i ).ToString() + " , ";
			}
		else
			s = o.ToString() ;
		log( "[pop] " + s ) ;
		return o ;
		}
	static private object peak
		{
		get { return stack.Length > 0 ? stack[stack.Length-1] : null ; }
		}
	static private bool peakIsNull
		{
		get { return peak == null ; }
		}
	static private bool peakIsItemToken
		{
		get { return peak is Item.Token ; }
		}
	static private bool peakIsObject
		{
		get { return peak is Object ; }
		}
	static private bool peakIsArray
		{
		get { return peak is object[] ; }
		}
	static public object[] Pop()
		{
		throw new System.NotImplementedException() ;
		}
	static public void Pop( ref object[] o )
		{
		for( int i = o.Length - 1 ; i > 0 ; i-- )
			{
			if( peakIsNull )
				o[i] = null ;
			else
			if( peakIsItemToken )
				{
				Item.Token t = peak as Item.Token ;
				string rhs = this_rule.RHS[i-1] ;
				/*
				if( t._Token.c == 0 )
					o[i] = new Item.Empty( "rhs==" + rhs + "  stack==" + t._Token._ ) ;
				else
				*/
				if( rhs[0] == '\'' )
					{
					if(	rhs[1] == t._Token._[0] )
						o[i] = stack_pop() as Stack.Item.Token ;
					else
						o[i] = new Item.Empty( "rhs==" + rhs + "  stack==" + t._Token._ ) ;
					}
				else
				if( rhs[0] == '"' )
					{
					if( rhs == '"'+t._Token._+'"' )
						o[i] = stack_pop() as Stack.Item.Token ;
					else
						o[i] = new Item.Empty( "rhs==" + rhs + "  stack==" + t._Token._ ) ;
					}
				else
				if( rhs[0] == '$' )
					{
					if( rhs == t._Token._ )
						o[i] = stack_pop() as Stack.Item.Token ;
					else
						o[i] = new Item.Empty( "rhs==" + rhs + "  stack==" + t._Token._ ) ;
					}
				else
					{
					if( rhs == rhs.ToUpper() )
						o[i] = stack_pop() as Stack.Item.Token ;
					else
						o[i] = new Item.Empty( "rhs==" + rhs + "  stack==" + t._Token._ + " (not UPPER)" ) ;
					}
				}
			else
			if( peakIsObject )
				{
				Object p = peak as Object ;
				string lhs = p.Rule.LHS ;
				string rhs = this_rule.RHS[i-1] ;
				if( lhs == rhs )
					o[i] = stack_pop() as Object ;
				else
					{
					log( "[Stack.Pop] lhs="+lhs+"   rhs="+rhs ) ;
					o[i] = new Item.Empty( "lhs="+lhs+"   rhs="+rhs ) ;
					}
				}
			else
			if( peakIsArray )
				{
				object[] p = peak as object[] ;
				string lhs = ((IRule)p[0]).LHS ;
				string rhs = this_rule.RHS[i-1] ;
				if( lhs == rhs )
					o[i] = new Object( stack_pop() as object[] ) ;
				else
					{
					log( "[Stack.Pop] lhs="+lhs+"   rhs="+rhs ) ;
					o[i] = new Item.Empty( "lhs="+lhs+"   rhs="+rhs ) ;
					}
				}
			else
				throw new System.NotImplementedException( "Unknown type on stack." ) ;
			}
		}
	}
}
