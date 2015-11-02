partial class A335
{
/*#*/static/*#*/ string [,] qubit_ildex_nt ; //_nexus: Allow entry of server idle events for -dex bits, so it avoids stack over-head. (BCL)
static string qouted_bit ;   //""
static string qouted_    ;   //''
static string qouted_unbit ; //;("un-");''
static string _qR_ ;//#':''R'#//#_xbf ; /* default:*:image_t="urn:file:QR-Coded-Image.bin" */
static string _qr_CC     ;   //_qrcc
static int    _qr_v      ;   //_inverted_quant,_qr_CC[,_voxel]

public struct Quant
	{
	const System.Decimal  one    = System.Decimal.One ;
	const System.Decimal  two    = one + one ;
	const System.Decimal  three  = one + two ;
	public System.Decimal nybble ;
	public bool One
		{
		get { return nybble == one ; }
		set { nybble = value ? one : System.Decimal.Zero ; }
		}
	public bool OneOrTwo
		{
		get { return nybble < three  ; }
		set { One = value ; }
		}
	public bool OneOrThree
		{
		get { return ! Two ; }
		set { One = value ; }
		}
	public bool Two
		{
		get { return nybble == two ; }
		set { nybble = value ? two : System.Decimal.Zero ; }
		}
	public bool TwoOrThree
		{
		get { return nybble > one  ; }
		set { Two = value ; }
		}
	public bool Three
		{
		get { return nybble == three ; }
		set { nybble = value ? three : System.Decimal.Zero ; }
		}
	public override string ToString()
		{
		return nybble.ToString() ;
		}
	public System.Decimal Increment()
		{
		return nybble += one ;
		}
	public System.Decimal Decrement()
		{
		return nybble -= one ;
		}
	}


}
