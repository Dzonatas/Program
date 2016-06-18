partial class A335
{
public partial class Type : Automatrix
	{
	static public implicit operator string( Type n ) { return n.symbol ; }
	protected virtual string symbol { get { throw new System.NotImplementedException() ; } }
	static public implicit operator C699.c( Type n ) { return n.c ; }
	protected virtual C699.c c { get { throw new System.NotImplementedException() ; } }
	static public implicit operator C_Type( Type n ) { return n.c_type ; }
	protected virtual C_Type c_type { get { throw new System.NotImplementedException() ; } }
	}

public partial class   type__bool_
	: Type {
	static C_Type _c_type = C_Type.Acquire( C699.C.Int ) ;
	protected override string symbol { get { return Arg1.Token ; } }
	protected override C699.c c { get { return C699.C.Int ; } }
	protected override C_Type c_type { get { return _c_type ; } }
	}

public partial class   type__char_
	: Type {
	static C_Type _c_type = C_Type.Acquire( C699.C.Char ) ;
	protected override string symbol { get { return Arg1.Token ; } }
	protected override C699.c c { get { return C699.C.Int ; } }
	protected override C_Type c_type { get { return _c_type ; } }
	}

public partial class   type__int16_
	: Type {
	static C_Type _c_type = C_Type.Acquire( C699.C.Short ) ;
	protected override string symbol { get { return Arg1.Token ; } }
	protected override C699.c c { get { return C699.C.Int ; } }
	protected override C_Type c_type { get { return _c_type ; } }
	}

public partial class   type__int32_
	: Type {
	static C_Type _c_type = C_Type.Acquire( C699.C.Int ) ;
	protected override string symbol { get { return Arg1.Token ; } }
	protected override C699.c c { get { return C699.C.Int ; } }
	protected override C_Type c_type { get { return _c_type ; } }
	}

public partial class   type__object_
	: Type {
	static C_Type _c_type = C_Type.Acquire( C699.Object("object") ) ;
	protected override string symbol { get { return Arg1.Token ; } }
	protected override C699.c c { get { return C699.Object("object") ; } }
	protected override C_Type c_type { get { return _c_type ; } }
	}

public partial class   type__valuetype__className
	: Type {
	protected override string symbol { get { return (Argv[2] as Class.Name) ; } }
	protected override C699.c c      { get { return new C699.c(C699.KeyedWord.Struct+" "+symbol+" ").p ; } }
	protected override C_Type c_type { get { return C_Type.Acquire(c) ; } }
	}

public partial class   type__class__className
	: Type {
	protected override string symbol { get { return (Argv[2] as Class.Name) ; } }
	protected override C699.c c      { get { return new C699.c(C699.KeyedWord.Struct+" "+symbol+" ").p ; } }
	protected override C_Type c_type { get { return C_Type.Acquire(c) ; } }
	}

public partial class   type__string_
	: Type {
	static C_Type _c_type = C_Type.Acquire( C699.String.p ) ;
	protected override string symbol { get { return Arg1.Token ; } }
	protected override C699.c c { get { return C699.String.p ; } }
	protected override C_Type c_type { get { return _c_type ; } }
	}

public partial class   type__void_
	: Type {
	static C_Type _c_type = C_Type.Acquire( C699.C.Void ) ;
	protected override string symbol { get { return Arg1.Token ; } }
	protected override C699.c c { get { return C699.C.Void ; } }
	protected override C_Type c_type { get { return _c_type ; } }
	}

public partial class   type_____int32
	: Type {
	protected override string symbol { get { return "excl"+Arg2.Token ; } }
	protected override C699.c c { get { return new C699.c(symbol) ; } }
	protected override C_Type c_type { get { return C_Type.Acquire(c) ; } }
	}

public partial class   type__native___int_
	: Type {
	protected override string symbol { get { return "native_int" ; } }
	protected override C699.c c { get { return new C699.c(C699.KeyedWord.Int) ; } }
	protected override C_Type c_type { get { return C_Type.Acquire(c) ; } }
	}

public partial class   type_type_____bounds1____
	: Type {
	protected override string symbol { get { return (Argv[1] as Type) + "_rsqb_" + Arg3.Token + "_lsqb_" ; } }
	}

public partial class   type_type_asterisk
	: Type {
	protected override string symbol { get { return (Argv[1] as Type) + "_asterisk" ; } }
	}

public partial class   type_type_ampersand
	: Type {
	protected override string symbol { get { return (Argv[1] as Type) + "_ampersand" ; } }
	}

public partial class   type_type_square_brackets
	: Type {
	protected override string symbol { get { return (Argv[1] as Type) + "_sqbr" ; } }
	protected override C699.c c { get { return ((C699.c)(Argv[1] as Type)).p ; } }
	protected override C_Type c_type { get { return C_Type.Acquire(c) ; } }
	}

public partial class   type_type_____genArgs____
	: Type {
	protected override string symbol
		{
		get {
			string s = (string) (Argv[1] as Type) ;
			if( s.StartsWith("_mscorlib_") )
				s = s.Substring(10) ;
			else
			if( s.StartsWith("_corlib_") )
				s = s.Substring(8) ;
			return s + "_genArgs" ;
			}
		}
	protected override C699.c c
		{
		get	{
			if( ! Program.C_TypeDef.Declared(  symbol ) )
				{
				var t = C.TypeDef.Type( symbol ) ;
				//var s = Program.C_Struct.FromSymbol( symbol ) ;
				t.Parameter( C699.Object("object").p , "this" ) ;
				t.Parameter( C699.String.p, "(*$Invoke)()" ) ;
				}
			return new C699.c(C699.KeyedWord.Struct+" "+symbol+" ").p ;
			}
		}
	//protected override C699.c c { get { return new C699.c(C699.KeyedWord.Struct+" "+symbol+" ").p ; } }
	protected override C_Type c_type { get { return C_Type.Acquire(c) ; } }
	}

}