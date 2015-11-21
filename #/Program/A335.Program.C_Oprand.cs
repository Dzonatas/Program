using System.Collections.Generic ;
using System.Extensions ;

partial class A335
{
partial class Program : C699
	{
	public class C_Oprand : Program
		{
		C_Function function ;
		public string Instruction ;
		public string ID ;
		public bool HasArgs ;
		public bool BrTarget ;
		List<C699.c> list = new List<C699.c>() ;
		public System.Action<C_Function> Evaluate = (c) => {} ;
		public C_Method Method
			{
			get { return function.Method ; }
			}
		public C_Oprand( C_Function function, string instr )
			{
			this.function = function ;
			ID = A335.Guid.NewGuid().ToID() ;
			Instruction = System.Text.RegularExpressions.Regex.Replace( instr, "[^A-Za-z_0-9]", "_").ToUpper() ;
			Evaluate = (c) => { foreach( C699.c s in list )	c.Statement( s ) ; } ;
			}
		static public implicit operator C699.c( C_Oprand d )
			{
			if( d.BrTarget )
				return d.list[0] ;
			return C.Function( d.Instruction, d.ID,"stack " + ( d.HasArgs ? ", args" : "" ) ) ;
			}
		static public explicit operator string( C_Oprand d )
			{
			return ((C699.c)d) ;
			}
		public C_Oprand GotoStatement( string label )
			{
			if( ! BrTarget )
				throw new System.NotImplementedException() ;
			list.Add( C.Goto( label ) ) ;
			return this ;
			}
		public C_Oprand IfGotoStatement( string label )
			{
			if( ! BrTarget )
				throw new System.NotImplementedException() ;
			var f = C.Function( Instruction, ID,"stack " + ( HasArgs ? ", args" : "" ) ) ;
			list.Add( C.If( f, C.Goto( label ) ) ) ;
			return this ;
			}
		public C_Oprand Statement( C699.c c )
			{
			list.Add( c ) ;
			return this ;
			}
		public void Push( C699.c value, C_Type type )
			{
			Statement( Stack.Assign( value, type.Spec ) ) ;
			Push( type ) ;
			}
		public void PushRef( C_ValueType vt )
			{
			for( int i = 0 ; i < freeset.Length ; i++ )
				if( freeset[i].Symbol == vt.Symbol )
					freeset[i].Offset++ ;
			vt.Type = vt.Type.Ref ;
			Statement( Stack.Assign( new c("&"+vt.Symbol), vt.Type.Spec ) ) ;
			stack[stack_offset] = vt ;
			stack_offset++ ;
			}
		public C_ValueType Allocate(C_Type type)
			{
			var vt = new C_ValueType()
				{
				Symbol = new C_Symbol(),
				Type   = C_Type.Static( type.Deref.Spec )
				} ;
			Statement( C699.C.Struct(vt.Type.TypeSpec, vt.Symbol) ) ;
			System.Array.Resize( ref freeset, freeset.Length+1 ) ;
			freeset[freeset.Length-1] = vt ;
			return vt ;
			}
		/*
		public C_ValueType ConstStatic(C699.c ctype, )
			{
			var vt = new C_ValueType()
				{
				Symbol = new C_Symbol(),
				Type   = C_Type.Static( type.Deref.Spec )
				} ;
			Statement( C699.C.Struct(vt.Type.TypeSpec, vt.Symbol) ) ;
			System.Array.Resize( ref freeset, freeset.Length+1 ) ;
			freeset[freeset.Length-1] = vt ;
			return vt ;
			}
		*/
		public void WriteTo( System.IO.TextWriter tw )
			{
			#if HPP
			if( list.Count == 1 && list[0].Bits == C699.Bit.Goto )
				return ;
			#endif
			var c = C_Function.FromSymbol( Instruction + "$" + ID ) ;
			if( BrTarget )
				c.Bool = true ;
			c.Static = true ;
			c.Inline = true ;
			c.HasArgs = HasArgs ;
			Evaluate(c) ;
			c.WriteTo( tw ) ;
			}
		}
	}
}