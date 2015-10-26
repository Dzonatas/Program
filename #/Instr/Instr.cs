public partial class A335
{
public partial class Instr : Automatrix
	{
	Instr next ;
	string code ;
	static Instr list ;
	static Instr previous ;
	static Instr current ;
	static public Instr List
		{
		get { Instr l = list ; list = previous = current = null ; return l ; }
		}
	public Instr Next
		{
		get { return next ; }
		}
	public class Oprand
		{
		Instr _instr ;
		Program.C_Oprand c_oprand ;
		static Oprand current ;
		static public A335.Program.C_Oprand Current
			{
			get { return current.c_oprand ; }
			}
		public A335.Program.C_Oprand C
			{
			get { return c_oprand ; }
			}
		public bool BrTarget
			{
			set { c_oprand.BrTarget = value ; }
			}
		public Oprand( Instr instr )
			{
			c_oprand = A335.Method.Head.Current.NewOprand( op ) ;
			op = c_oprand.Instruction ;
			log( "[Instr.Oprand] "+ op ) ;
			current = this ;
			_instr = instr ;
			}
		static public void Declared()
			{
			current = null ;
			}
		}
	static string op ;
	protected string Op
		{
		set {
			current = this ;
			if( previous != null ) previous.next = current ;
			if( list == null ) list = this ;
			op = value ;
			op = (oprand = new Oprand(this)).C.Instruction ;
			code = op ;
			}
		get { return op ; }
		}
	protected Oprand oprand ;
	static public implicit operator C699.c( Instr i )
		{
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
		previous = current ;
		}
	public override string ToString()
			{
			return "[Instr] " + code ;
			}
	static public void WriteList( string symbol, Instr instr )
		{
		var sw = Current.Path.CreateText( symbol + ".hpp" ) ;
		for( Instr i = instr ; i is Instr ; i = i.Next )
			i.oprand.C.WriteTo( sw ) ;
		sw.Close() ;
		}
	}
}
