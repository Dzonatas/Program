//|#(!)using System;
using System.Text.RegularExpressions ;
using System.Collections.Generic ;
using System.Diagnostics ;

public partial class A335
{
static List<object> freeset = new List<object>() ;

class Object : Stack.Item
	{
	protected object[] o ;
	public Object( object[] _ ) : base()
		{
		Debug.WriteLine( "<A Object " + GetType().Name + " />"  ) ;
		o = _ ;
		}
	public Object( int n ) : base()
		{
		Debug.WriteLine( "<A Object " + GetType().Name + ">"  ) ;
		o = new object[n+1] ;
		Stack.Pop( ref o ) ;
		o[0] = this ;
		Debug.WriteLine( "</A>"  ) ;
		}
	public Stack.Item this[int n]
		{
		get { return (Stack.Item) o[n] ; }
		set { o[n] = value ; }
		}
	}


[Automaton] class   classHead___class__classAttr_id_extendsClause_implClause
	: Class.Head	{
	protected override void main()
		{
		ID = Arg3.Token ;
		}
	}

class CallConv : Automatrix
	{
	static CallConv current = null ;
	CallConv next ;
	protected override void main()
		{
		next = current ;
		current = this ;
		}
	static public CallConv List
		{
		get { CallConv l = current ; current = null ; return l ; }
		}
	public bool Instance
		{
		get {
			for( CallConv i = this ; i is CallConv ; i = i.next )
				if( i is callConv__instance__callConv )
					return true ;
			return false ;
			}
		}
	[Automaton] class   callConv__instance__callConv
		: CallConv	{}
	}

[Automaton] class   instr_INSTR_METHOD_callConv_type_typeSpec______methodName_____sigArgs0____
	: Instr.Method	{
	protected override void main()
		{
		string methodName = System.String.Empty ;
		if( Args[6] is methodName___ctor_ )
			methodName = "_ctor" ;
		else
			methodName = "$" + Arg6.Token ;
		this_instr_type = Arg3.ResolveType() ;
		this_instr_class_symbol = Arg4.ResolveTypeSpec() ;
		this_instr_symbol = this_instr_class_symbol + methodName + SigArg.Types() ;
		this_instr_sigArgs = SigArg.Count() ;
		this_instr_sigArg_types = SigArg.Types() ;
		CallConvList = A335.CallConv.List ;
		SigArg.Clear() ;
		}
	}

[Automaton] class   classDecl_methodHead_methodDecls____
	: Class.Decl	{
	protected override void main()
		{
		C.Hangdown() ;
		}
	}

[Automaton] class   compQstring_QSTRING
	: Automatrix	{
	protected override void main()
		{
		this_string = Arg1.Token ;
		}
	}

[Automaton] class   instr_INSTR_STRING_compQstring
	: Automatrix {}

[Automaton] class   decl_classHead_____classDecls____
	: Automatrix	{
	protected override void main()
		{
		Class.Declared() ;
		}
	}

[Automaton] class   _accept_START__end
	: Automatrix	{
	protected override void main()
		{
		if( o[1] != null && o[2] != null )
			return ;
		log( "[OOP!] _accept_START__end != {START,.end}" ) ;
		}
	}

[Automaton] class   classDecl_classHead_____classDecls____
	: Class.Decl	{
	protected override void main()
		{
		Declared() ;
		}
	}

[Automaton] class   customType_callConv_type_typeSpec________ctor______sigArgs0____
	: Automatrix {
	protected override void main()
		{
		SigArg.Clear() ;
		}
	}

}


namespace org.com.net.edu.mil.us
	{
	//(([zero-copy|copy-paste]-buffer))-to-the-wall.
	}