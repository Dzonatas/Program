/* License: GNU Public License version 2, or any later version of the GNU Public License.
**          http://www.gnu.org/licenses/gpl-2.0.html
** Copyright (C) 2009 Ballard, Jonathan H. <dzonatas@dzonux.net> 
*/

using System.Collections.Generic ;
using System.Collections ;
using System ;

namespace Snowglobe
	{
	[Status.Startup]
	public sealed class GestureManager
		{
		static public event Action<MultiGesture>       Changed     = delegate { } ;
		static Dictionary< UUID, MultiGesture >        active      = new Dictionary< UUID, MultiGesture >() ;

		static public Dictionary< UUID, MultiGesture > Active
			{
			get { return active ; }
			}
			
		class QueryActiveGestures : REST.Get
			{
			override protected string  Resource   { get { return "GestureManager/Items" ; } }
			override protected string  XML        { set { GestureManager.updateActive( value ) ; } }
			}

		class QueryPlayGesture : REST.Post
			{
			UUID id ;
			override protected string  Resource   { get { return "GestureManager/PlayGesture/" + id ; } }
			override protected string  XML        { set { } get { return "<llsd/>" ; } }
			public QueryPlayGesture( UUID id )
				{
				this.id = id ;
				}
			}
			
		static public void NotifyChanged( MultiGesture g )
			{
			Changed( g ) ;
			}

		static internal void updateActive( string xml )
			{
			Scalar s     = new Scalar() ;
			s.XML        = xml ;
			foreach( Scalar id in s )
				Activate( Inventory.Item.Find( (UUID) id ) ) ;
			}

		static public void Activate( Inventory.Item item )
			{
			lock( active )
				{
				if( active.ContainsKey( item.ID ) )
					return ;
				active[item.ID] = new MultiGesture( item ) ;
				}
			}

		static public void Deactivate( Inventory.Item item )
			{
			lock( active )
				{
				if( ! active.ContainsKey( item.ID ) )
					return ;
				active.Remove( item.ID ) ;
				}
			}

		static public string TriggerFromAndTrim( string text )
			{
			string trigger     = null ;
			char[] whitespace  = null ; 
			MultiGesture g     = null ;
			if( text == null || text.Trim() == "" )
				return "" ;
			string[] split     = text.Split( whitespace, StringSplitOptions.RemoveEmptyEntries ) ;
			foreach( KeyValuePair< UUID, MultiGesture > kv  in active )
				{
				MultiGesture m = kv.Value ;
				if( m.Loaded && m.Trigger.Length > 0 )
					{
					// TODO: redo this with Regex match, maybe faster
					trigger = m.Trigger ;
					foreach( string s in split )
						if( String.Compare( trigger, s, StringComparison.CurrentCultureIgnoreCase ) == 0 )
							{
							g = m ;
							break ;
							}
					if( g != null )
						break ;
					}
				}
			string replace = null ;
			if( g == null )
				trigger = null ;
			else
				{
				REST.Queue( new QueryPlayGesture( g.ID ) ) ;
				trigger = g.Trigger ;
				replace = g.ReplaceText.Trim() ;
				if( replace.Length == 0 )
					replace = null ;
				}
			// TODO: Regex here also, use match from above for replace
			string result = "" ;
			foreach( string s in split )
				{
				if( result.Length > 0 )
					result += " " ;
				if( replace != null && String.Compare( trigger, s, StringComparison.CurrentCultureIgnoreCase ) == 0 )
					{
					result += replace ;
					replace = null ;
					}
				else
					result += s ;
				}
			return result ;
			}


		private GestureManager()
			{
			}

		static GestureManager()
			{
			Interface.LoginComplete += () => REST.Queue( new QueryActiveGestures() ) ;
			}
		}
	}