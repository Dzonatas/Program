//|#(!)using System;
using System.Text.RegularExpressions ;
using System.Diagnostics ;

public partial class A335
{
static object[] freeset = new object[0] ;

public class Object : Stack.Item
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
	public CallConv List
		{
		get { current = null ; return this ; }
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
	[Automaton] public class   callConv__instance__callConv
		: CallConv	{}

	[Automaton] public class   callConv_callKind
		: CallConv {}
	}

[Automaton] class   classDecl_methodHead_methodDecls____
	: Class.Decl	{
	protected override void main()
		{
		var methodHead = (Argv[1] as Method.Head) ;
		methodHead.DeclList = Method.Decl.List ;
		string symbol = Class.Type + methodHead.Name ;
		Instr.WriteList( symbol, Instr.List ) ;
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
	: Automatrix {}

}


namespace org.com.net.edu.mil.us
	{
	//(([zero-copy|copy-paste]-buffer))-to-the-wall.
	}