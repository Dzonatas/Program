using System.Text.RegularExpressions ;
using System.Collections.Generic ;
using System.Diagnostics ;
using System.Collections ;
using System.Reflection ;
using System.IO ;
using System ;

public partial class A335
{
int f_rune_sharp ; //#`s (-> ./#/...)
//int f_rune__   ; //# (-> ./#/__.(./#/__...])//
int f_rune___    ; //# (-> ./#/___]
const System.Decimal flag_rune__ = 0.0m ; //# (-> ./#/___.(./#/_]](.ico:EMBED`QR:BIT)
//_FIX[t]:<s>"flags"</>,<s>"flag"</>,_FIXT:LOCATION.[mip]map,_var|enum,_ref:Icesphere.Panel.Map-polar(<F#,-.bat(D)>)
//_FIXT:f_script(<s>javascript</s>+.bat)[,Torqu3D,LLVM][[_loops]]
//_FIXT:_(futh_)-((_cubed)(_second))

// jo <environment,spin{::}>{$loop=true;}  /*$jQ$CPP*/
// jo quant <environment,spin>{.loop.up}   /*$E$#*/_OK,_FIX:_pure_virtual_phantoms.assertion("collusion")
// jo quant <environment,paravirtual>{.loop.down}   /*$E$#*/_NAK:(in-session:...)

partial class Program
	{
	public class C_Function
		{
		//Guid ID ;
		public C_Method Method ;
		public bool Static ;
		public bool Inline ;
		public bool Void
			{
			set {
				if( value )
					Type = C699.C.Void ;
				}
			}
		public bool Bool
			{
			set {
				if( value )
					Type = C699.C.Int ;
				}
			}
		public C699.c Type ;
		C_Symbol symbol ;
		public string Symbol ;
		public bool   HasArgs ;
		public string Args ;
		public bool   Written ;
		public bool   Required ;
		C_Literal let ;
		List<string> list = new List<string>() ;
		public C_Function Let( C_Literal literal )
			{
			let = literal ;
			return this ;
			}
		public C_Function Equal
			{
			get { return this ; }
			}
		public C_Function ConstLocalArg0
			{
			get {
				var arg0 = new C_Struct(Method.Args[0]) ;
				var symbol = C_Symbol.Acquire( "_local" ) ;
				return Statement( C699.C.Const.Struct(arg0.Type.p,symbol).Equate("*args") ) ;
				}
			}
		public C_Function StandardOutputWriteLocal( string _string, string _length )
			{
			var symbol = C_Symbol.Acquire( "_local" ) ;
			return Statement( "write( 0 , " + symbol + "->" + _string + " , " + symbol + "->" + _length + " )" ) ;
			}
		public C_Function StandardOutputWriteLine()
			{
			return Statement( "write( 0 , \"\\012\" , 1 )" ) ;
			}
		public C_Function Return( string symbol )
			{
			return Statement( C699.C.Return+symbol ) ;
			}
		public C_Function Register( C699.c type, string name )
			{
			return C.Register( this, type, C_Symbol.Acquire(name) ) ;
			}
		public C_Function Register( C699.c type )
			{
			return Register( type, C_Symbol.Acquire(type).By_p() ) ;
			}
		public C_Function ManagedArgument( int i )
			{
			if( let.Type == C699.Object(0) || let.Type == C699.String )
					return Statement( C699.C.If("((union _*)args["+i+"])->base.managed && ((union _*)args["+i+"])->base.pointer") )
					      .Statement( "\t" + let + " =  *(("+C699.String+" *)args["+i+"])" )
					      .Statement( C699.C.Else )
					      .Statement( "\t" + let + " =  (("+C699.Object(0)+" *)args["+i+"])->this->$ToString( args+"+i+" )") ;
			throw new System.NotImplementedException( "Type of managed pointer not defined." ) ;
			}
		C_Function( string symbol )
			{
			Void = true ;
			this.symbol = C_Symbol.Acquire( symbol ) ;
			Symbol = symbol ;
			//ID = Guid.NewGuid() ;
			}
		static public C_Function FromSymbol( string symbol )
			{
			C_Symbol s = C_Symbol.Acquire( symbol ) ;
			return FromSymbol( s ) ;
			}
		static public C_Function FromSymbol( C_Symbol symbol )
			{
			C_Function c ;
			if( ! c_functionset.ContainsKey( symbol ) )
				c_functionset.Add( symbol, c = new C_Function( symbol ) ) ;
			else
				c = c_functionset[symbol] ;
			return c ;
			}
		static public void Require( string symbol )
			{
			C_Function c ;
			if( ! c_functionset.ContainsKey( symbol ) )
				c_functionset.Add( symbol, c = new C_Function( symbol ) ) ;
			else
				c = c_functionset[symbol] ;
			c.Required = true ;
			}
		public C_Function Statement( C699.c line )
			{
			bool eos = ( line.Bits & (C699.Bit.If|C699.Bit.Else) ) != 0 && (line.Bits & C699.Bit.Goto) == 0 ;
			list.Add( "\t" + line + ( eos ? "" : " ;" ) ) ;
			return this ;
			}
		public C_Function Statement( string line )
			{
			return Statement( C699.C.Restricted(line) ) ;
			}
		public void Label( C_Label label )
			{
			list.Add( "\t" + label + " :" ) ;
			}
		public void WriteTo( StreamWriter sw )
			{
			var line = new List<string>() ;
			if( Inline )
				line.Add( C699.C.Inline ) ;
			if( Static )
				line.Add( C699.C.Static(Type) ) ;
			else
				line.Add( Type ) ;
			line.Add( Symbol ) ;
			string a ;
			if( Args == null )
				a = '('+C699.C.Const.Voidpp+"stack"
				+ ( HasArgs ? ','+C699.C.Const.Voidpp.ArgV : "" )
				+ ')' ;
			else
				a = Args ;
			sw.WriteLine( String.Join( " ", line ) + a ) ;
			sw.WriteLine( "\t{" ) ;
			foreach( string s in list )
				sw.WriteLine( s ) ;
			sw.WriteLine( "\t}" ) ;
			sw.WriteLine() ;
			Written = true ;
			}
		}
	}

public class far : Future.ʄutex<string>
	{
	static System.IntPtr farpoint = System.IntPtr.Zero ;
	public far()
		{
		Orbit       = farpoint ;             //_grounded_paradigm
		//Whereas: Interface  = native_shoe ;          //_module
		//Whereas: Interfaces = native_shoes ;         //_next_module,...
		//Therefore: Precursor = (slides,shadows,shades,...,so[u]l(s))
		}
	public class Point : far
		{
		public Point(uint x, uint y)
			{
			//Precursor = point ;  //_if_partial_class
			Intraface  = (System.IntPtr)x ;
			Intrafaces = (System.IntPtr)y ;
			}
		//public point(Decimal x_y) {}
		static public Point Module(char [] oprands)
			{
			Point module      = new Point(0,0) ;
			//oprands := operands before compiler-compiled, ordered or out-of-order
			module.Interface  = (System.IntPtr)oprands[0] ;  //_uppercase_letter[,+ATM_index]
			module.Interfaces = (System.IntPtr)oprands[1] ;  //_lowercase_letter[,+ATM_index]
			module.Item       = oprands.ToString() ;
			//materialize_oprands[2,3,4,...]
			return module ;
			}
		}
	}
}

namespace Future
	{
	using System ;
	public class ʄutex<T> /* : Atomatrix<T> */
		{
		public     IntPtr Precursor  ;     //Precursor = well-formed, determined IP
		public     IntPtr Intraface  ;
		public     IntPtr Intrafaces ;
		protected  IntPtr Orbit      ;
		protected  IntPtr Interface  ;
		protected  IntPtr Interfaces ;     // (Interfaces==Orbit) ? "illogical" : loop !  //_always_minor_fix,_use_acquire
		T                 item       ;
		public     T      Item
			{
			get { return item ; }
			set { item = value ; }
			}
		}
	}
