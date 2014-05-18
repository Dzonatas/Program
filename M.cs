//#define START Blogic#<NOUN L="START">#

//using System;
//using System.Xml ;
using System.IO ;
using System.Collections.Generic ;

public partial class A335
{

public static void Main( string[] args )
	{
	Application.Program.Parse( args ) ;
	//request( ref system ) ;  //_: request( ref system_m ) ; //_m!(_err[1...3]='boxed','unboxed','not boxed')((_cubed))
	if( Application.Parameter.Value("synopsis") == "false" ) 
		Begin() ;
#if RELEASE
	else
		Tutorial() ;
	//iOS.up
	try {
		leave() ; //[debug:n0p;,("AI")]
		}
	catch
		{
		throw new _.exception() ;
		}
#endif
	}

partial class Program
	{
	public class Method
		{
		int            maxstack ;
		C_Method       method ;
		C_Function     function ;
		List<object>   list = new List<object>() ;
		List<string>   labels = new List<string>() ;
		public bool    Static ;
		public bool    CallConvInstance ;
		public string  Type ;
		public string  ClassSymbol ;
		public string  Name ;
		public string  SigArgTypes ;
		public int     SigArgs ;
		public int     MaxStack
			{
			set { C.MaxStack = maxstack = value ; }
			//get { return maxstack ; }
			}
		bool _virtual ;
		public bool    Virtual
			{
			set {
				if( ( _virtual = value ) )
					{
					C_Struct c = C_Struct.FromSymbol( ClassSymbol ) ;
					c.Assign( Name + SigArgTypes ) ;
					}
				}
			get {
				return _virtual ;
				}
			}
		public Method()
			{
			methodset.Add( this ) ;
			}
		public void Add( C_Oprand oprand )
			{
			list.Add( oprand ) ;
			}
		public void AddLabel( string text )
			{
			list.Add( text ) ;
			}
		public void RegisterLabel( string text )
			{
			labels.Add( text ) ;
			}
		public void RegisterCctor()
			{
			cctorset.Add( ClassSymbol ) ;
			}
		public void WriteInclude( StreamWriter sw )
			{
			sw.WriteLine( "#include \"" + ClassSymbol + Name + SigArgTypes + ".c\"" ) ;
			}
		public void CreateFunction()
			{
			method = new C_Method() ;
			method.Type = C_Type.Acquire( Type ) ;
			method.Name = C_Symbol.Acquire( Name ) ;
			foreach( string s in ClassSymbol.Split( '$' ) )
				method.ClassName.Add( C_Type.Acquire( s ) ) ;
			foreach( string a in SigArg.Typeset )
				method.Args.Add( C_Type.Acquire( a ) ) ;
			function = C_Function.FromSymbol( ClassSymbol + Name + SigArgTypes ) ;
			function.Method = method ;
			}
		public C_Oprand NewOprand( string instr )
			{
			var d = new C_Oprand( function, instr ) ;
			Add( d ) ;
			return d ;
			}
		public void Write()
			{
			var c = function ;
			StreamWriter sw = File.CreateText( directory.FullName + "/" + c.Symbol + ".c" ) ;
			foreach( object o in list )
				if( o is C_Oprand )
					(o as C_Oprand).WriteTo( sw ) ;
			int args = SigArgs + ( CallConvInstance ? 1 : 0 ) ;
			if( Virtual )
				c.Type = C_Symbol.Acquire( "struct _string" ) ;
			if( args == 0 )
				c.Args = "()" ;
			else
				c.Args = "( const void** args )" ;
			c.Statement( "const void** stack = alloca( " + maxstack + " * sizeof(void*) )" ) ;
			foreach( object o in list )
				{
				if( o is C_Oprand )
					c.Statement( (string) (o as C_Oprand) ) ;
				else
					{
					string label = (string) o ;
					if( labels.Contains( label ) )
						c.Label( label ) ;
					}
				}
			if( Virtual )
				c.Statement( "return *(struct _string *)*stack" ) ;
			c.WriteTo( sw ) ;
			sw.Close() ;
			}
		}
	}

}

namespace Materials
	{
	#region MATERIAL
	struct M
		{
		System.Guid guid ;
		public int INTERFACE ;
		public int intraface ;
		}
	struct library_collada
		{
		M id ;
		}
	struct MESA
		{
		static readonly object _ ;
		string defunct_drm ;
		M resx ;
		static MESA()
			{
			MESA _ = new MESA() ;
			_.defunct_drm = "" ;
			_.resx = new Materials.M() ;
			}
		}
	#endregion
	}

namespace Magic.Number
	{
	#region DUMB_TERM
	struct _
		{
		string TERM ;//_region
		}
	#endregion
	}
