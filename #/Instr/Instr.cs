partial class A335
{
public partial class Instr : Automatrix
	{
	protected A335.Method.Decl decl ;
	public A335.Method.Decl Decl
		{
		set { decl = value ; }
		}
	public class Oprand
		{
		Instr _instr ;
		Program.C_Oprand c_oprand ;
		/*
		static Oprand current ;
		static public A335.Program.C_Oprand Current
			{
			get { return current.c_oprand ; }
			}
		*/
		public A335.Program.C_Oprand C
			{
			get { return c_oprand ; }
			}
		public bool BrTarget
			{
			set { c_oprand.BrTarget = value ; }
			}
		public Oprand( Instr instr, string op )
			{
			c_oprand = instr.decl.Node.Head.NewOprand( op ) ;
			op = c_oprand.Instruction ;
			log( "[Instr.Oprand] "+ op ) ;
			//current = this ;
			_instr = instr ;
			}
		static public void Declared()
			{
			//current = null ;
			}
		}
	protected string Op
		{
		get { return oprand.C.Instruction ; }
		}
	protected Oprand oprand ;
	static public implicit operator C699.c( Instr i )
		{
		#if HPP
		return i.oprand.C ;
		#else
		var s = new System.IO.StringWriter() ;
		foreach( C699.c l in i.oprand.C.GCBefore )
			s.WriteLine( l ) ;
		i.oprand.C.WriteTo( s ) ;
		foreach( C699.c l in i.oprand.C.GCAfter )
			s.Write( " ;\n\t"+l ) ;
		return new C699.c( s.ToString() ) ;
		#endif
		}
	virtual protected void _prerender() {}
	protected override void prerender()
		{
		var head = decl.Node.Head ;
		oprand = new Oprand(this,Arg1.Token) ;
		oprand.C.HasArgs = 0 < (
			( head.SigArgs0 == null ? 0	: head.SigArgs0.Count() )
			+ ( head.CallConvInstance ? 1 : 0 ) ) ;
		Oprand.Declared() ;
		_prerender() ;
		}
	public override string ToString()
			{
			return "[Instr] " + (oprand != null ?  oprand.C.Instruction : "" ) ;
			}
	#if HPP
	static public void WriteList( string symbol, Instr instr )
		{
		var sw = Current.Path.CreateText( symbol + ".hpp" ) ;
		for( Instr i = instr ; i is Instr ; i = i.Next )
			i.oprand.C.WriteTo( sw ) ;
		sw.Close() ;
		}
	#endif
	}
}
