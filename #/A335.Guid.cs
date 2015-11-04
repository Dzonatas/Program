partial class A335
{
sealed public class Guid
	{
	static int id = 0 ;
	System.Guid guid ;
	static public Guid NewGuid()
		{
		#if RELEASE
		return new Guid() { guid = System.Guid.NewGuid() } ;
		#else
		return new Guid() { guid = new System.Guid( ++id, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ) } ;
		#endif
		}
	public string ToID()
		{
		return System.Text.RegularExpressions.Regex.Replace
			(this.ToString(), "[^A-Za-z_0-9]", "_").ToLower() ;
		}
	public override string ToString()
		{
		return guid.ToString() ;
		}
	}
}

