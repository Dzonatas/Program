partial class A335
{
public partial class   compQstring_QSTRING
	: Automatrix
	{
	static public explicit operator string(compQstring_QSTRING qs )
		{
		return qs.Arg1.Token ;
		}
	}
}
