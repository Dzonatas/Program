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
