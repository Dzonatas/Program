partial class A335
{
public partial class Instr : Automatrix
	{
	public partial class None : Instr
		{
		protected override void render()
			{
			NONE() ;
			}
		protected virtual void NONE() {}
		}
	}

public partial class   instr_INSTR_NONE
	: Instr.None    {
	protected override void NONE()
			{
		var d = oprand.C ;
		switch( Op )
			{
			case "LDARG_0":
				{
				C_Type type ;
				if( decl.Node.Head.CallConvInstance )
					type = d.Method.ThisType ;
				else
					type = d.Method.Args[0] ;
				d.Statement( C699.Stack.Assign( new C699.c("args[0]") ) ) ;
				C.Push( type ) ;
				break ;
				}
			case "RET":
				{
				var typedef = Program.C_TypeDef.Acquire("string") ;
				string field = typedef.Struct[1] ;
				foreach( object z in freeset )
					{
					if( z is int )
						d.Statement( C699.Free("("+'('+C699.String+'*'+')'+C699.Stack.Index((int)z)+')'+"->"+field ) ) ;
					}
				freeset = new object[0] ;
				break ;
				}
			case "LDC_I4_0" :
				d.Statement( C699.Stack.Assign(C699.C.Zero) ) ;
				C.Push( C_I4_0 ) ;
				break ;
			case "LDC_I4_1" :
				d.Statement( C699.Stack.Assign(C699.C.One) ) ;
				C.Push( C_I4_1 ) ;
				break ;
			case "LDC_I4_2" :
				d.Statement( C699.Stack.Assign(C699.C.Two) ) ;
				C.Push( C_I4_2 ) ;
				break ;
			case "LDC_I4_3" :
				d.Statement( C699.Stack.Assign(C699.C.Three) ) ;
				C.Push( C_I4_3 ) ;
				break ;
			case "DUP" :
				{
				var t = C.Peak() ;
				d.Push( t.StackElement, t.Type ) ;
				}
				break ;
			case "LDELEM_REF" :
				{
				C.Pop() ;
				var e = C699.Stack.Deref(C699.C.Int) ;
				C.Pop() ;
				var r = C699.Stack.CastIndex(C699.String) ;
				oprand.C.Statement(
					C699.Stack.Assign(  C699.Array( r, e, C699.String )  )
					) ;
				C.Push( C_Type.Acquire( "_C_" + Op ) ) ;
				}
				break ;
			case "STELEM_REF" :
				{
				C.Pop() ;
				var r = C699.Stack.CastIndex(C699.String) ;
				C.Pop() ;
				var e = C699.Stack.Deref(C699.C.Int) ;
				C.Pop() ;
				var a = C699.Stack.Array(e, C699.String) ;
				d.Statement( a.Equate( r ) ) ;
				}
				break ;
			case "STLOC_0" :
				C.Pop() ;
				stloc( 0 ) ;
				break ;
			case "STLOC_1" :
				C.Pop() ;
				stloc( 1 ) ;
				break ;
			case "STLOC_2" :
				C.Pop() ;
				stloc( 2 ) ;
				break ;
			case "STLOC_3" :
				C.Pop() ;
				stloc( 3 ) ;
				break ;
			case "LDLOC_0" :
				C.Push( ldloc( 0 ) ) ;
				break ;
			case "LDLOC_1" :
				C.Push( ldloc( 1 ) ) ;
				break ;
			case "LDLOC_2" :
				C.Push( ldloc( 2 ) ) ;
				break ;
			case "LDLOC_3" :
				C.Push( ldloc( 3 ) ) ;
				break ;
			case "ADD" :
				{
				var t = C.Pop() ;
				C699.c b = C699.Stack.Deref(C699.C.Int) ;
				C.Pop() ;
				C699.c a = C699.Stack.Deref(C699.C.Int) ;
				d.Push( a.plus(b), t.Type ) ;
				}
				break ;
			default :
				log( "[INSTR_NONE] Defaulted on " + Op ) ;
				return ;
			}
		}
	void stloc( int i )
		{
		var loc = decl.Node.Head.Locals[i] ;
		var l = C699.C.Literal( loc.Symbol ) ;
		#if HPP
		C699.c c = c.Local( loc._Type, l ) ;
		//oprand.C.Statement( c.Equate( C699.Stack.Deref(C.StackOffset,type) ) ) ;
		throw new System.NoteImplementedException() ;
		#else
		oprand.C.Statement( l.Equate( C699.Stack.Deref(loc.Type) ) ) ;
		#endif
		}
	C_Type ldloc( int i )
		{
		var loc = decl.Node.Head.Locals[i] ;
		#if HPP
		throw new System.NoteImplementedException() ;
		#endif
		C699.c c = C699.C ;
		if( ((string)(C699.c)loc.Type).StartsWith("struct ") )
			c = new C699.c( "&"+loc.Symbol ) ;
		else
			c = new C699.c( loc.Symbol ) ;
		oprand.C.Statement( C699.Stack.Assign(c) ) ;
		return loc.Type ;
		}
	}
}
