using System.Collections.Specialized ;
using System.Diagnostics ;
using System.Collections ;
using System;

//http://icyspherical.blogspot.com/2012/05/parameters-minimal-c-singleton-edition.html

namespace Cluster
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
			parameter.Add( "shell",    "false"  ) ;
			parameter.Add( "input",    "false"  ) ;
			parameter.Add( "output",   "false"  ) ;
			parameter.Add( "build",    "false"  ) ;
			parameter.Add( "headless", "false" ) ;	//https://code.google.com/p/dpkg-scripts/wiki/HOWTO#Creating_a_Simple_Package
			parameter.Add( "reflection", "false" ) ;
			#if DEBUG
				parameter.Add( "debug",    "true"  ) ;
				parameter.Add( "point",    "0.0"   ) ;
				parameter.Add( "endpoint", "0.0"   ) ;
				parameter.Add( "geometry", "false" ) ;
				parameter.Add( "fini",     "true"  ) ;
			#endif
			}

		static void parse( string[] args )
			{
			foreach( string s in args )
				{
				var m = System.Text.RegularExpressions.Regex.Match( s, @"^(-{1,2}|/)((?<key>\S+)=(?<value>.+)$|(?<option>\S+)[^=]\s*$)" ) ;
	        	if( ! m.Success )
	        		{
	        		Debug.WriteLine( "Invalid Parameter: {0}", s ) ;
	        		continue ;
	        		}
				var o = m.Groups[ "option" ] ;
				var k = m.Groups[ "key"    ] ;
				var v = m.Groups[ "value"  ] ;
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
