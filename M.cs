//#define START Blogic#<NOUN L="START">#

//using System;
//using System.Xml ;
using System.IO ;
using System.Collections.Generic ;

public partial class A335
{

public static void Main( string[] args )
	{
	Application.Program.Parse( args ) ;
	//request( ref system ) ;  //_: request( ref system_m ) ; //_m!(_err[1...3]='boxed','unboxed','not boxed')((_cubed))
	if( Application.Parameter.Value("synopsis") == "false" ) 
		Begin() ;
#if RELEASE
	else
		Tutorial() ;
	//iOS.up
	try {
		leave() ; //[debug:n0p;,("AI")]
		}
	catch
		{
		throw new _.exception() ;
		}
#endif
	}

class Microdata : C_Type //,IOprand
	{
	public int     capacity ; //itemscope
	public string  _char_np ; //itemtype="data:xml::C#<C++0x11>(<*.cs>)_,<Method>_,"
	public string  type     ; //<itemprop item="<Method.Type>">
	public object[] ToArray() { return new object[] { capacity, _char_np, type } ; }
	static public Microdata N0P
		{
		get { return new Microdata( 0, null, new C_Undefined() ) ; }
		}
	public Microdata( int _1, string _2, string _3 )
		: base( C_Type.Acquire( _3 ) )
		{
		this.capacity  = _1 ; //<br/>
		this._char_np  = _2 ; //<br/>
		this.type      = _3 ; //<br/>
		} //</itemprop>
	public Microdata( bool _1, string type )
		: base( C_Type.Acquire( type ) )
		{
		this.capacity  = _1 ? 1 : 0 ;
		this._char_np  = _1 ? System.String.Empty : null ;
		this.type      = type ;
		}
	public Microdata( bool _1 )
		: base( new C_Undefined() )
		{
		this.capacity  = _1 ? 1 : 0 ;
		this._char_np  = _1 ? System.String.Empty : null ;
		}
	public Microdata( int _1, string _char_np )
		: base( new C_Undefined() )
		{
		this.capacity  = _1 ;
		this._char_np  = _char_np ;
		}
	public Microdata( string _char_np )
		: base( new C_Undefined() )
		{
		this.capacity  = _char_np.Length ;
		this._char_np  = _char_np ;
		}
	public Microdata( string _char_np, string type )
		: base( C_Type.Acquire( type ) )
		{
		this.capacity  = _char_np.Length ;
		this._char_np  = _char_np ;
		this.type      = type ;
		}
	static public explicit operator bool(Microdata d)
		{
		return d.capacity == 0 ? false : true ;
		}
	}

class Method
	{
	static Program.Method method ;
	public class Head : Automatrix
		{
		protected void methodHead()
			{
			CreateFunction() ;
			SigArg.Clear() ;
			}
		protected void    NewMethod( C_Type context )
			{
			method = new Program.Method( context ) ;
			}
		protected Attr    AttrList
			{
			set {
				  method.Static  = value is Attr ? value.Static : false ;
				  method.Virtual = value is Attr ? value.Virtual : false ;
				}
			}
		protected CallConv CallConvList
			{
			set { method.CallConvInstance = value is CallConv ? value.Instance : false ; }
			}
		protected A335.Argument  Type
			{
			set { method.Type = C_Type.Acquire( value.ResolveType() ) ; }
			}
		protected string  Name
			{
			set { method.Name = value ; }
			}
		protected string  SigArgTypes
			{
			set { method.SigArgTypes = value ; }
			}
		protected int     SigArgs
			{
			set { method.SigArgs = value ; }
			}
		protected void    RegisterCctor()
			{
			method.RegisterCctor() ;
			}
		protected void    CreateFunction()
			{
			method.CreateFunction() ;
			}
		}
	public class Decl : Automatrix
		{
		static C_Symbol   label = C_Symbol.Acquire( System.String.Empty ) ;
		protected int     MaxStack
			{
			set { method.MaxStack = value ; }
			}
		protected bool    CallConvInstance
			{
			get { return method.CallConvInstance ; }
			}
		protected int     SigArgs
			{
			get { return method.SigArgs ; }
			}
		protected new int Args
			{
			get { return SigArgs + ( CallConvInstance ? 1 : 0 ) ; }
			}
		protected void    RegisterLabel( string text )
			{
			method.RegisterLabel( text ) ;
			}
		static public C_Symbol Label
			{
			set { label = value ; }
			get { return label ; }
			}
		protected void    EntryPoint()
			{
			if( System.String.IsNullOrEmpty(Class.Symbol) )
				throw new System.NotImplementedException( "entrypoint outside class" ) ;
			this_start_method = method ;
			}
		protected Program.C_Oprand NewOprand( string instr )
			{
			return method.NewOprand( instr ) ;
			}
		}
	public class Attr : Automatrix
		{
		static Attr current = null ;
		Attr next ;
		protected override void main()
			{
			next = current ;
			current = this ;
			}
		static public Attr List
			{
			get { Attr l = current ; current = null ; return l ; }
			}
		public bool Static
			{
			get {
				for( Attr i = this ; i is Attr ; i = i.next )
					if( i is methAttr_methAttr__static_ )
						return true ;
				return false ;
				}
			}
		public bool Virtual
			{
			get {
				for( Attr i = this ; i is Attr ; i = i.next )
					if( i is methAttr_methAttr__virtual_ )
						return true ;
				return false ;
				}
			}
		}
	static public void Start()
		{
		#if SYSTEM_GUID
		if( system.guid == null )
			{
			xml_load_grammar() ;
			byte []    b = system_ip.GetAddressBytes() ;
			Array.Reverse( b ) ;
			/*
			system       = b_enter( b[3], b[2], b[1], b[0] ) ;
			system.guid  = Guid.Empty ;
			*/
			}
		#else
		xml_load_grammar() ;
		#endif
		}
	}

partial class Program
	{
	public class Method
		{
		int            maxstack ;
		C_Method       method ;
		C_Function     function ;
		List<C_Oprand> oprandset = new List<C_Oprand>() ;
		List<string>   labelset = new List<string>() ;
		public bool    Static ;
		public bool    CallConvInstance ;
		public string  Type
			{
			set { method.Type = C_Type.Acquire( value ) ; }
			get { return (string) method.Type ; }
			}
		public string  Name
			{
			set { method.Name = C_Symbol_Acquire( value ) ; }
			get { return (string) method.Name ; }
			}
		public string  SigArgTypes ;
		public int     SigArgs ;
		public string  ClassSymbol
			{
			get { return (string) method.ClassType ; }
			}
		public int     MaxStack
			{
			set { C.MaxStack = maxstack = value ; }
			}
		bool _virtual ;
		public bool    Virtual
			{
			set {
				if( ( _virtual = value ) )
					{
					C_Struct c = C_Struct.FromSymbol( ClassSymbol ) ;
					c.Assign( Name + SigArgTypes ) ;
					}
				}
			}
		public Method( C_Type context )
			{
			method = new C_Method( context ) ;
			methodset.Add( this ) ;
			}
		public void Add( C_Oprand oprand )
			{
			oprand.Label = A335.Method.Decl.Label ;
			A335.Method.Decl.Label = C_Symbol.Acquire( System.String.Empty ) ;
			oprandset.Add( oprand ) ;
			}
		public void RegisterLabel( string text )
			{
			labelset.Add( text ) ;
			}
		public void RegisterCctor()
			{
			cctorset.Add( ClassSymbol ) ;
			}
		public void WriteInclude( StreamWriter sw )
			{
			sw.WriteLine( "#include \"" + ClassSymbol + Name + SigArgTypes + ".c\"" ) ;
			}
		public void CreateFunction()
			{
			foreach( string a in SigArg.Typeset )
				method.Args.Add( C_Type.Acquire( a ) ) ;
			function = C_Function.FromSymbol( ClassSymbol + Name + SigArgTypes ) ;
			function.Method = method ;
			}
		public C_Oprand NewOprand( string instr )
			{
			var d = new C_Oprand( function, instr ) ;
			Add( d ) ;
			return d ;
			}
		public void Write()
			{
			var c = function ;
			StreamWriter sw = File.CreateText( directory.FullName + "/" + c.Symbol + ".c" ) ;
			foreach( C_Oprand o in oprandset )
				o.WriteTo( sw ) ;
			int args = SigArgs + ( CallConvInstance ? 1 : 0 ) ;
			if( _virtual )
				c.Type = C_Symbol.Acquire( "struct _string" ) ;
			if( args == 0 )
				c.Args = "()" ;
			else
				c.Args = "( const void** args )" ;
			c.Statement( "const void** stack = alloca( " + maxstack + " * sizeof(void*) )" ) ;
			foreach( C_Oprand o in oprandset )
				{
				string label = System.String.Empty ;
				if( System.String.Empty == ( label = o.Label ) )
					c.Statement( (string) (o as C_Oprand) ) ;
				else
					{
					if( labelset.Contains( label ) )
						c.Label( label ) ;
					c.Statement( (string) (o as C_Oprand) ) ;
					}
				}
			if( _virtual )
				c.Statement( "return *(struct _string *)*stack" ) ;
			c.WriteTo( sw ) ;
			sw.Close() ;
			}
		}
	}

}

namespace Materials
	{
	#region MATERIAL
	struct M
		{
		System.Guid guid ;
		public int INTERFACE ;
		public int intraface ;
		}
	struct library_collada
		{
		M id ;
		}
	struct MESA
		{
		static readonly object _ ;
		string defunct_drm ;
		M resx ;
		static MESA()
			{
			MESA _ = new MESA() ;
			_.defunct_drm = "" ;
			_.resx = new Materials.M() ;
			}
		}
	#endregion
	}

namespace Magic.Number
	{
	#region DUMB_TERM
	struct _
		{
		string TERM ;//_region
		}
	#endregion
	}
