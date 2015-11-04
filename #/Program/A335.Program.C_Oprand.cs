using System.Collections.Generic ;
using System.Text.RegularExpressions ;
using System.Extensions ;

partial class A335
{
partial class Program
	{
	public class C_Oprand
		{
		C_Label label ;
		C_Function function ;
		public string Instruction ;
		public string ID ;
		public bool HasArgs ;
		public bool BrTarget ;
		List<C699.c> list = new List<C699.c>() ;
		public System.Action<C_Function> Evaluate = (c) => {} ;
		public C_Label Label
			{
			set { label = value ; }
			get { return label ; }
			}
		public C_Method Method
			{
			get { return function.Method ; }
			}
		public C_Oprand( C_Function function, string instr )
			{
			this.function = function ;
			ID = System.Guid.NewGuid().ToID() ;
			Instruction = System.Text.RegularExpressions.Regex.Replace( instr, "[^A-Za-z_0-9]", "_").ToUpper() ;
			Evaluate = (c) => { foreach( C699.c s in list )	c.Statement( s ) ; } ;
			}
		static public implicit operator C699.c( C_Oprand d )
			{
			if( d.BrTarget )
				return d.list[0] ;
			return C699.C.Function( d.Instruction, d.ID,"stack " + ( d.HasArgs ? ", args" : "" ) ) ;
			}
		static public explicit operator string( C_Oprand d )
			{
			return ((C699.c)d) ;
			}
		public C_Oprand GotoStatement( string label )
			{
			if( ! BrTarget )
				throw new System.NotImplementedException() ;
			list.Add( C699.C.Goto( label ) ) ;
			return this ;
			}
		public C_Oprand IfGotoStatement( string label )
			{
			if( ! BrTarget )
				throw new System.NotImplementedException() ;
			var f = C699.C.Function( Instruction, ID,"stack " + ( HasArgs ? ", args" : "" ) ) ;
			list.Add( C699.C.If( f, C699.C.Goto( label ) ) ) ;
			return this ;
			}
		public C_Oprand Statement( C699.c c )
			{
			list.Add( c ) ;
			return this ;
			}
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