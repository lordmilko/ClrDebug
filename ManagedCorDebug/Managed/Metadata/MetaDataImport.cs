using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods for importing and manipulating existing metadata from a portable executable (PE) file or other source, such as a type library or a stand-alone, run-time metadata binary.
    /// </summary>
    /// <remarks>
    /// The design of the <see cref="IMetaDataImport"/> interface is intended primarily to be used by tools and services that will be
    /// importing type information (for example, development tools) or managing deployed components (for example, resolution/activation
    /// services). The methods in <see cref="IMetaDataImport"/> fall into the following task categories:
    /// </remarks>
    public class MetaDataImport : ComObject<IMetaDataImport>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetaDataImport"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public MetaDataImport(IMetaDataImport raw) : base(raw)
        {
        }

        #region IMetaDataImport
        #region ScopeProps

        /// <summary>
        /// Gets the name and optionally the version identifier of the assembly or module in the current metadata scope.
        /// </summary>
        public GetScopePropsResult ScopeProps
        {
            get
            {
                HRESULT hr;
                GetScopePropsResult result;

                if ((hr = TryGetScopeProps(out result)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return result;
            }
        }

        /// <summary>
        /// Gets the name and optionally the version identifier of the assembly or module in the current metadata scope.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// The <see cref="MetaDataEmit.SetModuleProps"/> method is used to set these properties.
        /// </remarks>
        public HRESULT TryGetScopeProps(out GetScopePropsResult result)
        {
            /*HRESULT GetScopeProps(
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szName,
            [In] int cchName,
            [Out] out int pchName,
            [Out] out Guid pmvid);*/
            StringBuilder szName = null;
            int cchName = 0;
            int pchName;
            Guid pmvid;
            HRESULT hr = Raw.GetScopeProps(szName, cchName, out pchName, out pmvid);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pchName;
            szName = new StringBuilder(pchName);
            hr = Raw.GetScopeProps(szName, cchName, out pchName, out pmvid);

            if (hr == HRESULT.S_OK)
            {
                result = new GetScopePropsResult(szName.ToString(), pmvid);

                return hr;
            }

            fail:
            result = default(GetScopePropsResult);

            return hr;
        }

        #endregion
        #region ModuleFromScope

        /// <summary>
        /// Gets a metadata token for the module referenced in the current metadata scope.
        /// </summary>
        public mdModule ModuleFromScope
        {
            get
            {
                HRESULT hr;
                mdModule pmd;

                if ((hr = TryGetModuleFromScope(out pmd)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pmd;
            }
        }

        /// <summary>
        /// Gets a metadata token for the module referenced in the current metadata scope.
        /// </summary>
        /// <param name="pmd">[out] A pointer to the token representing the module referenced in the current metadata scope.</param>
        public HRESULT TryGetModuleFromScope(out mdModule pmd)
        {
            /*HRESULT GetModuleFromScope([Out] out mdModule pmd);*/
            return Raw.GetModuleFromScope(out pmd);
        }

        #endregion
        #region CloseEnum

        /// <summary>
        /// Closes the enumerator that is identified by the specified handle.
        /// </summary>
        /// <param name="hEnum">[in] The handle for the enumerator to close.</param>
        /// <remarks>
        /// The handle specified by hEnum is obtained from a previous EnumName call (for example, <see cref="EnumTypeDefs"/>).
        /// </remarks>
        public void CloseEnum(IntPtr hEnum)
        {
            /*void CloseEnum([In] IntPtr hEnum);*/
            Raw.CloseEnum(hEnum);
        }

        #endregion
        #region CountEnum

        /// <summary>
        /// Gets the number of elements in the enumeration that was retrieved by the specified enumerator.
        /// </summary>
        /// <param name="hEnum">[in] The handle for the enumerator.</param>
        /// <returns>[out] The number of elements enumerated.</returns>
        /// <remarks>
        /// The handle specified by hEnum is obtained from a previous EnumName call (for example, <see cref="EnumTypeDefs"/>).
        /// </remarks>
        public int CountEnum(IntPtr hEnum)
        {
            HRESULT hr;
            int pulCount;

            if ((hr = TryCountEnum(hEnum, out pulCount)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pulCount;
        }

        /// <summary>
        /// Gets the number of elements in the enumeration that was retrieved by the specified enumerator.
        /// </summary>
        /// <param name="hEnum">[in] The handle for the enumerator.</param>
        /// <param name="pulCount">[out] The number of elements enumerated.</param>
        /// <remarks>
        /// The handle specified by hEnum is obtained from a previous EnumName call (for example, <see cref="EnumTypeDefs"/>).
        /// </remarks>
        public HRESULT TryCountEnum(IntPtr hEnum, out int pulCount)
        {
            /*HRESULT CountEnum([In] IntPtr hEnum, [Out] out int pulCount);*/
            return Raw.CountEnum(hEnum, out pulCount);
        }

        #endregion
        #region ResetEnum

        /// <summary>
        /// Resets the specified enumerator to the specified position.
        /// </summary>
        /// <param name="hEnum">[in] The enumerator to reset.</param>
        /// <param name="ulPos">[in] The new position at which to place the enumerator.</param>
        public void ResetEnum(IntPtr hEnum, int ulPos)
        {
            HRESULT hr;

            if ((hr = TryResetEnum(hEnum, ulPos)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Resets the specified enumerator to the specified position.
        /// </summary>
        /// <param name="hEnum">[in] The enumerator to reset.</param>
        /// <param name="ulPos">[in] The new position at which to place the enumerator.</param>
        public HRESULT TryResetEnum(IntPtr hEnum, int ulPos)
        {
            /*HRESULT ResetEnum([In] IntPtr hEnum, [In] int ulPos);*/
            return Raw.ResetEnum(hEnum, ulPos);
        }

        #endregion
        #region EnumTypeDefs

        /// <summary>
        /// Enumerates TypeDef tokens representing all types within the current scope.
        /// </summary>
        /// <param name="cMax">[in] The maximum size of the rTypeDefs array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The TypeDef token represents a type such as a class or an interface, as well as any type added via an extensibility
        /// mechanism.
        /// </remarks>
        public EnumTypeDefsResult EnumTypeDefs(int cMax)
        {
            HRESULT hr;
            EnumTypeDefsResult result;

            if ((hr = TryEnumTypeDefs(cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Enumerates TypeDef tokens representing all types within the current scope.
        /// </summary>
        /// <param name="cMax">[in] The maximum size of the rTypeDefs array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// | HRESULT | Description                                                         |
        /// | ------- | ------------------------------------------------------------------- |
        /// | S_OK    | EnumTypeDefs returned successfully.                                 |
        /// | S_FALSE | There are no tokens to enumerate. In that case, pcTypeDefs is zero. |
        /// </returns>
        /// <remarks>
        /// The TypeDef token represents a type such as a class or an interface, as well as any type added via an extensibility
        /// mechanism.
        /// </remarks>
        public HRESULT TryEnumTypeDefs(int cMax, out EnumTypeDefsResult result)
        {
            /*HRESULT EnumTypeDefs(
            [In, Out] ref IntPtr phEnum,
            [Out] out mdTypeDef[] typeDefs,
            [In] int cMax,
            [Out] out int pcTypeDefs);*/
            IntPtr phEnum = default(IntPtr);
            mdTypeDef[] typeDefs;
            int pcTypeDefs;
            HRESULT hr = Raw.EnumTypeDefs(ref phEnum, out typeDefs, cMax, out pcTypeDefs);

            if (hr == HRESULT.S_OK)
                result = new EnumTypeDefsResult(phEnum, typeDefs, pcTypeDefs);
            else
                result = default(EnumTypeDefsResult);

            return hr;
        }

        #endregion
        #region EnumInterfaceImpls

        /// <summary>
        /// Enumerates all interfaces implemented by the specified TypeDef.
        /// </summary>
        /// <param name="td">[in] The token of the TypeDef whose MethodDef tokens representing interface implementations are to be enumerated.</param>
        /// <param name="cMax">[in] The maximum length of the rImpls array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The enumeration returns a collection of <see cref="mdInterfaceImpl"/> tokens for each interface implemented by the specified
        /// TypeDef. Interface tokens are returned in the order the interfaces were specified (through DefineTypeDef or SetTypeDefProps).
        /// Properties of the returned <see cref="mdInterfaceImpl"/> tokens can be queried using <see cref="GetInterfaceImplProps"/>.
        /// </remarks>
        public EnumInterfaceImplsResult EnumInterfaceImpls(mdTypeDef td, int cMax)
        {
            HRESULT hr;
            EnumInterfaceImplsResult result;

            if ((hr = TryEnumInterfaceImpls(td, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Enumerates all interfaces implemented by the specified TypeDef.
        /// </summary>
        /// <param name="td">[in] The token of the TypeDef whose MethodDef tokens representing interface implementations are to be enumerated.</param>
        /// <param name="cMax">[in] The maximum length of the rImpls array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// | HRESULT | Description                                                                       |
        /// | ------- | --------------------------------------------------------------------------------- |
        /// | S_OK    | EnumInterfaceImpls returned successfully.                                         |
        /// | S_FALSE | There are no MethodDef tokens to enumerate. In that case, pcImpls is set to zero. |
        /// </returns>
        /// <remarks>
        /// The enumeration returns a collection of <see cref="mdInterfaceImpl"/> tokens for each interface implemented by the specified
        /// TypeDef. Interface tokens are returned in the order the interfaces were specified (through DefineTypeDef or SetTypeDefProps).
        /// Properties of the returned <see cref="mdInterfaceImpl"/> tokens can be queried using <see cref="GetInterfaceImplProps"/>.
        /// </remarks>
        public HRESULT TryEnumInterfaceImpls(mdTypeDef td, int cMax, out EnumInterfaceImplsResult result)
        {
            /*HRESULT EnumInterfaceImpls(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef td,
            [Out] out mdInterfaceImpl[] rImpls,
            [In] int cMax,
            [Out] out int pcImpls);*/
            IntPtr phEnum = default(IntPtr);
            mdInterfaceImpl[] rImpls;
            int pcImpls;
            HRESULT hr = Raw.EnumInterfaceImpls(ref phEnum, td, out rImpls, cMax, out pcImpls);

            if (hr == HRESULT.S_OK)
                result = new EnumInterfaceImplsResult(phEnum, rImpls, pcImpls);
            else
                result = default(EnumInterfaceImplsResult);

            return hr;
        }

        #endregion
        #region EnumTypeRefs

        /// <summary>
        /// Enumerates TypeRef tokens defined in the current metadata scope.
        /// </summary>
        /// <param name="cMax">[in] The maximum size of the rTypeRefs array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// A TypeRef token represents a reference to a type.
        /// </remarks>
        public EnumTypeRefsResult EnumTypeRefs(int cMax)
        {
            HRESULT hr;
            EnumTypeRefsResult result;

            if ((hr = TryEnumTypeRefs(cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Enumerates TypeRef tokens defined in the current metadata scope.
        /// </summary>
        /// <param name="cMax">[in] The maximum size of the rTypeRefs array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// | HRESULT | Description                                                         |
        /// | ------- | ------------------------------------------------------------------- |
        /// | S_OK    | EnumTypeRefs returned successfully.                                 |
        /// | S_FALSE | There are no tokens to enumerate. In that case, pcTypeRefs is zero. |
        /// </returns>
        /// <remarks>
        /// A TypeRef token represents a reference to a type.
        /// </remarks>
        public HRESULT TryEnumTypeRefs(int cMax, out EnumTypeRefsResult result)
        {
            /*HRESULT EnumTypeRefs(
            [In, Out] ref IntPtr phEnum,
            [Out] out mdTypeRef[] rTypeRefs,
            [In] int cMax,
            [Out] out int pcTypeRefs);*/
            IntPtr phEnum = default(IntPtr);
            mdTypeRef[] rTypeRefs;
            int pcTypeRefs;
            HRESULT hr = Raw.EnumTypeRefs(ref phEnum, out rTypeRefs, cMax, out pcTypeRefs);

            if (hr == HRESULT.S_OK)
                result = new EnumTypeRefsResult(phEnum, rTypeRefs, pcTypeRefs);
            else
                result = default(EnumTypeRefsResult);

            return hr;
        }

        #endregion
        #region FindTypeDefByName

        /// <summary>
        /// Gets a pointer to the TypeDef metadata token for the <see cref="Type"/> with the specified name.
        /// </summary>
        /// <param name="szTypeDef">[in] The name of the type for which to get the TypeDef token.</param>
        /// <param name="tkEnclosingClass">[in] A TypeDef or TypeRef token representing the enclosing class. If the type to find is not a nested class, set this value to NULL.</param>
        /// <returns>[out] A pointer to the matching TypeDef token.</returns>
        public mdTypeDef FindTypeDefByName(string szTypeDef, mdToken tkEnclosingClass)
        {
            HRESULT hr;
            mdTypeDef typeDef;

            if ((hr = TryFindTypeDefByName(szTypeDef, tkEnclosingClass, out typeDef)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return typeDef;
        }

        /// <summary>
        /// Gets a pointer to the TypeDef metadata token for the <see cref="Type"/> with the specified name.
        /// </summary>
        /// <param name="szTypeDef">[in] The name of the type for which to get the TypeDef token.</param>
        /// <param name="tkEnclosingClass">[in] A TypeDef or TypeRef token representing the enclosing class. If the type to find is not a nested class, set this value to NULL.</param>
        /// <param name="typeDef">[out] A pointer to the matching TypeDef token.</param>
        public HRESULT TryFindTypeDefByName(string szTypeDef, mdToken tkEnclosingClass, out mdTypeDef typeDef)
        {
            /*HRESULT FindTypeDefByName(
            [MarshalAs(UnmanagedType.LPWStr), In] string szTypeDef,
            [In] mdToken tkEnclosingClass,
            [Out] out mdTypeDef typeDef);*/
            return Raw.FindTypeDefByName(szTypeDef, tkEnclosingClass, out typeDef);
        }

        #endregion
        #region GetTypeDefProps

        /// <summary>
        /// Returns metadata information for the <see cref="Type"/> represented by the specified TypeDef token.
        /// </summary>
        /// <param name="td">[in] The TypeDef token that represents the type to return metadata for.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetTypeDefPropsResult GetTypeDefProps(mdTypeDef td)
        {
            HRESULT hr;
            GetTypeDefPropsResult result;

            if ((hr = TryGetTypeDefProps(td, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Returns metadata information for the <see cref="Type"/> represented by the specified TypeDef token.
        /// </summary>
        /// <param name="td">[in] The TypeDef token that represents the type to return metadata for.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetTypeDefProps(mdTypeDef td, out GetTypeDefPropsResult result)
        {
            /*HRESULT GetTypeDefProps(
            [In] mdTypeDef td,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szTypeDef,
            [In] int cchTypeDef,
            [Out] out int pchTypeDef,
            [Out] out CorTypeAttr pdwTypeDefFlags,
            [Out] out mdToken ptkExtends);*/
            StringBuilder szTypeDef = null;
            int cchTypeDef = 0;
            int pchTypeDef;
            CorTypeAttr pdwTypeDefFlags;
            mdToken ptkExtends;
            HRESULT hr = Raw.GetTypeDefProps(td, szTypeDef, cchTypeDef, out pchTypeDef, out pdwTypeDefFlags, out ptkExtends);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchTypeDef = pchTypeDef;
            szTypeDef = new StringBuilder(pchTypeDef);
            hr = Raw.GetTypeDefProps(td, szTypeDef, cchTypeDef, out pchTypeDef, out pdwTypeDefFlags, out ptkExtends);

            if (hr == HRESULT.S_OK)
            {
                result = new GetTypeDefPropsResult(szTypeDef.ToString(), pdwTypeDefFlags, ptkExtends);

                return hr;
            }

            fail:
            result = default(GetTypeDefPropsResult);

            return hr;
        }

        #endregion
        #region GetInterfaceImplProps

        /// <summary>
        /// Gets a pointer to the metadata tokens for the <see cref="Type"/> that implements the specified method, and for the interface that declares that method.
        /// </summary>
        /// <param name="iiImpl">[in] The metadata token representing the method to return the class and interface tokens for.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// You obtain the value for iImpl by calling the <see cref="EnumInterfaceImpls"/> method. For example, suppose that
        /// a class has an <see cref="mdTypeDef"/> token value of 0x02000007 and that it implements threeinterfaces whose types have tokens:
        /// Conceptually, this information is stored into an interface implementation table as: Recall, the token is a 4-byte
        /// value: GetInterfaceImplProps returns the information held in the row whose token you provide in the iImpl argument.
        /// </remarks>
        public GetInterfaceImplPropsResult GetInterfaceImplProps(mdInterfaceImpl iiImpl)
        {
            HRESULT hr;
            GetInterfaceImplPropsResult result;

            if ((hr = TryGetInterfaceImplProps(iiImpl, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets a pointer to the metadata tokens for the <see cref="Type"/> that implements the specified method, and for the interface that declares that method.
        /// </summary>
        /// <param name="iiImpl">[in] The metadata token representing the method to return the class and interface tokens for.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// You obtain the value for iImpl by calling the <see cref="EnumInterfaceImpls"/> method. For example, suppose that
        /// a class has an <see cref="mdTypeDef"/> token value of 0x02000007 and that it implements threeinterfaces whose types have tokens:
        /// Conceptually, this information is stored into an interface implementation table as: Recall, the token is a 4-byte
        /// value: GetInterfaceImplProps returns the information held in the row whose token you provide in the iImpl argument.
        /// </remarks>
        public HRESULT TryGetInterfaceImplProps(mdInterfaceImpl iiImpl, out GetInterfaceImplPropsResult result)
        {
            /*HRESULT GetInterfaceImplProps(
            [In] mdInterfaceImpl iiImpl,
            [Out] out mdTypeDef pClass,
            [Out] out mdToken ptkIface);*/
            mdTypeDef pClass;
            mdToken ptkIface;
            HRESULT hr = Raw.GetInterfaceImplProps(iiImpl, out pClass, out ptkIface);

            if (hr == HRESULT.S_OK)
                result = new GetInterfaceImplPropsResult(pClass, ptkIface);
            else
                result = default(GetInterfaceImplPropsResult);

            return hr;
        }

        #endregion
        #region GetTypeRefProps

        /// <summary>
        /// Gets the metadata associated with the <see cref="Type"/> referenced by the specified TypeRef token.
        /// </summary>
        /// <param name="tr">[in] The TypeRef token that represents the type to return metadata for.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetTypeRefPropsResult GetTypeRefProps(mdTypeRef tr)
        {
            HRESULT hr;
            GetTypeRefPropsResult result;

            if ((hr = TryGetTypeRefProps(tr, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the metadata associated with the <see cref="Type"/> referenced by the specified TypeRef token.
        /// </summary>
        /// <param name="tr">[in] The TypeRef token that represents the type to return metadata for.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetTypeRefProps(mdTypeRef tr, out GetTypeRefPropsResult result)
        {
            /*HRESULT GetTypeRefProps(
            [In] mdTypeRef tr,
            [Out] out mdToken ptkResolutionScope,
            [Out] StringBuilder szName,
            [In] int cchName,
            [Out] out int pchName);*/
            mdToken ptkResolutionScope;
            StringBuilder szName = null;
            int cchName = 0;
            int pchName;
            HRESULT hr = Raw.GetTypeRefProps(tr, out ptkResolutionScope, szName, cchName, out pchName);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pchName;
            szName = new StringBuilder(pchName);
            hr = Raw.GetTypeRefProps(tr, out ptkResolutionScope, szName, cchName, out pchName);

            if (hr == HRESULT.S_OK)
            {
                result = new GetTypeRefPropsResult(ptkResolutionScope, szName.ToString());

                return hr;
            }

            fail:
            result = default(GetTypeRefPropsResult);

            return hr;
        }

        #endregion
        #region ResolveTypeRef

        /// <summary>
        /// Resolves a <see cref="Type"/> reference represented by the specified TypeRef token.
        /// </summary>
        /// <param name="tr">[in] The TypeRef metadata token to return the referenced type information for.</param>
        /// <param name="riid">[in] The IID of the interface to return in ppIScope. Typically, this would be IID_IMetaDataImport.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The ResolveTypeRef method searches for the type definition in other modules. If the type definition is found, ResolveTypeRef
        /// returns an interface to that module scope as well as the TypeDef token for the type. If the type reference to be
        /// resolved has a resolution scope of AssemblyRef, the ResolveTypeRef method searches for a match only in the metadata
        /// scopes that have already been opened with calls to either the <see cref="MetaDataDispenser.OpenScope"/> method
        /// or the <see cref="MetaDataDispenser.OpenScopeOnMemory"/> method. This is because ResolveTypeRef cannot determine
        /// from only the AssemblyRef scope where on disk or in the global assembly cache the assembly is stored.
        /// </remarks>
        [Obsolete("This method no longer appears to exist in the IMetaDataImport vtable.")]
        public ResolveTypeRefResult ResolveTypeRef(mdTypeRef tr, Guid riid)
        {
            HRESULT hr;
            ResolveTypeRefResult result;

            if ((hr = TryResolveTypeRef(tr, riid, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Resolves a <see cref="Type"/> reference represented by the specified TypeRef token.
        /// </summary>
        /// <param name="tr">[in] The TypeRef metadata token to return the referenced type information for.</param>
        /// <param name="riid">[in] The IID of the interface to return in ppIScope. Typically, this would be IID_IMetaDataImport.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// The ResolveTypeRef method searches for the type definition in other modules. If the type definition is found, ResolveTypeRef
        /// returns an interface to that module scope as well as the TypeDef token for the type. If the type reference to be
        /// resolved has a resolution scope of AssemblyRef, the ResolveTypeRef method searches for a match only in the metadata
        /// scopes that have already been opened with calls to either the <see cref="MetaDataDispenser.OpenScope"/> method
        /// or the <see cref="MetaDataDispenser.OpenScopeOnMemory"/> method. This is because ResolveTypeRef cannot determine
        /// from only the AssemblyRef scope where on disk or in the global assembly cache the assembly is stored.
        /// </remarks>
        [Obsolete("This method no longer appears to exist in the IMetaDataImport vtable.")]
        public HRESULT TryResolveTypeRef(mdTypeRef tr, Guid riid, out ResolveTypeRefResult result)
        {
            /*HRESULT ResolveTypeRef(
            [In] mdTypeRef tr,
            [In] ref Guid riid,
            [MarshalAs(UnmanagedType.IUnknown), Out] out object ppIScope,
            [Out] out mdTypeDef ptd);*/
            object ppIScope;
            mdTypeDef ptd;
            HRESULT hr = Raw.ResolveTypeRef(tr, ref riid, out ppIScope, out ptd);

            if (hr == HRESULT.S_OK)
                result = new ResolveTypeRefResult(ppIScope, ptd);
            else
                result = default(ResolveTypeRefResult);

            return hr;
        }

        #endregion
        #region EnumMembers

        /// <summary>
        /// Enumerates MemberDef tokens representing members of the specified type.
        /// </summary>
        /// <param name="cl">[in] A TypeDef token representing the type whose members are to be enumerated.</param>
        /// <param name="cMax">[in] The maximum size of the rMembers array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// When enumerating collections of members for a class, EnumMembers returns only members (fields and methods, but
        /// not properties or events) defined directly on the class. It does not return any members that the class inherits,
        /// even if the class provides an implementation for those inherited members. To enumerate inherited members, the caller
        /// must explicitly walk the inheritance chain. Note that the rules for the inheritance chain may vary depending on
        /// the language or compiler that emitted the original metadata. Properties and events are not enumerated by EnumMembers.
        /// To enumerate those, use <see cref="EnumProperties"/> or <see cref="EnumEvents"/>.
        /// </remarks>
        public EnumMembersResult EnumMembers(mdTypeDef cl, int cMax)
        {
            HRESULT hr;
            EnumMembersResult result;

            if ((hr = TryEnumMembers(cl, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Enumerates MemberDef tokens representing members of the specified type.
        /// </summary>
        /// <param name="cl">[in] A TypeDef token representing the type whose members are to be enumerated.</param>
        /// <param name="cMax">[in] The maximum size of the rMembers array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// | HRESULT | Description                                                                 |
        /// | ------- | --------------------------------------------------------------------------- |
        /// | S_OK    | EnumMembers returned successfully.                                          |
        /// | S_FALSE | There are no MemberDef tokens to enumerate. In that case, pcTokens is zero. |
        /// </returns>
        /// <remarks>
        /// When enumerating collections of members for a class, EnumMembers returns only members (fields and methods, but
        /// not properties or events) defined directly on the class. It does not return any members that the class inherits,
        /// even if the class provides an implementation for those inherited members. To enumerate inherited members, the caller
        /// must explicitly walk the inheritance chain. Note that the rules for the inheritance chain may vary depending on
        /// the language or compiler that emitted the original metadata. Properties and events are not enumerated by EnumMembers.
        /// To enumerate those, use <see cref="EnumProperties"/> or <see cref="EnumEvents"/>.
        /// </remarks>
        public HRESULT TryEnumMembers(mdTypeDef cl, int cMax, out EnumMembersResult result)
        {
            /*HRESULT EnumMembers(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef cl,
            [Out] out mdToken[] rMembers,
            [In] int cMax,
            [Out] out int pcTokens);*/
            IntPtr phEnum = default(IntPtr);
            mdToken[] rMembers;
            int pcTokens;
            HRESULT hr = Raw.EnumMembers(ref phEnum, cl, out rMembers, cMax, out pcTokens);

            if (hr == HRESULT.S_OK)
                result = new EnumMembersResult(phEnum, rMembers, pcTokens);
            else
                result = default(EnumMembersResult);

            return hr;
        }

        #endregion
        #region EnumMembersWithName

        /// <summary>
        /// Enumerates MemberDef tokens representing members of the specified type with the specified name.
        /// </summary>
        /// <param name="cl">[in] A TypeDef token representing the type with members to enumerate.</param>
        /// <param name="szName">[in] The member name that limits the scope of the enumerator.</param>
        /// <param name="cMax">[in] The maximum size of the rMembers array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// This method enumerates fields and methods, but not properties or events. Unlike <see cref="EnumMembers"/>, EnumMembersWithName
        /// discards all field and member tokens that do not have the specified name.
        /// </remarks>
        public EnumMembersWithNameResult EnumMembersWithName(mdTypeDef cl, string szName, int cMax)
        {
            HRESULT hr;
            EnumMembersWithNameResult result;

            if ((hr = TryEnumMembersWithName(cl, szName, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Enumerates MemberDef tokens representing members of the specified type with the specified name.
        /// </summary>
        /// <param name="cl">[in] A TypeDef token representing the type with members to enumerate.</param>
        /// <param name="szName">[in] The member name that limits the scope of the enumerator.</param>
        /// <param name="cMax">[in] The maximum size of the rMembers array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// | HRESULT | Description                                                                 |
        /// | ------- | --------------------------------------------------------------------------- |
        /// | S_OK    | EnumTypeDefs returned successfully.                                         |
        /// | S_FALSE | There are no MemberDef tokens to enumerate. In that case, pcTokens is zero. |
        /// </returns>
        /// <remarks>
        /// This method enumerates fields and methods, but not properties or events. Unlike <see cref="EnumMembers"/>, EnumMembersWithName
        /// discards all field and member tokens that do not have the specified name.
        /// </remarks>
        public HRESULT TryEnumMembersWithName(mdTypeDef cl, string szName, int cMax, out EnumMembersWithNameResult result)
        {
            /*HRESULT EnumMembersWithName(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef cl,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [Out] out mdToken[] rMembers,
            [In] int cMax,
            [Out] out int pcTokens);*/
            IntPtr phEnum = default(IntPtr);
            mdToken[] rMembers;
            int pcTokens;
            HRESULT hr = Raw.EnumMembersWithName(ref phEnum, cl, szName, out rMembers, cMax, out pcTokens);

            if (hr == HRESULT.S_OK)
                result = new EnumMembersWithNameResult(phEnum, rMembers, pcTokens);
            else
                result = default(EnumMembersWithNameResult);

            return hr;
        }

        #endregion
        #region EnumMethods

        /// <summary>
        /// Enumerates MethodDef tokens representing methods of the specified type.
        /// </summary>
        /// <param name="cl">[in] A TypeDef token representing the type with the methods to enumerate.</param>
        /// <param name="cMax">[in] The maximum size of the MethodDef rMethods array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public EnumMethodsResult EnumMethods(mdTypeDef cl, int cMax)
        {
            HRESULT hr;
            EnumMethodsResult result;

            if ((hr = TryEnumMethods(cl, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Enumerates MethodDef tokens representing methods of the specified type.
        /// </summary>
        /// <param name="cl">[in] A TypeDef token representing the type with the methods to enumerate.</param>
        /// <param name="cMax">[in] The maximum size of the MethodDef rMethods array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// | HRESULT | Description                                                                 |
        /// | ------- | --------------------------------------------------------------------------- |
        /// | S_OK    | EnumMethods returned successfully.                                          |
        /// | S_FALSE | There are no MethodDef tokens to enumerate. In that case, pcTokens is zero. |
        /// </returns>
        public HRESULT TryEnumMethods(mdTypeDef cl, int cMax, out EnumMethodsResult result)
        {
            /*HRESULT EnumMethods(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef cl,
            [Out] out mdMethodDef[] rMethods,
            [In] int cMax,
            [Out] out int pcTokens);*/
            IntPtr phEnum = default(IntPtr);
            mdMethodDef[] rMethods;
            int pcTokens;
            HRESULT hr = Raw.EnumMethods(ref phEnum, cl, out rMethods, cMax, out pcTokens);

            if (hr == HRESULT.S_OK)
                result = new EnumMethodsResult(phEnum, rMethods, pcTokens);
            else
                result = default(EnumMethodsResult);

            return hr;
        }

        #endregion
        #region EnumMethodsWithName

        /// <summary>
        /// Enumerates methods that have the specified name and that are defined by the type referenced by the specified TypeDef token.
        /// </summary>
        /// <param name="cl">[in] A TypeDef token representing the type whose methods to enumerate.</param>
        /// <param name="cMax">[in] The maximum size of the rMethods array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// This method enumerates fields and methods, but not properties or events. Unlike <see cref="EnumMethods"/>, EnumMethodsWithName
        /// discards all method tokens that do not have the specified name.
        /// </remarks>
        public EnumMethodsWithNameResult EnumMethodsWithName(mdTypeDef cl, int cMax)
        {
            HRESULT hr;
            EnumMethodsWithNameResult result;

            if ((hr = TryEnumMethodsWithName(cl, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Enumerates methods that have the specified name and that are defined by the type referenced by the specified TypeDef token.
        /// </summary>
        /// <param name="cl">[in] A TypeDef token representing the type whose methods to enumerate.</param>
        /// <param name="cMax">[in] The maximum size of the rMethods array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// | HRESULT | Description                                                       |
        /// | ------- | ----------------------------------------------------------------- |
        /// | S_OK    | EnumMethodsWithName returned successfully.                        |
        /// | S_FALSE | There are no tokens to enumerate. In that case, pcTokens is zero. |
        /// </returns>
        /// <remarks>
        /// This method enumerates fields and methods, but not properties or events. Unlike <see cref="EnumMethods"/>, EnumMethodsWithName
        /// discards all method tokens that do not have the specified name.
        /// </remarks>
        public HRESULT TryEnumMethodsWithName(mdTypeDef cl, int cMax, out EnumMethodsWithNameResult result)
        {
            /*HRESULT EnumMethodsWithName(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef cl,
            [Out, MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [Out] out mdMethodDef[] rMethods,
            [In] int cMax,
            [Out] out int pcTokens);*/
            IntPtr phEnum = default(IntPtr);
            string szName = default(string);
            mdMethodDef[] rMethods;
            int pcTokens;
            HRESULT hr = Raw.EnumMethodsWithName(ref phEnum, cl, szName, out rMethods, cMax, out pcTokens);

            if (hr == HRESULT.S_OK)
                result = new EnumMethodsWithNameResult(phEnum, szName, rMethods, pcTokens);
            else
                result = default(EnumMethodsWithNameResult);

            return hr;
        }

        #endregion
        #region EnumFields

        /// <summary>
        /// Enumerates FieldDef tokens for the type referenced by the specified TypeDef token.
        /// </summary>
        /// <param name="cl">[in] The TypeDef token of the class whose fields are to be enumerated.</param>
        /// <param name="cMax">[in] The maximum size of the rFields array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public EnumFieldsResult EnumFields(mdTypeDef cl, int cMax)
        {
            HRESULT hr;
            EnumFieldsResult result;

            if ((hr = TryEnumFields(cl, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Enumerates FieldDef tokens for the type referenced by the specified TypeDef token.
        /// </summary>
        /// <param name="cl">[in] The TypeDef token of the class whose fields are to be enumerated.</param>
        /// <param name="cMax">[in] The maximum size of the rFields array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// | HRESULT | Description                                                       |
        /// | ------- | ----------------------------------------------------------------- |
        /// | S_OK    | EnumFields returned successfully.                                 |
        /// | S_FALSE | There are no fields to enumerate. In that case, pcTokens is zero. |
        /// </returns>
        public HRESULT TryEnumFields(mdTypeDef cl, int cMax, out EnumFieldsResult result)
        {
            /*HRESULT EnumFields(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef cl,
            [Out] out mdFieldDef[] rFields,
            [In] int cMax,
            [Out] out int pcTokens);*/
            IntPtr phEnum = default(IntPtr);
            mdFieldDef[] rFields;
            int pcTokens;
            HRESULT hr = Raw.EnumFields(ref phEnum, cl, out rFields, cMax, out pcTokens);

            if (hr == HRESULT.S_OK)
                result = new EnumFieldsResult(phEnum, rFields, pcTokens);
            else
                result = default(EnumFieldsResult);

            return hr;
        }

        #endregion
        #region EnumFieldsWithName

        /// <summary>
        /// Enumerates FieldDef tokens of the specified type with the specified name.
        /// </summary>
        /// <param name="cl">[in] The token of the type whose fields are to be enumerated.</param>
        /// <param name="szName">[in] The field name that limits the scope of the enumeration.</param>
        /// <param name="cMax">[in] The maximum size of the rFields array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// Unlike <see cref="EnumFields"/>, EnumFieldsWithName discards all field tokens that do not have the specified name.
        /// </remarks>
        public EnumFieldsWithNameResult EnumFieldsWithName(mdTypeDef cl, string szName, int cMax)
        {
            HRESULT hr;
            EnumFieldsWithNameResult result;

            if ((hr = TryEnumFieldsWithName(cl, szName, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Enumerates FieldDef tokens of the specified type with the specified name.
        /// </summary>
        /// <param name="cl">[in] The token of the type whose fields are to be enumerated.</param>
        /// <param name="szName">[in] The field name that limits the scope of the enumeration.</param>
        /// <param name="cMax">[in] The maximum size of the rFields array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// | HRESULT | Description                                                       |
        /// | ------- | ----------------------------------------------------------------- |
        /// | S_OK    | EnumFieldsWithName returned successfully.                         |
        /// | S_FALSE | There are no fields to enumerate. In that case, pcTokens is zero. |
        /// </returns>
        /// <remarks>
        /// Unlike <see cref="EnumFields"/>, EnumFieldsWithName discards all field tokens that do not have the specified name.
        /// </remarks>
        public HRESULT TryEnumFieldsWithName(mdTypeDef cl, string szName, int cMax, out EnumFieldsWithNameResult result)
        {
            /*HRESULT EnumFieldsWithName(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef cl,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [Out] out mdFieldDef[] rFields,
            [In] int cMax,
            [Out] out int pcTokens);*/
            IntPtr phEnum = default(IntPtr);
            mdFieldDef[] rFields;
            int pcTokens;
            HRESULT hr = Raw.EnumFieldsWithName(ref phEnum, cl, szName, out rFields, cMax, out pcTokens);

            if (hr == HRESULT.S_OK)
                result = new EnumFieldsWithNameResult(phEnum, rFields, pcTokens);
            else
                result = default(EnumFieldsWithNameResult);

            return hr;
        }

        #endregion
        #region EnumParams

        /// <summary>
        /// Enumerates ParamDef tokens representing the parameters of the method referenced by the specified MethodDef token.
        /// </summary>
        /// <param name="mb">[in] A MethodDef token representing the method with the parameters to enumerate.</param>
        /// <param name="cMax">[in] The maximum size of the rParams array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public EnumParamsResult EnumParams(mdMethodDef mb, int cMax)
        {
            HRESULT hr;
            EnumParamsResult result;

            if ((hr = TryEnumParams(mb, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Enumerates ParamDef tokens representing the parameters of the method referenced by the specified MethodDef token.
        /// </summary>
        /// <param name="mb">[in] A MethodDef token representing the method with the parameters to enumerate.</param>
        /// <param name="cMax">[in] The maximum size of the rParams array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// | HRESULT | Description                                                       |
        /// | ------- | ----------------------------------------------------------------- |
        /// | S_OK    | EnumParams returned successfully.                                 |
        /// | S_FALSE | There are no tokens to enumerate. In that case, pcTokens is zero. |
        /// </returns>
        public HRESULT TryEnumParams(mdMethodDef mb, int cMax, out EnumParamsResult result)
        {
            /*HRESULT EnumParams(
            [In, Out] ref IntPtr phEnum,
            [In] mdMethodDef mb,
            [Out] out mdParamDef[] rParams,
            [In] int cMax,
            [Out] out int pcTokens);*/
            IntPtr phEnum = default(IntPtr);
            mdParamDef[] rParams;
            int pcTokens;
            HRESULT hr = Raw.EnumParams(ref phEnum, mb, out rParams, cMax, out pcTokens);

            if (hr == HRESULT.S_OK)
                result = new EnumParamsResult(phEnum, rParams, pcTokens);
            else
                result = default(EnumParamsResult);

            return hr;
        }

        #endregion
        #region EnumMemberRefs

        /// <summary>
        /// Enumerates MemberRef tokens representing members of the specified type.
        /// </summary>
        /// <param name="tkParent">[in] A TypeDef, TypeRef, MethodDef, or ModuleRef token for the type whose members are to be enumerated.</param>
        /// <param name="cMax">[in] The maximum size of the rMemberRefs array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public EnumMemberRefsResult EnumMemberRefs(mdToken tkParent, int cMax)
        {
            HRESULT hr;
            EnumMemberRefsResult result;

            if ((hr = TryEnumMemberRefs(tkParent, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Enumerates MemberRef tokens representing members of the specified type.
        /// </summary>
        /// <param name="tkParent">[in] A TypeDef, TypeRef, MethodDef, or ModuleRef token for the type whose members are to be enumerated.</param>
        /// <param name="cMax">[in] The maximum size of the rMemberRefs array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// | HRESULT | Description                                                                    |
        /// | ------- | ------------------------------------------------------------------------------ |
        /// | S_OK    | EnumMemberRefs returned successfully.                                          |
        /// | S_FALSE | There are no MemberRef tokens to enumerate. In that case, pcTokens is to zero. |
        /// </returns>
        public HRESULT TryEnumMemberRefs(mdToken tkParent, int cMax, out EnumMemberRefsResult result)
        {
            /*HRESULT EnumMemberRefs(
            [In, Out] ref IntPtr phEnum,
            [In] mdToken tkParent,
            [Out] out mdMemberRef[] rMemberRefs,
            [In] int cMax,
            [Out] out int pcTokens);*/
            IntPtr phEnum = default(IntPtr);
            mdMemberRef[] rMemberRefs;
            int pcTokens;
            HRESULT hr = Raw.EnumMemberRefs(ref phEnum, tkParent, out rMemberRefs, cMax, out pcTokens);

            if (hr == HRESULT.S_OK)
                result = new EnumMemberRefsResult(phEnum, rMemberRefs, pcTokens);
            else
                result = default(EnumMemberRefsResult);

            return hr;
        }

        #endregion
        #region EnumMethodImpls

        /// <summary>
        /// Enumerates MethodBody and MethodDeclaration tokens representing methods of the specified type.
        /// </summary>
        /// <param name="td">[in] A TypeDef token for the type whose method implementations to enumerate.</param>
        /// <param name="cMax">[in] The maximum size of the rMethodBody and rMethodDecl arrays.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public EnumMethodImplsResult EnumMethodImpls(mdTypeDef td, int cMax)
        {
            HRESULT hr;
            EnumMethodImplsResult result;

            if ((hr = TryEnumMethodImpls(td, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Enumerates MethodBody and MethodDeclaration tokens representing methods of the specified type.
        /// </summary>
        /// <param name="td">[in] A TypeDef token for the type whose method implementations to enumerate.</param>
        /// <param name="cMax">[in] The maximum size of the rMethodBody and rMethodDecl arrays.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// | HRESULT | Description                                                              |
        /// | ------- | ------------------------------------------------------------------------ |
        /// | S_OK    | EnumMethodImpls returned successfully.                                   |
        /// | S_FALSE | There are no method tokens to enumerate. In that case, pcTokens is zero. |
        /// </returns>
        public HRESULT TryEnumMethodImpls(mdTypeDef td, int cMax, out EnumMethodImplsResult result)
        {
            /*HRESULT EnumMethodImpls(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef td,
            [Out] out mdToken[] rMethodBody,
            [Out] out mdToken[] rMethodDecl,
            [In] int cMax,
            [Out] out int pcTokens);*/
            IntPtr phEnum = default(IntPtr);
            mdToken[] rMethodBody;
            mdToken[] rMethodDecl;
            int pcTokens;
            HRESULT hr = Raw.EnumMethodImpls(ref phEnum, td, out rMethodBody, out rMethodDecl, cMax, out pcTokens);

            if (hr == HRESULT.S_OK)
                result = new EnumMethodImplsResult(phEnum, rMethodBody, rMethodDecl, pcTokens);
            else
                result = default(EnumMethodImplsResult);

            return hr;
        }

        #endregion
        #region EnumPermissionSets

        /// <summary>
        /// Enumerates permissions for the objects in a specified metadata scope.
        /// </summary>
        /// <param name="tk">[in] A metadata token that limits the scope of the search, or NULL to search the widest scope possible.</param>
        /// <param name="dwActions">[in] Flags representing the <see cref="SecurityAction"/> values to include in rPermission, or zero to return all actions.</param>
        /// <param name="cMax">[in] The maximum size of the rPermission array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public EnumPermissionSetsResult EnumPermissionSets(mdToken tk, SecurityAction dwActions, int cMax)
        {
            HRESULT hr;
            EnumPermissionSetsResult result;

            if ((hr = TryEnumPermissionSets(tk, dwActions, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Enumerates permissions for the objects in a specified metadata scope.
        /// </summary>
        /// <param name="tk">[in] A metadata token that limits the scope of the search, or NULL to search the widest scope possible.</param>
        /// <param name="dwActions">[in] Flags representing the <see cref="SecurityAction"/> values to include in rPermission, or zero to return all actions.</param>
        /// <param name="cMax">[in] The maximum size of the rPermission array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// | HRESULT | Description                                                       |
        /// | ------- | ----------------------------------------------------------------- |
        /// | S_OK    | EnumPermissionSets returned successfully.                         |
        /// | S_FALSE | There are no tokens to enumerate. In that case, pcTokens is zero. |
        /// </returns>
        public HRESULT TryEnumPermissionSets(mdToken tk, SecurityAction dwActions, int cMax, out EnumPermissionSetsResult result)
        {
            /*HRESULT EnumPermissionSets(
            [In, Out] ref IntPtr phEnum,
            [In] mdToken tk,
            [In] SecurityAction dwActions,
            [Out] out mdPermission[] rPermission,
            [In] int cMax,
            [Out] out int pcTokens);*/
            IntPtr phEnum = default(IntPtr);
            mdPermission[] rPermission;
            int pcTokens;
            HRESULT hr = Raw.EnumPermissionSets(ref phEnum, tk, dwActions, out rPermission, cMax, out pcTokens);

            if (hr == HRESULT.S_OK)
                result = new EnumPermissionSetsResult(phEnum, rPermission, pcTokens);
            else
                result = default(EnumPermissionSetsResult);

            return hr;
        }

        #endregion
        #region FindMember

        /// <summary>
        /// Gets a pointer to the MemberDef token for field or method that is enclosed by the specified <see cref="Type"/> and that has the specified name and metadata signature.
        /// </summary>
        /// <param name="td">[in] The TypeDef token for the class or interface that encloses the member to search for. If this value is mdTokenNil, the lookup is done for a global-variable or global-function.</param>
        /// <param name="szName">[in] The name of the member to search for.</param>
        /// <param name="pvSigBlob">[in] A pointer to the binary metadata signature of the member.</param>
        /// <param name="cbSigBlob">[in] The size in bytes of pvSigBlob.</param>
        /// <returns>[out] A pointer to the matching MemberDef token.</returns>
        /// <remarks>
        /// You specify the member using its enclosing class or interface (td), its name (szName), and optionally its signature
        /// (pvSigBlob). There might be multiple members with the same name in a class or interface. In that case, pass the
        /// member's signature to find the unique match. The signature passed to FindMember must have been generated in the
        /// current scope, because signatures are bound to a particular scope. A signature can embed a token that identifies
        /// the enclosing class or value type. The token is an index into the local TypeDef table. You cannot build a run-time
        /// signature outside the context of the current scope and use that signature as input to input to FindMember. FindMember
        /// finds only members that were defined directly in the class or interface; it does not find inherited members.
        /// </remarks>
        public mdToken FindMember(mdToken td, string szName, IntPtr pvSigBlob, int cbSigBlob)
        {
            HRESULT hr;
            mdToken pmb;

            if ((hr = TryFindMember(td, szName, pvSigBlob, cbSigBlob, out pmb)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pmb;
        }

        /// <summary>
        /// Gets a pointer to the MemberDef token for field or method that is enclosed by the specified <see cref="Type"/> and that has the specified name and metadata signature.
        /// </summary>
        /// <param name="td">[in] The TypeDef token for the class or interface that encloses the member to search for. If this value is mdTokenNil, the lookup is done for a global-variable or global-function.</param>
        /// <param name="szName">[in] The name of the member to search for.</param>
        /// <param name="pvSigBlob">[in] A pointer to the binary metadata signature of the member.</param>
        /// <param name="cbSigBlob">[in] The size in bytes of pvSigBlob.</param>
        /// <param name="pmb">[out] A pointer to the matching MemberDef token.</param>
        /// <remarks>
        /// You specify the member using its enclosing class or interface (td), its name (szName), and optionally its signature
        /// (pvSigBlob). There might be multiple members with the same name in a class or interface. In that case, pass the
        /// member's signature to find the unique match. The signature passed to FindMember must have been generated in the
        /// current scope, because signatures are bound to a particular scope. A signature can embed a token that identifies
        /// the enclosing class or value type. The token is an index into the local TypeDef table. You cannot build a run-time
        /// signature outside the context of the current scope and use that signature as input to input to FindMember. FindMember
        /// finds only members that were defined directly in the class or interface; it does not find inherited members.
        /// </remarks>
        public HRESULT TryFindMember(mdToken td, string szName, IntPtr pvSigBlob, int cbSigBlob, out mdToken pmb)
        {
            /*HRESULT FindMember(
            [In] mdToken td,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [In] IntPtr pvSigBlob,
            [In] int cbSigBlob,
            [Out] out mdToken pmb);*/
            return Raw.FindMember(td, szName, pvSigBlob, cbSigBlob, out pmb);
        }

        #endregion
        #region FindMethod

        /// <summary>
        /// Gets a pointer to the MethodDef token for the method that is enclosed by the specified <see cref="Type"/> and that has the specified name and metadata signature.
        /// </summary>
        /// <param name="td">[in] The <see cref="mdTypeDef"/> token for the type (a class or interface) that encloses the member to search for. If this value is mdTokenNil, then the lookup is done for a global function.</param>
        /// <param name="szName">[in] The name of the method to search for.</param>
        /// <param name="pvSigBlob">[in] A pointer to the binary metadata signature of the method.</param>
        /// <param name="cbSigBlob">[in] The size in bytes of pvSigBlob.</param>
        /// <returns>[out] A pointer to the matching MethodDef token.</returns>
        /// <remarks>
        /// You specify the method using its enclosing class or interface (td), its name (szName), and optionally its signature
        /// (pvSigBlob). There might be multiple methods with the same name in a class or interface. In that case, pass the
        /// method's signature to find the unique match. The signature passed to FindMethod must have been generated in the
        /// current scope, because signatures are bound to a particular scope. A signature can embed a token that identifies
        /// the enclosing class or value type. The token is an index into the local TypeDef table. You cannot build a run-time
        /// signature outside the context of the current scope and use that signature as input to input to FindMethod. FindMethod
        /// finds only methods that were defined directly in the class or interface; it does not find inherited methods.
        /// </remarks>
        public mdMethodDef FindMethod(mdToken td, string szName, IntPtr pvSigBlob, int cbSigBlob)
        {
            HRESULT hr;
            mdMethodDef pmb;

            if ((hr = TryFindMethod(td, szName, pvSigBlob, cbSigBlob, out pmb)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pmb;
        }

        /// <summary>
        /// Gets a pointer to the MethodDef token for the method that is enclosed by the specified <see cref="Type"/> and that has the specified name and metadata signature.
        /// </summary>
        /// <param name="td">[in] The <see cref="mdTypeDef"/> token for the type (a class or interface) that encloses the member to search for. If this value is mdTokenNil, then the lookup is done for a global function.</param>
        /// <param name="szName">[in] The name of the method to search for.</param>
        /// <param name="pvSigBlob">[in] A pointer to the binary metadata signature of the method.</param>
        /// <param name="cbSigBlob">[in] The size in bytes of pvSigBlob.</param>
        /// <param name="pmb">[out] A pointer to the matching MethodDef token.</param>
        /// <remarks>
        /// You specify the method using its enclosing class or interface (td), its name (szName), and optionally its signature
        /// (pvSigBlob). There might be multiple methods with the same name in a class or interface. In that case, pass the
        /// method's signature to find the unique match. The signature passed to FindMethod must have been generated in the
        /// current scope, because signatures are bound to a particular scope. A signature can embed a token that identifies
        /// the enclosing class or value type. The token is an index into the local TypeDef table. You cannot build a run-time
        /// signature outside the context of the current scope and use that signature as input to input to FindMethod. FindMethod
        /// finds only methods that were defined directly in the class or interface; it does not find inherited methods.
        /// </remarks>
        public HRESULT TryFindMethod(mdToken td, string szName, IntPtr pvSigBlob, int cbSigBlob, out mdMethodDef pmb)
        {
            /*HRESULT FindMethod(
            [In] mdToken td,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [In] IntPtr pvSigBlob,
            [In] int cbSigBlob,
            [Out] out mdMethodDef pmb);*/
            return Raw.FindMethod(td, szName, pvSigBlob, cbSigBlob, out pmb);
        }

        #endregion
        #region FindField

        /// <summary>
        /// Gets a pointer to the FieldDef token for the field that is enclosed by the specified <see cref="Type"/> and that has the specified name and metadata signature.
        /// </summary>
        /// <param name="td">[in] The TypeDef token for the class or interface that encloses the field to search for. If this value is mdTokenNil, the lookup is done for a global variable.</param>
        /// <param name="szName">[in] The name of the field to search for.</param>
        /// <param name="pvSigBlob">[in] A pointer to the binary metadata signature of the field.</param>
        /// <param name="cbSigBlob">[in] The size in bytes of pvSigBlob.</param>
        /// <returns>[out] A pointer to the matching FieldDef token.</returns>
        /// <remarks>
        /// You specify the field using its enclosing class or interface (td), its name (szName), and optionally its signature
        /// (pvSigBlob). The signature passed to FindField must have been generated in the current scope, because signatures
        /// are bound to a particular scope. A signature can embed a token that identifies the enclosing class or value type.
        /// (The token is an index into the local TypeDef table). You cannot build a run-time signature outside the context
        /// of the current scope and use that signature as input to FindField. FindField finds only fields that were defined
        /// directly in the class or interface; it does not find inherited fields.
        /// </remarks>
        public mdFieldDef FindField(mdToken td, string szName, IntPtr pvSigBlob, int cbSigBlob)
        {
            HRESULT hr;
            mdFieldDef pmb;

            if ((hr = TryFindField(td, szName, pvSigBlob, cbSigBlob, out pmb)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pmb;
        }

        /// <summary>
        /// Gets a pointer to the FieldDef token for the field that is enclosed by the specified <see cref="Type"/> and that has the specified name and metadata signature.
        /// </summary>
        /// <param name="td">[in] The TypeDef token for the class or interface that encloses the field to search for. If this value is mdTokenNil, the lookup is done for a global variable.</param>
        /// <param name="szName">[in] The name of the field to search for.</param>
        /// <param name="pvSigBlob">[in] A pointer to the binary metadata signature of the field.</param>
        /// <param name="cbSigBlob">[in] The size in bytes of pvSigBlob.</param>
        /// <param name="pmb">[out] A pointer to the matching FieldDef token.</param>
        /// <remarks>
        /// You specify the field using its enclosing class or interface (td), its name (szName), and optionally its signature
        /// (pvSigBlob). The signature passed to FindField must have been generated in the current scope, because signatures
        /// are bound to a particular scope. A signature can embed a token that identifies the enclosing class or value type.
        /// (The token is an index into the local TypeDef table). You cannot build a run-time signature outside the context
        /// of the current scope and use that signature as input to FindField. FindField finds only fields that were defined
        /// directly in the class or interface; it does not find inherited fields.
        /// </remarks>
        public HRESULT TryFindField(mdToken td, string szName, IntPtr pvSigBlob, int cbSigBlob, out mdFieldDef pmb)
        {
            /*HRESULT FindField(
            [In] mdToken td,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [In] IntPtr pvSigBlob,
            [In] int cbSigBlob,
            [Out] out mdFieldDef pmb);*/
            return Raw.FindField(td, szName, pvSigBlob, cbSigBlob, out pmb);
        }

        #endregion
        #region FindMemberRef

        /// <summary>
        /// Gets a pointer to the MemberRef token for the member reference that is enclosed by the specified <see cref="Type"/> and that has the specified name and metadata signature.
        /// </summary>
        /// <param name="td">[in] The TypeRef token for the class or interface that encloses the member reference to search for. If this value is mdTokenNil, the lookup is done for a global variable or a global-function reference.</param>
        /// <param name="szName">[in] The name of the member reference to search for.</param>
        /// <param name="pvSigBlob">[in] A pointer to the binary metadata signature of the member reference.</param>
        /// <param name="cbSigBlob">[in] The size in bytes of pvSigBlob.</param>
        /// <returns>[out] A pointer to the matching MemberRef token.</returns>
        /// <remarks>
        /// You specify the member using its enclosing class or interface (td), its name (szName), and optionally its signature
        /// (pvSigBlob). The signature passed to FindMemberRef must have been generated in the current scope, because signatures
        /// are bound to a particular scope. A signature can embed a token that identifies the enclosing class or value type.
        /// The token is an index into the local TypeDef table. You cannot build a run-time signature outside the context of
        /// the current scope and use that signature as input to FindMemberRef. FindMemberRef finds only member references
        /// that were defined directly in the class or interface; it does not find inherited member references.
        /// </remarks>
        public mdMemberRef FindMemberRef(mdToken td, string szName, IntPtr pvSigBlob, int cbSigBlob)
        {
            HRESULT hr;
            mdMemberRef pmr;

            if ((hr = TryFindMemberRef(td, szName, pvSigBlob, cbSigBlob, out pmr)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pmr;
        }

        /// <summary>
        /// Gets a pointer to the MemberRef token for the member reference that is enclosed by the specified <see cref="Type"/> and that has the specified name and metadata signature.
        /// </summary>
        /// <param name="td">[in] The TypeRef token for the class or interface that encloses the member reference to search for. If this value is mdTokenNil, the lookup is done for a global variable or a global-function reference.</param>
        /// <param name="szName">[in] The name of the member reference to search for.</param>
        /// <param name="pvSigBlob">[in] A pointer to the binary metadata signature of the member reference.</param>
        /// <param name="cbSigBlob">[in] The size in bytes of pvSigBlob.</param>
        /// <param name="pmr">[out] A pointer to the matching MemberRef token.</param>
        /// <remarks>
        /// You specify the member using its enclosing class or interface (td), its name (szName), and optionally its signature
        /// (pvSigBlob). The signature passed to FindMemberRef must have been generated in the current scope, because signatures
        /// are bound to a particular scope. A signature can embed a token that identifies the enclosing class or value type.
        /// The token is an index into the local TypeDef table. You cannot build a run-time signature outside the context of
        /// the current scope and use that signature as input to FindMemberRef. FindMemberRef finds only member references
        /// that were defined directly in the class or interface; it does not find inherited member references.
        /// </remarks>
        public HRESULT TryFindMemberRef(mdToken td, string szName, IntPtr pvSigBlob, int cbSigBlob, out mdMemberRef pmr)
        {
            /*HRESULT FindMemberRef(
            [In] mdToken td,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [In] IntPtr pvSigBlob, [In] int cbSigBlob,
            [Out] out mdMemberRef pmr);*/
            return Raw.FindMemberRef(td, szName, pvSigBlob, cbSigBlob, out pmr);
        }

        #endregion
        #region GetMethodProps

        /// <summary>
        /// Gets the metadata associated with the method referenced by the specified MethodDef token.
        /// </summary>
        /// <param name="mb">[in] The MethodDef token that represents the method to return metadata for.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public MetaDataImport_GetMethodPropsResult GetMethodProps(mdMethodDef mb)
        {
            HRESULT hr;
            MetaDataImport_GetMethodPropsResult result;

            if ((hr = TryGetMethodProps(mb, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the metadata associated with the method referenced by the specified MethodDef token.
        /// </summary>
        /// <param name="mb">[in] The MethodDef token that represents the method to return metadata for.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetMethodProps(mdMethodDef mb, out MetaDataImport_GetMethodPropsResult result)
        {
            /*HRESULT GetMethodProps(
            [In] mdMethodDef mb,
            [Out] out mdTypeDef pClass,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szMethod,
            [In] int cchMethod,
            [Out] out int pchMethod,
            [Out] out CorMethodAttr pdwAttr,
            [Out] out IntPtr ppvSigBlob,
            [Out] out int pcbSigBlob,
            [Out] out int pulCodeRVA,
            [Out] out int pdwImplFlags);*/
            mdTypeDef pClass;
            StringBuilder szMethod = null;
            int cchMethod = 0;
            int pchMethod;
            CorMethodAttr pdwAttr;
            IntPtr ppvSigBlob;
            int pcbSigBlob;
            int pulCodeRVA;
            int pdwImplFlags;
            HRESULT hr = Raw.GetMethodProps(mb, out pClass, szMethod, cchMethod, out pchMethod, out pdwAttr, out ppvSigBlob, out pcbSigBlob, out pulCodeRVA, out pdwImplFlags);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchMethod = pchMethod;
            szMethod = new StringBuilder(pchMethod);
            hr = Raw.GetMethodProps(mb, out pClass, szMethod, cchMethod, out pchMethod, out pdwAttr, out ppvSigBlob, out pcbSigBlob, out pulCodeRVA, out pdwImplFlags);

            if (hr == HRESULT.S_OK)
            {
                result = new MetaDataImport_GetMethodPropsResult(pClass, szMethod.ToString(), pdwAttr, ppvSigBlob, pcbSigBlob, pulCodeRVA, pdwImplFlags);

                return hr;
            }

            fail:
            result = default(MetaDataImport_GetMethodPropsResult);

            return hr;
        }

        #endregion
        #region GetMemberRefProps

        /// <summary>
        /// Gets metadata associated with the member referenced by the specified token.
        /// </summary>
        /// <param name="mr">[in] The MemberRef token to return associated metadata for.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetMemberRefPropsResult GetMemberRefProps(mdMemberRef mr)
        {
            HRESULT hr;
            GetMemberRefPropsResult result;

            if ((hr = TryGetMemberRefProps(mr, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets metadata associated with the member referenced by the specified token.
        /// </summary>
        /// <param name="mr">[in] The MemberRef token to return associated metadata for.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetMemberRefProps(mdMemberRef mr, out GetMemberRefPropsResult result)
        {
            /*HRESULT GetMemberRefProps(
            [In] mdMemberRef mr,
            [Out] out mdToken ptk,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szMember,
            [In] int cchMember,
            [Out] out int pchMember,
            [Out] out IntPtr ppvSigBlob,
            [Out] out int pbSig);*/
            mdToken ptk;
            StringBuilder szMember = null;
            int cchMember = 0;
            int pchMember;
            IntPtr ppvSigBlob;
            int pbSig;
            HRESULT hr = Raw.GetMemberRefProps(mr, out ptk, szMember, cchMember, out pchMember, out ppvSigBlob, out pbSig);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchMember = pchMember;
            szMember = new StringBuilder(pchMember);
            hr = Raw.GetMemberRefProps(mr, out ptk, szMember, cchMember, out pchMember, out ppvSigBlob, out pbSig);

            if (hr == HRESULT.S_OK)
            {
                result = new GetMemberRefPropsResult(ptk, szMember.ToString(), ppvSigBlob, pbSig);

                return hr;
            }

            fail:
            result = default(GetMemberRefPropsResult);

            return hr;
        }

        #endregion
        #region EnumProperties

        /// <summary>
        /// Enumerates PropertyDef tokens representing the properties of the type referenced by the specified TypeDef token.
        /// </summary>
        /// <param name="td">[in] A TypeDef token representing the type with properties to enumerate.</param>
        /// <param name="cMax">[in] The maximum size of the rProperties array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public EnumPropertiesResult EnumProperties(mdTypeDef td, int cMax)
        {
            HRESULT hr;
            EnumPropertiesResult result;

            if ((hr = TryEnumProperties(td, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Enumerates PropertyDef tokens representing the properties of the type referenced by the specified TypeDef token.
        /// </summary>
        /// <param name="td">[in] A TypeDef token representing the type with properties to enumerate.</param>
        /// <param name="cMax">[in] The maximum size of the rProperties array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// | HRESULT | Description                                                           |
        /// | ------- | --------------------------------------------------------------------- |
        /// | S_OK    | EnumProperties returned successfully.                                 |
        /// | S_FALSE | There are no tokens to enumerate. In that case, pcProperties is zero. |
        /// </returns>
        public HRESULT TryEnumProperties(mdTypeDef td, int cMax, out EnumPropertiesResult result)
        {
            /*HRESULT EnumProperties(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef td,
            [Out] mdProperty[] rProperties,
            [In] int cMax,
            [Out] out int pcProperties);*/
            IntPtr phEnum = default(IntPtr);
            mdProperty[] rProperties = default(mdProperty[]);
            int pcProperties;
            HRESULT hr = Raw.EnumProperties(ref phEnum, td, rProperties, cMax, out pcProperties);

            if (hr == HRESULT.S_OK)
                result = new EnumPropertiesResult(phEnum, rProperties, pcProperties);
            else
                result = default(EnumPropertiesResult);

            return hr;
        }

        #endregion
        #region EnumEvents

        /// <summary>
        /// Enumerates event definition tokens for the specified TypeDef token.
        /// </summary>
        /// <param name="td">[in] The TypeDef token whose event definitions are to be enumerated.</param>
        /// <param name="cMax">[in] The maximum size of the rEvents array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public EnumEventsResult EnumEvents(mdTypeDef td, int cMax)
        {
            HRESULT hr;
            EnumEventsResult result;

            if ((hr = TryEnumEvents(td, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Enumerates event definition tokens for the specified TypeDef token.
        /// </summary>
        /// <param name="td">[in] The TypeDef token whose event definitions are to be enumerated.</param>
        /// <param name="cMax">[in] The maximum size of the rEvents array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// | HRESULT | Description                                                       |
        /// | ------- | ----------------------------------------------------------------- |
        /// | S_OK    | EnumEvents returned successfully.                                 |
        /// | S_FALSE | There are no events to enumerate. In that case, pcEvents is zero. |
        /// </returns>
        public HRESULT TryEnumEvents(mdTypeDef td, int cMax, out EnumEventsResult result)
        {
            /*HRESULT EnumEvents(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef td,
            [Out] out mdEvent[] rEvents,
            [In] int cMax,
            [Out] out int pcEvents);*/
            IntPtr phEnum = default(IntPtr);
            mdEvent[] rEvents;
            int pcEvents;
            HRESULT hr = Raw.EnumEvents(ref phEnum, td, out rEvents, cMax, out pcEvents);

            if (hr == HRESULT.S_OK)
                result = new EnumEventsResult(phEnum, rEvents, pcEvents);
            else
                result = default(EnumEventsResult);

            return hr;
        }

        #endregion
        #region GetEventProps

        /// <summary>
        /// Gets metadata information for the event represented by the specified event token, including the declaring type, the add and remove methods for delegates, and any flags and other associated data.
        /// </summary>
        /// <param name="ev">[in] The event metadata token representing the event to get metadata for.</param>
        /// <param name="cMax">[in] The maximum size of the rmdOtherMethod array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetEventPropsResult GetEventProps(mdEvent ev, int cMax)
        {
            HRESULT hr;
            GetEventPropsResult result;

            if ((hr = TryGetEventProps(ev, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets metadata information for the event represented by the specified event token, including the declaring type, the add and remove methods for delegates, and any flags and other associated data.
        /// </summary>
        /// <param name="ev">[in] The event metadata token representing the event to get metadata for.</param>
        /// <param name="cMax">[in] The maximum size of the rmdOtherMethod array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetEventProps(mdEvent ev, int cMax, out GetEventPropsResult result)
        {
            /*HRESULT GetEventProps(
            [In] mdEvent ev,
            [Out] mdTypeDef pClass,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szEvent,
            [In] int cchEvent,
            [Out] out int pchEvent,
            [Out] out int pdwEventFlags,
            [Out] out mdToken ptkEventType,
            [Out] out mdMethodDef pmdAddOn,
            [Out] out mdMethodDef pmdRemoveOn,
            [Out] out mdMethodDef pmdFire,
            [Out] out mdMethodDef[] rmdOtherMethod,
            [In] int cMax,
            [Out] int pcOtherMethod);*/
            mdTypeDef pClass = default(mdTypeDef);
            StringBuilder szEvent = null;
            int cchEvent = 0;
            int pchEvent;
            int pdwEventFlags;
            mdToken ptkEventType;
            mdMethodDef pmdAddOn;
            mdMethodDef pmdRemoveOn;
            mdMethodDef pmdFire;
            mdMethodDef[] rmdOtherMethod;
            int pcOtherMethod = default(int);
            HRESULT hr = Raw.GetEventProps(ev, pClass, szEvent, cchEvent, out pchEvent, out pdwEventFlags, out ptkEventType, out pmdAddOn, out pmdRemoveOn, out pmdFire, out rmdOtherMethod, cMax, pcOtherMethod);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchEvent = pchEvent;
            szEvent = new StringBuilder(pchEvent);
            hr = Raw.GetEventProps(ev, pClass, szEvent, cchEvent, out pchEvent, out pdwEventFlags, out ptkEventType, out pmdAddOn, out pmdRemoveOn, out pmdFire, out rmdOtherMethod, cMax, pcOtherMethod);

            if (hr == HRESULT.S_OK)
            {
                result = new GetEventPropsResult(pClass, szEvent.ToString(), pdwEventFlags, ptkEventType, pmdAddOn, pmdRemoveOn, pmdFire, rmdOtherMethod, pcOtherMethod);

                return hr;
            }

            fail:
            result = default(GetEventPropsResult);

            return hr;
        }

        #endregion
        #region EnumMethodSemantics

        /// <summary>
        /// Enumerates the properties and the property-change events to which the specified method is related.
        /// </summary>
        /// <param name="mb">[in] A MethodDef token that limits the scope of the enumeration.</param>
        /// <param name="cMax">[in] The maximum size of the rEventProp array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// Many common language runtime types define PropertyChanged events and OnPropertyChanged methods related to their
        /// properties. For example, the System.Windows.Forms.Control type defines a System.Windows.Forms.Control.Font property,
        /// a System.Windows.Forms.Control.FontChanged event, and an System.Windows.Forms.Control.OnFontChanged method. The
        /// set accessor method of the System.Windows.Forms.Control.Font property calls System.Windows.Forms.Control.OnFontChanged
        /// method, which in turn raises the System.Windows.Forms.Control.FontChanged event. You would call EnumMethodSemantics
        /// using the MethodDef for System.Windows.Forms.Control.OnFontChanged to get references to the System.Windows.Forms.Control.Font
        /// property and the System.Windows.Forms.Control.FontChanged event.
        /// </remarks>
        public EnumMethodSemanticsResult EnumMethodSemantics(mdMethodDef mb, int cMax)
        {
            HRESULT hr;
            EnumMethodSemanticsResult result;

            if ((hr = TryEnumMethodSemantics(mb, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Enumerates the properties and the property-change events to which the specified method is related.
        /// </summary>
        /// <param name="mb">[in] A MethodDef token that limits the scope of the enumeration.</param>
        /// <param name="cMax">[in] The maximum size of the rEventProp array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// | HRESULT | Description                                                                        |
        /// | ------- | ---------------------------------------------------------------------------------- |
        /// | S_OK    | EnumMethodSemantics returned successfully.                                         |
        /// | S_FALSE | There are no events or properties to enumerate. In that case, pcEventProp is zero. |
        /// </returns>
        /// <remarks>
        /// Many common language runtime types define PropertyChanged events and OnPropertyChanged methods related to their
        /// properties. For example, the System.Windows.Forms.Control type defines a System.Windows.Forms.Control.Font property,
        /// a System.Windows.Forms.Control.FontChanged event, and an System.Windows.Forms.Control.OnFontChanged method. The
        /// set accessor method of the System.Windows.Forms.Control.Font property calls System.Windows.Forms.Control.OnFontChanged
        /// method, which in turn raises the System.Windows.Forms.Control.FontChanged event. You would call EnumMethodSemantics
        /// using the MethodDef for System.Windows.Forms.Control.OnFontChanged to get references to the System.Windows.Forms.Control.Font
        /// property and the System.Windows.Forms.Control.FontChanged event.
        /// </remarks>
        public HRESULT TryEnumMethodSemantics(mdMethodDef mb, int cMax, out EnumMethodSemanticsResult result)
        {
            /*HRESULT EnumMethodSemantics(
            [In, Out] ref IntPtr phEnum,
            [In] mdMethodDef mb,
            [Out] out mdToken[] rEventProp,
            [In] int cMax,
            [Out] out int pcEventProp);*/
            IntPtr phEnum = default(IntPtr);
            mdToken[] rEventProp;
            int pcEventProp;
            HRESULT hr = Raw.EnumMethodSemantics(ref phEnum, mb, out rEventProp, cMax, out pcEventProp);

            if (hr == HRESULT.S_OK)
                result = new EnumMethodSemanticsResult(phEnum, rEventProp, pcEventProp);
            else
                result = default(EnumMethodSemanticsResult);

            return hr;
        }

        #endregion
        #region GetMethodSemantics

        /// <summary>
        /// Gets flags indicating the relationship between the method referenced by the specified MethodDef token and the paired property and event referenced by the specified EventProp token.
        /// </summary>
        /// <param name="mb">[in] A MethodDef token representing the method to get the semantic role information for.</param>
        /// <param name="tkEventProp">[in] A token representing the paired property and event for which to get the method's role.</param>
        /// <returns>[out] A pointer to the associated semantics flags. This value is a bitmask from the <see cref="CorMethodSemanticsAttr"/> enumeration.</returns>
        /// <remarks>
        /// The <see cref="MetaDataEmit.DefineProperty"/> method sets a method's semantics flags.
        /// </remarks>
        public CorMethodSemanticsAttr GetMethodSemantics(mdMethodDef mb, mdToken tkEventProp)
        {
            HRESULT hr;
            CorMethodSemanticsAttr pdwSemanticsFlags;

            if ((hr = TryGetMethodSemantics(mb, tkEventProp, out pdwSemanticsFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pdwSemanticsFlags;
        }

        /// <summary>
        /// Gets flags indicating the relationship between the method referenced by the specified MethodDef token and the paired property and event referenced by the specified EventProp token.
        /// </summary>
        /// <param name="mb">[in] A MethodDef token representing the method to get the semantic role information for.</param>
        /// <param name="tkEventProp">[in] A token representing the paired property and event for which to get the method's role.</param>
        /// <param name="pdwSemanticsFlags">[out] A pointer to the associated semantics flags. This value is a bitmask from the <see cref="CorMethodSemanticsAttr"/> enumeration.</param>
        /// <remarks>
        /// The <see cref="MetaDataEmit.DefineProperty"/> method sets a method's semantics flags.
        /// </remarks>
        public HRESULT TryGetMethodSemantics(mdMethodDef mb, mdToken tkEventProp, out CorMethodSemanticsAttr pdwSemanticsFlags)
        {
            /*HRESULT GetMethodSemantics(
            [In] mdMethodDef mb,
            [In] mdToken tkEventProp,
            [Out] out CorMethodSemanticsAttr pdwSemanticsFlags);*/
            return Raw.GetMethodSemantics(mb, tkEventProp, out pdwSemanticsFlags);
        }

        #endregion
        #region GetClassLayout

        /// <summary>
        /// Gets layout information for the class referenced by the specified TypeDef token.
        /// </summary>
        /// <param name="td">[in] The TypeDef token for the class with the layout to return.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetClassLayoutResult GetClassLayout(mdTypeDef td)
        {
            HRESULT hr;
            GetClassLayoutResult result;

            if ((hr = TryGetClassLayout(td, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets layout information for the class referenced by the specified TypeDef token.
        /// </summary>
        /// <param name="td">[in] The TypeDef token for the class with the layout to return.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetClassLayout(mdTypeDef td, out GetClassLayoutResult result)
        {
            /*HRESULT GetClassLayout(
            [In] mdTypeDef td,
            [Out] int pdwPackSize,
            [MarshalAs(UnmanagedType.LPArray), Out] COR_FIELD_OFFSET[] rFieldOffset,
            [In] int cMax,
            [Out] int pcFieldOffset,
            [Out] int pulClassSize);*/
            int pdwPackSize = default(int);
            COR_FIELD_OFFSET[] rFieldOffset = null;
            int cMax = 0;
            int pcFieldOffset = default(int);
            int pulClassSize = default(int);
            HRESULT hr = Raw.GetClassLayout(td, pdwPackSize, rFieldOffset, cMax, pcFieldOffset, pulClassSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cMax = pcFieldOffset;
            rFieldOffset = new COR_FIELD_OFFSET[pcFieldOffset];
            hr = Raw.GetClassLayout(td, pdwPackSize, rFieldOffset, cMax, pcFieldOffset, pulClassSize);

            if (hr == HRESULT.S_OK)
            {
                result = new GetClassLayoutResult(pdwPackSize, rFieldOffset, pulClassSize);

                return hr;
            }

            fail:
            result = default(GetClassLayoutResult);

            return hr;
        }

        #endregion
        #region GetFieldMarshal

        /// <summary>
        /// Gets a pointer to the native, unmanaged type of the field represented by the specified field metadata token.
        /// </summary>
        /// <param name="tk">[in] The metadata token that represents the field to get interop marshalling information for.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetFieldMarshalResult GetFieldMarshal(mdToken tk)
        {
            HRESULT hr;
            GetFieldMarshalResult result;

            if ((hr = TryGetFieldMarshal(tk, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets a pointer to the native, unmanaged type of the field represented by the specified field metadata token.
        /// </summary>
        /// <param name="tk">[in] The metadata token that represents the field to get interop marshalling information for.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetFieldMarshal(mdToken tk, out GetFieldMarshalResult result)
        {
            /*HRESULT GetFieldMarshal(
            [In] mdToken tk,
            [Out] out IntPtr ppvNativeType,
            [Out] out int pcbNativeType);*/
            IntPtr ppvNativeType;
            int pcbNativeType;
            HRESULT hr = Raw.GetFieldMarshal(tk, out ppvNativeType, out pcbNativeType);

            if (hr == HRESULT.S_OK)
                result = new GetFieldMarshalResult(ppvNativeType, pcbNativeType);
            else
                result = default(GetFieldMarshalResult);

            return hr;
        }

        #endregion
        #region GetRVA

        /// <summary>
        /// Gets the relative virtual address (RVA) and the implementation flags of the method or field represented by the specified token.
        /// </summary>
        /// <param name="tk">[in] A MethodDef or FieldDef metadata token that represents the code object to return the RVA for. If the token is a FieldDef, the field must be a global variable.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetRVAResult GetRVA(mdToken tk)
        {
            HRESULT hr;
            GetRVAResult result;

            if ((hr = TryGetRVA(tk, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the relative virtual address (RVA) and the implementation flags of the method or field represented by the specified token.
        /// </summary>
        /// <param name="tk">[in] A MethodDef or FieldDef metadata token that represents the code object to return the RVA for. If the token is a FieldDef, the field must be a global variable.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetRVA(mdToken tk, out GetRVAResult result)
        {
            /*HRESULT GetRVA(
            [In] mdToken tk,
            [Out] out int pulCodeRVA,
            [Out] out CorMethodImpl pdwImplFlags);*/
            int pulCodeRVA;
            CorMethodImpl pdwImplFlags;
            HRESULT hr = Raw.GetRVA(tk, out pulCodeRVA, out pdwImplFlags);

            if (hr == HRESULT.S_OK)
                result = new GetRVAResult(pulCodeRVA, pdwImplFlags);
            else
                result = default(GetRVAResult);

            return hr;
        }

        #endregion
        #region GetPermissionSetProps

        /// <summary>
        /// Gets the metadata associated with the <see cref="PermissionSet"/> represented by the specified Permission token.
        /// </summary>
        /// <param name="pm">[in] The Permission metadata token that represents the permission set to get the metadata properties for.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetPermissionSetPropsResult GetPermissionSetProps(mdPermission pm)
        {
            HRESULT hr;
            GetPermissionSetPropsResult result;

            if ((hr = TryGetPermissionSetProps(pm, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the metadata associated with the <see cref="PermissionSet"/> represented by the specified Permission token.
        /// </summary>
        /// <param name="pm">[in] The Permission metadata token that represents the permission set to get the metadata properties for.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetPermissionSetProps(mdPermission pm, out GetPermissionSetPropsResult result)
        {
            /*HRESULT GetPermissionSetProps(
            [In] mdPermission pm,
            [Out] out int pdwAction,
            [Out] IntPtr ppvPermission,
            [Out] out int pcbPermission);*/
            int pdwAction;
            IntPtr ppvPermission = default(IntPtr);
            int pcbPermission;
            HRESULT hr = Raw.GetPermissionSetProps(pm, out pdwAction, ppvPermission, out pcbPermission);

            if (hr == HRESULT.S_OK)
                result = new GetPermissionSetPropsResult(pdwAction, ppvPermission, pcbPermission);
            else
                result = default(GetPermissionSetPropsResult);

            return hr;
        }

        #endregion
        #region GetSigFromToken

        /// <summary>
        /// Gets the binary metadata signature associated with the specified token.
        /// </summary>
        /// <param name="mdSig">[in] The token to return the binary metadata signature for.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetSigFromTokenResult GetSigFromToken(mdSignature mdSig)
        {
            HRESULT hr;
            GetSigFromTokenResult result;

            if ((hr = TryGetSigFromToken(mdSig, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the binary metadata signature associated with the specified token.
        /// </summary>
        /// <param name="mdSig">[in] The token to return the binary metadata signature for.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetSigFromToken(mdSignature mdSig, out GetSigFromTokenResult result)
        {
            /*HRESULT GetSigFromToken(
            [In] mdSignature mdSig,
            [Out] out IntPtr ppvSig,
            [Out] out int pcbSig);*/
            IntPtr ppvSig;
            int pcbSig;
            HRESULT hr = Raw.GetSigFromToken(mdSig, out ppvSig, out pcbSig);

            if (hr == HRESULT.S_OK)
                result = new GetSigFromTokenResult(ppvSig, pcbSig);
            else
                result = default(GetSigFromTokenResult);

            return hr;
        }

        #endregion
        #region GetModuleRefProps

        /// <summary>
        /// Gets the name of the module referenced by the specified metadata token.
        /// </summary>
        /// <param name="mur">[in] The ModuleRef metadata token that references the module to get metadata information for.</param>
        /// <returns>[out] A buffer to hold the module name.</returns>
        public string GetModuleRefProps(mdModuleRef mur)
        {
            HRESULT hr;
            string szNameResult;

            if ((hr = TryGetModuleRefProps(mur, out szNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szNameResult;
        }

        /// <summary>
        /// Gets the name of the module referenced by the specified metadata token.
        /// </summary>
        /// <param name="mur">[in] The ModuleRef metadata token that references the module to get metadata information for.</param>
        /// <param name="szNameResult">[out] A buffer to hold the module name.</param>
        public HRESULT TryGetModuleRefProps(mdModuleRef mur, out string szNameResult)
        {
            /*HRESULT GetModuleRefProps(
            [In] mdModuleRef mur,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szName,
            [In] int cchName,
            [Out] out int pchName);*/
            StringBuilder szName = null;
            int cchName = 0;
            int pchName;
            HRESULT hr = Raw.GetModuleRefProps(mur, szName, cchName, out pchName);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pchName;
            szName = new StringBuilder(pchName);
            hr = Raw.GetModuleRefProps(mur, szName, cchName, out pchName);

            if (hr == HRESULT.S_OK)
            {
                szNameResult = szName.ToString();

                return hr;
            }

            fail:
            szNameResult = default(string);

            return hr;
        }

        #endregion
        #region EnumModuleRefs

        /// <summary>
        /// Enumerates ModuleRef tokens that represent imported modules.
        /// </summary>
        /// <param name="cmax">[in] The maximum size of the rModuleRefs array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public EnumModuleRefsResult EnumModuleRefs(int cmax)
        {
            HRESULT hr;
            EnumModuleRefsResult result;

            if ((hr = TryEnumModuleRefs(cmax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Enumerates ModuleRef tokens that represent imported modules.
        /// </summary>
        /// <param name="cmax">[in] The maximum size of the rModuleRefs array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// | HRESULT | Description                                                           |
        /// | ------- | --------------------------------------------------------------------- |
        /// | S_OK    | EnumModuleRefs returned successfully.                                 |
        /// | S_FALSE | There are no tokens to enumerate. In that case, pcModuleRefs is zero. |
        /// </returns>
        public HRESULT TryEnumModuleRefs(int cmax, out EnumModuleRefsResult result)
        {
            /*HRESULT EnumModuleRefs(
            [In, Out] ref IntPtr phEnum,
            [Out] out mdModuleRef[] rModuleRefs,
            [In] int cmax,
            [Out] out int pcModuleRefs);*/
            IntPtr phEnum = default(IntPtr);
            mdModuleRef[] rModuleRefs;
            int pcModuleRefs;
            HRESULT hr = Raw.EnumModuleRefs(ref phEnum, out rModuleRefs, cmax, out pcModuleRefs);

            if (hr == HRESULT.S_OK)
                result = new EnumModuleRefsResult(phEnum, rModuleRefs, pcModuleRefs);
            else
                result = default(EnumModuleRefsResult);

            return hr;
        }

        #endregion
        #region GetTypeSpecFromToken

        /// <summary>
        /// Gets the binary metadata signature of the type specification represented by the specified token.
        /// </summary>
        /// <param name="typespec">[in] The TypeSpec token associated with the requested metadata signature.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetTypeSpecFromTokenResult GetTypeSpecFromToken(mdTypeSpec typespec)
        {
            HRESULT hr;
            GetTypeSpecFromTokenResult result;

            if ((hr = TryGetTypeSpecFromToken(typespec, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the binary metadata signature of the type specification represented by the specified token.
        /// </summary>
        /// <param name="typespec">[in] The TypeSpec token associated with the requested metadata signature.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>An <see cref="HRESULT"/> that indicates success or failure. Failures can be tested with the FAILED macro.</returns>
        public HRESULT TryGetTypeSpecFromToken(mdTypeSpec typespec, out GetTypeSpecFromTokenResult result)
        {
            /*HRESULT GetTypeSpecFromToken(
            [In] mdTypeSpec typespec,
            [Out] out IntPtr ppvSig,
            [Out] out int pcbSig);*/
            IntPtr ppvSig;
            int pcbSig;
            HRESULT hr = Raw.GetTypeSpecFromToken(typespec, out ppvSig, out pcbSig);

            if (hr == HRESULT.S_OK)
                result = new GetTypeSpecFromTokenResult(ppvSig, pcbSig);
            else
                result = default(GetTypeSpecFromTokenResult);

            return hr;
        }

        #endregion
        #region GetNameFromToken

        /// <summary>
        /// Gets the UTF-8 name of the object referenced by the specified metadata token. This method is obsolete.
        /// </summary>
        /// <param name="tk">[in] The token representing the object to return the name for.</param>
        /// <returns>[out] A pointer to the UTF-8 object name in the heap.</returns>
        /// <remarks>
        /// GetNameFromToken is obsolete. As an alternative, call a method to get the properties of the particular type of
        /// token required, such as GetFieldProps for a field or GetMethodProps for a method.
        /// </remarks>
        [Obsolete]
        public IntPtr GetNameFromToken(mdToken tk)
        {
            HRESULT hr;
            IntPtr pszUtf8NamePtr;

            if ((hr = TryGetNameFromToken(tk, out pszUtf8NamePtr)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pszUtf8NamePtr;
        }

        /// <summary>
        /// Gets the UTF-8 name of the object referenced by the specified metadata token. This method is obsolete.
        /// </summary>
        /// <param name="tk">[in] The token representing the object to return the name for.</param>
        /// <param name="pszUtf8NamePtr">[out] A pointer to the UTF-8 object name in the heap.</param>
        /// <remarks>
        /// GetNameFromToken is obsolete. As an alternative, call a method to get the properties of the particular type of
        /// token required, such as GetFieldProps for a field or GetMethodProps for a method.
        /// </remarks>
        [Obsolete]
        public HRESULT TryGetNameFromToken(mdToken tk, out IntPtr pszUtf8NamePtr)
        {
            /*HRESULT GetNameFromToken(
            [In] mdToken tk,
            [Out] out IntPtr pszUtf8NamePtr);*/
            return Raw.GetNameFromToken(tk, out pszUtf8NamePtr);
        }

        #endregion
        #region EnumUnresolvedMethods

        /// <summary>
        /// Enumerates MemberDef tokens representing the unresolved methods in the current metadata scope.
        /// </summary>
        /// <param name="cMax">[in] The maximum size of the rMethods array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// An unresolved method is one that has been declared but not implemented. A method is included in the enumeration
        /// if the method is marked miForwardRef and either mdPinvokeImpl or miRuntime is set to zero. In other words, an unresolved
        /// method is a class method that is marked miForwardRef but which is not implemented in unmanaged code (reached via
        /// PInvoke) nor implemented internally by the runtime itself The enumeration excludes all methods that are defined
        /// either at module scope (globals) or in interfaces or abstract classes.
        /// </remarks>
        public EnumUnresolvedMethodsResult EnumUnresolvedMethods(int cMax)
        {
            HRESULT hr;
            EnumUnresolvedMethodsResult result;

            if ((hr = TryEnumUnresolvedMethods(cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Enumerates MemberDef tokens representing the unresolved methods in the current metadata scope.
        /// </summary>
        /// <param name="cMax">[in] The maximum size of the rMethods array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// | HRESULT | Description                                                       |
        /// | ------- | ----------------------------------------------------------------- |
        /// | S_OK    | EnumUnresolvedMethods returned successfully.                      |
        /// | S_FALSE | There are no tokens to enumerate. In that case, pcTokens is zero. |
        /// </returns>
        /// <remarks>
        /// An unresolved method is one that has been declared but not implemented. A method is included in the enumeration
        /// if the method is marked miForwardRef and either mdPinvokeImpl or miRuntime is set to zero. In other words, an unresolved
        /// method is a class method that is marked miForwardRef but which is not implemented in unmanaged code (reached via
        /// PInvoke) nor implemented internally by the runtime itself The enumeration excludes all methods that are defined
        /// either at module scope (globals) or in interfaces or abstract classes.
        /// </remarks>
        public HRESULT TryEnumUnresolvedMethods(int cMax, out EnumUnresolvedMethodsResult result)
        {
            /*HRESULT EnumUnresolvedMethods(
            [In, Out] ref IntPtr phEnum,
            [Out] out mdToken[] rMethods,
            [In] int cMax,
            [Out] out int pcTokens);*/
            IntPtr phEnum = default(IntPtr);
            mdToken[] rMethods;
            int pcTokens;
            HRESULT hr = Raw.EnumUnresolvedMethods(ref phEnum, out rMethods, cMax, out pcTokens);

            if (hr == HRESULT.S_OK)
                result = new EnumUnresolvedMethodsResult(phEnum, rMethods, pcTokens);
            else
                result = default(EnumUnresolvedMethodsResult);

            return hr;
        }

        #endregion
        #region GetUserString

        /// <summary>
        /// Gets the literal string represented by the specified metadata token.
        /// </summary>
        /// <param name="stk">[in] The String token to return the associated string for.</param>
        /// <returns>[out] A copy of the requested string.</returns>
        public string GetUserString(mdString stk)
        {
            HRESULT hr;
            string szStringResult;

            if ((hr = TryGetUserString(stk, out szStringResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szStringResult;
        }

        /// <summary>
        /// Gets the literal string represented by the specified metadata token.
        /// </summary>
        /// <param name="stk">[in] The String token to return the associated string for.</param>
        /// <param name="szStringResult">[out] A copy of the requested string.</param>
        public HRESULT TryGetUserString(mdString stk, out string szStringResult)
        {
            /*HRESULT GetUserString(
            [In] mdString stk,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szString,
            [In] int cchString,
            [Out] out int pchString);*/
            StringBuilder szString = null;
            int cchString = 0;
            int pchString;
            HRESULT hr = Raw.GetUserString(stk, szString, cchString, out pchString);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchString = pchString;
            szString = new StringBuilder(pchString);
            hr = Raw.GetUserString(stk, szString, cchString, out pchString);

            if (hr == HRESULT.S_OK)
            {
                szStringResult = szString.ToString();

                return hr;
            }

            fail:
            szStringResult = default(string);

            return hr;
        }

        #endregion
        #region GetPinvokeMap

        /// <summary>
        /// Gets a ModuleRef token to represent the target assembly of a PInvoke call.
        /// </summary>
        /// <param name="tk">[in] A FieldDef or MethodDef token to get the PInvoke mapping metadata for.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetPinvokeMapResult GetPinvokeMap(mdToken tk)
        {
            HRESULT hr;
            GetPinvokeMapResult result;

            if ((hr = TryGetPinvokeMap(tk, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets a ModuleRef token to represent the target assembly of a PInvoke call.
        /// </summary>
        /// <param name="tk">[in] A FieldDef or MethodDef token to get the PInvoke mapping metadata for.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetPinvokeMap(mdToken tk, out GetPinvokeMapResult result)
        {
            /*HRESULT GetPinvokeMap(
            [In] mdToken tk,
            [Out] CorPinvokeMap pdwMappingFlags,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szImportName,
            [In] int cchImportName,
            [Out] int pchImportName,
            [Out] out mdModuleRef pmrImportDLL);*/
            CorPinvokeMap pdwMappingFlags = default(CorPinvokeMap);
            StringBuilder szImportName = null;
            int cchImportName = 0;
            int pchImportName = default(int);
            mdModuleRef pmrImportDLL;
            HRESULT hr = Raw.GetPinvokeMap(tk, pdwMappingFlags, szImportName, cchImportName, pchImportName, out pmrImportDLL);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchImportName = pchImportName;
            szImportName = new StringBuilder(pchImportName);
            hr = Raw.GetPinvokeMap(tk, pdwMappingFlags, szImportName, cchImportName, pchImportName, out pmrImportDLL);

            if (hr == HRESULT.S_OK)
            {
                result = new GetPinvokeMapResult(pdwMappingFlags, szImportName.ToString(), pmrImportDLL);

                return hr;
            }

            fail:
            result = default(GetPinvokeMapResult);

            return hr;
        }

        #endregion
        #region EnumSignatures

        /// <summary>
        /// Enumerates Signature tokens representing stand-alone signatures in the current scope.
        /// </summary>
        /// <param name="cmax">[in] The maximum size of the rSignatures array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The Signature tokens are created by the <see cref="MetaDataEmit.GetTokenFromSig"/> method.
        /// </remarks>
        public EnumSignaturesResult EnumSignatures(int cmax)
        {
            HRESULT hr;
            EnumSignaturesResult result;

            if ((hr = TryEnumSignatures(cmax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Enumerates Signature tokens representing stand-alone signatures in the current scope.
        /// </summary>
        /// <param name="cmax">[in] The maximum size of the rSignatures array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// | HRESULT | Description                                                           |
        /// | ------- | --------------------------------------------------------------------- |
        /// | S_OK    | EnumSignatures returned successfully.                                 |
        /// | S_FALSE | There are no tokens to enumerate. In that case, pcSignatures is zero. |
        /// </returns>
        /// <remarks>
        /// The Signature tokens are created by the <see cref="MetaDataEmit.GetTokenFromSig"/> method.
        /// </remarks>
        public HRESULT TryEnumSignatures(int cmax, out EnumSignaturesResult result)
        {
            /*HRESULT EnumSignatures(
            [In, Out] ref IntPtr phEnum,
            [Out] out mdSignature[] rSignatures,
            [In] int cmax,
            [Out] out int pcSignatures);*/
            IntPtr phEnum = default(IntPtr);
            mdSignature[] rSignatures;
            int pcSignatures;
            HRESULT hr = Raw.EnumSignatures(ref phEnum, out rSignatures, cmax, out pcSignatures);

            if (hr == HRESULT.S_OK)
                result = new EnumSignaturesResult(phEnum, rSignatures, pcSignatures);
            else
                result = default(EnumSignaturesResult);

            return hr;
        }

        #endregion
        #region EnumTypeSpecs

        /// <summary>
        /// Enumerates TypeSpec tokens defined in the current metadata scope.
        /// </summary>
        /// <param name="cmax">[in] The maximum size of the rTypeSpecs array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The TypeSpec tokens are created by the <see cref="MetaDataEmit.GetTokenFromTypeSpec"/> method.
        /// </remarks>
        public EnumTypeSpecsResult EnumTypeSpecs(int cmax)
        {
            HRESULT hr;
            EnumTypeSpecsResult result;

            if ((hr = TryEnumTypeSpecs(cmax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Enumerates TypeSpec tokens defined in the current metadata scope.
        /// </summary>
        /// <param name="cmax">[in] The maximum size of the rTypeSpecs array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// | HRESULT | Description                                                          |
        /// | ------- | -------------------------------------------------------------------- |
        /// | S_OK    | EnumTypeSpecs returned successfully.                                 |
        /// | S_FALSE | There are no tokens to enumerate. In that case, pcTypeSpecs is zero. |
        /// </returns>
        /// <remarks>
        /// The TypeSpec tokens are created by the <see cref="MetaDataEmit.GetTokenFromTypeSpec"/> method.
        /// </remarks>
        public HRESULT TryEnumTypeSpecs(int cmax, out EnumTypeSpecsResult result)
        {
            /*HRESULT EnumTypeSpecs(
            [In, Out] ref IntPtr phEnum,
            [Out] out mdTypeSpec[] rTypeSpecs,
            [In] int cmax,
            [Out] out int pcTypeSpecs);*/
            IntPtr phEnum = default(IntPtr);
            mdTypeSpec[] rTypeSpecs;
            int pcTypeSpecs;
            HRESULT hr = Raw.EnumTypeSpecs(ref phEnum, out rTypeSpecs, cmax, out pcTypeSpecs);

            if (hr == HRESULT.S_OK)
                result = new EnumTypeSpecsResult(phEnum, rTypeSpecs, pcTypeSpecs);
            else
                result = default(EnumTypeSpecsResult);

            return hr;
        }

        #endregion
        #region EnumUserStrings

        /// <summary>
        /// Enumerates String tokens representing hard-coded strings in the current metadata scope.
        /// </summary>
        /// <param name="cmax">[in] The maximum size of the rStrings array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The String tokens are created by the <see cref="MetaDataEmit.DefineUserString"/> method. This method is designed
        /// to be used by a metadata browser rather than by a compiler.
        /// </remarks>
        public EnumUserStringsResult EnumUserStrings(int cmax)
        {
            HRESULT hr;
            EnumUserStringsResult result;

            if ((hr = TryEnumUserStrings(cmax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Enumerates String tokens representing hard-coded strings in the current metadata scope.
        /// </summary>
        /// <param name="cmax">[in] The maximum size of the rStrings array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// | HRESULT | Description                                                        |
        /// | ------- | ------------------------------------------------------------------ |
        /// | S_OK    | EnumUserStrings returned successfully.                             |
        /// | S_FALSE | There are no tokens to enumerate. In that case, pcStrings is zero. |
        /// </returns>
        /// <remarks>
        /// The String tokens are created by the <see cref="MetaDataEmit.DefineUserString"/> method. This method is designed
        /// to be used by a metadata browser rather than by a compiler.
        /// </remarks>
        public HRESULT TryEnumUserStrings(int cmax, out EnumUserStringsResult result)
        {
            /*HRESULT EnumUserStrings(
            [In, Out] ref IntPtr phEnum,
            [Out] out mdString[] rStrings,
            [In] int cmax,
            [Out] out int pcStrings);*/
            IntPtr phEnum = default(IntPtr);
            mdString[] rStrings;
            int pcStrings;
            HRESULT hr = Raw.EnumUserStrings(ref phEnum, out rStrings, cmax, out pcStrings);

            if (hr == HRESULT.S_OK)
                result = new EnumUserStringsResult(phEnum, rStrings, pcStrings);
            else
                result = default(EnumUserStringsResult);

            return hr;
        }

        #endregion
        #region GetParamForMethodIndex

        /// <summary>
        /// Gets the token that represents a specified parameter of the method represented by the specified MethodDef token.
        /// </summary>
        /// <param name="md">[in] A token that represents the method to return the parameter token for.</param>
        /// <param name="ulParamSeq">[in] The ordinal position in the parameter list where the requested parameter occurs. Parameters are numbered starting from one, with the method's return value in position zero.</param>
        /// <returns>[out] A pointer to a ParamDef token that represents the requested parameter.</returns>
        public mdParamDef GetParamForMethodIndex(mdMethodDef md, int ulParamSeq)
        {
            HRESULT hr;
            mdParamDef ppd;

            if ((hr = TryGetParamForMethodIndex(md, ulParamSeq, out ppd)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppd;
        }

        /// <summary>
        /// Gets the token that represents a specified parameter of the method represented by the specified MethodDef token.
        /// </summary>
        /// <param name="md">[in] A token that represents the method to return the parameter token for.</param>
        /// <param name="ulParamSeq">[in] The ordinal position in the parameter list where the requested parameter occurs. Parameters are numbered starting from one, with the method's return value in position zero.</param>
        /// <param name="ppd">[out] A pointer to a ParamDef token that represents the requested parameter.</param>
        public HRESULT TryGetParamForMethodIndex(mdMethodDef md, int ulParamSeq, out mdParamDef ppd)
        {
            /*HRESULT GetParamForMethodIndex(
            [In] mdMethodDef md,
            [In] int ulParamSeq,
            [Out] out mdParamDef ppd);*/
            return Raw.GetParamForMethodIndex(md, ulParamSeq, out ppd);
        }

        #endregion
        #region EnumCustomAttributes

        /// <summary>
        /// Enumerates custom attribute-definition tokens associated with the specified type or member.
        /// </summary>
        /// <param name="tk">[in] A token for the scope of the enumeration, or zero for all custom attributes.</param>
        /// <param name="tkType">[in] A token for the constructor of the type of the attributes to be enumerated, or null for all types.</param>
        /// <param name="cMax">[in] The maximum size of the rCustomAttributes array.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public EnumCustomAttributesResult EnumCustomAttributes(mdToken tk, mdToken tkType, int cMax)
        {
            HRESULT hr;
            EnumCustomAttributesResult result;

            if ((hr = TryEnumCustomAttributes(tk, tkType, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Enumerates custom attribute-definition tokens associated with the specified type or member.
        /// </summary>
        /// <param name="tk">[in] A token for the scope of the enumeration, or zero for all custom attributes.</param>
        /// <param name="tkType">[in] A token for the constructor of the type of the attributes to be enumerated, or null for all types.</param>
        /// <param name="cMax">[in] The maximum size of the rCustomAttributes array.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// | HRESULT | Description                                                                            |
        /// | ------- | -------------------------------------------------------------------------------------- |
        /// | S_OK    | EnumCustomAttributes returned successfully.                                            |
        /// | S_FALSE | There are no custom attributes to enumerate. In that case, pcCustomAttributes is zero. |
        /// </returns>
        public HRESULT TryEnumCustomAttributes(mdToken tk, mdToken tkType, int cMax, out EnumCustomAttributesResult result)
        {
            /*HRESULT EnumCustomAttributes(
            [In, Out] ref IntPtr phEnum,
            [In] mdToken tk,
            [In] mdToken tkType,
            [Out] out mdCustomAttribute[] rCustomAttributes,
            [In] int cMax,
            [Out] out int pcCustomAttributes);*/
            IntPtr phEnum = default(IntPtr);
            mdCustomAttribute[] rCustomAttributes;
            int pcCustomAttributes;
            HRESULT hr = Raw.EnumCustomAttributes(ref phEnum, tk, tkType, out rCustomAttributes, cMax, out pcCustomAttributes);

            if (hr == HRESULT.S_OK)
                result = new EnumCustomAttributesResult(phEnum, rCustomAttributes, pcCustomAttributes);
            else
                result = default(EnumCustomAttributesResult);

            return hr;
        }

        #endregion
        #region GetCustomAttributeProps

        /// <summary>
        /// Gets the value of the custom attribute, given its metadata token.
        /// </summary>
        /// <param name="cv">[in] A metadata token that represents the custom attribute to be retrieved.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// A custom attribute is stored as an array of data, the format which is understood by the metadata engine.
        /// </remarks>
        public GetCustomAttributePropsResult GetCustomAttributeProps(mdCustomAttribute cv)
        {
            HRESULT hr;
            GetCustomAttributePropsResult result;

            if ((hr = TryGetCustomAttributeProps(cv, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the value of the custom attribute, given its metadata token.
        /// </summary>
        /// <param name="cv">[in] A metadata token that represents the custom attribute to be retrieved.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// A custom attribute is stored as an array of data, the format which is understood by the metadata engine.
        /// </remarks>
        public HRESULT TryGetCustomAttributeProps(mdCustomAttribute cv, out GetCustomAttributePropsResult result)
        {
            /*HRESULT GetCustomAttributeProps(
            [In] mdCustomAttribute cv,
            [Out] out mdToken ptkObj,
            [Out] out mdToken ptkType,
            [Out] out IntPtr ppBlob,
            [Out] out int pcbSize);*/
            mdToken ptkObj;
            mdToken ptkType;
            IntPtr ppBlob;
            int pcbSize;
            HRESULT hr = Raw.GetCustomAttributeProps(cv, out ptkObj, out ptkType, out ppBlob, out pcbSize);

            if (hr == HRESULT.S_OK)
                result = new GetCustomAttributePropsResult(ptkObj, ptkType, ppBlob, pcbSize);
            else
                result = default(GetCustomAttributePropsResult);

            return hr;
        }

        #endregion
        #region FindTypeRef

        /// <summary>
        /// Gets a pointer to the TypeRef token for the <see cref="Type"/> reference that is in the specified scope and that has the specified name.
        /// </summary>
        /// <param name="tkResolutionScope">[in] A ModuleRef, AssemblyRef, or TypeRef token that specifies the module, assembly, or type, respectively, in which the type reference is defined.</param>
        /// <param name="szName">[in] The name of the type reference to search for.</param>
        /// <returns>[out] A pointer to the matching TypeRef token.</returns>
        public mdTypeRef FindTypeRef(mdToken tkResolutionScope, string szName)
        {
            HRESULT hr;
            mdTypeRef ptr;

            if ((hr = TryFindTypeRef(tkResolutionScope, szName, out ptr)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ptr;
        }

        /// <summary>
        /// Gets a pointer to the TypeRef token for the <see cref="Type"/> reference that is in the specified scope and that has the specified name.
        /// </summary>
        /// <param name="tkResolutionScope">[in] A ModuleRef, AssemblyRef, or TypeRef token that specifies the module, assembly, or type, respectively, in which the type reference is defined.</param>
        /// <param name="szName">[in] The name of the type reference to search for.</param>
        /// <param name="ptr">[out] A pointer to the matching TypeRef token.</param>
        public HRESULT TryFindTypeRef(mdToken tkResolutionScope, string szName, out mdTypeRef ptr)
        {
            /*HRESULT FindTypeRef(
            [In] mdToken tkResolutionScope,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [Out] out mdTypeRef ptr);*/
            return Raw.FindTypeRef(tkResolutionScope, szName, out ptr);
        }

        #endregion
        #region GetMemberProps

        /// <summary>
        /// Gets information stored in the metadata for a specified member definition, including the name, binary signature, and relative virtual address, of the <see cref="Type"/> member referenced by the specified metadata token.<para/>
        /// This is a simple helper method: if mb is a MethodDef, then GetMethodProps is called; if mb is a FieldDef, then GetFieldProps is called.<para/>
        /// See these other methods for details.
        /// </summary>
        /// <param name="mb">[in] The token that references the member to get the associated metadata for.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetMemberPropsResult GetMemberProps(mdToken mb)
        {
            HRESULT hr;
            GetMemberPropsResult result;

            if ((hr = TryGetMemberProps(mb, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets information stored in the metadata for a specified member definition, including the name, binary signature, and relative virtual address, of the <see cref="Type"/> member referenced by the specified metadata token.<para/>
        /// This is a simple helper method: if mb is a MethodDef, then GetMethodProps is called; if mb is a FieldDef, then GetFieldProps is called.<para/>
        /// See these other methods for details.
        /// </summary>
        /// <param name="mb">[in] The token that references the member to get the associated metadata for.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetMemberProps(mdToken mb, out GetMemberPropsResult result)
        {
            /*HRESULT GetMemberProps(
            [In] mdToken mb,
            [Out] out mdTypeDef pClass,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szMember,
            [In] int cchMember,
            [Out] out int pchMember,
            [Out] out int pdwAttr, //if its a method is it cormethodattr?
            [Out] out IntPtr ppvSigBlob,
            [Out] out int pcbSigBlob,
            [Out] out int pulCodeRVA,
            [Out] out int pdwImplFlags,
            [Out] out CorElementType pdwCPlusTypeFlag,
            [Out] out IntPtr ppValue,
            [Out] out int pcchValue);*/
            mdTypeDef pClass;
            StringBuilder szMember = null;
            int cchMember = 0;
            int pchMember;
            int pdwAttr;
            IntPtr ppvSigBlob;
            int pcbSigBlob;
            int pulCodeRVA;
            int pdwImplFlags;
            CorElementType pdwCPlusTypeFlag;
            IntPtr ppValue;
            int pcchValue;
            HRESULT hr = Raw.GetMemberProps(mb, out pClass, szMember, cchMember, out pchMember, out pdwAttr, out ppvSigBlob, out pcbSigBlob, out pulCodeRVA, out pdwImplFlags, out pdwCPlusTypeFlag, out ppValue, out pcchValue);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchMember = pchMember;
            szMember = new StringBuilder(pchMember);
            hr = Raw.GetMemberProps(mb, out pClass, szMember, cchMember, out pchMember, out pdwAttr, out ppvSigBlob, out pcbSigBlob, out pulCodeRVA, out pdwImplFlags, out pdwCPlusTypeFlag, out ppValue, out pcchValue);

            if (hr == HRESULT.S_OK)
            {
                result = new GetMemberPropsResult(pClass, szMember.ToString(), pdwAttr, ppvSigBlob, pcbSigBlob, pulCodeRVA, pdwImplFlags, pdwCPlusTypeFlag, ppValue, pcchValue);

                return hr;
            }

            fail:
            result = default(GetMemberPropsResult);

            return hr;
        }

        #endregion
        #region GetFieldProps

        /// <summary>
        /// Gets metadata associated with the field referenced by the specified FieldDef token.
        /// </summary>
        /// <param name="mb">[in] A FieldDef token that represents the field to get associated metadata for.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetFieldPropsResult GetFieldProps(mdFieldDef mb)
        {
            HRESULT hr;
            GetFieldPropsResult result;

            if ((hr = TryGetFieldProps(mb, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets metadata associated with the field referenced by the specified FieldDef token.
        /// </summary>
        /// <param name="mb">[in] A FieldDef token that represents the field to get associated metadata for.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetFieldProps(mdFieldDef mb, out GetFieldPropsResult result)
        {
            /*HRESULT GetFieldProps(
            [In] mdFieldDef mb,
            [Out] mdTypeDef pClass,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szField,
            [In] int cchField,
            [Out] int pchField,
            [Out] CorFieldAttr pdwAttr,
            [Out] IntPtr ppvSigBlob,
            [Out] int pcbSigBlob,
            [Out] CorElementType pdwCPlusTypeFlag,
            [Out] IntPtr ppValue,
            [Out] int pcchValue);*/
            mdTypeDef pClass = default(mdTypeDef);
            StringBuilder szField = null;
            int cchField = 0;
            int pchField = default(int);
            CorFieldAttr pdwAttr = default(CorFieldAttr);
            IntPtr ppvSigBlob = default(IntPtr);
            int pcbSigBlob = default(int);
            CorElementType pdwCPlusTypeFlag = default(CorElementType);
            IntPtr ppValue = default(IntPtr);
            int pcchValue = default(int);
            HRESULT hr = Raw.GetFieldProps(mb, pClass, szField, cchField, pchField, pdwAttr, ppvSigBlob, pcbSigBlob, pdwCPlusTypeFlag, ppValue, pcchValue);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchField = pchField;
            szField = new StringBuilder(pchField);
            hr = Raw.GetFieldProps(mb, pClass, szField, cchField, pchField, pdwAttr, ppvSigBlob, pcbSigBlob, pdwCPlusTypeFlag, ppValue, pcchValue);

            if (hr == HRESULT.S_OK)
            {
                result = new GetFieldPropsResult(pClass, szField.ToString(), pdwAttr, ppvSigBlob, pcbSigBlob, pdwCPlusTypeFlag, ppValue, pcchValue);

                return hr;
            }

            fail:
            result = default(GetFieldPropsResult);

            return hr;
        }

        #endregion
        #region GetPropertyProps

        /// <summary>
        /// Gets the metadata for the property represented by the specified token.
        /// </summary>
        /// <param name="prop">[in] A token that represents the property to return metadata for.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetPropertyPropsResult GetPropertyProps(mdProperty prop)
        {
            HRESULT hr;
            GetPropertyPropsResult result;

            if ((hr = TryGetPropertyProps(prop, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the metadata for the property represented by the specified token.
        /// </summary>
        /// <param name="prop">[in] A token that represents the property to return metadata for.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetPropertyProps(mdProperty prop, out GetPropertyPropsResult result)
        {
            /*HRESULT GetPropertyProps(
            [In] mdProperty prop,
            [Out] mdTypeDef pClass,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szProperty,
            [In] int cchProperty,
            [Out] int pchProperty,
            [Out] CorPropertyAttr pdwPropFlags,
            [Out] IntPtr ppvSig,
            [Out] int pbSig,
            [Out] CorElementType pdwCPlusTypeFlag,
            [Out] IntPtr ppDefaultValue,
            [Out] int pcchDefaultValue,
            [Out] mdMethodDef pmdSetter,
            [Out] mdMethodDef pmdGetter,
            [Out, MarshalAs(UnmanagedType.LPArray)] mdMethodDef[] rmdOtherMethod,
            [In] int cMax,
            [Out] int pcOtherMethod);*/
            mdTypeDef pClass = default(mdTypeDef);
            StringBuilder szProperty = null;
            int cchProperty = 0;
            int pchProperty = default(int);
            CorPropertyAttr pdwPropFlags = default(CorPropertyAttr);
            IntPtr ppvSig = default(IntPtr);
            int pbSig = default(int);
            CorElementType pdwCPlusTypeFlag = default(CorElementType);
            IntPtr ppDefaultValue = default(IntPtr);
            int pcchDefaultValue = default(int);
            mdMethodDef pmdSetter = default(mdMethodDef);
            mdMethodDef pmdGetter = default(mdMethodDef);
            mdMethodDef[] rmdOtherMethod = null;
            int cMax = 0;
            int pcOtherMethod = default(int);
            HRESULT hr = Raw.GetPropertyProps(prop, pClass, szProperty, cchProperty, pchProperty, pdwPropFlags, ppvSig, pbSig, pdwCPlusTypeFlag, ppDefaultValue, pcchDefaultValue, pmdSetter, pmdGetter, rmdOtherMethod, cMax, pcOtherMethod);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchProperty = pchProperty;
            szProperty = new StringBuilder(pchProperty);
            cMax = pcOtherMethod;
            rmdOtherMethod = new mdMethodDef[pcOtherMethod];
            hr = Raw.GetPropertyProps(prop, pClass, szProperty, cchProperty, pchProperty, pdwPropFlags, ppvSig, pbSig, pdwCPlusTypeFlag, ppDefaultValue, pcchDefaultValue, pmdSetter, pmdGetter, rmdOtherMethod, cMax, pcOtherMethod);

            if (hr == HRESULT.S_OK)
            {
                result = new GetPropertyPropsResult(pClass, szProperty.ToString(), pdwPropFlags, ppvSig, pbSig, pdwCPlusTypeFlag, ppDefaultValue, pcchDefaultValue, pmdSetter, pmdGetter, rmdOtherMethod);

                return hr;
            }

            fail:
            result = default(GetPropertyPropsResult);

            return hr;
        }

        #endregion
        #region GetParamProps

        /// <summary>
        /// Gets metadata values for the parameter referenced by the specified ParamDef token.
        /// </summary>
        /// <param name="tk">[in] A ParamDef token that represents the parameter to return metadata for.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// The sequence values in pulSequence begin with 1 for parameters. A return value has a sequence number of 0.
        /// </remarks>
        public GetParamPropsResult GetParamProps(mdParamDef tk)
        {
            HRESULT hr;
            GetParamPropsResult result;

            if ((hr = TryGetParamProps(tk, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets metadata values for the parameter referenced by the specified ParamDef token.
        /// </summary>
        /// <param name="tk">[in] A ParamDef token that represents the parameter to return metadata for.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// The sequence values in pulSequence begin with 1 for parameters. A return value has a sequence number of 0.
        /// </remarks>
        public HRESULT TryGetParamProps(mdParamDef tk, out GetParamPropsResult result)
        {
            /*HRESULT GetParamProps(
            [In] mdParamDef tk,
            [Out] mdMethodDef pmd,
            [Out] int pulSequence,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szName,
            [Out] int cchName,
            [Out] int pchName,
            [Out] CorParamAttr pdwAttr,
            [Out] CorElementType pdwCPlusTypeFlag,
            [Out] IntPtr ppValue,
            [Out] IntPtr pcchValue);*/
            mdMethodDef pmd = default(mdMethodDef);
            int pulSequence = default(int);
            StringBuilder szName = null;
            int cchName = default(int);
            int pchName = default(int);
            CorParamAttr pdwAttr = default(CorParamAttr);
            CorElementType pdwCPlusTypeFlag = default(CorElementType);
            IntPtr ppValue = default(IntPtr);
            IntPtr pcchValue = default(IntPtr);
            HRESULT hr = Raw.GetParamProps(tk, pmd, pulSequence, szName, cchName, pchName, pdwAttr, pdwCPlusTypeFlag, ppValue, pcchValue);

            if (hr == HRESULT.S_OK)
                result = new GetParamPropsResult(pmd, pulSequence, szName.ToString(), cchName, pchName, pdwAttr, pdwCPlusTypeFlag, ppValue, pcchValue);
            else
                result = default(GetParamPropsResult);

            return hr;
        }

        #endregion
        #region GetCustomAttributeByName

        /// <summary>
        /// Gets the custom attribute, given its name and owner.
        /// </summary>
        /// <param name="tkObj">[in] A metadata token representing the object that owns the custom attribute.</param>
        /// <param name="szName">[in] The name of the custom attribute.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// It is legal to define multiple custom attributes for the same owner; they may even have the same name. However,
        /// GetCustomAttributeByName returns only one instance. (GetCustomAttributeByName returns the first instance that it
        /// encounters.) To find all instances of a custom attribute, call the <see cref="EnumCustomAttributes"/> method.
        /// </remarks>
        public GetCustomAttributeByNameResult GetCustomAttributeByName(mdToken tkObj, string szName)
        {
            HRESULT hr;
            GetCustomAttributeByNameResult result;

            if ((hr = TryGetCustomAttributeByName(tkObj, szName, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the custom attribute, given its name and owner.
        /// </summary>
        /// <param name="tkObj">[in] A metadata token representing the object that owns the custom attribute.</param>
        /// <param name="szName">[in] The name of the custom attribute.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// It is legal to define multiple custom attributes for the same owner; they may even have the same name. However,
        /// GetCustomAttributeByName returns only one instance. (GetCustomAttributeByName returns the first instance that it
        /// encounters.) To find all instances of a custom attribute, call the <see cref="EnumCustomAttributes"/> method.
        /// </remarks>
        public HRESULT TryGetCustomAttributeByName(mdToken tkObj, string szName, out GetCustomAttributeByNameResult result)
        {
            /*HRESULT GetCustomAttributeByName(
            [In] mdToken tkObj,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [Out] IntPtr ppData,
            [Out] int pcbData);*/
            IntPtr ppData = default(IntPtr);
            int pcbData = default(int);
            HRESULT hr = Raw.GetCustomAttributeByName(tkObj, szName, ppData, pcbData);

            if (hr == HRESULT.S_OK)
                result = new GetCustomAttributeByNameResult(ppData, pcbData);
            else
                result = default(GetCustomAttributeByNameResult);

            return hr;
        }

        #endregion
        #region IsValidToken

        /// <summary>
        /// Gets a value indicating whether the specified token holds a valid reference to a code object.
        /// </summary>
        /// <param name="tk">[in] The token to check the reference validity for.</param>
        public bool IsValidToken(mdToken tk)
        {
            /*bool IsValidToken([In] mdToken tk);*/
            return Raw.IsValidToken(tk);
        }

        #endregion
        #region GetNestedClassProps

        /// <summary>
        /// Gets the TypeDef token for the parent <see cref="Type"/> of the specified nested type.
        /// </summary>
        /// <param name="tdNestedClass">[in] A TypeDef token representing the <see cref="Type"/> to return the parent class token for.</param>
        /// <returns>[out] A pointer to the TypeDef token for the <see cref="Type"/> that tdNestedClass is nested in.</returns>
        public mdTypeDef GetNestedClassProps(mdTypeDef tdNestedClass)
        {
            HRESULT hr;
            mdTypeDef ptdEnclosingClass;

            if ((hr = TryGetNestedClassProps(tdNestedClass, out ptdEnclosingClass)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ptdEnclosingClass;
        }

        /// <summary>
        /// Gets the TypeDef token for the parent <see cref="Type"/> of the specified nested type.
        /// </summary>
        /// <param name="tdNestedClass">[in] A TypeDef token representing the <see cref="Type"/> to return the parent class token for.</param>
        /// <param name="ptdEnclosingClass">[out] A pointer to the TypeDef token for the <see cref="Type"/> that tdNestedClass is nested in.</param>
        public HRESULT TryGetNestedClassProps(mdTypeDef tdNestedClass, out mdTypeDef ptdEnclosingClass)
        {
            /*HRESULT GetNestedClassProps(
            [In] mdTypeDef tdNestedClass,
            [Out] out mdTypeDef ptdEnclosingClass);*/
            return Raw.GetNestedClassProps(tdNestedClass, out ptdEnclosingClass);
        }

        #endregion
        #region GetNativeCallConvFromSig

        /// <summary>
        /// Gets the native calling convention for the method that is represented by the specified signature pointer.
        /// </summary>
        /// <param name="pvSig">[in] A pointer to the metadata signature of the method to return the calling convention for.</param>
        /// <param name="cbSig">[in] The size in bytes of pvSig.</param>
        /// <returns>[out] A pointer to the native calling convention.</returns>
        public int GetNativeCallConvFromSig(IntPtr pvSig, int cbSig)
        {
            HRESULT hr;
            int pCallConv;

            if ((hr = TryGetNativeCallConvFromSig(pvSig, cbSig, out pCallConv)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pCallConv;
        }

        /// <summary>
        /// Gets the native calling convention for the method that is represented by the specified signature pointer.
        /// </summary>
        /// <param name="pvSig">[in] A pointer to the metadata signature of the method to return the calling convention for.</param>
        /// <param name="cbSig">[in] The size in bytes of pvSig.</param>
        /// <param name="pCallConv">[out] A pointer to the native calling convention.</param>
        public HRESULT TryGetNativeCallConvFromSig(IntPtr pvSig, int cbSig, out int pCallConv)
        {
            /*HRESULT GetNativeCallConvFromSig(
            [In] IntPtr pvSig,
            [In] int cbSig,
            [Out] out int pCallConv);*/
            return Raw.GetNativeCallConvFromSig(pvSig, cbSig, out pCallConv);
        }

        #endregion
        #region IsGlobal

        /// <summary>
        /// Gets a value indicating whether the field, method, or type represented by the specified metadata token has global scope.
        /// </summary>
        /// <param name="pd">[in] A metadata token that represents a type, field, or method.</param>
        /// <returns>[out] 1 if the object has global scope; otherwise, 0 (zero).</returns>
        public int IsGlobal(mdToken pd)
        {
            HRESULT hr;
            int pbGlobal;

            if ((hr = TryIsGlobal(pd, out pbGlobal)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pbGlobal;
        }

        /// <summary>
        /// Gets a value indicating whether the field, method, or type represented by the specified metadata token has global scope.
        /// </summary>
        /// <param name="pd">[in] A metadata token that represents a type, field, or method.</param>
        /// <param name="pbGlobal">[out] 1 if the object has global scope; otherwise, 0 (zero).</param>
        public HRESULT TryIsGlobal(mdToken pd, out int pbGlobal)
        {
            /*HRESULT IsGlobal(
            [In] mdToken pd,
            [Out] out int pbGlobal);*/
            return Raw.IsGlobal(pd, out pbGlobal);
        }

        #endregion
        #endregion
        #region IMetaDataImport2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IMetaDataImport2 Raw2 => (IMetaDataImport2) Raw;

        #region PEKind

        /// <summary>
        /// Gets a value identifying the nature of the code in the portable executable (PE) file, typically a DLL or EXE file, that is defined in the current metadata scope.
        /// </summary>
        public GetPEKindResult PEKind
        {
            get
            {
                HRESULT hr;
                GetPEKindResult result;

                if ((hr = TryGetPEKind(out result)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return result;
            }
        }

        /// <summary>
        /// Gets a value identifying the nature of the code in the portable executable (PE) file, typically a DLL or EXE file, that is defined in the current metadata scope.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// The value referenced by the pdwMachine parameter can be one of the following.
        /// </remarks>
        public HRESULT TryGetPEKind(out GetPEKindResult result)
        {
            /*HRESULT GetPEKind(
            [Out] out CorPEKind pdwPEKind,
            [Out] out int pdwMachine);*/
            CorPEKind pdwPEKind;
            int pdwMachine;
            HRESULT hr = Raw2.GetPEKind(out pdwPEKind, out pdwMachine);

            if (hr == HRESULT.S_OK)
                result = new GetPEKindResult(pdwPEKind, pdwMachine);
            else
                result = default(GetPEKindResult);

            return hr;
        }

        #endregion
        #region VersionString

        /// <summary>
        /// Gets the version number of the runtime that was used to build the assembly.
        /// </summary>
        public string VersionString
        {
            get
            {
                HRESULT hr;
                string pwzBufResult;

                if ((hr = TryGetVersionString(out pwzBufResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pwzBufResult;
            }
        }

        /// <summary>
        /// Gets the version number of the runtime that was used to build the assembly.
        /// </summary>
        /// <param name="pwzBufResult">[out] An array to store the string that specifies the version.</param>
        /// <remarks>
        /// The GetVersionString method gets the built-for version of the current metadata scope. If the scope has never been
        /// saved, it will not have a built-for version, and an empty string will be returned.
        /// </remarks>
        public HRESULT TryGetVersionString(out string pwzBufResult)
        {
            /*HRESULT GetVersionString(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwzBuf,
            [In] int ccBufSize,
            [Out] out int pccBufSize);*/
            StringBuilder pwzBuf = null;
            int ccBufSize = 0;
            int pccBufSize;
            HRESULT hr = Raw2.GetVersionString(pwzBuf, ccBufSize, out pccBufSize);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            ccBufSize = pccBufSize;
            pwzBuf = new StringBuilder(pccBufSize);
            hr = Raw2.GetVersionString(pwzBuf, ccBufSize, out pccBufSize);

            if (hr == HRESULT.S_OK)
            {
                pwzBufResult = pwzBuf.ToString();

                return hr;
            }

            fail:
            pwzBufResult = default(string);

            return hr;
        }

        #endregion
        #region EnumGenericParams

        /// <summary>
        /// Gets an enumerator for an array of generic parameter tokens associated with the specified TypeDef or MethodDef token.
        /// </summary>
        /// <param name="tk">[in] The TypeDef or MethodDef token whose generic parameters are to be enumerated.</param>
        /// <param name="cMax">[in] The requested maximum number of tokens to place in rGenericParams.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public EnumGenericParamsResult EnumGenericParams(mdToken tk, int cMax)
        {
            HRESULT hr;
            EnumGenericParamsResult result;

            if ((hr = TryEnumGenericParams(tk, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets an enumerator for an array of generic parameter tokens associated with the specified TypeDef or MethodDef token.
        /// </summary>
        /// <param name="tk">[in] The TypeDef or MethodDef token whose generic parameters are to be enumerated.</param>
        /// <param name="cMax">[in] The requested maximum number of tokens to place in rGenericParams.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// | HRESULT | Description                                                                      |
        /// | ------- | -------------------------------------------------------------------------------- |
        /// | S_OK    | EnumGenericParams returned successfully.                                         |
        /// | S_FALSE | phEnum has no member elements. In this case, pcGenericParams is set to 0 (zero). |
        /// </returns>
        public HRESULT TryEnumGenericParams(mdToken tk, int cMax, out EnumGenericParamsResult result)
        {
            /*HRESULT EnumGenericParams(
            [In, Out] ref IntPtr phEnum,
            [In] mdToken tk,
            [Out] out mdGenericParam[] rGenericParams,
            [In] int cMax,
            [Out] out int pcGenericParams);*/
            IntPtr phEnum = default(IntPtr);
            mdGenericParam[] rGenericParams;
            int pcGenericParams;
            HRESULT hr = Raw2.EnumGenericParams(ref phEnum, tk, out rGenericParams, cMax, out pcGenericParams);

            if (hr == HRESULT.S_OK)
                result = new EnumGenericParamsResult(phEnum, rGenericParams, pcGenericParams);
            else
                result = default(EnumGenericParamsResult);

            return hr;
        }

        #endregion
        #region GetGenericParamProps

        /// <summary>
        /// Gets the metadata associated with the generic parameter represented by the specified token.
        /// </summary>
        /// <param name="gp">[in] The token that represents the generic parameter for which to return metadata.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetGenericParamPropsResult GetGenericParamProps(mdGenericParam gp)
        {
            HRESULT hr;
            GetGenericParamPropsResult result;

            if ((hr = TryGetGenericParamProps(gp, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the metadata associated with the generic parameter represented by the specified token.
        /// </summary>
        /// <param name="gp">[in] The token that represents the generic parameter for which to return metadata.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetGenericParamProps(mdGenericParam gp, out GetGenericParamPropsResult result)
        {
            /*HRESULT GetGenericParamProps(
            [In] mdGenericParam gp,
            [Out] out int pulParamSeq,
            [Out] out CorGenericParamAttr pdwParamFlags,
            [Out] mdToken ptOwner,
            [Out] int reserved,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzname,
            [In] int cchName,
            [Out] out int pchName);*/
            int pulParamSeq;
            CorGenericParamAttr pdwParamFlags;
            mdToken ptOwner = default(mdToken);
            int reserved = default(int);
            StringBuilder wzname = null;
            int cchName = 0;
            int pchName;
            HRESULT hr = Raw2.GetGenericParamProps(gp, out pulParamSeq, out pdwParamFlags, ptOwner, reserved, wzname, cchName, out pchName);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pchName;
            wzname = new StringBuilder(pchName);
            hr = Raw2.GetGenericParamProps(gp, out pulParamSeq, out pdwParamFlags, ptOwner, reserved, wzname, cchName, out pchName);

            if (hr == HRESULT.S_OK)
            {
                result = new GetGenericParamPropsResult(pulParamSeq, pdwParamFlags, ptOwner, reserved, wzname.ToString());

                return hr;
            }

            fail:
            result = default(GetGenericParamPropsResult);

            return hr;
        }

        #endregion
        #region GetMethodSpecProps

        /// <summary>
        /// Gets the metadata signature of the method referenced by the specified MethodSpec token.
        /// </summary>
        /// <param name="mi">[in] A MethodSpec token that represents the instantiation of the method.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetMethodSpecPropsResult GetMethodSpecProps(mdMethodSpec mi)
        {
            HRESULT hr;
            GetMethodSpecPropsResult result;

            if ((hr = TryGetMethodSpecProps(mi, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the metadata signature of the method referenced by the specified MethodSpec token.
        /// </summary>
        /// <param name="mi">[in] A MethodSpec token that represents the instantiation of the method.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetMethodSpecProps(mdMethodSpec mi, out GetMethodSpecPropsResult result)
        {
            /*HRESULT GetMethodSpecProps(
            [In] mdMethodSpec mi,
            [Out] out mdToken tkParent,
            [Out] out IntPtr ppvSigBlob,
            [Out] out int pcbSigBlob);*/
            mdToken tkParent;
            IntPtr ppvSigBlob;
            int pcbSigBlob;
            HRESULT hr = Raw2.GetMethodSpecProps(mi, out tkParent, out ppvSigBlob, out pcbSigBlob);

            if (hr == HRESULT.S_OK)
                result = new GetMethodSpecPropsResult(tkParent, ppvSigBlob, pcbSigBlob);
            else
                result = default(GetMethodSpecPropsResult);

            return hr;
        }

        #endregion
        #region EnumGenericParamConstraints

        /// <summary>
        /// Gets an enumerator for an array of generic parameter constraints associated with the generic parameter represented by the specified token.
        /// </summary>
        /// <param name="tk">[in] A token that represents the generic parameter whose constraints are to be enumerated.</param>
        /// <param name="cMax">[in] The requested maximum number of tokens to place in rGenericParamConstraints.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public EnumGenericParamConstraintsResult EnumGenericParamConstraints(mdGenericParam tk, int cMax)
        {
            HRESULT hr;
            EnumGenericParamConstraintsResult result;

            if ((hr = TryEnumGenericParamConstraints(tk, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets an enumerator for an array of generic parameter constraints associated with the generic parameter represented by the specified token.
        /// </summary>
        /// <param name="tk">[in] A token that represents the generic parameter whose constraints are to be enumerated.</param>
        /// <param name="cMax">[in] The requested maximum number of tokens to place in rGenericParamConstraints.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// | HRESULT | Description                                                                                    |
        /// | ------- | ---------------------------------------------------------------------------------------------- |
        /// | S_OK    | EnumGenericParameterConstraints returned successfully.                                         |
        /// | S_FALSE | phEnum has no member elements. In this case, pcGenericParameterConstraints is set to 0 (zero). |
        /// </returns>
        public HRESULT TryEnumGenericParamConstraints(mdGenericParam tk, int cMax, out EnumGenericParamConstraintsResult result)
        {
            /*HRESULT EnumGenericParamConstraints(
            [In, Out] ref IntPtr phEnum,
            [In] mdGenericParam tk,
            [Out] mdGenericParamConstraint[] rGenericParamConstraints,
            [In] int cMax,
            [Out] out int pcGenericParamConstraints);*/
            IntPtr phEnum = default(IntPtr);
            mdGenericParamConstraint[] rGenericParamConstraints = default(mdGenericParamConstraint[]);
            int pcGenericParamConstraints;
            HRESULT hr = Raw2.EnumGenericParamConstraints(ref phEnum, tk, rGenericParamConstraints, cMax, out pcGenericParamConstraints);

            if (hr == HRESULT.S_OK)
                result = new EnumGenericParamConstraintsResult(phEnum, rGenericParamConstraints, pcGenericParamConstraints);
            else
                result = default(EnumGenericParamConstraintsResult);

            return hr;
        }

        #endregion
        #region GetGenericParamConstraintProps

        /// <summary>
        /// Gets the metadata associated with the generic parameter constraint represented by the specified constraint token.
        /// </summary>
        /// <param name="gpc">[in] The token to the generic parameter constraint for which to return the metadata.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetGenericParamConstraintPropsResult GetGenericParamConstraintProps(mdGenericParamConstraint gpc)
        {
            HRESULT hr;
            GetGenericParamConstraintPropsResult result;

            if ((hr = TryGetGenericParamConstraintProps(gpc, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the metadata associated with the generic parameter constraint represented by the specified constraint token.
        /// </summary>
        /// <param name="gpc">[in] The token to the generic parameter constraint for which to return the metadata.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        public HRESULT TryGetGenericParamConstraintProps(mdGenericParamConstraint gpc, out GetGenericParamConstraintPropsResult result)
        {
            /*HRESULT GetGenericParamConstraintProps(
            [In] mdGenericParamConstraint gpc,
            [Out] out mdGenericParam ptGenericParam,
            [Out] out mdToken ptkConstraintType);*/
            mdGenericParam ptGenericParam;
            mdToken ptkConstraintType;
            HRESULT hr = Raw2.GetGenericParamConstraintProps(gpc, out ptGenericParam, out ptkConstraintType);

            if (hr == HRESULT.S_OK)
                result = new GetGenericParamConstraintPropsResult(ptGenericParam, ptkConstraintType);
            else
                result = default(GetGenericParamConstraintPropsResult);

            return hr;
        }

        #endregion
        #region EnumMethodSpecs

        /// <summary>
        /// Gets an enumerator for an array of MethodSpec tokens associated with the specified MethodDef or MemberRef token.
        /// </summary>
        /// <param name="tk">[in] The MemberRef or MethodDef token that represents the method whose MethodSpec tokens are to be enumerated. If the value of tk is 0 (zero), all MethodSpec tokens in the scope will be enumerated.</param>
        /// <param name="cMax">[in] The requested maximum number of tokens to place in rMethodSpecs.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public EnumMethodSpecsResult EnumMethodSpecs(mdToken tk, int cMax)
        {
            HRESULT hr;
            EnumMethodSpecsResult result;

            if ((hr = TryEnumMethodSpecs(tk, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets an enumerator for an array of MethodSpec tokens associated with the specified MethodDef or MemberRef token.
        /// </summary>
        /// <param name="tk">[in] The MemberRef or MethodDef token that represents the method whose MethodSpec tokens are to be enumerated. If the value of tk is 0 (zero), all MethodSpec tokens in the scope will be enumerated.</param>
        /// <param name="cMax">[in] The requested maximum number of tokens to place in rMethodSpecs.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// | HRESULT | Description                                                                    |
        /// | ------- | ------------------------------------------------------------------------------ |
        /// | S_OK    | EnumMethodSpecs returned successfully.                                         |
        /// | S_FALSE | phEnum has no member elements. In this case, pcMethodSpecs is set to 0 (zero). |
        /// </returns>
        public HRESULT TryEnumMethodSpecs(mdToken tk, int cMax, out EnumMethodSpecsResult result)
        {
            /*HRESULT EnumMethodSpecs(
            [In, Out] ref IntPtr phEnum,
            [In] mdToken tk,
            [Out] mdMethodSpec[] rMethodSpecs,
            [In] int cMax,
            [Out] out int pcMethodSpecs);*/
            IntPtr phEnum = default(IntPtr);
            mdMethodSpec[] rMethodSpecs = default(mdMethodSpec[]);
            int pcMethodSpecs;
            HRESULT hr = Raw2.EnumMethodSpecs(ref phEnum, tk, rMethodSpecs, cMax, out pcMethodSpecs);

            if (hr == HRESULT.S_OK)
                result = new EnumMethodSpecsResult(phEnum, rMethodSpecs, pcMethodSpecs);
            else
                result = default(EnumMethodSpecsResult);

            return hr;
        }

        #endregion
        #endregion
    }
}