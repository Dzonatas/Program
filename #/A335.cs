partial class A335
{
public partial class Stack
	{
	public partial class Item : global::Item
		{
		public partial class Token : Item {}
		public partial class Empty : Item {}
		}
	}
public partial class Object : Stack.Item {}
public partial class Automatrix : Object {}
public partial class SigArgs0 : Automatrix
	{
	[Automaton] public partial class   sigArgs0_sigArgs1 {}
	}
public class _START : Automatrix {}
}

