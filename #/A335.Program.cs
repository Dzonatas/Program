using System.Collections.Generic ;
using System.Text.RegularExpressions ;
using System.Extensions ;

public partial class A335
{
partial class Program
	{
	static Dictionary<string,object> virtualset = new Dictionary<string,object>() ;
	static Dictionary<string,C_Function> c_functionset = new Dictionary<string, C_Function>() ;
	static Dictionary<string,C_Symbol> symbolset = new Dictionary<string, C_Symbol>() ;
	static Dictionary<C_Symbol,C_Type> typeset = new Dictionary<C_Symbol, C_Type>() ;
	static Dictionary<string,C_TypeDef> typedefset = new Dictionary<string, C_TypeDef>() ;
	Program()
		{
		}
	public Program( Automatrix auto )
		{
		}
	public Program Language
		{
		get { return this ; }
		}
	static public void Write()
		{
		Program.WriteC_Main() ;
		A335.Method.Write() ;
		Program.WriteC_Objects() ;
		}
	static public C_Function jiffy( string description )
		{
		return C.This = C_Method.CreateFunction( description ) ;
		}
	static public System.Type Function
		{
		get { return typeof(C_Function) ; }
		}
	public _TypeDef TypeDef
		{
		get { return new _TypeDef() ; }
		}
	public class _TypeDef
		{
		public C_Struct String
			{
			get { return new C_Struct("string") ; }
			}
		public C_Struct Object
			{
			get { return new C_Struct("object") ; }
			}
		}
	public class C_Method
		{
		//Guid ID ;
		//public List<C_Symbol>  NameSpace = new List<C_Symbol>() ;
		public List<C_Symbol>  ClassName = new List<C_Symbol>() ;
		public C_Symbol        Name ;
		public List<C_Type>    Args  = new List<C_Type>() ;
		public C_Type          Type ;
		public C_Function      Function ;
		/*
		public C_Method()
			{
			//ID = Guid.NewGuid() ;
			}
		*/
		public C_Method( C_Type context )
			{
			//ID = Guid.NewGuid() ;
			foreach( string s in (string[]) context )
				ClassName.Add( C_Symbol_Acquire( s ) ) ;
			}
		public C_Type ClassType
			{
			get {
				var type = new string[ClassName.Count];
				int i = 0 ;
				foreach( C_Symbol symbol in ClassName )
					type[i++] = symbol ;
				//type[i] = Name ;
				return C_Type.Acquire( type ) ;
				}
			}
		public C_Type ThisType
			{
			get {
				var type = new string[ClassName.Count+2];
				type[0] = new C_Undefined() ;
				int i = 1 ;
				foreach( C_Symbol symbol in ClassName )
					type[i++] = symbol ;
				type[i] = Name ;
				return C_Type.Acquire( type ) ;
				}
			}
		static public C_Function CreateFunction( string typedef )
			{
			C_Method m ;
			C_Function c ;
			var context = new string[] { "System" } ;
			m = new C_Method( C_Type.Acquire( context ) ) ;
			//m.NameSpace.Add( C_Symbol.Acquire( "BCL" ) ) ;
			//m.NameSpace.Add( C_Symbol.Acquire( "System" ) ) ;
			Match y = Regex.Match( typedef, @"^(?<type>\S+)\s" ) ;
			if( y.Success )
				m.Type = C_Type.Acquire( y.Groups[ "type" ].Value ) ;
			Match x = Regex.Match( typedef, @"^(\S+\s|)(?<classname>\S+)::(?<methodname>[^\(]+)(\((?<args>\S+)\)|)" ) ;
			if( ! x.Success )
				throw new System.NotImplementedException( typedef ) ;
			switch( x.Groups[ "classname" ].Value )
				{
				case "object"  : m.ClassName.Add( C_Symbol.Acquire( "Object" ) ) ; break ;
				case "console" : m.ClassName.Add( C_Symbol.Acquire( "Console" ) ) ; break ;
				case "string"  : m.ClassName.Add( C_Symbol.Acquire( "String" ) ) ; break ;
				default        : throw new System.NotImplementedException( typedef ) ;
				}
			string name ;
			switch( name = x.Groups[ "methodname" ].Value )
				{
				case ".ctor"   : m.Name = C_Symbol.Acquire( "_ctor" ) ; break ;
				default        : m.Name = C_Symbol.Acquire( "$" + name ) ; break ;
				}
			string args = x.Groups[ "args" ].Value ;
			if( ! System.String.IsNullOrEmpty( args ) )
				foreach( string a in x.Groups[ "args" ].Value.Split( ',' ) )
					m.Args.Add( C_Type.Acquire( a ) ) ;
			c = m.CreateFunction() ;
			c.Static = true ;
			c.Inline = true ;
			c.Args = '('+C699.C.Const.Voidpp.ArgV+')' ;
			return c ;
			}
		public C_Function CreateFunction()
			{
			string ns = "" ;
			/*
			foreach( C_Symbol e in NameSpace )
				{
				if( ns != "" )
					ns += "$$" ;
				ns += e ;
				}
			*/
			string cn = "" ;
			foreach( C_Symbol e in ClassName )
				{
				if( cn != "" )
					cn += "$" ;
				cn += e ;
				}
			string a = "" ;
			foreach( C_Type e in Args )
				{
				if( a != "" )
					a += "$" ;
				a += e ;
				}
			string s = "" ;
			s += /*ns + "_" +*/ cn + Name + ( a == "" ? "" : "$" + a ) ;
			C_Symbol symbol = C_Symbol.Acquire( s ) ;
			Function = C_Function.FromSymbol( symbol ) ;
			Function.Method = this ;
			if( Type != null )
				{
				if( Type == C_Type.Acquire("string") )
					Function.Type = C699.String ;
				else
					Function.Type = C699.C.Restricted(Type) ;
				}
			return Function ;
			}
		}
	static public void WriteC_Main()
		{
		var sw = C699_Main_Function___WriteTo__C699_Main_FileStructure__() ;
		foreach( C_TypeDef t in typedefset.Values )
			t.Struct.WriteTo( sw ) ;
		foreach( C_Function f in c_functionset.Values )
			{
			if( f.Required && ( f.Symbol.StartsWith( "BCL$" ) || f.Symbol.StartsWith( "System" ) ) )
				{
				f.WriteTo( sw ) ;
				}
			}
		A335.Method.WriteIncludesTo( sw ) ;
	    foreach( string class_symbol in virtualset.Keys )
			C_Struct.FromSymbol( class_symbol ).WriteInclude( sw ) ;
		sw.Close() ;
		}
	static public void WriteC_Objects()
		{
	    foreach( string class_symbol in virtualset.Keys )
			{
			System.IO.StreamWriter sw = System.IO.File.CreateText( Current.Working.Directory.FullName + "/" + class_symbol + ".c" ) ;
			var c = ((C_Struct) virtualset[class_symbol]) ;
			c.WriteTo( sw ) ;
			sw.Close() ;
			}
		}
	public class C_TypeDef
		{
		C_Symbol symbol ;
		C_Type   alias ;
		public C_Struct Struct ;
		C_TypeDef( string symbol, C_Type alias )
			{
			//ID = Guid.NewGuid() ;
			this.symbol = C_Symbol.Acquire( symbol ) ;
			this.alias  = alias ;
			}
		static public C_TypeDef Acquire( string symbol )
			{
			C_TypeDef c;
			if( typedefset.ContainsKey( symbol ) )
				c = typedefset[symbol] ;
			else
				typedefset.Add( symbol, c = new C_TypeDef( symbol, C_Type.Acquire( string.Empty ) ) ) ;
			return c ;
			}
		}
	public class C_Struct
		{
		public C699.c Type ;
		public string Symbol ;
		public C_TypeDef TypeDef ;
		List<string> list = new List<string>() ;
		List<C_Type> parameterset = new List<C_Type>() ;
		public C_Struct( string type )
			{
			TypeDef = C_TypeDef.Acquire( type ) ;
			if( TypeDef.Struct == null )
				TypeDef.Struct = this ;
			switch( type )
				{
				case "string": Type = C699.String ; return ;
				case "object": Type = C699.Object(0) ; return ;
				default      : Type = C699.C.Restricted("_" + type) ; return ;
				}
			}
		public C_Struct()
			{
			Type = C699.Object(0) ;
			}
		public void Add( string text )
			{
			list.Add( text ) ;
			}
		public C_Struct Parameter( C_Type symbol )
			{
			list.Add( symbol.Type + " " + symbol ) ;
			parameterset.Add( symbol ) ;
			return this ;
			}
		public C_Struct Parameter( C699.c symbol, string text )
			{
			list.Add( symbol + " " + text ) ;
			return this ;
			}
		public C_Type this[int n]
			{
			get{ return parameterset[n] ; }
			}
		public void Assign( string text )
			{
			list.Add( "." + text + " = " + Symbol + text ) ;
			}
		public void WriteInclude( System.IO.StreamWriter sw )
			{
			sw.WriteLine( "#include \"" + Symbol + ".c\"" ) ;
			}
		public void WriteTo( System.IO.StreamWriter sw )
			{
			if( Symbol != null )
				{
				sw.WriteLine( Type + ' ' + Symbol + " =" ) ;
				sw.WriteLine( "\t{" ) ;
				foreach( string s in list )
					sw.WriteLine( "\t" + s + " ," ) ;
				sw.WriteLine( "\t} ;" ) ;
				}
			else
				{
				sw.WriteLine( Type ) ;
				sw.WriteLine( "\t{" ) ;
				foreach( string s in list )
					sw.WriteLine( "\t" + s + " ;" ) ;
				sw.WriteLine( "\t} ;" ) ;
				}
			sw.WriteLine() ;
			}
		static public C_Struct FromSymbol( string S )
			{
			C_Struct c ;
			if( ! virtualset.ContainsKey( S ) )
				{
				c = new C_Struct() ;
				c.Symbol = S ;
				virtualset.Add( S, c ) ;
				}
			else
				c = virtualset[S] as C_Struct ;
			return c ;
			}
		}
	public class C_Oprand
		{
		C_Label label ;
		C_Function function ;
		public string Instruction ;
		public string ID ;
		public bool HasArgs ;
		public bool BrTarget ;
		List<C699.c> list = new List<C699.c>() ;
		public C_Label Label
			{
			set { label = value ; }
			get { return label ; }
			}
		public C_Method Method
			{
			get { return function.Method ; }
			}
		public C_Oprand( C_Function function, string instr )
			{
			this.function = function ;
			ID = System.Guid.NewGuid().ToID() ;
			Instruction = System.Text.RegularExpressions.Regex.Replace( instr, "[^A-Za-z_0-9]", "_").ToUpper() ;
			}
		static public implicit operator C699.c( C_Oprand d )
			{
			if( d.BrTarget && d.Instruction == "BR" )
				return d.list[0] ;
			var f = C699.C.Function( d.Instruction, d.ID,"stack " + ( d.HasArgs ? ", args" : "" ) ) ;
			if( d.BrTarget )
				return C699.C.If( f, d.list[0] ) ;
			return f ;
			}
		static public explicit operator string( C_Oprand d )
			{
			return ((C699.c)d) ;
			}
		public C_Oprand Statement( C699.c c )
			{
			list.Add( c ) ;
			return this ;
			}
		public void WriteTo( System.IO.StreamWriter sw )
			{
			if( BrTarget && Instruction == "BR" )
				return ;
			var c = C_Function.FromSymbol( Instruction + "$" + ID ) ;
			if( BrTarget )
				c.Bool = true ;
			c.Static = true ;
			c.Inline = true ;
			c.HasArgs = HasArgs ;
			switch( Instruction )
				{
				case "BGE" :
					c.Statement( C699.C.Return("1") ) ;
					break ;
				default:
					foreach( C699.c s in list )
						c.Statement( s ) ;
					break ;
				}
			c.WriteTo( sw ) ;
			}
		}
	}

}

