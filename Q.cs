using System;

public partial class A335
{
static string [,] qubit_ildex_nt ; //_research: Allow entry of server idle events for -dex bits, so it avoids stack over-head.
static string qouted_bit ;   //""
static string qouted_    ;   //''
static string qouted_unbit ; //;("un-");''
static string _qR_ ;//#':''R'#//#_xbf ; /* default:*:image_t="urn:file:QR-Coded-Image.bin" */
static string _qr_binary_square ;  //_research: extra string storage for scanned/inputted QR-Code, with known orientation

public struct Quant
	{
	const Decimal  one    = Decimal.One ;
	const Decimal  two    = one + one ;
	const Decimal  three  = one + two ;
	public Decimal nybble ;
	public bool One
		{
		get { return nybble == one ; }
		set { nybble = value ? one : Decimal.Zero ; }
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
		set { nybble = value ? two : Decimal.Zero ; }
		}
	public bool TwoOrThree
		{
		get { return nybble > one  ; }
		set { Two = value ; }
		}
	public bool Three
		{
		get { return nybble == three ; }
		set { nybble = value ? three : Decimal.Zero ; }
		}
	public override string ToString()
		{
		return nybble.ToString() ;
		}
	public Decimal Increment()
		{
		return nybble += one ;
		}
	public Decimal Decrement()
		{
		return nybble -= one ;
		}
	}


}
