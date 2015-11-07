sealed public partial class A335
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
public class _START : Automatrix {}
public partial class SigArgs0 : Automatrix
	{
	[Automaton] public partial class   sigArgs0_sigArgs1
		: SigArgs0 {}
	}
public partial class SigArg : Automatrix
	{
	[Automaton] public partial class   sigArg_paramAttr_type
		: SigArg	{}
	[Automaton] public partial class   sigArg_paramAttr_type_id
		: SigArg	{}
	[Automaton] public partial class   sigArgs1_sigArgs1_____sigArg
		: Automatrix	{}
	[Automaton] public partial class   sigArgs1_sigArg
		: Automatrix	{}
	}
public partial class Class : Automatrix
	{
	public partial class Head : Class {}
	public partial class Decl : Class {}
	public partial class Name : Class {}
	public partial class Attr : Class {}
	}
[Automaton] public partial class   classHead___class__classAttr_id_extendsClause_implClause
	: Class.Head	{}
[Automaton] public partial class   classDecl_fieldDecl
	: Class.Decl	{}
[Automaton] public partial class   classDecl_methodHead_methodDecls____
	: Class.Decl	{}
[Automaton] public partial class   classDecl_classHead_____classDecls____
	: Class.Decl	{}
[Automaton] public partial class   classDecls_classDecls_classDecl
	: Automatrix	{}
[Automaton] public partial class   classAttr_classAttr__private_
	: Class.Attr {}
[Automaton] public partial class   classAttr_classAttr__auto_
	: Class.Attr {}
[Automaton] public partial class   classAttr_classAttr__ansi_
	: Class.Attr {}
[Automaton] public partial class   classAttr_classAttr__beforefieldinit_
	: Class.Attr {}
[Automaton] public partial class   classAttr_classAttr__nested___private_
	: Class.Attr {}
[Automaton] public partial class   classAttr_classAttr__public_
	: Class.Attr {}
[Automaton] public partial class   className_____name1_____slashedName
	: Class.Name {}
[Automaton] public partial class   className_slashedName
	: Class.Name {}

public partial class CallConv : Automatrix
	{
	[Automaton] public partial class   callConv__instance__callConv
		: CallConv	{}

	[Automaton] public partial class   callConv_callKind
		: CallConv	{}
	}
[Automaton] public partial class   _accept_START__end
	: Automatrix	{}
[Automaton] public partial class   decl_classHead_____classDecls____
	: Automatrix	{}
[Automaton] public partial class   compQstring_QSTRING
	: Automatrix	{}
[Automaton] public partial class   customType_callConv_type_typeSpec________ctor______sigArgs0____
	: Automatrix	{}

public partial class Field
	{
	public partial class Decl :Automatrix {}
	public partial class Attr :Automatrix {}
	}
[Automaton] public partial class   fieldDecl___field__repeatOpt_fieldAttr_type_id_atOpt_initOpt
	: Field.Decl	{}
[Automaton] public partial class   fieldAttr_fieldAttr__private_
	: Field.Attr	{}
[Automaton] public partial class   fieldAttr_fieldAttr__static_
	: Field.Attr	{}

public partial class Method
	{
	public partial class Head : Automatrix
		{
		public partial class Part1 : Automatrix {}
		}
	public partial class Decl  : Automatrix {}
	public partial class Attr  : Automatrix {}
	public partial class Name  : Automatrix {}
	public partial class Decls : Automatrix {}
	}
[Automaton] public partial class   methodHeadPart1___method_
	: Method.Head.Part1   {}
[Automaton] public partial class   methodHead_methodHeadPart1_methAttr_callConv_paramAttr_type_methodName_____sigArgs0_____implAttr____
	: Method.Head   {}
[Automaton] public partial class   methodDecl_localsHead__init______sigArgs0____
	: Method.Decl   {}
[Automaton] public partial class   methodDecl___entrypoint_
	: Method.Decl   {}
[Automaton] public partial class   methodDecl___maxstack__int32
	: Method.Decl   {}
[Automaton] public partial class   methodDecl_id____
	: Method.Decl   {}
[Automaton] public partial class   methodDecl_instr
	: Method.Decl	{}
[Automaton] public partial class   methAttr_methAttr__static_
	: Method.Attr   {}
[Automaton] public partial class   methAttr_methAttr__specialname_
	: Method.Attr   {}
[Automaton] public partial class   methAttr_methAttr__public_
	: Method.Attr	{}
[Automaton] public partial class   methAttr_methAttr__hidebysig_
	: Method.Attr	{}
[Automaton] public partial class   methAttr_methAttr__rtspecialname_
	: Method.Attr	{}
[Automaton] public partial class   methAttr_methAttr__private_
	: Method.Attr	{}
[Automaton] public partial class   methAttr_methAttr__virtual_
	: Method.Attr	{}
[Automaton] public partial class   methodName___ctor_
	: Method.Name	{}
[Automaton] public partial class   methodName___cctor_
	: Method.Name	{}
[Automaton] public partial class   methodName_name1
	: Method.Name	{}
[Automaton] public partial class   methodDecls_methodDecls_methodDecl
	: Method.Decls	{}

public partial class Instr : Automatrix
	{
	public partial class BrTarget : Instr {}
	public partial class Method : Instr {}
	public partial class Type : Instr {}
	public partial class Field : Instr {}
	public partial class Switch : Instr {}
	public partial class None : Instr {}
	public partial class String : Instr {}
	}
[Automaton] public partial class   instr_INSTR_BRTARGET_id
	: Instr.BrTarget {}
[Automaton] public partial class   instr_INSTR_METHOD_callConv_type_typeSpec______methodName_____sigArgs0____
	: Instr.Method	{}
[Automaton] public partial class   instr_INSTR_TYPE_typeSpec
	: Instr.Type    {}
[Automaton] public partial class   instr_INSTR_FIELD_type_id
	: Instr.Field   {}
[Automaton] public partial class   instr_INSTR_FIELD_type_typeSpec______id
	: Instr.Field   {}
[Automaton] public partial class   instr_INSTR_SWITCH_____labels____
	: Instr.Switch  {}
[Automaton] public partial class   instr_INSTR_NONE
	: Instr.None    {}
[Automaton] public partial class   instr_INSTR_STRING_compQstring
	: Instr.String {}

public partial class Type : Automatrix
	{
	public partial class Spec : Type {}
	}
[Automaton] public partial class   type_type_____bounds1____
	: Type {}
[Automaton] public partial class   type__int32_
	: Type {}
[Automaton] public partial class   type__object_
	: Type {}
[Automaton] public partial class   type__valuetype__className
	: Type {}
[Automaton] public partial class   type__class__className
	: Type {}
[Automaton] public partial class   type__string_
	: Type {}
[Automaton] public partial class   type__void_
	: Type {}
[Automaton("type_type_272A27")]
	public partial class   type_type_asterisk
	: Type {}
[Automaton("type_type_272627")]
	public partial class   type_type_ampersand
	: Type {}
[Automaton("type_type_275B27_275D27")]
	public partial class   type_type_square_brackets
	: Type {}
[Automaton] public partial class   typeSpec_type
	: Type.Spec {}
[Automaton] public partial class   typeSpec_className
	: Type.Spec {}
}

