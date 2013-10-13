using System.Collections.Specialized ;
using System.Text.RegularExpressions ;
using System.Diagnostics ;
using System.Collections ;
using System;

//http://icyspherical.blogspot.com/2012/05/parameters-minimal-c-singleton-edition.html

namespace Application
	{
	[Program.Singleton]
	public sealed class Parameter
		{
		static StringDictionary parameter = new StringDictionary() ;

		private Parameter()
			{
			Program.Parse       += parse ;
			}

		~Parameter()
			{
			Program.Parse       -= parse ;
			}
        
		static Parameter()
			{
			parameter.Add( "synopsis", "false" ) ;
			#if DEBUG
				parameter.Add( "debug",    "true"  ) ;
				parameter.Add( "point",    "0.0"   ) ;
				parameter.Add( "endpoint", "0.0"   ) ;
				parameter.Add( "geometry", "false" ) ;
				parameter.Add( "snake",    "true"  ) ;
				parameter.Add( "serpent",  "false" ) ;
				parameter.Add( "fini",     "true"  ) ;
			#endif
			#if DEBIAN
				parameter.Add( "snake",    "false"  ) ;
				parameter.Add( "shark",    "true"   ) ;
			#endif
			#if METH || KNOPPIX
				parameter.Add( "shark",     "true"   ) ;
				parameter.Add( "man-o-war", "true"   ) ;
			#endif
			}

		static void parse( string[] args )
			{
			foreach( string s in args )
				{
				Match m = Regex.Match( s, @"^(-{1,2}|/)((?<key>\S+)=(?<value>.+)$|(?<option>\S+)[^=]\s*$)" ) ;
	        	if( ! m.Success )
	        		{
	        		Debug.WriteLine( "Invalid Parameter: {0}", s ) ;
	        		continue ;
	        		}
				Group o = m.Groups[ "option" ] ;
				Group k = m.Groups[ "key"    ] ;
				Group v = m.Groups[ "value"  ] ;
				if( ! String.IsNullOrEmpty( o.Value ) )
					parameter[ o.Value ] = "true" ;
				else
					{
					parameter[ k.Value ] = v.Value ;
					}
				}
			}
			
		static public string Value( string key )
			{
			return parameter[ key ] ; 
			} 
		}
	}
