public partial class A335
{
public partial class Type : Automatrix
	{
	static public implicit operator string( Type n ) { return n.symbol ; }
	protected virtual string symbol { get { return null ; } }
	}

public partial class   type__int32_
	: Type {
	protected override string symbol { get { return Arg1.Token ; } }
	}

public partial class   type__object_
	: Type {
	protected override string symbol { get { return Arg1.Token ; } }
	}

public partial class   type__valuetype__className
	: Type {
	protected override string symbol { get { return Arg1.Token + " " + Arg2.ResolveType() ; } }
	}

public partial class   type__class__className
	: Type {
	protected override string symbol { get { return Arg1.Token + " " + Arg2.ResolveType() ; } }
	}

public partial class   type__string_
	: Type {
	protected override string symbol { get { return Arg1.Token ; } }
	}

public partial class   type__void_
	: Type {
	protected override string symbol { get { return Arg1.Token ; } }
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