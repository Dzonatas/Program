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
				d.Push( new C699.c("args[0]"), type ) ;
				break ;
				}
			case "RET":
				{
				//d.Statement( C699.C.Return("") ) ;
				break ;
				}
			case "LDC_I4_0" :
				d.Push( C699.C.Zero, C_I4_0 ) ;
				break ;
			case "LDC_I4_1" :
				d.Push( C699.C.One, C_I4_1 ) ;
				break ;
			case "LDC_I4_2" :
				d.Push( C699.C.Two, C_I4_2 ) ;
				break ;
			case "LDC_I4_3" :
				d.Push( C699.C.Three, C_I4_3 ) ;
				break ;
			case "DUP" :
				{
				var t = C.Peak() ;
				d.Push( t.StackElement, t.Type ) ;
				}
				break ;
			case "LDELEM_REF" :
				{
				var index = C.Pop() ;
				var value = C.Pop() ;
				d.Push( C699.Array( value.Type.Spec, value.StackElement, index.StackDeref  ), value.Type.Deref  ) ;
				}
				break ;
			case "STELEM_REF" :
				{
				var value = C.Pop() ;
				var index = C.Pop().StackDeref ;
				var array = C.Pop().StackArray(index) ;
				d.Statement( array.Equate( value.StackCast ) ) ;
				}
				break ;
			case "STLOC_0" :
				stloc( 0 ) ;
				break ;
			case "STLOC_1" :
				stloc( 1 ) ;
				break ;
			case "STLOC_2" :
				stloc( 2 ) ;
				break ;
			case "STLOC_3" :
				stloc( 3 ) ;
				break ;
			case "LDLOC_0" :
				ldloc( 0 ) ;
				break ;
			case "LDLOC_1" :
				ldloc( 1 ) ;
				break ;
			case "LDLOC_2" :
				ldloc( 2 ) ;
				break ;
			case "LDLOC_3" :
				ldloc( 3 ) ;
				break ;
			case "ADD" :
				{
				var t = C.Pop() ;
				var b = t.StackDeref ;
				var a = C.Pop().StackDeref ;
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
		oprand.C.Statement( l.Equate( C.Pop().StackCast ) ) ;
		#endif
		}
	void ldloc( int i )
		{
		var loc = decl.Node.Head.Locals[i] ;
		#if HPP
		throw new System.NoteImplementedException() ;
		#endif
		oprand.C.Push( new C699.c(loc.Symbol), loc.Type ) ;
		}
	}
}
