partial class C699
{
public         static c                             Write( int fd, string _string, string _length )
	{
	return C.Function("write",new c(fd.ToString()+','+_string+','+_length)) ;
	}
public         static c                             Strncpy( string o, string _string, string _length )
	{
	return C.Function("strncpy",new c(o+','+_string+','+_length)) ;
	}
public         static c                             Alloca( string expr )
	{
	return C.Function("alloca",new c(expr)) ;
	}
}
