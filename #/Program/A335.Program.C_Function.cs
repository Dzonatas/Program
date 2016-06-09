using System.Collections.Generic ;

partial class A335
{
partial class Program : C699
	{
	public class C_Function
		{
		//Guid ID ;
		public C_Method Method ;
		public bool Static ;
		public bool Inline ;
		public bool Instance ;
		public bool Void
			{
			set {
				if( value )
					Type = C.Void ;
				}
			}
		public bool Bool
			{
			set {
				if( value )
					Type = C.Int ;
				}
			}
		public C699.c Type ;
		//C_Symbol symbol ;
		public string Symbol ;
		public bool   HasArgs ;
		public string Args ;
		public bool   Written ;
		public bool   Required ;
		C_Literal let ;
		string[]      list        = new string[0] ;
		public C_ValueType[] ManagedPointers = new C_ValueType[0] ;
		void list_add( string s )
			{
			System.Array.Resize( ref list, list.Length+1 ) ;
			list[list.Length-1] = s ;
			}
		public C_Function Let( C_Literal literal )
			{
			let = literal ;
			return this ;
			}
		public C_Function Equal
			{
			get { return this ; }
			}
		public C_Function Instantiated()
			{
			Instance = true ;
			return this ;
			}
		public C_Function ConstLocalArg0
			{
			get {
				var arg0 = new C_Struct(Method.Args[0]) ;
				var symbol = C_Symbol.Acquire( "_local" ) ;
				return Statement( C.Const.Struct(arg0.Type.p,symbol).Equate("*argv") ) ;
				}
			}
		public C_Function ConstLocalArg( int argn )
			{
			var arg1 = new C_Struct(Method.Args[argn]) ;
			var symbol = C_Symbol.Acquire( "_local"+argn ) ;
			return Statement( C.Const.Struct(arg1.Type.p,symbol).Equate("argv["+argn+"]") ) ;
			}
		public C_Function StandardOutputWriteLocal( string _string, string _length )
			{
			var symbol = C_Symbol.Acquire( "_local" ) ;
			return Statement( C699.Write( 0, symbol+"->"+_string, symbol+"->"+_length ) ) ;
			}
		public C_Function StandardOutputWriteLine()
			{
			return Statement( C699.Write( 0, "\"\\012\"" , "1" ) ) ;
			}
		public C_Function Return( string symbol )
			{
			return Statement( C.Return(symbol) ) ;
			}
		public C_Function Register( ref C_Literal l, C699.c type, string name )
			{
			l.Function  = this ;
			l.Type      = type ;
			l.Name      = C.Literal(C_Symbol.Acquire(name)) ;
			Statement( C.Struct(type,l.Name) ) ;
			return this ;
			}
		public C_Function Register( ref C_Literal l, C699.c type )
			{
			l = new C_Literal() ;
			return Register( ref l, type, C_Symbol.Acquire(type).By_p() ) ;
			}
		public C_Function ManagedToString( int i )
			{
			if( (let.Type.Bits & C699.Bit.Object) != 0 || let.Type == C699.String.p )
					return Statement( let.Name.Equate("(("+C699.Object("object")+" *)argv["+i+"])->$ToString( argv+"+i+" )") ) ;
			throw new System.NotImplementedException( "Type of managed pointer not defined." ) ;
			}
		C_Function( string symbol )
			{
			Void = true ;
			/*this.symbol =*/ C_Symbol.Acquire( symbol ) ;
			Symbol = symbol ;
			//ID = Guid.NewGuid() ;
			}
		static public C_Function FromSymbol( string symbol )
			{
			C_Symbol s = C_Symbol.Acquire( symbol ) ;
			return FromSymbol( s ) ;
			}
		static public C_Function FromSymbol( C_Symbol symbol )
			{
			C_Function c ;
			if( ! c_functionset.ContainsKey( symbol ) )
				c_functionset.Add( symbol, c = new C_Function( symbol ) ) ;
			else
				c = c_functionset[symbol] ;
			return c ;
			}
		static public void Require( string symbol )
			{
			C_Function c ;
			if( ! c_functionset.ContainsKey( symbol ) )
				c_functionset.Add( symbol, c = new C_Function( symbol ) ) ;
			else
				c = c_functionset[symbol] ;
			c.Required = true ;
			}
		public C_Function Statement( C699.c line )
			{
			bool eos = ( line.Bits & (C699.Bit.If|C699.Bit.Else) ) != 0 && (line.Bits & C699.Bit.Goto) == 0 ;
			list_add( "\t" + line + ( eos ? "" : " ;" ) ) ;
			return this ;
			}
		public C_Function Statement( string line )
			{
			return Statement( C.Restricted(line) ) ;
			}
		public void Label( string label )
			{
			list_add( "\t" + label + " :" ) ;
			}
		public void GarbageCollect()
			{
			var typedef = C_TypeDef.Acquire("string") ;
			string field = typedef.Struct[1] ;
			for( int x = 0 ; x < freeset.Length ; x++ )
				{
				for( int y = C699.Stack.Offset ; y < stack.Length ; y++ )
					{
					if( freeset[x].Symbol == stack[y].Symbol )
						{
						#if DEBUG
						Statement( new c("//"+C699.Free( "("+stack[y].StackDeref+")."+field )) ) ;
						#endif
						stack[y].Symbol = null ;
						}
					}
				}
			}
		public C699.c Allocate(Method.Local local)
			{
			var mp = new C_ValueType()
				{
				Symbol = local.Symbol ,
				//Offset = stack_offset ,
				Type   = local.Type
				} ;
			System.Array.Resize( ref ManagedPointers, ManagedPointers.Length+1 ) ;
			ManagedPointers[ManagedPointers.Length-1] = mp ;
			return C699.C.Struct( new c("struct _mp "), mp.Symbol+"_mp"  ).Equate( "{0,(void*)0}" ) ;
			}
		public void WriteTo( System.IO.TextWriter sw )
			{
			#if !HPP
			if( sw is System.IO.StreamWriter )
				{
			#endif
				string line = "" ;
				if( Inline )
					line += C.Inline + " " ;
				if( Static )
					line += C.Static(Type) ;
				else
					line += Type ;
				line += " " + Symbol
						.Replace('/','_').Replace('.','$')
						.Replace('[','_').Replace(']','_') ;
				if( Args == null )
					line += '('
					+ ( ( Instance || HasArgs ) ? C.Const.Void.p.p.ArgV : "" )
					+ ( ( Instance == false && HasArgs == false ) ? C699.KeyedWord.Void : "" )
					+ ')' ;
				else
					line += Args ;
				sw.WriteLine( line ) ;
				sw.WriteLine( "\t{" ) ;
			#if !HPP
				foreach( string s in list )
					sw.WriteLine( s ) ;
				}
			else
				{
				sw.WriteLine( "{// "+Symbol.Split('$')[0] ) ;
				foreach( string s in list )
					sw.WriteLine( "\t"+s ) ;
				}
			#else
			foreach( string s in list )
				sw.WriteLine( "\t"+s ) ;
			sw.WriteLine( "\t}" ) ;
			sw.WriteLine() ;
			#endif
			#if !HPP
			if( sw is System.IO.StreamWriter )
				{
				sw.WriteLine( "\t}" ) ;
				sw.WriteLine() ;
				}
			else
				{
				sw.Write( "\t}" ) ;
				}
			#endif
			Written = true ;
			}
		}
	}
}
