//#define START Blogic#<NOUN L="START">#

//using System;
//using System.Xml ;
using System.IO ;
using System.Collections.Generic ;
using System.Extensions ;
using System ;
using X.Predefined ;

public partial class A335
{

public static void Main( string[] args )
	{
	current_working_directory() ;	//'POST ip time/0.0'
	Application.Program.Parse( args ) ;
	Current.Estate.Current__System_File.Path = Application.Parameter.Value("PANZOR") ;
	#if PRIME
	X.Simple.Map( Cluster.Shell.Dpkg__p_START() ) ;
	#elif TOP
	//:vi::1,3d,top
	//:vi::4,$s//
	//:!export WINDOWID
	#endif
	#if !STABLE
	X.Simple.Map( Cluster.Shell.Dpkg__p_LSB() ) ;
	///googlechromereleases.blogspot.com
	#elif SID
	System.Console.WriteLine( "{0} {1} {2}", (1<<22), (1L<<22)-1, Environment.GetEnvironmentVariable("DECISION") ) ;
	//Chrome-Version: M38(JE)
	#elif ASL
	//Y.x() ;
	#else
	//Chrome-Version: 37.0.2062.94
	System.Console.WriteLine( Cluster.Shell.Dpkg__p_LSB() ) ; /* Override 'START' with 'LSB' for XHAL. */
	X.Simple.Map() ;
	#endif
	//X.Window() ;
	//XLogo logo = new XLogo() ;
	//logo.Window() ;
	Xo_t.Build() ;
	//Punctuation.Program.Parse( args ) ;
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

#if MICRODATA

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

#endif //MICRODATA

class Method
	{
	static Head head ;
	static Head begin ;
	static public List<string>  cctorset = new List<string>() ;
	public class Head : Automatrix
		{
		Head    previous ;
		Head    next ;
		Program.C_Method c_method ;
		C_Type  classType ;
		C_Symbol name ;
		Decl    declList ;
		int     maxstack ;
		bool    _static ;
		bool    _CallConvInstance ;
		SigArgs0 _SigArgs0 ;
		bool    _Virtual ;
		public class Part1 : Automatrix
			{
			protected override void main()
				{
				}
			}
		protected C_Symbol _ctor          = C_Type.Acquire( Nameset[0] ) ;
		protected C_Symbol _cctor
			{
			get { cctorset.Add( classType ) ; return C_Type.Acquire( Nameset[1] ) ; }
			}
		protected override void main()
			{
			if( null != ( previous = head ) )
				previous.next = this ;
			else
				begin = this ;
			head = this ;
			c_method = new Program.C_Method( Class.Type ) ;
			classType = Class.Type ;
			methodHead() ;
			CreateFunction() ;
			}
		virtual protected void methodHead() {}
		public Decl    DeclList
			{
			set { declList = value ; }
			get { return declList ; }
			}
		protected Attr    AttrList
			{
			set {
				  Static  = value is Attr ? value.Static : false ;
				  Virtual = value is Attr ? value.Virtual : false ;
				}
			}
		protected CallConv CallConvList
			{
			set { _CallConvInstance = value is CallConv ? value.Instance : false ; }
			}
		protected A335.Argument  Type
			{
			set { c_method.Type = C_Type.Acquire( value.ResolveType() ) ; }
			}
		public C_Type  ClassType
			{
			get { return classType ; }
			}
		public C_Symbol  Name
			{
			set { c_method.Name = name = value ; }
			get { return name ; }
			}
		public SigArgs0 SigArgs0
			{
			set { _SigArgs0 = value ; }
			get { return _SigArgs0 ; }
			}
		protected void    CreateFunction()
			{
			string symbol = classType + name ;
			if( _SigArgs0 != null )
				{
				_SigArgs0.ForEach( (a) => c_method.Args.Add( a._Type ) ) ;
				symbol += _SigArgs0.Types() ;
				}
			c_method.Function = Program.C_Function.FromSymbol( symbol ) ;
			c_method.Function.Method = c_method ;
			}
		public int MaxStack
			{
			set { maxstack = value ; }
			get { return maxstack ; }
			}
		public bool Static
			{
			set { _static = value ; }
			get { return _static ; }
			}
		public bool CallConvInstance
			{
			set { _CallConvInstance = value ; }
			get { return _CallConvInstance ; }
			}
		static public Method.Head Current
			{
			get { return head ; }
			}
		public bool    Virtual
			{
			set {
				if( ( _Virtual = value ) )
					{
					var c = Program.C_Struct.FromSymbol( classType ) ;
					c.Assign( name + _SigArgs0.Types() ) ;
					}
				}
			get { return _Virtual ; }
			}
		public void WriteInclude( StreamWriter sw )
			{
			if( _SigArgs0 == null )
				sw.WriteLine( "#include \"" + classType + name + ".c\"" ) ;
			else
				sw.WriteLine( "#include \"" + classType + name + _SigArgs0.Types() + ".c\"" ) ;
			}
		static public Head Begin
			{
			get { return begin ; }
			}
		public Head Next
			{
			get { return next ; }
			}
		public void Write()
			{
			var c = c_method.Function ;
			int args = ( _SigArgs0 == null ? 0 :_SigArgs0.Count() ) + ( _CallConvInstance ? 1 : 0 ) ;
			if( _Virtual )
				c.Type = C_Symbol.Acquire( "struct _string" ) ;
			if( args == 0 )
				c.Args = "()" ;
			else
				c.Args = "( const void** args )" ;
			c.Statement( "const void** stack = alloca( " + maxstack + " * sizeof(void*) )" ) ;
			A335.Method.WriteList( c, declList ) ;
			if( _Virtual )
				c.Statement( "return *(struct _string *)*stack" ) ;
			StreamWriter sw = File.CreateText( directory.FullName + "/" + c.Symbol + ".c" ) ;
			sw.WriteLine( "#include \"" + c.Symbol + ".hpp\"\n" ) ;
			c.WriteTo( sw ) ;
			sw.Close() ;
			}
		public Program.C_Oprand NewOprand( string instr )
			{
			return new Program.C_Oprand( c_method.Function, instr ) ;
			}
		}
	static public void WriteIncludesTo( StreamWriter sw )
		{
		for( Head i = Head.Begin ; i is Head ; i = i.Next )
			i.WriteInclude( sw ) ;
		}
	static public void Write()
		{
		for( Head i = Head.Begin ; i is Head ; i = i.Next )
			i.Write() ;
		}
	public class Decl : Automatrix
		{
		static Decl current = null ;
		Head _head ;
		Decl previous ;
		Decl next ;
		C_Label   label ;
		Instr     _Instr ;
		public Decl Next
			{
			get { return next ; }
			}
		public Instr     Instr
			{
			set { _Instr = value ; }
			get { return _Instr ; }
			}
		static public Decl List
			{
			get {
				Decl i ;
				for( i = current ; i is Decl ; i = i.previous )
					{
					if( i.previous == null )
						{
						current = null ;
						return i ;
						}
					else
						i.previous.next = i ;
					}
				return i ;
				}
			}
		protected void Enlist()
			{
			previous = current ;
			current = this ;
			}
		protected int     MaxStack
			{
			set { head.MaxStack = value ; C.MaxStack = value ; }
			}
		protected int Args
			{
			get { return ( head.SigArgs0 == null ? 0 : head.SigArgs0.Count() ) + ( head.CallConvInstance ? 1 : 0 ) ; }
			}
		public C_Label Label
			{
			set { label = value ; }
			get { return label != null ? label : C_Label.Empty ; }
			}
		static public C_Label Find( C_Symbol id )
			{
			for( Decl i = current ; i is Decl ; i = i.next )
				if( i.label != null && id == i.label )
					return i.label ;
			return null ;
			}
		protected Decl    EntryPoint
			{
			set {
				_EntryPoint = value ;
				_head = head ;
				if( System.String.IsNullOrEmpty(Class.Symbol) )
					throw new System.NotImplementedException( "entrypoint outside class" ) ;
				}
			get {
				return _EntryPoint ;
				}
			}
		protected Program.C_Oprand NewOprand( string instr )
			{
			return head.NewOprand( instr ) ;
			}
		public Head Head
			{
			get { return _head ; }
			}
		}
	static Decl _EntryPoint ;
	static public Decl EntryPoint
		{
		get { return _EntryPoint ; }
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
	static public void WriteList( Program.C_Function function, Decl declList )
		{
		for( A335.Method.Decl d = declList ; d is A335.Method.Decl ; d = d.Next )
			{
			if( d.Label != null && d.Label.Required )
				function.Label( d.Label ) ;
			else
			if( d.Instr != null )
				function.Statement( (string) d.Instr._C_Oprand ) ;
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
