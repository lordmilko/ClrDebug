using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;

namespace ManagedCorDebug
{
    public class MetaDataImport : ComObject<IMetaDataImport>
    {
        public MetaDataImport(IMetaDataImport raw) : base(raw)
        {
        }

        #region IMetaDataImport
        #region GetModuleFromScope

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

        public HRESULT TryGetModuleFromScope(out mdModule pmd)
        {
            /*HRESULT GetModuleFromScope([Out] out mdModule pmd);*/
            return Raw.GetModuleFromScope(out pmd);
        }

        #endregion
        #region CloseEnum

        public void CloseEnum(IntPtr hEnum)
        {
            /*void CloseEnum([In] IntPtr hEnum);*/
            Raw.CloseEnum(hEnum);
        }

        #endregion
        #region CountEnum

        public uint CountEnum(IntPtr hEnum)
        {
            HRESULT hr;
            uint pulCount;

            if ((hr = TryCountEnum(hEnum, out pulCount)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pulCount;
        }

        public HRESULT TryCountEnum(IntPtr hEnum, out uint pulCount)
        {
            /*HRESULT CountEnum([In] IntPtr hEnum, [Out] out uint pulCount);*/
            return Raw.CountEnum(hEnum, out pulCount);
        }

        #endregion
        #region ResetEnum

        public void ResetEnum(IntPtr hEnum, uint ulPos)
        {
            HRESULT hr;

            if ((hr = TryResetEnum(hEnum, ulPos)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryResetEnum(IntPtr hEnum, uint ulPos)
        {
            /*HRESULT ResetEnum([In] IntPtr hEnum, [In] uint ulPos);*/
            return Raw.ResetEnum(hEnum, ulPos);
        }

        #endregion
        #region EnumTypeDefs

        public EnumTypeDefsResult EnumTypeDefs(uint cMax)
        {
            HRESULT hr;
            EnumTypeDefsResult result;

            if ((hr = TryEnumTypeDefs(cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumTypeDefs(uint cMax, out EnumTypeDefsResult result)
        {
            /*HRESULT EnumTypeDefs(
            [In, Out] ref IntPtr phEnum,
            [Out] out mdTypeDef[] typeDefs,
            [In] uint cMax,
            [Out] out uint pcTypeDefs);*/
            IntPtr phEnum = default(IntPtr);
            mdTypeDef[] typeDefs;
            uint pcTypeDefs;
            HRESULT hr = Raw.EnumTypeDefs(ref phEnum, out typeDefs, cMax, out pcTypeDefs);

            if (hr == HRESULT.S_OK)
                result = new EnumTypeDefsResult(phEnum, typeDefs, pcTypeDefs);
            else
                result = default(EnumTypeDefsResult);

            return hr;
        }

        #endregion
        #region EnumInterfaceImpls

        public EnumInterfaceImplsResult EnumInterfaceImpls(mdTypeDef td, uint cMax)
        {
            HRESULT hr;
            EnumInterfaceImplsResult result;

            if ((hr = TryEnumInterfaceImpls(td, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumInterfaceImpls(mdTypeDef td, uint cMax, out EnumInterfaceImplsResult result)
        {
            /*HRESULT EnumInterfaceImpls(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef td,
            [Out] out mdInterfaceImpl[] rImpls,
            [In] uint cMax,
            [Out] out uint pcImpls);*/
            IntPtr phEnum = default(IntPtr);
            mdInterfaceImpl[] rImpls;
            uint pcImpls;
            HRESULT hr = Raw.EnumInterfaceImpls(ref phEnum, td, out rImpls, cMax, out pcImpls);

            if (hr == HRESULT.S_OK)
                result = new EnumInterfaceImplsResult(phEnum, rImpls, pcImpls);
            else
                result = default(EnumInterfaceImplsResult);

            return hr;
        }

        #endregion
        #region EnumTypeRefs

        public EnumTypeRefsResult EnumTypeRefs(uint cMax)
        {
            HRESULT hr;
            EnumTypeRefsResult result;

            if ((hr = TryEnumTypeRefs(cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumTypeRefs(uint cMax, out EnumTypeRefsResult result)
        {
            /*HRESULT EnumTypeRefs(
            [In, Out] ref IntPtr phEnum,
            [Out] out mdTypeRef[] rTypeRefs,
            [In] uint cMax,
            [Out] out uint pcTypeRefs);*/
            IntPtr phEnum = default(IntPtr);
            mdTypeRef[] rTypeRefs;
            uint pcTypeRefs;
            HRESULT hr = Raw.EnumTypeRefs(ref phEnum, out rTypeRefs, cMax, out pcTypeRefs);

            if (hr == HRESULT.S_OK)
                result = new EnumTypeRefsResult(phEnum, rTypeRefs, pcTypeRefs);
            else
                result = default(EnumTypeRefsResult);

            return hr;
        }

        #endregion
        #region FindTypeDefByName

        public mdTypeDef FindTypeDefByName(string szTypeDef, mdToken tkEnclosingClass)
        {
            HRESULT hr;
            mdTypeDef typeDef;

            if ((hr = TryFindTypeDefByName(szTypeDef, tkEnclosingClass, out typeDef)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return typeDef;
        }

        public HRESULT TryFindTypeDefByName(string szTypeDef, mdToken tkEnclosingClass, out mdTypeDef typeDef)
        {
            /*HRESULT FindTypeDefByName(
            [MarshalAs(UnmanagedType.LPWStr), In] string szTypeDef,
            [In] mdToken tkEnclosingClass,
            [Out] out mdTypeDef typeDef);*/
            return Raw.FindTypeDefByName(szTypeDef, tkEnclosingClass, out typeDef);
        }

        #endregion
        #region GetScopeProps

        public GetScopePropsResult GetScopeProps()
        {
            HRESULT hr;
            GetScopePropsResult result;

            if ((hr = TryGetScopeProps(out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

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

            if (hr != HRESULT.S_FALSE)
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
        #region GetTypeDefProps

        public GetTypeDefPropsResult GetTypeDefProps(mdTypeDef td)
        {
            HRESULT hr;
            GetTypeDefPropsResult result;

            if ((hr = TryGetTypeDefProps(td, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

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

            if (hr != HRESULT.S_FALSE)
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

        public GetInterfaceImplPropsResult GetInterfaceImplProps(mdInterfaceImpl iiImpl)
        {
            HRESULT hr;
            GetInterfaceImplPropsResult result;

            if ((hr = TryGetInterfaceImplProps(iiImpl, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

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

        public GetTypeRefPropsResult GetTypeRefProps(mdTypeRef tr)
        {
            HRESULT hr;
            GetTypeRefPropsResult result;

            if ((hr = TryGetTypeRefProps(tr, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

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

            if (hr != HRESULT.S_FALSE)
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

        [Obsolete("This method no longer appears to exist in the IMetaDataImport vtable.")]
        public ResolveTypeRefResult ResolveTypeRef(mdTypeRef tr, Guid riid)
        {
            HRESULT hr;
            ResolveTypeRefResult result;

            if ((hr = TryResolveTypeRef(tr, riid, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

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

        public EnumMembersResult EnumMembers(mdTypeDef cl, uint cMax)
        {
            HRESULT hr;
            EnumMembersResult result;

            if ((hr = TryEnumMembers(cl, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumMembers(mdTypeDef cl, uint cMax, out EnumMembersResult result)
        {
            /*HRESULT EnumMembers(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef cl,
            [Out] out mdToken[] rMembers,
            [In] uint cMax,
            [Out] out uint pcTokens);*/
            IntPtr phEnum = default(IntPtr);
            mdToken[] rMembers;
            uint pcTokens;
            HRESULT hr = Raw.EnumMembers(ref phEnum, cl, out rMembers, cMax, out pcTokens);

            if (hr == HRESULT.S_OK)
                result = new EnumMembersResult(phEnum, rMembers, pcTokens);
            else
                result = default(EnumMembersResult);

            return hr;
        }

        #endregion
        #region EnumMembersWithName

        public EnumMembersWithNameResult EnumMembersWithName(mdTypeDef cl, string szName, uint cMax)
        {
            HRESULT hr;
            EnumMembersWithNameResult result;

            if ((hr = TryEnumMembersWithName(cl, szName, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumMembersWithName(mdTypeDef cl, string szName, uint cMax, out EnumMembersWithNameResult result)
        {
            /*HRESULT EnumMembersWithName(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef cl,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [Out] out mdToken[] rMembers,
            [In] uint cMax,
            [Out] out uint pcTokens);*/
            IntPtr phEnum = default(IntPtr);
            mdToken[] rMembers;
            uint pcTokens;
            HRESULT hr = Raw.EnumMembersWithName(ref phEnum, cl, szName, out rMembers, cMax, out pcTokens);

            if (hr == HRESULT.S_OK)
                result = new EnumMembersWithNameResult(phEnum, rMembers, pcTokens);
            else
                result = default(EnumMembersWithNameResult);

            return hr;
        }

        #endregion
        #region EnumMethods

        public EnumMethodsResult EnumMethods(mdTypeDef cl, uint cMax)
        {
            HRESULT hr;
            EnumMethodsResult result;

            if ((hr = TryEnumMethods(cl, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumMethods(mdTypeDef cl, uint cMax, out EnumMethodsResult result)
        {
            /*HRESULT EnumMethods(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef cl,
            [Out] out mdMethodDef[] rMethods,
            [In] uint cMax,
            [Out] out uint pcTokens);*/
            IntPtr phEnum = default(IntPtr);
            mdMethodDef[] rMethods;
            uint pcTokens;
            HRESULT hr = Raw.EnumMethods(ref phEnum, cl, out rMethods, cMax, out pcTokens);

            if (hr == HRESULT.S_OK)
                result = new EnumMethodsResult(phEnum, rMethods, pcTokens);
            else
                result = default(EnumMethodsResult);

            return hr;
        }

        #endregion
        #region EnumMethodsWithName

        public EnumMethodsWithNameResult EnumMethodsWithName(mdTypeDef cl, uint cMax)
        {
            HRESULT hr;
            EnumMethodsWithNameResult result;

            if ((hr = TryEnumMethodsWithName(cl, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumMethodsWithName(mdTypeDef cl, uint cMax, out EnumMethodsWithNameResult result)
        {
            /*HRESULT EnumMethodsWithName(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef cl,
            [Out, MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [Out] out mdMethodDef[] rMethods,
            [In] uint cMax,
            [Out] out uint pcTokens);*/
            IntPtr phEnum = default(IntPtr);
            string szName = default(string);
            mdMethodDef[] rMethods;
            uint pcTokens;
            HRESULT hr = Raw.EnumMethodsWithName(ref phEnum, cl, szName, out rMethods, cMax, out pcTokens);

            if (hr == HRESULT.S_OK)
                result = new EnumMethodsWithNameResult(phEnum, szName, rMethods, pcTokens);
            else
                result = default(EnumMethodsWithNameResult);

            return hr;
        }

        #endregion
        #region EnumFields

        public EnumFieldsResult EnumFields(mdTypeDef cl, uint cMax)
        {
            HRESULT hr;
            EnumFieldsResult result;

            if ((hr = TryEnumFields(cl, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumFields(mdTypeDef cl, uint cMax, out EnumFieldsResult result)
        {
            /*HRESULT EnumFields(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef cl,
            [Out] out mdFieldDef[] rFields,
            [In] uint cMax,
            [Out] out uint pcTokens);*/
            IntPtr phEnum = default(IntPtr);
            mdFieldDef[] rFields;
            uint pcTokens;
            HRESULT hr = Raw.EnumFields(ref phEnum, cl, out rFields, cMax, out pcTokens);

            if (hr == HRESULT.S_OK)
                result = new EnumFieldsResult(phEnum, rFields, pcTokens);
            else
                result = default(EnumFieldsResult);

            return hr;
        }

        #endregion
        #region EnumFieldsWithName

        public EnumFieldsWithNameResult EnumFieldsWithName(mdTypeDef cl, string szName, uint cMax)
        {
            HRESULT hr;
            EnumFieldsWithNameResult result;

            if ((hr = TryEnumFieldsWithName(cl, szName, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumFieldsWithName(mdTypeDef cl, string szName, uint cMax, out EnumFieldsWithNameResult result)
        {
            /*HRESULT EnumFieldsWithName(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef cl,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [Out] out mdFieldDef[] rFields,
            [In] uint cMax,
            [Out] out uint pcTokens);*/
            IntPtr phEnum = default(IntPtr);
            mdFieldDef[] rFields;
            uint pcTokens;
            HRESULT hr = Raw.EnumFieldsWithName(ref phEnum, cl, szName, out rFields, cMax, out pcTokens);

            if (hr == HRESULT.S_OK)
                result = new EnumFieldsWithNameResult(phEnum, rFields, pcTokens);
            else
                result = default(EnumFieldsWithNameResult);

            return hr;
        }

        #endregion
        #region EnumParams

        public EnumParamsResult EnumParams(mdMethodDef mb, uint cMax)
        {
            HRESULT hr;
            EnumParamsResult result;

            if ((hr = TryEnumParams(mb, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumParams(mdMethodDef mb, uint cMax, out EnumParamsResult result)
        {
            /*HRESULT EnumParams(
            [In, Out] ref IntPtr phEnum,
            [In] mdMethodDef mb,
            [Out] out mdParamDef[] rParams,
            [In] uint cMax,
            [Out] out uint pcTokens);*/
            IntPtr phEnum = default(IntPtr);
            mdParamDef[] rParams;
            uint pcTokens;
            HRESULT hr = Raw.EnumParams(ref phEnum, mb, out rParams, cMax, out pcTokens);

            if (hr == HRESULT.S_OK)
                result = new EnumParamsResult(phEnum, rParams, pcTokens);
            else
                result = default(EnumParamsResult);

            return hr;
        }

        #endregion
        #region EnumMemberRefs

        public EnumMemberRefsResult EnumMemberRefs(mdToken tkParent, uint cMax)
        {
            HRESULT hr;
            EnumMemberRefsResult result;

            if ((hr = TryEnumMemberRefs(tkParent, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumMemberRefs(mdToken tkParent, uint cMax, out EnumMemberRefsResult result)
        {
            /*HRESULT EnumMemberRefs(
            [In, Out] ref IntPtr phEnum,
            [In] mdToken tkParent,
            [Out] out mdMemberRef[] rMemberRefs,
            [In] uint cMax,
            [Out] out uint pcTokens);*/
            IntPtr phEnum = default(IntPtr);
            mdMemberRef[] rMemberRefs;
            uint pcTokens;
            HRESULT hr = Raw.EnumMemberRefs(ref phEnum, tkParent, out rMemberRefs, cMax, out pcTokens);

            if (hr == HRESULT.S_OK)
                result = new EnumMemberRefsResult(phEnum, rMemberRefs, pcTokens);
            else
                result = default(EnumMemberRefsResult);

            return hr;
        }

        #endregion
        #region EnumMethodImpls

        public EnumMethodImplsResult EnumMethodImpls(mdTypeDef td, uint cMax)
        {
            HRESULT hr;
            EnumMethodImplsResult result;

            if ((hr = TryEnumMethodImpls(td, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumMethodImpls(mdTypeDef td, uint cMax, out EnumMethodImplsResult result)
        {
            /*HRESULT EnumMethodImpls(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef td,
            [Out] out mdToken[] rMethodBody,
            [Out] out mdToken[] rMethodDecl,
            [In] uint cMax,
            [Out] out uint pcTokens);*/
            IntPtr phEnum = default(IntPtr);
            mdToken[] rMethodBody;
            mdToken[] rMethodDecl;
            uint pcTokens;
            HRESULT hr = Raw.EnumMethodImpls(ref phEnum, td, out rMethodBody, out rMethodDecl, cMax, out pcTokens);

            if (hr == HRESULT.S_OK)
                result = new EnumMethodImplsResult(phEnum, rMethodBody, rMethodDecl, pcTokens);
            else
                result = default(EnumMethodImplsResult);

            return hr;
        }

        #endregion
        #region EnumPermissionSets

        public EnumPermissionSetsResult EnumPermissionSets(mdToken tk, SecurityAction dwActions, uint cMax)
        {
            HRESULT hr;
            EnumPermissionSetsResult result;

            if ((hr = TryEnumPermissionSets(tk, dwActions, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumPermissionSets(mdToken tk, SecurityAction dwActions, uint cMax, out EnumPermissionSetsResult result)
        {
            /*HRESULT EnumPermissionSets(
            [In, Out] ref IntPtr phEnum,
            [In] mdToken tk,
            [In] SecurityAction dwActions,
            [Out] out mdPermission[] rPermission,
            [In] uint cMax,
            [Out] out uint pcTokens);*/
            IntPtr phEnum = default(IntPtr);
            mdPermission[] rPermission;
            uint pcTokens;
            HRESULT hr = Raw.EnumPermissionSets(ref phEnum, tk, dwActions, out rPermission, cMax, out pcTokens);

            if (hr == HRESULT.S_OK)
                result = new EnumPermissionSetsResult(phEnum, rPermission, pcTokens);
            else
                result = default(EnumPermissionSetsResult);

            return hr;
        }

        #endregion
        #region FindMember

        public mdToken FindMember(mdToken td, string szName, IntPtr pvSigBlob, uint cbSigBlob)
        {
            HRESULT hr;
            mdToken pmb;

            if ((hr = TryFindMember(td, szName, pvSigBlob, cbSigBlob, out pmb)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pmb;
        }

        public HRESULT TryFindMember(mdToken td, string szName, IntPtr pvSigBlob, uint cbSigBlob, out mdToken pmb)
        {
            /*HRESULT FindMember(
            [In] mdToken td,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [In] IntPtr pvSigBlob,
            [In] uint cbSigBlob,
            [Out] out mdToken pmb);*/
            return Raw.FindMember(td, szName, pvSigBlob, cbSigBlob, out pmb);
        }

        #endregion
        #region FindMethod

        public mdMethodDef FindMethod(mdToken td, string szName, IntPtr pvSigBlob, uint cbSigBlob)
        {
            HRESULT hr;
            mdMethodDef pmb;

            if ((hr = TryFindMethod(td, szName, pvSigBlob, cbSigBlob, out pmb)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pmb;
        }

        public HRESULT TryFindMethod(mdToken td, string szName, IntPtr pvSigBlob, uint cbSigBlob, out mdMethodDef pmb)
        {
            /*HRESULT FindMethod(
            [In] mdToken td,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [In] IntPtr pvSigBlob,
            [In] uint cbSigBlob,
            [Out] out mdMethodDef pmb);*/
            return Raw.FindMethod(td, szName, pvSigBlob, cbSigBlob, out pmb);
        }

        #endregion
        #region FindField

        public mdFieldDef FindField(mdToken td, string szName, IntPtr pvSigBlob, uint cbSigBlob)
        {
            HRESULT hr;
            mdFieldDef pmb;

            if ((hr = TryFindField(td, szName, pvSigBlob, cbSigBlob, out pmb)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pmb;
        }

        public HRESULT TryFindField(mdToken td, string szName, IntPtr pvSigBlob, uint cbSigBlob, out mdFieldDef pmb)
        {
            /*HRESULT FindField(
            [In] mdToken td,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [In] IntPtr pvSigBlob,
            [In] uint cbSigBlob,
            [Out] out mdFieldDef pmb);*/
            return Raw.FindField(td, szName, pvSigBlob, cbSigBlob, out pmb);
        }

        #endregion
        #region FindMemberRef

        public mdMemberRef FindMemberRef(mdToken td, string szName, IntPtr pvSigBlob, uint cbSigBlob)
        {
            HRESULT hr;
            mdMemberRef pmr;

            if ((hr = TryFindMemberRef(td, szName, pvSigBlob, cbSigBlob, out pmr)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pmr;
        }

        public HRESULT TryFindMemberRef(mdToken td, string szName, IntPtr pvSigBlob, uint cbSigBlob, out mdMemberRef pmr)
        {
            /*HRESULT FindMemberRef(
            [In] mdToken td,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [In] IntPtr pvSigBlob, [In] uint cbSigBlob,
            [Out] out mdMemberRef pmr);*/
            return Raw.FindMemberRef(td, szName, pvSigBlob, cbSigBlob, out pmr);
        }

        #endregion
        #region GetMethodProps

        public MetaDataImport_GetMethodPropsResult GetMethodProps(mdMethodDef mb)
        {
            HRESULT hr;
            MetaDataImport_GetMethodPropsResult result;

            if ((hr = TryGetMethodProps(mb, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetMethodProps(mdMethodDef mb, out MetaDataImport_GetMethodPropsResult result)
        {
            /*HRESULT GetMethodProps(
            [In] mdMethodDef mb,
            [Out] out mdTypeDef pClass,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szMethod,
            [In] uint cchMethod,
            [Out] out int pchMethod,
            [Out] out CorMethodAttr pdwAttr,
            [Out] out IntPtr ppvSigBlob,
            [Out] out uint pcbSigBlob,
            [Out] out uint pulCodeRVA,
            [Out] out uint pdwImplFlags);*/
            mdTypeDef pClass;
            StringBuilder szMethod = null;
            uint cchMethod = 0;
            int pchMethod;
            CorMethodAttr pdwAttr;
            IntPtr ppvSigBlob;
            uint pcbSigBlob;
            uint pulCodeRVA;
            uint pdwImplFlags;
            HRESULT hr = Raw.GetMethodProps(mb, out pClass, szMethod, cchMethod, out pchMethod, out pdwAttr, out ppvSigBlob, out pcbSigBlob, out pulCodeRVA, out pdwImplFlags);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchMethod = (uint) pchMethod;
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

        public GetMemberRefPropsResult GetMemberRefProps(mdMemberRef mr)
        {
            HRESULT hr;
            GetMemberRefPropsResult result;

            if ((hr = TryGetMemberRefProps(mr, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetMemberRefProps(mdMemberRef mr, out GetMemberRefPropsResult result)
        {
            /*HRESULT GetMemberRefProps(
            [In] mdMemberRef mr,
            [Out] out mdToken ptk,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szMember,
            [In] uint cchMember,
            [Out] out uint pchMember,
            [Out] out IntPtr ppvSigBlob,
            [Out] out uint pbSig);*/
            mdToken ptk;
            StringBuilder szMember = null;
            uint cchMember = 0;
            uint pchMember;
            IntPtr ppvSigBlob;
            uint pbSig;
            HRESULT hr = Raw.GetMemberRefProps(mr, out ptk, szMember, cchMember, out pchMember, out ppvSigBlob, out pbSig);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchMember = pchMember;
            szMember = new StringBuilder((int) pchMember);
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

        public EnumPropertiesResult EnumProperties(mdTypeDef td, uint cMax)
        {
            HRESULT hr;
            EnumPropertiesResult result;

            if ((hr = TryEnumProperties(td, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumProperties(mdTypeDef td, uint cMax, out EnumPropertiesResult result)
        {
            /*HRESULT EnumProperties(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef td,
            [Out] mdProperty[] rProperties,
            [In] uint cMax,
            [Out] out uint pcProperties);*/
            IntPtr phEnum = default(IntPtr);
            mdProperty[] rProperties = default(mdProperty[]);
            uint pcProperties;
            HRESULT hr = Raw.EnumProperties(ref phEnum, td, rProperties, cMax, out pcProperties);

            if (hr == HRESULT.S_OK)
                result = new EnumPropertiesResult(phEnum, rProperties, pcProperties);
            else
                result = default(EnumPropertiesResult);

            return hr;
        }

        #endregion
        #region EnumEvents

        public EnumEventsResult EnumEvents(mdTypeDef td, uint cMax)
        {
            HRESULT hr;
            EnumEventsResult result;

            if ((hr = TryEnumEvents(td, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumEvents(mdTypeDef td, uint cMax, out EnumEventsResult result)
        {
            /*HRESULT EnumEvents(
            [In, Out] ref IntPtr phEnum,
            [In] mdTypeDef td,
            [Out] out mdEvent[] rEvents,
            [In] uint cMax,
            [Out] out uint pcEvents);*/
            IntPtr phEnum = default(IntPtr);
            mdEvent[] rEvents;
            uint pcEvents;
            HRESULT hr = Raw.EnumEvents(ref phEnum, td, out rEvents, cMax, out pcEvents);

            if (hr == HRESULT.S_OK)
                result = new EnumEventsResult(phEnum, rEvents, pcEvents);
            else
                result = default(EnumEventsResult);

            return hr;
        }

        #endregion
        #region GetEventProps

        public GetEventPropsResult GetEventProps(mdEvent ev, uint cMax)
        {
            HRESULT hr;
            GetEventPropsResult result;

            if ((hr = TryGetEventProps(ev, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetEventProps(mdEvent ev, uint cMax, out GetEventPropsResult result)
        {
            /*HRESULT GetEventProps(
            [In] mdEvent ev,
            [Out] mdTypeDef pClass,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szEvent,
            [In] uint cchEvent,
            [Out] out uint pchEvent,
            [Out] out uint pdwEventFlags,
            [Out] out mdToken ptkEventType,
            [Out] out mdMethodDef pmdAddOn,
            [Out] out mdMethodDef pmdRemoveOn,
            [Out] out mdMethodDef pmdFire,
            [Out] out mdMethodDef[] rmdOtherMethod,
            [In] uint cMax,
            [Out] uint pcOtherMethod);*/
            mdTypeDef pClass = default(mdTypeDef);
            StringBuilder szEvent = null;
            uint cchEvent = 0;
            uint pchEvent;
            uint pdwEventFlags;
            mdToken ptkEventType;
            mdMethodDef pmdAddOn;
            mdMethodDef pmdRemoveOn;
            mdMethodDef pmdFire;
            mdMethodDef[] rmdOtherMethod;
            uint pcOtherMethod = default(uint);
            HRESULT hr = Raw.GetEventProps(ev, pClass, szEvent, cchEvent, out pchEvent, out pdwEventFlags, out ptkEventType, out pmdAddOn, out pmdRemoveOn, out pmdFire, out rmdOtherMethod, cMax, pcOtherMethod);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchEvent = pchEvent;
            szEvent = new StringBuilder((int) pchEvent);
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

        public EnumMethodSemanticsResult EnumMethodSemantics(mdMethodDef mb, uint cMax)
        {
            HRESULT hr;
            EnumMethodSemanticsResult result;

            if ((hr = TryEnumMethodSemantics(mb, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumMethodSemantics(mdMethodDef mb, uint cMax, out EnumMethodSemanticsResult result)
        {
            /*HRESULT EnumMethodSemantics(
            [In, Out] ref IntPtr phEnum,
            [In] mdMethodDef mb,
            [Out] out mdToken[] rEventProp,
            [In] uint cMax,
            [Out] out uint pcEventProp);*/
            IntPtr phEnum = default(IntPtr);
            mdToken[] rEventProp;
            uint pcEventProp;
            HRESULT hr = Raw.EnumMethodSemantics(ref phEnum, mb, out rEventProp, cMax, out pcEventProp);

            if (hr == HRESULT.S_OK)
                result = new EnumMethodSemanticsResult(phEnum, rEventProp, pcEventProp);
            else
                result = default(EnumMethodSemanticsResult);

            return hr;
        }

        #endregion
        #region GetMethodSemantics

        public CorMethodSemanticsAttr GetMethodSemantics(mdMethodDef mb, mdToken tkEventProp)
        {
            HRESULT hr;
            CorMethodSemanticsAttr pdwSemanticsFlags;

            if ((hr = TryGetMethodSemantics(mb, tkEventProp, out pdwSemanticsFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pdwSemanticsFlags;
        }

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

        public GetClassLayoutResult GetClassLayout(mdTypeDef td)
        {
            HRESULT hr;
            GetClassLayoutResult result;

            if ((hr = TryGetClassLayout(td, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetClassLayout(mdTypeDef td, out GetClassLayoutResult result)
        {
            /*HRESULT GetClassLayout(
            [In] mdTypeDef td,
            [Out] uint pdwPackSize,
            [MarshalAs(UnmanagedType.LPArray), Out] COR_FIELD_OFFSET[] rFieldOffset,
            [In] int cMax,
            [Out] uint pcFieldOffset,
            [Out] uint pulClassSize);*/
            uint pdwPackSize = default(uint);
            COR_FIELD_OFFSET[] rFieldOffset = null;
            int cMax = 0;
            uint pcFieldOffset = default(uint);
            uint pulClassSize = default(uint);
            HRESULT hr = Raw.GetClassLayout(td, pdwPackSize, rFieldOffset, cMax, pcFieldOffset, pulClassSize);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cMax = (int) pcFieldOffset;
            rFieldOffset = new COR_FIELD_OFFSET[(int) pcFieldOffset];
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

        public GetFieldMarshalResult GetFieldMarshal(mdToken tk)
        {
            HRESULT hr;
            GetFieldMarshalResult result;

            if ((hr = TryGetFieldMarshal(tk, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetFieldMarshal(mdToken tk, out GetFieldMarshalResult result)
        {
            /*HRESULT GetFieldMarshal(
            [In] mdToken tk,
            [Out] out IntPtr ppvNativeType,
            [Out] out uint pcbNativeType);*/
            IntPtr ppvNativeType;
            uint pcbNativeType;
            HRESULT hr = Raw.GetFieldMarshal(tk, out ppvNativeType, out pcbNativeType);

            if (hr == HRESULT.S_OK)
                result = new GetFieldMarshalResult(ppvNativeType, pcbNativeType);
            else
                result = default(GetFieldMarshalResult);

            return hr;
        }

        #endregion
        #region GetRVA

        public GetRVAResult GetRVA(mdToken tk)
        {
            HRESULT hr;
            GetRVAResult result;

            if ((hr = TryGetRVA(tk, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetRVA(mdToken tk, out GetRVAResult result)
        {
            /*HRESULT GetRVA(
            [In] mdToken tk,
            [Out] out uint pulCodeRVA,
            [Out] out CorMethodImpl pdwImplFlags);*/
            uint pulCodeRVA;
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

        public GetPermissionSetPropsResult GetPermissionSetProps(mdPermission pm)
        {
            HRESULT hr;
            GetPermissionSetPropsResult result;

            if ((hr = TryGetPermissionSetProps(pm, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetPermissionSetProps(mdPermission pm, out GetPermissionSetPropsResult result)
        {
            /*HRESULT GetPermissionSetProps(
            [In] mdPermission pm,
            [Out] out uint pdwAction,
            [Out] IntPtr ppvPermission,
            [Out] out uint pcbPermission);*/
            uint pdwAction;
            IntPtr ppvPermission = default(IntPtr);
            uint pcbPermission;
            HRESULT hr = Raw.GetPermissionSetProps(pm, out pdwAction, ppvPermission, out pcbPermission);

            if (hr == HRESULT.S_OK)
                result = new GetPermissionSetPropsResult(pdwAction, ppvPermission, pcbPermission);
            else
                result = default(GetPermissionSetPropsResult);

            return hr;
        }

        #endregion
        #region GetSigFromToken

        public GetSigFromTokenResult GetSigFromToken(mdSignature mdSig)
        {
            HRESULT hr;
            GetSigFromTokenResult result;

            if ((hr = TryGetSigFromToken(mdSig, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetSigFromToken(mdSignature mdSig, out GetSigFromTokenResult result)
        {
            /*HRESULT GetSigFromToken(
            [In] mdSignature mdSig,
            [Out] out IntPtr ppvSig,
            [Out] out uint pcbSig);*/
            IntPtr ppvSig;
            uint pcbSig;
            HRESULT hr = Raw.GetSigFromToken(mdSig, out ppvSig, out pcbSig);

            if (hr == HRESULT.S_OK)
                result = new GetSigFromTokenResult(ppvSig, pcbSig);
            else
                result = default(GetSigFromTokenResult);

            return hr;
        }

        #endregion
        #region GetModuleRefProps

        public string GetModuleRefProps(mdModuleRef mur)
        {
            HRESULT hr;
            string szNameResult;

            if ((hr = TryGetModuleRefProps(mur, out szNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szNameResult;
        }

        public HRESULT TryGetModuleRefProps(mdModuleRef mur, out string szNameResult)
        {
            /*HRESULT GetModuleRefProps(
            [In] mdModuleRef mur,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szName,
            [In] uint cchName,
            [Out] out uint pchName);*/
            StringBuilder szName = null;
            uint cchName = 0;
            uint pchName;
            HRESULT hr = Raw.GetModuleRefProps(mur, szName, cchName, out pchName);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchName = pchName;
            szName = new StringBuilder((int) pchName);
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

        public EnumModuleRefsResult EnumModuleRefs(uint cmax)
        {
            HRESULT hr;
            EnumModuleRefsResult result;

            if ((hr = TryEnumModuleRefs(cmax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumModuleRefs(uint cmax, out EnumModuleRefsResult result)
        {
            /*HRESULT EnumModuleRefs(
            [In, Out] ref IntPtr phEnum,
            [Out] out mdModuleRef[] rModuleRefs,
            [In] uint cmax,
            [Out] out uint pcModuleRefs);*/
            IntPtr phEnum = default(IntPtr);
            mdModuleRef[] rModuleRefs;
            uint pcModuleRefs;
            HRESULT hr = Raw.EnumModuleRefs(ref phEnum, out rModuleRefs, cmax, out pcModuleRefs);

            if (hr == HRESULT.S_OK)
                result = new EnumModuleRefsResult(phEnum, rModuleRefs, pcModuleRefs);
            else
                result = default(EnumModuleRefsResult);

            return hr;
        }

        #endregion
        #region GetTypeSpecFromToken

        public GetTypeSpecFromTokenResult GetTypeSpecFromToken(mdTypeSpec typespec)
        {
            HRESULT hr;
            GetTypeSpecFromTokenResult result;

            if ((hr = TryGetTypeSpecFromToken(typespec, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetTypeSpecFromToken(mdTypeSpec typespec, out GetTypeSpecFromTokenResult result)
        {
            /*HRESULT GetTypeSpecFromToken(
            [In] mdTypeSpec typespec,
            [Out] out IntPtr ppvSig,
            [Out] out uint pcbSig);*/
            IntPtr ppvSig;
            uint pcbSig;
            HRESULT hr = Raw.GetTypeSpecFromToken(typespec, out ppvSig, out pcbSig);

            if (hr == HRESULT.S_OK)
                result = new GetTypeSpecFromTokenResult(ppvSig, pcbSig);
            else
                result = default(GetTypeSpecFromTokenResult);

            return hr;
        }

        #endregion
        #region GetNameFromToken

        [Obsolete]
        public IntPtr GetNameFromToken(mdToken tk)
        {
            HRESULT hr;
            IntPtr pszUtf8NamePtr;

            if ((hr = TryGetNameFromToken(tk, out pszUtf8NamePtr)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pszUtf8NamePtr;
        }

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

        public EnumUnresolvedMethodsResult EnumUnresolvedMethods(uint cMax)
        {
            HRESULT hr;
            EnumUnresolvedMethodsResult result;

            if ((hr = TryEnumUnresolvedMethods(cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumUnresolvedMethods(uint cMax, out EnumUnresolvedMethodsResult result)
        {
            /*HRESULT EnumUnresolvedMethods(
            [In, Out] ref IntPtr phEnum,
            [Out] out mdToken[] rMethods,
            [In] uint cMax,
            [Out] out uint pcTokens);*/
            IntPtr phEnum = default(IntPtr);
            mdToken[] rMethods;
            uint pcTokens;
            HRESULT hr = Raw.EnumUnresolvedMethods(ref phEnum, out rMethods, cMax, out pcTokens);

            if (hr == HRESULT.S_OK)
                result = new EnumUnresolvedMethodsResult(phEnum, rMethods, pcTokens);
            else
                result = default(EnumUnresolvedMethodsResult);

            return hr;
        }

        #endregion
        #region GetUserString

        public string GetUserString(mdString stk)
        {
            HRESULT hr;
            string szStringResult;

            if ((hr = TryGetUserString(stk, out szStringResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szStringResult;
        }

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

            if (hr != HRESULT.S_FALSE)
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

        public GetPinvokeMapResult GetPinvokeMap(mdToken tk)
        {
            HRESULT hr;
            GetPinvokeMapResult result;

            if ((hr = TryGetPinvokeMap(tk, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

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

            if (hr != HRESULT.S_FALSE)
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

        public EnumSignaturesResult EnumSignatures(uint cmax)
        {
            HRESULT hr;
            EnumSignaturesResult result;

            if ((hr = TryEnumSignatures(cmax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumSignatures(uint cmax, out EnumSignaturesResult result)
        {
            /*HRESULT EnumSignatures(
            [In, Out] ref IntPtr phEnum,
            [Out] out mdSignature[] rSignatures,
            [In] uint cmax,
            [Out] out uint pcSignatures);*/
            IntPtr phEnum = default(IntPtr);
            mdSignature[] rSignatures;
            uint pcSignatures;
            HRESULT hr = Raw.EnumSignatures(ref phEnum, out rSignatures, cmax, out pcSignatures);

            if (hr == HRESULT.S_OK)
                result = new EnumSignaturesResult(phEnum, rSignatures, pcSignatures);
            else
                result = default(EnumSignaturesResult);

            return hr;
        }

        #endregion
        #region EnumTypeSpecs

        public EnumTypeSpecsResult EnumTypeSpecs(uint cmax)
        {
            HRESULT hr;
            EnumTypeSpecsResult result;

            if ((hr = TryEnumTypeSpecs(cmax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumTypeSpecs(uint cmax, out EnumTypeSpecsResult result)
        {
            /*HRESULT EnumTypeSpecs(
            [In, Out] ref IntPtr phEnum,
            [Out] out mdTypeSpec[] rTypeSpecs,
            [In] uint cmax,
            [Out] out uint pcTypeSpecs);*/
            IntPtr phEnum = default(IntPtr);
            mdTypeSpec[] rTypeSpecs;
            uint pcTypeSpecs;
            HRESULT hr = Raw.EnumTypeSpecs(ref phEnum, out rTypeSpecs, cmax, out pcTypeSpecs);

            if (hr == HRESULT.S_OK)
                result = new EnumTypeSpecsResult(phEnum, rTypeSpecs, pcTypeSpecs);
            else
                result = default(EnumTypeSpecsResult);

            return hr;
        }

        #endregion
        #region EnumUserStrings

        public EnumUserStringsResult EnumUserStrings(uint cmax)
        {
            HRESULT hr;
            EnumUserStringsResult result;

            if ((hr = TryEnumUserStrings(cmax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumUserStrings(uint cmax, out EnumUserStringsResult result)
        {
            /*HRESULT EnumUserStrings(
            [In, Out] ref IntPtr phEnum,
            [Out] out mdString[] rStrings,
            [In] uint cmax,
            [Out] out uint pcStrings);*/
            IntPtr phEnum = default(IntPtr);
            mdString[] rStrings;
            uint pcStrings;
            HRESULT hr = Raw.EnumUserStrings(ref phEnum, out rStrings, cmax, out pcStrings);

            if (hr == HRESULT.S_OK)
                result = new EnumUserStringsResult(phEnum, rStrings, pcStrings);
            else
                result = default(EnumUserStringsResult);

            return hr;
        }

        #endregion
        #region GetParamForMethodIndex

        public mdParamDef GetParamForMethodIndex(mdMethodDef md, int ulParamSeq)
        {
            HRESULT hr;
            mdParamDef ppd;

            if ((hr = TryGetParamForMethodIndex(md, ulParamSeq, out ppd)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppd;
        }

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

        public EnumCustomAttributesResult EnumCustomAttributes(mdToken tk, mdToken tkType, uint cMax)
        {
            HRESULT hr;
            EnumCustomAttributesResult result;

            if ((hr = TryEnumCustomAttributes(tk, tkType, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumCustomAttributes(mdToken tk, mdToken tkType, uint cMax, out EnumCustomAttributesResult result)
        {
            /*HRESULT EnumCustomAttributes(
            [In, Out] ref IntPtr phEnum,
            [In] mdToken tk,
            [In] mdToken tkType,
            [Out] out mdCustomAttribute[] rCustomAttributes,
            [In] uint cMax,
            [Out] out uint pcCustomAttributes);*/
            IntPtr phEnum = default(IntPtr);
            mdCustomAttribute[] rCustomAttributes;
            uint pcCustomAttributes;
            HRESULT hr = Raw.EnumCustomAttributes(ref phEnum, tk, tkType, out rCustomAttributes, cMax, out pcCustomAttributes);

            if (hr == HRESULT.S_OK)
                result = new EnumCustomAttributesResult(phEnum, rCustomAttributes, pcCustomAttributes);
            else
                result = default(EnumCustomAttributesResult);

            return hr;
        }

        #endregion
        #region GetCustomAttributeProps

        public GetCustomAttributePropsResult GetCustomAttributeProps(mdCustomAttribute cv)
        {
            HRESULT hr;
            GetCustomAttributePropsResult result;

            if ((hr = TryGetCustomAttributeProps(cv, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetCustomAttributeProps(mdCustomAttribute cv, out GetCustomAttributePropsResult result)
        {
            /*HRESULT GetCustomAttributeProps(
            [In] mdCustomAttribute cv,
            [Out] out mdToken ptkObj,
            [Out] out mdToken ptkType,
            [Out] out IntPtr ppBlob,
            [Out] out uint pcbSize);*/
            mdToken ptkObj;
            mdToken ptkType;
            IntPtr ppBlob;
            uint pcbSize;
            HRESULT hr = Raw.GetCustomAttributeProps(cv, out ptkObj, out ptkType, out ppBlob, out pcbSize);

            if (hr == HRESULT.S_OK)
                result = new GetCustomAttributePropsResult(ptkObj, ptkType, ppBlob, pcbSize);
            else
                result = default(GetCustomAttributePropsResult);

            return hr;
        }

        #endregion
        #region FindTypeRef

        public mdTypeRef FindTypeRef(mdToken tkResolutionScope, string szName)
        {
            HRESULT hr;
            mdTypeRef ptr;

            if ((hr = TryFindTypeRef(tkResolutionScope, szName, out ptr)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ptr;
        }

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

        public GetMemberPropsResult GetMemberProps(mdToken mb)
        {
            HRESULT hr;
            GetMemberPropsResult result;

            if ((hr = TryGetMemberProps(mb, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetMemberProps(mdToken mb, out GetMemberPropsResult result)
        {
            /*HRESULT GetMemberProps(
            [In] mdToken mb,
            [Out] out mdTypeDef pClass,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szMember,
            [In] uint cchMember,
            [Out] out uint pchMember,
            [Out] out uint pdwAttr, //if its a method is it cormethodattr?
            [Out] out IntPtr ppvSigBlob,
            [Out] out uint pcbSigBlob,
            [Out] out uint pulCodeRVA,
            [Out] out uint pdwImplFlags,
            [Out] out CorElementType pdwCPlusTypeFlag,
            [Out] out IntPtr ppValue,
            [Out] out uint pcchValue);*/
            mdTypeDef pClass;
            StringBuilder szMember = null;
            uint cchMember = 0;
            uint pchMember;
            uint pdwAttr;
            IntPtr ppvSigBlob;
            uint pcbSigBlob;
            uint pulCodeRVA;
            uint pdwImplFlags;
            CorElementType pdwCPlusTypeFlag;
            IntPtr ppValue;
            uint pcchValue;
            HRESULT hr = Raw.GetMemberProps(mb, out pClass, szMember, cchMember, out pchMember, out pdwAttr, out ppvSigBlob, out pcbSigBlob, out pulCodeRVA, out pdwImplFlags, out pdwCPlusTypeFlag, out ppValue, out pcchValue);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchMember = pchMember;
            szMember = new StringBuilder((int) pchMember);
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

        public GetFieldPropsResult GetFieldProps(mdFieldDef mb)
        {
            HRESULT hr;
            GetFieldPropsResult result;

            if ((hr = TryGetFieldProps(mb, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetFieldProps(mdFieldDef mb, out GetFieldPropsResult result)
        {
            /*HRESULT GetFieldProps(
            [In] mdFieldDef mb,
            [Out] mdTypeDef pClass,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szField,
            [In] uint cchField,
            [Out] uint pchField,
            [Out] CorFieldAttr pdwAttr,
            [Out] IntPtr ppvSigBlob,
            [Out] uint pcbSigBlob,
            [Out] CorElementType pdwCPlusTypeFlag,
            [Out] IntPtr ppValue,
            [Out] uint pcchValue);*/
            mdTypeDef pClass = default(mdTypeDef);
            StringBuilder szField = null;
            uint cchField = 0;
            uint pchField = default(uint);
            CorFieldAttr pdwAttr = default(CorFieldAttr);
            IntPtr ppvSigBlob = default(IntPtr);
            uint pcbSigBlob = default(uint);
            CorElementType pdwCPlusTypeFlag = default(CorElementType);
            IntPtr ppValue = default(IntPtr);
            uint pcchValue = default(uint);
            HRESULT hr = Raw.GetFieldProps(mb, pClass, szField, cchField, pchField, pdwAttr, ppvSigBlob, pcbSigBlob, pdwCPlusTypeFlag, ppValue, pcchValue);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchField = pchField;
            szField = new StringBuilder((int) pchField);
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

        public GetPropertyPropsResult GetPropertyProps(mdProperty prop)
        {
            HRESULT hr;
            GetPropertyPropsResult result;

            if ((hr = TryGetPropertyProps(prop, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetPropertyProps(mdProperty prop, out GetPropertyPropsResult result)
        {
            /*HRESULT GetPropertyProps(
            [In] mdProperty prop,
            [Out] mdTypeDef pClass,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szProperty,
            [In] uint cchProperty,
            [Out] uint pchProperty,
            [Out] CorPropertyAttr pdwPropFlags,
            [Out] IntPtr ppvSig,
            [Out] uint pbSig,
            [Out] CorElementType pdwCPlusTypeFlag,
            [Out] IntPtr ppDefaultValue,
            [Out] uint pcchDefaultValue,
            [Out] mdMethodDef pmdSetter,
            [Out] mdMethodDef pmdGetter,
            [Out, MarshalAs(UnmanagedType.LPArray)] mdMethodDef[] rmdOtherMethod,
            [In] uint cMax,
            [Out] uint pcOtherMethod);*/
            mdTypeDef pClass = default(mdTypeDef);
            StringBuilder szProperty = null;
            uint cchProperty = 0;
            uint pchProperty = default(uint);
            CorPropertyAttr pdwPropFlags = default(CorPropertyAttr);
            IntPtr ppvSig = default(IntPtr);
            uint pbSig = default(uint);
            CorElementType pdwCPlusTypeFlag = default(CorElementType);
            IntPtr ppDefaultValue = default(IntPtr);
            uint pcchDefaultValue = default(uint);
            mdMethodDef pmdSetter = default(mdMethodDef);
            mdMethodDef pmdGetter = default(mdMethodDef);
            mdMethodDef[] rmdOtherMethod = null;
            uint cMax = 0;
            uint pcOtherMethod = default(uint);
            HRESULT hr = Raw.GetPropertyProps(prop, pClass, szProperty, cchProperty, pchProperty, pdwPropFlags, ppvSig, pbSig, pdwCPlusTypeFlag, ppDefaultValue, pcchDefaultValue, pmdSetter, pmdGetter, rmdOtherMethod, cMax, pcOtherMethod);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchProperty = pchProperty;
            szProperty = new StringBuilder((int) pchProperty);
            cMax = pcOtherMethod;
            rmdOtherMethod = new mdMethodDef[(int) pcOtherMethod];
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

        public GetParamPropsResult GetParamProps(mdParamDef tk)
        {
            HRESULT hr;
            GetParamPropsResult result;

            if ((hr = TryGetParamProps(tk, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetParamProps(mdParamDef tk, out GetParamPropsResult result)
        {
            /*HRESULT GetParamProps(
            [In] mdParamDef tk,
            [Out] mdMethodDef pmd,
            [Out] uint pulSequence,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder szName,
            [Out] uint cchName,
            [Out] uint pchName,
            [Out] CorParamAttr pdwAttr,
            [Out] CorElementType pdwCPlusTypeFlag,
            [Out] IntPtr ppValue,
            [Out] IntPtr pcchValue);*/
            mdMethodDef pmd = default(mdMethodDef);
            uint pulSequence = default(uint);
            StringBuilder szName = null;
            uint cchName = default(uint);
            uint pchName = default(uint);
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

        public GetCustomAttributeByNameResult GetCustomAttributeByName(mdToken tkObj, string szName)
        {
            HRESULT hr;
            GetCustomAttributeByNameResult result;

            if ((hr = TryGetCustomAttributeByName(tkObj, szName, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetCustomAttributeByName(mdToken tkObj, string szName, out GetCustomAttributeByNameResult result)
        {
            /*HRESULT GetCustomAttributeByName(
            [In] mdToken tkObj,
            [MarshalAs(UnmanagedType.LPWStr), In] string szName,
            [Out] IntPtr ppData,
            [Out] uint pcbData);*/
            IntPtr ppData = default(IntPtr);
            uint pcbData = default(uint);
            HRESULT hr = Raw.GetCustomAttributeByName(tkObj, szName, ppData, pcbData);

            if (hr == HRESULT.S_OK)
                result = new GetCustomAttributeByNameResult(ppData, pcbData);
            else
                result = default(GetCustomAttributeByNameResult);

            return hr;
        }

        #endregion
        #region IsValidToken

        public bool IsValidToken(mdToken tk)
        {
            /*bool IsValidToken([In] mdToken tk);*/
            return Raw.IsValidToken(tk);
        }

        #endregion
        #region GetNestedClassProps

        public mdTypeDef GetNestedClassProps(mdTypeDef tdNestedClass)
        {
            HRESULT hr;
            mdTypeDef ptdEnclosingClass;

            if ((hr = TryGetNestedClassProps(tdNestedClass, out ptdEnclosingClass)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ptdEnclosingClass;
        }

        public HRESULT TryGetNestedClassProps(mdTypeDef tdNestedClass, out mdTypeDef ptdEnclosingClass)
        {
            /*HRESULT GetNestedClassProps(
            [In] mdTypeDef tdNestedClass,
            [Out] out mdTypeDef ptdEnclosingClass);*/
            return Raw.GetNestedClassProps(tdNestedClass, out ptdEnclosingClass);
        }

        #endregion
        #region GetNativeCallConvFromSig

        public uint GetNativeCallConvFromSig(IntPtr pvSig, uint cbSig)
        {
            HRESULT hr;
            uint pCallConv;

            if ((hr = TryGetNativeCallConvFromSig(pvSig, cbSig, out pCallConv)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pCallConv;
        }

        public HRESULT TryGetNativeCallConvFromSig(IntPtr pvSig, uint cbSig, out uint pCallConv)
        {
            /*HRESULT GetNativeCallConvFromSig(
            [In] IntPtr pvSig,
            [In] uint cbSig,
            [Out] out uint pCallConv);*/
            return Raw.GetNativeCallConvFromSig(pvSig, cbSig, out pCallConv);
        }

        #endregion
        #region IsGlobal

        public int IsGlobal(mdToken pd)
        {
            HRESULT hr;
            int pbGlobal;

            if ((hr = TryIsGlobal(pd, out pbGlobal)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pbGlobal;
        }

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

        public IMetaDataImport2 Raw2 => (IMetaDataImport2) Raw;

        #region GetPEKind

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

        public HRESULT TryGetPEKind(out GetPEKindResult result)
        {
            /*HRESULT GetPEKind(
            [Out] out CorPEKind pdwPEKind,
            [Out] out uint pdwMachine);*/
            CorPEKind pdwPEKind;
            uint pdwMachine;
            HRESULT hr = Raw2.GetPEKind(out pdwPEKind, out pdwMachine);

            if (hr == HRESULT.S_OK)
                result = new GetPEKindResult(pdwPEKind, pdwMachine);
            else
                result = default(GetPEKindResult);

            return hr;
        }

        #endregion
        #region GetVersionString

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

        public HRESULT TryGetVersionString(out string pwzBufResult)
        {
            /*HRESULT GetVersionString(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwzBuf,
            [In] uint ccBufSize,
            [Out] out uint pccBufSize);*/
            StringBuilder pwzBuf = null;
            uint ccBufSize = 0;
            uint pccBufSize;
            HRESULT hr = Raw2.GetVersionString(pwzBuf, ccBufSize, out pccBufSize);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            ccBufSize = pccBufSize;
            pwzBuf = new StringBuilder((int) pccBufSize);
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

        public EnumGenericParamsResult EnumGenericParams(mdToken tk, uint cMax)
        {
            HRESULT hr;
            EnumGenericParamsResult result;

            if ((hr = TryEnumGenericParams(tk, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumGenericParams(mdToken tk, uint cMax, out EnumGenericParamsResult result)
        {
            /*HRESULT EnumGenericParams(
            [In, Out] ref IntPtr phEnum,
            [In] mdToken tk,
            [Out] out mdGenericParam[] rGenericParams,
            [In] uint cMax,
            [Out] out uint pcGenericParams);*/
            IntPtr phEnum = default(IntPtr);
            mdGenericParam[] rGenericParams;
            uint pcGenericParams;
            HRESULT hr = Raw2.EnumGenericParams(ref phEnum, tk, out rGenericParams, cMax, out pcGenericParams);

            if (hr == HRESULT.S_OK)
                result = new EnumGenericParamsResult(phEnum, rGenericParams, pcGenericParams);
            else
                result = default(EnumGenericParamsResult);

            return hr;
        }

        #endregion
        #region GetGenericParamProps

        public GetGenericParamPropsResult GetGenericParamProps(mdGenericParam gp)
        {
            HRESULT hr;
            GetGenericParamPropsResult result;

            if ((hr = TryGetGenericParamProps(gp, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetGenericParamProps(mdGenericParam gp, out GetGenericParamPropsResult result)
        {
            /*HRESULT GetGenericParamProps(
            [In] mdGenericParam gp,
            [Out] out uint pulParamSeq,
            [Out] out CorGenericParamAttr pdwParamFlags,
            [Out] mdToken ptOwner,
            [Out] uint reserved,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder wzname,
            [In] uint cchName,
            [Out] out uint pchName);*/
            uint pulParamSeq;
            CorGenericParamAttr pdwParamFlags;
            mdToken ptOwner = default(mdToken);
            uint reserved = default(uint);
            StringBuilder wzname = null;
            uint cchName = 0;
            uint pchName;
            HRESULT hr = Raw2.GetGenericParamProps(gp, out pulParamSeq, out pdwParamFlags, ptOwner, reserved, wzname, cchName, out pchName);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchName = pchName;
            wzname = new StringBuilder((int) pchName);
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

        public GetMethodSpecPropsResult GetMethodSpecProps(mdMethodSpec mi)
        {
            HRESULT hr;
            GetMethodSpecPropsResult result;

            if ((hr = TryGetMethodSpecProps(mi, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetMethodSpecProps(mdMethodSpec mi, out GetMethodSpecPropsResult result)
        {
            /*HRESULT GetMethodSpecProps(
            [In] mdMethodSpec mi,
            [Out] out mdToken tkParent,
            [Out] out IntPtr ppvSigBlob,
            [Out] out uint pcbSigBlob);*/
            mdToken tkParent;
            IntPtr ppvSigBlob;
            uint pcbSigBlob;
            HRESULT hr = Raw2.GetMethodSpecProps(mi, out tkParent, out ppvSigBlob, out pcbSigBlob);

            if (hr == HRESULT.S_OK)
                result = new GetMethodSpecPropsResult(tkParent, ppvSigBlob, pcbSigBlob);
            else
                result = default(GetMethodSpecPropsResult);

            return hr;
        }

        #endregion
        #region EnumGenericParamConstraints

        public EnumGenericParamConstraintsResult EnumGenericParamConstraints(mdGenericParam tk, uint cMax)
        {
            HRESULT hr;
            EnumGenericParamConstraintsResult result;

            if ((hr = TryEnumGenericParamConstraints(tk, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumGenericParamConstraints(mdGenericParam tk, uint cMax, out EnumGenericParamConstraintsResult result)
        {
            /*HRESULT EnumGenericParamConstraints(
            [In, Out] ref IntPtr phEnum,
            [In] mdGenericParam tk,
            [Out] mdGenericParamConstraint[] rGenericParamConstraints,
            [In] uint cMax,
            [Out] out uint pcGenericParamConstraints);*/
            IntPtr phEnum = default(IntPtr);
            mdGenericParamConstraint[] rGenericParamConstraints = default(mdGenericParamConstraint[]);
            uint pcGenericParamConstraints;
            HRESULT hr = Raw2.EnumGenericParamConstraints(ref phEnum, tk, rGenericParamConstraints, cMax, out pcGenericParamConstraints);

            if (hr == HRESULT.S_OK)
                result = new EnumGenericParamConstraintsResult(phEnum, rGenericParamConstraints, pcGenericParamConstraints);
            else
                result = default(EnumGenericParamConstraintsResult);

            return hr;
        }

        #endregion
        #region GetGenericParamConstraintProps

        public GetGenericParamConstraintPropsResult GetGenericParamConstraintProps(mdGenericParamConstraint gpc)
        {
            HRESULT hr;
            GetGenericParamConstraintPropsResult result;

            if ((hr = TryGetGenericParamConstraintProps(gpc, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

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

        public EnumMethodSpecsResult EnumMethodSpecs(mdToken tk, uint cMax)
        {
            HRESULT hr;
            EnumMethodSpecsResult result;

            if ((hr = TryEnumMethodSpecs(tk, cMax, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryEnumMethodSpecs(mdToken tk, uint cMax, out EnumMethodSpecsResult result)
        {
            /*HRESULT EnumMethodSpecs(
            [In, Out] ref IntPtr phEnum,
            [In] mdToken tk,
            [Out] mdMethodSpec[] rMethodSpecs,
            [In] uint cMax,
            [Out] out uint pcMethodSpecs);*/
            IntPtr phEnum = default(IntPtr);
            mdMethodSpec[] rMethodSpecs = default(mdMethodSpec[]);
            uint pcMethodSpecs;
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