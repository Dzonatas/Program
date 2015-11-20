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
				d.Push( C699.Array( value.StackElement, index.StackDeref, value.Type.Spec ), value.Type  ) ;
				}
				break ;
			case "STELEM_REF" :
				{
				var value = C.Pop() ;
				var index = C.Pop() ;
				C.Pop() ;
				var a = C699.Stack.Array(index.StackDeref, value.Type.Spec) ;
				d.Statement( a.Equate( value.StackCast ) ) ;
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
		oprand.C.Statement( l.Equate( C.Pop().StackDeref ) ) ;
		#endif
		}
	void ldloc( int i )
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
		oprand.C.Push( c, loc.Type ) ;
		}
	}
}
