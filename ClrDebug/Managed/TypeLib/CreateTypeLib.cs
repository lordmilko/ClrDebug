using System;
using System.Diagnostics;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Provides the methods for creating and managing the component or file that contains type information. Type libraries are created from type descriptions using the MIDL compiler.<para/>
    /// These type libraries are accessed through the ITypeLib interface.
    /// </summary>
    public class CreateTypeLib : ComObject<ICreateTypeLib>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTypeLib"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CreateTypeLib(ICreateTypeLib raw) : base(raw)
        {
        }

        #region ICreateTypeLib
        #region CreateTypeInfo

        /// <summary>
        /// Creates a new type description instance within the type library.
        /// </summary>
        /// <param name="szName">[in] The name of the new type.</param>
        /// <param name="tkind">[in] TYPEKIND of the type description to be created.</param>
        /// <returns>[out] The type description.</returns>
        /// <remarks>
        /// Use <see cref="ICreateTypeLib"/> to create a new type description instance within the library. An error is returned
        /// if the specified name already appears in the library. Valid tkind values are described in TYPEKIND. To get the
        /// type information of the type description that is being created, call IUnknown::QueryInterface(IID_ITypeInfo, ...)
        /// on the returned ICreateTypeLib. This type information can be used by other type descriptions that reference it
        /// by using <see cref="CreateTypeInfo.AddRefTypeInfo"/>.
        /// </remarks>
        public CreateTypeInfo CreateTypeInfo(string szName, TYPEKIND tkind)
        {
            CreateTypeInfo ppCTInfoResult;
            TryCreateTypeInfo(szName, tkind, out ppCTInfoResult).ThrowOnNotOK();

            return ppCTInfoResult;
        }

        /// <summary>
        /// Creates a new type description instance within the type library.
        /// </summary>
        /// <param name="szName">[in] The name of the new type.</param>
        /// <param name="tkind">[in] TYPEKIND of the type description to be created.</param>
        /// <param name="ppCTInfoResult">[out] The type description.</param>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// Use <see cref="ICreateTypeLib"/> to create a new type description instance within the library. An error is returned
        /// if the specified name already appears in the library. Valid tkind values are described in TYPEKIND. To get the
        /// type information of the type description that is being created, call IUnknown::QueryInterface(IID_ITypeInfo, ...)
        /// on the returned ICreateTypeLib. This type information can be used by other type descriptions that reference it
        /// by using <see cref="CreateTypeInfo.AddRefTypeInfo"/>.
        /// </remarks>
        public HRESULT TryCreateTypeInfo(string szName, TYPEKIND tkind, out CreateTypeInfo ppCTInfoResult)
        {
            /*HRESULT CreateTypeInfo(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName,
            [In] TYPEKIND tkind,
            [Out] out ICreateTypeInfo ppCTInfo);*/
            ICreateTypeInfo ppCTInfo;
            HRESULT hr = Raw.CreateTypeInfo(szName, tkind, out ppCTInfo);

            if (hr == HRESULT.S_OK)
                ppCTInfoResult = ppCTInfo == null ? null : new CreateTypeInfo(ppCTInfo);
            else
                ppCTInfoResult = default(CreateTypeInfo);

            return hr;
        }

        #endregion
        #region SetName

        /// <summary>
        /// Sets the name of the type library.
        /// </summary>
        /// <param name="szName">[in] The name to be assigned to the library.</param>
        public void SetName(string szName)
        {
            TrySetName(szName).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the name of the type library.
        /// </summary>
        /// <param name="szName">[in] The name to be assigned to the library.</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TrySetName(string szName)
        {
            /*HRESULT SetName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName);*/
            return Raw.SetName(szName);
        }

        #endregion
        #region SetVersion

        /// <summary>
        /// Sets the major and minor version numbers of the type library.
        /// </summary>
        /// <param name="wMajorVerNum">[in] The major version number for the library.</param>
        /// <param name="wMinorVerNum">[in] The minor version number for the library.</param>
        public void SetVersion(short wMajorVerNum, short wMinorVerNum)
        {
            TrySetVersion(wMajorVerNum, wMinorVerNum).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the major and minor version numbers of the type library.
        /// </summary>
        /// <param name="wMajorVerNum">[in] The major version number for the library.</param>
        /// <param name="wMinorVerNum">[in] The minor version number for the library.</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TrySetVersion(short wMajorVerNum, short wMinorVerNum)
        {
            /*HRESULT SetVersion(
            [In] short wMajorVerNum,
            [In] short wMinorVerNum);*/
            return Raw.SetVersion(wMajorVerNum, wMinorVerNum);
        }

        #endregion
        #region SetGuid

        /// <summary>
        /// Sets the universal unique identifier (UUID) associated with the type library (Also known as the globally unique identifier (GUID)).
        /// </summary>
        /// <param name="guid">[in] The globally unique identifier to be assigned to the library.</param>
        public void SetGuid(Guid guid)
        {
            TrySetGuid(guid).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the universal unique identifier (UUID) associated with the type library (Also known as the globally unique identifier (GUID)).
        /// </summary>
        /// <param name="guid">[in] The globally unique identifier to be assigned to the library.</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TrySetGuid(Guid guid)
        {
            /*HRESULT SetGuid(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guid);*/
            return Raw.SetGuid(guid);
        }

        #endregion
        #region SetDocString

        /// <summary>
        /// Sets the documentation string associated with the library.
        /// </summary>
        /// <param name="szDoc">[in] A brief description of the type library.</param>
        /// <remarks>
        /// The documentation string is a brief description of the library intended for use by type information browsing tools.
        /// </remarks>
        public void SetDocString(string szDoc)
        {
            TrySetDocString(szDoc).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the documentation string associated with the library.
        /// </summary>
        /// <param name="szDoc">[in] A brief description of the type library.</param>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// The documentation string is a brief description of the library intended for use by type information browsing tools.
        /// </remarks>
        public HRESULT TrySetDocString(string szDoc)
        {
            /*HRESULT SetDocString(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szDoc);*/
            return Raw.SetDocString(szDoc);
        }

        #endregion
        #region SetHelpFileName

        /// <summary>
        /// Sets the name of the Help file.
        /// </summary>
        /// <param name="szHelpFileName">[in] The name of the Help file for the library.</param>
        /// <remarks>
        /// Each type library can reference a single Help file. The GetDocumentation method of the created ITypeLib returns
        /// a fully qualified path for the Help file, which is formed by appending the name passed into szHelpFileName to the
        /// registered Help directory for the type library. The Help directory is registered under: \TYPELIB&amp;lt;guid of
        /// library&amp;lt;Major.Minor version \HELPDIR
        /// </remarks>
        public void SetHelpFileName(string szHelpFileName)
        {
            TrySetHelpFileName(szHelpFileName).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the name of the Help file.
        /// </summary>
        /// <param name="szHelpFileName">[in] The name of the Help file for the library.</param>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// Each type library can reference a single Help file. The GetDocumentation method of the created ITypeLib returns
        /// a fully qualified path for the Help file, which is formed by appending the name passed into szHelpFileName to the
        /// registered Help directory for the type library. The Help directory is registered under: \TYPELIB&amp;lt;guid of
        /// library&amp;lt;Major.Minor version \HELPDIR
        /// </remarks>
        public HRESULT TrySetHelpFileName(string szHelpFileName)
        {
            /*HRESULT SetHelpFileName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szHelpFileName);*/
            return Raw.SetHelpFileName(szHelpFileName);
        }

        #endregion
        #region SetHelpContext

        /// <summary>
        /// Sets the Help context ID for retrieving general Help information for the type library.
        /// </summary>
        /// <param name="dwHelpContext">[in] The Help context ID.</param>
        /// <remarks>
        /// Calling SetHelpContext with a Help context of zero is equivalent to not calling it at all, because zero indicates
        /// a null Help context.
        /// </remarks>
        public void SetHelpContext(int dwHelpContext)
        {
            TrySetHelpContext(dwHelpContext).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the Help context ID for retrieving general Help information for the type library.
        /// </summary>
        /// <param name="dwHelpContext">[in] The Help context ID.</param>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// Calling SetHelpContext with a Help context of zero is equivalent to not calling it at all, because zero indicates
        /// a null Help context.
        /// </remarks>
        public HRESULT TrySetHelpContext(int dwHelpContext)
        {
            /*HRESULT SetHelpContext(
            [In] int dwHelpContext);*/
            return Raw.SetHelpContext(dwHelpContext);
        }

        #endregion
        #region SetLcid

        /// <summary>
        /// Sets the binary Microsoft national language ID associated with the library.
        /// </summary>
        /// <param name="lcid">[in] The locale ID for the type library.</param>
        /// <remarks>
        /// For more information on national language IDs, see Supporting Multiple National Languages and the National Language
        /// Support (NLS) API.
        /// </remarks>
        public void SetLcid(int lcid)
        {
            TrySetLcid(lcid).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the binary Microsoft national language ID associated with the library.
        /// </summary>
        /// <param name="lcid">[in] The locale ID for the type library.</param>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// For more information on national language IDs, see Supporting Multiple National Languages and the National Language
        /// Support (NLS) API.
        /// </remarks>
        public HRESULT TrySetLcid(int lcid)
        {
            /*HRESULT SetLcid(
            [In] int lcid);*/
            return Raw.SetLcid(lcid);
        }

        #endregion
        #region SetLibFlags

        /// <summary>
        /// Sets library flags.
        /// </summary>
        /// <param name="uLibFlags">[in] The flags to set.</param>
        /// <remarks>
        /// Valid uLibFlags values are listed in LIBFLAGS.
        /// </remarks>
        public void SetLibFlags(LIBFLAGS uLibFlags)
        {
            TrySetLibFlags(uLibFlags).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets library flags.
        /// </summary>
        /// <param name="uLibFlags">[in] The flags to set.</param>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// Valid uLibFlags values are listed in LIBFLAGS.
        /// </remarks>
        public HRESULT TrySetLibFlags(LIBFLAGS uLibFlags)
        {
            /*HRESULT SetLibFlags(
            [In] LIBFLAGS uLibFlags);*/
            return Raw.SetLibFlags(uLibFlags);
        }

        #endregion
        #region SaveAllChanges

        /// <summary>
        /// Saves the <see cref="ICreateTypeLib"/> instance following the layout of type information.
        /// </summary>
        /// <remarks>
        /// You should not call any other <see cref="ICreateTypeLib"/> methods after calling SaveAllChanges.
        /// </remarks>
        public void SaveAllChanges()
        {
            TrySaveAllChanges().ThrowOnNotOK();
        }

        /// <summary>
        /// Saves the <see cref="ICreateTypeLib"/> instance following the layout of type information.
        /// </summary>
        /// <returns>This method can return one of these values.</returns>
        /// <remarks>
        /// You should not call any other <see cref="ICreateTypeLib"/> methods after calling SaveAllChanges.
        /// </remarks>
        public HRESULT TrySaveAllChanges()
        {
            /*HRESULT SaveAllChanges();*/
            return Raw.SaveAllChanges();
        }

        #endregion
        #endregion
        #region ICreateTypeLib2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ICreateTypeLib2 Raw2 => (ICreateTypeLib2) Raw;

        #region DeleteTypeInfo

        /// <summary>
        /// Deletes a specified type information from the type library.
        /// </summary>
        /// <param name="szName">[in] The name of the type information to remove.</param>
        public void DeleteTypeInfo(string szName)
        {
            TryDeleteTypeInfo(szName).ThrowOnNotOK();
        }

        /// <summary>
        /// Deletes a specified type information from the type library.
        /// </summary>
        /// <param name="szName">[in] The name of the type information to remove.</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TryDeleteTypeInfo(string szName)
        {
            /*HRESULT DeleteTypeInfo(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szName);*/
            return Raw2.DeleteTypeInfo(szName);
        }

        #endregion
        #region SetCustData

        /// <summary>
        /// Sets a value to custom data.
        /// </summary>
        /// <param name="guid">[in] The unique identifier for the data.</param>
        /// <param name="pVarVal">[in] The data to store (any variant except an object).</param>
        public void SetCustData(Guid guid, object pVarVal)
        {
            TrySetCustData(guid, pVarVal).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets a value to custom data.
        /// </summary>
        /// <param name="guid">[in] The unique identifier for the data.</param>
        /// <param name="pVarVal">[in] The data to store (any variant except an object).</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TrySetCustData(Guid guid, object pVarVal)
        {
            /*HRESULT SetCustData(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guid,
            [In, MarshalAs(UnmanagedType.Struct)] ref object pVarVal);*/
            return Raw2.SetCustData(guid, pVarVal);
        }

        #endregion
        #region SetHelpStringContext

        /// <summary>
        /// Sets the Help string context number.
        /// </summary>
        /// <param name="dwHelpStringContext">[in] The Help string context number.</param>
        public void SetHelpStringContext(int dwHelpStringContext)
        {
            TrySetHelpStringContext(dwHelpStringContext).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the Help string context number.
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
        #region SetHelpStringDll

        /// <summary>
        /// Sets the DLL name to be used for Help string lookup (for localization purposes).
        /// </summary>
        /// <param name="szFileName">[in] The DLL file name.</param>
        public void SetHelpStringDll(string szFileName)
        {
            TrySetHelpStringDll(szFileName).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the DLL name to be used for Help string lookup (for localization purposes).
        /// </summary>
        /// <param name="szFileName">[in] The DLL file name.</param>
        /// <returns>This method can return one of these values.</returns>
        public HRESULT TrySetHelpStringDll(string szFileName)
        {
            /*HRESULT SetHelpStringDll(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szFileName);*/
            return Raw2.SetHelpStringDll(szFileName);
        }

        #endregion
        #endregion
    }
}
