using System;
using System.Diagnostics;
using System.Linq;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Provides the managed definition of the <see cref="ITypeLib"/> interface.
    /// </summary>
    public class ComTypeLib : ComObject<ITypeLib>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComTypeLib"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public ComTypeLib(ITypeLib raw) : base(raw)
        {
        }

        #region ITypeLib
        #region TypeInfoCount

        /// <summary>
        /// Returns the number of type descriptions in the type library.
        /// </summary>
        public int TypeInfoCount
        {
            get
            {
                /*int GetTypeInfoCount();*/
                return Raw.GetTypeInfoCount();
            }
        }

        #endregion
        #region LibAttr

        /// <summary>
        /// Retrieves the structure that contains the library's attributes.
        /// </summary>
        public unsafe TLIBATTR* LibAttr
        {
            get
            {
                TLIBATTR* ppTLibAttr;
                TryGetLibAttr(out ppTLibAttr).ThrowOnNotOK();

                return ppTLibAttr;
            }
        }

        /// <summary>
        /// Retrieves the structure that contains the library's attributes.
        /// </summary>
        /// <param name="ppTLibAttr">When this method returns, contains a structure that contains the library's attributes. This parameter is passed uninitialized.</param>
        public unsafe HRESULT TryGetLibAttr(out TLIBATTR* ppTLibAttr)
        {
            /*HRESULT GetLibAttr(
            [Out] out TLIBATTR* ppTLibAttr);*/
            return Raw.GetLibAttr(out ppTLibAttr);
        }

        #endregion
        #region TypeComp

        /// <summary>
        /// Enables a client compiler to bind to a library's types, variables, constants, and global functions.
        /// </summary>
        public TypeComp TypeComp
        {
            get
            {
                TypeComp ppTCompResult;
                TryGetTypeComp(out ppTCompResult).ThrowOnNotOK();

                return ppTCompResult;
            }
        }

        /// <summary>
        /// Enables a client compiler to bind to a library's types, variables, constants, and global functions.
        /// </summary>
        /// <param name="ppTCompResult">When this method returns, contains an instance of a <see cref="ITypeComp"/> instance for this <see cref="ITypeLib"/>. This parameter is passed uninitialized.</param>
        public HRESULT TryGetTypeComp(out TypeComp ppTCompResult)
        {
            /*HRESULT GetTypeComp(
            [Out, MarshalAs(UnmanagedType.Interface)] out ITypeComp ppTComp);*/
            ITypeComp ppTComp;
            HRESULT hr = Raw.GetTypeComp(out ppTComp);

            if (hr == HRESULT.S_OK)
                ppTCompResult = ppTComp == null ? null : new TypeComp(ppTComp);
            else
                ppTCompResult = default(TypeComp);

            return hr;
        }

        #endregion
        #region GetTypeInfo

        /// <summary>
        /// Retrieves the specified type description in the library.
        /// </summary>
        /// <param name="index">The index of the <see cref="ITypeInfo"/> interface to return.</param>
        /// <returns>When this method returns, contains an <see cref="ITypeInfo"/> describing the type referenced by <paramref name="index"/>. This parameter is passed uninitialized.</returns>
        public TypeInfo GetTypeInfo(int index)
        {
            TypeInfo ppTIResult;
            TryGetTypeInfo(index, out ppTIResult).ThrowOnNotOK();

            return ppTIResult;
        }

        /// <summary>
        /// Retrieves the specified type description in the library.
        /// </summary>
        /// <param name="index">The index of the <see cref="ITypeInfo"/> interface to return.</param>
        /// <param name="ppTIResult">When this method returns, contains an <see cref="ITypeInfo"/> describing the type referenced by <paramref name="index"/>. This parameter is passed uninitialized.</param>
        public HRESULT TryGetTypeInfo(int index, out TypeInfo ppTIResult)
        {
            /*HRESULT GetTypeInfo(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.Interface)] out ITypeInfo ppTI);*/
            ITypeInfo ppTI;
            HRESULT hr = Raw.GetTypeInfo(index, out ppTI);

            if (hr == HRESULT.S_OK)
                ppTIResult = ppTI == null ? null : new TypeInfo(ppTI);
            else
                ppTIResult = default(TypeInfo);

            return hr;
        }

        #endregion
        #region GetTypeInfoType

        /// <summary>
        /// Retrieves the type of a type description.
        /// </summary>
        /// <param name="index">The index of the type description within the type library.</param>
        /// <returns>When this method returns, contains a reference to the <see cref="TYPEKIND"/> enumeration for the type description. This parameter is passed uninitialized.</returns>
        public TYPEKIND GetTypeInfoType(int index)
        {
            TYPEKIND pTKind;
            TryGetTypeInfoType(index, out pTKind).ThrowOnNotOK();

            return pTKind;
        }

        /// <summary>
        /// Retrieves the type of a type description.
        /// </summary>
        /// <param name="index">The index of the type description within the type library.</param>
        /// <param name="pTKind">When this method returns, contains a reference to the <see cref="TYPEKIND"/> enumeration for the type description. This parameter is passed uninitialized.</param>
        public HRESULT TryGetTypeInfoType(int index, out TYPEKIND pTKind)
        {
            /*HRESULT GetTypeInfoType(
            [In] int index,
            [Out] out TYPEKIND pTKind);*/
            return Raw.GetTypeInfoType(index, out pTKind);
        }

        #endregion
        #region GetTypeInfoOfGuid

        /// <summary>
        /// Retrieves the type description that corresponds to the specified GUID.
        /// </summary>
        /// <param name="guid">The IID of the interface or CLSID of the class whose type info is requested.</param>
        /// <returns>When this method returns, contains the requested <see cref="ITypeInfo"/> interface. This parameter is passed uninitialized.</returns>
        public TypeInfo GetTypeInfoOfGuid(Guid guid)
        {
            TypeInfo ppTInfoResult;
            TryGetTypeInfoOfGuid(guid, out ppTInfoResult).ThrowOnNotOK();

            return ppTInfoResult;
        }

        /// <summary>
        /// Retrieves the type description that corresponds to the specified GUID.
        /// </summary>
        /// <param name="guid">The IID of the interface or CLSID of the class whose type info is requested.</param>
        /// <param name="ppTInfoResult">When this method returns, contains the requested <see cref="ITypeInfo"/> interface. This parameter is passed uninitialized.</param>
        public HRESULT TryGetTypeInfoOfGuid(Guid guid, out TypeInfo ppTInfoResult)
        {
            /*HRESULT GetTypeInfoOfGuid(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guid,
            [Out, MarshalAs(UnmanagedType.Interface)] out ITypeInfo ppTInfo);*/
            ITypeInfo ppTInfo;
            HRESULT hr = Raw.GetTypeInfoOfGuid(guid, out ppTInfo);

            if (hr == HRESULT.S_OK)
                ppTInfoResult = ppTInfo == null ? null : new TypeInfo(ppTInfo);
            else
                ppTInfoResult = default(TypeInfo);

            return hr;
        }

        #endregion
        #region GetDocumentation

        /// <summary>
        /// Retrieves the library's documentation string, the complete Help file name and path, and the context identifier for the library Help topic in the Help file.
        /// </summary>
        /// <param name="index">The index of the type description whose documentation is to be returned.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetDocumentationResult GetDocumentation(int index)
        {
            GetDocumentationResult result;
            TryGetDocumentation(index, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Retrieves the library's documentation string, the complete Help file name and path, and the context identifier for the library Help topic in the Help file.
        /// </summary>
        /// <param name="index">The index of the type description whose documentation is to be returned.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetDocumentation(int index, out GetDocumentationResult result)
        {
            /*HRESULT GetDocumentation(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.BStr)] out string strName,
            [Out, MarshalAs(UnmanagedType.BStr)] out string strDocString,
            [Out] out int dwHelpContext,
            [Out, MarshalAs(UnmanagedType.BStr)] out string strHelpFile);*/
            string strName;
            string strDocString;
            int dwHelpContext;
            string strHelpFile;
            HRESULT hr = Raw.GetDocumentation(index, out strName, out strDocString, out dwHelpContext, out strHelpFile);

            if (hr == HRESULT.S_OK)
                result = new GetDocumentationResult(strName, strDocString, dwHelpContext, strHelpFile);
            else
                result = default(GetDocumentationResult);

            return hr;
        }

        #endregion
        #region IsName

        /// <summary>
        /// Indicates whether a passed-in string contains the name of a type or member described in the library.
        /// </summary>
        /// <param name="szNameBuf">The string to test. This is an in/out parameter.</param>
        /// <param name="lHashVal">The hash value of <paramref name="szNameBuf"/>.</param>
        /// <returns><see langword="true"/> if <paramref name="szNameBuf"/> was found in the type library; otherwise, <see langword="false"/>.</returns>
        public bool IsName(string szNameBuf, int lHashVal)
        {
            bool pfName;
            TryIsName(szNameBuf, lHashVal, out pfName).ThrowOnNotOK();

            return pfName;
        }

        /// <summary>
        /// Indicates whether a passed-in string contains the name of a type or member described in the library.
        /// </summary>
        /// <param name="szNameBuf">The string to test. This is an in/out parameter.</param>
        /// <param name="lHashVal">The hash value of <paramref name="szNameBuf"/>.</param>
        /// <param name="pfName"><see langword="true"/> if <paramref name="szNameBuf"/> was found in the type library; otherwise, <see langword="false"/>.</param>
        public HRESULT TryIsName(string szNameBuf, int lHashVal, out bool pfName)
        {
            /*HRESULT IsName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szNameBuf,
            [In] int lHashVal,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pfName);*/
            return Raw.IsName(szNameBuf, lHashVal, out pfName);
        }

        #endregion
        #region FindName

        /// <summary>
        /// Finds occurrences of a type description in a type library.
        /// </summary>
        /// <param name="szNameBuf">The name to search for. This is an in/out parameter.</param>
        /// <param name="lHashVal">A hash value to speed up the search, computed by the <see langword="LHashValOfNameSys"/> function. If lHashVal is 0, a value is computed.</param>
        /// <param name="pcFound">On entry, indicates how many instances to look for. For example, pcFound = 1 can be called to find the first occurrence. The search stops when one instance is found.
        /// On exit, indicates the number of instances that were found. If the <see langword="in"/> and <see langword="out"/> values of pcFound are identical, there might be more type descriptions that contain the name.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public FindNameResult FindName(string szNameBuf, int lHashVal, short pcFound)
        {
            FindNameResult result;
            TryFindName(szNameBuf, lHashVal, pcFound, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Finds occurrences of a type description in a type library.
        /// </summary>
        /// <param name="szNameBuf">The name to search for. This is an in/out parameter.</param>
        /// <param name="lHashVal">A hash value to speed up the search, computed by the <see langword="LHashValOfNameSys"/> function. If lHashVal is 0, a value is computed.</param>
        /// <param name="pcFound">On entry, indicates how many instances to look for. For example, pcFound = 1 can be called to find the first occurrence. The search stops when one instance is found.
        /// On exit, indicates the number of instances that were found. If the <see langword="in"/> and <see langword="out"/> values of pcFound are identical, there might be more type descriptions that contain the name.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryFindName(string szNameBuf, int lHashVal, short pcFound, out FindNameResult result)
        {
            /*HRESULT FindName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szNameBuf,
            [In] int lHashVal,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4), Out] ITypeInfo[] ppTInfo,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4), Out] int[] rgMemId,
            [In, Out] ref short pcFound);*/
            ITypeInfo[] ppTInfo = new ITypeInfo[(int) pcFound];
            int[] rgMemId = new int[(int) pcFound];
            HRESULT hr = Raw.FindName(szNameBuf, lHashVal, ppTInfo, rgMemId, ref pcFound);

            if (hr == HRESULT.S_OK)
            {
                if (ppTInfo.Length != pcFound)
                    Array.Resize(ref ppTInfo, (int) pcFound);

                if (rgMemId.Length != pcFound)
                    Array.Resize(ref rgMemId, (int) pcFound);

                result = new FindNameResult(ppTInfo.Select(v => v == null ? null : new TypeInfo(v)).ToArray(), rgMemId);
            }
            else
                result = default(FindNameResult);

            return hr;
        }

        #endregion
        #region ReleaseTLibAttr

        /// <summary>
        /// Releases the <see cref="TLIBATTR"/> structure originally obtained from the <see cref="LibAttr"/> property.
        /// </summary>
        /// <param name="pTLibAttr">The <see cref="TLIBATTR"/> structure to release.</param>
        public unsafe void ReleaseTLibAttr(TLIBATTR* pTLibAttr)
        {
            /*void ReleaseTLibAttr(
            [In] TLIBATTR* pTLibAttr);*/
            Raw.ReleaseTLibAttr(pTLibAttr);
        }

        #endregion
        #endregion
        #region ITypeLib2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ITypeLib2 Raw2 => (ITypeLib2) Raw;

        #region GetCustData

        /// <summary>
        /// Gets the custom data.
        /// </summary>
        /// <param name="guid">A <see cref="Guid"/>, passed by reference, that is used to identify the data.</param>
        /// <returns>When this method returns, contains an object that specifies where to put the retrieved data. This parameter is passed uninitialized.</returns>
        public object GetCustData(Guid guid)
        {
            object pVarVal;
            TryGetCustData(guid, out pVarVal).ThrowOnNotOK();

            return pVarVal;
        }

        /// <summary>
        /// Gets the custom data.
        /// </summary>
        /// <param name="guid">A <see cref="Guid"/>, passed by reference, that is used to identify the data.</param>
        /// <param name="pVarVal">When this method returns, contains an object that specifies where to put the retrieved data. This parameter is passed uninitialized.</param>
        public HRESULT TryGetCustData(Guid guid, out object pVarVal)
        {
            /*HRESULT GetCustData(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guid,
            [Out] out object pVarVal);*/
            return Raw2.GetCustData(guid, out pVarVal);
        }

        #endregion
        #region GetDocumentation2

        /// <summary>
        /// Retrieves the library's documentation string, the complete Help file name and path, the localization context to use, and the context ID for the library Help topic in the Help file.
        /// </summary>
        /// <param name="index">An index of the type description whose documentation is to be returned; if index is -1, the documentation for the library is returned.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetDocumentation2Result GetDocumentation2(int index)
        {
            GetDocumentation2Result result;
            TryGetDocumentation2(index, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Retrieves the library's documentation string, the complete Help file name and path, the localization context to use, and the context ID for the library Help topic in the Help file.
        /// </summary>
        /// <param name="index">An index of the type description whose documentation is to be returned; if index is -1, the documentation for the library is returned.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetDocumentation2(int index, out GetDocumentation2Result result)
        {
            /*HRESULT GetDocumentation2(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pbstrHelpString,
            [Out] out int pdwHelpStringContext,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pbstrHelpStringDll);*/
            string pbstrHelpString;
            int pdwHelpStringContext;
            string pbstrHelpStringDll;
            HRESULT hr = Raw2.GetDocumentation2(index, out pbstrHelpString, out pdwHelpStringContext, out pbstrHelpStringDll);

            if (hr == HRESULT.S_OK)
                result = new GetDocumentation2Result(pbstrHelpString, pdwHelpStringContext, pbstrHelpStringDll);
            else
                result = default(GetDocumentation2Result);

            return hr;
        }

        #endregion
        #region GetLibStatistics

        /// <summary>
        /// Returns statistics about a type library that are required for efficient sizing of hash tables.
        /// </summary>
        /// <param name="pcUniqueNames">A pointer to a count of unique names. If the caller does not need this information, set to <see langword="null"/>.</param>
        /// <returns>When this method returns, contains a pointer to a change in the count of unique names. This parameter is passed uninitialized.</returns>
        public int GetLibStatistics(IntPtr pcUniqueNames)
        {
            int pcchUniqueNames;
            TryGetLibStatistics(pcUniqueNames, out pcchUniqueNames).ThrowOnNotOK();

            return pcchUniqueNames;
        }

        /// <summary>
        /// Returns statistics about a type library that are required for efficient sizing of hash tables.
        /// </summary>
        /// <param name="pcUniqueNames">A pointer to a count of unique names. If the caller does not need this information, set to <see langword="null"/>.</param>
        /// <param name="pcchUniqueNames">When this method returns, contains a pointer to a change in the count of unique names. This parameter is passed uninitialized.</param>
        public HRESULT TryGetLibStatistics(IntPtr pcUniqueNames, out int pcchUniqueNames)
        {
            /*HRESULT GetLibStatistics(
            [In] IntPtr pcUniqueNames,
            [Out] out int pcchUniqueNames);*/
            return Raw2.GetLibStatistics(pcUniqueNames, out pcchUniqueNames);
        }

        #endregion
        #region GetAllCustData

        /// <summary>
        /// Gets all custom data items for the library.
        /// </summary>
        /// <param name="pCustData">A pointer to <see cref="CUSTDATA"/>, which holds all custom data items.</param>
        public void GetAllCustData(IntPtr pCustData)
        {
            TryGetAllCustData(pCustData).ThrowOnNotOK();
        }

        /// <summary>
        /// Gets all custom data items for the library.
        /// </summary>
        /// <param name="pCustData">A pointer to <see cref="CUSTDATA"/>, which holds all custom data items.</param>
        public HRESULT TryGetAllCustData(IntPtr pCustData)
        {
            /*HRESULT GetAllCustData(
            [In] IntPtr pCustData);*/
            return Raw2.GetAllCustData(pCustData);
        }

        #endregion
        #endregion
    }
}
