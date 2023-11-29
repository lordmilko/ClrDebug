using System;
using System.Diagnostics;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Provides the managed definition of the Component Automation ITypeInfo interface.
    /// </summary>
    public class TypeInfo : ComObject<ITypeInfo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TypeInfo"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public TypeInfo(ITypeInfo raw) : base(raw)
        {
        }

        #region ITypeInfo
        #region TypeAttr

        /// <summary>
        /// Retrieves a <see cref="TYPEATTR"/> structure that contains the attributes of the type description.<para/>
        /// This value must be released by calling <see cref="ReleaseTypeAttr"/>.
        /// </summary>
        public unsafe TYPEATTR* TypeAttr
        {
            get
            {
                TYPEATTR* ppTypeAttr;
                TryGetTypeAttr(out ppTypeAttr).ThrowOnNotOK();

                return ppTypeAttr;
            }
        }

        /// <summary>
        /// Retrieves a <see cref="TYPEATTR"/> structure that contains the attributes of the type description.<para/>
        /// This value must be released by calling <see cref="ReleaseTypeAttr"/>.
        /// </summary>
        /// <param name="ppTypeAttr">When this method returns, contains a reference to the structure that contains the attributes of this type description. This parameter is passed uninitialized.</param>
        public unsafe HRESULT TryGetTypeAttr(out TYPEATTR* ppTypeAttr)
        {
            /*HRESULT GetTypeAttr(
            [Out] out TYPEATTR* ppTypeAttr);*/
            return Raw.GetTypeAttr(out ppTypeAttr);
        }

        #endregion
        #region TypeComp

        /// <summary>
        /// Retrieves the ITypeComp interface for the type description, which enables a client compiler to bind to the type description's members.
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
        /// Retrieves the ITypeComp interface for the type description, which enables a client compiler to bind to the type description's members.
        /// </summary>
        /// <param name="ppTCompResult">When this method returns, contains a reference to the ITypeComp interface of the containing type library. This parameter is passed uninitialized.</param>
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
        #region ContainingTypeLib

        /// <summary>
        /// Retrieves the type library that contains this type description and its index within that type library.
        /// </summary>
        public GetContainingTypeLibResult ContainingTypeLib
        {
            get
            {
                GetContainingTypeLibResult result;
                TryGetContainingTypeLib(out result).ThrowOnNotOK();

                return result;
            }
        }

        /// <summary>
        /// Retrieves the type library that contains this type description and its index within that type library.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetContainingTypeLib(out GetContainingTypeLibResult result)
        {
            /*HRESULT GetContainingTypeLib(
            [Out, MarshalAs(UnmanagedType.Interface)] out ITypeLib ppTLB,
            [Out] out int pIndex);*/
            ITypeLib ppTLB;
            int pIndex;
            HRESULT hr = Raw.GetContainingTypeLib(out ppTLB, out pIndex);

            if (hr == HRESULT.S_OK)
                result = new GetContainingTypeLibResult(ppTLB == null ? null : new ComTypeLib(ppTLB), pIndex);
            else
                result = default(GetContainingTypeLibResult);

            return hr;
        }

        #endregion
        #region GetFuncDesc

        /// <summary>
        /// Retrieves the <see cref="FUNCDESC"/> structure that contains information about a specified function.<para/>
        /// This value must be released by calling <see cref="ReleaseFuncDesc"/>.
        /// </summary>
        /// <param name="index">The index of the function description to return.</param>
        /// <returns>When this method returns, contains a reference to a FUNCDESC structure that describes the specified function. This parameter is passed uninitialized.</returns>
        public unsafe FUNCDESC* GetFuncDesc(int index)
        {
            FUNCDESC* ppFuncDesc;
            TryGetFuncDesc(index, out ppFuncDesc).ThrowOnNotOK();

            return ppFuncDesc;
        }

        /// <summary>
        /// Retrieves the <see cref="FUNCDESC"/> structure that contains information about a specified function.<para/>
        /// This value must be released by calling <see cref="ReleaseFuncDesc"/>.
        /// </summary>
        /// <param name="index">The index of the function description to return.</param>
        /// <param name="ppFuncDesc">When this method returns, contains a reference to a FUNCDESC structure that describes the specified function. This parameter is passed uninitialized.</param>
        public unsafe HRESULT TryGetFuncDesc(int index, out FUNCDESC* ppFuncDesc)
        {
            /*HRESULT GetFuncDesc(
            [In] int index,
            [Out] out FUNCDESC* ppFuncDesc);*/
            return Raw.GetFuncDesc(index, out ppFuncDesc);
        }

        #endregion
        #region GetVarDesc

        /// <summary>
        /// Retrieves a <see cref="VARDESC"/> structure that describes the specified variable.
        /// This value must be released by calling <see cref="ReleaseVarDesc"/>.
        /// </summary>
        /// <param name="index">The index of the variable description to return.</param>
        /// <returns>When this method returns, contains a reference to the VARDESC structure that describes the specified variable. This parameter is passed uninitialized.</returns>
        public unsafe VARDESC* GetVarDesc(int index)
        {
            VARDESC* ppVarDesc;
            TryGetVarDesc(index, out ppVarDesc).ThrowOnNotOK();

            return ppVarDesc;
        }

        /// <summary>
        /// Retrieves a <see cref="VARDESC"/> structure that describes the specified variable.
        /// This value must be released by calling <see cref="ReleaseVarDesc"/>.
        /// </summary>
        /// <param name="index">The index of the variable description to return.</param>
        /// <param name="ppVarDesc">When this method returns, contains a reference to the VARDESC structure that describes the specified variable. This parameter is passed uninitialized.</param>
        public unsafe HRESULT TryGetVarDesc(int index, out VARDESC* ppVarDesc)
        {
            /*HRESULT GetVarDesc(
            [In] int index,
            [Out] out VARDESC* ppVarDesc);*/
            return Raw.GetVarDesc(index, out ppVarDesc);
        }

        #endregion
        #region GetNames

        /// <summary>
        /// Retrieves the variable with the specified member ID (or the name of the property or method and its parameters) that corresponds to the specified function ID.
        /// </summary>
        /// <param name="memid">The ID of the member whose name (or names) is to be returned.</param>
        /// <param name="cMaxNames">The length of the rgBstrNames array.</param>
        /// <returns>When this method returns, contains the name (or names) associated with the member. This parameter is passed uninitialized.</returns>
        public string[] GetNames(int memid, int cMaxNames)
        {
            string[] rgBstrNames;
            TryGetNames(memid, cMaxNames, out rgBstrNames).ThrowOnNotOK();

            return rgBstrNames;
        }

        /// <summary>
        /// Retrieves the variable with the specified member ID (or the name of the property or method and its parameters) that corresponds to the specified function ID.
        /// </summary>
        /// <param name="memid">The ID of the member whose name (or names) is to be returned.</param>
        /// <param name="rgBstrNames">When this method returns, contains the name (or names) associated with the member. This parameter is passed uninitialized.</param>
        /// <param name="cMaxNames">The length of the rgBstrNames array.</param>
        public HRESULT TryGetNames(int memid, int cMaxNames, out string[] rgBstrNames)
        {
            /*HRESULT GetNames(
            [In] int memid,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.BStr, SizeParamIndex = 2)] string[] rgBstrNames,
            [In] int cMaxNames,
            [Out] out int pcNames);*/
            rgBstrNames = new string[cMaxNames];
            int pcNames;
            HRESULT hr = Raw.GetNames(memid, rgBstrNames, cMaxNames, out pcNames);

            if (cMaxNames != pcNames)
                Array.Resize(ref rgBstrNames, pcNames);

            return hr;
        }

        #endregion
        #region GetRefTypeOfImplType

        /// <summary>
        /// Retrieves the type description of the implemented interface types if a type description describes a COM class.
        /// </summary>
        /// <param name="index">The index of the implemented type whose handle is returned.</param>
        /// <returns>When this method returns, contains a reference to a handle for the implemented interface. This parameter is passed uninitialized.</returns>
        public int GetRefTypeOfImplType(int index)
        {
            int href;
            TryGetRefTypeOfImplType(index, out href).ThrowOnNotOK();

            return href;
        }

        /// <summary>
        /// Retrieves the type description of the implemented interface types if a type description describes a COM class.
        /// </summary>
        /// <param name="index">The index of the implemented type whose handle is returned.</param>
        /// <param name="href">When this method returns, contains a reference to a handle for the implemented interface. This parameter is passed uninitialized.</param>
        public HRESULT TryGetRefTypeOfImplType(int index, out int href)
        {
            /*HRESULT GetRefTypeOfImplType(
            [In] int index,
            [Out] out int href);*/
            return Raw.GetRefTypeOfImplType(index, out href);
        }

        #endregion
        #region GetImplTypeFlags

        /// <summary>
        /// Retrieves the <see cref="IMPLTYPEFLAGS"/> value for one implemented interface or base interface in a type description.
        /// </summary>
        /// <param name="index">The index of the implemented interface or base interface.</param>
        /// <returns>When this method returns, contains a reference to the IMPLTYPEFLAGS enumeration. This parameter is passed uninitialized.</returns>
        public IMPLTYPEFLAGS GetImplTypeFlags(int index)
        {
            IMPLTYPEFLAGS pImplTypeFlags;
            TryGetImplTypeFlags(index, out pImplTypeFlags).ThrowOnNotOK();

            return pImplTypeFlags;
        }

        /// <summary>
        /// Retrieves the <see cref="IMPLTYPEFLAGS"/> value for one implemented interface or base interface in a type description.
        /// </summary>
        /// <param name="index">The index of the implemented interface or base interface.</param>
        /// <param name="pImplTypeFlags">When this method returns, contains a reference to the IMPLTYPEFLAGS enumeration. This parameter is passed uninitialized.</param>
        public HRESULT TryGetImplTypeFlags(int index, out IMPLTYPEFLAGS pImplTypeFlags)
        {
            /*HRESULT GetImplTypeFlags(
            [In] int index,
            [Out] out IMPLTYPEFLAGS pImplTypeFlags);*/
            return Raw.GetImplTypeFlags(index, out pImplTypeFlags);
        }

        #endregion
        #region GetIDsOfNames

        /// <summary>
        /// Maps between member names and member IDs, and parameter names and parameter IDs.
        /// </summary>
        /// <param name="rgszNames">An array of names to map.</param>
        /// <param name="cNames">The count of names to map.</param>
        /// <returns>When this method returns, contains a reference to an array in which name mappings are placed. This parameter is passed uninitialized.</returns>
        public int[] GetIDsOfNames(string[] rgszNames, int cNames)
        {
            int[] pMemId;
            TryGetIDsOfNames(rgszNames, cNames, out pMemId).ThrowOnNotOK();

            return pMemId;
        }

        /// <summary>
        /// Maps between member names and member IDs, and parameter names and parameter IDs.
        /// </summary>
        /// <param name="rgszNames">An array of names to map.</param>
        /// <param name="cNames">The count of names to map.</param>
        /// <param name="pMemId">When this method returns, contains a reference to an array in which name mappings are placed. This parameter is passed uninitialized.</param>
        public HRESULT TryGetIDsOfNames(string[] rgszNames, int cNames, out int[] pMemId)
        {
            /*HRESULT GetIDsOfNames(
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 1)] string[] rgszNames,
            [In] int cNames,
            [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] pMemId);*/
            pMemId = new int[cNames];
            HRESULT hr = Raw.GetIDsOfNames(rgszNames, cNames, pMemId);

            return hr;
        }

        #endregion
        #region Invoke

        /// <summary>
        /// Invokes a method, or accesses a property of an object, that implements the interface described by the type description.
        /// </summary>
        /// <param name="pvInstance">A reference to the interface described by this type description.</param>
        /// <param name="memid">A value that identifies the interface member.</param>
        /// <param name="wFlags">Flags that describe the context of the invoke call.</param>
        /// <param name="pDispParams">A reference to a structure that contains an array of arguments, an array of DISPIDs for named arguments, and counts of the number of elements in each array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public InvokeResult Invoke(object pvInstance, int memid, short wFlags, ref DISPPARAMS pDispParams)
        {
            InvokeResult result;
            TryInvoke(pvInstance, memid, wFlags, ref pDispParams, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Invokes a method, or accesses a property of an object, that implements the interface described by the type description.
        /// </summary>
        /// <param name="pvInstance">A reference to the interface described by this type description.</param>
        /// <param name="memid">A value that identifies the interface member.</param>
        /// <param name="wFlags">Flags that describe the context of the invoke call.</param>
        /// <param name="pDispParams">A reference to a structure that contains an array of arguments, an array of DISPIDs for named arguments, and counts of the number of elements in each array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryInvoke(object pvInstance, int memid, short wFlags, ref DISPPARAMS pDispParams, out InvokeResult result)
        {
            /*HRESULT Invoke(
            [In, MarshalAs(UnmanagedType.Interface)] object pvInstance,
            [In] int memid,
            [In] short wFlags,
            [In, Out] ref DISPPARAMS pDispParams,
            [Out] out IntPtr pVarResult,
            [Out] out IntPtr pExcepInfo,
            [Out] out int puArgErr);*/
            IntPtr pVarResult;
            IntPtr pExcepInfo;
            int puArgErr;
            HRESULT hr = Raw.Invoke(pvInstance, memid, wFlags, ref pDispParams, out pVarResult, out pExcepInfo, out puArgErr);

            if (hr == HRESULT.S_OK)
                result = new InvokeResult(pVarResult, pExcepInfo, puArgErr);
            else
                result = default(InvokeResult);

            return hr;
        }

        #endregion
        #region GetDocumentation

        /// <summary>
        /// Retrieves the documentation string, the complete Help file name and path, and the context ID for the Help topic for a specified type description.
        /// </summary>
        /// <param name="index">The ID of the member whose documentation is to be returned.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetDocumentationResult GetDocumentation(int index)
        {
            GetDocumentationResult result;
            TryGetDocumentation(index, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Retrieves the documentation string, the complete Help file name and path, and the context ID for the Help topic for a specified type description.
        /// </summary>
        /// <param name="index">The ID of the member whose documentation is to be returned.</param>
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
        #region GetDllEntry

        /// <summary>
        /// Retrieves a description or specification of an entry point for a function in a DLL.
        /// </summary>
        /// <param name="memid">The ID of the member function whose DLL entry description is to be returned.</param>
        /// <param name="invKind">One of the <see cref="INVOKEKIND"/> values that specifies the kind of member identified by memid.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetDllEntryResult GetDllEntry(int memid, INVOKEKIND invKind)
        {
            GetDllEntryResult result;
            TryGetDllEntry(memid, invKind, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Retrieves a description or specification of an entry point for a function in a DLL.
        /// </summary>
        /// <param name="memid">The ID of the member function whose DLL entry description is to be returned.</param>
        /// <param name="invKind">One of the <see cref="INVOKEKIND"/> values that specifies the kind of member identified by memid.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetDllEntry(int memid, INVOKEKIND invKind, out GetDllEntryResult result)
        {
            /*HRESULT GetDllEntry(
            [In] int memid,
            [In] INVOKEKIND invKind,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pBstrDllName,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pBstrName,
            [Out] out short pwOrdinal);*/
            string pBstrDllName;
            string pBstrName;
            short pwOrdinal;
            HRESULT hr = Raw.GetDllEntry(memid, invKind, out pBstrDllName, out pBstrName, out pwOrdinal);

            if (hr == HRESULT.S_OK)
                result = new GetDllEntryResult(pBstrDllName, pBstrName, pwOrdinal);
            else
                result = default(GetDllEntryResult);

            return hr;
        }

        #endregion
        #region GetRefTypeInfo

        /// <summary>
        /// Retrieves the referenced type descriptions if a type description references other type descriptions.
        /// </summary>
        /// <param name="hRef">A handle to the referenced type description to return.</param>
        /// <returns>When this method returns, contains the referenced type description. This parameter is passed uninitialized.</returns>
        public TypeInfo GetRefTypeInfo(int hRef)
        {
            TypeInfo ppTIResult;
            TryGetRefTypeInfo(hRef, out ppTIResult).ThrowOnNotOK();

            return ppTIResult;
        }

        /// <summary>
        /// Retrieves the referenced type descriptions if a type description references other type descriptions.
        /// </summary>
        /// <param name="hRef">A handle to the referenced type description to return.</param>
        /// <param name="ppTIResult">When this method returns, contains the referenced type description. This parameter is passed uninitialized.</param>
        public HRESULT TryGetRefTypeInfo(int hRef, out TypeInfo ppTIResult)
        {
            /*HRESULT GetRefTypeInfo(
            [In] int hRef,
            [Out, MarshalAs(UnmanagedType.Interface)] out ITypeInfo ppTI);*/
            ITypeInfo ppTI;
            HRESULT hr = Raw.GetRefTypeInfo(hRef, out ppTI);

            if (hr == HRESULT.S_OK)
                ppTIResult = ppTI == null ? null : new TypeInfo(ppTI);
            else
                ppTIResult = default(TypeInfo);

            return hr;
        }

        #endregion
        #region AddressOfMember

        /// <summary>
        /// Retrieves the addresses of static functions or variables, such as those defined in a DLL.
        /// </summary>
        /// <param name="memid">The member ID of the static member's address to retrieve.</param>
        /// <param name="invKind">One of the <see cref="INVOKEKIND"/> values that specifies whether the member is a property, and if so, what kind.</param>
        /// <returns>When this method returns, contains a reference to the static member. This parameter is passed uninitialized.</returns>
        public IntPtr AddressOfMember(int memid, INVOKEKIND invKind)
        {
            IntPtr ppv;
            TryAddressOfMember(memid, invKind, out ppv).ThrowOnNotOK();

            return ppv;
        }

        /// <summary>
        /// Retrieves the addresses of static functions or variables, such as those defined in a DLL.
        /// </summary>
        /// <param name="memid">The member ID of the static member's address to retrieve.</param>
        /// <param name="invKind">One of the <see cref="INVOKEKIND"/> values that specifies whether the member is a property, and if so, what kind.</param>
        /// <param name="ppv">When this method returns, contains a reference to the static member. This parameter is passed uninitialized.</param>
        public HRESULT TryAddressOfMember(int memid, INVOKEKIND invKind, out IntPtr ppv)
        {
            /*HRESULT AddressOfMember(
            [In] int memid,
            [In] INVOKEKIND invKind,
            [Out] out IntPtr ppv);*/
            return Raw.AddressOfMember(memid, invKind, out ppv);
        }

        #endregion
        #region CreateInstance

        /// <summary>
        /// Creates a new instance of a type that describes a component class (coclass).
        /// </summary>
        /// <param name="pUnkOuter">The object that acts as the controlling IUnknown.</param>
        /// <param name="riid">The IID of the interface that the caller uses to communicate with the resulting object.</param>
        /// <returns>When this method returns, contains a reference to the created object. This parameter is passed uninitialized.</returns>
        public object CreateInstance(object pUnkOuter, Guid riid)
        {
            object ppvObj;
            TryCreateInstance(pUnkOuter, riid, out ppvObj).ThrowOnNotOK();

            return ppvObj;
        }

        /// <summary>
        /// Creates a new instance of a type that describes a component class (coclass).
        /// </summary>
        /// <param name="pUnkOuter">The object that acts as the controlling IUnknown.</param>
        /// <param name="riid">The IID of the interface that the caller uses to communicate with the resulting object.</param>
        /// <param name="ppvObj">When this method returns, contains a reference to the created object. This parameter is passed uninitialized.</param>
        public HRESULT TryCreateInstance(object pUnkOuter, Guid riid, out object ppvObj)
        {
            /*HRESULT CreateInstance(
            [In, MarshalAs(UnmanagedType.Interface)] object pUnkOuter,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppvObj);*/
            return Raw.CreateInstance(pUnkOuter, riid, out ppvObj);
        }

        #endregion
        #region GetMops

        /// <summary>
        /// Retrieves marshaling information.
        /// </summary>
        /// <param name="memid">The member ID that indicates which marshaling information is needed.</param>
        /// <returns>When this method returns, contains a reference to the opcode string used in marshaling the fields of the structure described by the referenced type description, or returns null if there is no information to return. This parameter is passed uninitialized.</returns>
        public string GetMops(int memid)
        {
            string pBstrMops;
            TryGetMops(memid, out pBstrMops).ThrowOnNotOK();

            return pBstrMops;
        }

        /// <summary>
        /// Retrieves marshaling information.
        /// </summary>
        /// <param name="memid">The member ID that indicates which marshaling information is needed.</param>
        /// <param name="pBstrMops">When this method returns, contains a reference to the opcode string used in marshaling the fields of the structure described by the referenced type description, or returns null if there is no information to return. This parameter is passed uninitialized.</param>
        public HRESULT TryGetMops(int memid, out string pBstrMops)
        {
            /*HRESULT GetMops(
            [In] int memid,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pBstrMops);*/
            return Raw.GetMops(memid, out pBstrMops);
        }

        #endregion
        #region ReleaseTypeAttr

        /// <summary>
        /// Releases a <see cref="TYPEATTR"/> structure previously returned by the <see cref="TypeAttr"/> property.
        /// </summary>
        /// <param name="pTypeAttr">A reference to the TYPEATTR structure to release.</param>
        public unsafe void ReleaseTypeAttr(TYPEATTR* pTypeAttr)
        {
            /*void ReleaseTypeAttr(
            [In] TYPEATTR* pTypeAttr);*/
            Raw.ReleaseTypeAttr(pTypeAttr);
        }

        #endregion
        #region ReleaseFuncDesc

        /// <summary>
        /// Releases a <see cref="FUNCDESC"/> structure previously returned by the <see cref="GetFuncDesc"/> method.
        /// </summary>
        /// <param name="pFuncDesc">A reference to the FUNCDESC structure to release.</param>
        public unsafe void ReleaseFuncDesc(FUNCDESC* pFuncDesc)
        {
            /*void ReleaseFuncDesc(
            [In] FUNCDESC* pFuncDesc);*/
            Raw.ReleaseFuncDesc(pFuncDesc);
        }

        #endregion
        #region ReleaseVarDesc

        /// <summary>
        /// Releases a <see cref="VARDESC"/> structure previously returned by the <see cref="GetVarDesc"/> method.
        /// </summary>
        /// <param name="pVarDesc">A reference to the VARDESC structure to release.</param>
        public unsafe void ReleaseVarDesc(VARDESC* pVarDesc)
        {
            /*void ReleaseVarDesc(
            [In] VARDESC* pVarDesc);*/
            Raw.ReleaseVarDesc(pVarDesc);
        }

        #endregion
        #endregion
        #region ITypeInfo2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ITypeInfo2 Raw2 => (ITypeInfo2) Raw;

        #region TypeKind

        /// <summary>
        /// Returns the <see cref="TYPEKIND"/> enumeration quickly, without doing any allocations.
        /// </summary>
        public TYPEKIND TypeKind
        {
            get
            {
                TYPEKIND pTypeKind;
                TryGetTypeKind(out pTypeKind).ThrowOnNotOK();

                return pTypeKind;
            }
        }

        /// <summary>
        /// Returns the <see cref="TYPEKIND"/> enumeration quickly, without doing any allocations.
        /// </summary>
        /// <param name="pTypeKind">When this method returns, contains a reference to a <see cref="TYPEKIND"/> enumeration. This parameter is passed uninitialized.</param>
        public HRESULT TryGetTypeKind(out TYPEKIND pTypeKind)
        {
            /*HRESULT GetTypeKind(
            [Out] out TYPEKIND pTypeKind);*/
            return Raw2.GetTypeKind(out pTypeKind);
        }

        #endregion
        #region TypeFlags

        /// <summary>
        /// Returns the type flags without any allocations. This method returns a type flag, which expands the type flags without growing the <see langword="TYPEATTR"/> (type attribute).
        /// </summary>
        public TYPEFLAGS TypeFlags
        {
            get
            {
                TYPEFLAGS pTypeFlags;
                TryGetTypeFlags(out pTypeFlags).ThrowOnNotOK();

                return pTypeFlags;
            }
        }

        /// <summary>
        /// Returns the type flags without any allocations. This method returns a type flag, which expands the type flags without growing the <see langword="TYPEATTR"/> (type attribute).
        /// </summary>
        /// <param name="pTypeFlags">When this method returns, contains a reference to a <see cref="TYPEFLAGS"/> value. This parameter is passed uninitialized.</param>
        public HRESULT TryGetTypeFlags(out TYPEFLAGS pTypeFlags)
        {
            /*HRESULT GetTypeFlags(
            [Out] out TYPEFLAGS pTypeFlags);*/
            return Raw2.GetTypeFlags(out pTypeFlags);
        }

        #endregion
        #region AllCustData

        /// <summary>
        /// Gets all custom data items for the library.
        /// </summary>
        public CUSTDATA AllCustData
        {
            get
            {
                CUSTDATA pCustData;
                TryGetAllCustData(out pCustData).ThrowOnNotOK();

                return pCustData;
            }
        }

        /// <summary>
        /// Gets all custom data items for the library.
        /// </summary>
        /// <param name="pCustData">A pointer to <see cref="CUSTDATA"/>, which holds all custom data items.</param>
        public HRESULT TryGetAllCustData(out CUSTDATA pCustData)
        {
            /*HRESULT GetAllCustData(
            [Out] out CUSTDATA pCustData);*/
            return Raw2.GetAllCustData(out pCustData);
        }

        #endregion
        #region GetFuncIndexOfMemId

        /// <summary>
        /// Binds to a specific member based on a known DISPID, where the member name is not known (for example, when binding to a default member).
        /// </summary>
        /// <param name="memid">The member identifier.</param>
        /// <param name="invKind">One of the <see cref="INVOKEKIND"/> values that specifies the kind of member identified by memid.</param>
        /// <returns>When this method returns, contains an index into the function. This parameter is passed uninitialized.</returns>
        public int GetFuncIndexOfMemId(int memid, INVOKEKIND invKind)
        {
            int pFuncIndex;
            TryGetFuncIndexOfMemId(memid, invKind, out pFuncIndex).ThrowOnNotOK();

            return pFuncIndex;
        }

        /// <summary>
        /// Binds to a specific member based on a known DISPID, where the member name is not known (for example, when binding to a default member).
        /// </summary>
        /// <param name="memid">The member identifier.</param>
        /// <param name="invKind">One of the <see cref="INVOKEKIND"/> values that specifies the kind of member identified by memid.</param>
        /// <param name="pFuncIndex">When this method returns, contains an index into the function. This parameter is passed uninitialized.</param>
        public HRESULT TryGetFuncIndexOfMemId(int memid, INVOKEKIND invKind, out int pFuncIndex)
        {
            /*HRESULT GetFuncIndexOfMemId(
            [In] int memid,
            [In] INVOKEKIND invKind,
            [Out] out int pFuncIndex);*/
            return Raw2.GetFuncIndexOfMemId(memid, invKind, out pFuncIndex);
        }

        #endregion
        #region GetVarIndexOfMemId

        /// <summary>
        /// Binds to a specific member based on a known <see langword="DISPID"/>, where the member name is not known (for example, when binding to a default member).
        /// </summary>
        /// <param name="memid">The member identifier.</param>
        /// <returns>When this method returns, contains an index of memid. This parameter is passed uninitialized.</returns>
        public int GetVarIndexOfMemId(int memid)
        {
            int pVarIndex;
            TryGetVarIndexOfMemId(memid, out pVarIndex).ThrowOnNotOK();

            return pVarIndex;
        }

        /// <summary>
        /// Binds to a specific member based on a known <see langword="DISPID"/>, where the member name is not known (for example, when binding to a default member).
        /// </summary>
        /// <param name="memid">The member identifier.</param>
        /// <param name="pVarIndex">When this method returns, contains an index of memid. This parameter is passed uninitialized.</param>
        public HRESULT TryGetVarIndexOfMemId(int memid, out int pVarIndex)
        {
            /*HRESULT GetVarIndexOfMemId(
            [In] int memid,
            [Out] out int pVarIndex);*/
            return Raw2.GetVarIndexOfMemId(memid, out pVarIndex);
        }

        #endregion
        #region GetCustData

        /// <summary>
        /// Gets the custom data.
        /// </summary>
        /// <param name="guid">The GUID used to identify the data.</param>
        /// <returns>When this method returns, contains an <see langword="object"/> that specifies where to put the retrieved data. This parameter is passed uninitialized.</returns>
        public object GetCustData(Guid guid)
        {
            object pVarVal;
            TryGetCustData(guid, out pVarVal).ThrowOnNotOK();

            return pVarVal;
        }

        /// <summary>
        /// Gets the custom data.
        /// </summary>
        /// <param name="guid">The GUID used to identify the data.</param>
        /// <param name="pVarVal">When this method returns, contains an <see langword="object"/> that specifies where to put the retrieved data. This parameter is passed uninitialized.</param>
        public HRESULT TryGetCustData(Guid guid, out object pVarVal)
        {
            /*HRESULT GetCustData(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guid,
            [Out] out object pVarVal);*/
            return Raw2.GetCustData(guid, out pVarVal);
        }

        #endregion
        #region GetFuncCustData

        /// <summary>
        /// Gets the custom data from the specified function.
        /// </summary>
        /// <param name="index">The index of the function to get the custom data for.</param>
        /// <param name="guid">The GUID used to identify the data.</param>
        /// <returns>When this method returns, contains an <see langword="object"/> that specified where to put the data. This parameter is passed uninitialized.</returns>
        public object GetFuncCustData(int index, Guid guid)
        {
            object pVarVal;
            TryGetFuncCustData(index, guid, out pVarVal).ThrowOnNotOK();

            return pVarVal;
        }

        /// <summary>
        /// Gets the custom data from the specified function.
        /// </summary>
        /// <param name="index">The index of the function to get the custom data for.</param>
        /// <param name="guid">The GUID used to identify the data.</param>
        /// <param name="pVarVal">When this method returns, contains an <see langword="object"/> that specified where to put the data. This parameter is passed uninitialized.</param>
        public HRESULT TryGetFuncCustData(int index, Guid guid, out object pVarVal)
        {
            /*HRESULT GetFuncCustData(
            [In] int index,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guid,
            [Out] out object pVarVal);*/
            return Raw2.GetFuncCustData(index, guid, out pVarVal);
        }

        #endregion
        #region GetParamCustData

        /// <summary>
        /// Gets the specified custom data parameter.
        /// </summary>
        /// <param name="indexFunc">The index of the function to get the custom data for.</param>
        /// <param name="indexParam">The index of the parameter of this function to get the custom data for.</param>
        /// <param name="guid">The GUID used to identify the data.</param>
        /// <returns>When this method returns, contains an <see langword="object"/> that specifies where to put the retrieved data. This parameter is passed uninitialized.</returns>
        public object GetParamCustData(int indexFunc, int indexParam, Guid guid)
        {
            object pVarVal;
            TryGetParamCustData(indexFunc, indexParam, guid, out pVarVal).ThrowOnNotOK();

            return pVarVal;
        }

        /// <summary>
        /// Gets the specified custom data parameter.
        /// </summary>
        /// <param name="indexFunc">The index of the function to get the custom data for.</param>
        /// <param name="indexParam">The index of the parameter of this function to get the custom data for.</param>
        /// <param name="guid">The GUID used to identify the data.</param>
        /// <param name="pVarVal">When this method returns, contains an <see langword="object"/> that specifies where to put the retrieved data. This parameter is passed uninitialized.</param>
        public HRESULT TryGetParamCustData(int indexFunc, int indexParam, Guid guid, out object pVarVal)
        {
            /*HRESULT GetParamCustData(
            [In] int indexFunc,
            [In] int indexParam,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guid,
            [Out] out object pVarVal);*/
            return Raw2.GetParamCustData(indexFunc, indexParam, guid, out pVarVal);
        }

        #endregion
        #region GetVarCustData

        /// <summary>
        /// Gets the variable for the custom data.
        /// </summary>
        /// <param name="index">The index of the variable to get the custom data for.</param>
        /// <param name="guid">The GUID used to identify the data.</param>
        /// <returns>When this method returns, contains an <see langword="object"/> that specifies where to put the retrieved data. This parameter is passed uninitialized.</returns>
        public object GetVarCustData(int index, Guid guid)
        {
            object pVarVal;
            TryGetVarCustData(index, guid, out pVarVal).ThrowOnNotOK();

            return pVarVal;
        }

        /// <summary>
        /// Gets the variable for the custom data.
        /// </summary>
        /// <param name="index">The index of the variable to get the custom data for.</param>
        /// <param name="guid">The GUID used to identify the data.</param>
        /// <param name="pVarVal">When this method returns, contains an <see langword="object"/> that specifies where to put the retrieved data. This parameter is passed uninitialized.</param>
        public HRESULT TryGetVarCustData(int index, Guid guid, out object pVarVal)
        {
            /*HRESULT GetVarCustData(
            [In] int index,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guid,
            [Out] out object pVarVal);*/
            return Raw2.GetVarCustData(index, guid, out pVarVal);
        }

        #endregion
        #region GetImplTypeCustData

        /// <summary>
        /// Gets the implementation type of the custom data.
        /// </summary>
        /// <param name="index">The index of the implementation type for the custom data.</param>
        /// <param name="guid">The GUID used to identify the data.</param>
        /// <returns>When this method returns, contains an <see langword="object"/> that specifies where to put the retrieved data. This parameter is passed uninitialized.</returns>
        public object GetImplTypeCustData(int index, Guid guid)
        {
            object pVarVal;
            TryGetImplTypeCustData(index, guid, out pVarVal).ThrowOnNotOK();

            return pVarVal;
        }

        /// <summary>
        /// Gets the implementation type of the custom data.
        /// </summary>
        /// <param name="index">The index of the implementation type for the custom data.</param>
        /// <param name="guid">The GUID used to identify the data.</param>
        /// <param name="pVarVal">When this method returns, contains an <see langword="object"/> that specifies where to put the retrieved data. This parameter is passed uninitialized.</param>
        public HRESULT TryGetImplTypeCustData(int index, Guid guid, out object pVarVal)
        {
            /*HRESULT GetImplTypeCustData(
            [In] int index,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid guid,
            [Out] out object pVarVal);*/
            return Raw2.GetImplTypeCustData(index, guid, out pVarVal);
        }

        #endregion
        #region GetDocumentation2

        /// <summary>
        /// Retrieves the documentation string, the complete Help file name and path, the localization context to use, and the context ID for the library Help topic in the Help file.
        /// </summary>
        /// <param name="memid">The member identifier for the type description.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetDocumentation2Result GetDocumentation2(int memid)
        {
            GetDocumentation2Result result;
            TryGetDocumentation2(memid, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Retrieves the documentation string, the complete Help file name and path, the localization context to use, and the context ID for the library Help topic in the Help file.
        /// </summary>
        /// <param name="memid">The member identifier for the type description.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetDocumentation2(int memid, out GetDocumentation2Result result)
        {
            /*HRESULT GetDocumentation2(
            [In] int memid,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pbstrHelpString,
            [Out] out int pdwHelpStringContext,
            [Out, MarshalAs(UnmanagedType.BStr)] out string pbstrHelpStringDll);*/
            string pbstrHelpString;
            int pdwHelpStringContext;
            string pbstrHelpStringDll;
            HRESULT hr = Raw2.GetDocumentation2(memid, out pbstrHelpString, out pdwHelpStringContext, out pbstrHelpStringDll);

            if (hr == HRESULT.S_OK)
                result = new GetDocumentation2Result(pbstrHelpString, pdwHelpStringContext, pbstrHelpStringDll);
            else
                result = default(GetDocumentation2Result);

            return hr;
        }

        #endregion
        #region GetAllFuncCustData

        /// <summary>
        /// Gets all custom data from the specified function.
        /// </summary>
        /// <param name="index">The index of the function to get the custom data for.</param>
        /// <returns>A pointer to <see cref="CUSTDATA"/>, which holds all custom data items.</returns>
        public CUSTDATA GetAllFuncCustData(int index)
        {
            CUSTDATA pCustData;
            TryGetAllFuncCustData(index, out pCustData).ThrowOnNotOK();

            return pCustData;
        }

        /// <summary>
        /// Gets all custom data from the specified function.
        /// </summary>
        /// <param name="index">The index of the function to get the custom data for.</param>
        /// <param name="pCustData">A pointer to <see cref="CUSTDATA"/>, which holds all custom data items.</param>
        public HRESULT TryGetAllFuncCustData(int index, out CUSTDATA pCustData)
        {
            /*HRESULT GetAllFuncCustData(
            [In] int index,
            [Out] out CUSTDATA pCustData);*/
            return Raw2.GetAllFuncCustData(index, out pCustData);
        }

        #endregion
        #region GetAllParamCustData

        /// <summary>
        /// Gets all of the custom data for the specified function parameter.
        /// </summary>
        /// <param name="indexFunc">The index of the function to get the custom data for.</param>
        /// <param name="indexParam">The index of the parameter of this function to get the custom data for.</param>
        /// <returns>A pointer to <see cref="CUSTDATA"/>, which holds all custom data items.</returns>
        public CUSTDATA GetAllParamCustData(int indexFunc, int indexParam)
        {
            CUSTDATA pCustData;
            TryGetAllParamCustData(indexFunc, indexParam, out pCustData).ThrowOnNotOK();

            return pCustData;
        }

        /// <summary>
        /// Gets all of the custom data for the specified function parameter.
        /// </summary>
        /// <param name="indexFunc">The index of the function to get the custom data for.</param>
        /// <param name="indexParam">The index of the parameter of this function to get the custom data for.</param>
        /// <param name="pCustData">A pointer to <see cref="CUSTDATA"/>, which holds all custom data items.</param>
        public HRESULT TryGetAllParamCustData(int indexFunc, int indexParam, out CUSTDATA pCustData)
        {
            /*HRESULT GetAllParamCustData(
            [In] int indexFunc,
            [In] int indexParam,
            [Out] out CUSTDATA pCustData);*/
            return Raw2.GetAllParamCustData(indexFunc, indexParam, out pCustData);
        }

        #endregion
        #region GetAllVarCustData

        /// <summary>
        /// Gets the variable for the custom data.
        /// </summary>
        /// <param name="index">The index of the variable to get the custom data for.</param>
        /// <returns>A pointer to <see cref="CUSTDATA"/>, which holds all custom data items.</returns>
        public CUSTDATA GetAllVarCustData(int index)
        {
            CUSTDATA pCustData;
            TryGetAllVarCustData(index, out pCustData).ThrowOnNotOK();

            return pCustData;
        }

        /// <summary>
        /// Gets the variable for the custom data.
        /// </summary>
        /// <param name="index">The index of the variable to get the custom data for.</param>
        /// <param name="pCustData">A pointer to <see cref="CUSTDATA"/>, which holds all custom data items.</param>
        public HRESULT TryGetAllVarCustData(int index, out CUSTDATA pCustData)
        {
            /*HRESULT GetAllVarCustData(
            [In] int index,
            [Out] out CUSTDATA pCustData);*/
            return Raw2.GetAllVarCustData(index, out pCustData);
        }

        #endregion
        #region GetAllImplTypeCustData

        /// <summary>
        /// Gets all custom data for the specified implementation type.
        /// </summary>
        /// <param name="index">The index of the implementation type for the custom data.</param>
        /// <returns>A pointer to <see cref="CUSTDATA"/> which holds all custom data items.</returns>
        public CUSTDATA GetAllImplTypeCustData(int index)
        {
            CUSTDATA pCustData;
            TryGetAllImplTypeCustData(index, out pCustData).ThrowOnNotOK();

            return pCustData;
        }

        /// <summary>
        /// Gets all custom data for the specified implementation type.
        /// </summary>
        /// <param name="index">The index of the implementation type for the custom data.</param>
        /// <param name="pCustData">A pointer to <see cref="CUSTDATA"/> which holds all custom data items.</param>
        public HRESULT TryGetAllImplTypeCustData(int index, out CUSTDATA pCustData)
        {
            /*HRESULT GetAllImplTypeCustData(
            [In] int index,
            [Out] out CUSTDATA pCustData);*/
            return Raw2.GetAllImplTypeCustData(index, out pCustData);
        }

        #endregion
        #endregion
    }
}
