using System;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// This section describes ITypeInfo, an interface typically used for reading information about objects. For example, an object
    /// browser tool can use ITypeInfo to extract information about the characteristics and capabilities of objects from type libraries.
    /// </summary>
    [Guid("00020401-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public unsafe partial interface ITypeInfo
    {
        /// <summary>
        /// Retrieves a <see cref="TYPEATTR"/> structure that contains the attributes of the type description.<para/>
        /// This value must be released by calling <see cref="ReleaseTypeAttr"/>.
        /// </summary>
        /// <param name="ppTypeAttr">When this method returns, contains a reference to the structure that contains the attributes of this type description. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetTypeAttr(
            [Out] out TYPEATTR* ppTypeAttr);

        /// <summary>
        /// Retrieves the ITypeComp interface for the type description, which enables a client compiler to bind to the type description's members.
        /// </summary>
        /// <param name="ppTComp">When this method returns, contains a reference to the ITypeComp interface of the containing type library. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetTypeComp(
            [Out, MarshalAs(UnmanagedType.Interface)] out ITypeComp ppTComp);

        /// <summary>
        /// Retrieves the <see cref="FUNCDESC"/> structure that contains information about a specified function.<para/>
        /// This value must be released by calling <see cref="ReleaseFuncDesc"/>.
        /// </summary>
        /// <param name="index">The index of the function description to return.</param>
        /// <param name="ppFuncDesc">When this method returns, contains a reference to a FUNCDESC structure that describes the specified function. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetFuncDesc(
            [In] int index,
            [Out] out FUNCDESC* ppFuncDesc);

        /// <summary>
        /// Retrieves a <see cref="VARDESC"/> structure that describes the specified variable.
        /// This value must be released by calling <see cref="ReleaseVarDesc"/>.
        /// </summary>
        /// <param name="index">The index of the variable description to return.</param>
        /// <param name="ppVarDesc">When this method returns, contains a reference to the VARDESC structure that describes the specified variable. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetVarDesc(
            [In] int index,
            [Out] out VARDESC* ppVarDesc);

        /// <summary>
        /// Retrieves the variable with the specified member ID (or the name of the property or method and its parameters) that corresponds to the specified function ID.
        /// </summary>
        /// <param name="memid">The ID of the member whose name (or names) is to be returned.</param>
        /// <param name="rgBstrNames">When this method returns, contains the name (or names) associated with the member. This parameter is passed uninitialized.</param>
        /// <param name="cMaxNames">The length of the rgBstrNames array.</param>
        /// <param name="pcNames">When this method returns, contains the number of names in the rgBstrNames array. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetNames(
            [In] int memid,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.BStr, SizeParamIndex = 2)] string[] rgBstrNames,
            [In] int cMaxNames,
            [Out] out int pcNames);

        /// <summary>
        /// Retrieves the type description of the implemented interface types if a type description describes a COM class.
        /// </summary>
        /// <param name="index">The index of the implemented type whose handle is returned.</param>
        /// <param name="href">When this method returns, contains a reference to a handle for the implemented interface. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetRefTypeOfImplType(
            [In] int index,
            [Out] out int href);

        /// <summary>
        /// Retrieves the <see cref="IMPLTYPEFLAGS"/> value for one implemented interface or base interface in a type description.
        /// </summary>
        /// <param name="index">The index of the implemented interface or base interface.</param>
        /// <param name="pImplTypeFlags">When this method returns, contains a reference to the IMPLTYPEFLAGS enumeration. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetImplTypeFlags(
            [In] int index,
            [Out] out IMPLTYPEFLAGS pImplTypeFlags);

        /// <summary>
        /// Maps between member names and member IDs, and parameter names and parameter IDs.
        /// </summary>
        /// <param name="rgszNames">An array of names to map.</param>
        /// <param name="cNames">The count of names to map.</param>
        /// <param name="pMemId">When this method returns, contains a reference to an array in which name mappings are placed. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetIDsOfNames(
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 1)] string[] rgszNames,
            [In] int cNames,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] pMemId);

        /// <summary>
        /// Invokes a method, or accesses a property of an object, that implements the interface described by the type description.
        /// </summary>
        /// <param name="pvInstance">A reference to the interface described by this type description.</param>
        /// <param name="memid">A value that identifies the interface member.</param>
        /// <param name="wFlags">Flags that describe the context of the invoke call.</param>
        /// <param name="pDispParams">A reference to a structure that contains an array of arguments, an array of DISPIDs for named arguments, and counts of the number of elements in each array.</param>
        /// <param name="pVarResult">A reference to the location at which the result is to be stored. If wFlags specifies DISPATCH_PROPERTYPUT or DISPATCH_PROPERTYPUTREF, pVarResult is ignored. Set to null if no result is desired.</param>
        /// <param name="pExcepInfo">A pointer to an exception information structure, which is filled in only if DISP_E_EXCEPTION is returned.</param>
        /// <param name="puArgErr">If Invoke returns DISP_E_TYPEMISMATCH, puArgErr indicates the index within rgvarg of the argument with the incorrect type. If more than one argument returns an error, puArgErr indicates only the first argument with an error. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT Invoke(
            [In, MarshalAs(UnmanagedType.Interface)] object pvInstance,
            [In] int memid,
            [In] short wFlags,
            [In, Out] ref DISPPARAMS pDispParams,
            [Out] out IntPtr pVarResult,
            [Out] out IntPtr pExcepInfo,
            [Out] out int puArgErr);

        /// <summary>
        /// Retrieves the documentation string, the complete Help file name and path, and the context ID for the Help topic for a specified type description.
        /// </summary>
        /// <param name="index">The ID of the member whose documentation is to be returned.</param>
        /// <param name="strName">When this method returns, contains the name of the item method. This parameter is passed uninitialized.</param>
        /// <param name="strDocString">When this method returns, contains the documentation string for the specified item. This parameter is passed uninitialized.</param>
        /// <param name="dwHelpContext">When this method returns, contains a reference to the Help context associated with the specified item. This parameter is passed uninitialized.</param>
        /// <param name="strHelpFile">When this method returns, contains the fully qualified name of the Help file. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetDocumentation(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.BStr)] out string strName,
            [Out, MarshalAs(UnmanagedType.BStr)] out string strDocString,
            [Out] out int dwHelpContext,
            [Out, MarshalAs(UnmanagedType.BStr)] out string strHelpFile);

        /// <summary>
        /// Retrieves a description or specification of an entry point for a function in a DLL.
        /// </summary>
        /// <param name="memid">The ID of the member function whose DLL entry description is to be returned.</param>
        /// <param name="invKind">One of the <see cref="INVOKEKIND"/> values that specifies the kind of member identified by memid.</param>
        /// <param name="pBstrDllName">If not null, the function sets pBstrDllName to a BSTR that contains the name of the DLL.</param>
        /// <param name="pBstrName">If not null, the function sets lpbstrName to a BSTR that contains the name of the entry point.</param>
        /// <param name="pwOrdinal">If not null, and the function is defined by an ordinal, then lpwOrdinal is set to point to the ordinal.</param>
        [PreserveSig]
        HRESULT GetDllEntry(
            [In] int memid,
            [In] INVOKEKIND invKind,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pBstrDllName,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pBstrName,
            [Out] out short pwOrdinal);

        /// <summary>
        /// Retrieves the referenced type descriptions if a type description references other type descriptions.
        /// </summary>
        /// <param name="hRef">A handle to the referenced type description to return.</param>
        /// <param name="ppTI">When this method returns, contains the referenced type description. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetRefTypeInfo(
            [In] int hRef,
            [Out, MarshalAs(UnmanagedType.Interface)] out ITypeInfo ppTI);

        /// <summary>
        /// Retrieves the addresses of static functions or variables, such as those defined in a DLL.
        /// </summary>
        /// <param name="memid">The member ID of the static member's address to retrieve.</param>
        /// <param name="invKind">One of the <see cref="INVOKEKIND"/> values that specifies whether the member is a property, and if so, what kind.</param>
        /// <param name="ppv">When this method returns, contains a reference to the static member. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT AddressOfMember(
            [In] int memid,
            [In] INVOKEKIND invKind,
            [Out] out IntPtr ppv);

        /// <summary>
        /// Creates a new instance of a type that describes a component class (coclass).
        /// </summary>
        /// <param name="pUnkOuter">The object that acts as the controlling IUnknown.</param>
        /// <param name="riid">The IID of the interface that the caller uses to communicate with the resulting object.</param>
        /// <param name="ppvObj">When this method returns, contains a reference to the created object. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT CreateInstance(
            [In, MarshalAs(UnmanagedType.Interface)] object pUnkOuter,
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppvObj);

        /// <summary>
        /// Retrieves marshaling information.
        /// </summary>
        /// <param name="memid">The member ID that indicates which marshaling information is needed.</param>
        /// <param name="pBstrMops">When this method returns, contains a reference to the opcode string used in marshaling the fields of the structure described by the referenced type description, or returns null if there is no information to return. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetMops(
            [In] int memid,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pBstrMops);

        /// <summary>
        /// Retrieves the type library that contains this type description and its index within that type library.
        /// </summary>
        /// <param name="ppTLB">When this method returns, contains a reference to the containing type library. This parameter is passed uninitialized.</param>
        /// <param name="pIndex">When this method returns, contains a reference to the index of the type description within the containing type library. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetContainingTypeLib(
            [Out, MarshalAs(UnmanagedType.Interface)] out ITypeLib ppTLB,
            [Out] out int pIndex);

        /// <summary>
        /// Releases a <see cref="TYPEATTR"/> structure previously returned by the <see cref="GetTypeAttr"/> method.
        /// </summary>
        /// <param name="pTypeAttr">A reference to the TYPEATTR structure to release.</param>
        [PreserveSig]
        void ReleaseTypeAttr(
            [In] TYPEATTR* pTypeAttr);

        /// <summary>
        /// Releases a <see cref="FUNCDESC"/> structure previously returned by the <see cref="GetFuncDesc"/> method.
        /// </summary>
        /// <param name="pFuncDesc">A reference to the FUNCDESC structure to release.</param>
        [PreserveSig]
        void ReleaseFuncDesc(
            [In] FUNCDESC* pFuncDesc);

        /// <summary>
        /// Releases a <see cref="VARDESC"/> structure previously returned by the <see cref="GetVarDesc"/> method.
        /// </summary>
        /// <param name="pVarDesc">A reference to the VARDESC structure to release.</param>
        [PreserveSig]
        void ReleaseVarDesc(
            [In] VARDESC* pVarDesc);
    }
}
