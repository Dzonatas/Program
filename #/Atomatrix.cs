namespace Application.Atomatrice
	{
	using Application.Orbs ;

	public class Atomatrix : Orb
		{
		protected Atomatrix
			precursor ,
			intranet , z ;

		public Atomatrix Precursor
			{
			set
				{
				if( precursor == value.precursor )
					return;
				if( value.precursor != null )
					{
					if( value.precursor.intranet == value )
						value.precursor.intranet = value.z ;
					else
						{
						Atomatrix a = value.precursor.intranet ;
						while( a.z != value )
							a = a.z ;
						a.z = value.z ;
						}
					}
				
				value.precursor = precursor ;
				
				if( precursor != null )
					{
					value.z		        = precursor.intranet ;
					precursor.intranet	= value ;
					}
				}
			}

		public Atomatrix( Orb orb )
			{
			Orbit = orb ;
			}
		}
	}

namespace Application.Orbs
	{
	using Application.Atomatrice ;
	
	public partial class Orb : Orbital
		{
		public Orb( Atomatrix a )
			{
			orbit = (Orb) a ;
			}
		}
		
	public class Atom<T> : Atomatrix where T : Orb
		{
		static protected Orb beta = new Orb() ;
			
		public Atom() : base( beta )
			{
			}
		}
	}
