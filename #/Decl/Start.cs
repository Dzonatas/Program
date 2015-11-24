partial class A335
{
public partial class   START_decls
	: _START {
	static public implicit operator Decls( START_decls sd )
		{
		return sd.Argv[1] as Decls ;
		}
	}
}