using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods to create, modify, and save metadata about the assembly in the currently defined scope. The metadata can be stored in memory or saved to disk.
    /// </summary>
    [Guid("BA3FEE4C-ECB9-4e41-83B7-183FA41CD859")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IMetaDataEmit
    {
        /// <summary>
        /// Updates references to a module defined by a prior call to <see cref="DefineModuleRef"/>.
        /// </summary>
        /// <param name="szName">[in] The module name in Unicode. This is the file name only and not the full path name.</param>
        [PreserveSig]
        HRESULT SetModuleProps(
            [MarshalAs(UnmanagedType.LPWStr)] string szName);

        /// <summary>
        /// Saves all metadata in the current scope to the file at the specified address.
        /// </summary>
        /// <param name="szFile">[in] The name of the file to save to. If this value is null, the in-memory copy will be saved to the last location that was used.</param>
        /// <param name="dwSaveFlags">[in] Reserved. Must be zero.</param>
        [PreserveSig]
        HRESULT Save(
            [MarshalAs(UnmanagedType.LPWStr)] string szFile,
            uint dwSaveFlags);

        /// <summary>
        /// Saves all metadata in the current scope to the specified <see cref="IStream"/>.
        /// </summary>
        /// <param name="pIStream">[in] The writable stream to save to.</param>
        /// <param name="dwSaveFlags">[in] Reserved. Must be zero.</param>
        [PreserveSig]
        HRESULT SaveToStream(
            [MarshalAs(UnmanagedType.Interface)] object pIStream,
            uint dwSaveFlags);

        /// <summary>
        /// Gets the estimated binary size of the assembly and its metadata in the current scope.
        /// </summary>
        /// <param name="fSave">[in] A value of the <see cref="CorSaveSize"/> enumeration that specifies whether to get an accurate or approximate size.<para/>
        /// Only three values are valid: cssAccurate, cssQuick, and cssDiscardTransientCAs:</param>
        /// <param name="pdwSaveSize">[out] A pointer to the size that is required to save the file.</param>
        /// <remarks>
        /// GetSaveSize calculates the space required, in bytes, to save the assembly and all its metadata in the current scope.
        /// (A call to the <see cref="SaveToStream"/> method would emit this number of bytes.) If the caller implements the
        /// <see cref="IMapToken"/> interface (through <see cref="SetHandler"/> or <see cref="Merge"/>), GetSaveSize will perform
        /// two passes over the metadata to optimize and compress it. Otherwise, no optimizations are performed. If optimization
        /// is performed, the first pass simply sorts the metadata structures to tune the performance of import-time searches.
        /// This step typically results in moving records around, with the side effect that tokens retained by the tool for
        /// future reference are invalidated. The metadata does not inform the caller of these token changes until after the
        /// second pass, however. In the second pass, various optimizations are performed that are intended to reduce the overall
        /// size of the metadata, such as optimizing away (early binding) <see cref="mdTypeRef"/> and <see cref="mdMemberRef"/> tokens when the reference
        /// is to a type or member that is declared in the current metadata scope. In this pass, another round of token mapping
        /// occurs. After this pass, the metadata engine notifies the caller, through its <see cref="IMapToken"/> interface, of any changed
        /// token values.
        /// </remarks>
        [PreserveSig]
        HRESULT GetSaveSize(
            CorSaveSize fSave,
            out uint pdwSaveSize);

        /// <summary>
        /// Creates a type definition for a common language runtime type, and gets a metadata token for that type definition.
        /// </summary>
        /// <param name="szTypeDef">[in] The name of the type in Unicode.</param>
        /// <param name="dwTypeDefFlags">[in] TypeDef attributes. This is a bitmask of CoreTypeAttr values.</param>
        /// <param name="tkExtends">[in] The token of the base class. It must be either an <see cref="mdTypeDef"/> or an <see cref="mdTypeRef"/> token.</param>
        /// <param name="rtkImplements">[in] An array of tokens specifying the interfaces that this class or interface implements.</param>
        /// <param name="ptd">[out] The <see cref="mdTypeDef"/> token assigned.</param>
        /// <remarks>
        /// A flag in dwTypeDefFlags specifies whether the type being created is a common type system reference type (class
        /// or interface) or a common type system value type. Depending on the parameters supplied, this method, as a side
        /// effect, may also create an <see cref="mdInterfaceImpl"/> record for each interface that is inherited or implemented by this type.
        /// However, this method does not return any of these <see cref="mdInterfaceImpl"/> tokens. If a client wants to later add or modify
        /// an <see cref="mdInterfaceImpl"/> token, it must use the <see cref="IMetaDataImport"/> interface to enumerate them. If you want to use COM semantics
        /// of the [default] interface, you should supply the default interface as the first element in rtkImplements; a custom
        /// attribute set on the class will indicate that the class has a default interface (which is always assumed to be
        /// the first <see cref="mdInterfaceImpl"/> token declared for the class). Each element of the rtkImplements array holds an <see cref="mdTypeDef"/>
        /// or <see cref="mdTypeRef"/> token. The last element in the array must be mdTokenNil.
        /// </remarks>
        [PreserveSig]
        HRESULT DefineTypeDef(
            [MarshalAs(UnmanagedType.LPWStr)] string szTypeDef,
            uint dwTypeDefFlags,
            mdToken tkExtends,
            [MarshalAs(UnmanagedType.LPArray)] mdToken[] rtkImplements,
            out mdTypeDef ptd);

        /// <summary>
        /// Creates the metadata signature of a type definition, returns an <see cref="mdTypeDef"/> token for that type, and specifies that the defined type is a member of the type referenced by the tdEncloser parameter.
        /// </summary>
        /// <param name="szTypeDef">[in] The name of the type in Unicode.</param>
        /// <param name="dwTypeDefFlags">[in] TypeDef attributes. This is a bitmask of <see cref="CorTypeAttr"/> values.</param>
        /// <param name="tkExtends">[in] The token of the base class. This is either a <see cref="mdTypeDef"/> or a <see cref="mdTypeRef"/> token.</param>
        /// <param name="rtkImplements">[][in] An array of tokens that specify the interfaces that this class or interface implements.</param>
        /// <param name="tdEncloser">[in] The token of the enclosing type. The last element of the array must be mdTokenNil.</param>
        /// <param name="ptd">[out] The <see cref="mdTypeDef"/> token assigned.</param>
        [PreserveSig]
        HRESULT DefineNestedType(
            [MarshalAs(UnmanagedType.LPWStr)] string szTypeDef,
            CorTypeAttr dwTypeDefFlags,
            mdToken tkExtends,
            [MarshalAs(UnmanagedType.LPArray)] mdToken[] rtkImplements,
            mdToken tdEncloser,
            out mdTypeDef ptd);

        /// <summary>
        /// Sets the method referenced by the specified IUnknown pointer as a notification callback for token remaps.
        /// </summary>
        /// <param name="pUnk">[in] The handler to register.</param>
        /// <remarks>
        /// The metadata engine sends notification by using the method that is provided by SetHandler, to compilers that do
        /// not generate records in an optimized way and that would like to optimize saved records. If the callback method
        /// is not provided through SetHandler, no optimization will be performed on save except where several import scopes
        /// have been merged using <see cref="IMapToken"/> on merge for each scope.
        /// </remarks>
        [PreserveSig]
        HRESULT SetHandler(
            [MarshalAs(UnmanagedType.IUnknown)] object pUnk);

        /// <summary>
        /// Creates a definition for a method or global function with the specified signature, and returns a token to that method definition.
        /// </summary>
        /// <param name="td">[in] The <see cref="mdTypeDef"/> token of the parent class or parent interface of the method. Set td to mdTokenNil, if you are defining a global function.</param>
        /// <param name="szName">[in] The member name in Unicode.</param>
        /// <param name="dwMethodFlags">[in] A value of the <see cref="CorMethodAttr"/> enumeration that specifies the attributes of the method or global function.</param>
        /// <param name="pvSigBlob">[in] The method signature. The signature is persisted as supplied. If you need to specify additional information for any parameters, use the <see cref="SetParamProps"/> method.</param>
        /// <param name="cbSigBlob">[in] The count of bytes in pvSigBlob.</param>
        /// <param name="ulCodeRVA">[in] The address of the code.</param>
        /// <param name="dwImplFlags">[in] A value of the <see cref="CorMethodImpl"/> enumeration that specifies the implementation features of the method.</param>
        /// <param name="pmd">[out] The member token.</param>
        /// <remarks>
        /// The metadata API guarantees to persist methods in the same order as the caller emits them for a given enclosing
        /// class or interface, which is specified in the td parameter. Additional information regarding the use of DefineMethod
        /// and particular parameter settings is given below.
        /// </remarks>
        [PreserveSig]
        HRESULT DefineMethod(
            mdToken td,
            [MarshalAs(UnmanagedType.LPWStr)] string szName,
            MethodAttributes dwMethodFlags,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] pvSigBlob,
            uint cbSigBlob,
            uint ulCodeRVA,
            MethodImplAttributes dwImplFlags,
            out uint pmd);

        /// <summary>
        /// Creates a definition for implementation of a method inherited from an interface, and returns a token to that method-implementation definition.
        /// </summary>
        /// <param name="td">[in] The <see cref="mdTypeDef"/> token of the implementing class.</param>
        /// <param name="tkBody">[in] The <see cref="mdMethodDef"/> or <see cref="mdMemberRef"/> token of the code body.</param>
        /// <param name="tkDecl">[in] The <see cref="mdMethodDef"/> or <see cref="mdMemberRef"/> token of the interface method being implemented.</param>
        [PreserveSig]
        HRESULT DefineMethodImpl(
            mdTypeDef td,
            mdToken tkBody,
            mdToken tkDecl);

        /// <summary>
        /// Gets a metadata token for a type that is defined in the specified scope, which is outside the current scope.
        /// </summary>
        /// <param name="tkResolutionScope">[in] The token specifying the resolution scope. The following token types are valid:</param>
        /// <param name="szName">[in] The name of the target type in Unicode.</param>
        /// <param name="ptr">[out] A pointer to the <see cref="mdTypeRef"/> token that is assigned to the type.</param>
        [PreserveSig]
        HRESULT DefineTypeRefByName(
            uint tkResolutionScope,
            [MarshalAs(UnmanagedType.LPWStr)] string szName,
            out mdTypeRef ptr);

        /// <summary>
        /// Creates a reference to the specified type that is defined outside the current scope, and defines a token for that reference.
        /// </summary>
        /// <param name="pAssemImport">[in] An <see cref="IMetaDataAssemblyImport"/> interface that represents the assembly from which the target type is imported.</param>
        /// <param name="pbHashValue">[in] An array that contains the hash for the assembly specified by pAssemImport.</param>
        /// <param name="cbHashValue">[in] The number of bytes in the pbHashValue array.</param>
        /// <param name="pImport">[in] An <see cref="IMetaDataImport"/> interface that represents the metadata scope from which the target type is imported.</param>
        /// <param name="tdImport">[in] An <see cref="mdTypeDef"/> token that specifies the target type.</param>
        /// <param name="pAssemEmit">[in] An <see cref="IMetaDataAssemblyEmit"/> interface that represents the assembly into which the target type is imported.</param>
        /// <param name="ptr">[out] The <see cref="mdTypeRef"/> token that is defined in the current scope for the type reference.</param>
        /// <remarks>
        /// Prior to calling the <see cref="DefineImportMember"/> method, you can use the DefineImportType method to create
        /// a type reference, in the current scope, for the member's parent class or parent interface.
        /// </remarks>
        [PreserveSig]
        HRESULT DefineImportType(
            [MarshalAs(UnmanagedType.Interface)] IMetaDataAssemblyImport pAssemImport,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pbHashValue,
            uint cbHashValue,
            [MarshalAs(UnmanagedType.Interface)] IMetaDataImport pImport,
            mdTypeDef tdImport,
            [MarshalAs(UnmanagedType.Interface)] IMetaDataAssemblyEmit pAssemEmit,
            out mdTypeRef ptr);

        /// <summary>
        /// Defines a reference to a member of a module outside the current scope, and gets a token to that reference definition.
        /// </summary>
        /// <param name="tkImport">[in] Token for the target member's class or interface, if the member is not global; if the member is global, the <see cref="mdModuleRef"/> token for that other file.</param>
        /// <param name="szName">[in] The name of the target member.</param>
        /// <param name="pvSigBlob">[in] The signature of the target member.</param>
        /// <param name="cbSigBlob">[in] The count of bytes in pvSigBlob.</param>
        /// <param name="pmr">[out] The <see cref="mdMemberRef"/> token assigned.</param>
        [PreserveSig]
        HRESULT DefineMemberRef(
            mdModuleRef tkImport,
            [MarshalAs(UnmanagedType.LPWStr)] string szName,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pvSigBlob,
            uint cbSigBlob,
            out mdMemberRef pmr);

        /// <summary>
        /// Creates a reference to the specified member of a type or module that is defined outside the current scope, and defines a token for that reference.
        /// </summary>
        /// <param name="pAssemImport">[in] An <see cref="IMetaDataAssemblyImport"/> interface that represents the assembly from which the target member is imported.</param>
        /// <param name="pbHashValue">[in] An array that contains the hash for the assembly specified by pAssemImport.</param>
        /// <param name="cbHashValue">[in] The number of bytes in the pbHashValue array.</param>
        /// <param name="pImport">[in] An <see cref="IMetaDataImport"/> interface that represents the metadata scope from which the target member is imported.</param>
        /// <param name="mbMember">[in] The metadata token that specifies the target member. The token can be an <see cref="mdMethodDef"/> (for a member method), <see cref="mdProperty"/> (for a member property), or <see cref="mdFieldDef"/> (for a member field) token.</param>
        /// <param name="pAssemEmit">[in] An <see cref="IMetaDataAssemblyEmit"/> interface that represents the assembly into which the target member is imported.</param>
        /// <param name="tkParent">[in] The <see cref="mdTypeRef"/> or <see cref="mdModuleRef"/> token for the type or module, respectively, that owns the target member.</param>
        /// <param name="pmr">[out] The <see cref="mdMemberRef"/> token that is defined in the current scope for the member reference.</param>
        /// <remarks>
        /// The DefineImportMember method looks up the member, specified by mbMember, that is defined in another scope, specified
        /// by pImport, and retrieves its properties. It uses this information to call the <see cref="DefineMemberRef"/> method
        /// in the current scope to create the member reference. Generally, before you use the DefineImportMember method, you
        /// must create, in the current scope, a type reference or module reference for the target member's parent class, interface,
        /// or module. The metadata token for this reference is then passed in the tkParent argument. You do not need to create
        /// a reference to the target member's parent if it will be resolved later by the compiler or linker. To summarize:
        /// </remarks>
        [PreserveSig]
        HRESULT DefineImportMember(
            [MarshalAs(UnmanagedType.Interface)] IMetaDataAssemblyImport pAssemImport,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pbHashValue,
            uint cbHashValue,
            [MarshalAs(UnmanagedType.Interface)] IMetaDataImport pImport,
            mdToken mbMember,
            [MarshalAs(UnmanagedType.Interface)] IMetaDataAssemblyEmit pAssemEmit,
            mdToken tkParent,
            out mdMemberRef pmr);

        /// <summary>
        /// Creates a definition for an event with the specified metadata signature, and gets a token to that event definition.
        /// </summary>
        /// <param name="td">[in] The token for the target class or interface. This is either a <see cref="mdTypeDef"/> or mdTypeDefNil token.</param>
        /// <param name="szEvent">[in] The name of the event.</param>
        /// <param name="dwEventFlags">[in] Event flags.</param>
        /// <param name="tkEventType">[in] The token for the event class. This is a <see cref="mdTypeDef"/>, a <see cref="mdTypeRef"/>, or a mdTokenNil token.</param>
        /// <param name="mdAddOn">[in] The method used to subscribe to the event, or null.</param>
        /// <param name="mdRemoveOn">[in] The method used to unsubscribe to the event, or null.</param>
        /// <param name="mdFire">[in] The method used (by a derived class) to raise the event.</param>
        /// <param name="rmdOtherMethods">[in] An array of tokens for other methods associated with the event. The array is terminated with a mdMethodDefNil token.</param>
        /// <param name="pmdEvent">[out] The metadata token assigned to the event.</param>
        [PreserveSig]
        HRESULT DefineEvent(
            mdToken td,
            [MarshalAs(UnmanagedType.LPWStr)] string szEvent,
            uint dwEventFlags,
            mdToken tkEventType,
            uint mdAddOn,
            uint mdRemoveOn,
            uint mdFire,
            [MarshalAs(UnmanagedType.LPArray)] mdMethodDef[] rmdOtherMethods,
            out mdToken pmdEvent);

        /// <summary>
        /// Completes the layout of fields for a class that has been defined by a prior call to <see cref="DefineTypeDef"/>.
        /// </summary>
        /// <param name="td">[in] An <see cref="mdTypeDef"/> token that specifies the class to be laid out.</param>
        /// <param name="dwPackSize">[in] The packing size: 1, 2, 4, 8 or 16 bytes. The packing size is the number of bytes between adjacent fields.</param>
        /// <param name="rFieldOffsets">[in] An array of <see cref="COR_FIELD_OFFSET"/> structures, each of which specifies a field of the class and the field's offset within the class.<para/>
        /// Terminate the array with mdTokenNil.</param>
        /// <param name="ulClassSize">[in] The size, in bytes, of the class.</param>
        /// <remarks>
        /// The class is initially defined by calling the <see cref="DefineTypeDef"/> method, and specifying one of three layouts
        /// for the fields of the class: automatic, sequential, or explicit. Normally, you would use automatic layout and let
        /// the runtime choose the best way to lay out the fields. However, you might want the fields laid out according to
        /// the arrangement that unmanaged code uses. In this case, choose either sequential or explicit layout and call SetClassLayout
        /// to complete the layout of the fields:
        /// </remarks>
        [PreserveSig]
        HRESULT SetClassLayout(
            mdTypeDef td,
            uint dwPackSize,
            [MarshalAs(UnmanagedType.LPArray)] mdToken[] rFieldOffsets,
            uint ulClassSize);

        /// <summary>
        /// Destroys the class layout metadata signature for the type represented by the specified token.
        /// </summary>
        /// <param name="td">[in] An <see cref="mdTypeDef"/> metadata token that represents the type for which the class layout will be deleted.</param>
        [PreserveSig]
        HRESULT DeleteClassLayout(mdTypeDef td);

        /// <summary>
        /// Sets the PInvoke marshalling information for the field, method return, or method parameter referenced by the specified token.
        /// </summary>
        /// <param name="tk">[in] The token for target data item. This is either a <see cref="mdFieldDef"/> or a <see cref="mdParamDef"/> token.</param>
        /// <param name="pvNativeType">[in] The signature for unmanaged type.</param>
        /// <param name="cbNativeType">[in] The count of bytes in pvNativeType.</param>
        [PreserveSig]
        HRESULT SetFieldMarshal(
            mdToken tk,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pvNativeType,
            uint cbNativeType);

        /// <summary>
        /// Destroys the PInvoke marshalling metadata signature for the object referenced by the specified token.
        /// </summary>
        /// <param name="tk">[in] An <see cref="mdFieldDef"/> or <see cref="mdParamDef"/> token that represents the field or parameter for which to delete the marshalling metadata signature.</param>
        [PreserveSig]
        HRESULT DeleteFieldMarshal(mdToken tk);

        /// <summary>
        /// Creates a definition for a permission set with the specified metadata signature, and gets a token to that permission set definition.
        /// </summary>
        /// <param name="tk">[in] The object to be decorated.</param>
        /// <param name="dwAction">[in] A <see cref="CorDeclSecurity"/> value that specifies the type of declarative security to be used.</param>
        /// <param name="pvPermission">[in] The permission BLOB.</param>
        /// <param name="cbPermission">[in] The size, in bytes, of pvPermission.</param>
        /// <param name="ppm">[out] The returned permission token.</param>
        [PreserveSig]
        HRESULT DefinePermissionSet(
            mdToken tk,
            CorDeclSecurity dwAction,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pvPermission,
            uint cbPermission,
            out uint ppm);

        /// <summary>
        /// Sets the relative virtual address of the specified method.
        /// </summary>
        /// <param name="md">[in] The token for the target method or method implementation.</param>
        /// <param name="ulRVA">[in] The address of the code or data area.</param>
        [PreserveSig]
        HRESULT SetRVA(
            uint md,
            uint ulRVA);

        /// <summary>
        /// Gets a token for the specified metadata signature.
        /// </summary>
        /// <param name="pvSig">[in] The signature to be persisted and stored.</param>
        /// <param name="cbSig">[in] The count of bytes in pvSig.</param>
        /// <param name="pmsig">[out] The <see cref="mdSignature"/> token assigned.</param>
        [PreserveSig]
        HRESULT GetTokenFromSig(
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pvSig,
            uint cbSig,
            out mdSignature pmsig);

        /// <summary>
        /// Creates the metadata signature for a module with the specified name.
        /// </summary>
        /// <param name="szName">[in] The name of the other metadata file, typically a DLL. This is the file name only. Do not use a full path name.</param>
        /// <param name="pmur">[out] The assigned <see cref="mdModuleRef"/> token.</param>
        [PreserveSig]
        HRESULT DefineModuleRef(
            [MarshalAs(UnmanagedType.LPWStr)] string szName,
            out mdModuleRef pmur);

        /// <summary>
        /// Establishes that the specified member, as defined by a prior call to <see cref="DefineMemberRef"/>, is a member of the specified type, as defined by a prior call to <see cref="DefineTypeDef"/>.
        /// </summary>
        /// <param name="mr">[in] The <see cref="mdMemberRef"/> token to receive a new parent.</param>
        /// <param name="tk">[in] The <see cref="mdToken"/> for the new parent.</param>
        [PreserveSig]
        HRESULT SetParent(
            mdMemberRef mr,
            mdToken tk);

        /// <summary>
        /// Gets a metadata token for the type with the specified metadata signature.
        /// </summary>
        /// <param name="pvSig">[in] The signature being defined.</param>
        /// <param name="cbSig">[in] The count of bytes in pvSig.</param>
        /// <param name="ptypespec">[out] The <see cref="mdTypeSpec"/> token assigned.</param>
        [PreserveSig]
        HRESULT GetTokenFromTypeSpec(
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pvSig,
            uint cbSig,
            out mdTypeSpec ptypespec);

        /// <summary>
        /// Saves all metadata in the current scope to the specified area of memory.
        /// </summary>
        /// <param name="pbData">[out] The address at which to begin writing metadata.</param>
        /// <param name="cbData">[in] The size, in bytes, of the allocated memory.</param>
        [PreserveSig]
        HRESULT SaveToMemory(
            IntPtr pbData,
            uint cbData);

        /// <summary>
        /// Gets a metadata token for the specified literal string.
        /// </summary>
        /// <param name="szString">[in] The user string to store.</param>
        /// <param name="cchString">[in] The count of wide characters in szString.</param>
        /// <param name="pstk">[out] The string token assigned.</param>
        [PreserveSig]
        HRESULT DefineUserString(
            [MarshalAs(UnmanagedType.LPWStr, SizeParamIndex = 1)] string szString,
            uint cchString,
            out uint pstk);

        /// <summary>
        /// Deletes the specified token from the current metadata scope.
        /// </summary>
        /// <param name="tkObj">[in] The token to be deleted.</param>
        [PreserveSig]
        HRESULT DeleteToken(uint tkObj);

        /// <summary>
        /// Sets or updates the feature, stored at the specified relative virtual address, of a method defined by a prior call to <see cref="DefineMethod"/>.
        /// </summary>
        /// <param name="md">[in] The token for the method to be changed.</param>
        /// <param name="dwMethodFlags">[in] The member attributes.</param>
        /// <param name="ulCodeRVA">[in] The address of the code.</param>
        /// <param name="dwImplFlags">[in] The implementation flags for the method.</param>
        [PreserveSig]
        HRESULT SetMethodProps(
            uint md,
            uint dwMethodFlags,
            uint ulCodeRVA,
            uint dwImplFlags);

        /// <summary>
        /// Sets features of a type defined by a prior call to <see cref="DefineTypeDef"/>.
        /// </summary>
        /// <param name="td">[in] An <see cref="mdTypeDef"/> token obtained from original call to <see cref="DefineTypeDef"/>.</param>
        /// <param name="dwTypeDefFlags">[in] TypeDef attributes. This is a bitmask of <see cref="CorTypeAttr"/> values.</param>
        /// <param name="tkExtends">[in] The <see cref="mdToken"/> of the base class. Obtained from a previous call to <see cref="DefineImportType"/>, or null.</param>
        /// <param name="rtkImplements">[in] An array of tokens for the interfaces that this type implements. These <see cref="mdTypeRef"/> tokens are obtained using <see cref="DefineImportType"/>.<para/>
        /// The last element of the array is must be mdTokenNil.</param>
        [PreserveSig]
        HRESULT SetTypeDefProps(
            mdTypeDef td,
            CorTypeAttr dwTypeDefFlags,
            mdToken tkExtends,
            [MarshalAs(UnmanagedType.LPArray)] mdToken[] rtkImplements);

        /// <summary>
        /// Sets or updates the specified feature of an event defined by a prior call to <see cref="DefineEvent"/>.
        /// </summary>
        /// <param name="ev">[in] The event token.</param>
        /// <param name="dwEventFlags">[in] Event flags. This is a bitmask of <see cref="CorEventAttr"/> values.</param>
        /// <param name="tkEventType">[in] The token for the event class. This is either a <see cref="mdTypeDef"/> or a <see cref="mdTypeRef"/> token.</param>
        /// <param name="mdAddOn">[in] The method used to subscribe to the event, or null.</param>
        /// <param name="mdRemoveOn">[in] The method used to unsubscribe to the event, or null.</param>
        /// <param name="mdFire">[in] The method used (by a derived class) to raise the event.</param>
        /// <param name="rmdOtherMethods">[in] An array of tokens for other methods associated with the event. The last element of the array must be mdMethodDefNil.</param>
        [PreserveSig]
        HRESULT SetEventProps(
            uint ev,
            CorEventAttr dwEventFlags,
            mdToken tkEventType,
            uint mdAddOn,
            uint mdRemoveOn,
            uint mdFire,
            [MarshalAs(UnmanagedType.LPArray)] mdMethodDef[] rmdOtherMethods);

        /// <summary>
        /// Sets or updates features of the metadata signature of a permission set defined by a prior call to <see cref="DefinePermissionSet"/>.
        /// </summary>
        /// <param name="tk">[in] A metadata token that represents the object to be decorated.</param>
        /// <param name="dwAction">[in] A <see cref="CorDeclSecurity"/> value that specifies the type of declarative security to be used.</param>
        /// <param name="pvPermission">[in] The permission BLOB.</param>
        /// <param name="cbPermission">[in] The size, in bytes, of pvPermission.</param>
        /// <param name="ppm">[out] An <see cref="mdPermission"/> metadata token that represents the updated permissions.</param>
        [PreserveSig]
        HRESULT SetPermissionSetProps(
            uint tk,
            CorDeclSecurity dwAction,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pvPermission,
            uint cbPermission,
            out mdPermission ppm);

        /// <summary>
        /// Sets features of the PInvoke signature of the method referenced by the specified token.
        /// </summary>
        /// <param name="tk">[in] The token for the target method.</param>
        /// <param name="dwMappingFlags">[in] Flags used by PInvoke to do the mapping.</param>
        /// <param name="szImportName">[in] The name of the target export method in an unmanaged DLL.</param>
        /// <param name="mrImportDLL">[in] The token for the target native DLL.</param>
        [PreserveSig]
        HRESULT DefinePinvokeMap(
            uint tk,
            uint dwMappingFlags,
            [MarshalAs(UnmanagedType.LPWStr)] string szImportName,
            uint mrImportDLL);

        /// <summary>
        /// Sets or changes features of a method's PInvoke signature, as defined by a prior call to <see cref="DefinePinvokeMap"/>.
        /// </summary>
        /// <param name="tk">[in] The <see cref="mdToken"/> to which mapping information applies.</param>
        /// <param name="dwMappingFlags">[in] Flags used by PInvoke to do the mapping. This is a bitmask of <see cref="CorPinvokeMap"/> values.</param>
        /// <param name="szImportName">[in] The name of the target export in the native DLL.</param>
        /// <param name="mrImportDLL">[in] The <see cref="mdModuleRef"/> token for the target unmanaged DLL.</param>
        [PreserveSig]
        HRESULT SetPinvokeMap(
            mdToken tk,
            CorPinvokeMap dwMappingFlags,
            [MarshalAs(UnmanagedType.LPWStr)] string szImportName,
            mdModuleRef mrImportDLL);

        /// <summary>
        /// Destroys the PInvoke mapping metadata for the object referenced by the specified token.
        /// </summary>
        /// <param name="tk">[in] An <see cref="mdFieldDef"/> or <see cref="mdMethodDef"/> token that represents the object for which to delete the PInvoke mapping metadata.</param>
        [PreserveSig]
        HRESULT DeletePinvokeMap(mdToken tk);

        /// <summary>
        /// Creates a definition for a custom attribute with the specified metadata signature, to be attached to the specified object, and gets a token to that custom attribute definition.
        /// </summary>
        /// <param name="tkObj">[in] The token for the owner item.</param>
        /// <param name="tkType">[in] The token that identifies the custom attribute.</param>
        /// <param name="pCustomAttribute">[in] A pointer to the custom attribute.</param>
        /// <param name="cbCustomAttribute">[in] The count of bytes in pCustomAttribute.</param>
        /// <param name="pcv">[out] The <see cref="mdCustomAttribute"/> token assigned.</param>
        [PreserveSig]
        HRESULT DefineCustomAttribute(
            uint tkObj,
            uint tkType,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pCustomAttribute,
            uint cbCustomAttribute,
            out mdCustomAttribute pcv);

        /// <summary>
        /// Sets or updates the value of a custom attribute defined by a prior call to <see cref="DefineCustomAttribute"/>.
        /// </summary>
        /// <param name="pcv">[in] The token of the target custom attribute.</param>
        /// <param name="pCustomAttribute">[in] A pointer to the array that contains the custom attribute.</param>
        /// <param name="cbCustomAttribute">[in] The size, in bytes, of the custom attribute.</param>
        [PreserveSig]
        HRESULT SetCustomAttributeValue(
            uint pcv,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pCustomAttribute,
            uint cbCustomAttribute);

        /// <summary>
        /// Creates a definition for a field with the specified metadata signature, and gets a token to that field definition.
        /// </summary>
        /// <param name="td">[in] The <see cref="mdTypeDef"/> token for the enclosing class or interface.</param>
        /// <param name="szName">[in] The field name in Unicode.</param>
        /// <param name="dwFieldFlags">[in] The field attributes. This is a bitmask of <see cref="CorFieldAttr"/> values.</param>
        /// <param name="pvSigBlob">[in] The field signature as a BLOB.</param>
        /// <param name="cbSigBlob">[in] The count of bytes in pvSigBlob.</param>
        /// <param name="dwCPlusTypeFlag">[in] The ELEMENT_TYPE_* for the constant value. This is a <see cref="CorElementType"/> value. If not defining a constant value for the field, use ELEMENT_TYPE_END.</param>
        /// <param name="pValue">[in] The constant value for the field.</param>
        /// <param name="cchValue">[in] The size in (Unicode) characters of pValue.</param>
        /// <param name="pmd">[out] The <see cref="mdFieldDef"/> token assigned.</param>
        [PreserveSig]
        HRESULT DefineField(
            mdTypeDef td,
            [MarshalAs(UnmanagedType.LPWStr)] string szName,
            CorFieldAttr dwFieldFlags,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] pvSigBlob,
            uint cbSigBlob,
            CorElementType dwCPlusTypeFlag,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 7)] byte[] pValue,
            uint cchValue,
            out mdFieldDef pmd);

        /// <summary>
        /// Creates a property definition for the specified type, with the specified get and set method accessors, and gets a token to that property definition.
        /// </summary>
        /// <param name="td">[in] The token for class or interface on which the property is being defined.</param>
        /// <param name="szProperty">[in] The name of the property.</param>
        /// <param name="dwPropFlags">[in] The property flags.</param>
        /// <param name="pvSig">[in] The property signature.</param>
        /// <param name="cbSig">[in] The count of bytes in pvSig.</param>
        /// <param name="dwCPlusTypeFlag">[in] The type of the property's default value.</param>
        /// <param name="cvalue">[in] The default value for the property.</param>
        /// <param name="cchValue">[in] The count of (Unicode) characters in pValue.</param>
        /// <param name="mdSetter">[in] The method that sets the property value.</param>
        /// <param name="mdGetter">[in] The method that gets the property value.</param>
        /// <param name="rmdOtherMethods">[in] An array of other methods associated with the property. Terminate the array with an mdTokenNil.</param>
        /// <param name="pmdProp">[out] The <see cref="mdProperty"/> token assigned.</param>
        [PreserveSig]
        HRESULT DefineProperty(
            uint td,
            [MarshalAs(UnmanagedType.LPWStr)] string szProperty,
            uint dwPropFlags,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] pvSig,
            uint cbSig,
            uint dwCPlusTypeFlag,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 7)] byte[] cvalue,
            uint cchValue,
            uint mdSetter,
            uint mdGetter,
            [MarshalAs(UnmanagedType.LPArray)] mdToken[] rmdOtherMethods,
            out mdProperty pmdProp);

        /// <summary>
        /// Creates a parameter definition with the specified signature for the method referenced by the specified token, and gets a token for that parameter definition.
        /// </summary>
        /// <param name="md">[in] The token for the method whose parameter is being defined.</param>
        /// <param name="ulParamSeq">[in] The parameter sequence number.</param>
        /// <param name="szName">[in] The name of the parameter in Unicode.</param>
        /// <param name="dwParamFlags">[in] Flags for the parameter. This is a bitmask of <see cref="CorParamAttr"/> values.</param>
        /// <param name="dwCPlusTypeFlag">[in] ELEMENT_TYPE_* for the constant value.</param>
        /// <param name="pValue">[in] The constant value for the parameter.</param>
        /// <param name="cchValue">[in] The size, in Unicode characters, of pValue.</param>
        /// <param name="ppd">[out] The <see cref="mdParamDef"/> token assigned.</param>
        /// <remarks>
        /// The sequence values in ulParamSeq begin with 1 for parameters. A return value has a sequence number of 0.
        /// </remarks>
        [PreserveSig]
        HRESULT DefineParam(
            uint md,
            uint ulParamSeq,
            [MarshalAs(UnmanagedType.LPWStr)] string szName,
            CorParamAttr dwParamFlags,
            CorElementType dwCPlusTypeFlag,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)] byte[] pValue,
            uint cchValue,
            out mdParamDef ppd);

        /// <summary>
        /// Sets or updates the default value for the field referenced by the specified field token.
        /// </summary>
        /// <param name="fd">[in] The token for the target field.</param>
        /// <param name="dwFieldFlags">[in] Field attributes. This is a bitmask of <see cref="CorFieldAttr"/> values.</param>
        /// <param name="dwCPlusTypeFlag">[in] The ELEMENT_TYPE_* for the constant value. This is a <see cref="CorElementType"/> value. If a constant is not being defined, set this value to ELEMENT_TYPE_END.</param>
        /// <param name="pValue">[in] The constant value for the field.</param>
        /// <param name="cchValue">[in] The size, in Unicode characters, of pValue.</param>
        [PreserveSig]
        HRESULT SetFieldProps(
            uint fd,
            CorFieldAttr dwFieldFlags,
            CorElementType dwCPlusTypeFlag,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] pValue,
            uint cchValue);

        /// <summary>
        /// Sets the features stored in metadata for a property defined by a prior call to <see cref="DefineProperty"/>.
        /// </summary>
        /// <param name="pr">[in] The token for the property to be changed</param>
        /// <param name="dwPropFlags">[in] Property flags.</param>
        /// <param name="dwCPlusTypeFlag">[in] The type of the property's default value.</param>
        /// <param name="pValue">[in] The default value for the property.</param>
        /// <param name="cchValue">[in] The count of (Unicode) characters in pValue.</param>
        /// <param name="mdSetter">[in] The method that sets the property value.</param>
        /// <param name="mdGetter">[in] The method that gets the property value.</param>
        /// <param name="rmdOtherMethods">[in] An array of other methods associated with the property. Terminate this array with an mdTokenNil token.</param>
        [PreserveSig]
        HRESULT SetPropertyProps(
            uint pr,
            uint dwPropFlags,
            uint dwCPlusTypeFlag,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] pValue,
            uint cchValue,
            uint mdSetter,
            uint mdGetter,
            [MarshalAs(UnmanagedType.LPArray)] mdToken[] rmdOtherMethods);

        /// <summary>
        /// Sets or changes features of a method parameter that was defined by a prior call to <see cref="DefineParam"/>.
        /// </summary>
        /// <param name="pd">[in] The token for the target parameter.</param>
        /// <param name="szName">[in] The name of the parameter in Unicode.</param>
        /// <param name="dwParamFlags">[in] The flags for the parameter.</param>
        /// <param name="dwCPlusTypeFlag">[in] The ELEMENT_TYPE_* for the constant value.</param>
        /// <param name="pValue">[in] The constant value for the parameter.</param>
        /// <param name="cchValue">[in] The size in (Unicode) characters of pValue.</param>
        [PreserveSig]
        HRESULT SetParamProps(
            uint pd,
            [MarshalAs(UnmanagedType.LPWStr)] string szName,
            uint dwParamFlags,
            uint dwCPlusTypeFlag,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] byte[] pValue,
            uint cchValue);

        /// <summary>
        /// Creates a set of security permissions to attach to the object referenced by the specified token.
        /// </summary>
        /// <param name="tkObj">[in] The token to which the security information is attached.</param>
        /// <param name="rSecAttrs">[in] An array of <see cref="COR_SECATTR"/> structures.</param>
        /// <param name="cSecAttrs">[in] The number of elements in rSecAttrs.</param>
        /// <param name="pulErrorAttr">[out] If the method fails, specifies the index in rSecAttrs of the element that caused the problem.</param>
        [PreserveSig]
        HRESULT DefineSecurityAttributeSet(
            uint tkObj,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] COR_SECATTR[] rSecAttrs,
            uint cSecAttrs,
            out uint pulErrorAttr);

        /// <summary>
        /// Updates the current assembly scope with the changes made in the specified metadata.
        /// </summary>
        /// <param name="pImport">[in] Pointer to an IUnknown object that represents the delta metadata from the portable executable (PE) file. The delta metadata is the block of metadata that includes the changes that were made to the copy of the module's actual metadata.</param>
        [PreserveSig]
        HRESULT ApplyEditAndContinue([MarshalAs(UnmanagedType.IUnknown)] object pImport);

        /// <summary>
        /// Imports an assembly into the current scope and gets a new metadata signature for the merged scope.
        /// </summary>
        /// <param name="pAssemImport">[in] The interface for import assembly (where the signature is defined).</param>
        /// <param name="pbHashValue">[in] The hash blob for the assembly.</param>
        /// <param name="cbHashValue">[in] The count of bytes in pbHashValue.</param>
        /// <param name="import">[in] The interface for import metadata scope.</param>
        /// <param name="pbSigBlob">[in] The signature to be imported.</param>
        /// <param name="cbSigBlob">[in] The size, in bytes, of pbSigBlob.</param>
        /// <param name="pAssemEmit">[in] The interface for export assembly.</param>
        /// <param name="emit">[in] The interface for export metadata scope.</param>
        /// <param name="pvTranslatedSig">[out] The buffer to hold the translated signature blob.</param>
        /// <param name="cbTranslatedSigMax">[in] The capacity, in bytes, of pvTranslatedSig.</param>
        /// <param name="pcbTranslatedSig">[out] The number of actual bytes in the translated signature.</param>
        [PreserveSig]
        HRESULT TranslateSigWithScope(
            [MarshalAs(UnmanagedType.Interface)] IMetaDataAssemblyImport pAssemImport,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pbHashValue,
            uint cbHashValue,
            [MarshalAs(UnmanagedType.Interface)] IMetaDataImport import,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] byte[] pbSigBlob,
            uint cbSigBlob,
            [MarshalAs(UnmanagedType.Interface)] IMetaDataAssemblyEmit pAssemEmit,
            [MarshalAs(UnmanagedType.Interface)] IMetaDataEmit emit,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 9)] byte[] pvTranslatedSig,
            uint cbTranslatedSigMax,
            out uint pcbTranslatedSig);

        /// <summary>
        /// Sets or updates the metadata signature of the inherited method implementation that is referenced by the specified token.
        /// </summary>
        /// <param name="md">[in] The token for the method to be changed.</param>
        /// <param name="dwImplFlags">[in] A combination of the values of the <see cref="CorMethodImpl"/> enumeration that specifies the method implementation features.</param>
        [PreserveSig]
        HRESULT SetMethodImplFlags(
            uint md,
            uint dwImplFlags);

        /// <summary>
        /// Sets a global variable value for the relative virtual address of the field referenced by the specified token.
        /// </summary>
        /// <param name="fd">[in] The token for the target field.</param>
        /// <param name="ulRVA">[in] The address of a code or data area.</param>
        [PreserveSig]
        HRESULT SetFieldRVA(
            uint fd,
            uint ulRVA);

        /// <summary>
        /// Adds the specified imported scope to the list of scopes to be merged.
        /// </summary>
        /// <param name="pImport">[in] A pointer to an <see cref="IMetaDataImport"/> object that identifies the imported scope to be merged.</param>
        /// <param name="pHostMapToken">[in] A pointer to an <see cref="IMapToken"/> object that specifies the token re-map.</param>
        /// <param name="pHandler">[in] A pointer to an IUnknown object that specifies the errors.</param>
        /// <remarks>
        /// Call <see cref="MergeEnd"/> to trigger the merger of metadata into a single scope.
        /// </remarks>
        [PreserveSig]
        HRESULT Merge(
            [MarshalAs(UnmanagedType.Interface)] IMetaDataImport pImport,
            [MarshalAs(UnmanagedType.Interface)] IMapToken pHostMapToken,
            [MarshalAs(UnmanagedType.IUnknown)] object pHandler);

        /// <summary>
        /// Merges into the current scope all the metadata scopes specified by one or more prior calls to <see cref="Merge"/>.
        /// </summary>
        /// <remarks>
        /// This routine triggers the actual merge of metadata, of all import scopes specified by preceding calls to <see cref="Merge"/>,
        /// into the current output scope. The following special conditions apply to the merge:
        /// </remarks>
        [PreserveSig]
        HRESULT MergeEnd();
    }
}
