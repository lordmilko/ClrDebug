using System;
using System.Runtime.InteropServices;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Provides the managed definition of the ITypeInfo2 interface.
    /// </summary>
    [Guid("00020412-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public unsafe interface ITypeInfo2 : ITypeInfo
    {
        /// <summary>
        /// Retrieves a <see cref="TYPEATTR"/> structure that contains the attributes of the type description.<para/>
        /// This value must be released by calling <see cref="ReleaseTypeAttr"/>.
        /// </summary>
        /// <param name="ppTypeAttr">When this method returns, contains a reference to the structure that contains the attributes of this type description. This parameter is passed uninitialized.</param>
        [PreserveSig]
        new HRESULT GetTypeAttr(
            [Out] out TYPEATTR* ppTypeAttr);

        /// <summary>
        /// Retrieves the ITypeComp interface for the type description, which enables a client compiler to bind to the type description's members.
        /// </summary>
        /// <param name="ppTComp">When this method returns, contains a reference to the ITypeComp interface of the containing type library. This parameter is passed uninitialized.</param>
        [PreserveSig]
        new HRESULT GetTypeComp(
            [Out] out ITypeComp ppTComp);

        /// <summary>
        /// Retrieves the <see cref="FUNCDESC"/> structure that contains information about a specified function.<para/>
        /// This value must be released by calling <see cref="ReleaseFuncDesc"/>.
        /// </summary>
        /// <param name="index">The index of the function description to return.</param>
        /// <param name="ppFuncDesc">When this method returns, contains a reference to a FUNCDESC structure that describes the specified function. This parameter is passed uninitialized.</param>
        [PreserveSig]
        new HRESULT GetFuncDesc(
            [In] int index,
            [Out] out FUNCDESC* ppFuncDesc);

        /// <summary>
        /// Retrieves a <see cref="VARDESC"/> structure that describes the specified variable.
        /// This value must be released by calling <see cref="ReleaseVarDesc"/>.
        /// </summary>
        /// <param name="index">The index of the variable description to return.</param>
        /// <param name="ppVarDesc">When this method returns, contains a reference to the VARDESC structure that describes the specified variable. This parameter is passed uninitialized.</param>
        [PreserveSig]
        new HRESULT GetVarDesc(
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
        new HRESULT GetNames(
            [In] int memid,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.BStr, SizeParamIndex = 2)] string[] rgBstrNames,
            [In] int cMaxNames,
            [Out] out int pcNames);

        /// <summary>
        /// Retrieves the type description of the implemented interface types if a type description describes a COM class.
        /// </summary>
        /// <param name="index">The index of the implemented type whose handle is returned.</param>
        /// <param name="href">When this method returns, contains a reference to a handle for the implemented interface. This parameter is passed uninitialized.</param>
        [PreserveSig]
        new HRESULT GetRefTypeOfImplType(
            [In] int index,
            [Out] out int href);

        /// <summary>
        /// Retrieves the <see cref="IMPLTYPEFLAGS"/> value for one implemented interface or base interface in a type description.
        /// </summary>
        /// <param name="index">The index of the implemented interface or base interface.</param>
        /// <param name="pImplTypeFlags">When this method returns, contains a reference to the IMPLTYPEFLAGS enumeration. This parameter is passed uninitialized.</param>
        [PreserveSig]
        new HRESULT GetImplTypeFlags(
            [In] int index,
            [Out] out IMPLTYPEFLAGS pImplTypeFlags);

        /// <summary>
        /// Maps between member names and member IDs, and parameter names and parameter IDs.
        /// </summary>
        /// <param name="rgszNames">An array of names to map.</param>
        /// <param name="cNames">The count of names to map.</param>
        /// <param name="pMemId">When this method returns, contains a reference to an array in which name mappings are placed. This parameter is passed uninitialized.</param>
        [PreserveSig]
        new HRESULT GetIDsOfNames(
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] string[] rgszNames,
            [In] int cNames,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] pMemId);

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
        new HRESULT Invoke(
            [In, MarshalAs(UnmanagedType.IUnknown)] object pvInstance,
            [In] int memid,
            [In] short wFlags,
            [In, Out] ref DISPPARAMS pDispParams,
            [In] IntPtr pVarResult,
            [In] IntPtr pExcepInfo,
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
        new HRESULT GetDocumentation(
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
        new HRESULT GetDllEntry(
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
        new HRESULT GetRefTypeInfo(
            [In] int hRef,
            [Out] out ITypeInfo ppTI);

        /// <summary>
        /// Retrieves the addresses of static functions or variables, such as those defined in a DLL.
        /// </summary>
        /// <param name="memid">The member ID of the static member's address to retrieve.</param>
        /// <param name="invKind">One of the <see cref="INVOKEKIND"/> values that specifies whether the member is a property, and if so, what kind.</param>
        /// <param name="ppv">When this method returns, contains a reference to the static member. This parameter is passed uninitialized.</param>
        [PreserveSig]
        new HRESULT AddressOfMember(
            [In] int memid,
            [In] INVOKEKIND invKind,
            [Out] IntPtr ppv);

        /// <summary>
        /// Creates a new instance of a type that describes a component class (coclass).
        /// </summary>
        /// <param name="pUnkOuter">The object that acts as the controlling IUnknown.</param>
        /// <param name="riid">The IID of the interface that the caller uses to communicate with the resulting object.</param>
        /// <param name="ppvObj">When this method returns, contains a reference to the created object. This parameter is passed uninitialized.</param>
        [PreserveSig]
        new HRESULT CreateInstance(
            [In] object pUnkOuter,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [Out] out object ppvObj);

        /// <summary>
        /// Retrieves marshaling information.
        /// </summary>
        /// <param name="memid">The member ID that indicates which marshaling information is needed.</param>
        /// <param name="pBstrMops">When this method returns, contains a reference to the opcode string used in marshaling the fields of the structure described by the referenced type description, or returns null if there is no information to return. This parameter is passed uninitialized.</param>
        [PreserveSig]
        new HRESULT GetMops(
            [In] int memid,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pBstrMops);

        /// <summary>
        /// Retrieves the type library that contains this type description and its index within that type library.
        /// </summary>
        /// <param name="ppTLB">When this method returns, contains a reference to the containing type library. This parameter is passed uninitialized.</param>
        /// <param name="pIndex">When this method returns, contains a reference to the index of the type description within the containing type library. This parameter is passed uninitialized.</param>
        [PreserveSig]
        new HRESULT GetContainingTypeLib(
            [Out] out ITypeLib ppTLB,
            [Out] out int pIndex);

        /// <summary>
        /// Releases a <see cref="TYPEATTR"/> structure previously returned by the <see cref="GetTypeAttr"/> method.
        /// </summary>
        /// <param name="pTypeAttr">A reference to the TYPEATTR structure to release.</param>
        [PreserveSig]
        new void ReleaseTypeAttr(
            [In] TYPEATTR* pTypeAttr);

        /// <summary>
        /// Releases a <see cref="FUNCDESC"/> structure previously returned by the <see cref="GetFuncDesc"/> method.
        /// </summary>
        /// <param name="pFuncDesc">A reference to the FUNCDESC structure to release.</param>
        [PreserveSig]
        new void ReleaseFuncDesc(
            [In] FUNCDESC* pFuncDesc);

        /// <summary>
        /// Releases a <see cref="VARDESC"/> structure previously returned by the <see cref="GetVarDesc"/> method.
        /// </summary>
        /// <param name="pVarDesc">A reference to the VARDESC structure to release.</param>
        [PreserveSig]
        new void ReleaseVarDesc(
            [In] VARDESC* pVarDesc);

        /// <summary>
        /// Returns the <see cref="TYPEKIND"/> enumeration quickly, without doing any allocations.
        /// </summary>
        /// <param name="pTypeKind">When this method returns, contains a reference to a <see cref="TYPEKIND"/> enumeration. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetTypeKind(
            [Out] out TYPEKIND pTypeKind);

        /// <summary>
        /// Returns the type flags without any allocations. This method returns a type flag, which expands the type flags without growing the <see langword="TYPEATTR"/> (type attribute).
        /// </summary>
        /// <param name="pTypeFlags">When this method returns, contains a reference to a <see cref="TYPEFLAGS"/> value. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetTypeFlags(
            [Out] out TYPEFLAGS pTypeFlags);

        /// <summary>
        /// Binds to a specific member based on a known DISPID, where the member name is not known (for example, when binding to a default member).
        /// </summary>
        /// <param name="memid">The member identifier.</param>
        /// <param name="invKind">One of the <see cref="INVOKEKIND"/> values that specifies the kind of member identified by memid.</param>
        /// <param name="pFuncIndex">When this method returns, contains an index into the function. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetFuncIndexOfMemId(
            [In] int memid,
            [In] INVOKEKIND invKind,
            [Out] out int pFuncIndex);

        /// <summary>
        /// Binds to a specific member based on a known <see langword="DISPID"/>, where the member name is not known (for example, when binding to a default member).
        /// </summary>
        /// <param name="memid">The member identifier.</param>
        /// <param name="pVarIndex">When this method returns, contains an index of memid. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetVarIndexOfMemId(
            [In] int memid,
            [Out] out int pVarIndex);

        /// <summary>
        /// Gets the custom data.
        /// </summary>
        /// <param name="guid">The GUID used to identify the data.</param>
        /// <param name="pVarVal">When this method returns, contains an <see langword="object"/> that specifies where to put the retrieved data. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetCustData(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guid,
            [Out] out object pVarVal);

        /// <summary>
        /// Gets the custom data from the specified function.
        /// </summary>
        /// <param name="index">The index of the function to get the custom data for.</param>
        /// <param name="guid">The GUID used to identify the data.</param>
        /// <param name="pVarVal">When this method returns, contains an <see langword="object"/> that specified where to put the data. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetFuncCustData(
            [In] int index,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guid,
            [Out] out object pVarVal);

        /// <summary>
        /// Gets the specified custom data parameter.
        /// </summary>
        /// <param name="indexFunc">The index of the function to get the custom data for.</param>
        /// <param name="indexParam">The index of the parameter of this function to get the custom data for.</param>
        /// <param name="guid">The GUID used to identify the data.</param>
        /// <param name="pVarVal">When this method returns, contains an <see langword="object"/> that specifies where to put the retrieved data. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetParamCustData(
            [In] int indexFunc,
            [In] int indexParam,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guid,
            [Out] out object pVarVal);

        /// <summary>
        /// Gets the variable for the custom data.
        /// </summary>
        /// <param name="index">The index of the variable to get the custom data for.</param>
        /// <param name="guid">The GUID used to identify the data.</param>
        /// <param name="pVarVal">When this method returns, contains an <see langword="object"/> that specifies where to put the retrieved data. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetVarCustData(
            [In] int index,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guid,
            [Out] out object pVarVal);

        /// <summary>
        /// Gets the implementation type of the custom data.
        /// </summary>
        /// <param name="index">The index of the implementation type for the custom data.</param>
        /// <param name="guid">The GUID used to identify the data.</param>
        /// <param name="pVarVal">When this method returns, contains an <see langword="object"/> that specifies where to put the retrieved data. This parameter is passed uninitialized.</param>
        [PreserveSig]
        HRESULT GetImplTypeCustData(
            [In] int index,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guid,
            [Out] out object pVarVal);

        /// <summary>
        /// Retrieves the documentation string, the complete Help file name and path, the localization context to use, and the context ID for the library Help topic in the Help file.
        /// </summary>
        /// <param name="memid">The member identifier for the type description.</param>
        /// <param name="pbstrHelpString">When this method returns, contains a <see langword="BSTR"/> that contains the name of the specified item. If the caller does not need the item name, pbstrHelpString can be <see langword="null"/>. This parameter is passed uninitialized.</param>
        /// <param name="pdwHelpStringContext">When this method returns, contains the Help localization context. If the caller does not need the Help context, pdwHelpStringContext can be <see langword="null"/>. This parameter is passed uninitialized.</param>
        /// <param name="pbstrHelpStringDll">When this method returns, contains a <see langword="BSTR"/> that contains the fully qualified name of the file containing the DLL used for the Help file. If the caller does not need the file name, pbstrHelpStringDll can be <see langword="null"/>. This parameter is passed uninitialized.</param>
        [PreserveSig]
        [LCIDConversion(1)]
        HRESULT GetDocumentation2(
            [In] int memid,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pbstrHelpString,
            [Out] out int pdwHelpStringContext,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pbstrHelpStringDll);

        /// <summary>
        /// Gets all custom data items for the library.
        /// </summary>
        /// <param name="pCustData">A pointer to <see cref="CUSTDATA"/>, which holds all custom data items.</param>
        [PreserveSig]
        HRESULT GetAllCustData(
            [Out] out CUSTDATA pCustData);

        /// <summary>
        /// Gets all custom data from the specified function.
        /// </summary>
        /// <param name="index">The index of the function to get the custom data for.</param>
        /// <param name="pCustData">A pointer to <see cref="CUSTDATA"/>, which holds all custom data items.</param>
        [PreserveSig]
        HRESULT GetAllFuncCustData(
            [In] int index,
            [Out] out CUSTDATA pCustData);

        /// <summary>
        /// Gets all of the custom data for the specified function parameter.
        /// </summary>
        /// <param name="indexFunc">The index of the function to get the custom data for.</param>
        /// <param name="indexParam">The index of the parameter of this function to get the custom data for.</param>
        /// <param name="pCustData">A pointer to <see cref="CUSTDATA"/>, which holds all custom data items.</param>
        [PreserveSig]
        HRESULT GetAllParamCustData(
            [In] int indexFunc,
            [In] int indexParam,
            [Out] out CUSTDATA pCustData);

        /// <summary>
        /// Gets the variable for the custom data.
        /// </summary>
        /// <param name="index">The index of the variable to get the custom data for.</param>
        /// <param name="pCustData">A pointer to <see cref="CUSTDATA"/>, which holds all custom data items.</param>
        [PreserveSig]
        HRESULT GetAllVarCustData(
            [In] int index,
            [Out] out CUSTDATA pCustData);

        /// <summary>
        /// Gets all custom data for the specified implementation type.
        /// </summary>
        /// <param name="index">The index of the implementation type for the custom data.</param>
        /// <param name="pCustData">A pointer to <see cref="CUSTDATA"/> which holds all custom data items.</param>
        [PreserveSig]
        HRESULT GetAllImplTypeCustData(
            [In] int index,
            [Out] out CUSTDATA pCustData);
    }
}
