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
	static Head head ;
	static public Program.Method Current
		{
		get { return method ; }
		}
	public class Head : Automatrix
		{
		C_Type  classType ;
		Decl    declList ;
		int     maxstack ;
		bool    _static ;
		bool    _CallConvInstance ;
		int     _SigArgs ;
		string  _SigArgTypes ;
		public class Part1 : Automatrix
			{
			protected override void main()
				{
				method = new Program.Method( Class.Type ) ;
				}
			}
		protected C_Symbol _ctor          = C_Type.Acquire( Nameset[0] ) ;
		protected C_Symbol _cctor
			{
			get { RegisterCctor() ; return C_Type.Acquire( Nameset[1] ) ; }
			}
		protected override void main()
			{
			head = this ;
			classType = Class.Type ;
			method.Head = this ;
			methodHead() ;
			CreateFunction() ;
			SigArg.Clear() ;
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
				  method.Virtual = value is Attr ? value.Virtual : false ;
				}
			}
		protected CallConv CallConvList
			{
			set { _CallConvInstance = value is CallConv ? value.Instance : false ; }
			}
		protected A335.Argument  Type
			{
			set { method.Type = C_Type.Acquire( value.ResolveType() ) ; }
			}
		protected string  Name
			{
			set { method.Name = value ; }
			}
		public string  SigArgTypes
			{
			set { _SigArgTypes = value ; }
			get { return _SigArgTypes ; }
			}
		public int     SigArgs
			{
			set { _SigArgs = value ; }
			get { return _SigArgs ; }
			}
		protected void    RegisterCctor()
			{
			method.RegisterCctor() ;
			}
		protected void    CreateFunction()
			{
			method.CreateFunction() ;
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
		}
	public class Decl : Automatrix
		{
		static Decl current = null ;
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
			get { return head.SigArgs + ( head.CallConvInstance ? 1 : 0 ) ; }
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
