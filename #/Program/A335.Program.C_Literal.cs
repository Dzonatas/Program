partial class A335
{
partial class Program
	{
	C_Literal[] register ;
	public struct C_Literal
		{
		public C_Function  Function ;
		public C699.c      Type ;
		public C699.c      Name ;
		static public implicit operator string( C_Literal l )
			{
			return l.Name ;
			}
		}
	public C_Literal this[int n]
		{
		get {
			return register[n] ;
			}
		}
	public C_Literal this[string name]
		{
		get {
			foreach( C_Literal literal in register )
				if( name == literal.Name )
					return literal ;
			throw new System.FieldAccessException( name ) ;
			}
		}
	}
}
