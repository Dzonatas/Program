partial class A335
{
public partial class Type : Automatrix
	{
	static public implicit operator string( Type n ) { return n.symbol ; }
	protected virtual string symbol { get { return null ; } }
	static public implicit operator C699.c( Type n ) { return n.c ; }
	protected virtual C699.c c { get { throw new System.NotImplementedException() ; } }
	static public implicit operator C_Type( Type n ) { return n.c_type ; }
	protected virtual C_Type c_type { get { throw new System.NotImplementedException() ; } }
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
	static C_Type _c_type = C_Type.Acquire( C699.Object(0) ) ;
	protected override string symbol { get { return Arg1.Token ; } }
	protected override C699.c c { get { return C699.Object(0) ; } }
	protected override C_Type c_type { get { return _c_type ; } }
	}

public partial class   type__valuetype__className
	: Type {
	protected override string symbol { get { return Arg1.Token + " " + Arg2.ResolveType() ; } }
	protected override C699.c c { get { throw new System.NotImplementedException() ; } }
	}

public partial class   type__class__className
	: Type {
	protected override string symbol { get { return Arg1.Token + " " + Arg2.ResolveType() ; } }
	protected override C699.c c { get { throw new System.NotImplementedException() ; } }
	}

public partial class   type__string_
	: Type {
	static C_Type _c_type = C_Type.Acquire( C699.String ) ;
	protected override string symbol { get { return Arg1.Token ; } }
	protected override C699.c c { get { return C699.String ; } }
	protected override C_Type c_type { get { return _c_type ; } }
	}

public partial class   type__void_
	: Type {
	static C_Type _c_type = C_Type.Acquire( C699.C.Void ) ;
	protected override string symbol { get { return Arg1.Token ; } }
	protected override C699.c c { get { return C699.C.Void ; } }
	protected override C_Type c_type { get { return _c_type ; } }
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
	}

}