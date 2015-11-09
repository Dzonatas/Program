partial class A335
{
public partial class Instr : Automatrix
	{
	protected A335.Method.Decl decl ;
	public A335.Method.Decl Decl
		{
		set { decl = value ; oprand = new Oprand(this,Arg1.Token) ; }
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
	virtual protected void render() {}
	bool rendered ;
	static public implicit operator C699.c( Instr i )
		{
		if( ! i.rendered )
			{
			i.render() ;
			i.rendered = true ;
			}
		#if HPP
		return i.oprand.C ;
		#else
		var s = new System.IO.StringWriter() ;
		i.oprand.C.WriteTo( s ) ;
		return new C699.c( s.ToString() ) ;
		#endif
		}
	public bool C_OprandHasArgs
		{
		set { oprand.C.HasArgs = value ; }
		}
	public void Defined()
		{
		Oprand.Declared() ;
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
