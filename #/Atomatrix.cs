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

namespace Application.Asteroid //Application.Stone[5,6] : Orbs
	{
	namespace Atomatrice.Five // : (using) Atomatrice
		{
		//restricted interface {...}
		}
	namespace Atomatrice.Six // : (using) Atomatrice
		{
		//$interface {...}
		}
	}

namespace Application.YYBACKUP //Application.HTTP[.post,.get] : Orbs#Resources
	{
	namespace Atomatrice.Seven.Eight.Nine // : (using) Atomatrice
		{
		//C++0xC++0xC++...
		}
	}

namespace Application.Twelve //Application.HTTP[.post,.get] : Orbs#Resources
	{
	namespace Zero
		{
		namespace Zero
			{
			namespace Zero
				{
				//s//$(CPP)((VERSION(((GNU#)))))///bin/#.0.0.0.exe//
				using Logo ;

					Plot face on canvas as icon ;
				stamp rectangle as hypercard.

					Browse inventory as source ;
				attach to communicator.

					Sort by face recognition ;
				categorize by name ;
				pivot index by keyed form ;
				override sort by typeof(street) ;
				drone up.

				Used [QR] exit by android logo.
				}
			}
		}
	}
