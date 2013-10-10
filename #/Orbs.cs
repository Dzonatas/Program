namespace Application.Orbs
	{
	public abstract class Orbital
		{
		public Orbital
			orbit ,
			internet , s ;
		}
		
	public partial class Orb : Orbital
		{
		static protected Orbital alpha = new Orb() ;

		public Orbital Orbit
			{
			set
				{
				if( orbit == value.orbit )
					return;
				if( value.orbit != null )
					{
					if( value.orbit.internet == value )
						value.orbit.internet = value.s ;
					else
						{
						Orbital o = value.orbit.internet ;
						while( o.s != value )
							o = o.s ;
						o.s = value.s ;
						}
					value.orbit = null ;
					}
				if( orbit == null )
					return ;
				value.orbit       = orbit ;
				value.s           = orbit.internet ;
				orbit.internet    = value ;
				}
			}

		public Orb()
			{
			orbit = alpha ;
			}
		}
	}
