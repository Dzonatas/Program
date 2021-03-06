partial class A335
{
public partial class Instr : Automatrix
	{
	public partial class None : Instr {}
	}

public partial class   instr_INSTR_NONE
	: Instr.None    {
	protected override void render()
			{
		var d = oprand.C ;
		switch( Op )
			{
			case "LDARG_0":
				{
				if( decl.Node.Head.CallConvInstance )
					{
					var typeSpec = new C699.c(decl.Node.Head.ClassType) ;
					d.Push( new C699.c("argv[0]"), C_Type.Acquire(C699.C.Struct(typeSpec).p) ) ;
					}
				else
					d.Push( new C699.c("argv[0]"), d.Method.Args[0] ) ;
				break ;
				}
			case "LDARG_1":
				{
				if( decl.Node.Head.CallConvInstance )
					d.Push( new C699.c("argv[1]"), d.Method.Args[0] ) ;
				else
					d.Push( new C699.c("argv[1]"), d.Method.Args[1] ) ;
				break ;
				}
			case "LDARG_2":
				{
				oprand.C.Statement(new C699.c("/*new implementation*/")) ;
				d.Push( C699.C.Three, C_I4_3 ) ; //bogus
				break ;
				}
			case "LDARG_3":
				{
				oprand.C.Statement(new C699.c("/*new implementation*/")) ;
				d.Push( C699.C.Three, C_I4_3 ) ; //bogus
				break ;
				}
			case "RET":
				{
				if( C699.Stack.Offset == 1 )
					{
					var r = C.Pop() ;
					d.Statement( C699.C.Return( r.StackCast ) ) ;
					}
				else
				if( C699.Stack.Offset > 1 )
					throw new System.NotImplementedException() ;
				break ;
				}
			case "LDC_I4_M1" :
				d.Push( C699.C.Minus.One, C_I4_M1 ) ;
				break ;
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
			case "LDC_I4_4" :
				d.Push( C699.C.Four, C_I4_4 ) ;
				break ;
			case "LDC_I4_5" :
				d.Push( C699.C.Five, C_I4_5 ) ;
				break ;
			case "LDC_I4_6" :
				d.Push( C699.C.Six, C_I4_6 ) ;
				break ;
			case "LDC_I4_7" :
				d.Push( C699.C.Seven, C_I4_7 ) ;
				break ;
			case "LDC_I4_8" :
				d.Push( C699.C.Eight, C_I4_8 ) ;
				break ;
			case "LDC_I4_9" :
				d.Push( C699.C.Nine, C_I4_9 ) ;
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
			case "STELEM_I2" :
				{
				C.Pop() ;
				C.Pop() ;
				C.Pop() ;
				//d.Statement( array.Equate( value.StackCast ) ) ;
				oprand.C.Statement(new C699.c("/*new implementation*/")) ;
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
				d.Push( new C699.c("(intptr_t)"+ a.plus(b)), t.Type ) ;
				}
				break ;
			case "SUB" :
				{
				var t = C.Pop() ;
				var b = t.StackDeref ;
				var a = C.Pop().StackDeref ;
				d.Push( new C699.c("(intptr_t)"+a.sub(b)), t.Type ) ;
				}
				break ;
			case "NOP" :
				d.Statement( new C699.c( "/* nop */" ) ) ;
				break ;
			case "POP" :
				C.Pop() ;
				oprand.C.Statement(new C699.c("/*new implementation*/")) ;
				break ;
			case "LDLEN" :
				{
				var vt = C.Pop() ;
				oprand.C.Statement( new C699.c(C699.KeyedWord.Long+" _length = (("+C699.KeyedWord.Int+"*)"+vt.StackElement+")[-1]") ) ;
				d.Push( new C699.c("_length"), C_Type.Acquire(C699.KeyedWord.Long) ) ;
				}
				break ;
			case "CONV_I4" :
				{
				var vt = C.Pop() ;
				oprand.C.Statement(new C699.c("/*new implementation*/")) ;
				d.Push( vt.StackElement, vt.Type ) ;
				}
				break ;
			case "THROW" :
				{
				C.Pop() ;
				oprand.C.Statement(new C699.c("/*new implementation*/")) ;
				}
				break ;
			case "LDNULL" :
				d.Push( C699.C.Zero, C_Type.Acquire( C699.C.Void.p ) ) ;
				break ;
			default :
				throw new System.NotImplementedException( Op ) ;
			}
		}
	void stloc( int i )
		{
		var loc = decl.Node.Head.Locals[i] ;
		var l = C699.C.Literal( loc.Symbol ) ;
		var vt = C.Pop() ;
		oprand.C.Statement( l.Equate( vt.StackCast ) ) ;
		var ct1 = ((string)C699.String.p).Trim() ;
		var ct2 = ((string)((C_Type)loc.Type).Spec).Trim() ;
		if( ct1 == ct2 )
			{
			if( vt.Symbol == null )
				{
				#if DEBUG
				oprand.C.GCAfter.Add( new C699.c( "// nop.gc" ) ) ;
				#endif
				}
			else
				{
				oprand.C.GCAfter.Add(
					C699.C.If( ""+loc.Symbol+"_mp.managed && ! --"+loc.Symbol+"_mp.managed",
						C699.Free( ""+loc.Symbol+"_mp.pointer" )) ) ;
				oprand.C.GCAfter.Add( new C699.c( ""+loc.Symbol+"_mp = "+vt.Symbol+"_mp" ) ) ;
				}
			}
		}
	void ldloc( int i )
		{
		var loc = decl.Node.Head.Locals[i] ;
		if( loc.Type is type__int32_ )
			oprand.C.Push( new C699.c("(intptr_t)"+loc.Symbol), loc.Type ) ;
		else
			oprand.C.Push( new C699.c(loc.Symbol), loc.Type ) ;
		}
	}
}
