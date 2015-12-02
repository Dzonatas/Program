partial class A335
{
public partial class GenArgs : Automatrix
	{
	protected int      index ;
	protected GenArgs  pole ;
	protected override void main()
		{
		if( this is genArgs_type )
			{
			index = 0 ;
			pole  = this ;
			}
		else
			{
			index = (Argv[1] as GenArgs).index + 1 ;
			pole  = (Argv[1] as GenArgs).pole ;
			}
		}
	public Type Index(int x)
		{
		foreach( Automatrix a in this )
			if( a is GenArgs && (a as GenArgs).pole == this.pole && (a as GenArgs).index == x )
				{
				if( (a as GenArgs) is genArgs_type )
					return (a as GenArgs).Argv[1] as Type ;
				else
					return (a as GenArgs).Argv[3] as Type ;
				}
		throw new System.IndexOutOfRangeException("Generic Argument "+x) ;
		}
	}

public partial class genArgs_type
	: GenArgs {}

public partial class genArgs_genArgs_____type
	: GenArgs {}
}
