using System.Diagnostics ;
using System.Extensions ;
using System.Reflection ;
using System.Linq ;
using System ;
public partial class A335 {
public static void Auto( int n )
	{
	if( n == 0 )
		return ;
	Stack.Push( (Automatrix) _auto( Rule.Set[n].AlphaSignal ) ) ;
	return ;
	}


public static global::Item _auto( string method ) {
switch( method ) {
case "sigArgs0_sigArgs1" : return new SigArgs0.sigArgs0_sigArgs1() ;
case "sigArg_paramAttr_type" : return new SigArg.sigArg_paramAttr_type() ;
case "sigArg_paramAttr_type_id" : return new SigArg.sigArg_paramAttr_type_id() ;
case "sigArgs1_sigArgs1_____sigArg" : return new SigArg.sigArgs1_sigArgs1_____sigArg() ;
case "sigArgs1_sigArg" : return new SigArg.sigArgs1_sigArg() ;
case "classHead___class__classAttr_id_extendsClause_implClause" : return new classHead___class__classAttr_id_extendsClause_implClause() ;
case "callConv__instance__callConv" : return new CallConv.callConv__instance__callConv() ;
case "callConv_callKind" : return new CallConv.callConv_callKind() ;
case "classDecl_methodHead_methodDecls____" : return new classDecl_methodHead_methodDecls____() ;
case "compQstring_QSTRING" : return new compQstring_QSTRING() ;
case "decl_classHead_____classDecls____" : return new decl_classHead_____classDecls____() ;
case "_accept_START__end" : return new _accept_START__end() ;
case "classDecl_classHead_____classDecls____" : return new classDecl_classHead_____classDecls____() ;
case "customType_callConv_type_typeSpec________ctor______sigArgs0____" : return new customType_callConv_type_typeSpec________ctor______sigArgs0____() ;
case "id_ID" : return new id_ID() ;
case "name1_id" : return new name1_id() ;
case "assemblyRefHead___assembly___extern__name1" : return new assemblyRefHead___assembly___extern__name1() ;
case "int32_INT64" : return new int32_INT64() ;
case "asmOrRefDecl___ver__int32_____int32_____int32_____int32" : return new asmOrRefDecl___ver__int32_____int32_____int32_____int32() ;
case "assemblyRefDecl_asmOrRefDecl" : return new assemblyRefDecl_asmOrRefDecl() ;
case "assemblyRefDecls_assemblyRefDecls_assemblyRefDecl" : return new assemblyRefDecls_assemblyRefDecls_assemblyRefDecl() ;
case "decl_assemblyRefHead_____assemblyRefDecls____" : return new decl_assemblyRefHead_____assemblyRefDecls____() ;
case "decls_decls_decl" : return new decls_decls_decl() ;
case "id_SQSTRING" : return new id_SQSTRING() ;
case "assemblyHead___assembly__asmAttr_name1" : return new assemblyHead___assembly__asmAttr_name1() ;
case "assemblyDecl___hash___algorithm__int32" : return new assemblyDecl___hash___algorithm__int32() ;
case "assemblyDecls_assemblyDecls_assemblyDecl" : return new assemblyDecls_assemblyDecls_assemblyDecl() ;
case "assemblyDecl_asmOrRefDecl" : return new assemblyDecl_asmOrRefDecl() ;
case "decl_assemblyHead_____assemblyDecls____" : return new decl_assemblyHead_____assemblyDecls____() ;
case "classAttr_classAttr__private_" : return new classAttr_classAttr__private_() ;
case "classAttr_classAttr__auto_" : return new classAttr_classAttr__auto_() ;
case "classAttr_classAttr__ansi_" : return new classAttr_classAttr__ansi_() ;
case "classAttr_classAttr__beforefieldinit_" : return new classAttr_classAttr__beforefieldinit_() ;
case "fieldAttr_fieldAttr__private_" : return new fieldAttr_fieldAttr__private_() ;
case "fieldAttr_fieldAttr__static_" : return new fieldAttr_fieldAttr__static_() ;
case "name1_DOTTEDNAME" : return new name1_DOTTEDNAME() ;
case "slashedName_name1" : return new slashedName_name1() ;
case "className_____name1_____slashedName" : return new className_____name1_____slashedName() ;
case "extendsClause__extends__className" : return new extendsClause__extends__className() ;
case "callKind__default_" : return new callKind__default_() ;
case "type__void_" : return new type__void_() ;
case "methodName___ctor_" : return new methodName___ctor_() ;
case "methodName___cctor_" : return new methodName___cctor_() ;
case "implAttr_implAttr__cil_" : return new implAttr_implAttr__cil_() ;
case "implAttr_implAttr__managed_" : return new implAttr_implAttr__managed_() ;
case "methodDecls_methodDecls_methodDecl" : return new methodDecls_methodDecls_methodDecl() ;
case "type__valuetype__className" : return new type__valuetype__className() ;
case "typeSpec_type" : return new typeSpec_type() ;
case "classDecls_classDecls_classDecl" : return new classDecls_classDecls_classDecl() ;
case "methodName_name1" : return new methodName_name1() ;
case "type__class__className" : return new type__class__className() ;
case "type__string_" : return new type__string_() ;
case "publicKeyTokenHead___publickeytoken_________" : return new publicKeyTokenHead___publickeytoken_________() ;
case "hexbytes_HEXBYTE" : return new hexbytes_HEXBYTE() ;
case "hexbytes_hexbytes_HEXBYTE" : return new hexbytes_hexbytes_HEXBYTE() ;
case "bytes_hexbytes" : return new bytes_hexbytes() ;
case "assemblyRefDecl_publicKeyTokenHead_bytes____" : return new assemblyRefDecl_publicKeyTokenHead_bytes____() ;
case "customHead___custom__customType________" : return new customHead___custom__customType________() ;
case "customAttrDecl_customHead_bytes____" : return new customAttrDecl_customHead_bytes____() ;
case "asmOrRefDecl_customAttrDecl" : return new asmOrRefDecl_customAttrDecl() ;
case "moduleHead___module__name1" : return new moduleHead___module__name1() ;
case "classAttr_classAttr__public_" : return new classAttr_classAttr__public_() ;
case "type__object_" : return new type__object_() ;
case "slashedName_slashedName_____name1" : return new slashedName_slashedName_____name1() ;
case "className_slashedName" : return new className_slashedName() ;
case "classAttr_classAttr__nested___private_" : return new classAttr_classAttr__nested___private_() ;
case "decl_moduleHead" : return new decl_moduleHead() ;
case "bounds1_bound" : return new bounds1_bound() ;
case "type_type_____bounds1____" : return new type_type_____bounds1____() ;
case "fieldDecl___field__repeatOpt_fieldAttr_type_id_atOpt_initOpt" : return new fieldDecl___field__repeatOpt_fieldAttr_type_id_atOpt_initOpt() ;
case "classDecl_fieldDecl" : return new classDecl_fieldDecl() ;
case "typeSpec_className" : return new typeSpec_className() ;
case "decls" : return new decls() ;
case "localsHead___locals_" : return new localsHead___locals_() ;
case "type__int32_" : return new type__int32_() ;
case "labels_id" : return new labels_id() ;
case "labels_id_____labels" : return new labels_id_____labels() ;
case "START_decls" : return new START_decls() ;
case "methodHeadPart1___method_" : return new methodHeadPart1___method_() ;
case "methodHead_methodHeadPart1_methAttr_callConv_paramAttr_type_methodName_____sigArgs0_____implAttr____" : return new methodHead_methodHeadPart1_methAttr_callConv_paramAttr_type_methodName_____sigArgs0_____implAttr____() ;
case "methodDecl___entrypoint_" : return new methodDecl___entrypoint_() ;
case "methodDecl___maxstack__int32" : return new methodDecl___maxstack__int32() ;
case "methodDecl_localsHead__init______sigArgs0____" : return new methodDecl_localsHead__init______sigArgs0____() ;
case "methodDecl_id____" : return new methodDecl_id____() ;
case "methodDecl_instr" : return new methodDecl_instr() ;
case "methAttr_methAttr__static_" : return new methAttr_methAttr__static_() ;
case "methAttr_methAttr__specialname_" : return new methAttr_methAttr__specialname_() ;
case "methAttr_methAttr__public_" : return new methAttr_methAttr__public_() ;
case "methAttr_methAttr__hidebysig_" : return new methAttr_methAttr__hidebysig_() ;
case "methAttr_methAttr__rtspecialname_" : return new methAttr_methAttr__rtspecialname_() ;
case "methAttr_methAttr__private_" : return new methAttr_methAttr__private_() ;
case "methAttr_methAttr__virtual_" : return new methAttr_methAttr__virtual_() ;
case "instr_INSTR_BRTARGET_id" : return new instr_INSTR_BRTARGET_id() ;
case "instr_INSTR_METHOD_callConv_type_typeSpec______methodName_____sigArgs0____" : return new instr_INSTR_METHOD_callConv_type_typeSpec______methodName_____sigArgs0____() ;
case "instr_INSTR_TYPE_typeSpec" : return new instr_INSTR_TYPE_typeSpec() ;
case "instr_INSTR_FIELD_type_id" : return new instr_INSTR_FIELD_type_id() ;
case "instr_INSTR_FIELD_type_typeSpec______id" : return new instr_INSTR_FIELD_type_typeSpec______id() ;
case "instr_INSTR_SWITCH_____labels____" : return new instr_INSTR_SWITCH_____labels____() ;
case "instr_INSTR_NONE" : return new instr_INSTR_NONE() ;
case "instr_INSTR_STRING_compQstring" : return new instr_INSTR_STRING_compQstring() ;
default: throw new System.DuplicateWaitObjectException() ;
}
}
}
