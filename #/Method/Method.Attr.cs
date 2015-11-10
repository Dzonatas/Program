partial class A335
{
public partial class Method
	{
	public partial class Attr : Automatrix
		{
		public bool Static
			{
			get {
				for( Attr i = this ; i is Attr ; i = i.Argv[1] as Attr )
					if( i is methAttr_methAttr__static_ )
						return true ;
				return false ;
				}
			}
		public bool Virtual
			{
			get {
				for( Attr i = this ; i is Attr ; i = i.Argv[1] as Attr )
					if( i is methAttr_methAttr__virtual_ )
						return true ;
				return false ;
				}
			}
		}
	}

public partial class   methAttr_methAttr__static_
	: Method.Attr   {}

public partial class   methAttr_methAttr__specialname_
	: Method.Attr   {}

public partial class   methAttr_methAttr__public_
	: Method.Attr {}

public partial class   methAttr_methAttr__hidebysig_
	: Method.Attr {}

public partial class   methAttr_methAttr__rtspecialname_
	: Method.Attr {}

public partial class   methAttr_methAttr__private_
	: Method.Attr {}

public partial class   methAttr_methAttr__virtual_
	: Method.Attr {}
}
