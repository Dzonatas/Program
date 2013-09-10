/* License: GNU Public License version 2, or any later version of the GNU Public License.
**          http://www.gnu.org/licenses/gpl-2.0.html
** Copyright (C) 2009 Ballard, Jonathan H. <dzonatas@dzonux.net> 
*/

using Snowglobe ;
using System ;
using Gtk ;

namespace Icesphere
	{
	public class Tag
		{
		public static TextTag       Muted         = new TextTag("muted") ;
		public static TextTag       IM            = new TextTag("im") ;
		public static TextTag       Time          = new TextTag("time") ;
		public static TextTag[]     System        = { new TextTag("system0"),  new TextTag("system1") } ;
		public static TextTag[]     User          = { new TextTag("user0"),    new TextTag("user1") } ;
		public static TextTag[]     Agent         = { new TextTag("agent0"),   new TextTag("agent1") } ;
		public static TextTag[]     Error         = { new TextTag("error0"),   new TextTag("error1") } ;
		public static TextTag[]     Owner         = { new TextTag("owner0"),   new TextTag("owner1") } ;
		public static TextTag[]     Object        = { new TextTag("object0"),  new TextTag("object1") } ;
		public static TextTag[]     Link          = { new Linkage("link0"),    new Linkage("link1") } ;
		public static TextTag[]     Default       = { new TextTag("default0"), new TextTag("default1") } ;
		public static TextTagTable  Table         = new TextTagTable() ;

		public static void Update()
			{
			Muted.ForegroundGdk          = UI.Color.AluminiumLight ;
			IM.ForegroundGdk             = UI.Color.AluminiumLight ;
			Time.ForegroundGdk           = UI.Color.AluminiumMediumDark ;
			int level = (int) Snowglobe.ChatAudibleLevel.Fully ;
			System[level].ForegroundGdk  = UI.Color.AluminiumLight ;
			User[level].ForegroundGdk    = UI.Color.AluminiumLight ;
			Agent[level].ForegroundGdk   = UI.Color.AluminiumLight ;
			Error[level].ForegroundGdk   = UI.Color.ScarletRedLight ;
			Owner[level].ForegroundGdk   = UI.Color.ButterLight ;
			Object[level].ForegroundGdk  = UI.Color.ChameleonLight ;
			Link[level].ForegroundGdk    = UI.Color.SkyBlueLight ;
			Default[level].ForegroundGdk = UI.Color.AluminiumLight ;
			level = (int) Snowglobe.ChatAudibleLevel.Barely ;
			System[level].ForegroundGdk  = UI.Color.AluminiumMediumDark ;
			User[level].ForegroundGdk    = UI.Color.AluminiumMediumDark ;
			Agent[level].ForegroundGdk   = UI.Color.AluminiumMediumDark ;
			Error[level].ForegroundGdk   = UI.Color.ScarletRedDark ;
			Owner[level].ForegroundGdk   = UI.Color.ButterDark ;
			Object[level].ForegroundGdk  = UI.Color.ChameleonDark ;
			Link[level].ForegroundGdk    = UI.Color.SkyBlueDark ;
			Default[level].ForegroundGdk = UI.Color.AluminiumLight ;
			}
		public class TextTagTable : Gtk.TextTagTable
			{
			public TextTagTable()
				{
				Add( Tag.Muted ) ;
				Add( Tag.IM ) ;
				Add( Tag.Time ) ;
				for( int level=0 ; level < 2 ; level++ )
					{
					Add( Tag.System[level] ) ;
					Add( Tag.User[level] ) ;
					Add( Tag.Agent[level] ) ;
					Add( Tag.Error[level] ) ;
					Add( Tag.Owner[level] ) ;
					Add( Tag.Object[level] ) ;
					Add( Tag.Link[level] ) ;
					Add( Tag.Default[level] ) ;
					}
				}
			}
		public class Linkage : TextTag
			{
			public Linkage( string text )
				: base( text ) {}
			public static TextTag HotSpot( TextTag[] tags )
				{
				if( tags != null )
					foreach( TextTag tag in tags )
						if( tag is Linkage )
							return tag ;
				return null ;
				}
			}
		public class AgentUUID : Linkage
			{
			static string        prefix = "AGENT:" ;
			AgentUUID( UUID uuid )
				: base( prefix + uuid ) {}
			public static TextTag Lookup( UUID uuid )
				{
				TextTag tag = Table.Lookup( prefix + uuid ) ;
				if( tag != null )
					return tag ;
				Table.Add( tag = new AgentUUID(uuid) ) ;
				return tag ;
				}
			public UUID UUID
				{
				get { return new UUID( (string) Name.Remove( 0, prefix.Length ) ) ; }
				}
			}
			
		static void onSavedSettingsQueried()
			{
			Gtk.Application.Invoke( delegate { Update() ; } ) ;
			}
			
		static Tag()
			{
			Snowglobe.SavedSettings.WhenQueried( onSavedSettingsQueried ) ;
			}
		}
	}