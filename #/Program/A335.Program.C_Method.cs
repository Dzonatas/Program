using System.Collections.Generic ;

partial class A335
{
partial class Program : C699
	{
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
			var y = System.Text.RegularExpressions.Regex.Match( typedef, @"^(?<type>\S+)\s" ) ;
			if( y.Success )
				{
				string t = y.Groups[ "type" ].Value ;
				if( t == "string*" )
					m.Type = C_Type.Acquire( C699.String.p ) ;
				else
					m.Type = C_Type.Acquire( t ) ;
				}
			var x = System.Text.RegularExpressions.Regex.Match( typedef, @"^(\S+\s|)(?<classname>\S+)::(?<methodname>[^\(]+)(\((?<args>\S+)\)|)" ) ;
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
			c.Args = '('+C.Const.Voidpp.ArgV+')' ;
			return c ;
			}
		public C_Function CreateFunction()
			{
			/*
			string ns = "" ;
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
					Function.Type = C.Restricted(Type) ;
				}
			return Function ;
			}
		public override string ToString()
			{
			return (Type == null ? "?type?" : Type.Spec)  + " " + (Name == null ? "?name?" : Name) ;
			}
		}
	}
}