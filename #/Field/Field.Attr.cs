partial class A335
{
public partial class Field
	{
	public partial class Attr : Automatrix
		{
		public bool Static
			{
			get	{
				foreach( Automatrix a in this )
					if( a is fieldAttr_fieldAttr__static_ )
						return true ;
				return false ;
				}
			}
		public bool Family
			{
			get	{
				foreach( Automatrix a in this )
					if( a is fieldAttr_fieldAttr__family_ )
						return true ;
				return false ;
				}
			}
		}
	}

public partial class   fieldAttr_fieldAttr__assembly_
	: Field.Attr {}

public partial class   fieldAttr_fieldAttr__family_
	: Field.Attr {}

public partial class   fieldAttr_fieldAttr__literal_
	: Field.Attr {}

public partial class   fieldAttr_fieldAttr__private_
	: Field.Attr {}

public partial class   fieldAttr_fieldAttr__static_
	: Field.Attr {}

public partial class   fieldAttr_fieldAttr__public_
	: Field.Attr	{}
}