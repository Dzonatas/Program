partial class A335
{
static void Begin()
	{
	if( Cluster.Parameter.Value("reflection") == "false" )
		if( Current.Path.Exists( "main.c" ) )
			return ;
	Cluster.Cli.Start( Cluster.Parameter.Value("shell"), Tokenset.Assimulation ) ;
	//Console.WriteLine( "symbolset={0} tokenset={1}", xml_symbolset.Count, xml_tokenset.Count ) ;
	/*
	foreach( State s in stateset )
		{
		if( s.itemset.Length == 0 )
			throw new NotImplementedException() ;
		if( s.itemset.Length == 1 )
			y++ ;
		if( s.itemset.Length == 1 && s.reductionset.Length == 0 )
			zz++ ;
		if( s.itemset.Length == 1 && s.transitionset.Length == 0 )
			yy++ ;
		if( s.transitionset.Length == 0 && s.reductionset.Length == 0 )
			throw new NotImplementedException() ;
		if( s.reductionset.Length == 1 && s.reductionset[0] != _default )
			throw new NotImplementedException() ;
		if( s.reductionset.Length >  1 && s.reductionset[0] == _default )
			throw new NotImplementedException() ;
		if( s.transitionset.Length == 1 && s.reductionset.Length == 1 && s.transitionset[0] == s.reductionset[0] )
			throw new NotImplementedException() ;
		if( s.itemset.Length < s.transitionset.Length )
			throw new NotImplementedException() ;
		if( s.itemset.Length > 1 && s.itemset.Length == s.transitionset.Length && s.reductionset.Length != 0 )
			throw new NotImplementedException() ;
		if( s.itemset.Length == s.transitionset.Length && s.reductionset.Length != 0 )
			throw new NotImplementedException() ;
		if( s.itemset.Length + s.reductionset.Length < s.transitionset.Length )
			throw new NotImplementedException() ;
		if( s.transitionset.Length == 0 && s.itemset.Length <= s.reductionset.Length && s.reductionset[s.reductionset.Length-1] != _default )
			throw new NotImplementedException() ;
		if( s.transitionset.Length == 0 && s.reductionset[s.reductionset.Length-1] != _default )
				throw new NotImplementedException() ;
		x++ ;
		}
	if( y != (zz + yy) )
		throw new NotImplementedException() ;
	//Console.WriteLine("x={0} y={1} z={2} yy={3}",x,y,zz,yy ) ;
	*/
	#if SCREEN
	_.screen.DrawCode() ;
	#endif
	Program.Begin() ;
	Cluster.Cli.Refine() ;
	#if !BEGINNING
	global::Automaton.Begin() ;
	#else
	planet b = new planet(0,0,0,(-ʄ)._default(_default)) ;
	beginning( ref b ) ;
	#endif
	#if DEBUG_DUMP
	Stack.Dump() ;
	#endif
	#if DEBUG_ASM
	var main_c = Current.Path.CreateText( "main.c" ) ;
	X.Auto["list"] = b_list ;
	main_c.WriteLine( Xo_t.put("main_c") ) ;
	main_c.Close() ;
	Cluster.Cli.AutoStart( "cc main.c -o main" ) ;
	main_c = Current.Path.CreateText( "dmain.c" ) ;
	b_list = "" ;
	X.Auto["list"] = b_list ;
	main_c.WriteLine( Xo_t.put("main_c") ) ;
	main_c.Close() ;
	#endif
	Stack.IStart start = Stack.FindIStart() ;
	Automatrix.Prerender( start ) ;
	Automatrix.Render( start ) ;
	Program.Write() ;
	if( log_output != null )
		{
		log_output.Close() ;
		#if !DEBUG
		throw new System.NotImplementedException( "[/tmp/output.c] Logged" ) ;
		#endif
		}
	//_.prompt(_.string_t) ;
	}
}