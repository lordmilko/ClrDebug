﻿using System;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Represents a type library, the data that describes a set of objects. A type library can be a stand-alone binary file (.TLB),
    /// a resource in a dynamic link library or executable file (.DLL, .OLB, or .EXE).
    /// </summary>
    [Guid("00020402-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public unsafe partial interface ITypeLib
    {
        /// <summary>
        /// Returns the number of type descriptions in the type library.
        /// </summary>
        /// <returns>The number of type descriptions in the type library.</returns>
        [PreserveSig]
        int GetTypeInfoCount();

        /// <summary>
        /// Retrieves the specified type description in the library.
        /// </summary>
        /// <param name="index">The index of the <see cref="ITypeInfo"/> interface to return.</param>
        /// <param name="ppTI">When this method returns, contains an <see cref="ITypeInfo"/> describing the type referenced by <paramref name="index"/>. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetTypeInfo(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.Interface)] out ITypeInfo ppTI);

        /// <summary>
        /// Retrieves the type of a type description.
        /// </summary>
        /// <param name="index">The index of the type description within the type library.</param>
        /// <param name="pTKind">When this method returns, contains a reference to the <see cref="TYPEKIND"/> enumeration for the type description. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetTypeInfoType(
            [In] int index,
            [Out] out TYPEKIND pTKind);

        /// <summary>
        /// Retrieves the type description that corresponds to the specified GUID.
        /// </summary>
        /// <param name="guid">The IID of the interface or CLSID of the class whose type info is requested.</param>
        /// <param name="ppTInfo">When this method returns, contains the requested <see cref="ITypeInfo"/> interface. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetTypeInfoOfGuid(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid guid,
            [Out, MarshalAs(UnmanagedType.Interface)] out ITypeInfo ppTInfo);

        /// <summary>
        /// Retrieves the structure that contains the library's attributes.
        /// </summary>
        /// <param name="ppTLibAttr">When this method returns, contains a structure that contains the library's attributes. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetLibAttr(
            [Out] out TLIBATTR* ppTLibAttr);

        /// <summary>
        /// Enables a client compiler to bind to a library's types, variables, constants, and global functions.
        /// </summary>
        /// <param name="ppTComp">When this method returns, contains an instance of a <see cref="ITypeComp"/> instance for this <see cref="ITypeLib"/>. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetTypeComp(
            [Out, MarshalAs(UnmanagedType.Interface)] out ITypeComp ppTComp);

        /// <summary>
        /// Retrieves the library's documentation string, the complete Help file name and path, and the context identifier for the library Help topic in the Help file.
        /// </summary>
        /// <param name="index">The index of the type description whose documentation is to be returned.</param>
        /// <param name="strName">When this method returns, contains a string that represents the name of the specified item. This parameter is passed uninitialized.</param>
        /// <param name="strDocString">When this method returns, contains a string that represents the documentation string for the specified item. This parameter is passed uninitialized.</param>
        /// <param name="dwHelpContext">When this method returns, contains the Help context identifier associated with the specified item. This parameter is passed uninitialized.</param>
        /// <param name="strHelpFile">When this method returns, contains a string that represents the fully qualified name of the Help file. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetDocumentation(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.BStr)] out string strName,
            [Out, MarshalAs(UnmanagedType.BStr)] out string strDocString,
            [Out] out int dwHelpContext,
            [Out, MarshalAs(UnmanagedType.BStr)] out string strHelpFile);

        /// <summary>
        /// Indicates whether a passed-in string contains the name of a type or member described in the library.
        /// </summary>
        /// <param name="szNameBuf">The string to test. This is an in/out parameter.</param>
        /// <param name="lHashVal">The hash value of <paramref name="szNameBuf"/>.</param>
        /// <param name="pfName"><see langword="true"/> if <paramref name="szNameBuf"/> was found in the type library; otherwise, <see langword="false"/>.</param>
        [PreserveSig]
        HRESULT IsName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szNameBuf,
            [In] int lHashVal,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pfName);

        /// <summary>
        /// Finds occurrences of a type description in a type library.
        /// </summary>
        /// <param name="szNameBuf">The name to search for. This is an in/out parameter.</param>
        /// <param name="lHashVal">A hash value to speed up the search, computed by the <see langword="LHashValOfNameSys"/> function. If lHashVal is 0, a value is computed.</param>
        /// <param name="ppTInfo">When this method returns, contains an array of pointers to the type descriptions that contain the name specified in szNameBuf. This parameter is passed uninitialized.</param>
        /// <param name="rgMemId">An array of the <see langword="MEMBERID"/> 's of the found items; rgMemId[i] is the <see langword="MEMBERID"/> that indexes into the type description specified by ppTInfo[i]. Cannot be <see langword="null"/>.</param>
        /// <param name="pcFound">On entry, indicates how many instances to look for. For example, pcFound = 1 can be called to find the first occurrence. The search stops when one instance is found.
        /// On exit, indicates the number of instances that were found. If the <see langword="in"/> and <see langword="out"/> values of pcFound are identical, there might be more type descriptions that contain the name.</param>
        [PreserveSig]
        HRESULT FindName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szNameBuf,
            [In] int lHashVal,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4), SRI.Out] ITypeInfo[] ppTInfo,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4), SRI.Out] int[] rgMemId,
            [In, Out] ref short pcFound);

        /// <summary>
        /// Releases the <see cref="TLIBATTR"/> structure originally obtained from the <see cref="GetLibAttr"/> method.
        /// </summary>
        /// <param name="pTLibAttr">The <see cref="TLIBATTR"/> structure to release.</param>
        [PreserveSig]
        void ReleaseTLibAttr(
            [In] TLIBATTR* pTLibAttr);
    }
}
