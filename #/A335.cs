sealed public partial class A335
{
public partial class Stack
	{
	public interface IStart {}
	public partial class Item : global::Item
		{
		public partial class Token : Item {}
		public partial class Empty : Item {}
		}
	}
public partial class Object : Stack.Item {}
public partial class Automatrix : Object {}
public partial class _START : Automatrix {}
[Automaton] public partial class   START_decls
	: _START, Stack.IStart {}

public partial class Decls : Automatrix {}
[Automaton] public partial class   decls
	: Decls	{}
[Automaton] public partial class   decls_decls_decl
	: Decls {}

public partial class Decl : Automatrix {}
[Automaton] public partial class   decl_assemblyHead_____assemblyDecls____
	: Decl	{}
[Automaton] public partial class   decl_assemblyRefHead_____assemblyRefDecls____
	: Decl	{}
[Automaton] public partial class   decl_classHead_____classDecls____
	: Decl	{}
[Automaton] public partial class   decl_moduleHead
	: Decl	{}
[Automaton] public partial class   decl_nameSpaceHead_____decls____
	: Decl	{}

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
	public partial class Head  : Class {}
	public partial class Decl  : Class {}
	public partial class Decls : Class {}
	public partial class Name  : Class {}
	public partial class Names : Class {}
	public partial class Attr  : Class {}
	}
[Automaton] public partial class   classHead___class__classAttr_id_extendsClause_implClause
	: Class.Head	{}
[Automaton] public partial class   classDecl_fieldDecl
	: Class.Decl	{}
[Automaton] public partial class   classDecl_customAttrDecl
	: Class.Decl	{}
[Automaton] public partial class   classDecl_methodHead_methodDecls____
	: Class.Decl	{}
[Automaton] public partial class   classDecl_classHead_____classDecls____
	: Class.Decl	{}
[Automaton] public partial class   classDecl___pack__int32
	: Class.Decl	{}
[Automaton] public partial class   classDecl___size__int32
	: Class.Decl	{}
[Automaton] public partial class   classDecl_propHead_____propDecls____
	: Class.Decl	{}
[Automaton] public partial class   classDecls_classDecls_classDecl
	: Class.Decls	{}
[Automaton] public partial class   classAttr_classAttr__private_
	: Class.Attr {}
[Automaton] public partial class   classAttr_classAttr__abstract_
	: Class.Attr {}
[Automaton] public partial class   classAttr_classAttr__auto_
	: Class.Attr {}
[Automaton] public partial class   classAttr_classAttr__ansi_
	: Class.Attr {}
[Automaton] public partial class   classAttr_classAttr__beforefieldinit_
	: Class.Attr {}
[Automaton] public partial class   classAttr_classAttr__interface_
	: Class.Attr {}
[Automaton] public partial class   classAttr_classAttr__nested___private_
	: Class.Attr {}
[Automaton] public partial class   classAttr_classAttr__nested___public_
	: Class.Attr {}
[Automaton] public partial class   classAttr_classAttr__public_
	: Class.Attr {}
[Automaton] public partial class   classAttr_classAttr__sequential_
	: Class.Attr {}
[Automaton] public partial class   classAttr_classAttr__sealed_
	: Class.Attr {}
[Automaton] public partial class   className_____name1_____slashedName
	: Class.Name {}
[Automaton] public partial class   className_slashedName
	: Class.Name {}
[Automaton] public partial class   classNames_className
	: Class.Names {}

public partial class CallConv : Automatrix
	{
	[Automaton] public partial class   callConv__instance__callConv
		: CallConv	{}
	[Automaton] public partial class   callConv_callKind
		: CallConv	{}
	}
[Automaton] public partial class   _accept_START__end
	: Automatrix	{}
[Automaton] public partial class   compQstring_QSTRING
	: Automatrix	{}
[Automaton] public partial class   customType_callConv_type_typeSpec________ctor______sigArgs0____
	: Automatrix	{}

public partial class ExtendsClause : Automatrix {}
[Automaton] public partial class   extendsClause__extends__className
	: ExtendsClause {}

public partial class Field
	{
	public partial class Decl : Automatrix {}
	public partial class Attr : Automatrix {}
	public partial class Init : Automatrix {}
	}
[Automaton] public partial class   fieldDecl___field__repeatOpt_fieldAttr_type_id_atOpt_initOpt
	: Field.Decl	{}
[Automaton] public partial class   fieldAttr_fieldAttr__assembly_
	: Field.Attr	{}
[Automaton] public partial class   fieldAttr_fieldAttr__family_
	: Field.Attr	{}
[Automaton] public partial class   fieldAttr_fieldAttr__literal_
	: Field.Attr	{}
[Automaton] public partial class   fieldAttr_fieldAttr__initonly_
	: Field.Attr	{}
[Automaton] public partial class   fieldAttr_fieldAttr__private_
	: Field.Attr	{}
[Automaton] public partial class   fieldAttr_fieldAttr__static_
	: Field.Attr	{}
[Automaton] public partial class   fieldAttr_fieldAttr__public_
	: Field.Attr	{}
[Automaton] public partial class   fieldInit__int32______int64____
	: Field.Init	{}

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
[Automaton] public partial class   methodDecl_customAttrDecl
	: Method.Decl   {}
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
[Automaton] public partial class   methAttr_methAttr__abstract_
	: Method.Attr   {}
[Automaton] public partial class   methAttr_methAttr__assembly_
	: Method.Attr   {}
[Automaton] public partial class   methAttr_methAttr__family_
	: Method.Attr   {}
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
[Automaton] public partial class   methAttr_methAttr__newslot_
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
	public partial class Method   : Instr {}
	public partial class Type     : Instr {}
	public partial class Field    : Instr {}
	public partial class Switch   : Instr {}
	public partial class None     : Instr {}
	public partial class String   : Instr {}
	public partial class Var      : Instr {}
	public partial class I        : Instr {}
	public partial class Tok      : Instr {}
	}
[Automaton] public partial class   instr_INSTR_BRTARGET_id
	: Instr.BrTarget {}
[Automaton] public partial class   instr_INSTR_BRTARGET_int32
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
	: Instr.String  {}
[Automaton] public partial class   instr_INSTR_VAR_int32
	: Instr.Var     {}
[Automaton] public partial class   instr_INSTR_I_int32
	: Instr.I       {}
[Automaton] public partial class   instr_instr_tok_head_ownerType
	: Instr.Tok     {}
[Automaton] public partial class   instr_tok_head_INSTR_TOK
	: Automatrix     {}

public partial class Type : Automatrix
	{
	public partial class Spec : Type {}
	}
[Automaton] public partial class   type_type_____bounds1____
	: Type {}
[Automaton] public partial class   type__bool_
	: Type {}
[Automaton] public partial class   type__char_
	: Type {}
[Automaton] public partial class   type__int16_
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
[Automaton] public partial class   type_____int32
	: Type {}
[Automaton] public partial class   type__native___int_
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
[Automaton] public partial class   type_type_____genArgs____
	: Type {}
[Automaton] public partial class   typeSpec_type
	: Type.Spec {}
[Automaton] public partial class   typeSpec_className
	: Type.Spec {}

public partial class SlashedName : Automatrix {}
[Automaton] public partial class   slashedName_name1
	: SlashedName {}
[Automaton] public partial class   slashedName_slashedName_____name1
	: SlashedName {}

[Automaton] public partial class nameSpaceHead___namespace__name1
	: Automatrix {}
[Automaton] public partial class implClause__implements__classNames
	: Automatrix {}
[Automaton] public partial class propHead___property__propAttr_callConv_type_id_____sigArgs0_____initOpt
	: Automatrix {}
[Automaton] public partial class propDecl___get__callConv_type_typeSpec______methodName_____sigArgs0____
	: Automatrix {}
[Automaton] public partial class propDecl___set__callConv_type_typeSpec______methodName_____sigArgs0____
	: Automatrix {}
[Automaton] public partial class propDecls_propDecls_propDecl
	: Automatrix {}
[Automaton] public partial class genArgs_type
	: Automatrix {}
[Automaton] public partial class genArgs_genArgs_____type
	: Automatrix {}
[Automaton] public partial class int64_INT64
	: Automatrix {}
[Automaton] public partial class initOpt_____fieldInit
	: Automatrix {}
[Automaton] public partial class memberRef__field__type_typeSpec______id
	: Automatrix {}
[Automaton] public partial class ownerType_memberRef
	: Automatrix {}
[Automaton] public partial class atOpt__at__id
	: Automatrix {}
[Automaton] public partial class ddHead___data__tls_id____
	: Automatrix {}
[Automaton] public partial class bytearrayhead__bytearray_____
	: Automatrix {}
[Automaton] public partial class ddItem_bytearrayhead_bytes____
	: Automatrix {}
[Automaton] public partial class ddBody_ddItem
	: Automatrix {}
[Automaton] public partial class dataDecl_ddHead_ddBody
	: Automatrix {}
[Automaton] public partial class decl_dataDecl
	: Decl {}
}
