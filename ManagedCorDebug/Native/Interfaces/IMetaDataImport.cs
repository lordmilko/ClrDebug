using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ManagedCorDebug
{
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("7DAC8207-D3AE-4C75-9B67-92801A497D44")]
    public interface IMetaDataImport
    {
        [PreserveSig]
        void CloseEnum([In] IntPtr hEnum);

        [PreserveSig]
        HRESULT CountEnum([In] IntPtr hEnum, [Out] out uint pulCount);

        [PreserveSig]
        HRESULT ResetEnum([In] IntPtr hEnum, [In] uint ulPos);

        [PreserveSig]
        HRESULT EnumTypeDefs(
            [In, Out] ref IntPtr phEnum,
            [Out] out mdTypeDef typeDefs,
            [In] uint cMax,
            [Out] out uint pcTypeDefs);

        [PreserveSig]
        HRESULT EnumInterfaceImpls(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef td,
            [Out] out mdInterfaceImpl rImpls,
            [In] uint cMax,
            [Out] out uint pcImpls);

        [PreserveSig]
        HRESULT EnumTypeRefs(
            [In, Out] ref IntPtr phEnum,
            [Out] out mdTypeRef rTypeRefs,
            [In] uint cMax,
            [Out] out uint pcTypeRefs);

        [PreserveSig]
        HRESULT FindTypeDefByName(
            [MarshalAs(UnmanagedType.LPWStr), In] string szTypeDef,
            [In] mdToken tkEnclosingClass,
            [Out] out mdTypeDef typeDef);

        [PreserveSig]
        HRESULT GetScopeProps(
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szName,
            [In] int cchName,
            [Out] out int pchName,
            [Out] out Guid pmvid);

        [PreserveSig]
        HRESULT GetModuleFromScope([Out] out mdModule pmd);

        [PreserveSig]
        HRESULT GetTypeDefProps(
            [In] mdTypeDef td,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szTypeDef,
            [In] int cchTypeDef,
            [Out] out int pchTypeDef,
            [Out] out CorTypeAttr pdwTypeDefFlags,
            [Out] out mdToken ptkExtends);

        [PreserveSig]
        HRESULT GetInterfaceImplProps(
            [In] mdInterfaceImpl iiImpl,
            [Out] out mdTypeDef pClass,
            [Out] out mdToken ptkIface);

        [PreserveSig]
        HRESULT GetTypeRefProps(
            [In] mdTypeRef tr,
            [Out] out mdToken ptkResolutionScope,
            [Out] StringBuilder szName,
            [In] int cchName,
            [Out] out int pchName);

        /// <summary>
        /// Resolves a type reference.
        /// </summary>
        /// <param name="tr">The TypeRef metadata token to return the referenced type information for.</param>
        /// <param name="riid">The IID of the interface to return in ppIScope. Typically, this would be IID_IMetaDataImport.</param>
        /// <param name="ppIScope">An interface to the module scope in which the referenced type is defined.</param>
        /// <param name="ptd">A pointer to a TypeDef token that represents the referenced type.</param>
        /// <returns>A <see cref="HRESULT"/> indicating whether the operation was successful.</returns>
        /// <remarks>
        /// TypeDefs define a type within a scope. TypeRefs refer to type-defs in other scopes
        /// and allow you to import a type from another scope. This function attempts to determine
        /// which type-def a type-ref points to.
        /// 
        /// This resolves (type-ref, this scope) --> (type-def=*ptd, other scope=*ppIScope)
        /// 
        /// However, this resolution requires knowing what modules have been loaded, which is not decided
        /// until runtime via loader / fusion policy. Thus this interface can't possibly be correct since
        /// it doesn't have that knowledge. Furthermore, when inspecting metadata from another process
        /// (such as a debugger inspecting the debuggee's metadata), this API can be truly misleading.
        /// 
        /// This API usage should be avoided.
        /// </remarks>
        [Obsolete("This method no longer appears to exist in the IMetaDataImport vtable.")]
        [PreserveSig]
        HRESULT ResolveTypeRef(
            [In] mdTypeRef tr,
            [In] ref Guid riid,
            [MarshalAs(UnmanagedType.IUnknown), Out] out object ppIScope,
            [Out] out mdTypeDef ptd);

        [PreserveSig]
        HRESULT EnumMembers(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef cl,
            [Out] out mdToken rMembers,
            [In] uint cMax,
            [Out] out uint pcTokens);

        [PreserveSig]
        HRESULT EnumMembersWithName(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef cl,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [Out] out mdToken rMembers,
            [In] uint cMax,
            [Out] out uint pcTokens);

        [PreserveSig]
        HRESULT EnumMethods(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef cl,
            [Out] out mdMethodDef rMethods,
            [In] uint cMax,
            [Out] out uint pcTokens);

        [PreserveSig]
        HRESULT EnumMethodsWithName(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef cl,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            mdMethodDef[] rMethods,
            [In] uint cMax,
            [Out] out uint pcTokens);

        [PreserveSig]
        HRESULT EnumFields(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef cl,
            [Out] out mdFieldDef rFields,
            [In] uint cMax,
            [Out] out uint pcTokens);

        [PreserveSig]
        HRESULT EnumFieldsWithName(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef cl,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [Out] mdFieldDef[] rFields,
            [In] uint cMax,
            [Out] out uint pcTokens);

        [PreserveSig]
        HRESULT EnumParams(
            [In, Out] ref IntPtr phEnum,
            [In] mdMethodDef mb,
            [Out] out mdParamDef rParams,
            [In] uint cMax,
            [Out] out uint pcTokens);

        [PreserveSig]
        HRESULT EnumMemberRefs(
            [In, Out] ref IntPtr phEnum,
            [In] mdToken tkParent,
            [Out] out mdMemberRef rMemberRefs,
            [In] uint cMax,
            [Out] out uint pcTokens);

        [PreserveSig]
        HRESULT EnumMethodImpls(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef td,
            [Out] out mdToken rMethodBody,
            [Out] out mdToken rMethodDecl,
            [In] uint cMax,
            [Out] out uint pcTokens);

        [PreserveSig]
        HRESULT EnumPermissionSets(
            [In, Out] ref IntPtr phEnum,
            [In] mdToken tk,
            [In] SecurityAction dwActions,
            [Out] out mdPermission rPermission,
            [In] uint cMax,
            [Out] out uint pcTokens);

        [PreserveSig]
        HRESULT FindMember(
            [In] mdTypeDef td,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [In] IntPtr pvSigBlob,
            [In] uint cbSigBlob,
            [Out] out mdToken pmb);

        [PreserveSig]
        HRESULT FindMethod(
            [In] mdTypeDef td,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [In] IntPtr pvSigBlob,
            [In] uint cbSigBlob,
            [Out] out mdMethodDef pmb);

        [PreserveSig]
        HRESULT FindField(
            [In] mdTypeDef td,
            [MarshalAs(UnmanagedType.LPWStr), In] StringBuilder szName,
            [In] IntPtr pvSigBlob,
            [In] uint cbSigBlob,
            [Out] out mdFieldDef pmb);

        [PreserveSig]
        HRESULT FindMemberRef(
            [In] mdTypeRef td,
            [MarshalAs(UnmanagedType.LPWStr), In] StringBuilder szName,
            [In] IntPtr pvSigBlob, [In] uint cbSigBlob,
            [Out] out mdMemberRef pmr);

        [PreserveSig]
        HRESULT GetMethodProps(
            [In] mdMethodDef mb,
            [Out] out mdTypeDef pClass,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szMethod,
            [In] uint cchMethod,
            [Out] out int pchMethod,
            [Out] out CorMethodAttr pdwAttr,
            [Out] out IntPtr ppvSigBlob,
            [Out] out uint pcbSigBlob,
            [Out] out uint pulCodeRVA,
            [Out] out uint pdwImplFlags);

        [PreserveSig]
        HRESULT GetMemberRefProps(
            [In] mdMemberRef mr,
            [Out] out mdToken ptk,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szMember,
            [In] uint cchMember,
            [Out] out uint pchMember,
            [Out] out IntPtr ppvSigBlob,
            [Out] out uint pbSig);

        [PreserveSig]
        HRESULT EnumProperties(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef td,
            [Out] mdProperty[] rProperties,
            [In] uint cMax,
            [Out] out uint pcProperties);

        [PreserveSig]
        HRESULT EnumEvents(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef td,
            [Out] mdEvent[] rEvents,
            [In] uint cMax,
            [Out] out uint pcEvents);

        [PreserveSig]
        HRESULT GetEventProps(
            [In] mdEvent ev,
            [Out] mdTypeDef pClass,
            [MarshalAs(UnmanagedType.LPWStr), Out] string szEvent,
            [In] uint cchEvent,
            [Out] out uint pchEvent,
            [Out] out uint pdwEventFlags,
            [Out] out uint ptkEventType,
            [Out] out mdMethodDef pmdAddOn,
            [Out] out mdMethodDef pmdRemoveOn,
            [Out] out mdMethodDef pmdFire,
            [Out] out mdMethodDef[] rmdOtherMethod,
            [In] uint cMax,
            [Out] uint pcOtherMethod);

        [PreserveSig]
        HRESULT EnumMethodSemantics(
            [In, Out] ref IntPtr phEnum,
            [In] mdMethodDef mb,
            [Out] mdToken[] rEventProp,
            [In] uint cMax,
            [Out] out uint pcEventProp);

        [PreserveSig]
        HRESULT GetMethodSemantics(
            [In] mdMethodDef mb,
            [In] mdToken tkEventProp,
            [Out] out CorMethodSemanticsAttr pdwSemanticsFlags);

        [PreserveSig]
        HRESULT GetClassLayout(
            [In] mdTypeDef td,
            [Out] uint pdwPackSize,
            [MarshalAs(UnmanagedType.LPArray), Out] COR_FIELD_OFFSET[] rFieldOffset,
            [In] int cMax,
            [Out] uint pcFieldOffset,
            [Out] uint pulClassSize);

        [PreserveSig]
        HRESULT GetFieldMarshal(
            [In] mdToken tk,
            [Out] out IntPtr ppvNativeType,
            [Out] out uint pcbNativeType);

        [PreserveSig]
        HRESULT GetRVA(
            [In] mdToken tk,
            [Out] out uint pulCodeRVA,
            [Out] out CorMethodImpl pdwImplFlags);

        [PreserveSig]
        HRESULT GetPermissionSetProps(
            [In] mdPermission pm,
            [Out] out uint pdwAction,
            [Out] IntPtr ppvPermission,
            [Out] out uint pcbPermission);

        [PreserveSig]
        HRESULT GetSigFromToken(
            [In] mdSignature mdSig,
            [Out] out IntPtr ppvSig,
            [Out] out uint pcbSig);

        [PreserveSig]
        HRESULT GetModuleRefProps(
            [In] mdModuleRef mur,
            [MarshalAs(UnmanagedType.LPWStr), Out] string szName,
            [In] uint cchName,
            [Out] out uint pchName);

        [PreserveSig]
        HRESULT EnumModuleRefs(
            [In, Out] ref IntPtr phEnum,
            [Out] mdModuleRef[] rModuleRefs,
            [In] uint cmax,
            [Out] out uint pcModuleRefs);

        [PreserveSig]
        HRESULT GetTypeSpecFromToken(
            [In] mdTypeSpec typespec,
            [Out] out IntPtr ppvSig,
            [Out] out uint pcbSig);

        [Obsolete]
        [PreserveSig]
        HRESULT GetNameFromToken(
            [In] mdToken tk,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder pszUtf8NamePtr);

        [PreserveSig]
        HRESULT EnumUnresolvedMethods(
            [In, Out] ref IntPtr phEnum,
            [Out] mdToken[] rMethods,
            [In] uint cMax,
            [Out] out uint pcTokens);

        [PreserveSig]
        HRESULT GetUserString(
            [In] mdString stk,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szString,
            [In] int cchString,
            [Out] out int pchString);

        [PreserveSig]
        HRESULT GetPinvokeMap(
            [In] mdToken tk,
            [Out] CorPinvokeMap pdwMappingFlags,
            [MarshalAs(UnmanagedType.LPWStr), Out] string szImportName,
            [In] int cchImportName,
            [Out] int pchImportName,
            [Out] mdModuleRef pmrImportDLL);

        [PreserveSig]
        HRESULT EnumSignatures(
            [In, Out] ref IntPtr phEnum,
            [Out] out mdSignature rSignatures,
            [In] uint cmax,
            [Out] out uint pcSignatures);

        [PreserveSig]
        HRESULT EnumTypeSpecs(
            [In, Out] ref IntPtr phEnum,
            [Out] out mdTypeSpec rTypeSpecs,
            [In] uint cmax,
            [Out] out uint pcTypeSpecs);

        [PreserveSig]
        HRESULT EnumUserStrings(
            [In, Out] ref IntPtr phEnum,
            [Out] out mdString rStrings,
            [In] uint cmax,
            [Out] out uint pcStrings);

        [PreserveSig]
        HRESULT GetParamForMethodIndex(
            [In] mdMethodDef md,
            [In] int ulParamSeq,
            [Out] out mdParamDef ppd);

        [PreserveSig]
        HRESULT EnumCustomAttributes(
            [In, Out] ref IntPtr phEnum,
            [In] mdToken tk,
            [In] mdToken tkType,
            [Out] mdCustomAttribute[] rCustomAttributes,
            [In] uint cMax,
            [Out] out uint pcCustomAttributes);

        [PreserveSig]
        HRESULT GetCustomAttributeProps(
            [In] mdCustomAttribute cv,
            [Out] out mdToken ptkObj,
            [Out] out mdToken ptkType,
            [Out] out IntPtr ppBlob,
            [Out] out uint pcbSize);

        [PreserveSig]
        HRESULT FindTypeRef(
            [In] mdToken tkResolutionScope,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [Out] out mdTypeRef ptr);

        [PreserveSig]
        HRESULT GetMemberProps(
            [In] mdToken mb,
            [Out] out mdTypeDef pClass,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szMember,
            [In] uint cchMember,
            [Out] out uint pchMember,
            [Out] out uint pdwAttr, //if its a method is it cormethodattr?
            [Out] out IntPtr ppvSigBlob,
            [Out] out uint pcbSigBlob,
            [Out] out uint pulCodeRVA,
            [Out] out uint pdwImplFlags,
            [Out] out CorElementType pdwCPlusTypeFlag,
            [Out] out IntPtr ppValue,
            [Out] out uint pcchValue);

        [PreserveSig]
        HRESULT GetFieldProps(
            [In] mdFieldDef mb,
            [Out] mdTypeDef pClass,
            [Out] StringBuilder szField,
            [In] uint cchField,
            [Out] uint pchField,
            [Out] CorFieldAttr pdwAttr,
            [Out] IntPtr ppvSigBlob,
            [Out] uint pcbSigBlob,
            [Out] CorElementType pdwCPlusTypeFlag,
            [Out] uint ppValue,
            [Out] uint pcchValue);

        [PreserveSig]
        HRESULT GetPropertyProps(
            mdProperty prop,
            mdTypeDef pClass,
            string szProperty,
            uint cchProperty,
            uint pchProperty,
            CorPropertyAttr pdwPropFlags,
            IntPtr ppvSig,
            uint pbSig,
            CorElementType pdwCPlusTypeFlag,
            IntPtr ppDefaultValue,
            uint pcchDefaultValue,
            mdMethodDef pmdSetter,
            mdMethodDef pmdGetter,
            mdMethodDef[] rmdOtherMethod,
            uint cMax,
            uint pcOtherMethod);

        [PreserveSig]
        HRESULT GetParamProps(
            [In] mdParamDef tk,
            [Out] mdMethodDef pmd,
            [Out] uint pulSequence,
            [MarshalAs(UnmanagedType.LPWStr), Out] string szName,
            [Out] uint cchName,
            [Out] uint pchName,
            [Out] CorParamAttr pdwAttr,
            [Out] CorElementType pdwCPlusTypeFlag,
            [Out] IntPtr ppValue,
            [Out] IntPtr pcchValue);

        [PreserveSig]
        HRESULT GetCustomAttributeByName(
            [In] mdToken tkObj,
            [MarshalAs(UnmanagedType.LPWStr), In] StringBuilder szName,
            [Out] IntPtr ppData,
            [Out] uint pcbData);

        [PreserveSig]
        bool IsValidToken([In] mdToken tk);

        [PreserveSig]
        HRESULT GetNestedClassProps(
            [In] mdTypeDef tdNestedClass,
            [Out] out mdTypeDef ptdEnclosingClass);

        [PreserveSig]
        HRESULT GetNativeCallConvFromSig(
            [In] IntPtr pvSig,
            [In] uint cbSig,
            [Out] out uint pCallConv);

        [PreserveSig]
        HRESULT IsGlobal(
            [In] mdToken pd,
            [Out] out int pbGlobal);
    }
}
