using System;
using System.Diagnostics;
using System.Reflection;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods to create, modify, and save metadata about the assembly in the currently defined scope. The metadata can be stored in memory or saved to disk.
    /// </summary>
    public class MetaDataEmit : ComObject<IMetaDataEmit>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetaDataEmit"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public MetaDataEmit(IMetaDataEmit raw) : base(raw)
        {
        }

        #region IMetaDataEmit
        #region SetModuleProps

        /// <summary>
        /// Updates references to a module defined by a prior call to <see cref="DefineModuleRef"/>.
        /// </summary>
        /// <param name="szName">[in] The module name in Unicode. This is the file name only and not the full path name.</param>
        public void SetModuleProps(string szName)
        {
            TrySetModuleProps(szName).ThrowOnNotOK();
        }

        /// <summary>
        /// Updates references to a module defined by a prior call to <see cref="DefineModuleRef"/>.
        /// </summary>
        /// <param name="szName">[in] The module name in Unicode. This is the file name only and not the full path name.</param>
        public HRESULT TrySetModuleProps(string szName)
        {
            /*HRESULT SetModuleProps(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName);*/
            return Raw.SetModuleProps(szName);
        }

        #endregion
        #region Save

        /// <summary>
        /// Saves all metadata in the current scope to the file at the specified address.
        /// </summary>
        /// <param name="szFile">[in] The name of the file to save to. If this value is null, the in-memory copy will be saved to the last location that was used.</param>
        /// <param name="dwSaveFlags">[in] Reserved. Must be zero.</param>
        public void Save(string szFile, int dwSaveFlags)
        {
            TrySave(szFile, dwSaveFlags).ThrowOnNotOK();
        }

        /// <summary>
        /// Saves all metadata in the current scope to the file at the specified address.
        /// </summary>
        /// <param name="szFile">[in] The name of the file to save to. If this value is null, the in-memory copy will be saved to the last location that was used.</param>
        /// <param name="dwSaveFlags">[in] Reserved. Must be zero.</param>
        public HRESULT TrySave(string szFile, int dwSaveFlags)
        {
            /*HRESULT Save(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szFile,
            [In] int dwSaveFlags);*/
            return Raw.Save(szFile, dwSaveFlags);
        }

        #endregion
        #region SaveToStream

        /// <summary>
        /// Saves all metadata in the current scope to the specified <see cref="IStream"/>.
        /// </summary>
        /// <param name="pIStream">[in] The writable stream to save to.</param>
        /// <param name="dwSaveFlags">[in] Reserved. Must be zero.</param>
        public void SaveToStream(IStream pIStream, int dwSaveFlags)
        {
            TrySaveToStream(pIStream, dwSaveFlags).ThrowOnNotOK();
        }

        /// <summary>
        /// Saves all metadata in the current scope to the specified <see cref="IStream"/>.
        /// </summary>
        /// <param name="pIStream">[in] The writable stream to save to.</param>
        /// <param name="dwSaveFlags">[in] Reserved. Must be zero.</param>
        public HRESULT TrySaveToStream(IStream pIStream, int dwSaveFlags)
        {
            /*HRESULT SaveToStream(
            [In, MarshalAs(UnmanagedType.Interface)] IStream pIStream,
            [In] int dwSaveFlags);*/
            return Raw.SaveToStream(pIStream, dwSaveFlags);
        }

        #endregion
        #region GetSaveSize

        /// <summary>
        /// Gets the estimated binary size of the assembly and its metadata in the current scope.
        /// </summary>
        /// <param name="fSave">[in] A value of the <see cref="CorSaveSize"/> enumeration that specifies whether to get an accurate or approximate size.<para/>
        /// Only three values are valid: cssAccurate, cssQuick, and cssDiscardTransientCAs:</param>
        /// <returns>[out] A pointer to the size that is required to save the file.</returns>
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
        public int GetSaveSize(CorSaveSize fSave)
        {
            int pdwSaveSize;
            TryGetSaveSize(fSave, out pdwSaveSize).ThrowOnNotOK();

            return pdwSaveSize;
        }

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
        public HRESULT TryGetSaveSize(CorSaveSize fSave, out int pdwSaveSize)
        {
            /*HRESULT GetSaveSize(
            [In] CorSaveSize fSave,
            [Out] out int pdwSaveSize);*/
            return Raw.GetSaveSize(fSave, out pdwSaveSize);
        }

        #endregion
        #region DefineTypeDef

        /// <summary>
        /// Creates a type definition for a common language runtime type, and gets a metadata token for that type definition.
        /// </summary>
        /// <param name="szTypeDef">[in] The name of the type in Unicode.</param>
        /// <param name="dwTypeDefFlags">[in] TypeDef attributes. This is a bitmask of <see cref="CorTypeAttr"/> values.</param>
        /// <param name="tkExtends">[in] The token of the base class. It must be either an <see cref="mdTypeDef"/> or an <see cref="mdTypeRef"/> token.</param>
        /// <param name="rtkImplements">[in] An array of tokens specifying the interfaces that this class or interface implements.</param>
        /// <returns>[out] The <see cref="mdTypeDef"/> token assigned.</returns>
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
        public mdTypeDef DefineTypeDef(string szTypeDef, CorTypeAttr dwTypeDefFlags, mdToken tkExtends, mdToken[] rtkImplements)
        {
            mdTypeDef ptd;
            TryDefineTypeDef(szTypeDef, dwTypeDefFlags, tkExtends, rtkImplements, out ptd).ThrowOnNotOK();

            return ptd;
        }

        /// <summary>
        /// Creates a type definition for a common language runtime type, and gets a metadata token for that type definition.
        /// </summary>
        /// <param name="szTypeDef">[in] The name of the type in Unicode.</param>
        /// <param name="dwTypeDefFlags">[in] TypeDef attributes. This is a bitmask of <see cref="CorTypeAttr"/> values.</param>
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
        public HRESULT TryDefineTypeDef(string szTypeDef, CorTypeAttr dwTypeDefFlags, mdToken tkExtends, mdToken[] rtkImplements, out mdTypeDef ptd)
        {
            /*HRESULT DefineTypeDef(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szTypeDef,
            [In] CorTypeAttr dwTypeDefFlags,
            [In] mdToken tkExtends,
            [In, MarshalAs(UnmanagedType.LPArray)] mdToken[] rtkImplements,
            [Out] out mdTypeDef ptd);*/
            return Raw.DefineTypeDef(szTypeDef, dwTypeDefFlags, tkExtends, rtkImplements, out ptd);
        }

        #endregion
        #region DefineNestedType

        /// <summary>
        /// Creates the metadata signature of a type definition, returns an <see cref="mdTypeDef"/> token for that type, and specifies that the defined type is a member of the type referenced by the tdEncloser parameter.
        /// </summary>
        /// <param name="szTypeDef">[in] The name of the type in Unicode.</param>
        /// <param name="dwTypeDefFlags">[in] TypeDef attributes. This is a bitmask of <see cref="CorTypeAttr"/> values.</param>
        /// <param name="tkExtends">[in] The token of the base class. This is either a <see cref="mdTypeDef"/> or a <see cref="mdTypeRef"/> token.</param>
        /// <param name="rtkImplements">[in] An array of tokens that specify the interfaces that this class or interface implements.</param>
        /// <param name="tdEncloser">[in] The token of the enclosing type. The last element of the array must be mdTokenNil.</param>
        /// <returns>[out] The <see cref="mdTypeDef"/> token assigned.</returns>
        public mdTypeDef DefineNestedType(string szTypeDef, CorTypeAttr dwTypeDefFlags, mdToken tkExtends, mdToken[] rtkImplements, mdTypeDef tdEncloser)
        {
            mdTypeDef ptd;
            TryDefineNestedType(szTypeDef, dwTypeDefFlags, tkExtends, rtkImplements, tdEncloser, out ptd).ThrowOnNotOK();

            return ptd;
        }

        /// <summary>
        /// Creates the metadata signature of a type definition, returns an <see cref="mdTypeDef"/> token for that type, and specifies that the defined type is a member of the type referenced by the tdEncloser parameter.
        /// </summary>
        /// <param name="szTypeDef">[in] The name of the type in Unicode.</param>
        /// <param name="dwTypeDefFlags">[in] TypeDef attributes. This is a bitmask of <see cref="CorTypeAttr"/> values.</param>
        /// <param name="tkExtends">[in] The token of the base class. This is either a <see cref="mdTypeDef"/> or a <see cref="mdTypeRef"/> token.</param>
        /// <param name="rtkImplements">[in] An array of tokens that specify the interfaces that this class or interface implements.</param>
        /// <param name="tdEncloser">[in] The token of the enclosing type. The last element of the array must be mdTokenNil.</param>
        /// <param name="ptd">[out] The <see cref="mdTypeDef"/> token assigned.</param>
        public HRESULT TryDefineNestedType(string szTypeDef, CorTypeAttr dwTypeDefFlags, mdToken tkExtends, mdToken[] rtkImplements, mdTypeDef tdEncloser, out mdTypeDef ptd)
        {
            /*HRESULT DefineNestedType(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szTypeDef,
            [In] CorTypeAttr dwTypeDefFlags,
            [In] mdToken tkExtends,
            [In, MarshalAs(UnmanagedType.LPArray)] mdToken[] rtkImplements,
            [In] mdTypeDef tdEncloser,
            [Out] out mdTypeDef ptd);*/
            return Raw.DefineNestedType(szTypeDef, dwTypeDefFlags, tkExtends, rtkImplements, tdEncloser, out ptd);
        }

        #endregion
        #region SetHandler

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
        public void SetHandler(object pUnk)
        {
            TrySetHandler(pUnk).ThrowOnNotOK();
        }

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
        public HRESULT TrySetHandler(object pUnk)
        {
            /*HRESULT SetHandler(
            [In, MarshalAs(UnmanagedType.IUnknown)] object pUnk);*/
            return Raw.SetHandler(pUnk);
        }

        #endregion
        #region DefineMethod

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
        /// <returns>[out] The member token.</returns>
        /// <remarks>
        /// The metadata API guarantees to persist methods in the same order as the caller emits them for a given enclosing
        /// class or interface, which is specified in the td parameter. Additional information regarding the use of DefineMethod
        /// and particular parameter settings is given below.
        /// </remarks>
        public mdMethodDef DefineMethod(mdTypeDef td, string szName, MethodAttributes dwMethodFlags, IntPtr pvSigBlob, int cbSigBlob, int ulCodeRVA, MethodImplAttributes dwImplFlags)
        {
            mdMethodDef pmd;
            TryDefineMethod(td, szName, dwMethodFlags, pvSigBlob, cbSigBlob, ulCodeRVA, dwImplFlags, out pmd).ThrowOnNotOK();

            return pmd;
        }

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
        public HRESULT TryDefineMethod(mdTypeDef td, string szName, MethodAttributes dwMethodFlags, IntPtr pvSigBlob, int cbSigBlob, int ulCodeRVA, MethodImplAttributes dwImplFlags, out mdMethodDef pmd)
        {
            /*HRESULT DefineMethod(
            [In] mdTypeDef td,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [In] MethodAttributes dwMethodFlags,
            [In] IntPtr pvSigBlob,
            [In] int cbSigBlob,
            [In] int ulCodeRVA,
            [In] MethodImplAttributes dwImplFlags,
            [Out] out mdMethodDef pmd);*/
            return Raw.DefineMethod(td, szName, dwMethodFlags, pvSigBlob, cbSigBlob, ulCodeRVA, dwImplFlags, out pmd);
        }

        #endregion
        #region DefineMethodImpl

        /// <summary>
        /// Creates a definition for implementation of a method inherited from an interface, and returns a token to that method-implementation definition.
        /// </summary>
        /// <param name="td">[in] The <see cref="mdTypeDef"/> token of the implementing class.</param>
        /// <param name="tkBody">[in] The <see cref="mdMethodDef"/> or <see cref="mdMemberRef"/> token of the code body.</param>
        /// <param name="tkDecl">[in] The <see cref="mdMethodDef"/> or <see cref="mdMemberRef"/> token of the interface method being implemented.</param>
        public void DefineMethodImpl(mdTypeDef td, mdToken tkBody, mdToken tkDecl)
        {
            TryDefineMethodImpl(td, tkBody, tkDecl).ThrowOnNotOK();
        }

        /// <summary>
        /// Creates a definition for implementation of a method inherited from an interface, and returns a token to that method-implementation definition.
        /// </summary>
        /// <param name="td">[in] The <see cref="mdTypeDef"/> token of the implementing class.</param>
        /// <param name="tkBody">[in] The <see cref="mdMethodDef"/> or <see cref="mdMemberRef"/> token of the code body.</param>
        /// <param name="tkDecl">[in] The <see cref="mdMethodDef"/> or <see cref="mdMemberRef"/> token of the interface method being implemented.</param>
        public HRESULT TryDefineMethodImpl(mdTypeDef td, mdToken tkBody, mdToken tkDecl)
        {
            /*HRESULT DefineMethodImpl(
            [In] mdTypeDef td,
            [In] mdToken tkBody,
            [In] mdToken tkDecl);*/
            return Raw.DefineMethodImpl(td, tkBody, tkDecl);
        }

        #endregion
        #region DefineTypeRefByName

        /// <summary>
        /// Gets a metadata token for a type that is defined in the specified scope, which is outside the current scope.
        /// </summary>
        /// <param name="tkResolutionScope">[in] The token specifying the resolution scope. The following token types are valid:</param>
        /// <param name="szName">[in] The name of the target type in Unicode.</param>
        /// <returns>[out] A pointer to the <see cref="mdTypeRef"/> token that is assigned to the type.</returns>
        public mdTypeRef DefineTypeRefByName(mdToken tkResolutionScope, string szName)
        {
            mdTypeRef ptr;
            TryDefineTypeRefByName(tkResolutionScope, szName, out ptr).ThrowOnNotOK();

            return ptr;
        }

        /// <summary>
        /// Gets a metadata token for a type that is defined in the specified scope, which is outside the current scope.
        /// </summary>
        /// <param name="tkResolutionScope">[in] The token specifying the resolution scope. The following token types are valid:</param>
        /// <param name="szName">[in] The name of the target type in Unicode.</param>
        /// <param name="ptr">[out] A pointer to the <see cref="mdTypeRef"/> token that is assigned to the type.</param>
        public HRESULT TryDefineTypeRefByName(mdToken tkResolutionScope, string szName, out mdTypeRef ptr)
        {
            /*HRESULT DefineTypeRefByName(
            [In] mdToken tkResolutionScope,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [Out] out mdTypeRef ptr);*/
            return Raw.DefineTypeRefByName(tkResolutionScope, szName, out ptr);
        }

        #endregion
        #region DefineImportType

        /// <summary>
        /// Creates a reference to the specified type that is defined outside the current scope, and defines a token for that reference.
        /// </summary>
        /// <param name="pAssemImport">[in] An <see cref="IMetaDataAssemblyImport"/> interface that represents the assembly from which the target type is imported.</param>
        /// <param name="pbHashValue">[in] An array that contains the hash for the assembly specified by pAssemImport.</param>
        /// <param name="cbHashValue">[in] The number of bytes in the pbHashValue array.</param>
        /// <param name="pImport">[in] An <see cref="IMetaDataImport"/> interface that represents the metadata scope from which the target type is imported.</param>
        /// <param name="tdImport">[in] An <see cref="mdTypeDef"/> token that specifies the target type.</param>
        /// <param name="pAssemEmit">[in] An <see cref="IMetaDataAssemblyEmit"/> interface that represents the assembly into which the target type is imported.</param>
        /// <returns>[out] The <see cref="mdTypeRef"/> token that is defined in the current scope for the type reference.</returns>
        /// <remarks>
        /// Prior to calling the <see cref="DefineImportMember"/> method, you can use the DefineImportType method to create
        /// a type reference, in the current scope, for the member's parent class or parent interface.
        /// </remarks>
        public mdTypeRef DefineImportType(IMetaDataAssemblyImport pAssemImport, IntPtr pbHashValue, int cbHashValue, IMetaDataImport pImport, mdTypeDef tdImport, IMetaDataAssemblyEmit pAssemEmit)
        {
            mdTypeRef ptr;
            TryDefineImportType(pAssemImport, pbHashValue, cbHashValue, pImport, tdImport, pAssemEmit, out ptr).ThrowOnNotOK();

            return ptr;
        }

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
        public HRESULT TryDefineImportType(IMetaDataAssemblyImport pAssemImport, IntPtr pbHashValue, int cbHashValue, IMetaDataImport pImport, mdTypeDef tdImport, IMetaDataAssemblyEmit pAssemEmit, out mdTypeRef ptr)
        {
            /*HRESULT DefineImportType(
            [In, MarshalAs(UnmanagedType.Interface)] IMetaDataAssemblyImport pAssemImport,
            [In] IntPtr pbHashValue,
            [In] int cbHashValue,
            [In, MarshalAs(UnmanagedType.Interface)] IMetaDataImport pImport,
            [In] mdTypeDef tdImport,
            [In, MarshalAs(UnmanagedType.Interface)] IMetaDataAssemblyEmit pAssemEmit,
            [Out] out mdTypeRef ptr);*/
            return Raw.DefineImportType(pAssemImport, pbHashValue, cbHashValue, pImport, tdImport, pAssemEmit, out ptr);
        }

        #endregion
        #region DefineMemberRef

        /// <summary>
        /// Defines a reference to a member of a module outside the current scope, and gets a token to that reference definition.
        /// </summary>
        /// <param name="tkImport">[in] Token for the target member's class or interface, if the member is not global; if the member is global, the <see cref="mdModuleRef"/> token for that other file.</param>
        /// <param name="szName">[in] The name of the target member.</param>
        /// <param name="pvSigBlob">[in] The signature of the target member.</param>
        /// <param name="cbSigBlob">[in] The count of bytes in pvSigBlob.</param>
        /// <returns>[out] The <see cref="mdMemberRef"/> token assigned.</returns>
        public mdMemberRef DefineMemberRef(mdToken tkImport, string szName, IntPtr pvSigBlob, int cbSigBlob)
        {
            mdMemberRef pmr;
            TryDefineMemberRef(tkImport, szName, pvSigBlob, cbSigBlob, out pmr).ThrowOnNotOK();

            return pmr;
        }

        /// <summary>
        /// Defines a reference to a member of a module outside the current scope, and gets a token to that reference definition.
        /// </summary>
        /// <param name="tkImport">[in] Token for the target member's class or interface, if the member is not global; if the member is global, the <see cref="mdModuleRef"/> token for that other file.</param>
        /// <param name="szName">[in] The name of the target member.</param>
        /// <param name="pvSigBlob">[in] The signature of the target member.</param>
        /// <param name="cbSigBlob">[in] The count of bytes in pvSigBlob.</param>
        /// <param name="pmr">[out] The <see cref="mdMemberRef"/> token assigned.</param>
        public HRESULT TryDefineMemberRef(mdToken tkImport, string szName, IntPtr pvSigBlob, int cbSigBlob, out mdMemberRef pmr)
        {
            /*HRESULT DefineMemberRef(
            [In] mdToken tkImport,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [In] IntPtr pvSigBlob,
            [In] int cbSigBlob,
            [Out] out mdMemberRef pmr);*/
            return Raw.DefineMemberRef(tkImport, szName, pvSigBlob, cbSigBlob, out pmr);
        }

        #endregion
        #region DefineImportMember

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
        /// <returns>[out] The <see cref="mdMemberRef"/> token that is defined in the current scope for the member reference.</returns>
        /// <remarks>
        /// The DefineImportMember method looks up the member, specified by mbMember, that is defined in another scope, specified
        /// by pImport, and retrieves its properties. It uses this information to call the <see cref="DefineMemberRef"/> method
        /// in the current scope to create the member reference. Generally, before you use the DefineImportMember method, you
        /// must create, in the current scope, a type reference or module reference for the target member's parent class, interface,
        /// or module. The metadata token for this reference is then passed in the tkParent argument. You do not need to create
        /// a reference to the target member's parent if it will be resolved later by the compiler or linker. To summarize:
        /// </remarks>
        public mdMemberRef DefineImportMember(IMetaDataAssemblyImport pAssemImport, IntPtr pbHashValue, int cbHashValue, IMetaDataImport pImport, mdToken mbMember, IMetaDataAssemblyEmit pAssemEmit, mdToken tkParent)
        {
            mdMemberRef pmr;
            TryDefineImportMember(pAssemImport, pbHashValue, cbHashValue, pImport, mbMember, pAssemEmit, tkParent, out pmr).ThrowOnNotOK();

            return pmr;
        }

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
        public HRESULT TryDefineImportMember(IMetaDataAssemblyImport pAssemImport, IntPtr pbHashValue, int cbHashValue, IMetaDataImport pImport, mdToken mbMember, IMetaDataAssemblyEmit pAssemEmit, mdToken tkParent, out mdMemberRef pmr)
        {
            /*HRESULT DefineImportMember(
            [In, MarshalAs(UnmanagedType.Interface)] IMetaDataAssemblyImport pAssemImport,
            [In] IntPtr pbHashValue,
            [In] int cbHashValue,
            [In, MarshalAs(UnmanagedType.Interface)] IMetaDataImport pImport,
            [In] mdToken mbMember,
            [In, MarshalAs(UnmanagedType.Interface)] IMetaDataAssemblyEmit pAssemEmit,
            [In] mdToken tkParent,
            [Out] out mdMemberRef pmr);*/
            return Raw.DefineImportMember(pAssemImport, pbHashValue, cbHashValue, pImport, mbMember, pAssemEmit, tkParent, out pmr);
        }

        #endregion
        #region DefineEvent

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
        /// <returns>[out] The metadata token assigned to the event.</returns>
        public mdToken DefineEvent(mdTypeDef td, string szEvent, int dwEventFlags, mdToken tkEventType, mdMethodDef mdAddOn, mdMethodDef mdRemoveOn, mdMethodDef mdFire, mdMethodDef[] rmdOtherMethods)
        {
            mdToken pmdEvent;
            TryDefineEvent(td, szEvent, dwEventFlags, tkEventType, mdAddOn, mdRemoveOn, mdFire, rmdOtherMethods, out pmdEvent).ThrowOnNotOK();

            return pmdEvent;
        }

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
        public HRESULT TryDefineEvent(mdTypeDef td, string szEvent, int dwEventFlags, mdToken tkEventType, mdMethodDef mdAddOn, mdMethodDef mdRemoveOn, mdMethodDef mdFire, mdMethodDef[] rmdOtherMethods, out mdToken pmdEvent)
        {
            /*HRESULT DefineEvent(
            [In] mdTypeDef td,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szEvent,
            [In] int dwEventFlags,
            [In] mdToken tkEventType,
            [In] mdMethodDef mdAddOn,
            [In] mdMethodDef mdRemoveOn,
            [In] mdMethodDef mdFire,
            [In, MarshalAs(UnmanagedType.LPArray)] mdMethodDef[] rmdOtherMethods,
            [Out] out mdToken pmdEvent);*/
            return Raw.DefineEvent(td, szEvent, dwEventFlags, tkEventType, mdAddOn, mdRemoveOn, mdFire, rmdOtherMethods, out pmdEvent);
        }

        #endregion
        #region SetClassLayout

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
        public void SetClassLayout(mdTypeDef td, int dwPackSize, mdToken[] rFieldOffsets, int ulClassSize)
        {
            TrySetClassLayout(td, dwPackSize, rFieldOffsets, ulClassSize).ThrowOnNotOK();
        }

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
        public HRESULT TrySetClassLayout(mdTypeDef td, int dwPackSize, mdToken[] rFieldOffsets, int ulClassSize)
        {
            /*HRESULT SetClassLayout(
            [In] mdTypeDef td,
            [In] int dwPackSize,
            [In, MarshalAs(UnmanagedType.LPArray)] mdToken[] rFieldOffsets,
            [In] int ulClassSize);*/
            return Raw.SetClassLayout(td, dwPackSize, rFieldOffsets, ulClassSize);
        }

        #endregion
        #region DeleteClassLayout

        /// <summary>
        /// Destroys the class layout metadata signature for the type represented by the specified token.
        /// </summary>
        /// <param name="td">[in] An <see cref="mdTypeDef"/> metadata token that represents the type for which the class layout will be deleted.</param>
        public void DeleteClassLayout(mdTypeDef td)
        {
            TryDeleteClassLayout(td).ThrowOnNotOK();
        }

        /// <summary>
        /// Destroys the class layout metadata signature for the type represented by the specified token.
        /// </summary>
        /// <param name="td">[in] An <see cref="mdTypeDef"/> metadata token that represents the type for which the class layout will be deleted.</param>
        public HRESULT TryDeleteClassLayout(mdTypeDef td)
        {
            /*HRESULT DeleteClassLayout(
            [In] mdTypeDef td);*/
            return Raw.DeleteClassLayout(td);
        }

        #endregion
        #region SetFieldMarshal

        /// <summary>
        /// Sets the PInvoke marshalling information for the field, method return, or method parameter referenced by the specified token.
        /// </summary>
        /// <param name="tk">[in] The token for target data item. This is either a <see cref="mdFieldDef"/> or a <see cref="mdParamDef"/> token.</param>
        /// <param name="pvNativeType">[in] The signature for unmanaged type.</param>
        /// <param name="cbNativeType">[in] The count of bytes in pvNativeType.</param>
        public void SetFieldMarshal(mdToken tk, IntPtr pvNativeType, int cbNativeType)
        {
            TrySetFieldMarshal(tk, pvNativeType, cbNativeType).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the PInvoke marshalling information for the field, method return, or method parameter referenced by the specified token.
        /// </summary>
        /// <param name="tk">[in] The token for target data item. This is either a <see cref="mdFieldDef"/> or a <see cref="mdParamDef"/> token.</param>
        /// <param name="pvNativeType">[in] The signature for unmanaged type.</param>
        /// <param name="cbNativeType">[in] The count of bytes in pvNativeType.</param>
        public HRESULT TrySetFieldMarshal(mdToken tk, IntPtr pvNativeType, int cbNativeType)
        {
            /*HRESULT SetFieldMarshal(
            [In] mdToken tk,
            [In] IntPtr pvNativeType,
            [In] int cbNativeType);*/
            return Raw.SetFieldMarshal(tk, pvNativeType, cbNativeType);
        }

        #endregion
        #region DeleteFieldMarshal

        /// <summary>
        /// Destroys the PInvoke marshalling metadata signature for the object referenced by the specified token.
        /// </summary>
        /// <param name="tk">[in] An <see cref="mdFieldDef"/> or <see cref="mdParamDef"/> token that represents the field or parameter for which to delete the marshalling metadata signature.</param>
        public void DeleteFieldMarshal(mdToken tk)
        {
            TryDeleteFieldMarshal(tk).ThrowOnNotOK();
        }

        /// <summary>
        /// Destroys the PInvoke marshalling metadata signature for the object referenced by the specified token.
        /// </summary>
        /// <param name="tk">[in] An <see cref="mdFieldDef"/> or <see cref="mdParamDef"/> token that represents the field or parameter for which to delete the marshalling metadata signature.</param>
        public HRESULT TryDeleteFieldMarshal(mdToken tk)
        {
            /*HRESULT DeleteFieldMarshal(
            [In] mdToken tk);*/
            return Raw.DeleteFieldMarshal(tk);
        }

        #endregion
        #region DefinePermissionSet

        /// <summary>
        /// Creates a definition for a permission set with the specified metadata signature, and gets a token to that permission set definition.
        /// </summary>
        /// <param name="tk">[in] The object to be decorated.</param>
        /// <param name="dwAction">[in] A <see cref="CorDeclSecurity"/> value that specifies the type of declarative security to be used.</param>
        /// <param name="pvPermission">[in] The permission BLOB.</param>
        /// <param name="cbPermission">[in] The size, in bytes, of pvPermission.</param>
        /// <returns>[out] The returned permission token.</returns>
        public mdPermission DefinePermissionSet(mdToken tk, CorDeclSecurity dwAction, IntPtr pvPermission, int cbPermission)
        {
            mdPermission ppm;
            TryDefinePermissionSet(tk, dwAction, pvPermission, cbPermission, out ppm).ThrowOnNotOK();

            return ppm;
        }

        /// <summary>
        /// Creates a definition for a permission set with the specified metadata signature, and gets a token to that permission set definition.
        /// </summary>
        /// <param name="tk">[in] The object to be decorated.</param>
        /// <param name="dwAction">[in] A <see cref="CorDeclSecurity"/> value that specifies the type of declarative security to be used.</param>
        /// <param name="pvPermission">[in] The permission BLOB.</param>
        /// <param name="cbPermission">[in] The size, in bytes, of pvPermission.</param>
        /// <param name="ppm">[out] The returned permission token.</param>
        public HRESULT TryDefinePermissionSet(mdToken tk, CorDeclSecurity dwAction, IntPtr pvPermission, int cbPermission, out mdPermission ppm)
        {
            /*HRESULT DefinePermissionSet(
            [In] mdToken tk,
            [In] CorDeclSecurity dwAction,
            [In] IntPtr pvPermission,
            [In] int cbPermission,
            [Out] out mdPermission ppm);*/
            return Raw.DefinePermissionSet(tk, dwAction, pvPermission, cbPermission, out ppm);
        }

        #endregion
        #region SetRVA

        /// <summary>
        /// Sets the relative virtual address of the specified method.
        /// </summary>
        /// <param name="md">[in] The token for the target method or method implementation.</param>
        /// <param name="ulRVA">[in] The address of the code or data area.</param>
        public void SetRVA(mdMethodDef md, int ulRVA)
        {
            TrySetRVA(md, ulRVA).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the relative virtual address of the specified method.
        /// </summary>
        /// <param name="md">[in] The token for the target method or method implementation.</param>
        /// <param name="ulRVA">[in] The address of the code or data area.</param>
        public HRESULT TrySetRVA(mdMethodDef md, int ulRVA)
        {
            /*HRESULT SetRVA(
            [In] mdMethodDef md,
            [In] int ulRVA);*/
            return Raw.SetRVA(md, ulRVA);
        }

        #endregion
        #region GetTokenFromSig

        /// <summary>
        /// Gets a token for the specified metadata signature.
        /// </summary>
        /// <param name="pvSig">[in] The signature to be persisted and stored.</param>
        /// <param name="cbSig">[in] The count of bytes in pvSig.</param>
        /// <returns>[out] The <see cref="mdSignature"/> token assigned.</returns>
        public mdSignature GetTokenFromSig(IntPtr pvSig, int cbSig)
        {
            mdSignature pmsig;
            TryGetTokenFromSig(pvSig, cbSig, out pmsig).ThrowOnNotOK();

            return pmsig;
        }

        /// <summary>
        /// Gets a token for the specified metadata signature.
        /// </summary>
        /// <param name="pvSig">[in] The signature to be persisted and stored.</param>
        /// <param name="cbSig">[in] The count of bytes in pvSig.</param>
        /// <param name="pmsig">[out] The <see cref="mdSignature"/> token assigned.</param>
        public HRESULT TryGetTokenFromSig(IntPtr pvSig, int cbSig, out mdSignature pmsig)
        {
            /*HRESULT GetTokenFromSig(
            [In] IntPtr pvSig,
            [In] int cbSig,
            [Out] out mdSignature pmsig);*/
            return Raw.GetTokenFromSig(pvSig, cbSig, out pmsig);
        }

        #endregion
        #region DefineModuleRef

        /// <summary>
        /// Creates the metadata signature for a module with the specified name.
        /// </summary>
        /// <param name="szName">[in] The name of the other metadata file, typically a DLL. This is the file name only. Do not use a full path name.</param>
        /// <returns>[out] The assigned <see cref="mdModuleRef"/> token.</returns>
        public mdModuleRef DefineModuleRef(string szName)
        {
            mdModuleRef pmur;
            TryDefineModuleRef(szName, out pmur).ThrowOnNotOK();

            return pmur;
        }

        /// <summary>
        /// Creates the metadata signature for a module with the specified name.
        /// </summary>
        /// <param name="szName">[in] The name of the other metadata file, typically a DLL. This is the file name only. Do not use a full path name.</param>
        /// <param name="pmur">[out] The assigned <see cref="mdModuleRef"/> token.</param>
        public HRESULT TryDefineModuleRef(string szName, out mdModuleRef pmur)
        {
            /*HRESULT DefineModuleRef(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [Out] out mdModuleRef pmur);*/
            return Raw.DefineModuleRef(szName, out pmur);
        }

        #endregion
        #region SetParent

        /// <summary>
        /// Establishes that the specified member, as defined by a prior call to <see cref="DefineMemberRef"/>, is a member of the specified type, as defined by a prior call to <see cref="DefineTypeDef"/>.
        /// </summary>
        /// <param name="mr">[in] The <see cref="mdMemberRef"/> token to receive a new parent.</param>
        /// <param name="tk">[in] The <see cref="mdToken"/> for the new parent.</param>
        public void SetParent(mdMemberRef mr, mdToken tk)
        {
            TrySetParent(mr, tk).ThrowOnNotOK();
        }

        /// <summary>
        /// Establishes that the specified member, as defined by a prior call to <see cref="DefineMemberRef"/>, is a member of the specified type, as defined by a prior call to <see cref="DefineTypeDef"/>.
        /// </summary>
        /// <param name="mr">[in] The <see cref="mdMemberRef"/> token to receive a new parent.</param>
        /// <param name="tk">[in] The <see cref="mdToken"/> for the new parent.</param>
        public HRESULT TrySetParent(mdMemberRef mr, mdToken tk)
        {
            /*HRESULT SetParent(
            [In] mdMemberRef mr,
            [In] mdToken tk);*/
            return Raw.SetParent(mr, tk);
        }

        #endregion
        #region GetTokenFromTypeSpec

        /// <summary>
        /// Gets a metadata token for the type with the specified metadata signature.
        /// </summary>
        /// <param name="pvSig">[in] The signature being defined.</param>
        /// <param name="cbSig">[in] The count of bytes in pvSig.</param>
        /// <returns>[out] The <see cref="mdTypeSpec"/> token assigned.</returns>
        public mdTypeSpec GetTokenFromTypeSpec(IntPtr pvSig, int cbSig)
        {
            mdTypeSpec ptypespec;
            TryGetTokenFromTypeSpec(pvSig, cbSig, out ptypespec).ThrowOnNotOK();

            return ptypespec;
        }

        /// <summary>
        /// Gets a metadata token for the type with the specified metadata signature.
        /// </summary>
        /// <param name="pvSig">[in] The signature being defined.</param>
        /// <param name="cbSig">[in] The count of bytes in pvSig.</param>
        /// <param name="ptypespec">[out] The <see cref="mdTypeSpec"/> token assigned.</param>
        public HRESULT TryGetTokenFromTypeSpec(IntPtr pvSig, int cbSig, out mdTypeSpec ptypespec)
        {
            /*HRESULT GetTokenFromTypeSpec(
            [In] IntPtr pvSig,
            [In] int cbSig,
            [Out] out mdTypeSpec ptypespec);*/
            return Raw.GetTokenFromTypeSpec(pvSig, cbSig, out ptypespec);
        }

        #endregion
        #region SaveToMemory

        /// <summary>
        /// Saves all metadata in the current scope to the specified area of memory.
        /// </summary>
        /// <param name="pbData">[out] The address at which to begin writing metadata.</param>
        /// <param name="cbData">[in] The size, in bytes, of the allocated memory.</param>
        public void SaveToMemory(IntPtr pbData, int cbData)
        {
            TrySaveToMemory(pbData, cbData).ThrowOnNotOK();
        }

        /// <summary>
        /// Saves all metadata in the current scope to the specified area of memory.
        /// </summary>
        /// <param name="pbData">[out] The address at which to begin writing metadata.</param>
        /// <param name="cbData">[in] The size, in bytes, of the allocated memory.</param>
        public HRESULT TrySaveToMemory(IntPtr pbData, int cbData)
        {
            /*HRESULT SaveToMemory(
            [In] IntPtr pbData,
            [In] int cbData);*/
            return Raw.SaveToMemory(pbData, cbData);
        }

        #endregion
        #region DefineUserString

        /// <summary>
        /// Gets a metadata token for the specified literal string.
        /// </summary>
        /// <param name="szString">[in] The user string to store.</param>
        /// <param name="cchString">[in] The count of wide characters in szString.</param>
        /// <returns>[out] The string token assigned.</returns>
        public mdString DefineUserString(string szString, int cchString)
        {
            mdString pstk;
            TryDefineUserString(szString, cchString, out pstk).ThrowOnNotOK();

            return pstk;
        }

        /// <summary>
        /// Gets a metadata token for the specified literal string.
        /// </summary>
        /// <param name="szString">[in] The user string to store.</param>
        /// <param name="cchString">[in] The count of wide characters in szString.</param>
        /// <param name="pstk">[out] The string token assigned.</param>
        public HRESULT TryDefineUserString(string szString, int cchString, out mdString pstk)
        {
            /*HRESULT DefineUserString(
            [In, MarshalAs(UnmanagedType.LPWStr, SizeParamIndex = 1)] string szString,
            [In] int cchString,
            [Out] out mdString pstk);*/
            return Raw.DefineUserString(szString, cchString, out pstk);
        }

        #endregion
        #region DeleteToken

        /// <summary>
        /// Deletes the specified token from the current metadata scope.
        /// </summary>
        /// <param name="tkObj">[in] The token to be deleted.</param>
        public void DeleteToken(mdToken tkObj)
        {
            TryDeleteToken(tkObj).ThrowOnNotOK();
        }

        /// <summary>
        /// Deletes the specified token from the current metadata scope.
        /// </summary>
        /// <param name="tkObj">[in] The token to be deleted.</param>
        public HRESULT TryDeleteToken(mdToken tkObj)
        {
            /*HRESULT DeleteToken(
            [In] mdToken tkObj);*/
            return Raw.DeleteToken(tkObj);
        }

        #endregion
        #region SetMethodProps

        /// <summary>
        /// Sets or updates the feature, stored at the specified relative virtual address, of a method defined by a prior call to <see cref="DefineMethod"/>.
        /// </summary>
        /// <param name="md">[in] The token for the method to be changed.</param>
        /// <param name="dwMethodFlags">[in] The member attributes.</param>
        /// <param name="ulCodeRVA">[in] The address of the code.</param>
        /// <param name="dwImplFlags">[in] The implementation flags for the method.</param>
        public void SetMethodProps(mdMethodDef md, int dwMethodFlags, int ulCodeRVA, int dwImplFlags)
        {
            TrySetMethodProps(md, dwMethodFlags, ulCodeRVA, dwImplFlags).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets or updates the feature, stored at the specified relative virtual address, of a method defined by a prior call to <see cref="DefineMethod"/>.
        /// </summary>
        /// <param name="md">[in] The token for the method to be changed.</param>
        /// <param name="dwMethodFlags">[in] The member attributes.</param>
        /// <param name="ulCodeRVA">[in] The address of the code.</param>
        /// <param name="dwImplFlags">[in] The implementation flags for the method.</param>
        public HRESULT TrySetMethodProps(mdMethodDef md, int dwMethodFlags, int ulCodeRVA, int dwImplFlags)
        {
            /*HRESULT SetMethodProps(
            [In] mdMethodDef md,
            [In] int dwMethodFlags,
            [In] int ulCodeRVA,
            [In] int dwImplFlags);*/
            return Raw.SetMethodProps(md, dwMethodFlags, ulCodeRVA, dwImplFlags);
        }

        #endregion
        #region SetTypeDefProps

        /// <summary>
        /// Sets features of a type defined by a prior call to <see cref="DefineTypeDef"/>.
        /// </summary>
        /// <param name="td">[in] An <see cref="mdTypeDef"/> token obtained from original call to <see cref="DefineTypeDef"/>.</param>
        /// <param name="dwTypeDefFlags">[in] TypeDef attributes. This is a bitmask of <see cref="CorTypeAttr"/> values.</param>
        /// <param name="tkExtends">[in] The <see cref="mdToken"/> of the base class. Obtained from a previous call to <see cref="DefineImportType"/>, or null.</param>
        /// <param name="rtkImplements">[in] An array of tokens for the interfaces that this type implements. These <see cref="mdTypeRef"/> tokens are obtained using <see cref="DefineImportType"/>.<para/>
        /// The last element of the array is must be mdTokenNil.</param>
        public void SetTypeDefProps(mdTypeDef td, CorTypeAttr dwTypeDefFlags, mdToken tkExtends, mdToken[] rtkImplements)
        {
            TrySetTypeDefProps(td, dwTypeDefFlags, tkExtends, rtkImplements).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets features of a type defined by a prior call to <see cref="DefineTypeDef"/>.
        /// </summary>
        /// <param name="td">[in] An <see cref="mdTypeDef"/> token obtained from original call to <see cref="DefineTypeDef"/>.</param>
        /// <param name="dwTypeDefFlags">[in] TypeDef attributes. This is a bitmask of <see cref="CorTypeAttr"/> values.</param>
        /// <param name="tkExtends">[in] The <see cref="mdToken"/> of the base class. Obtained from a previous call to <see cref="DefineImportType"/>, or null.</param>
        /// <param name="rtkImplements">[in] An array of tokens for the interfaces that this type implements. These <see cref="mdTypeRef"/> tokens are obtained using <see cref="DefineImportType"/>.<para/>
        /// The last element of the array is must be mdTokenNil.</param>
        public HRESULT TrySetTypeDefProps(mdTypeDef td, CorTypeAttr dwTypeDefFlags, mdToken tkExtends, mdToken[] rtkImplements)
        {
            /*HRESULT SetTypeDefProps(
            [In] mdTypeDef td,
            [In] CorTypeAttr dwTypeDefFlags,
            [In] mdToken tkExtends,
            [In, MarshalAs(UnmanagedType.LPArray)] mdToken[] rtkImplements);*/
            return Raw.SetTypeDefProps(td, dwTypeDefFlags, tkExtends, rtkImplements);
        }

        #endregion
        #region SetEventProps

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
        public void SetEventProps(mdEvent ev, CorEventAttr dwEventFlags, mdToken tkEventType, mdMethodDef mdAddOn, mdMethodDef mdRemoveOn, mdMethodDef mdFire, mdMethodDef[] rmdOtherMethods)
        {
            TrySetEventProps(ev, dwEventFlags, tkEventType, mdAddOn, mdRemoveOn, mdFire, rmdOtherMethods).ThrowOnNotOK();
        }

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
        public HRESULT TrySetEventProps(mdEvent ev, CorEventAttr dwEventFlags, mdToken tkEventType, mdMethodDef mdAddOn, mdMethodDef mdRemoveOn, mdMethodDef mdFire, mdMethodDef[] rmdOtherMethods)
        {
            /*HRESULT SetEventProps(
            [In] mdEvent ev,
            [In] CorEventAttr dwEventFlags,
            [In] mdToken tkEventType,
            [In] mdMethodDef mdAddOn,
            [In] mdMethodDef mdRemoveOn,
            [In] mdMethodDef mdFire,
            [In, MarshalAs(UnmanagedType.LPArray)] mdMethodDef[] rmdOtherMethods);*/
            return Raw.SetEventProps(ev, dwEventFlags, tkEventType, mdAddOn, mdRemoveOn, mdFire, rmdOtherMethods);
        }

        #endregion
        #region SetPermissionSetProps

        /// <summary>
        /// Sets or updates features of the metadata signature of a permission set defined by a prior call to <see cref="DefinePermissionSet"/>.
        /// </summary>
        /// <param name="tk">[in] A metadata token that represents the object to be decorated.</param>
        /// <param name="dwAction">[in] A <see cref="CorDeclSecurity"/> value that specifies the type of declarative security to be used.</param>
        /// <param name="pvPermission">[in] The permission BLOB.</param>
        /// <param name="cbPermission">[in] The size, in bytes, of pvPermission.</param>
        /// <returns>[out] An <see cref="mdPermission"/> metadata token that represents the updated permissions.</returns>
        public mdPermission SetPermissionSetProps(mdToken tk, CorDeclSecurity dwAction, IntPtr pvPermission, int cbPermission)
        {
            mdPermission ppm;
            TrySetPermissionSetProps(tk, dwAction, pvPermission, cbPermission, out ppm).ThrowOnNotOK();

            return ppm;
        }

        /// <summary>
        /// Sets or updates features of the metadata signature of a permission set defined by a prior call to <see cref="DefinePermissionSet"/>.
        /// </summary>
        /// <param name="tk">[in] A metadata token that represents the object to be decorated.</param>
        /// <param name="dwAction">[in] A <see cref="CorDeclSecurity"/> value that specifies the type of declarative security to be used.</param>
        /// <param name="pvPermission">[in] The permission BLOB.</param>
        /// <param name="cbPermission">[in] The size, in bytes, of pvPermission.</param>
        /// <param name="ppm">[out] An <see cref="mdPermission"/> metadata token that represents the updated permissions.</param>
        public HRESULT TrySetPermissionSetProps(mdToken tk, CorDeclSecurity dwAction, IntPtr pvPermission, int cbPermission, out mdPermission ppm)
        {
            /*HRESULT SetPermissionSetProps(
            [In] mdToken tk,
            [In] CorDeclSecurity dwAction,
            [In] IntPtr pvPermission,
            [In] int cbPermission,
            [Out] out mdPermission ppm);*/
            return Raw.SetPermissionSetProps(tk, dwAction, pvPermission, cbPermission, out ppm);
        }

        #endregion
        #region DefinePinvokeMap

        /// <summary>
        /// Sets features of the PInvoke signature of the method referenced by the specified token.
        /// </summary>
        /// <param name="tk">[in] The token for the target method.</param>
        /// <param name="dwMappingFlags">[in] Flags used by PInvoke to do the mapping.</param>
        /// <param name="szImportName">[in] The name of the target export method in an unmanaged DLL.</param>
        /// <param name="mrImportDLL">[in] The token for the target native DLL.</param>
        public void DefinePinvokeMap(mdToken tk, int dwMappingFlags, string szImportName, mdModuleRef mrImportDLL)
        {
            TryDefinePinvokeMap(tk, dwMappingFlags, szImportName, mrImportDLL).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets features of the PInvoke signature of the method referenced by the specified token.
        /// </summary>
        /// <param name="tk">[in] The token for the target method.</param>
        /// <param name="dwMappingFlags">[in] Flags used by PInvoke to do the mapping.</param>
        /// <param name="szImportName">[in] The name of the target export method in an unmanaged DLL.</param>
        /// <param name="mrImportDLL">[in] The token for the target native DLL.</param>
        public HRESULT TryDefinePinvokeMap(mdToken tk, int dwMappingFlags, string szImportName, mdModuleRef mrImportDLL)
        {
            /*HRESULT DefinePinvokeMap(
            [In] mdToken tk,
            [In] int dwMappingFlags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szImportName,
            [In] mdModuleRef mrImportDLL);*/
            return Raw.DefinePinvokeMap(tk, dwMappingFlags, szImportName, mrImportDLL);
        }

        #endregion
        #region SetPinvokeMap

        /// <summary>
        /// Sets or changes features of a method's PInvoke signature, as defined by a prior call to <see cref="DefinePinvokeMap"/>.
        /// </summary>
        /// <param name="tk">[in] The <see cref="mdToken"/> to which mapping information applies.</param>
        /// <param name="dwMappingFlags">[in] Flags used by PInvoke to do the mapping. This is a bitmask of <see cref="CorPinvokeMap"/> values.</param>
        /// <param name="szImportName">[in] The name of the target export in the native DLL.</param>
        /// <param name="mrImportDLL">[in] The <see cref="mdModuleRef"/> token for the target unmanaged DLL.</param>
        public void SetPinvokeMap(mdToken tk, CorPinvokeMap dwMappingFlags, string szImportName, mdModuleRef mrImportDLL)
        {
            TrySetPinvokeMap(tk, dwMappingFlags, szImportName, mrImportDLL).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets or changes features of a method's PInvoke signature, as defined by a prior call to <see cref="DefinePinvokeMap"/>.
        /// </summary>
        /// <param name="tk">[in] The <see cref="mdToken"/> to which mapping information applies.</param>
        /// <param name="dwMappingFlags">[in] Flags used by PInvoke to do the mapping. This is a bitmask of <see cref="CorPinvokeMap"/> values.</param>
        /// <param name="szImportName">[in] The name of the target export in the native DLL.</param>
        /// <param name="mrImportDLL">[in] The <see cref="mdModuleRef"/> token for the target unmanaged DLL.</param>
        public HRESULT TrySetPinvokeMap(mdToken tk, CorPinvokeMap dwMappingFlags, string szImportName, mdModuleRef mrImportDLL)
        {
            /*HRESULT SetPinvokeMap(
            [In] mdToken tk,
            [In] CorPinvokeMap dwMappingFlags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szImportName,
            [In] mdModuleRef mrImportDLL);*/
            return Raw.SetPinvokeMap(tk, dwMappingFlags, szImportName, mrImportDLL);
        }

        #endregion
        #region DeletePinvokeMap

        /// <summary>
        /// Destroys the PInvoke mapping metadata for the object referenced by the specified token.
        /// </summary>
        /// <param name="tk">[in] An <see cref="mdFieldDef"/> or <see cref="mdMethodDef"/> token that represents the object for which to delete the PInvoke mapping metadata.</param>
        public void DeletePinvokeMap(mdToken tk)
        {
            TryDeletePinvokeMap(tk).ThrowOnNotOK();
        }

        /// <summary>
        /// Destroys the PInvoke mapping metadata for the object referenced by the specified token.
        /// </summary>
        /// <param name="tk">[in] An <see cref="mdFieldDef"/> or <see cref="mdMethodDef"/> token that represents the object for which to delete the PInvoke mapping metadata.</param>
        public HRESULT TryDeletePinvokeMap(mdToken tk)
        {
            /*HRESULT DeletePinvokeMap(
            [In] mdToken tk);*/
            return Raw.DeletePinvokeMap(tk);
        }

        #endregion
        #region DefineCustomAttribute

        /// <summary>
        /// Creates a definition for a custom attribute with the specified metadata signature, to be attached to the specified object, and gets a token to that custom attribute definition.
        /// </summary>
        /// <param name="tkObj">[in] The token for the owner item.</param>
        /// <param name="tkType">[in] The token that identifies the custom attribute.</param>
        /// <param name="pCustomAttribute">[in] A pointer to the custom attribute.</param>
        /// <param name="cbCustomAttribute">[in] The count of bytes in pCustomAttribute.</param>
        /// <returns>[out] The <see cref="mdCustomAttribute"/> token assigned.</returns>
        public mdCustomAttribute DefineCustomAttribute(mdToken tkObj, mdToken tkType, byte[] pCustomAttribute, int cbCustomAttribute)
        {
            mdCustomAttribute pcv;
            TryDefineCustomAttribute(tkObj, tkType, pCustomAttribute, cbCustomAttribute, out pcv).ThrowOnNotOK();

            return pcv;
        }

        /// <summary>
        /// Creates a definition for a custom attribute with the specified metadata signature, to be attached to the specified object, and gets a token to that custom attribute definition.
        /// </summary>
        /// <param name="tkObj">[in] The token for the owner item.</param>
        /// <param name="tkType">[in] The token that identifies the custom attribute.</param>
        /// <param name="pCustomAttribute">[in] A pointer to the custom attribute.</param>
        /// <param name="cbCustomAttribute">[in] The count of bytes in pCustomAttribute.</param>
        /// <param name="pcv">[out] The <see cref="mdCustomAttribute"/> token assigned.</param>
        public HRESULT TryDefineCustomAttribute(mdToken tkObj, mdToken tkType, byte[] pCustomAttribute, int cbCustomAttribute, out mdCustomAttribute pcv)
        {
            /*HRESULT DefineCustomAttribute(
            [In] mdToken tkObj,
            [In] mdToken tkType,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pCustomAttribute,
            [In] int cbCustomAttribute,
            [Out] out mdCustomAttribute pcv);*/
            return Raw.DefineCustomAttribute(tkObj, tkType, pCustomAttribute, cbCustomAttribute, out pcv);
        }

        #endregion
        #region SetCustomAttributeValue

        /// <summary>
        /// Sets or updates the value of a custom attribute defined by a prior call to <see cref="DefineCustomAttribute"/>.
        /// </summary>
        /// <param name="pcv">[in] The token of the target custom attribute.</param>
        /// <param name="pCustomAttribute">[in] A pointer to the array that contains the custom attribute.</param>
        /// <param name="cbCustomAttribute">[in] The size, in bytes, of the custom attribute.</param>
        public void SetCustomAttributeValue(int pcv, byte[] pCustomAttribute, int cbCustomAttribute)
        {
            TrySetCustomAttributeValue(pcv, pCustomAttribute, cbCustomAttribute).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets or updates the value of a custom attribute defined by a prior call to <see cref="DefineCustomAttribute"/>.
        /// </summary>
        /// <param name="pcv">[in] The token of the target custom attribute.</param>
        /// <param name="pCustomAttribute">[in] A pointer to the array that contains the custom attribute.</param>
        /// <param name="cbCustomAttribute">[in] The size, in bytes, of the custom attribute.</param>
        public HRESULT TrySetCustomAttributeValue(int pcv, byte[] pCustomAttribute, int cbCustomAttribute)
        {
            /*HRESULT SetCustomAttributeValue(
            [In] int pcv,
            [In, MarshalAs(UnmanagedType.LPArray)] byte[] pCustomAttribute,
            [In] int cbCustomAttribute);*/
            return Raw.SetCustomAttributeValue(pcv, pCustomAttribute, cbCustomAttribute);
        }

        #endregion
        #region DefineField

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
        /// <returns>[out] The <see cref="mdFieldDef"/> token assigned.</returns>
        public mdFieldDef DefineField(mdTypeDef td, string szName, CorFieldAttr dwFieldFlags, IntPtr pvSigBlob, int cbSigBlob, CorElementType dwCPlusTypeFlag, IntPtr pValue, int cchValue)
        {
            mdFieldDef pmd;
            TryDefineField(td, szName, dwFieldFlags, pvSigBlob, cbSigBlob, dwCPlusTypeFlag, pValue, cchValue, out pmd).ThrowOnNotOK();

            return pmd;
        }

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
        public HRESULT TryDefineField(mdTypeDef td, string szName, CorFieldAttr dwFieldFlags, IntPtr pvSigBlob, int cbSigBlob, CorElementType dwCPlusTypeFlag, IntPtr pValue, int cchValue, out mdFieldDef pmd)
        {
            /*HRESULT DefineField(
            [In] mdTypeDef td,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [In] CorFieldAttr dwFieldFlags,
            [In] IntPtr pvSigBlob,
            [In] int cbSigBlob,
            [In] CorElementType dwCPlusTypeFlag,
            [In] IntPtr pValue,
            [In] int cchValue,
            [Out] out mdFieldDef pmd);*/
            return Raw.DefineField(td, szName, dwFieldFlags, pvSigBlob, cbSigBlob, dwCPlusTypeFlag, pValue, cchValue, out pmd);
        }

        #endregion
        #region DefineProperty

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
        /// <returns>[out] The <see cref="mdProperty"/> token assigned.</returns>
        public mdProperty DefineProperty(mdTypeDef td, string szProperty, CorPropertyAttr dwPropFlags, IntPtr pvSig, int cbSig, int dwCPlusTypeFlag, IntPtr cvalue, int cchValue, mdMethodDef mdSetter, mdMethodDef mdGetter, mdToken[] rmdOtherMethods)
        {
            mdProperty pmdProp;
            TryDefineProperty(td, szProperty, dwPropFlags, pvSig, cbSig, dwCPlusTypeFlag, cvalue, cchValue, mdSetter, mdGetter, rmdOtherMethods, out pmdProp).ThrowOnNotOK();

            return pmdProp;
        }

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
        public HRESULT TryDefineProperty(mdTypeDef td, string szProperty, CorPropertyAttr dwPropFlags, IntPtr pvSig, int cbSig, int dwCPlusTypeFlag, IntPtr cvalue, int cchValue, mdMethodDef mdSetter, mdMethodDef mdGetter, mdToken[] rmdOtherMethods, out mdProperty pmdProp)
        {
            /*HRESULT DefineProperty(
            [In] mdTypeDef td,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szProperty,
            [In] CorPropertyAttr dwPropFlags,
            [In] IntPtr pvSig,
            [In] int cbSig,
            [In] int dwCPlusTypeFlag,
            [In] IntPtr cvalue,
            [In] int cchValue,
            [In] mdMethodDef mdSetter,
            [In] mdMethodDef mdGetter,
            [In, MarshalAs(UnmanagedType.LPArray)] mdToken[] rmdOtherMethods,
            [Out] out mdProperty pmdProp);*/
            return Raw.DefineProperty(td, szProperty, dwPropFlags, pvSig, cbSig, dwCPlusTypeFlag, cvalue, cchValue, mdSetter, mdGetter, rmdOtherMethods, out pmdProp);
        }

        #endregion
        #region DefineParam

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
        /// <returns>[out] The <see cref="mdParamDef"/> token assigned.</returns>
        /// <remarks>
        /// The sequence values in ulParamSeq begin with 1 for parameters. A return value has a sequence number of 0.
        /// </remarks>
        public mdParamDef DefineParam(mdMethodDef md, int ulParamSeq, string szName, CorParamAttr dwParamFlags, CorElementType dwCPlusTypeFlag, IntPtr pValue, int cchValue)
        {
            mdParamDef ppd;
            TryDefineParam(md, ulParamSeq, szName, dwParamFlags, dwCPlusTypeFlag, pValue, cchValue, out ppd).ThrowOnNotOK();

            return ppd;
        }

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
        public HRESULT TryDefineParam(mdMethodDef md, int ulParamSeq, string szName, CorParamAttr dwParamFlags, CorElementType dwCPlusTypeFlag, IntPtr pValue, int cchValue, out mdParamDef ppd)
        {
            /*HRESULT DefineParam(
            [In] mdMethodDef md,
            [In] int ulParamSeq,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [In] CorParamAttr dwParamFlags,
            [In] CorElementType dwCPlusTypeFlag,
            [In] IntPtr pValue,
            [In] int cchValue,
            [Out] out mdParamDef ppd);*/
            return Raw.DefineParam(md, ulParamSeq, szName, dwParamFlags, dwCPlusTypeFlag, pValue, cchValue, out ppd);
        }

        #endregion
        #region SetFieldProps

        /// <summary>
        /// Sets or updates the default value for the field referenced by the specified field token.
        /// </summary>
        /// <param name="fd">[in] The token for the target field.</param>
        /// <param name="dwFieldFlags">[in] Field attributes. This is a bitmask of <see cref="CorFieldAttr"/> values.</param>
        /// <param name="dwCPlusTypeFlag">[in] The ELEMENT_TYPE_* for the constant value. This is a <see cref="CorElementType"/> value. If a constant is not being defined, set this value to ELEMENT_TYPE_END.</param>
        /// <param name="pValue">[in] The constant value for the field.</param>
        /// <param name="cchValue">[in] The size, in Unicode characters, of pValue.</param>
        public void SetFieldProps(mdFieldDef fd, CorFieldAttr dwFieldFlags, CorElementType dwCPlusTypeFlag, IntPtr pValue, int cchValue)
        {
            TrySetFieldProps(fd, dwFieldFlags, dwCPlusTypeFlag, pValue, cchValue).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets or updates the default value for the field referenced by the specified field token.
        /// </summary>
        /// <param name="fd">[in] The token for the target field.</param>
        /// <param name="dwFieldFlags">[in] Field attributes. This is a bitmask of <see cref="CorFieldAttr"/> values.</param>
        /// <param name="dwCPlusTypeFlag">[in] The ELEMENT_TYPE_* for the constant value. This is a <see cref="CorElementType"/> value. If a constant is not being defined, set this value to ELEMENT_TYPE_END.</param>
        /// <param name="pValue">[in] The constant value for the field.</param>
        /// <param name="cchValue">[in] The size, in Unicode characters, of pValue.</param>
        public HRESULT TrySetFieldProps(mdFieldDef fd, CorFieldAttr dwFieldFlags, CorElementType dwCPlusTypeFlag, IntPtr pValue, int cchValue)
        {
            /*HRESULT SetFieldProps(
            [In] mdFieldDef fd,
            [In] CorFieldAttr dwFieldFlags,
            [In] CorElementType dwCPlusTypeFlag,
            [In] IntPtr pValue,
            [In] int cchValue);*/
            return Raw.SetFieldProps(fd, dwFieldFlags, dwCPlusTypeFlag, pValue, cchValue);
        }

        #endregion
        #region SetPropertyProps

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
        public void SetPropertyProps(mdProperty pr, CorPropertyAttr dwPropFlags, int dwCPlusTypeFlag, IntPtr pValue, int cchValue, mdMethodDef mdSetter, mdMethodDef mdGetter, mdToken[] rmdOtherMethods)
        {
            TrySetPropertyProps(pr, dwPropFlags, dwCPlusTypeFlag, pValue, cchValue, mdSetter, mdGetter, rmdOtherMethods).ThrowOnNotOK();
        }

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
        public HRESULT TrySetPropertyProps(mdProperty pr, CorPropertyAttr dwPropFlags, int dwCPlusTypeFlag, IntPtr pValue, int cchValue, mdMethodDef mdSetter, mdMethodDef mdGetter, mdToken[] rmdOtherMethods)
        {
            /*HRESULT SetPropertyProps(
            [In] mdProperty pr,
            [In] CorPropertyAttr dwPropFlags,
            [In] int dwCPlusTypeFlag,
            [In] IntPtr pValue,
            [In] int cchValue,
            [In] mdMethodDef mdSetter,
            [In] mdMethodDef mdGetter,
            [In, MarshalAs(UnmanagedType.LPArray)] mdToken[] rmdOtherMethods);*/
            return Raw.SetPropertyProps(pr, dwPropFlags, dwCPlusTypeFlag, pValue, cchValue, mdSetter, mdGetter, rmdOtherMethods);
        }

        #endregion
        #region SetParamProps

        /// <summary>
        /// Sets or changes features of a method parameter that was defined by a prior call to <see cref="DefineParam"/>.
        /// </summary>
        /// <param name="pd">[in] The token for the target parameter.</param>
        /// <param name="szName">[in] The name of the parameter in Unicode.</param>
        /// <param name="dwParamFlags">[in] The flags for the parameter.</param>
        /// <param name="dwCPlusTypeFlag">[in] The ELEMENT_TYPE_* for the constant value.</param>
        /// <param name="pValue">[in] The constant value for the parameter.</param>
        /// <param name="cchValue">[in] The size in (Unicode) characters of pValue.</param>
        public void SetParamProps(mdParamDef pd, string szName, int dwParamFlags, int dwCPlusTypeFlag, IntPtr pValue, int cchValue)
        {
            TrySetParamProps(pd, szName, dwParamFlags, dwCPlusTypeFlag, pValue, cchValue).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets or changes features of a method parameter that was defined by a prior call to <see cref="DefineParam"/>.
        /// </summary>
        /// <param name="pd">[in] The token for the target parameter.</param>
        /// <param name="szName">[in] The name of the parameter in Unicode.</param>
        /// <param name="dwParamFlags">[in] The flags for the parameter.</param>
        /// <param name="dwCPlusTypeFlag">[in] The ELEMENT_TYPE_* for the constant value.</param>
        /// <param name="pValue">[in] The constant value for the parameter.</param>
        /// <param name="cchValue">[in] The size in (Unicode) characters of pValue.</param>
        public HRESULT TrySetParamProps(mdParamDef pd, string szName, int dwParamFlags, int dwCPlusTypeFlag, IntPtr pValue, int cchValue)
        {
            /*HRESULT SetParamProps(
            [In] mdParamDef pd,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [In] int dwParamFlags,
            [In] int dwCPlusTypeFlag,
            [In] IntPtr pValue,
            [In] int cchValue);*/
            return Raw.SetParamProps(pd, szName, dwParamFlags, dwCPlusTypeFlag, pValue, cchValue);
        }

        #endregion
        #region DefineSecurityAttributeSet

        /// <summary>
        /// Creates a set of security permissions to attach to the object referenced by the specified token.
        /// </summary>
        /// <param name="tkObj">[in] The token to which the security information is attached.</param>
        /// <param name="rSecAttrs">[in] An array of <see cref="COR_SECATTR"/> structures.</param>
        /// <param name="cSecAttrs">[in] The number of elements in rSecAttrs.</param>
        /// <returns>[out] If the method fails, specifies the index in rSecAttrs of the element that caused the problem.</returns>
        public int DefineSecurityAttributeSet(mdToken tkObj, COR_SECATTR[] rSecAttrs, int cSecAttrs)
        {
            int pulErrorAttr;
            TryDefineSecurityAttributeSet(tkObj, rSecAttrs, cSecAttrs, out pulErrorAttr).ThrowOnNotOK();

            return pulErrorAttr;
        }

        /// <summary>
        /// Creates a set of security permissions to attach to the object referenced by the specified token.
        /// </summary>
        /// <param name="tkObj">[in] The token to which the security information is attached.</param>
        /// <param name="rSecAttrs">[in] An array of <see cref="COR_SECATTR"/> structures.</param>
        /// <param name="cSecAttrs">[in] The number of elements in rSecAttrs.</param>
        /// <param name="pulErrorAttr">[out] If the method fails, specifies the index in rSecAttrs of the element that caused the problem.</param>
        public HRESULT TryDefineSecurityAttributeSet(mdToken tkObj, COR_SECATTR[] rSecAttrs, int cSecAttrs, out int pulErrorAttr)
        {
            /*HRESULT DefineSecurityAttributeSet(
            [In] mdToken tkObj,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] COR_SECATTR[] rSecAttrs,
            [In] int cSecAttrs,
            [Out] out int pulErrorAttr);*/
            return Raw.DefineSecurityAttributeSet(tkObj, rSecAttrs, cSecAttrs, out pulErrorAttr);
        }

        #endregion
        #region ApplyEditAndContinue

        /// <summary>
        /// Updates the current assembly scope with the changes made in the specified metadata.
        /// </summary>
        /// <param name="pImport">[in] Pointer to an IUnknown object that represents the delta metadata from the portable executable (PE) file. The delta metadata is the block of metadata that includes the changes that were made to the copy of the module's actual metadata.</param>
        public void ApplyEditAndContinue(IMetaDataImport pImport)
        {
            TryApplyEditAndContinue(pImport).ThrowOnNotOK();
        }

        /// <summary>
        /// Updates the current assembly scope with the changes made in the specified metadata.
        /// </summary>
        /// <param name="pImport">[in] Pointer to an IUnknown object that represents the delta metadata from the portable executable (PE) file. The delta metadata is the block of metadata that includes the changes that were made to the copy of the module's actual metadata.</param>
        public HRESULT TryApplyEditAndContinue(IMetaDataImport pImport)
        {
            /*HRESULT ApplyEditAndContinue(
            [In, MarshalAs(UnmanagedType.Interface)] IMetaDataImport pImport);*/
            return Raw.ApplyEditAndContinue(pImport);
        }

        #endregion
        #region TranslateSigWithScope

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
        /// <returns>[out] The number of actual bytes in the translated signature.</returns>
        public int TranslateSigWithScope(IMetaDataAssemblyImport pAssemImport, IntPtr pbHashValue, int cbHashValue, IMetaDataImport import, IntPtr pbSigBlob, int cbSigBlob, IMetaDataAssemblyEmit pAssemEmit, IMetaDataEmit emit, IntPtr pvTranslatedSig, int cbTranslatedSigMax)
        {
            int pcbTranslatedSig;
            TryTranslateSigWithScope(pAssemImport, pbHashValue, cbHashValue, import, pbSigBlob, cbSigBlob, pAssemEmit, emit, pvTranslatedSig, cbTranslatedSigMax, out pcbTranslatedSig).ThrowOnNotOK();

            return pcbTranslatedSig;
        }

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
        public HRESULT TryTranslateSigWithScope(IMetaDataAssemblyImport pAssemImport, IntPtr pbHashValue, int cbHashValue, IMetaDataImport import, IntPtr pbSigBlob, int cbSigBlob, IMetaDataAssemblyEmit pAssemEmit, IMetaDataEmit emit, IntPtr pvTranslatedSig, int cbTranslatedSigMax, out int pcbTranslatedSig)
        {
            /*HRESULT TranslateSigWithScope(
            [In, MarshalAs(UnmanagedType.Interface)] IMetaDataAssemblyImport pAssemImport,
            [In] IntPtr pbHashValue,
            [In] int cbHashValue,
            [In, MarshalAs(UnmanagedType.Interface)] IMetaDataImport import,
            [In] IntPtr pbSigBlob,
            [In] int cbSigBlob,
            [In, MarshalAs(UnmanagedType.Interface)] IMetaDataAssemblyEmit pAssemEmit,
            [In, MarshalAs(UnmanagedType.Interface)] IMetaDataEmit emit,
            [In] IntPtr pvTranslatedSig,
            [In] int cbTranslatedSigMax,
            [Out] out int pcbTranslatedSig);*/
            return Raw.TranslateSigWithScope(pAssemImport, pbHashValue, cbHashValue, import, pbSigBlob, cbSigBlob, pAssemEmit, emit, pvTranslatedSig, cbTranslatedSigMax, out pcbTranslatedSig);
        }

        #endregion
        #region SetMethodImplFlags

        /// <summary>
        /// Sets or updates the metadata signature of the inherited method implementation that is referenced by the specified token.
        /// </summary>
        /// <param name="md">[in] The token for the method to be changed.</param>
        /// <param name="dwImplFlags">[in] A combination of the values of the <see cref="CorMethodImpl"/> enumeration that specifies the method implementation features.</param>
        public void SetMethodImplFlags(mdMethodDef md, int dwImplFlags)
        {
            TrySetMethodImplFlags(md, dwImplFlags).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets or updates the metadata signature of the inherited method implementation that is referenced by the specified token.
        /// </summary>
        /// <param name="md">[in] The token for the method to be changed.</param>
        /// <param name="dwImplFlags">[in] A combination of the values of the <see cref="CorMethodImpl"/> enumeration that specifies the method implementation features.</param>
        public HRESULT TrySetMethodImplFlags(mdMethodDef md, int dwImplFlags)
        {
            /*HRESULT SetMethodImplFlags(
            [In] mdMethodDef md,
            [In] int dwImplFlags);*/
            return Raw.SetMethodImplFlags(md, dwImplFlags);
        }

        #endregion
        #region SetFieldRVA

        /// <summary>
        /// Sets a global variable value for the relative virtual address of the field referenced by the specified token.
        /// </summary>
        /// <param name="fd">[in] The token for the target field.</param>
        /// <param name="ulRVA">[in] The address of a code or data area.</param>
        public void SetFieldRVA(mdFieldDef fd, int ulRVA)
        {
            TrySetFieldRVA(fd, ulRVA).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets a global variable value for the relative virtual address of the field referenced by the specified token.
        /// </summary>
        /// <param name="fd">[in] The token for the target field.</param>
        /// <param name="ulRVA">[in] The address of a code or data area.</param>
        public HRESULT TrySetFieldRVA(mdFieldDef fd, int ulRVA)
        {
            /*HRESULT SetFieldRVA(
            [In] mdFieldDef fd,
            [In] int ulRVA);*/
            return Raw.SetFieldRVA(fd, ulRVA);
        }

        #endregion
        #region Merge

        /// <summary>
        /// Adds the specified imported scope to the list of scopes to be merged.
        /// </summary>
        /// <param name="pImport">[in] A pointer to an <see cref="IMetaDataImport"/> object that identifies the imported scope to be merged.</param>
        /// <param name="pHostMapToken">[in] A pointer to an <see cref="IMapToken"/> object that specifies the token re-map.</param>
        /// <param name="pHandler">[in] A pointer to an IUnknown object that specifies the errors.</param>
        /// <remarks>
        /// Call <see cref="MergeEnd"/> to trigger the merger of metadata into a single scope.
        /// </remarks>
        public void Merge(IMetaDataImport pImport, IMapToken pHostMapToken, object pHandler)
        {
            TryMerge(pImport, pHostMapToken, pHandler).ThrowOnNotOK();
        }

        /// <summary>
        /// Adds the specified imported scope to the list of scopes to be merged.
        /// </summary>
        /// <param name="pImport">[in] A pointer to an <see cref="IMetaDataImport"/> object that identifies the imported scope to be merged.</param>
        /// <param name="pHostMapToken">[in] A pointer to an <see cref="IMapToken"/> object that specifies the token re-map.</param>
        /// <param name="pHandler">[in] A pointer to an IUnknown object that specifies the errors.</param>
        /// <remarks>
        /// Call <see cref="MergeEnd"/> to trigger the merger of metadata into a single scope.
        /// </remarks>
        public HRESULT TryMerge(IMetaDataImport pImport, IMapToken pHostMapToken, object pHandler)
        {
            /*HRESULT Merge(
            [In, MarshalAs(UnmanagedType.Interface)] IMetaDataImport pImport,
            [In, MarshalAs(UnmanagedType.Interface)] IMapToken pHostMapToken,
            [In, MarshalAs(UnmanagedType.IUnknown)] object pHandler);*/
            return Raw.Merge(pImport, pHostMapToken, pHandler);
        }

        #endregion
        #region MergeEnd

        /// <summary>
        /// Merges into the current scope all the metadata scopes specified by one or more prior calls to <see cref="Merge"/>.
        /// </summary>
        /// <remarks>
        /// This routine triggers the actual merge of metadata, of all import scopes specified by preceding calls to <see cref="Merge"/>,
        /// into the current output scope. The following special conditions apply to the merge:
        /// </remarks>
        public void MergeEnd()
        {
            TryMergeEnd().ThrowOnNotOK();
        }

        /// <summary>
        /// Merges into the current scope all the metadata scopes specified by one or more prior calls to <see cref="Merge"/>.
        /// </summary>
        /// <remarks>
        /// This routine triggers the actual merge of metadata, of all import scopes specified by preceding calls to <see cref="Merge"/>,
        /// into the current output scope. The following special conditions apply to the merge:
        /// </remarks>
        public HRESULT TryMergeEnd()
        {
            /*HRESULT MergeEnd();*/
            return Raw.MergeEnd();
        }

        #endregion
        #endregion
        #region IMetaDataEmit2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IMetaDataEmit2 Raw2 => (IMetaDataEmit2) Raw;

        #region DefineMethodSpec

        /// <summary>
        /// Creates a generic instance of a method, and gets a token to the definition.
        /// </summary>
        /// <param name="tkParent">[in] A token for the method of which to create the generic instance. The token must be of type <see cref="mdMethodDef"/> or <see cref="mdMemberRef"/>.</param>
        /// <param name="pvSigBlob">[in] A pointer to the binary COM+ signature of the method.</param>
        /// <param name="cbSigBlob">[in] The size, in bytes, of pvSigBlob.</param>
        /// <returns>[out] A token to the metadata signature definition of the method.</returns>
        public mdMethodSpec DefineMethodSpec(mdToken tkParent, IntPtr pvSigBlob, int cbSigBlob)
        {
            mdMethodSpec pmi;
            TryDefineMethodSpec(tkParent, pvSigBlob, cbSigBlob, out pmi).ThrowOnNotOK();

            return pmi;
        }

        /// <summary>
        /// Creates a generic instance of a method, and gets a token to the definition.
        /// </summary>
        /// <param name="tkParent">[in] A token for the method of which to create the generic instance. The token must be of type <see cref="mdMethodDef"/> or <see cref="mdMemberRef"/>.</param>
        /// <param name="pvSigBlob">[in] A pointer to the binary COM+ signature of the method.</param>
        /// <param name="cbSigBlob">[in] The size, in bytes, of pvSigBlob.</param>
        /// <param name="pmi">[out] A token to the metadata signature definition of the method.</param>
        public HRESULT TryDefineMethodSpec(mdToken tkParent, IntPtr pvSigBlob, int cbSigBlob, out mdMethodSpec pmi)
        {
            /*HRESULT DefineMethodSpec(
            [In] mdToken tkParent,
            [In] IntPtr pvSigBlob,
            [In] int cbSigBlob,
            [Out] out mdMethodSpec pmi);*/
            return Raw2.DefineMethodSpec(tkParent, pvSigBlob, cbSigBlob, out pmi);
        }

        #endregion
        #region GetDeltaSaveSize

        /// <summary>
        /// Gets a value indicating any change in metadata size that results from the current edit-and-continue session.
        /// </summary>
        /// <param name="fSave">[in] One of the <see cref="CorSaveSize"/> values, indicating the level of precision desired. For the .NET Framework version 2.0, this parameter is ignored.</param>
        /// <returns>[out] The change in the size of the metadata.</returns>
        public int GetDeltaSaveSize(CorSaveSize fSave)
        {
            int pdwSaveSize;
            TryGetDeltaSaveSize(fSave, out pdwSaveSize).ThrowOnNotOK();

            return pdwSaveSize;
        }

        /// <summary>
        /// Gets a value indicating any change in metadata size that results from the current edit-and-continue session.
        /// </summary>
        /// <param name="fSave">[in] One of the <see cref="CorSaveSize"/> values, indicating the level of precision desired. For the .NET Framework version 2.0, this parameter is ignored.</param>
        /// <param name="pdwSaveSize">[out] The change in the size of the metadata.</param>
        public HRESULT TryGetDeltaSaveSize(CorSaveSize fSave, out int pdwSaveSize)
        {
            /*HRESULT GetDeltaSaveSize(
            [In] CorSaveSize fSave,
            [Out] out int pdwSaveSize);*/
            return Raw2.GetDeltaSaveSize(fSave, out pdwSaveSize);
        }

        #endregion
        #region SaveDelta

        /// <summary>
        /// Saves changes from the current edit-and-continue session to the specified file.
        /// </summary>
        /// <param name="szFile">[in] The file name under which to save changes.</param>
        /// <param name="dwSaveFlags">[in] Reserved. Must be zero.</param>
        public void SaveDelta(string szFile, int dwSaveFlags)
        {
            TrySaveDelta(szFile, dwSaveFlags).ThrowOnNotOK();
        }

        /// <summary>
        /// Saves changes from the current edit-and-continue session to the specified file.
        /// </summary>
        /// <param name="szFile">[in] The file name under which to save changes.</param>
        /// <param name="dwSaveFlags">[in] Reserved. Must be zero.</param>
        public HRESULT TrySaveDelta(string szFile, int dwSaveFlags)
        {
            /*HRESULT SaveDelta(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szFile,
            [In] int dwSaveFlags);*/
            return Raw2.SaveDelta(szFile, dwSaveFlags);
        }

        #endregion
        #region SaveDeltaToStream

        /// <summary>
        /// Saves changes from the current edit-and-continue session to the specified stream.
        /// </summary>
        /// <param name="pIStream">[in] An interface pointer to the writable stream to which to save changes.</param>
        /// <param name="dwSaveFlags">[in] Reserved. This value must be zero.</param>
        public void SaveDeltaToStream(IStream pIStream, int dwSaveFlags)
        {
            TrySaveDeltaToStream(pIStream, dwSaveFlags).ThrowOnNotOK();
        }

        /// <summary>
        /// Saves changes from the current edit-and-continue session to the specified stream.
        /// </summary>
        /// <param name="pIStream">[in] An interface pointer to the writable stream to which to save changes.</param>
        /// <param name="dwSaveFlags">[in] Reserved. This value must be zero.</param>
        public HRESULT TrySaveDeltaToStream(IStream pIStream, int dwSaveFlags)
        {
            /*HRESULT SaveDeltaToStream(
            [In, MarshalAs(UnmanagedType.Interface)] IStream pIStream,
            [In] int dwSaveFlags);*/
            return Raw2.SaveDeltaToStream(pIStream, dwSaveFlags);
        }

        #endregion
        #region SaveDeltaToMemory

        /// <summary>
        /// Saves changes from the current edit-and-continue session to memory.
        /// </summary>
        /// <param name="pbData">[out] The address at which to begin writing the metadata delta.</param>
        /// <param name="cbData">[in] The size of the changes. Use <see cref="GetDeltaSaveSize"/> to determine the size.</param>
        public void SaveDeltaToMemory(IntPtr pbData, int cbData)
        {
            TrySaveDeltaToMemory(pbData, cbData).ThrowOnNotOK();
        }

        /// <summary>
        /// Saves changes from the current edit-and-continue session to memory.
        /// </summary>
        /// <param name="pbData">[out] The address at which to begin writing the metadata delta.</param>
        /// <param name="cbData">[in] The size of the changes. Use <see cref="GetDeltaSaveSize"/> to determine the size.</param>
        public HRESULT TrySaveDeltaToMemory(IntPtr pbData, int cbData)
        {
            /*HRESULT SaveDeltaToMemory(
            [In] IntPtr pbData,
            [In] int cbData);*/
            return Raw2.SaveDeltaToMemory(pbData, cbData);
        }

        #endregion
        #region DefineGenericParam

        /// <summary>
        /// Creates a definition for a generic type parameter, and gets a token to that generic type parameter.
        /// </summary>
        /// <param name="tk">[in] An <see cref="mdTypeDef"/> or <see cref="mdMethodDef"/> token that represents the method or constructor for which to define a generic parameter.</param>
        /// <param name="ulParamSeq">[in] The index of the generic parameter.</param>
        /// <param name="dwParamFlags">[in] A value of the <see cref="CorGenericParamAttr"/> enumeration that describes the type for the generic parameter.</param>
        /// <param name="szName">[in] The name of the parameter.</param>
        /// <param name="reserved">[in] This parameter is reserved for future extensibility.</param>
        /// <param name="rtkConstraints">[in] A zero-terminated array of type constraints. Array members must be an <see cref="mdTypeDef"/>, <see cref="mdTypeRef"/>, or <see cref="mdTypeSpec"/> metadata token.</param>
        /// <returns>[out] A token that represents the generic parameter.</returns>
        public mdGenericParam DefineGenericParam(mdToken tk, int ulParamSeq, int dwParamFlags, string szName, int reserved, mdToken[] rtkConstraints)
        {
            mdGenericParam pgp;
            TryDefineGenericParam(tk, ulParamSeq, dwParamFlags, szName, reserved, rtkConstraints, out pgp).ThrowOnNotOK();

            return pgp;
        }

        /// <summary>
        /// Creates a definition for a generic type parameter, and gets a token to that generic type parameter.
        /// </summary>
        /// <param name="tk">[in] An <see cref="mdTypeDef"/> or <see cref="mdMethodDef"/> token that represents the method or constructor for which to define a generic parameter.</param>
        /// <param name="ulParamSeq">[in] The index of the generic parameter.</param>
        /// <param name="dwParamFlags">[in] A value of the <see cref="CorGenericParamAttr"/> enumeration that describes the type for the generic parameter.</param>
        /// <param name="szName">[in] The name of the parameter.</param>
        /// <param name="reserved">[in] This parameter is reserved for future extensibility.</param>
        /// <param name="rtkConstraints">[in] A zero-terminated array of type constraints. Array members must be an <see cref="mdTypeDef"/>, <see cref="mdTypeRef"/>, or <see cref="mdTypeSpec"/> metadata token.</param>
        /// <param name="pgp">[out] A token that represents the generic parameter.</param>
        public HRESULT TryDefineGenericParam(mdToken tk, int ulParamSeq, int dwParamFlags, string szName, int reserved, mdToken[] rtkConstraints, out mdGenericParam pgp)
        {
            /*HRESULT DefineGenericParam(
            [In] mdToken tk,
            [In] int ulParamSeq,
            [In] int dwParamFlags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [In] int reserved,
            [In, MarshalAs(UnmanagedType.LPArray)] mdToken[] rtkConstraints,
            [Out] out mdGenericParam pgp);*/
            return Raw2.DefineGenericParam(tk, ulParamSeq, dwParamFlags, szName, reserved, rtkConstraints, out pgp);
        }

        #endregion
        #region SetGenericParamProps

        /// <summary>
        /// Sets property values for the generic parameter definition referenced by the specified token.
        /// </summary>
        /// <param name="gp">[in] The token for the generic parameter definition for which to set values.</param>
        /// <param name="dwParamFlags">[in] A value of the <see cref="CorGenericParamAttr"/> enumeration that describes the type for the generic parameter.</param>
        /// <param name="szName">[in] Optional. The name of the parameter for which to set values.</param>
        /// <param name="reserved">[in] Reserved for future extensibility.</param>
        /// <param name="rtkConstraints">[in] Optional. A zero-terminated array of type constraints. Array members must be an <see cref="mdTypeDef"/>, <see cref="mdTypeRef"/>, or <see cref="mdTypeSpec"/> metadata token.</param>
        public void SetGenericParamProps(mdGenericParam gp, int dwParamFlags, string szName, int reserved, mdToken[] rtkConstraints)
        {
            TrySetGenericParamProps(gp, dwParamFlags, szName, reserved, rtkConstraints).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets property values for the generic parameter definition referenced by the specified token.
        /// </summary>
        /// <param name="gp">[in] The token for the generic parameter definition for which to set values.</param>
        /// <param name="dwParamFlags">[in] A value of the <see cref="CorGenericParamAttr"/> enumeration that describes the type for the generic parameter.</param>
        /// <param name="szName">[in] Optional. The name of the parameter for which to set values.</param>
        /// <param name="reserved">[in] Reserved for future extensibility.</param>
        /// <param name="rtkConstraints">[in] Optional. A zero-terminated array of type constraints. Array members must be an <see cref="mdTypeDef"/>, <see cref="mdTypeRef"/>, or <see cref="mdTypeSpec"/> metadata token.</param>
        public HRESULT TrySetGenericParamProps(mdGenericParam gp, int dwParamFlags, string szName, int reserved, mdToken[] rtkConstraints)
        {
            /*HRESULT SetGenericParamProps(
            [In] mdGenericParam gp,
            [In] int dwParamFlags,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [In] int reserved,
            [In, MarshalAs(UnmanagedType.LPArray)] mdToken[] rtkConstraints);*/
            return Raw2.SetGenericParamProps(gp, dwParamFlags, szName, reserved, rtkConstraints);
        }

        #endregion
        #region ResetENCLog

        /// <summary>
        /// Resets the edit-and-continue log and starts a new session.
        /// </summary>
        public void ResetENCLog()
        {
            TryResetENCLog().ThrowOnNotOK();
        }

        /// <summary>
        /// Resets the edit-and-continue log and starts a new session.
        /// </summary>
        public HRESULT TryResetENCLog()
        {
            /*HRESULT ResetENCLog();*/
            return Raw2.ResetENCLog();
        }

        #endregion
        #endregion
    }
}
