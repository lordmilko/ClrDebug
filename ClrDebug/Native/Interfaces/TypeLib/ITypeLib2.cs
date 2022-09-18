using System;
using System.Runtime.InteropServices;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Provides a managed definition of the <see cref="ITypeLib2"/> interface.
    /// </summary>
    [Guid("00020411-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public unsafe interface ITypeLib2 : ITypeLib
    {
        /// <summary>
        /// Returns the number of type descriptions in the type library.
        /// </summary>
        /// <returns>The number of type descriptions in the type library.</returns>
        [PreserveSig]
        new int GetTypeInfoCount();

        /// <summary>
        /// Retrieves the specified type description in the library.
        /// </summary>
        /// <param name="index">An index of the <see cref="ITypeInfo"/> interface to return.</param>
        /// <param name="ppTI">When this method returns, contains an <see cref="ITypeInfo"/> describing the type referenced by <paramref name="index"/>. This parameter is passed uninitialized.</param>
        [PreserveSig]
        new HRESULT GetTypeInfo(
            int index,
            out ITypeInfo ppTI);

        /// <summary>
        /// Retrieves the type of a type description.
        /// </summary>
        /// <param name="index">The index of the type description within the type library.</param>
        /// <param name="pTKind">When this method returns, contains a reference to the <see cref="TYPEKIND"/> enumeration for the type description. This parameter is passed uninitialized.</param>
        [PreserveSig]
        new HRESULT GetTypeInfoType(
            int index,
            out TYPEKIND pTKind);

        /// <summary>
        /// Retrieves the type description that corresponds to the specified GUID.
        /// </summary>
        /// <param name="guid">The <see cref="Guid"/>, passed by reference, that represents the IID of the <see langword="CLSID"/> interface of the class whose type info is requested.</param>
        /// <param name="ppTInfo">When this method returns, contains the requested <see cref="ITypeInfo"/> interface. This parameter is passed uninitialized.</param>
        [PreserveSig]
        new HRESULT GetTypeInfoOfGuid(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guid,
            [Out] out ITypeInfo ppTInfo);

        /// <summary>
        /// Retrieves the structure that contains the library's attributes.
        /// </summary>
        /// <param name="ppTLibAttr">When this method returns, contains a structure that contains the library's attributes. This parameter is passed uninitialized.</param>
        [PreserveSig]
        new HRESULT GetLibAttr(
            out TLIBATTR* ppTLibAttr);

        /// <summary>
        /// Enables a client compiler to bind to a library's types, variables, constants, and global functions.
        /// </summary>
        /// <param name="ppTComp">When this method returns, contains an <see cref="ITypeComp"/> instance for this <see cref="ITypeLib"/>. This parameter is passed uninitialized.</param>
        [PreserveSig]
        new HRESULT GetTypeComp(
            out ITypeComp ppTComp);

        /// <summary>
        /// Retrieves the library's documentation string, the complete Help file name and path, and the context identifier for the library Help topic in the Help file.
        /// </summary>
        /// <param name="index">An index of the type description whose documentation is to be returned.</param>
        /// <param name="strName">When this method returns, contains a string that specifies the name of the specified item. This parameter is passed uninitialized.</param>
        /// <param name="strDocString">When this method returns, contains the documentation string for the specified item. This parameter is passed uninitialized.</param>
        /// <param name="dwHelpContext">When this method returns, contains the Help context identifier associated with the specified item. This parameter is passed uninitialized.</param>
        /// <param name="strHelpFile">When this method returns, contains a string that specifies the fully qualified name of the Help file. This parameter is passed uninitialized.</param>
        [PreserveSig]
        new HRESULT GetDocumentation(
            int index,
            out string strName,
            out string strDocString,
            out int dwHelpContext,
            out string strHelpFile);

        /// <summary>
        /// Indicates whether a passed-in string contains the name of a type or member described in the library.
        /// </summary>
        /// <param name="szNameBuf">The string to test.</param>
        /// <param name="lHashVal">The hash value of szNameBuf.</param>
        /// <param name="pfName"><see langword="true"/> if szNameBuf was found in the type library; otherwise, <see langword="false"/>.</param>
        [PreserveSig]
        new HRESULT IsName(
            [MarshalAs(UnmanagedType.LPWStr)] string szNameBuf,
            int lHashVal,
            out bool pfName);

        /// <summary>
        /// Finds occurrences of a type description in a type library.
        /// </summary>
        /// <param name="szNameBuf">The name to search for.</param>
        /// <param name="lHashVal">A hash value to speed up the search, computed by the <see langword="LHashValOfNameSys"/> function. If lHashVal is 0, a value is computed.</param>
        /// <param name="ppTInfo">When this method returns, contains an array of pointers to the type descriptions that contain the name specified in szNameBuf. This parameter is passed uninitialized.</param>
        /// <param name="rgMemId">When this method returns, contains an array of the <see langword="MEMBERID"/>s of the found items; rgMemId[i] is the <see langword="MEMBERID"/> that indexes into the type description specified by ppTInfo[i]. This parameter cannot be <see langword="null"/>. This parameter is passed uninitialized.</param>
        /// <param name="pcFound">On entry, a value, passed by reference, that indicates how many instances to look for. For example, pcFound = 1 can be called to find the first occurrence. The search stops when one instance is found.
        /// On exit, indicates the number of instances that were found. If the <see langword="in"/> and <see langword="out"/> values of pcFound are identical, there might be more type descriptions that contain the name.</param>
        [PreserveSig]
        new HRESULT FindName(
            [MarshalAs(UnmanagedType.LPWStr)] string szNameBuf,
            int lHashVal,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4), Out] ITypeInfo[] ppTInfo,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4), Out] int[] rgMemId,
            [In, Out] ref short pcFound);

        /// <summary>
        /// Releases the <see cref="TLIBATTR"/> structure originally obtained from the <see cref="ITypeLib.GetLibAttr"/> method.
        /// </summary>
        /// <param name="pTLibAttr">The <see cref="TLIBATTR"/> structure to release.</param>
        [PreserveSig]
        new void ReleaseTLibAttr(
            TLIBATTR* pTLibAttr);

        /// <summary>
        /// Gets the custom data.
        /// </summary>
        /// <param name="guid">A <see cref="Guid"/>, passed by reference, that is used to identify the data.</param>
        /// <param name="pVarVal">When this method returns, contains an object that specifies where to put the retrieved data. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetCustData(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guid,
            [Out] out object pVarVal);

        /// <summary>
        /// Retrieves the library's documentation string, the complete Help file name and path, the localization context to use, and the context ID for the library Help topic in the Help file.
        /// </summary>
        /// <param name="index">An index of the type description whose documentation is to be returned; if index is -1, the documentation for the library is returned.</param>
        /// <param name="pbstrHelpString">When this method returns, contains a BSTR that specifies the name of the specified item. If the caller does not need the item name, pbstrHelpString can be <see langword="null"/>. This parameter is passed uninitialized.</param>
        /// <param name="pdwHelpStringContext">When this method returns, contains the Help localization context. If the caller does not need the Help context, pdwHelpStringContext can be <see langword="null"/>. This parameter is passed uninitialized.</param>
        /// <param name="pbstrHelpStringDll">When this method returns, contains a BSTR that specifies the fully qualified name of the file containing the DLL used for Help file. If the caller does not need the file name, pbstrHelpStringDll can be <see langword="null"/>. This parameter is passed uninitialized.</param>
        [PreserveSig]
        [LCIDConversion(1)]
        HRESULT GetDocumentation2(
            int index,
            out string pbstrHelpString,
            out int pdwHelpStringContext,
            out string pbstrHelpStringDll);

        /// <summary>
        /// Returns statistics about a type library that are required for efficient sizing of hash tables.
        /// </summary>
        /// <param name="pcUniqueNames">A pointer to a count of unique names. If the caller does not need this information, set to <see langword="null"/>.</param>
        /// <param name="pcchUniqueNames">When this method returns, contains a pointer to a change in the count of unique names. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetLibStatistics(
            IntPtr pcUniqueNames,
            out int pcchUniqueNames);

        /// <summary>
        /// Gets all custom data items for the library.
        /// </summary>
        /// <param name="pCustData">A pointer to <see cref="CUSTDATA"/>, which holds all custom data items.</param>
        [PreserveSig]
        HRESULT GetAllCustData(
            IntPtr pCustData);
    }
}
