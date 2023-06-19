using System;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Extends the <see cref="IMetaDataImport"/> interface to provide the capability of working with generic types.
    /// </summary>
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FCE5EFA0-8BBA-4f8e-A036-8F2022B08466")]
    public interface IMetaDataImport2 : IMetaDataImport
    {
        /// <summary>
        /// Closes the enumerator that is identified by the specified handle.
        /// </summary>
        /// <param name="hEnum">[in] The handle for the enumerator to close.</param>
        /// <remarks>
        /// The handle specified by hEnum is obtained from a previous EnumName call (for example, <see cref="EnumTypeDefs"/>).
        /// </remarks>
        [PreserveSig]
        new void CloseEnum(
            [In] IntPtr hEnum);

        /// <summary>
        /// Gets the number of elements in the enumeration that was retrieved by the specified enumerator.
        /// </summary>
        /// <param name="hEnum">[in] The handle for the enumerator.</param>
        /// <param name="pulCount">[out] The number of elements enumerated.</param>
        /// <remarks>
        /// The handle specified by hEnum is obtained from a previous EnumName call (for example, <see cref="EnumTypeDefs"/>).
        /// </remarks>
        [PreserveSig]
        new HRESULT CountEnum(
            [In] IntPtr hEnum,
            [Out] out int pulCount);

        /// <summary>
        /// Resets the specified enumerator to the specified position.
        /// </summary>
        /// <param name="hEnum">[in] The enumerator to reset.</param>
        /// <param name="ulPos">[in] The new position at which to place the enumerator.</param>
        [PreserveSig]
        new HRESULT ResetEnum(
            [In] IntPtr hEnum,
            [In] int ulPos);

        /// <summary>
        /// Enumerates TypeDef tokens representing all types within the current scope.
        /// </summary>
        /// <param name="phEnum">[out] A pointer to the new enumerator. This must be NULL for the first call of this method.</param>
        /// <param name="typeDefs">[in] The array used to store the TypeDef tokens.</param>
        /// <param name="cMax">[in] The maximum size of the rTypeDefs array.</param>
        /// <param name="pcTypeDefs">[out] The number of TypeDef tokens returned in rTypeDefs.</param>
        /// <returns>
        /// | HRESULT | Description                                                         |
        /// | ------- | ------------------------------------------------------------------- |
        /// | S_OK    | EnumTypeDefs returned successfully.                                 |
        /// | S_FALSE | There are no tokens to enumerate. In that case, pcTypeDefs is zero. |
        /// </returns>
        /// <remarks>
        /// The TypeDef token represents a type such as a class or an interface, as well as any type added via an extensibility
        /// mechanism.
        /// </remarks>
        [PreserveSig]
        new HRESULT EnumTypeDefs(
            [In, Out] ref IntPtr phEnum,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] mdTypeDef[] typeDefs,
            [In] int cMax,
            [Out] out int pcTypeDefs);

        /// <summary>
        /// Enumerates all interfaces implemented by the specified TypeDef.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator.</param>
        /// <param name="td">[in] The token of the TypeDef whose MethodDef tokens representing interface implementations are to be enumerated.</param>
        /// <param name="rImpls">[out] The array used to store the MethodDef tokens.</param>
        /// <param name="cMax">[in] The maximum length of the rImpls array.</param>
        /// <param name="pcImpls">[out] The actual number of tokens returned in rImpls.</param>
        /// <returns>
        /// | HRESULT | Description                                                                       |
        /// | ------- | --------------------------------------------------------------------------------- |
        /// | S_OK    | EnumInterfaceImpls returned successfully.                                         |
        /// | S_FALSE | There are no MethodDef tokens to enumerate. In that case, pcImpls is set to zero. |
        /// </returns>
        /// <remarks>
        /// The enumeration returns a collection of <see cref="mdInterfaceImpl"/> tokens for each interface implemented by the specified
        /// TypeDef. Interface tokens are returned in the order the interfaces were specified (through DefineTypeDef or SetTypeDefProps).
        /// Properties of the returned <see cref="mdInterfaceImpl"/> tokens can be queried using <see cref="GetInterfaceImplProps"/>.
        /// </remarks>
        [PreserveSig]
        new HRESULT EnumInterfaceImpls(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef td,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] mdInterfaceImpl[] rImpls,
            [In] int cMax,
            [Out] out int pcImpls);

        /// <summary>
        /// Enumerates TypeRef tokens defined in the current metadata scope.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator. This must be NULL for the first call of this method.</param>
        /// <param name="rTypeRefs">[out] The array used to store the TypeRef tokens.</param>
        /// <param name="cMax">[in] The maximum size of the rTypeRefs array.</param>
        /// <param name="pcTypeRefs">[out] A pointer to the number of TypeRef tokens returned in rTypeRefs.</param>
        /// <returns>
        /// | HRESULT | Description                                                         |
        /// | ------- | ------------------------------------------------------------------- |
        /// | S_OK    | EnumTypeRefs returned successfully.                                 |
        /// | S_FALSE | There are no tokens to enumerate. In that case, pcTypeRefs is zero. |
        /// </returns>
        /// <remarks>
        /// A TypeRef token represents a reference to a type.
        /// </remarks>
        [PreserveSig]
        new HRESULT EnumTypeRefs(
            [In, Out] ref IntPtr phEnum,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] mdTypeRef[] rTypeRefs,
            [In] int cMax,
            [Out] out int pcTypeRefs);

        /// <summary>
        /// Gets a pointer to the TypeDef metadata token for the <see cref="Type"/> with the specified name.
        /// </summary>
        /// <param name="szTypeDef">[in] The name of the type for which to get the TypeDef token.</param>
        /// <param name="tkEnclosingClass">[in] A TypeDef or TypeRef token representing the enclosing class. If the type to find is not a nested class, set this value to NULL.</param>
        /// <param name="typeDef">[out] A pointer to the matching TypeDef token.</param>
        [PreserveSig]
        new HRESULT FindTypeDefByName(
            [MarshalAs(UnmanagedType.LPWStr), In] string szTypeDef,
            [In] mdToken tkEnclosingClass,
            [Out] out mdTypeDef typeDef);

        /// <summary>
        /// Gets the name and optionally the version identifier of the assembly or module in the current metadata scope.
        /// </summary>
        /// <param name="szName">[out] A buffer for the assembly or module name.</param>
        /// <param name="cchName">[in] The size in wide characters of szName.</param>
        /// <param name="pchName">[out] The number of wide characters returned in szName.</param>
        /// <param name="pmvid">[out, optional] A pointer to a GUID that uniquely identifies the version of the assembly or module.</param>
        /// <remarks>
        /// The <see cref="IMetaDataEmit.SetModuleProps"/> method is used to set these properties.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetScopeProps(
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1), Out] char[] szName,
            [In] int cchName,
            [Out] out int pchName,
            [Out] out Guid pmvid);

        /// <summary>
        /// Gets a metadata token for the module referenced in the current metadata scope.
        /// </summary>
        /// <param name="pmd">[out] A pointer to the token representing the module referenced in the current metadata scope.</param>
        [PreserveSig]
        new HRESULT GetModuleFromScope(
            [Out] out mdModule pmd);

        /// <summary>
        /// Returns metadata information for the <see cref="Type"/> represented by the specified TypeDef token.
        /// </summary>
        /// <param name="td">[in] The TypeDef token that represents the type to return metadata for.</param>
        /// <param name="szTypeDef">[out] A buffer containing the type name.</param>
        /// <param name="cchTypeDef">[in] The size in wide characters of szTypeDef.</param>
        /// <param name="pchTypeDef">[out] The number of wide characters returned in szTypeDef.</param>
        /// <param name="pdwTypeDefFlags">[out] A pointer to any flags that modify the type definition. This value is a bitmask from the <see cref="CorTypeAttr"/> enumeration.</param>
        /// <param name="ptkExtends">[out] A TypeDef or TypeRef metadata token that represents the base type of the requested type.</param>
        [PreserveSig]
        new HRESULT GetTypeDefProps(
            [In] mdTypeDef td,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2), Out] char[] szTypeDef,
            [In] int cchTypeDef,
            [Out] out int pchTypeDef,
            [Out] out CorTypeAttr pdwTypeDefFlags,
            [Out] out mdToken ptkExtends);

        /// <summary>
        /// Gets a pointer to the metadata tokens for the <see cref="Type"/> that implements the specified method, and for the interface that declares that method.
        /// </summary>
        /// <param name="iiImpl">[in] The metadata token representing the method to return the class and interface tokens for.</param>
        /// <param name="pClass">[out] The metadata token representing the class that implements the method.</param>
        /// <param name="ptkIface">[out] The metadata token representing the interface that defines the implemented method.</param>
        /// <remarks>
        /// You obtain the value for iImpl by calling the <see cref="EnumInterfaceImpls"/> method. For example, suppose that
        /// a class has an <see cref="mdTypeDef"/> token value of 0x02000007 and that it implements three interfaces whose types have tokens:
        /// Conceptually, this information is stored into an interface implementation table as: Recall, the token is a 4-byte
        /// value: GetInterfaceImplProps returns the information held in the row whose token you provide in the iImpl argument.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetInterfaceImplProps(
            [In] mdInterfaceImpl iiImpl,
            [Out] out mdTypeDef pClass,
            [Out] out mdToken ptkIface);

        /// <summary>
        /// Gets the metadata associated with the <see cref="Type"/> referenced by the specified TypeRef token.
        /// </summary>
        /// <param name="tr">[in] The TypeRef token that represents the type to return metadata for.</param>
        /// <param name="ptkResolutionScope">[out] A pointer to the scope in which the reference is made. This value is an AssemblyRef or ModuleRef token.</param>
        /// <param name="szName">[out] A buffer containing the type name.</param>
        /// <param name="cchName">[in] The requested size in wide characters of szName.</param>
        /// <param name="pchName">[out] The returned size in wide characters of szName.</param>
        [PreserveSig]
        new HRESULT GetTypeRefProps(
            [In] mdTypeRef tr,
            [Out] out mdToken ptkResolutionScope,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3)] char[] szName,
            [In] int cchName,
            [Out] out int pchName);

        /// <summary>
        /// Resolves a <see cref="Type"/> reference represented by the specified TypeRef token.
        /// </summary>
        /// <param name="tr">[in] The TypeRef metadata token to return the referenced type information for.</param>
        /// <param name="riid">[in] The IID of the interface to return in ppIScope. Typically, this would be IID_IMetaDataImport.</param>
        /// <param name="ppIScope">[out] An interface to the module scope in which the referenced type is defined.</param>
        /// <param name="ptd">[out] A pointer to a TypeDef token that represents the referenced type.</param>
        /// <remarks>
        /// The ResolveTypeRef method searches for the type definition in other modules. If the type definition is found, ResolveTypeRef
        /// returns an interface to that module scope as well as the TypeDef token for the type. If the type reference to be
        /// resolved has a resolution scope of AssemblyRef, the ResolveTypeRef method searches for a match only in the metadata
        /// scopes that have already been opened with calls to either the <see cref="IMetaDataDispenser.OpenScope"/> method
        /// or the <see cref="IMetaDataDispenser.OpenScopeOnMemory"/> method. This is because ResolveTypeRef cannot determine
        /// from only the AssemblyRef scope where on disk or in the global assembly cache the assembly is stored.
        /// </remarks>
        [Obsolete("This method no longer appears to exist in the IMetaDataImport vtable.")]
        [PreserveSig]
        new HRESULT ResolveTypeRef(
            [In] mdTypeRef tr,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [MarshalAs(UnmanagedType.Interface), Out] out object ppIScope,
            [Out] out mdTypeDef ptd);

        /// <summary>
        /// Enumerates MemberDef tokens representing members of the specified type.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator.</param>
        /// <param name="cl">[in] A TypeDef token representing the type whose members are to be enumerated.</param>
        /// <param name="rMembers">[out] The array used to hold the MemberDef tokens.</param>
        /// <param name="cMax">[in] The maximum size of the rMembers array.</param>
        /// <param name="pcTokens">[out] The actual number of MemberDef tokens returned in rMembers.</param>
        /// <returns>
        /// | HRESULT | Description                                                                 |
        /// | ------- | --------------------------------------------------------------------------- |
        /// | S_OK    | EnumMembers returned successfully.                                          |
        /// | S_FALSE | There are no MemberDef tokens to enumerate. In that case, pcTokens is zero. |
        /// </returns>
        /// <remarks>
        /// When enumerating collections of members for a class, EnumMembers returns only members (fields and methods, but
        /// not properties or events) defined directly on the class. It does not return any members that the class inherits,
        /// even if the class provides an implementation for those inherited members. To enumerate inherited members, the caller
        /// must explicitly walk the inheritance chain. Note that the rules for the inheritance chain may vary depending on
        /// the language or compiler that emitted the original metadata. Properties and events are not enumerated by EnumMembers.
        /// To enumerate those, use <see cref="EnumProperties"/> or <see cref="EnumEvents"/>.
        /// </remarks>
        [PreserveSig]
        new HRESULT EnumMembers(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef cl,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] mdToken[] rMembers,
            [In] int cMax,
            [Out] out int pcTokens);

        /// <summary>
        /// Enumerates MemberDef tokens representing members of the specified type with the specified name.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator.</param>
        /// <param name="cl">[in] A TypeDef token representing the type with members to enumerate.</param>
        /// <param name="szName">[in] The member name that limits the scope of the enumerator.</param>
        /// <param name="rMembers">[out] The array used to store the MemberDef tokens.</param>
        /// <param name="cMax">[in] The maximum size of the rMembers array.</param>
        /// <param name="pcTokens">[out] The actual number of MemberDef tokens returned in rMembers.</param>
        /// <returns>
        /// | HRESULT | Description                                                                 |
        /// | ------- | --------------------------------------------------------------------------- |
        /// | S_OK    | EnumTypeDefs returned successfully.                                         |
        /// | S_FALSE | There are no MemberDef tokens to enumerate. In that case, pcTokens is zero. |
        /// </returns>
        /// <remarks>
        /// This method enumerates fields and methods, but not properties or events. Unlike <see cref="EnumMembers"/>, EnumMembersWithName
        /// discards all field and member tokens that do not have the specified name.
        /// </remarks>
        [PreserveSig]
        new HRESULT EnumMembersWithName(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef cl,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] mdToken[] rMembers,
            [In] int cMax,
            [Out] out int pcTokens);

        /// <summary>
        /// Enumerates MethodDef tokens representing methods of the specified type.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator. This must be NULL for the first call of this method.</param>
        /// <param name="cl">[in] A TypeDef token representing the type with the methods to enumerate.</param>
        /// <param name="rMethods">[out] The array to store the MethodDef tokens.</param>
        /// <param name="cMax">[in] The maximum size of the MethodDef rMethods array.</param>
        /// <param name="pcTokens">[out] The number of MethodDef tokens returned in rMethods.</param>
        /// <returns>
        /// | HRESULT | Description                                                                 |
        /// | ------- | --------------------------------------------------------------------------- |
        /// | S_OK    | EnumMethods returned successfully.                                          |
        /// | S_FALSE | There are no MethodDef tokens to enumerate. In that case, pcTokens is zero. |
        /// </returns>
        [PreserveSig]
        new HRESULT EnumMethods(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef cl,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] mdMethodDef[] rMethods,
            [In] int cMax,
            [Out] out int pcTokens);

        /// <summary>
        /// Enumerates methods that have the specified name and that are defined by the type referenced by the specified TypeDef token.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator. This must be NULL for the first call of this method.</param>
        /// <param name="cl">[in] A TypeDef token representing the type whose methods to enumerate.</param>
        /// <param name="szName">[in] The name that limits the scope of the enumeration.</param>
        /// <param name="rMethods">[out] The array used to store the MethodDef tokens.</param>
        /// <param name="cMax">[in] The maximum size of the rMethods array.</param>
        /// <param name="pcTokens">[out] The number of MethodDef tokens returned in rMethods.</param>
        /// <returns>
        /// | HRESULT | Description                                                       |
        /// | ------- | ----------------------------------------------------------------- |
        /// | S_OK    | EnumMethodsWithName returned successfully.                        |
        /// | S_FALSE | There are no tokens to enumerate. In that case, pcTokens is zero. |
        /// </returns>
        /// <remarks>
        /// This method enumerates fields and methods, but not properties or events. Unlike <see cref="EnumMethods"/>, EnumMethodsWithName
        /// discards all method tokens that do not have the specified name.
        /// </remarks>
        [PreserveSig]
        new HRESULT EnumMethodsWithName(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef cl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] mdMethodDef[] rMethods,
            [In] int cMax,
            [Out] out int pcTokens);

        /// <summary>
        /// Enumerates FieldDef tokens for the type referenced by the specified TypeDef token.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator.</param>
        /// <param name="cl">[in] The TypeDef token of the class whose fields are to be enumerated.</param>
        /// <param name="rFields">[out] The list of FieldDef tokens.</param>
        /// <param name="cMax">[in] The maximum size of the rFields array.</param>
        /// <param name="pcTokens">[out] The actual number of FieldDef tokens returned in rFields.</param>
        /// <returns>
        /// | HRESULT | Description                                                       |
        /// | ------- | ----------------------------------------------------------------- |
        /// | S_OK    | EnumFields returned successfully.                                 |
        /// | S_FALSE | There are no fields to enumerate. In that case, pcTokens is zero. |
        /// </returns>
        [PreserveSig]
        new HRESULT EnumFields(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef cl,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] mdFieldDef[] rFields,
            [In] int cMax,
            [Out] out int pcTokens);

        /// <summary>
        /// Enumerates FieldDef tokens of the specified type with the specified name.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator.</param>
        /// <param name="cl">[in] The token of the type whose fields are to be enumerated.</param>
        /// <param name="szName">[in] The field name that limits the scope of the enumeration.</param>
        /// <param name="rFields">[out] Array used to store the FieldDef tokens.</param>
        /// <param name="cMax">[in] The maximum size of the rFields array.</param>
        /// <param name="pcTokens">[out] The actual number of FieldDef tokens returned in rFields.</param>
        /// <returns>
        /// | HRESULT | Description                                                       |
        /// | ------- | ----------------------------------------------------------------- |
        /// | S_OK    | EnumFieldsWithName returned successfully.                         |
        /// | S_FALSE | There are no fields to enumerate. In that case, pcTokens is zero. |
        /// </returns>
        /// <remarks>
        /// Unlike <see cref="EnumFields"/>, EnumFieldsWithName discards all field tokens that do not have the specified name.
        /// </remarks>
        [PreserveSig]
        new HRESULT EnumFieldsWithName(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef cl,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] mdFieldDef[] rFields,
            [In] int cMax,
            [Out] out int pcTokens);

        /// <summary>
        /// Enumerates ParamDef tokens representing the parameters of the method referenced by the specified MethodDef token.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator. This must be NULL for the first call of this method.</param>
        /// <param name="mb">[in] A MethodDef token representing the method with the parameters to enumerate.</param>
        /// <param name="rParams">[out] The array used to store the ParamDef tokens.</param>
        /// <param name="cMax">[in] The maximum size of the rParams array.</param>
        /// <param name="pcTokens">[out] The number of ParamDef tokens returned in rParams.</param>
        /// <returns>
        /// | HRESULT | Description                                                       |
        /// | ------- | ----------------------------------------------------------------- |
        /// | S_OK    | EnumParams returned successfully.                                 |
        /// | S_FALSE | There are no tokens to enumerate. In that case, pcTokens is zero. |
        /// </returns>
        [PreserveSig]
        new HRESULT EnumParams(
            [In, Out] ref IntPtr phEnum,
            [In] mdMethodDef mb,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] mdParamDef[] rParams,
            [In] int cMax,
            [Out] out int pcTokens);

        /// <summary>
        /// Enumerates MemberRef tokens representing members of the specified type.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator.</param>
        /// <param name="tkParent">[in] A TypeDef, TypeRef, MethodDef, or ModuleRef token for the type whose members are to be enumerated.</param>
        /// <param name="rMemberRefs">[out] The array used to store MemberRef tokens.</param>
        /// <param name="cMax">[in] The maximum size of the rMemberRefs array.</param>
        /// <param name="pcTokens">[out] The actual number of MemberRef tokens returned in rMemberRefs.</param>
        /// <returns>
        /// | HRESULT | Description                                                                    |
        /// | ------- | ------------------------------------------------------------------------------ |
        /// | S_OK    | EnumMemberRefs returned successfully.                                          |
        /// | S_FALSE | There are no MemberRef tokens to enumerate. In that case, pcTokens is to zero. |
        /// </returns>
        [PreserveSig]
        new HRESULT EnumMemberRefs(
            [In, Out] ref IntPtr phEnum,
            [In] mdToken tkParent,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] mdMemberRef[] rMemberRefs,
            [In] int cMax,
            [Out] out int pcTokens);

        /// <summary>
        /// Enumerates MethodBody and MethodDeclaration tokens representing methods of the specified type.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator. This must be NULL for the first call of this method.</param>
        /// <param name="td">[in] A TypeDef token for the type whose method implementations to enumerate.</param>
        /// <param name="rMethodBody">[out] The array to store the MethodBody tokens.</param>
        /// <param name="rMethodDecl">[out] The array to store the MethodDeclaration tokens.</param>
        /// <param name="cMax">[in] The maximum size of the rMethodBody and rMethodDecl arrays.</param>
        /// <param name="pcTokens">[in] The actual number of methods returned in rMethodBody and rMethodDecl.</param>
        /// <returns>
        /// | HRESULT | Description                                                              |
        /// | ------- | ------------------------------------------------------------------------ |
        /// | S_OK    | EnumMethodImpls returned successfully.                                   |
        /// | S_FALSE | There are no method tokens to enumerate. In that case, pcTokens is zero. |
        /// </returns>
        [PreserveSig]
        new HRESULT EnumMethodImpls(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef td,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] mdToken[] rMethodBody,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] mdToken[] rMethodDecl,
            [In] int cMax,
            [Out] out int pcTokens);

        /// <summary>
        /// Enumerates permissions for the objects in a specified metadata scope.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator. This must be NULL for the first call of this method.</param>
        /// <param name="tk">[in] A metadata token that limits the scope of the search, or NULL to search the widest scope possible.</param>
        /// <param name="dwActions">[in] Flags representing the security action values to include in rPermission, or zero to return all actions.</param>
        /// <param name="rPermission">[out] The array used to store the Permission tokens.</param>
        /// <param name="cMax">[in] The maximum size of the rPermission array.</param>
        /// <param name="pcTokens">[out] The number of Permission tokens returned in rPermission.</param>
        /// <returns>
        /// | HRESULT | Description                                                       |
        /// | ------- | ----------------------------------------------------------------- |
        /// | S_OK    | EnumPermissionSets returned successfully.                         |
        /// | S_FALSE | There are no tokens to enumerate. In that case, pcTokens is zero. |
        /// </returns>
        [PreserveSig]
        new HRESULT EnumPermissionSets(
            [In, Out] ref IntPtr phEnum,
            [In] mdToken tk,
            [In] CorDeclSecurity dwActions,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] mdPermission[] rPermission,
            [In] int cMax,
            [Out] out int pcTokens);

        /// <summary>
        /// Gets a pointer to the MemberDef token for field or method that is enclosed by the specified <see cref="Type"/> and that has the specified name and metadata signature.
        /// </summary>
        /// <param name="td">[in] The TypeDef token for the class or interface that encloses the member to search for. If this value is mdTokenNil, the lookup is done for a global-variable or global-function.</param>
        /// <param name="szName">[in] The name of the member to search for.</param>
        /// <param name="pvSigBlob">[in] A pointer to the binary metadata signature of the member.</param>
        /// <param name="cbSigBlob">[in] The size in bytes of pvSigBlob.</param>
        /// <param name="pmb">[out] A pointer to the matching MemberDef token.</param>
        /// <remarks>
        /// You specify the member using its enclosing class or interface (td), its name (szName), and optionally its signature
        /// (pvSigBlob). There might be multiple members with the same name in a class or interface. In that case, pass the
        /// member's signature to find the unique match. The signature passed to FindMember must have been generated in the
        /// current scope, because signatures are bound to a particular scope. A signature can embed a token that identifies
        /// the enclosing class or value type. The token is an index into the local TypeDef table. You cannot build a run-time
        /// signature outside the context of the current scope and use that signature as input to input to FindMember. FindMember
        /// finds only members that were defined directly in the class or interface; it does not find inherited members.
        /// </remarks>
        [PreserveSig]
        new HRESULT FindMember(
            [In] mdToken td,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [In] IntPtr pvSigBlob,
            [In] int cbSigBlob,
            [Out] out mdToken pmb);

        /// <summary>
        /// Gets a pointer to the MethodDef token for the method that is enclosed by the specified <see cref="Type"/> and that has the specified name and metadata signature.
        /// </summary>
        /// <param name="td">[in] The <see cref="mdTypeDef"/> token for the type (a class or interface) that encloses the member to search for. If this value is mdTokenNil, then the lookup is done for a global function.</param>
        /// <param name="szName">[in] The name of the method to search for.</param>
        /// <param name="pvSigBlob">[in] A pointer to the binary metadata signature of the method.</param>
        /// <param name="cbSigBlob">[in] The size in bytes of pvSigBlob.</param>
        /// <param name="pmb">[out] A pointer to the matching MethodDef token.</param>
        /// <remarks>
        /// You specify the method using its enclosing class or interface (td), its name (szName), and optionally its signature
        /// (pvSigBlob). There might be multiple methods with the same name in a class or interface. In that case, pass the
        /// method's signature to find the unique match. The signature passed to FindMethod must have been generated in the
        /// current scope, because signatures are bound to a particular scope. A signature can embed a token that identifies
        /// the enclosing class or value type. The token is an index into the local TypeDef table. You cannot build a run-time
        /// signature outside the context of the current scope and use that signature as input to input to FindMethod. FindMethod
        /// finds only methods that were defined directly in the class or interface; it does not find inherited methods.
        /// </remarks>
        [PreserveSig]
        new HRESULT FindMethod(
            [In] mdToken td,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [In] IntPtr pvSigBlob,
            [In] int cbSigBlob,
            [Out] out mdMethodDef pmb);

        /// <summary>
        /// Gets a pointer to the FieldDef token for the field that is enclosed by the specified <see cref="Type"/> and that has the specified name and metadata signature.
        /// </summary>
        /// <param name="td">[in] The TypeDef token for the class or interface that encloses the field to search for. If this value is mdTokenNil, the lookup is done for a global variable.</param>
        /// <param name="szName">[in] The name of the field to search for.</param>
        /// <param name="pvSigBlob">[in] A pointer to the binary metadata signature of the field.</param>
        /// <param name="cbSigBlob">[in] The size in bytes of pvSigBlob.</param>
        /// <param name="pmb">[out] A pointer to the matching FieldDef token.</param>
        /// <remarks>
        /// You specify the field using its enclosing class or interface (td), its name (szName), and optionally its signature
        /// (pvSigBlob). The signature passed to FindField must have been generated in the current scope, because signatures
        /// are bound to a particular scope. A signature can embed a token that identifies the enclosing class or value type.
        /// (The token is an index into the local TypeDef table). You cannot build a run-time signature outside the context
        /// of the current scope and use that signature as input to FindField. FindField finds only fields that were defined
        /// directly in the class or interface; it does not find inherited fields.
        /// </remarks>
        [PreserveSig]
        new HRESULT FindField(
            [In] mdToken td,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [In] IntPtr pvSigBlob,
            [In] int cbSigBlob,
            [Out] out mdFieldDef pmb);

        /// <summary>
        /// Gets a pointer to the MemberRef token for the member reference that is enclosed by the specified <see cref="Type"/> and that has the specified name and metadata signature.
        /// </summary>
        /// <param name="td">[in] The TypeRef token for the class or interface that encloses the member reference to search for. If this value is mdTokenNil, the lookup is done for a global variable or a global-function reference.</param>
        /// <param name="szName">[in] The name of the member reference to search for.</param>
        /// <param name="pvSigBlob">[in] A pointer to the binary metadata signature of the member reference.</param>
        /// <param name="cbSigBlob">[in] The size in bytes of pvSigBlob.</param>
        /// <param name="pmr">[out] A pointer to the matching MemberRef token.</param>
        /// <remarks>
        /// You specify the member using its enclosing class or interface (td), its name (szName), and optionally its signature
        /// (pvSigBlob). The signature passed to FindMemberRef must have been generated in the current scope, because signatures
        /// are bound to a particular scope. A signature can embed a token that identifies the enclosing class or value type.
        /// The token is an index into the local TypeDef table. You cannot build a run-time signature outside the context of
        /// the current scope and use that signature as input to FindMemberRef. FindMemberRef finds only member references
        /// that were defined directly in the class or interface; it does not find inherited member references.
        /// </remarks>
        [PreserveSig]
        new HRESULT FindMemberRef(
            [In] mdToken td,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [In] IntPtr pvSigBlob,
            [In] int cbSigBlob,
            [Out] out mdMemberRef pmr);

        /// <summary>
        /// Gets the metadata associated with the method referenced by the specified MethodDef token.
        /// </summary>
        /// <param name="mb">[in] The MethodDef token that represents the method to return metadata for.</param>
        /// <param name="pClass">[out] A Pointer to a TypeDef token that represents the type that implements the method.</param>
        /// <param name="szMethod">[out] A Pointer to a buffer that has the method's name.</param>
        /// <param name="cchMethod">[in] The requested size of szMethod.</param>
        /// <param name="pchMethod">[out] A Pointer to the size in wide characters of szMethod, or in the case of truncation, the actual number of wide characters in the method name.</param>
        /// <param name="pdwAttr">[out] A pointer to any flags associated with the method.</param>
        /// <param name="ppvSigBlob">[out] A pointer to the binary metadata signature of the method.</param>
        /// <param name="pcbSigBlob">[out] A Pointer to the size in bytes of ppvSigBlob.</param>
        /// <param name="pulCodeRVA">[out] A pointer to the relative virtual address of the method.</param>
        /// <param name="pdwImplFlags">[out] A pointer to any implementation flags for the method.</param>
        [PreserveSig]
        new HRESULT GetMethodProps(
            [In] mdMethodDef mb,
            [Out] out mdTypeDef pClass,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3), Out] char[] szMethod,
            [In] int cchMethod,
            [Out] out int pchMethod,
            [Out] out CorMethodAttr pdwAttr,
            [Out] out IntPtr ppvSigBlob,
            [Out] out int pcbSigBlob,
            [Out] out int pulCodeRVA,
            [Out] out CorMethodImpl pdwImplFlags);

        /// <summary>
        /// Gets metadata associated with the member referenced by the specified token.
        /// </summary>
        /// <param name="mr">[in] The MemberRef token to return associated metadata for.</param>
        /// <param name="ptk">[out] A TypeDef or TypeRef, or TypeSpec token that represents the class that declares the member, or a ModuleRef token that represents the module class that declares the member, or a MethodDef that represents the member.</param>
        /// <param name="szMember">[out] A string buffer for the member's name.</param>
        /// <param name="cchMember">[in] The requested size in wide characters of szMember.</param>
        /// <param name="pchMember">[out] The returned size in wide characters of szMember.</param>
        /// <param name="ppvSigBlob">[out] A pointer to the binary metadata signature for the member.</param>
        /// <param name="pbSig">[out] The size in bytes of ppvSigBlob.</param>
        [PreserveSig]
        new HRESULT GetMemberRefProps(
            [In] mdMemberRef mr,
            [Out] out mdToken ptk,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3), Out] char[] szMember,
            [In] int cchMember,
            [Out] out int pchMember,
            [Out] out IntPtr ppvSigBlob,
            [Out] out int pbSig);

        /// <summary>
        /// Enumerates PropertyDef tokens representing the properties of the type referenced by the specified TypeDef token.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator. This must be NULL for the first call of this method.</param>
        /// <param name="td">[in] A TypeDef token representing the type with properties to enumerate.</param>
        /// <param name="rProperties">[out] The array used to store the PropertyDef tokens.</param>
        /// <param name="cMax">[in] The maximum size of the rProperties array.</param>
        /// <param name="pcProperties">[out] The number of PropertyDef tokens returned in rProperties.</param>
        /// <returns>
        /// | HRESULT | Description                                                           |
        /// | ------- | --------------------------------------------------------------------- |
        /// | S_OK    | EnumProperties returned successfully.                                 |
        /// | S_FALSE | There are no tokens to enumerate. In that case, pcProperties is zero. |
        /// </returns>
        [PreserveSig]
        new HRESULT EnumProperties(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef td,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] mdProperty[] rProperties,
            [In] int cMax,
            [Out] out int pcProperties);

        /// <summary>
        /// Enumerates event definition tokens for the specified TypeDef token.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator.</param>
        /// <param name="td">[in] The TypeDef token whose event definitions are to be enumerated.</param>
        /// <param name="rEvents">[out] The array of returned events.</param>
        /// <param name="cMax">[in] The maximum size of the rEvents array.</param>
        /// <param name="pcEvents">[out] The actual number of events returned in rEvents.</param>
        /// <returns>
        /// | HRESULT | Description                                                       |
        /// | ------- | ----------------------------------------------------------------- |
        /// | S_OK    | EnumEvents returned successfully.                                 |
        /// | S_FALSE | There are no events to enumerate. In that case, pcEvents is zero. |
        /// </returns>
        [PreserveSig]
        new HRESULT EnumEvents(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef td,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] mdEvent[] rEvents,
            [In] int cMax,
            [Out] out int pcEvents);

        /// <summary>
        /// Gets metadata information for the event represented by the specified event token, including the declaring type, the add and remove methods for delegates, and any flags and other associated data.
        /// </summary>
        /// <param name="ev">[in] The event metadata token representing the event to get metadata for.</param>
        /// <param name="pClass">[out] A pointer to the TypeDef token representing the class that declares the event.</param>
        /// <param name="szEvent">[out] The name of the event referenced by ev.</param>
        /// <param name="cchEvent">[in] The requested length in wide characters of szEvent.</param>
        /// <param name="pchEvent">[out] The returned length in wide characters of szEvent.</param>
        /// <param name="pdwEventFlags">[out] A pointer to the event flags of the event.</param>
        /// <param name="ptkEventType">[out] A pointer to a TypeRef or TypeDef metadata token representing the System.Delegate type of the event.</param>
        /// <param name="pmdAddOn">[out] A pointer to the metadata token representing the method that adds handlers for the event.</param>
        /// <param name="pmdRemoveOn">[out] A pointer to the metadata token representing the method that removes handlers for the event.</param>
        /// <param name="pmdFire">[out] A pointer to the metadata token representing the method that raises the event.</param>
        /// <param name="rmdOtherMethod">[out] An array of token pointers to other methods associated with the event.</param>
        /// <param name="cMax">[in] The maximum size of the rmdOtherMethod array.</param>
        /// <param name="pcOtherMethod">[out] The number of tokens returned in rmdOtherMethod.</param>
        [PreserveSig]
        new HRESULT GetEventProps(
            [In] mdEvent ev,
            [Out] out mdTypeDef pClass,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3), Out] char[] szEvent,
            [In] int cchEvent,
            [Out] out int pchEvent,
            [Out] out CorEventAttr pdwEventFlags,
            [Out] out mdToken ptkEventType,
            [Out] out mdMethodDef pmdAddOn,
            [Out] out mdMethodDef pmdRemoveOn,
            [Out] out mdMethodDef pmdFire,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 11)] mdMethodDef[] rmdOtherMethod,
            [In] int cMax,
            [Out] out int pcOtherMethod);

        /// <summary>
        /// Enumerates the properties and the property-change events to which the specified method is related.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator. This must be NULL for the first call of this method.</param>
        /// <param name="mb">[in] A MethodDef token that limits the scope of the enumeration.</param>
        /// <param name="rEventProp">[out] The array used to store the events or properties.</param>
        /// <param name="cMax">[in] The maximum size of the rEventProp array.</param>
        /// <param name="pcEventProp">[out] The number of events or properties returned in rEventProp.</param>
        /// <returns>
        /// | HRESULT | Description                                                                        |
        /// | ------- | ---------------------------------------------------------------------------------- |
        /// | S_OK    | EnumMethodSemantics returned successfully.                                         |
        /// | S_FALSE | There are no events or properties to enumerate. In that case, pcEventProp is zero. |
        /// </returns>
        /// <remarks>
        /// Many common language runtime types define PropertyChanged events and OnPropertyChanged methods related to their
        /// properties. For example, the System.Windows.Forms.Control type defines a System.Windows.Forms.Control.Font property,
        /// a System.Windows.Forms.Control.FontChanged event, and an System.Windows.Forms.Control.OnFontChanged method. The
        /// set accessor method of the System.Windows.Forms.Control.Font property calls System.Windows.Forms.Control.OnFontChanged
        /// method, which in turn raises the System.Windows.Forms.Control.FontChanged event. You would call EnumMethodSemantics
        /// using the MethodDef for System.Windows.Forms.Control.OnFontChanged to get references to the System.Windows.Forms.Control.Font
        /// property and the System.Windows.Forms.Control.FontChanged event.
        /// </remarks>
        [PreserveSig]
        new HRESULT EnumMethodSemantics(
            [In, Out] ref IntPtr phEnum,
            [In] mdMethodDef mb,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] mdToken[] rEventProp,
            [In] int cMax,
            [Out] out int pcEventProp);

        /// <summary>
        /// Gets flags indicating the relationship between the method referenced by the specified MethodDef token and the paired property and event referenced by the specified EventProp token.
        /// </summary>
        /// <param name="mb">[in] A MethodDef token representing the method to get the semantic role information for.</param>
        /// <param name="tkEventProp">[in] A token representing the paired property and event for which to get the method's role.</param>
        /// <param name="pdwSemanticsFlags">[out] A pointer to the associated semantics flags. This value is a bitmask from the <see cref="CorMethodSemanticsAttr"/> enumeration.</param>
        /// <remarks>
        /// The <see cref="IMetaDataEmit.DefineProperty"/> method sets a method's semantics flags.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetMethodSemantics(
            [In] mdMethodDef mb,
            [In] mdToken tkEventProp,
            [Out] out CorMethodSemanticsAttr pdwSemanticsFlags);

        /// <summary>
        /// Gets layout information for the class referenced by the specified TypeDef token.
        /// </summary>
        /// <param name="td">[in] The TypeDef token for the class with the layout to return.</param>
        /// <param name="pdwPackSize">[out] One of the values 1, 2, 4, 8, or 16, representing the pack size of the class.</param>
        /// <param name="rFieldOffset">[out] An array of <see cref="COR_FIELD_OFFSET"/> values.</param>
        /// <param name="cMax">[in] The maximum size of the rFieldOffset array.</param>
        /// <param name="pcFieldOffset">[out] The number of elements returned in rFieldOffset.</param>
        /// <param name="pulClassSize">[out] The size in bytes of the class represented by td.</param>
        [PreserveSig]
        new HRESULT GetClassLayout(
            [In] mdTypeDef td,
            [Out] out int pdwPackSize,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3), Out] COR_FIELD_OFFSET[] rFieldOffset,
            [In] int cMax,
            [Out] out int pcFieldOffset,
            [Out] out int pulClassSize);

        /// <summary>
        /// Gets a pointer to the native, unmanaged type of the field represented by the specified field metadata token.
        /// </summary>
        /// <param name="tk">[in] The metadata token that represents the field to get interop marshalling information for.</param>
        /// <param name="ppvNativeType">[out] A pointer to the metadata signature of the field's native type.</param>
        /// <param name="pcbNativeType">[out] The size in bytes of ppvNativeType.</param>
        [PreserveSig]
        new HRESULT GetFieldMarshal(
            [In] mdToken tk,
            [Out] out IntPtr ppvNativeType,
            [Out] out int pcbNativeType);

        /// <summary>
        /// Gets the relative virtual address (RVA) and the implementation flags of the method or field represented by the specified token.
        /// </summary>
        /// <param name="tk">[in] A MethodDef or FieldDef metadata token that represents the code object to return the RVA for. If the token is a FieldDef, the field must be a global variable.</param>
        /// <param name="pulCodeRVA">[out] A pointer to the relative virtual address of the code object represented by the token.</param>
        /// <param name="pdwImplFlags">[out] A pointer to the implementation flags for the method. This value is a bitmask from the <see cref="CorMethodImpl"/> enumeration.<para/>
        /// The value of pdwImplFlags is valid only if tk is a MethodDef token.</param>
        [PreserveSig]
        new HRESULT GetRVA(
            [In] mdToken tk,
            [Out] out int pulCodeRVA,
            [Out] out CorMethodImpl pdwImplFlags);

        /// <summary>
        /// Gets the metadata associated with the System.Security.PermissionSet represented by the specified Permission token.
        /// </summary>
        /// <param name="pm">[in] The Permission metadata token that represents the permission set to get the metadata properties for.</param>
        /// <param name="pdwAction">[out] A pointer to the permission set.</param>
        /// <param name="ppvPermission">[out] A pointer to the binary metadata signature of the permission set.</param>
        /// <param name="pcbPermission">[out] The size in bytes of ppvPermission.</param>
        [PreserveSig]
        new HRESULT GetPermissionSetProps(
            [In] mdPermission pm,
            [Out] out CorDeclSecurity pdwAction,
            [Out] out IntPtr ppvPermission,
            [Out] out int pcbPermission);

        /// <summary>
        /// Gets the binary metadata signature associated with the specified token.
        /// </summary>
        /// <param name="mdSig">[in] The token to return the binary metadata signature for.</param>
        /// <param name="ppvSig">[out] A pointer to the returned metadata signature.</param>
        /// <param name="pcbSig">[out] The size in bytes of the binary metadata signature.</param>
        [PreserveSig]
        new HRESULT GetSigFromToken(
            [In] mdSignature mdSig,
            [Out] out IntPtr ppvSig,
            [Out] out int pcbSig);

        /// <summary>
        /// Gets the name of the module referenced by the specified metadata token.
        /// </summary>
        /// <param name="mur">[in] The ModuleRef metadata token that references the module to get metadata information for.</param>
        /// <param name="szName">[out] A buffer to hold the module name.</param>
        /// <param name="cchName">[in] The requested size of szName in wide characters.</param>
        /// <param name="pchName">[out] The returned size of szName in wide characters.</param>
        [PreserveSig]
        new HRESULT GetModuleRefProps(
            [In] mdModuleRef mur,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2), Out] char[] szName,
            [In] int cchName,
            [Out] out int pchName);

        /// <summary>
        /// Enumerates ModuleRef tokens that represent imported modules.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator. This must be NULL for the first call of this method.</param>
        /// <param name="rModuleRefs">[out] The array used to store the ModuleRef tokens.</param>
        /// <param name="cmax">[in] The maximum size of the rModuleRefs array.</param>
        /// <param name="pcModuleRefs">[out] The number of ModuleRef tokens returned in rModuleRefs.</param>
        /// <returns>
        /// | HRESULT | Description                                                           |
        /// | ------- | --------------------------------------------------------------------- |
        /// | S_OK    | EnumModuleRefs returned successfully.                                 |
        /// | S_FALSE | There are no tokens to enumerate. In that case, pcModuleRefs is zero. |
        /// </returns>
        [PreserveSig]
        new HRESULT EnumModuleRefs(
            [In, Out] ref IntPtr phEnum,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] mdModuleRef[] rModuleRefs,
            [In] int cmax,
            [Out] out int pcModuleRefs);

        /// <summary>
        /// Gets the binary metadata signature of the type specification represented by the specified token.
        /// </summary>
        /// <param name="typespec">[in] The TypeSpec token associated with the requested metadata signature.</param>
        /// <param name="ppvSig">[out] A pointer to the binary metadata signature.</param>
        /// <param name="pcbSig">[out] The size, in bytes, of the metadata signature.</param>
        /// <returns>An <see cref="HRESULT"/> that indicates success or failure. Failures can be tested with the FAILED macro.</returns>
        [PreserveSig]
        new HRESULT GetTypeSpecFromToken(
            [In] mdTypeSpec typespec,
            [Out] out IntPtr ppvSig,
            [Out] out int pcbSig);

        /// <summary>
        /// Gets the UTF-8 name of the object referenced by the specified metadata token. This method is obsolete.
        /// </summary>
        /// <param name="tk">[in] The token representing the object to return the name for.</param>
        /// <param name="pszUtf8NamePtr">[out] A pointer to the UTF-8 object name in the heap.</param>
        /// <remarks>
        /// GetNameFromToken is obsolete. As an alternative, call a method to get the properties of the particular type of
        /// token required, such as GetFieldProps for a field or GetMethodProps for a method.
        /// </remarks>
        [Obsolete]
        [PreserveSig]
        new HRESULT GetNameFromToken(
            [In] mdToken tk,
            [Out] out IntPtr pszUtf8NamePtr);

        /// <summary>
        /// Enumerates MemberDef tokens representing the unresolved methods in the current metadata scope.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator. This must be NULL for the first call of this method.</param>
        /// <param name="rMethods">[out] The array used to store the MemberDef tokens.</param>
        /// <param name="cMax">[in] The maximum size of the rMethods array.</param>
        /// <param name="pcTokens">[out] The number of MemberDef tokens returned in rMethods.</param>
        /// <returns>
        /// | HRESULT | Description                                                       |
        /// | ------- | ----------------------------------------------------------------- |
        /// | S_OK    | EnumUnresolvedMethods returned successfully.                      |
        /// | S_FALSE | There are no tokens to enumerate. In that case, pcTokens is zero. |
        /// </returns>
        /// <remarks>
        /// An unresolved method is one that has been declared but not implemented. A method is included in the enumeration
        /// if the method is marked miForwardRef and either mdPinvokeImpl or miRuntime is set to zero. In other words, an unresolved
        /// method is a class method that is marked miForwardRef but which is not implemented in unmanaged code (reached via
        /// PInvoke) nor implemented internally by the runtime itself The enumeration excludes all methods that are defined
        /// either at module scope (globals) or in interfaces or abstract classes.
        /// </remarks>
        [PreserveSig]
        new HRESULT EnumUnresolvedMethods(
            [In, Out] ref IntPtr phEnum,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] mdToken[] rMethods,
            [In] int cMax,
            [Out] out int pcTokens);

        /// <summary>
        /// Gets the literal string represented by the specified metadata token.
        /// </summary>
        /// <param name="stk">[in] The String token to return the associated string for.</param>
        /// <param name="szString">[out] A copy of the requested string.</param>
        /// <param name="cchString">[in] The maximum size in wide characters of the requested szString.</param>
        /// <param name="pchString">[out] The size in wide characters of the returned szString.</param>
        [PreserveSig]
        new HRESULT GetUserString(
            [In] mdString stk,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2), Out] char[] szString,
            [In] int cchString,
            [Out] out int pchString);

        /// <summary>
        /// Gets a ModuleRef token to represent the target assembly of a PInvoke call.
        /// </summary>
        /// <param name="tk">[in] A FieldDef or MethodDef token to get the PInvoke mapping metadata for.</param>
        /// <param name="pdwMappingFlags">[out] A pointer to flags used for mapping. This value is a bitmask from the <see cref="CorPinvokeMap"/> enumeration.</param>
        /// <param name="szImportName">[out] The name of the unmanaged target DLL.</param>
        /// <param name="cchImportName">[in] The size in wide characters of szImportName.</param>
        /// <param name="pchImportName">[out] The number of wide characters returned in szImportName.</param>
        /// <param name="pmrImportDLL">[out] A pointer to a ModuleRef token that represents the unmanaged target object library.</param>
        [PreserveSig]
        new HRESULT GetPinvokeMap(
            [In] mdToken tk,
            [Out] out CorPinvokeMap pdwMappingFlags,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3), Out] char[] szImportName,
            [In] int cchImportName,
            [Out] out int pchImportName,
            [Out] out mdModuleRef pmrImportDLL);

        /// <summary>
        /// Enumerates Signature tokens representing stand-alone signatures in the current scope.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator. This must be NULL for the first call of this method.</param>
        /// <param name="rSignatures">[out] The array used to store the Signature tokens.</param>
        /// <param name="cmax">[in] The maximum size of the rSignatures array.</param>
        /// <param name="pcSignatures">[out] The number of Signature tokens returned in rSignatures.</param>
        /// <returns>
        /// | HRESULT | Description                                                           |
        /// | ------- | --------------------------------------------------------------------- |
        /// | S_OK    | EnumSignatures returned successfully.                                 |
        /// | S_FALSE | There are no tokens to enumerate. In that case, pcSignatures is zero. |
        /// </returns>
        /// <remarks>
        /// The Signature tokens are created by the <see cref="IMetaDataEmit.GetTokenFromSig"/> method.
        /// </remarks>
        [PreserveSig]
        new HRESULT EnumSignatures(
            [In, Out] ref IntPtr phEnum,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] mdSignature[] rSignatures,
            [In] int cmax,
            [Out] out int pcSignatures);

        /// <summary>
        /// Enumerates TypeSpec tokens defined in the current metadata scope.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator. This value must be NULL for the first call of this method.</param>
        /// <param name="rTypeSpecs">[out] The array used to store the TypeSpec tokens.</param>
        /// <param name="cmax">[in] The maximum size of the rTypeSpecs array.</param>
        /// <param name="pcTypeSpecs">[out] The number of TypeSpec tokens returned in rTypeSpecs.</param>
        /// <returns>
        /// | HRESULT | Description                                                          |
        /// | ------- | -------------------------------------------------------------------- |
        /// | S_OK    | EnumTypeSpecs returned successfully.                                 |
        /// | S_FALSE | There are no tokens to enumerate. In that case, pcTypeSpecs is zero. |
        /// </returns>
        /// <remarks>
        /// The TypeSpec tokens are created by the <see cref="IMetaDataEmit.GetTokenFromTypeSpec"/> method.
        /// </remarks>
        [PreserveSig]
        new HRESULT EnumTypeSpecs(
            [In, Out] ref IntPtr phEnum,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] mdTypeSpec[] rTypeSpecs,
            [In] int cmax,
            [Out] out int pcTypeSpecs);

        /// <summary>
        /// Enumerates String tokens representing hard-coded strings in the current metadata scope.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator. This must be NULL for the first call of this method.</param>
        /// <param name="rStrings">[out] The array used to store the String tokens.</param>
        /// <param name="cmax">[in] The maximum size of the rStrings array.</param>
        /// <param name="pcStrings">[out] The number of String tokens returned in rStrings.</param>
        /// <returns>
        /// | HRESULT | Description                                                        |
        /// | ------- | ------------------------------------------------------------------ |
        /// | S_OK    | EnumUserStrings returned successfully.                             |
        /// | S_FALSE | There are no tokens to enumerate. In that case, pcStrings is zero. |
        /// </returns>
        /// <remarks>
        /// The String tokens are created by the <see cref="IMetaDataEmit.DefineUserString"/> method. This method is designed
        /// to be used by a metadata browser rather than by a compiler.
        /// </remarks>
        [PreserveSig]
        new HRESULT EnumUserStrings(
            [In, Out] ref IntPtr phEnum,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] mdString[] rStrings,
            [In] int cmax,
            [Out] out int pcStrings);

        /// <summary>
        /// Gets the token that represents a specified parameter of the method represented by the specified MethodDef token.
        /// </summary>
        /// <param name="md">[in] A token that represents the method to return the parameter token for.</param>
        /// <param name="ulParamSeq">[in] The ordinal position in the parameter list where the requested parameter occurs. Parameters are numbered starting from one, with the method's return value in position zero.</param>
        /// <param name="ppd">[out] A pointer to a ParamDef token that represents the requested parameter.</param>
        [PreserveSig]
        new HRESULT GetParamForMethodIndex(
            [In] mdMethodDef md,
            [In] int ulParamSeq,
            [Out] out mdParamDef ppd);

        /// <summary>
        /// Enumerates custom attribute-definition tokens associated with the specified type or member.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the returned enumerator.</param>
        /// <param name="tk">[in] A token for the scope of the enumeration, or zero for all custom attributes.</param>
        /// <param name="tkType">[in] A token for the constructor of the type of the attributes to be enumerated, or null for all types.</param>
        /// <param name="rCustomAttributes">[out] An array of custom attribute tokens.</param>
        /// <param name="cMax">[in] The maximum size of the rCustomAttributes array.</param>
        /// <param name="pcCustomAttributes">[out, optional] The actual number of token values returned in rCustomAttributes.</param>
        /// <returns>
        /// | HRESULT | Description                                                                            |
        /// | ------- | -------------------------------------------------------------------------------------- |
        /// | S_OK    | EnumCustomAttributes returned successfully.                                            |
        /// | S_FALSE | There are no custom attributes to enumerate. In that case, pcCustomAttributes is zero. |
        /// </returns>
        [PreserveSig]
        new HRESULT EnumCustomAttributes(
            [In, Out] ref IntPtr phEnum,
            [In] mdToken tk,
            [In] mdToken tkType,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] mdCustomAttribute[] rCustomAttributes,
            [In] int cMax,
            [Out] out int pcCustomAttributes);

        /// <summary>
        /// Gets the value of the custom attribute, given its metadata token.
        /// </summary>
        /// <param name="cv">[in] A metadata token that represents the custom attribute to be retrieved.</param>
        /// <param name="ptkObj">[out, optional] A metadata token representing the object that the custom attribute modifies. This value can be any type of metadata token except <see cref="mdCustomAttribute"/>.</param>
        /// <param name="ptkType">[out, optional] An <see cref="mdMethodDef"/> or <see cref="mdMemberRef"/> metadata token representing the <see cref="Type"/> of the returned custom attribute.</param>
        /// <param name="ppBlob">[out, optional] A pointer to an array of data that is the value of the custom attribute.</param>
        /// <param name="pcbSize">[out, optional] The size in bytes of the data returned in *ppBlob.</param>
        /// <remarks>
        /// A custom attribute is stored as an array of data, the format which is understood by the metadata engine.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetCustomAttributeProps(
            [In] mdCustomAttribute cv,
            [Out] out mdToken ptkObj,
            [Out] out mdToken ptkType,
            [Out] out IntPtr ppBlob,
            [Out] out int pcbSize);

        /// <summary>
        /// Gets a pointer to the TypeRef token for the <see cref="Type"/> reference that is in the specified scope and that has the specified name.
        /// </summary>
        /// <param name="tkResolutionScope">[in] A ModuleRef, AssemblyRef, or TypeRef token that specifies the module, assembly, or type, respectively, in which the type reference is defined.</param>
        /// <param name="szName">[in] The name of the type reference to search for.</param>
        /// <param name="ptr">[out] A pointer to the matching TypeRef token.</param>
        [PreserveSig]
        new HRESULT FindTypeRef(
            [In] mdToken tkResolutionScope,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [Out] out mdTypeRef ptr);

        /// <summary>
        /// Gets information stored in the metadata for a specified member definition, including the name, binary signature, and relative virtual address, of the <see cref="Type"/> member referenced by the specified metadata token.<para/>
        /// This is a simple helper method: if mb is a MethodDef, then GetMethodProps is called; if mb is a FieldDef, then GetFieldProps is called.<para/>
        /// See these other methods for details.
        /// </summary>
        /// <param name="mb">[in] The token that references the member to get the associated metadata for.</param>
        /// <param name="pClass">[out] A pointer to the metadata token that represents the class of the member.</param>
        /// <param name="szMember">[out] The name of the member.</param>
        /// <param name="cchMember">[in] The size in wide characters of the szMember buffer.</param>
        /// <param name="pchMember">[out] The size in wide characters of the returned name.</param>
        /// <param name="pdwAttr">[out] Any flag values applied to the member. If the member is a <see cref="mdMethodDef"/> this value is a bitwise combination of <see cref="CorMethodAttr"/> values. Otherwise, it is a bitwise combination of <see cref="CorFieldAttr"/> values.</param>
        /// <param name="ppvSigBlob">[out] A pointer to the binary metadata signature of the member.</param>
        /// <param name="pcbSigBlob">[out] The size in bytes of ppvSigBlob.</param>
        /// <param name="pulCodeRVA">[out] A pointer to the relative virtual address of the member.</param>
        /// <param name="pdwImplFlags">[out] Any method implementation flags associated with the member. If the member is an <see cref="mdMethodDef"/> these flags are a bitwise combination of <see cref="CorMethodImpl"/> values.</param>
        /// <param name="pdwCPlusTypeFlag">[out] A flag that marks a <see cref="ValueType"/>. It is one of the ELEMENT_TYPE_* values.</param>
        /// <param name="ppValue">[out] A constant string value returned by this member.</param>
        /// <param name="pcchValue">[out] The size in characters of ppValue, or zero if ppValue does not hold a string.</param>
        [PreserveSig]
        new HRESULT GetMemberProps(
            [In] mdToken mb,
            [Out] out mdTypeDef pClass,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3), Out] char[] szMember,
            [In] int cchMember,
            [Out] out int pchMember,
            [Out] out int pdwAttr,
            [Out] out IntPtr ppvSigBlob,
            [Out] out int pcbSigBlob,
            [Out] out int pulCodeRVA,
            [Out] out int pdwImplFlags,
            [Out] out CorElementType pdwCPlusTypeFlag,
            [Out] out IntPtr ppValue,
            [Out] out int pcchValue);

        /// <summary>
        /// Gets metadata associated with the field referenced by the specified FieldDef token.
        /// </summary>
        /// <param name="mb">[in] A FieldDef token that represents the field to get associated metadata for.</param>
        /// <param name="pClass">[out] A pointer to a TypeDef token that represents the type of the class that the field belongs to.</param>
        /// <param name="szField">[out] The name of the field.</param>
        /// <param name="cchField">[in] The size in wide characters of the buffer for szField.</param>
        /// <param name="pchField">[out] The actual size of the returned buffer.</param>
        /// <param name="pdwAttr">[out] Flags associated with the field's metadata.</param>
        /// <param name="ppvSigBlob">[out] A pointer to the binary metadata value that describes the field.</param>
        /// <param name="pcbSigBlob">[out] The size in bytes of ppvSigBlob.</param>
        /// <param name="pdwCPlusTypeFlag">[out] A flag that specifies the value type of the field.</param>
        /// <param name="ppValue">[out] A constant value for the field.</param>
        /// <param name="pcchValue">[out] The size in chars of ppValue, or zero if no string exists.</param>
        [PreserveSig]
        new HRESULT GetFieldProps(
            [In] mdFieldDef mb,
            [Out] out mdTypeDef pClass,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3), Out] char[] szField,
            [In] int cchField,
            [Out] out int pchField,
            [Out] out CorFieldAttr pdwAttr,
            [Out] out IntPtr ppvSigBlob,
            [Out] out int pcbSigBlob,
            [Out] out CorElementType pdwCPlusTypeFlag,
            [Out] out IntPtr ppValue,
            [Out] out int pcchValue);

        /// <summary>
        /// Gets the metadata for the property represented by the specified token.
        /// </summary>
        /// <param name="prop">[in] A token that represents the property to return metadata for.</param>
        /// <param name="pClass">[out] A pointer to the TypeDef token that represents the type that implements the property.</param>
        /// <param name="szProperty">[out] A buffer to hold the property name.</param>
        /// <param name="cchProperty">[in] The size in wide characters of szProperty.</param>
        /// <param name="pchProperty">[out] The number of wide characters returned in szProperty.</param>
        /// <param name="pdwPropFlags">[out] A pointer to any attribute flags applied to the property. This value is a bitmask from the <see cref="CorPropertyAttr"/> enumeration.</param>
        /// <param name="ppvSig">[out] A pointer to the metadata signature of the property.</param>
        /// <param name="pbSig">[out] The number of bytes returned in ppvSig.</param>
        /// <param name="pdwCPlusTypeFlag">[out] A flag specifying the type of the constant that is the default value of the property. This value is from the <see cref="CorElementType"/> enumeration.</param>
        /// <param name="ppDefaultValue">[out] A pointer to the bytes that store the default value for this property.</param>
        /// <param name="pcchDefaultValue">[out] The size in wide characters of ppDefaultValue, if pdwCPlusTypeFlag is ELEMENT_TYPE_STRING; otherwise, this value is not relevant.<para/>
        /// In that case, the length of ppDefaultValue is inferred from the type that is specified by pdwCPlusTypeFlag.</param>
        /// <param name="pmdSetter">[out] A pointer to the MethodDef token that represents the set accessor method for the property.</param>
        /// <param name="pmdGetter">[out] A pointer to the MethodDef token that represents the get accessor method for the property.</param>
        /// <param name="rmdOtherMethod">[out] An array of MethodDef tokens that represent other methods associated with the property.</param>
        /// <param name="cMax">[in] The maximum size of the rmdOtherMethod array. If you do not provide an array large enough to hold all the methods, they are skipped without warning.</param>
        /// <param name="pcOtherMethod">[out] The number of MethodDef tokens returned in rmdOtherMethod.</param>
        [PreserveSig]
        new HRESULT GetPropertyProps(
            [In] mdProperty prop,
            [Out] out mdTypeDef pClass,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 3), Out] char[] szProperty,
            [In] int cchProperty,
            [Out] out int pchProperty,
            [Out] out CorPropertyAttr pdwPropFlags,
            [Out] out IntPtr ppvSig,
            [Out] out int pbSig,
            [Out] out CorElementType pdwCPlusTypeFlag,
            [Out] out IntPtr ppDefaultValue,
            [Out] out int pcchDefaultValue,
            [Out] out mdMethodDef pmdSetter,
            [Out] out mdMethodDef pmdGetter,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 14)] mdMethodDef[] rmdOtherMethod,
            [In] int cMax,
            [Out] out int pcOtherMethod);

        /// <summary>
        /// Gets metadata values for the parameter referenced by the specified ParamDef token.
        /// </summary>
        /// <param name="tk">[in] A ParamDef token that represents the parameter to return metadata for.</param>
        /// <param name="pmd">[out] A pointer to a MethodDef token representing the method that takes the parameter.</param>
        /// <param name="pulSequence">[out] The ordinal position of the parameter in the method argument list.</param>
        /// <param name="szName">[out] A buffer to hold the name of the parameter.</param>
        /// <param name="cchName">[in] The requested size in wide characters of szName.</param>
        /// <param name="pchName">[out] The returned size in wide characters of szName.</param>
        /// <param name="pdwAttr">[out] A pointer to any attribute flags associated with the parameter. This is a bitmask of <see cref="CorParamAttr"/> values.</param>
        /// <param name="pdwCPlusTypeFlag">[out] A pointer to a flag specifying that the parameter is a <see cref="ValueType"/>.</param>
        /// <param name="ppValue">[out] A pointer to a constant string returned by the parameter.</param>
        /// <param name="pcchValue">[out] The size of ppValue in wide characters, or zero if ppValue does not hold a string.</param>
        /// <remarks>
        /// The sequence values in pulSequence begin with 1 for parameters. A return value has a sequence number of 0.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetParamProps(
            [In] mdParamDef tk,
            [Out] out mdMethodDef pmd,
            [Out] out int pulSequence,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 4), Out] char[] szName,
            [In] int cchName,
            [Out] out int pchName,
            [Out] out CorParamAttr pdwAttr,
            [Out] out CorElementType pdwCPlusTypeFlag,
            [Out] out IntPtr ppValue,
            [Out] out IntPtr pcchValue);

        /// <summary>
        /// Gets the custom attribute, given its name and owner.
        /// </summary>
        /// <param name="tkObj">[in] A metadata token representing the object that owns the custom attribute.</param>
        /// <param name="szName">[in] The name of the custom attribute.</param>
        /// <param name="ppData">[out] A pointer to an array of data that is the value of the custom attribute.</param>
        /// <param name="pcbData">[out] The size in bytes of the data returned in *ppData.</param>
        /// <remarks>
        /// It is legal to define multiple custom attributes for the same owner; they may even have the same name. However,
        /// GetCustomAttributeByName returns only one instance. (GetCustomAttributeByName returns the first instance that it
        /// encounters.) To find all instances of a custom attribute, call the <see cref="EnumCustomAttributes"/> method.
        /// </remarks>
        [PreserveSig]
        new HRESULT GetCustomAttributeByName(
            [In] mdToken tkObj,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [Out] out IntPtr ppData,
            [Out] out int pcbData);

        /// <summary>
        /// Gets a value indicating whether the specified token holds a valid reference to a code object.
        /// </summary>
        /// <param name="tk">[in] The token to check the reference validity for.</param>
        /// <returns>true if tk is a valid metadata token within the current scope. Otherwise, false.</returns>
        [return: MarshalAs(UnmanagedType.Bool)]
        new bool IsValidToken(
            [In] mdToken tk);

        /// <summary>
        /// Gets the TypeDef token for the parent <see cref="Type"/> of the specified nested type.
        /// </summary>
        /// <param name="tdNestedClass">[in] A TypeDef token representing the <see cref="Type"/> to return the parent class token for.</param>
        /// <param name="ptdEnclosingClass">[out] A pointer to the TypeDef token for the <see cref="Type"/> that tdNestedClass is nested in.</param>
        [PreserveSig]
        new HRESULT GetNestedClassProps(
            [In] mdTypeDef tdNestedClass,
            [Out] out mdTypeDef ptdEnclosingClass);

        /// <summary>
        /// Gets the native calling convention for the method that is represented by the specified signature pointer.
        /// </summary>
        /// <param name="pvSig">[in] A pointer to the metadata signature of the method to return the calling convention for.</param>
        /// <param name="cbSig">[in] The size in bytes of pvSig.</param>
        /// <param name="pCallConv">[out] A pointer to the native calling convention.</param>
        [PreserveSig]
        new HRESULT GetNativeCallConvFromSig(
            [In] IntPtr pvSig,
            [In] int cbSig,
            [Out] out int pCallConv);

        /// <summary>
        /// Gets a value indicating whether the field, method, or type represented by the specified metadata token has global scope.
        /// </summary>
        /// <param name="pd">[in] A metadata token that represents a type, field, or method.</param>
        /// <param name="pbGlobal">[out] 1 if the object has global scope; otherwise, 0 (zero).</param>
        [PreserveSig]
        new HRESULT IsGlobal(
            [In] mdToken pd,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pbGlobal);

        /// <summary>
        /// Gets an enumerator for an array of generic parameter tokens associated with the specified TypeDef or MethodDef token.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator.</param>
        /// <param name="tk">[in] The TypeDef or MethodDef token whose generic parameters are to be enumerated.</param>
        /// <param name="rGenericParams">[out] The array of generic parameters to enumerate.</param>
        /// <param name="cMax">[in] The requested maximum number of tokens to place in rGenericParams.</param>
        /// <param name="pcGenericParams">[out] The returned number of tokens placed in rGenericParams.</param>
        /// <returns>
        /// | HRESULT | Description                                                                      |
        /// | ------- | -------------------------------------------------------------------------------- |
        /// | S_OK    | EnumGenericParams returned successfully.                                         |
        /// | S_FALSE | phEnum has no member elements. In this case, pcGenericParams is set to 0 (zero). |
        /// </returns>
        [PreserveSig]
        HRESULT EnumGenericParams(
            [In, Out] ref IntPtr phEnum,
            [In] mdToken tk,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] mdGenericParam[] rGenericParams,
            [In] int cMax,
            [Out] out int pcGenericParams);

        /// <summary>
        /// Gets the metadata associated with the generic parameter represented by the specified token.
        /// </summary>
        /// <param name="gp">[in] The token that represents the generic parameter for which to return metadata.</param>
        /// <param name="pulParamSeq">[out] The ordinal position of the Type parameter in the parent constructor or method.</param>
        /// <param name="pdwParamFlags">[out] A value of the <see cref="CorGenericParamAttr"/> enumeration that describes the Type for the generic parameter.</param>
        /// <param name="ptOwner">[out] A TypeDef or MethodDef token that represents the owner of the parameter.</param>
        /// <param name="reserved">[out] Reserved for future extensibility.</param>
        /// <param name="wzname">[out] The name of the generic parameter.</param>
        /// <param name="cchName">[in] The size of the wzName buffer.</param>
        /// <param name="pchName">[out] The returned size of the name, in wide characters.</param>
        [PreserveSig]
        HRESULT GetGenericParamProps(
            [In] mdGenericParam gp,
            [Out] out int pulParamSeq,
            [Out] out CorGenericParamAttr pdwParamFlags,
            [Out] out mdToken ptOwner,
            [Out] out int reserved,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 6)] char[] wzname,
            [In] int cchName,
            [Out] out int pchName);

        /// <summary>
        /// Gets the metadata signature of the method referenced by the specified MethodSpec token.
        /// </summary>
        /// <param name="mi">[in] A MethodSpec token that represents the instantiation of the method.</param>
        /// <param name="tkParent">[out] A pointer to the MethodDef or MethodRef token that represents the method definition.</param>
        /// <param name="ppvSigBlob">[out] A pointer to the binary metadata signature of the method.</param>
        /// <param name="pcbSigBlob">[out] The size, in bytes, of ppvSigBlob.</param>
        [PreserveSig]
        HRESULT GetMethodSpecProps(
            [In] mdMethodSpec mi,
            [Out] out mdToken tkParent,
            [Out] out IntPtr ppvSigBlob,
            [Out] out int pcbSigBlob);

        /// <summary>
        /// Gets an enumerator for an array of generic parameter constraints associated with the generic parameter represented by the specified token.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator.</param>
        /// <param name="tk">[in] A token that represents the generic parameter whose constraints are to be enumerated.</param>
        /// <param name="rGenericParamConstraints">[out] The array of generic parameter constraints to enumerate.</param>
        /// <param name="cMax">[in] The requested maximum number of tokens to place in rGenericParamConstraints.</param>
        /// <param name="pcGenericParamConstraints">[out] A pointer to the number of tokens placed in rGenericParamConstraints.</param>
        /// <returns>
        /// | HRESULT | Description                                                                                    |
        /// | ------- | ---------------------------------------------------------------------------------------------- |
        /// | S_OK    | EnumGenericParameterConstraints returned successfully.                                         |
        /// | S_FALSE | phEnum has no member elements. In this case, pcGenericParameterConstraints is set to 0 (zero). |
        /// </returns>
        [PreserveSig]
        HRESULT EnumGenericParamConstraints(
            [In, Out] ref IntPtr phEnum,
            [In] mdGenericParam tk,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] mdGenericParamConstraint[] rGenericParamConstraints,
            [In] int cMax,
            [Out] out int pcGenericParamConstraints);

        /// <summary>
        /// Gets the metadata associated with the generic parameter constraint represented by the specified constraint token.
        /// </summary>
        /// <param name="gpc">[in] The token to the generic parameter constraint for which to return the metadata.</param>
        /// <param name="ptGenericParam">[out] A pointer to the token that represents the generic parameter that is constrained.</param>
        /// <param name="ptkConstraintType">[out] A pointer to a TypeDef, TypeRef, or TypeSpec token that represents a constraint on ptGenericParam.</param>
        [PreserveSig]
        HRESULT GetGenericParamConstraintProps(
            [In] mdGenericParamConstraint gpc,
            [Out] out mdGenericParam ptGenericParam,
            [Out] out mdToken ptkConstraintType);

        /// <summary>
        /// Gets a value identifying the nature of the code in the portable executable (PE) file, typically a DLL or EXE file, that is defined in the current metadata scope.
        /// </summary>
        /// <param name="pdwPEKind">[out] A pointer to a value of the <see cref="CorPEKind"/> enumeration that describes the PE file.</param>
        /// <param name="pdwMachine">[out] A pointer to a value that identifies the architecture of the machine. See the next section for possible values.</param>
        /// <remarks>
        /// The value referenced by the pdwMachine parameter can be one of the following.
        /// </remarks>
        [PreserveSig]
        HRESULT GetPEKind(
            [Out] out CorPEKind pdwPEKind,
            [Out] out IMAGE_FILE_MACHINE pdwMachine);

        /// <summary>
        /// Gets the version number of the runtime that was used to build the assembly.
        /// </summary>
        /// <param name="pwzBuf">[out] An array to store the string that specifies the version.</param>
        /// <param name="ccBufSize">[in] The size, in wide characters, of the pwzBuf array.</param>
        /// <param name="pccBufSize">[out] The number of wide characters, including a null terminator, returned in the pwzBuf array.</param>
        /// <remarks>
        /// The GetVersionString method gets the built-for version of the current metadata scope. If the scope has never been
        /// saved, it will not have a built-for version, and an empty string will be returned.
        /// </remarks>
        [PreserveSig]
        HRESULT GetVersionString(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1)] char[] pwzBuf,
            [In] int ccBufSize,
            [Out] out int pccBufSize);

        /// <summary>
        /// Gets an enumerator for an array of MethodSpec tokens associated with the specified MethodDef or MemberRef token.
        /// </summary>
        /// <param name="phEnum">[in, out] A pointer to the enumerator for rMethodSpecs.</param>
        /// <param name="tk">[in] The MemberRef or MethodDef token that represents the method whose MethodSpec tokens are to be enumerated. If the value of tk is 0 (zero), all MethodSpec tokens in the scope will be enumerated.</param>
        /// <param name="rMethodSpecs">[out] The array of MethodSpec tokens to enumerate.</param>
        /// <param name="cMax">[in] The requested maximum number of tokens to place in rMethodSpecs.</param>
        /// <param name="pcMethodSpecs">[out] The returned number of tokens placed in rMethodSpecs.</param>
        /// <returns>
        /// | HRESULT | Description                                                                    |
        /// | ------- | ------------------------------------------------------------------------------ |
        /// | S_OK    | EnumMethodSpecs returned successfully.                                         |
        /// | S_FALSE | phEnum has no member elements. In this case, pcMethodSpecs is set to 0 (zero). |
        /// </returns>
        [PreserveSig]
        HRESULT EnumMethodSpecs(
            [In, Out] ref IntPtr phEnum,
            [In] mdToken tk,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] mdMethodSpec[] rMethodSpecs,
            [In] int cMax,
            [Out] out int pcMethodSpecs);
    }
}
