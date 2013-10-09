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
			#if DEBUG
				parameter.Add( "debug",  "true" ) ;
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
