using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Provides the tools for creating and administering the type information defined through the type description. Derives from <see cref="ICreateTypeInfo"/>, and adds methods for deleting items that have been added through ICreateTypeInfo.<para/>
    /// The ICreateTypeInfo::LayOut method provides a way for the creator of the type information to check for any errors.<para/>
    /// A call to QueryInterface can be made to the ICreateTypeInfo instance at any time for its ITypeInfo interface. Calling any of the methods in the ITypeInfointerface that require layout information lays out the type information automatically.
    /// </summary>
    [Guid("0002040E-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public unsafe partial interface ICreateTypeInfo2 : ICreateTypeInfo
    {
#if !GENERATED_MARSHALLING
        /// <summary>
        /// Sets the globally unique identifier (GUID) associated with the type description.
        /// </summary>
        /// <param name="guid">[in] The globally unique ID to be associated with the type description.</param>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// For an interface, this is an interface ID (IID); for a coclass, it is a class ID (CLSID). For information on GUIDs,
        /// see Type Libraries and the Object Description Language.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetGuid(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid guid);

        /// <summary>
        /// Sets type flags of the type description being created.
        /// </summary>
        /// <param name="uTypeFlags">[in] The settings for the type flags. For details, see TYPEFLAGS.</param>
        /// <returns>This method can return one of these values.</returns>
        [PreserveSig]
        new HRESULT SetTypeFlags(
            [In] TYPEFLAGS uTypeFlags);

        /// <summary>
        ///  Sets the documentation string displayed by type browsers.
        /// </summary>
        /// <param name="pStrDoc">[in] A brief description of the type description.</param>
        /// <returns>This method can return one of these values.</returns>
        [PreserveSig]
        new HRESULT SetDocString(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pStrDoc);

        /// <summary>
        /// Sets the Help context ID of the type information.
        /// </summary>
        /// <param name="dwHelpContext">[in] A handle to the Help context.</param>
        /// <returns>This method can return one of these values.</returns>
        [PreserveSig]
        new HRESULT SetHelpContext(
            [In] int dwHelpContext);

        /// <summary>
        /// Sets the major and minor version number of the type information.
        /// </summary>
        /// <param name="wMajorVerNum">[in] The major version number.</param>
        /// <param name="wMinorVerNum">[in] The minor version number.</param>
        /// <returns>This method can return one of these values.</returns>
        [PreserveSig]
        new HRESULT SetVersion(
            [In] short wMajorVerNum,
            [In] short wMinorVerNum);

        /// <summary>
        /// Adds a type description to those referenced by the type description being created.
        /// </summary>
        /// <param name="pTInfo">[in] The type description to be referenced.</param>
        /// <param name="phRefType">[in] The handle that this type description associates with the referenced type information.</param>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// The second parameter returns a pointer to the handle of the added type information. If AddRefTypeInfo has been
        /// called previously for the same type information, the index that was returned by the previous call is returned in
        /// phRefType. If the referenced type description is in the type library being created, its type information can be
        /// obtained by calling IUnknown::QueryInterface(IID_ITypeInfo, ...) on the <see cref="ICreateTypeInfo"/> interface
        /// of that type description.
        /// </remarks>
        [PreserveSig]
        new HRESULT AddRefTypeInfo(
            [In] ITypeInfo pTInfo,
            [Out] out int phRefType);

        /// <summary>
        /// Adds a function description to the type description.
        /// </summary>
        /// <param name="index">[in] The index of the new FUNCDESC in the type information.</param>
        /// <param name="pFuncDesc">[in] A FUNCDESC structure that describes the function. The bstrIDLInfo field in the FUNCDESC should be null.</param>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// The index specifies the order of the functions within the type information. The first function has an index of
        /// zero. If an index is specified that exceeds one less than the number of functions in the type information, an error
        /// is returned. Calling this function does not pass ownership of the FUNCDESC structure to <see cref="ICreateTypeInfo"/>.
        /// Therefore, the caller must still de-allocate the FUNCDESC structure. The passed-in virtual function table (VTBL)
        /// field (oVft) of the FUNCDESC is ignored if the TYPEKIND is TKIND_MODULE or if oVft is -1 or 0. This attribute is
        /// set when ICreateTypeInfo::LayOut is called. The oVft value is used if the TYPEKIND is TKIND_DISPATCH and a dual
        /// interface or if the TYPEKIND is TKIND_INTERFACE. If the oVft is used, it must be a multiple of the sizeof(VOID
        /// *) on the machine, otherwise the function fails and E_INVALIDARG is returned as the HRESULT. The function AddFuncDesc
        /// uses the passed-in member identifier (memid) fields within each FUNCDESC for classes with TYPEKIND = TKIND_DISPATCH
        /// or TKIND_INTERFACE. If the member IDs are set to MEMBERID_NIL, AddFuncDesc assigns member IDs to the functions.
        /// Otherwise, the member ID fields within each FUNCDESC are ignored. Any HREFTYPE fields in the FUNCDESC structure
        /// must have been produced by the same instance of ITypeInfo for which AddFuncDesc is called. The get and put accessor
        /// functions for the same property must have the same dispatch identifier (DISPID).
        /// </remarks>
        [PreserveSig]
        new HRESULT AddFuncDesc(
            [In] int index,
            [In] FUNCDESC* pFuncDesc);

        /// <summary>
        /// Specifies an inherited interface, or an interface implemented by a component object class (coclass).
        /// </summary>
        /// <param name="index">[in] The index of the implementation class to be added. Specifies the order of the type relative to the other type.</param>
        /// <param name="hRefType">[in] A handle to the referenced type description obtained from the <see cref="AddRefTypeInfo"/> description.</param>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// To specify an inherited interface, use index = 0. For a dispinterface with Syntax 2, call ICreateTypeInfo::AddImplType
        /// twice, once with index = 0 for the inherited IDispatch and once with index = 1 for the interface that is being
        /// wrapped. For a dual interface, call ICreateTypeInfo::AddImplType with index = -1 for the TKIND_INTERFACE type information
        /// component of the dual interface.
        /// </remarks>
        [PreserveSig]
        new HRESULT AddImplType(
            [In] int index,
            [In] int hRefType);

        /// <summary>
        /// Sets the attributes for an implemented or inherited interface of a type.
        /// </summary>
        /// <param name="index">[in] The index of the interface for which to set type flags.</param>
        /// <param name="implTypeFlags">[in] IMPLTYPE flags to be set.</param>
        /// <returns>This method can return one of these values.</returns>
        [PreserveSig]
        new HRESULT SetImplTypeFlags(
            [In] int index,
            [In] IMPLTYPEFLAGS implTypeFlags);

        /// <summary>
        /// Specifies the data alignment for an item of TYPEKIND=TKIND_RECORD.
        /// </summary>
        /// <param name="cbAlignment">[in] Alignment method for the type. A value of 0 indicates alignment on the 64K boundary; 1 indicates no special alignment.<para/>
        /// For other values, n indicates alignment on byte n.</param>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// The alignment is the minimum of the natural alignment (for example, byte data on byte boundaries, word data on
        /// word boundaries, and so on), and the alignment denoted by cbAlignment.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetAlignment(
            [In] short cbAlignment);

        [PreserveSig]
        new HRESULT SetSchema(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pStrSchema);

        /// <summary>
        /// Adds a variable or data member description to the type description.
        /// </summary>
        /// <param name="index">[in] The index of the variable or data member to be added to the type description.</param>
        /// <param name="pVarDesc">[in] A pointer to the variable or data member description to be added.</param>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// The index specifies the order of the variables. The first variable has an index of zero. ICreateTypeInfo::AddVarDesc
        /// returns an error if the specified index is greater than the number of variables currently in the type information.
        /// Calling this function does not pass ownership of the VARDESC structure to <see cref="ICreateTypeInfo"/>. The instance
        /// field (oInst) of the VARDESC structure is ignored. This attribute is set only when ICreateTypeInfo::LayOut is called.
        /// Also, the member ID fields within the VARDESCs are ignored unless the TYPEKIND of the class is TKIND_DISPATCH.
        /// Any HREFTYPE fields in the VARDESC structure must have been produced by the same instance of ITypeInfo for which
        /// AddVarDesc is called. AddVarDesc ignores the contents of the idldesc field of the ELEMDESC.
        /// </remarks>
        [PreserveSig]
        new HRESULT AddVarDesc(
            [In] int index,
            [In] VARDESC* pVarDesc);

        /// <summary>
        /// Sets the name of a function and the names of its parameters to the specified names.
        /// </summary>
        /// <param name="index">[in] The index of the function whose function name and parameter names are to be set.</param>
        /// <param name="rgszNames">[in] An array of pointers to names. The first element is the function name. Subsequent elements are names of parameters.</param>
        /// <param name="cNames">[in] The number of elements in the rgszNames array.</param>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// This method must be used once for each property. The last parameter for put and putref accessor functions is unnamed.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetFuncAndParamNames(
            [In] int index,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2, ArraySubType = UnmanagedType.LPWStr)] string[] rgszNames,
            [In] int cNames);

        /// <summary>
        /// Sets the name of a variable.
        /// </summary>
        /// <param name="index">[in] The index of the variable.</param>
        /// <param name="szName">[in] The name.</param>
        /// <returns>This method can return one of these values.</returns>
        [PreserveSig]
        new HRESULT SetVarName(
            [In] int index,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName);

        /// <summary>
        /// Sets the type description for which this type description is an alias, if TYPEKIND=TKIND_ALIAS.
        /// </summary>
        /// <param name="pTDescAlias">[in] The type description.</param>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// To set the type for an alias, call SetTypeDescAlias for a type description whose TYPEKIND is TKIND_ALIAS.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetTypeDescAlias(
            [In] TYPEDESC* pTDescAlias);

        /// <summary>
        /// Associates a DLL entry point with the function that has the specified index.
        /// </summary>
        /// <param name="index">[in] The index of the function.</param>
        /// <param name="szDllName">[in] The name of the DLL that contains the entry point.</param>
        /// <param name="szProcName">[in] The name of the entry point or an ordinal (if the high word is zero).</param>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// If the high word of szProcName is zero, then the low word must contain the ordinal of the entry point; otherwise,
        /// szProcName points to the zero-terminated name of the entry point.
        /// </remarks>
        [PreserveSig]
        new HRESULT DefineFuncAsDllEntry(
            [In] int index,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szDllName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szProcName);

        /// <summary>
        /// Sets the documentation string for the function with the specified index.
        /// </summary>
        /// <param name="index">[in] The index of the function.</param>
        /// <param name="szDocString">[in] The documentation string.</param>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// The documentation string is a brief description of the function intended for use by tools such as type browsers.
        /// SetFuncDocString only needs to be used once for each property, because all property accessor functions are identified
        /// by one name.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetFuncDocString(
            [In] int index,
            [MarshalAs(UnmanagedType.LPWStr)] string szDocString);

        /// <summary>
        /// Sets the documentation string for the variable with the specified index.
        /// </summary>
        /// <param name="index">[in] The index of the variable.</param>
        /// <param name="szDocString">[in] The documentation string.</param>
        /// <returns>This method can return one of these values.</returns>
        [PreserveSig]
        new HRESULT SetVarDocString(
            [In] int index,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szDocString);

        /// <summary>
        /// Sets the Help context ID for the function with the specified index.
        /// </summary>
        /// <param name="index">[in] The index of the function.</param>
        /// <param name="dwHelpContext">[in] The Help context ID for the Help topic.</param>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// SetFuncHelpContext only needs to be set once for each property, because all property accessor functions are identified
        /// by one name.
        /// </remarks>
        [PreserveSig]
        new HRESULT SetFuncHelpContext(
            [In] int index,
            [In] int dwHelpContext);

        /// <summary>
        /// Sets the Help context ID for the variable with the specified index.
        /// </summary>
        /// <param name="index">[in] The index of the variable.</param>
        /// <param name="dwHelpContext">[in] The handle to the Help context ID for the Help topic on the variable.</param>
        /// <returns>This method can return one of these values.</returns>
        [PreserveSig]
        new HRESULT SetVarHelpContext(
            [In] int index,
            [In] int dwHelpContext);

        /// <summary>
        /// Sets the marshaling opcode string associated with the type description or the function.
        /// </summary>
        /// <param name="index">[in] The index of the member for which to set the opcode string. If index is –1, sets the opcode string for the type description.</param>
        /// <param name="bstrMops">[in] The marshaling opcode string.</param>
        /// <returns>This method can return one of these values.</returns>
        [PreserveSig]
        new HRESULT SetMops(
            [In] int index,
            [In, MarshalAs(UnmanagedType.BStr)] string bstrMops);

        [PreserveSig]
        new HRESULT SetTypeIdldesc(
            [In] IDLDESC* pIdlDesc);

        /// <summary>
        /// Assigns VTBL offsets for virtual functions and instance offsets for per-instance data members, and creates the two type descriptions for dual interfaces.
        /// </summary>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// LayOut also assigns member ID numbers to the functions and variables, unless the TYPEKIND of the class is TKIND_DISPATCH.
        /// Call LayOut after all members of the type information are defined, and before the type library is saved. Use <see
        /// cref="ICreateTypeLib.SaveAllChanges"/> to save the type information after calling LayOut. Other members of the
        /// <see cref="ICreateTypeInfo"/> interface should not be called after calling LayOut.
        /// </remarks>
        [PreserveSig]
        new HRESULT LayOut();
#endif

        /// <summary>
        /// Deletes a function description specified by the index number.
        /// </summary>
        /// <param name="index">[in] The index of the function whose description is to be deleted. The index should be in the range of 0 to 1 less than the number of functions in this type.</param>
        /// <returns>This method can return one of these values.</returns>
        [PreserveSig]
        HRESULT DeleteFuncDesc(
            [In] int index);

        /// <summary>
        /// Deletes the specified function description (FUNCDESC).
        /// </summary>
        /// <param name="memid">[in] The member identifier of the FUNCDESC to delete.</param>
        /// <param name="invKind">[in] The type of the invocation.</param>
        /// <returns>This method can return one of these values.</returns>
        [PreserveSig]
        HRESULT DeleteFuncDescByMemId(
            [In] int memid,
            [In] INVOKEKIND invKind);

        /// <summary>
        /// Deletes the specified VARDESC structure.
        /// </summary>
        /// <param name="index">[in] The index number of the VARDESC structure.</param>
        /// <returns>This method can return one of these values.</returns>
        [PreserveSig]
        HRESULT DeleteVarDesc(
            [In] int index);

        /// <summary>
        /// Deletes the specified VARDESC structure.
        /// </summary>
        /// <param name="memid">[in] The member identifier of the VARDESC to be deleted.</param>
        /// <returns>This method can return one of these values.</returns>
        [PreserveSig]
        HRESULT DeleteVarDescByMemId(
            [In] int memid);

        /// <summary>
        /// Deletes the IMPLTYPE flags for the indexed interface.
        /// </summary>
        /// <param name="index">[in] The index of the interface for which to delete the type flags.</param>
        /// <returns>This method can return one of these values.</returns>
        [PreserveSig]
        HRESULT DeleteImplType(
            [In] int index);

        /// <summary>
        /// Sets a value for custom data.
        /// </summary>
        /// <param name="guid">[in] The unique identifier that can be used to identify the data.</param>
        /// <param name="pVarVal">[in] The data to store (any variant except an object).</param>
        /// <returns>This method can return one of these values.</returns>
        [PreserveSig]
        HRESULT SetCustData(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid guid,
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(VariantMarshaller))]
#else
            [In, MarshalAs(UnmanagedType.Struct)]
#endif
            in object pVarVal);

        /// <summary>
        /// Sets a value for custom data for the specified function.
        /// </summary>
        /// <param name="index">[in] The index of the function for which to set the custom data.</param>
        /// <param name="guid">[in] The unique identifier used to identify the data.</param>
        /// <param name="pVarVal">[in] The data to store (any variant except an object).</param>
        /// <returns>This method can return one of these values.</returns>
        [PreserveSig]
        HRESULT SetFuncCustData(
            [In] int index,
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid guid,
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(VariantMarshaller))]
#else
            [In, MarshalAs(UnmanagedType.Struct)]
#endif
            in object pVarVal);

        /// <summary>
        ///  Sets a value for the custom data for the specified parameter.
        /// </summary>
        /// <param name="indexFunc">[in] The index of the function for which to set the custom data.</param>
        /// <param name="indexParam">[in] The index of the parameter of the function for which to set the custom data.</param>
        /// <param name="guid">[in] The globally unique identifier (GUID) used to identify the data.</param>
        /// <param name="pVarVal">[in] The data to store (any variant except an object).</param>
        /// <returns>This method can return one of these values.</returns>
        [PreserveSig]
        HRESULT SetParamCustData(
            [In] int indexFunc,
            [In] int indexParam,
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid guid,
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(VariantMarshaller))]
#else
            [In, MarshalAs(UnmanagedType.Struct)]
#endif
            in object pVarVal);

        /// <summary>
        /// Sets a value for custom data for the specified variable.
        /// </summary>
        /// <param name="index">[in] The index of the variable for which to set the custom data.</param>
        /// <param name="guid">[in] The globally unique ID (GUID) used to identify the data.</param>
        /// <param name="pVarVal">[in] The data to store (any variant except an object).</param>
        /// <returns>This method can return one of these values.</returns>
        [PreserveSig]
        HRESULT SetVarCustData(
            [In] int index,
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid guid,
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(VariantMarshaller))]
#else
            [In, MarshalAs(UnmanagedType.Struct)]
#endif
            in object pVarVal);

        /// <summary>
        /// Sets a value for custom data for the specified implementation type.
        /// </summary>
        /// <param name="index">[in] The index of the variable for which to set the custom data.</param>
        /// <param name="guid">[in] The unique identifier used to identify the data.</param>
        /// <param name="pVarVal">[in] The data to store (any variant except an object).</param>
        /// <returns>This method can return one of these values.</returns>
        [PreserveSig]
        HRESULT SetImplTypeCustData(
            [In] int index,
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid guid,
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(VariantMarshaller))]
#else
            [In, MarshalAs(UnmanagedType.Struct)]
#endif
            in object pVarVal);

        /// <summary>
        /// Sets the context number for the specified Help string.
        /// </summary>
        /// <param name="dwHelpStringContext">[in] The Help string context number.</param>
        /// <returns>This method can return one of these values.</returns>
        [PreserveSig]
        HRESULT SetHelpStringContext(
            [In] int dwHelpStringContext);

        /// <summary>
        /// Sets a Help context value for a specified function.
        /// </summary>
        /// <param name="index">[in] The index of the function for which to set the help string context.</param>
        /// <param name="dwHelpStringContext">[in] The Help string context for a localized string.</param>
        /// <returns>This method can return one of these values.</returns>
        [PreserveSig]
        HRESULT SetFuncHelpStringContext(
            [In] int index,
            [In] int dwHelpStringContext);

        /// <summary>
        /// Sets a Help context value for a specified variable.
        /// </summary>
        /// <param name="index">[in] The index of the variable.</param>
        /// <param name="dwHelpStringContext">[in] The Help string context for a localized string.</param>
        /// <returns>This method can return one of these values.</returns>
        [PreserveSig]
        HRESULT SetVarHelpStringContext(
            [In] int index,
            [In] int dwHelpStringContext);

        [PreserveSig]
        HRESULT Invalidate();

        /// <summary>
        /// Sets the name of the typeinfo.
        /// </summary>
        /// <param name="szName">[in] The name to be assigned.</param>
        /// <returns>This method can return one of these values.</returns>
        [PreserveSig]
        HRESULT SetName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName);
    }
}
