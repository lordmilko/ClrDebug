using System;
using System.Diagnostics;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Provides the tools for creating and administering the type information defined through the type description.
    /// </summary>
    public class CreateTypeInfo : ComObject<ICreateTypeInfo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTypeInfo"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CreateTypeInfo(ICreateTypeInfo raw) : base(raw)
        {
        }

        #region ICreateTypeInfo
        #region SetGuid

        /// <summary>
        /// Sets the globally unique identifier (GUID) associated with the type description.
        /// </summary>
        /// <param name="guid">[in] The globally unique ID to be associated with the type description.</param>
        /// <remarks>
        /// For an interface, this is an interface ID (IID); for a coclass, it is a class ID (CLSID). For information on GUIDs,
        /// see Type Libraries and the Object Description Language.
        /// </remarks>
        public void SetGuid(Guid guid)
        {
            TrySetGuid(guid).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the globally unique identifier (GUID) associated with the type description.
        /// </summary>
        /// <param name="guid">[in] The globally unique ID to be associated with the type description.</param>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// For an interface, this is an interface ID (IID); for a coclass, it is a class ID (CLSID). For information on GUIDs,
        /// see Type Libraries and the Object Description Language.
        /// </remarks>
        public HRESULT TrySetGuid(Guid guid)
        {
            /*HRESULT SetGuid(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guid);*/
            return Raw.SetGuid(guid);
        }

        #endregion
        #region SetTypeFlags

        /// <summary>
        /// Sets type flags of the type description being created.
        /// </summary>
        /// <param name="uTypeFlags">[in] The settings for the type flags. For details, see TYPEFLAGS.</param>
        public void SetTypeFlags(TYPEFLAGS uTypeFlags)
        {
            TrySetTypeFlags(uTypeFlags).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets type flags of the type description being created.
        /// </summary>
        /// <param name="uTypeFlags">[in] The settings for the type flags. For details, see TYPEFLAGS.</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TrySetTypeFlags(TYPEFLAGS uTypeFlags)
        {
            /*HRESULT SetTypeFlags(
            [In] TYPEFLAGS uTypeFlags);*/
            return Raw.SetTypeFlags(uTypeFlags);
        }

        #endregion
        #region SetDocString

        /// <summary>
        ///  Sets the documentation string displayed by type browsers.
        /// </summary>
        /// <param name="pStrDoc">[in] A brief description of the type description.</param>
        public void SetDocString(string pStrDoc)
        {
            TrySetDocString(pStrDoc).ThrowOnNotOK();
        }

        /// <summary>
        ///  Sets the documentation string displayed by type browsers.
        /// </summary>
        /// <param name="pStrDoc">[in] A brief description of the type description.</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TrySetDocString(string pStrDoc)
        {
            /*HRESULT SetDocString(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pStrDoc);*/
            return Raw.SetDocString(pStrDoc);
        }

        #endregion
        #region SetHelpContext

        /// <summary>
        /// Sets the Help context ID of the type information.
        /// </summary>
        /// <param name="dwHelpContext">[in] A handle to the Help context.</param>
        public void SetHelpContext(int dwHelpContext)
        {
            TrySetHelpContext(dwHelpContext).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the Help context ID of the type information.
        /// </summary>
        /// <param name="dwHelpContext">[in] A handle to the Help context.</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TrySetHelpContext(int dwHelpContext)
        {
            /*HRESULT SetHelpContext(
            [In] int dwHelpContext);*/
            return Raw.SetHelpContext(dwHelpContext);
        }

        #endregion
        #region SetVersion

        /// <summary>
        /// Sets the major and minor version number of the type information.
        /// </summary>
        /// <param name="wMajorVerNum">[in] The major version number.</param>
        /// <param name="wMinorVerNum">[in] The minor version number.</param>
        public void SetVersion(short wMajorVerNum, short wMinorVerNum)
        {
            TrySetVersion(wMajorVerNum, wMinorVerNum).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the major and minor version number of the type information.
        /// </summary>
        /// <param name="wMajorVerNum">[in] The major version number.</param>
        /// <param name="wMinorVerNum">[in] The minor version number.</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TrySetVersion(short wMajorVerNum, short wMinorVerNum)
        {
            /*HRESULT SetVersion(
            [In] short wMajorVerNum,
            [In] short wMinorVerNum);*/
            return Raw.SetVersion(wMajorVerNum, wMinorVerNum);
        }

        #endregion
        #region AddRefTypeInfo

        /// <summary>
        /// Adds a type description to those referenced by the type description being created.
        /// </summary>
        /// <param name="pTInfo">[in] The type description to be referenced.</param>
        /// <returns>[in] The handle that this type description associates with the referenced type information.</returns>
        /// <remarks>
        /// The second parameter returns a pointer to the handle of the added type information. If AddRefTypeInfo has been
        /// called previously for the same type information, the index that was returned by the previous call is returned in
        /// phRefType. If the referenced type description is in the type library being created, its type information can be
        /// obtained by calling IUnknown::QueryInterface(IID_ITypeInfo, ...) on the <see cref="ICreateTypeInfo"/> interface
        /// of that type description.
        /// </remarks>
        public int AddRefTypeInfo(ITypeInfo pTInfo)
        {
            int phRefType;
            TryAddRefTypeInfo(pTInfo, out phRefType).ThrowOnNotOK();

            return phRefType;
        }

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
        public HRESULT TryAddRefTypeInfo(ITypeInfo pTInfo, out int phRefType)
        {
            /*HRESULT AddRefTypeInfo(
            [In] ITypeInfo pTInfo,
            [Out] out int phRefType);*/
            return Raw.AddRefTypeInfo(pTInfo, out phRefType);
        }

        #endregion
        #region AddFuncDesc

        /// <summary>
        /// Adds a function description to the type description.
        /// </summary>
        /// <param name="index">[in] The index of the new FUNCDESC in the type information.</param>
        /// <param name="pFuncDesc">[in] A FUNCDESC structure that describes the function. The bstrIDLInfo field in the FUNCDESC should be null.</param>
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
        public unsafe void AddFuncDesc(int index, FUNCDESC* pFuncDesc)
        {
            TryAddFuncDesc(index, pFuncDesc).ThrowOnNotOK();
        }

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
        public unsafe HRESULT TryAddFuncDesc(int index, FUNCDESC* pFuncDesc)
        {
            /*HRESULT AddFuncDesc(
            [In] int index,
            [In] FUNCDESC* pFuncDesc);*/
            return Raw.AddFuncDesc(index, pFuncDesc);
        }

        #endregion
        #region AddImplType

        /// <summary>
        /// Specifies an inherited interface, or an interface implemented by a component object class (coclass).
        /// </summary>
        /// <param name="index">[in] The index of the implementation class to be added. Specifies the order of the type relative to the other type.</param>
        /// <param name="hRefType">[in] A handle to the referenced type description obtained from the <see cref="AddRefTypeInfo"/> description.</param>
        /// <remarks>
        /// To specify an inherited interface, use index = 0. For a dispinterface with Syntax 2, call ICreateTypeInfo::AddImplType
        /// twice, once with index = 0 for the inherited IDispatch and once with index = 1 for the interface that is being
        /// wrapped. For a dual interface, call ICreateTypeInfo::AddImplType with index = -1 for the TKIND_INTERFACE type information
        /// component of the dual interface.
        /// </remarks>
        public void AddImplType(int index, int hRefType)
        {
            TryAddImplType(index, hRefType).ThrowOnNotOK();
        }

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
        public HRESULT TryAddImplType(int index, int hRefType)
        {
            /*HRESULT AddImplType(
            [In] int index,
            [In] int hRefType);*/
            return Raw.AddImplType(index, hRefType);
        }

        #endregion
        #region SetImplTypeFlags

        /// <summary>
        /// Sets the attributes for an implemented or inherited interface of a type.
        /// </summary>
        /// <param name="index">[in] The index of the interface for which to set type flags.</param>
        /// <param name="implTypeFlags">[in] IMPLTYPE flags to be set.</param>
        public void SetImplTypeFlags(int index, IMPLTYPEFLAGS implTypeFlags)
        {
            TrySetImplTypeFlags(index, implTypeFlags).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the attributes for an implemented or inherited interface of a type.
        /// </summary>
        /// <param name="index">[in] The index of the interface for which to set type flags.</param>
        /// <param name="implTypeFlags">[in] IMPLTYPE flags to be set.</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TrySetImplTypeFlags(int index, IMPLTYPEFLAGS implTypeFlags)
        {
            /*HRESULT SetImplTypeFlags(
            [In] int index,
            [In] IMPLTYPEFLAGS implTypeFlags);*/
            return Raw.SetImplTypeFlags(index, implTypeFlags);
        }

        #endregion
        #region SetAlignment

        /// <summary>
        /// Specifies the data alignment for an item of TYPEKIND=TKIND_RECORD.
        /// </summary>
        /// <param name="cbAlignment">[in] Alignment method for the type. A value of 0 indicates alignment on the 64K boundary; 1 indicates no special alignment.<para/>
        /// For other values, n indicates alignment on byte n.</param>
        /// <remarks>
        /// The alignment is the minimum of the natural alignment (for example, byte data on byte boundaries, word data on
        /// word boundaries, and so on), and the alignment denoted by cbAlignment.
        /// </remarks>
        public void SetAlignment(short cbAlignment)
        {
            TrySetAlignment(cbAlignment).ThrowOnNotOK();
        }

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
        public HRESULT TrySetAlignment(short cbAlignment)
        {
            /*HRESULT SetAlignment(
            [In] short cbAlignment);*/
            return Raw.SetAlignment(cbAlignment);
        }

        #endregion
        #region SetSchema

        public void SetSchema(string pStrSchema)
        {
            TrySetSchema(pStrSchema).ThrowOnNotOK();
        }

        public HRESULT TrySetSchema(string pStrSchema)
        {
            /*HRESULT SetSchema(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pStrSchema);*/
            return Raw.SetSchema(pStrSchema);
        }

        #endregion
        #region AddVarDesc

        /// <summary>
        /// Adds a variable or data member description to the type description.
        /// </summary>
        /// <param name="index">[in] The index of the variable or data member to be added to the type description.</param>
        /// <param name="pVarDesc">[in] A pointer to the variable or data member description to be added.</param>
        /// <remarks>
        /// The index specifies the order of the variables. The first variable has an index of zero. ICreateTypeInfo::AddVarDesc
        /// returns an error if the specified index is greater than the number of variables currently in the type information.
        /// Calling this function does not pass ownership of the VARDESC structure to <see cref="ICreateTypeInfo"/>. The instance
        /// field (oInst) of the VARDESC structure is ignored. This attribute is set only when ICreateTypeInfo::LayOut is called.
        /// Also, the member ID fields within the VARDESCs are ignored unless the TYPEKIND of the class is TKIND_DISPATCH.
        /// Any HREFTYPE fields in the VARDESC structure must have been produced by the same instance of ITypeInfo for which
        /// AddVarDesc is called. AddVarDesc ignores the contents of the idldesc field of the ELEMDESC.
        /// </remarks>
        public unsafe void AddVarDesc(int index, VARDESC* pVarDesc)
        {
            TryAddVarDesc(index, pVarDesc).ThrowOnNotOK();
        }

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
        public unsafe HRESULT TryAddVarDesc(int index, VARDESC* pVarDesc)
        {
            /*HRESULT AddVarDesc(
            [In] int index,
            [In] VARDESC* pVarDesc);*/
            return Raw.AddVarDesc(index, pVarDesc);
        }

        #endregion
        #region SetFuncAndParamNames

        /// <summary>
        /// Sets the name of a function and the names of its parameters to the specified names.
        /// </summary>
        /// <param name="index">[in] The index of the function whose function name and parameter names are to be set.</param>
        /// <param name="rgszNames">[in] An array of pointers to names. The first element is the function name. Subsequent elements are names of parameters.</param>
        /// <param name="cNames">[in] The number of elements in the rgszNames array.</param>
        /// <remarks>
        /// This method must be used once for each property. The last parameter for put and putref accessor functions is unnamed.
        /// </remarks>
        public void SetFuncAndParamNames(int index, string[] rgszNames, int cNames)
        {
            TrySetFuncAndParamNames(index, rgszNames, cNames).ThrowOnNotOK();
        }

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
        public HRESULT TrySetFuncAndParamNames(int index, string[] rgszNames, int cNames)
        {
            /*HRESULT SetFuncAndParamNames(
            [In] int index,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2, ArraySubType = UnmanagedType.LPWStr)] string[] rgszNames,
            [In] int cNames);*/
            return Raw.SetFuncAndParamNames(index, rgszNames, cNames);
        }

        #endregion
        #region SetVarName

        /// <summary>
        /// Sets the name of a variable.
        /// </summary>
        /// <param name="index">[in] The index of the variable.</param>
        /// <param name="szName">[in] The name.</param>
        public void SetVarName(int index, string szName)
        {
            TrySetVarName(index, szName).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the name of a variable.
        /// </summary>
        /// <param name="index">[in] The index of the variable.</param>
        /// <param name="szName">[in] The name.</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TrySetVarName(int index, string szName)
        {
            /*HRESULT SetVarName(
            [In] int index,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName);*/
            return Raw.SetVarName(index, szName);
        }

        #endregion
        #region SetTypeDescAlias

        /// <summary>
        /// Sets the type description for which this type description is an alias, if TYPEKIND=TKIND_ALIAS.
        /// </summary>
        /// <param name="pTDescAlias">[in] The type description.</param>
        /// <remarks>
        /// To set the type for an alias, call SetTypeDescAlias for a type description whose TYPEKIND is TKIND_ALIAS.
        /// </remarks>
        public unsafe void SetTypeDescAlias(TYPEDESC* pTDescAlias)
        {
            TrySetTypeDescAlias(pTDescAlias).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the type description for which this type description is an alias, if TYPEKIND=TKIND_ALIAS.
        /// </summary>
        /// <param name="pTDescAlias">[in] The type description.</param>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// To set the type for an alias, call SetTypeDescAlias for a type description whose TYPEKIND is TKIND_ALIAS.
        /// </remarks>
        public unsafe HRESULT TrySetTypeDescAlias(TYPEDESC* pTDescAlias)
        {
            /*HRESULT SetTypeDescAlias(
            [In] TYPEDESC* pTDescAlias);*/
            return Raw.SetTypeDescAlias(pTDescAlias);
        }

        #endregion
        #region DefineFuncAsDllEntry

        /// <summary>
        /// Associates a DLL entry point with the function that has the specified index.
        /// </summary>
        /// <param name="index">[in] The index of the function.</param>
        /// <param name="szDllName">[in] The name of the DLL that contains the entry point.</param>
        /// <param name="szProcName">[in] The name of the entry point or an ordinal (if the high word is zero).</param>
        /// <remarks>
        /// If the high word of szProcName is zero, then the low word must contain the ordinal of the entry point; otherwise,
        /// szProcName points to the zero-terminated name of the entry point.
        /// </remarks>
        public void DefineFuncAsDllEntry(int index, string szDllName, string szProcName)
        {
            TryDefineFuncAsDllEntry(index, szDllName, szProcName).ThrowOnNotOK();
        }

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
        public HRESULT TryDefineFuncAsDllEntry(int index, string szDllName, string szProcName)
        {
            /*HRESULT DefineFuncAsDllEntry(
            [In] int index,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szDllName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szProcName);*/
            return Raw.DefineFuncAsDllEntry(index, szDllName, szProcName);
        }

        #endregion
        #region SetFuncDocString

        /// <summary>
        /// Sets the documentation string for the function with the specified index.
        /// </summary>
        /// <param name="index">[in] The index of the function.</param>
        /// <param name="szDocString">[in] The documentation string.</param>
        /// <remarks>
        /// The documentation string is a brief description of the function intended for use by tools such as type browsers.
        /// SetFuncDocString only needs to be used once for each property, because all property accessor functions are identified
        /// by one name.
        /// </remarks>
        public void SetFuncDocString(int index, string szDocString)
        {
            TrySetFuncDocString(index, szDocString).ThrowOnNotOK();
        }

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
        public HRESULT TrySetFuncDocString(int index, string szDocString)
        {
            /*HRESULT SetFuncDocString(
            [In] int index,
            [MarshalAs(UnmanagedType.LPWStr)] string szDocString);*/
            return Raw.SetFuncDocString(index, szDocString);
        }

        #endregion
        #region SetVarDocString

        /// <summary>
        /// Sets the documentation string for the variable with the specified index.
        /// </summary>
        /// <param name="index">[in] The index of the variable.</param>
        /// <param name="szDocString">[in] The documentation string.</param>
        public void SetVarDocString(int index, string szDocString)
        {
            TrySetVarDocString(index, szDocString).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the documentation string for the variable with the specified index.
        /// </summary>
        /// <param name="index">[in] The index of the variable.</param>
        /// <param name="szDocString">[in] The documentation string.</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TrySetVarDocString(int index, string szDocString)
        {
            /*HRESULT SetVarDocString(
            [In] int index,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szDocString);*/
            return Raw.SetVarDocString(index, szDocString);
        }

        #endregion
        #region SetFuncHelpContext

        /// <summary>
        /// Sets the Help context ID for the function with the specified index.
        /// </summary>
        /// <param name="index">[in] The index of the function.</param>
        /// <param name="dwHelpContext">[in] The Help context ID for the Help topic.</param>
        /// <remarks>
        /// SetFuncHelpContext only needs to be set once for each property, because all property accessor functions are identified
        /// by one name.
        /// </remarks>
        public void SetFuncHelpContext(int index, int dwHelpContext)
        {
            TrySetFuncHelpContext(index, dwHelpContext).ThrowOnNotOK();
        }

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
        public HRESULT TrySetFuncHelpContext(int index, int dwHelpContext)
        {
            /*HRESULT SetFuncHelpContext(
            [In] int index,
            [In] int dwHelpContext);*/
            return Raw.SetFuncHelpContext(index, dwHelpContext);
        }

        #endregion
        #region SetVarHelpContext

        /// <summary>
        /// Sets the Help context ID for the variable with the specified index.
        /// </summary>
        /// <param name="index">[in] The index of the variable.</param>
        /// <param name="dwHelpContext">[in] The handle to the Help context ID for the Help topic on the variable.</param>
        public void SetVarHelpContext(int index, int dwHelpContext)
        {
            TrySetVarHelpContext(index, dwHelpContext).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the Help context ID for the variable with the specified index.
        /// </summary>
        /// <param name="index">[in] The index of the variable.</param>
        /// <param name="dwHelpContext">[in] The handle to the Help context ID for the Help topic on the variable.</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TrySetVarHelpContext(int index, int dwHelpContext)
        {
            /*HRESULT SetVarHelpContext(
            [In] int index,
            [In] int dwHelpContext);*/
            return Raw.SetVarHelpContext(index, dwHelpContext);
        }

        #endregion
        #region SetMops

        /// <summary>
        /// Sets the marshaling opcode string associated with the type description or the function.
        /// </summary>
        /// <param name="index">[in] The index of the member for which to set the opcode string. If index is –1, sets the opcode string for the type description.</param>
        /// <param name="bstrMops">[in] The marshaling opcode string.</param>
        public void SetMops(int index, string bstrMops)
        {
            TrySetMops(index, bstrMops).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the marshaling opcode string associated with the type description or the function.
        /// </summary>
        /// <param name="index">[in] The index of the member for which to set the opcode string. If index is –1, sets the opcode string for the type description.</param>
        /// <param name="bstrMops">[in] The marshaling opcode string.</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TrySetMops(int index, string bstrMops)
        {
            /*HRESULT SetMops(
            [In] int index,
            [In, MarshalAs(UnmanagedType.BStr)] string bstrMops);*/
            return Raw.SetMops(index, bstrMops);
        }

        #endregion
        #region SetTypeIdldesc

        public unsafe void SetTypeIdldesc(IDLDESC* pIdlDesc)
        {
            TrySetTypeIdldesc(pIdlDesc).ThrowOnNotOK();
        }

        public unsafe HRESULT TrySetTypeIdldesc(IDLDESC* pIdlDesc)
        {
            /*HRESULT SetTypeIdldesc(
            [In] IDLDESC* pIdlDesc);*/
            return Raw.SetTypeIdldesc(pIdlDesc);
        }

        #endregion
        #region LayOut

        /// <summary>
        /// Assigns VTBL offsets for virtual functions and instance offsets for per-instance data members, and creates the two type descriptions for dual interfaces.
        /// </summary>
        /// <remarks>
        /// LayOut also assigns member ID numbers to the functions and variables, unless the TYPEKIND of the class is TKIND_DISPATCH.
        /// Call LayOut after all members of the type information are defined, and before the type library is saved. Use <see
        /// cref="CreateTypeLib.SaveAllChanges"/> to save the type information after calling LayOut. Other members of the
        /// <see cref="ICreateTypeInfo"/> interface should not be called after calling LayOut.
        /// </remarks>
        public void LayOut()
        {
            TryLayOut().ThrowOnNotOK();
        }

        /// <summary>
        /// Assigns VTBL offsets for virtual functions and instance offsets for per-instance data members, and creates the two type descriptions for dual interfaces.
        /// </summary>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// LayOut also assigns member ID numbers to the functions and variables, unless the TYPEKIND of the class is TKIND_DISPATCH.
        /// Call LayOut after all members of the type information are defined, and before the type library is saved. Use <see
        /// cref="CreateTypeLib.SaveAllChanges"/> to save the type information after calling LayOut. Other members of the
        /// <see cref="ICreateTypeInfo"/> interface should not be called after calling LayOut.
        /// </remarks>
        public HRESULT TryLayOut()
        {
            /*HRESULT LayOut();*/
            return Raw.LayOut();
        }

        #endregion
        #endregion
        #region ICreateTypeInfo2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICreateTypeInfo2 Raw2 => (ICreateTypeInfo2) Raw;

        #region DeleteFuncDesc

        /// <summary>
        /// Deletes a function description specified by the index number.
        /// </summary>
        /// <param name="index">[in] The index of the function whose description is to be deleted. The index should be in the range of 0 to 1 less than the number of functions in this type.</param>
        public void DeleteFuncDesc(int index)
        {
            TryDeleteFuncDesc(index).ThrowOnNotOK();
        }

        /// <summary>
        /// Deletes a function description specified by the index number.
        /// </summary>
        /// <param name="index">[in] The index of the function whose description is to be deleted. The index should be in the range of 0 to 1 less than the number of functions in this type.</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TryDeleteFuncDesc(int index)
        {
            /*HRESULT DeleteFuncDesc(
            [In] int index);*/
            return Raw2.DeleteFuncDesc(index);
        }

        #endregion
        #region DeleteFuncDescByMemId

        /// <summary>
        /// Deletes the specified function description (FUNCDESC).
        /// </summary>
        /// <param name="memid">[in] The member identifier of the FUNCDESC to delete.</param>
        /// <param name="invKind">[in] The type of the invocation.</param>
        public void DeleteFuncDescByMemId(int memid, INVOKEKIND invKind)
        {
            TryDeleteFuncDescByMemId(memid, invKind).ThrowOnNotOK();
        }

        /// <summary>
        /// Deletes the specified function description (FUNCDESC).
        /// </summary>
        /// <param name="memid">[in] The member identifier of the FUNCDESC to delete.</param>
        /// <param name="invKind">[in] The type of the invocation.</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TryDeleteFuncDescByMemId(int memid, INVOKEKIND invKind)
        {
            /*HRESULT DeleteFuncDescByMemId(
            [In] int memid,
            [In] INVOKEKIND invKind);*/
            return Raw2.DeleteFuncDescByMemId(memid, invKind);
        }

        #endregion
        #region DeleteVarDesc

        /// <summary>
        /// Deletes the specified VARDESC structure.
        /// </summary>
        /// <param name="index">[in] The index number of the VARDESC structure.</param>
        public void DeleteVarDesc(int index)
        {
            TryDeleteVarDesc(index).ThrowOnNotOK();
        }

        /// <summary>
        /// Deletes the specified VARDESC structure.
        /// </summary>
        /// <param name="index">[in] The index number of the VARDESC structure.</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TryDeleteVarDesc(int index)
        {
            /*HRESULT DeleteVarDesc(
            [In] int index);*/
            return Raw2.DeleteVarDesc(index);
        }

        #endregion
        #region DeleteVarDescByMemId

        /// <summary>
        /// Deletes the specified VARDESC structure.
        /// </summary>
        /// <param name="memid">[in] The member identifier of the VARDESC to be deleted.</param>
        public void DeleteVarDescByMemId(int memid)
        {
            TryDeleteVarDescByMemId(memid).ThrowOnNotOK();
        }

        /// <summary>
        /// Deletes the specified VARDESC structure.
        /// </summary>
        /// <param name="memid">[in] The member identifier of the VARDESC to be deleted.</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TryDeleteVarDescByMemId(int memid)
        {
            /*HRESULT DeleteVarDescByMemId(
            [In] int memid);*/
            return Raw2.DeleteVarDescByMemId(memid);
        }

        #endregion
        #region DeleteImplType

        /// <summary>
        /// Deletes the IMPLTYPE flags for the indexed interface.
        /// </summary>
        /// <param name="index">[in] The index of the interface for which to delete the type flags.</param>
        public void DeleteImplType(int index)
        {
            TryDeleteImplType(index).ThrowOnNotOK();
        }

        /// <summary>
        /// Deletes the IMPLTYPE flags for the indexed interface.
        /// </summary>
        /// <param name="index">[in] The index of the interface for which to delete the type flags.</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TryDeleteImplType(int index)
        {
            /*HRESULT DeleteImplType(
            [In] int index);*/
            return Raw2.DeleteImplType(index);
        }

        #endregion
        #region SetCustData

        /// <summary>
        /// Sets a value for custom data.
        /// </summary>
        /// <param name="guid">[in] The unique identifier that can be used to identify the data.</param>
        /// <param name="pVarVal">[in] The data to store (any variant except an object).</param>
        public void SetCustData(Guid guid, object pVarVal)
        {
            TrySetCustData(guid, pVarVal).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets a value for custom data.
        /// </summary>
        /// <param name="guid">[in] The unique identifier that can be used to identify the data.</param>
        /// <param name="pVarVal">[in] The data to store (any variant except an object).</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TrySetCustData(Guid guid, object pVarVal)
        {
            /*HRESULT SetCustData(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guid,
            [In, MarshalAs(UnmanagedType.Struct)] in object pVarVal);*/
            return Raw2.SetCustData(guid, pVarVal);
        }

        #endregion
        #region SetFuncCustData

        /// <summary>
        /// Sets a value for custom data for the specified function.
        /// </summary>
        /// <param name="index">[in] The index of the function for which to set the custom data.</param>
        /// <param name="guid">[in] The unique identifier used to identify the data.</param>
        /// <param name="pVarVal">[in] The data to store (any variant except an object).</param>
        public void SetFuncCustData(int index, Guid guid, object pVarVal)
        {
            TrySetFuncCustData(index, guid, pVarVal).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets a value for custom data for the specified function.
        /// </summary>
        /// <param name="index">[in] The index of the function for which to set the custom data.</param>
        /// <param name="guid">[in] The unique identifier used to identify the data.</param>
        /// <param name="pVarVal">[in] The data to store (any variant except an object).</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TrySetFuncCustData(int index, Guid guid, object pVarVal)
        {
            /*HRESULT SetFuncCustData(
            [In] int index,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guid,
            [In, MarshalAs(UnmanagedType.Struct)] in object pVarVal);*/
            return Raw2.SetFuncCustData(index, guid, pVarVal);
        }

        #endregion
        #region SetParamCustData

        /// <summary>
        ///  Sets a value for the custom data for the specified parameter.
        /// </summary>
        /// <param name="indexFunc">[in] The index of the function for which to set the custom data.</param>
        /// <param name="indexParam">[in] The index of the parameter of the function for which to set the custom data.</param>
        /// <param name="guid">[in] The globally unique identifier (GUID) used to identify the data.</param>
        /// <param name="pVarVal">[in] The data to store (any variant except an object).</param>
        public void SetParamCustData(int indexFunc, int indexParam, Guid guid, object pVarVal)
        {
            TrySetParamCustData(indexFunc, indexParam, guid, pVarVal).ThrowOnNotOK();
        }

        /// <summary>
        ///  Sets a value for the custom data for the specified parameter.
        /// </summary>
        /// <param name="indexFunc">[in] The index of the function for which to set the custom data.</param>
        /// <param name="indexParam">[in] The index of the parameter of the function for which to set the custom data.</param>
        /// <param name="guid">[in] The globally unique identifier (GUID) used to identify the data.</param>
        /// <param name="pVarVal">[in] The data to store (any variant except an object).</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TrySetParamCustData(int indexFunc, int indexParam, Guid guid, object pVarVal)
        {
            /*HRESULT SetParamCustData(
            [In] int indexFunc,
            [In] int indexParam,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guid,
            [In, MarshalAs(UnmanagedType.Struct)] in object pVarVal);*/
            return Raw2.SetParamCustData(indexFunc, indexParam, guid, pVarVal);
        }

        #endregion
        #region SetVarCustData

        /// <summary>
        /// Sets a value for custom data for the specified variable.
        /// </summary>
        /// <param name="index">[in] The index of the variable for which to set the custom data.</param>
        /// <param name="guid">[in] The globally unique ID (GUID) used to identify the data.</param>
        /// <param name="pVarVal">[in] The data to store (any variant except an object).</param>
        public void SetVarCustData(int index, Guid guid, object pVarVal)
        {
            TrySetVarCustData(index, guid, pVarVal).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets a value for custom data for the specified variable.
        /// </summary>
        /// <param name="index">[in] The index of the variable for which to set the custom data.</param>
        /// <param name="guid">[in] The globally unique ID (GUID) used to identify the data.</param>
        /// <param name="pVarVal">[in] The data to store (any variant except an object).</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TrySetVarCustData(int index, Guid guid, object pVarVal)
        {
            /*HRESULT SetVarCustData(
            [In] int index,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guid,
            [In, MarshalAs(UnmanagedType.Struct)] in object pVarVal);*/
            return Raw2.SetVarCustData(index, guid, pVarVal);
        }

        #endregion
        #region SetImplTypeCustData

        /// <summary>
        /// Sets a value for custom data for the specified implementation type.
        /// </summary>
        /// <param name="index">[in] The index of the variable for which to set the custom data.</param>
        /// <param name="guid">[in] The unique identifier used to identify the data.</param>
        /// <param name="pVarVal">[in] The data to store (any variant except an object).</param>
        public void SetImplTypeCustData(int index, Guid guid, object pVarVal)
        {
            TrySetImplTypeCustData(index, guid, pVarVal).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets a value for custom data for the specified implementation type.
        /// </summary>
        /// <param name="index">[in] The index of the variable for which to set the custom data.</param>
        /// <param name="guid">[in] The unique identifier used to identify the data.</param>
        /// <param name="pVarVal">[in] The data to store (any variant except an object).</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TrySetImplTypeCustData(int index, Guid guid, object pVarVal)
        {
            /*HRESULT SetImplTypeCustData(
            [In] int index,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guid,
            [In, MarshalAs(UnmanagedType.Struct)] in object pVarVal);*/
            return Raw2.SetImplTypeCustData(index, guid, pVarVal);
        }

        #endregion
        #region SetHelpStringContext

        /// <summary>
        /// Sets the context number for the specified Help string.
        /// </summary>
        /// <param name="dwHelpStringContext">[in] The Help string context number.</param>
        public void SetHelpStringContext(int dwHelpStringContext)
        {
            TrySetHelpStringContext(dwHelpStringContext).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the context number for the specified Help string.
        /// </summary>
        /// <param name="dwHelpStringContext">[in] The Help string context number.</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TrySetHelpStringContext(int dwHelpStringContext)
        {
            /*HRESULT SetHelpStringContext(
            [In] int dwHelpStringContext);*/
            return Raw2.SetHelpStringContext(dwHelpStringContext);
        }

        #endregion
        #region SetFuncHelpStringContext

        /// <summary>
        /// Sets a Help context value for a specified function.
        /// </summary>
        /// <param name="index">[in] The index of the function for which to set the help string context.</param>
        /// <param name="dwHelpStringContext">[in] The Help string context for a localized string.</param>
        public void SetFuncHelpStringContext(int index, int dwHelpStringContext)
        {
            TrySetFuncHelpStringContext(index, dwHelpStringContext).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets a Help context value for a specified function.
        /// </summary>
        /// <param name="index">[in] The index of the function for which to set the help string context.</param>
        /// <param name="dwHelpStringContext">[in] The Help string context for a localized string.</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TrySetFuncHelpStringContext(int index, int dwHelpStringContext)
        {
            /*HRESULT SetFuncHelpStringContext(
            [In] int index,
            [In] int dwHelpStringContext);*/
            return Raw2.SetFuncHelpStringContext(index, dwHelpStringContext);
        }

        #endregion
        #region SetVarHelpStringContext

        /// <summary>
        /// Sets a Help context value for a specified variable.
        /// </summary>
        /// <param name="index">[in] The index of the variable.</param>
        /// <param name="dwHelpStringContext">[in] The Help string context for a localized string.</param>
        public void SetVarHelpStringContext(int index, int dwHelpStringContext)
        {
            TrySetVarHelpStringContext(index, dwHelpStringContext).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets a Help context value for a specified variable.
        /// </summary>
        /// <param name="index">[in] The index of the variable.</param>
        /// <param name="dwHelpStringContext">[in] The Help string context for a localized string.</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TrySetVarHelpStringContext(int index, int dwHelpStringContext)
        {
            /*HRESULT SetVarHelpStringContext(
            [In] int index,
            [In] int dwHelpStringContext);*/
            return Raw2.SetVarHelpStringContext(index, dwHelpStringContext);
        }

        #endregion
        #region Invalidate

        public void Invalidate()
        {
            TryInvalidate().ThrowOnNotOK();
        }

        public HRESULT TryInvalidate()
        {
            /*HRESULT Invalidate();*/
            return Raw2.Invalidate();
        }

        #endregion
        #region SetName

        /// <summary>
        /// Sets the name of the typeinfo.
        /// </summary>
        /// <param name="szName">[in] The name to be assigned.</param>
        public void SetName(string szName)
        {
            TrySetName(szName).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the name of the typeinfo.
        /// </summary>
        /// <param name="szName">[in] The name to be assigned.</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TrySetName(string szName)
        {
            /*HRESULT SetName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName);*/
            return Raw2.SetName(szName);
        }

        #endregion
        #endregion
    }
}
