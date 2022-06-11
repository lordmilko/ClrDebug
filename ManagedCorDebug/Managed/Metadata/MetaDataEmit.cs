using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class MetaDataEmit : ComObject<IMetaDataEmit>
    {
        public MetaDataEmit(IMetaDataEmit raw) : base(raw)
        {
        }

        #region IMetaDataEmit
        #region SetModuleProps

        public void SetModuleProps(string szName)
        {
            HRESULT hr;

            if ((hr = TrySetModuleProps(szName)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetModuleProps(string szName)
        {
            /*HRESULT SetModuleProps(
            [MarshalAs(UnmanagedType.LPWStr)] string szName);*/
            return Raw.SetModuleProps(szName);
        }

        #endregion
        #region Save

        public void Save(string szFile, uint dwSaveFlags)
        {
            HRESULT hr;

            if ((hr = TrySave(szFile, dwSaveFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySave(string szFile, uint dwSaveFlags)
        {
            /*HRESULT Save(
            [MarshalAs(UnmanagedType.LPWStr)] string szFile,
            uint dwSaveFlags);*/
            return Raw.Save(szFile, dwSaveFlags);
        }

        #endregion
        #region SaveToStream

        public void SaveToStream(object pIStream, uint dwSaveFlags)
        {
            HRESULT hr;

            if ((hr = TrySaveToStream(pIStream, dwSaveFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySaveToStream(object pIStream, uint dwSaveFlags)
        {
            /*HRESULT SaveToStream(
            [MarshalAs(UnmanagedType.Interface)] object pIStream,
            uint dwSaveFlags);*/
            return Raw.SaveToStream(pIStream, dwSaveFlags);
        }

        #endregion
        #region GetSaveSize

        public uint GetSaveSize(CorSaveSize fSave)
        {
            HRESULT hr;
            uint pdwSaveSize;

            if ((hr = TryGetSaveSize(fSave, out pdwSaveSize)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pdwSaveSize;
        }

        public HRESULT TryGetSaveSize(CorSaveSize fSave, out uint pdwSaveSize)
        {
            /*HRESULT GetSaveSize(
            CorSaveSize fSave,
            out uint pdwSaveSize);*/
            return Raw.GetSaveSize(fSave, out pdwSaveSize);
        }

        #endregion
        #region DefineTypeDef

        public mdTypeDef DefineTypeDef(string szTypeDef, uint dwTypeDefFlags, mdToken tkExtends, mdToken[] rtkImplements)
        {
            HRESULT hr;
            mdTypeDef ptd;

            if ((hr = TryDefineTypeDef(szTypeDef, dwTypeDefFlags, tkExtends, rtkImplements, out ptd)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ptd;
        }

        public HRESULT TryDefineTypeDef(string szTypeDef, uint dwTypeDefFlags, mdToken tkExtends, mdToken[] rtkImplements, out mdTypeDef ptd)
        {
            /*HRESULT DefineTypeDef(
            [MarshalAs(UnmanagedType.LPWStr)] string szTypeDef,
            uint dwTypeDefFlags,
            mdToken tkExtends,
            [MarshalAs(UnmanagedType.LPArray)] mdToken[] rtkImplements,
            out mdTypeDef ptd);*/
            return Raw.DefineTypeDef(szTypeDef, dwTypeDefFlags, tkExtends, rtkImplements, out ptd);
        }

        #endregion
        #region DefineNestedType

        public mdTypeDef DefineNestedType(string szTypeDef, CorTypeAttr dwTypeDefFlags, mdToken tkExtends, mdToken[] rtkImplements, mdToken tdEncloser)
        {
            HRESULT hr;
            mdTypeDef ptd;

            if ((hr = TryDefineNestedType(szTypeDef, dwTypeDefFlags, tkExtends, rtkImplements, tdEncloser, out ptd)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ptd;
        }

        public HRESULT TryDefineNestedType(string szTypeDef, CorTypeAttr dwTypeDefFlags, mdToken tkExtends, mdToken[] rtkImplements, mdToken tdEncloser, out mdTypeDef ptd)
        {
            /*HRESULT DefineNestedType(
            [MarshalAs(UnmanagedType.LPWStr)] string szTypeDef,
            CorTypeAttr dwTypeDefFlags,
            mdToken tkExtends,
            [MarshalAs(UnmanagedType.LPArray)] mdToken[] rtkImplements,
            mdToken tdEncloser,
            out mdTypeDef ptd);*/
            return Raw.DefineNestedType(szTypeDef, dwTypeDefFlags, tkExtends, rtkImplements, tdEncloser, out ptd);
        }

        #endregion
        #region SetHandler

        public void SetHandler(object pUnk)
        {
            HRESULT hr;

            if ((hr = TrySetHandler(pUnk)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetHandler(object pUnk)
        {
            /*HRESULT SetHandler(
            [MarshalAs(UnmanagedType.IUnknown)] object pUnk);*/
            return Raw.SetHandler(pUnk);
        }

        #endregion
        #region DefineMethod

        public uint DefineMethod(mdToken td, string szName, MethodAttributes dwMethodFlags, byte[] pvSigBlob, uint cbSigBlob, uint ulCodeRVA, MethodImplAttributes dwImplFlags)
        {
            HRESULT hr;
            uint pmd;

            if ((hr = TryDefineMethod(td, szName, dwMethodFlags, pvSigBlob, cbSigBlob, ulCodeRVA, dwImplFlags, out pmd)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pmd;
        }

        public HRESULT TryDefineMethod(mdToken td, string szName, MethodAttributes dwMethodFlags, byte[] pvSigBlob, uint cbSigBlob, uint ulCodeRVA, MethodImplAttributes dwImplFlags, out uint pmd)
        {
            /*HRESULT DefineMethod(
            mdToken td,
            [MarshalAs(UnmanagedType.LPWStr)] string szName,
            MethodAttributes dwMethodFlags,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] pvSigBlob,
            uint cbSigBlob,
            uint ulCodeRVA,
            MethodImplAttributes dwImplFlags,
            out uint pmd);*/
            return Raw.DefineMethod(td, szName, dwMethodFlags, pvSigBlob, cbSigBlob, ulCodeRVA, dwImplFlags, out pmd);
        }

        #endregion
        #region DefineMethodImpl

        public void DefineMethodImpl(mdTypeDef td, mdToken tkBody, mdToken tkDecl)
        {
            HRESULT hr;

            if ((hr = TryDefineMethodImpl(td, tkBody, tkDecl)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryDefineMethodImpl(mdTypeDef td, mdToken tkBody, mdToken tkDecl)
        {
            /*HRESULT DefineMethodImpl(
            mdTypeDef td,
            mdToken tkBody,
            mdToken tkDecl);*/
            return Raw.DefineMethodImpl(td, tkBody, tkDecl);
        }

        #endregion
        #region DefineTypeRefByName

        public mdTypeRef DefineTypeRefByName(mdToken tkResolutionScope, string szName)
        {
            HRESULT hr;
            mdTypeRef ptr;

            if ((hr = TryDefineTypeRefByName(tkResolutionScope, szName, out ptr)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ptr;
        }

        public HRESULT TryDefineTypeRefByName(mdToken tkResolutionScope, string szName, out mdTypeRef ptr)
        {
            /*HRESULT DefineTypeRefByName(
            mdToken tkResolutionScope,
            [MarshalAs(UnmanagedType.LPWStr)] string szName,
            out mdTypeRef ptr);*/
            return Raw.DefineTypeRefByName(tkResolutionScope, szName, out ptr);
        }

        #endregion
        #region DefineImportType

        public mdTypeRef DefineImportType(IMetaDataAssemblyImport pAssemImport, byte[] pbHashValue, uint cbHashValue, IMetaDataImport pImport, mdTypeDef tdImport, IMetaDataAssemblyEmit pAssemEmit)
        {
            HRESULT hr;
            mdTypeRef ptr;

            if ((hr = TryDefineImportType(pAssemImport, pbHashValue, cbHashValue, pImport, tdImport, pAssemEmit, out ptr)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ptr;
        }

        public HRESULT TryDefineImportType(IMetaDataAssemblyImport pAssemImport, byte[] pbHashValue, uint cbHashValue, IMetaDataImport pImport, mdTypeDef tdImport, IMetaDataAssemblyEmit pAssemEmit, out mdTypeRef ptr)
        {
            /*HRESULT DefineImportType(
            [MarshalAs(UnmanagedType.Interface)] IMetaDataAssemblyImport pAssemImport,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pbHashValue,
            uint cbHashValue,
            [MarshalAs(UnmanagedType.Interface)] IMetaDataImport pImport,
            mdTypeDef tdImport,
            [MarshalAs(UnmanagedType.Interface)] IMetaDataAssemblyEmit pAssemEmit,
            out mdTypeRef ptr);*/
            return Raw.DefineImportType(pAssemImport, pbHashValue, cbHashValue, pImport, tdImport, pAssemEmit, out ptr);
        }

        #endregion
        #region DefineMemberRef

        public mdMemberRef DefineMemberRef(mdModuleRef tkImport, string szName, byte[] pvSigBlob, uint cbSigBlob)
        {
            HRESULT hr;
            mdMemberRef pmr;

            if ((hr = TryDefineMemberRef(tkImport, szName, pvSigBlob, cbSigBlob, out pmr)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pmr;
        }

        public HRESULT TryDefineMemberRef(mdModuleRef tkImport, string szName, byte[] pvSigBlob, uint cbSigBlob, out mdMemberRef pmr)
        {
            /*HRESULT DefineMemberRef(
            mdModuleRef tkImport,
            [MarshalAs(UnmanagedType.LPWStr)] string szName,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pvSigBlob,
            uint cbSigBlob,
            out mdMemberRef pmr);*/
            return Raw.DefineMemberRef(tkImport, szName, pvSigBlob, cbSigBlob, out pmr);
        }

        #endregion
        #region DefineImportMember

        public mdMemberRef DefineImportMember(IMetaDataAssemblyImport pAssemImport, byte[] pbHashValue, uint cbHashValue, IMetaDataImport pImport, mdToken mbMember, IMetaDataAssemblyEmit pAssemEmit, mdToken tkParent)
        {
            HRESULT hr;
            mdMemberRef pmr;

            if ((hr = TryDefineImportMember(pAssemImport, pbHashValue, cbHashValue, pImport, mbMember, pAssemEmit, tkParent, out pmr)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pmr;
        }

        public HRESULT TryDefineImportMember(IMetaDataAssemblyImport pAssemImport, byte[] pbHashValue, uint cbHashValue, IMetaDataImport pImport, mdToken mbMember, IMetaDataAssemblyEmit pAssemEmit, mdToken tkParent, out mdMemberRef pmr)
        {
            /*HRESULT DefineImportMember(
            [MarshalAs(UnmanagedType.Interface)] IMetaDataAssemblyImport pAssemImport,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pbHashValue,
            uint cbHashValue,
            [MarshalAs(UnmanagedType.Interface)] IMetaDataImport pImport,
            mdToken mbMember,
            [MarshalAs(UnmanagedType.Interface)] IMetaDataAssemblyEmit pAssemEmit,
            mdToken tkParent,
            out mdMemberRef pmr);*/
            return Raw.DefineImportMember(pAssemImport, pbHashValue, cbHashValue, pImport, mbMember, pAssemEmit, tkParent, out pmr);
        }

        #endregion
        #region DefineEvent

        public mdToken DefineEvent(mdToken td, string szEvent, uint dwEventFlags, mdToken tkEventType, uint mdAddOn, uint mdRemoveOn, uint mdFire, mdMethodDef[] rmdOtherMethods)
        {
            HRESULT hr;
            mdToken pmdEvent;

            if ((hr = TryDefineEvent(td, szEvent, dwEventFlags, tkEventType, mdAddOn, mdRemoveOn, mdFire, rmdOtherMethods, out pmdEvent)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pmdEvent;
        }

        public HRESULT TryDefineEvent(mdToken td, string szEvent, uint dwEventFlags, mdToken tkEventType, uint mdAddOn, uint mdRemoveOn, uint mdFire, mdMethodDef[] rmdOtherMethods, out mdToken pmdEvent)
        {
            /*HRESULT DefineEvent(
            mdToken td,
            [MarshalAs(UnmanagedType.LPWStr)] string szEvent,
            uint dwEventFlags,
            mdToken tkEventType,
            uint mdAddOn,
            uint mdRemoveOn,
            uint mdFire,
            [MarshalAs(UnmanagedType.LPArray)] mdMethodDef[] rmdOtherMethods,
            out mdToken pmdEvent);*/
            return Raw.DefineEvent(td, szEvent, dwEventFlags, tkEventType, mdAddOn, mdRemoveOn, mdFire, rmdOtherMethods, out pmdEvent);
        }

        #endregion
        #region SetClassLayout

        public void SetClassLayout(mdTypeDef td, uint dwPackSize, mdToken[] rFieldOffsets, uint ulClassSize)
        {
            HRESULT hr;

            if ((hr = TrySetClassLayout(td, dwPackSize, rFieldOffsets, ulClassSize)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetClassLayout(mdTypeDef td, uint dwPackSize, mdToken[] rFieldOffsets, uint ulClassSize)
        {
            /*HRESULT SetClassLayout(
            mdTypeDef td,
            uint dwPackSize,
            [MarshalAs(UnmanagedType.LPArray)] mdToken[] rFieldOffsets,
            uint ulClassSize);*/
            return Raw.SetClassLayout(td, dwPackSize, rFieldOffsets, ulClassSize);
        }

        #endregion
        #region DeleteClassLayout

        public void DeleteClassLayout(mdTypeDef td)
        {
            HRESULT hr;

            if ((hr = TryDeleteClassLayout(td)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryDeleteClassLayout(mdTypeDef td)
        {
            /*HRESULT DeleteClassLayout(mdTypeDef td);*/
            return Raw.DeleteClassLayout(td);
        }

        #endregion
        #region SetFieldMarshal

        public void SetFieldMarshal(mdToken tk, byte[] pvNativeType, uint cbNativeType)
        {
            HRESULT hr;

            if ((hr = TrySetFieldMarshal(tk, pvNativeType, cbNativeType)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetFieldMarshal(mdToken tk, byte[] pvNativeType, uint cbNativeType)
        {
            /*HRESULT SetFieldMarshal(
            mdToken tk,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pvNativeType,
            uint cbNativeType);*/
            return Raw.SetFieldMarshal(tk, pvNativeType, cbNativeType);
        }

        #endregion
        #region DeleteFieldMarshal

        public void DeleteFieldMarshal(mdToken tk)
        {
            HRESULT hr;

            if ((hr = TryDeleteFieldMarshal(tk)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryDeleteFieldMarshal(mdToken tk)
        {
            /*HRESULT DeleteFieldMarshal(mdToken tk);*/
            return Raw.DeleteFieldMarshal(tk);
        }

        #endregion
        #region DefinePermissionSet

        public uint DefinePermissionSet(mdToken tk, CorDeclSecurity dwAction, byte[] pvPermission, uint cbPermission)
        {
            HRESULT hr;
            uint ppm;

            if ((hr = TryDefinePermissionSet(tk, dwAction, pvPermission, cbPermission, out ppm)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppm;
        }

        public HRESULT TryDefinePermissionSet(mdToken tk, CorDeclSecurity dwAction, byte[] pvPermission, uint cbPermission, out uint ppm)
        {
            /*HRESULT DefinePermissionSet(
            mdToken tk,
            CorDeclSecurity dwAction,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pvPermission,
            uint cbPermission,
            out uint ppm);*/
            return Raw.DefinePermissionSet(tk, dwAction, pvPermission, cbPermission, out ppm);
        }

        #endregion
        #region SetRVA

        public void SetRVA(uint md, uint ulRVA)
        {
            HRESULT hr;

            if ((hr = TrySetRVA(md, ulRVA)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetRVA(uint md, uint ulRVA)
        {
            /*HRESULT SetRVA(
            uint md,
            uint ulRVA);*/
            return Raw.SetRVA(md, ulRVA);
        }

        #endregion
        #region GetTokenFromSig

        public mdSignature GetTokenFromSig(byte[] pvSig, uint cbSig)
        {
            HRESULT hr;
            mdSignature pmsig;

            if ((hr = TryGetTokenFromSig(pvSig, cbSig, out pmsig)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pmsig;
        }

        public HRESULT TryGetTokenFromSig(byte[] pvSig, uint cbSig, out mdSignature pmsig)
        {
            /*HRESULT GetTokenFromSig(
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pvSig,
            uint cbSig,
            out mdSignature pmsig);*/
            return Raw.GetTokenFromSig(pvSig, cbSig, out pmsig);
        }

        #endregion
        #region DefineModuleRef

        public mdModuleRef DefineModuleRef(string szName)
        {
            HRESULT hr;
            mdModuleRef pmur;

            if ((hr = TryDefineModuleRef(szName, out pmur)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pmur;
        }

        public HRESULT TryDefineModuleRef(string szName, out mdModuleRef pmur)
        {
            /*HRESULT DefineModuleRef(
            [MarshalAs(UnmanagedType.LPWStr)] string szName,
            out mdModuleRef pmur);*/
            return Raw.DefineModuleRef(szName, out pmur);
        }

        #endregion
        #region SetParent

        public void SetParent(mdMemberRef mr, mdToken tk)
        {
            HRESULT hr;

            if ((hr = TrySetParent(mr, tk)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetParent(mdMemberRef mr, mdToken tk)
        {
            /*HRESULT SetParent(
            mdMemberRef mr,
            mdToken tk);*/
            return Raw.SetParent(mr, tk);
        }

        #endregion
        #region GetTokenFromTypeSpec

        public mdTypeSpec GetTokenFromTypeSpec(byte[] pvSig, uint cbSig)
        {
            HRESULT hr;
            mdTypeSpec ptypespec;

            if ((hr = TryGetTokenFromTypeSpec(pvSig, cbSig, out ptypespec)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ptypespec;
        }

        public HRESULT TryGetTokenFromTypeSpec(byte[] pvSig, uint cbSig, out mdTypeSpec ptypespec)
        {
            /*HRESULT GetTokenFromTypeSpec(
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pvSig,
            uint cbSig,
            out mdTypeSpec ptypespec);*/
            return Raw.GetTokenFromTypeSpec(pvSig, cbSig, out ptypespec);
        }

        #endregion
        #region SaveToMemory

        public void SaveToMemory(IntPtr pbData, uint cbData)
        {
            HRESULT hr;

            if ((hr = TrySaveToMemory(pbData, cbData)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySaveToMemory(IntPtr pbData, uint cbData)
        {
            /*HRESULT SaveToMemory(
            IntPtr pbData,
            uint cbData);*/
            return Raw.SaveToMemory(pbData, cbData);
        }

        #endregion
        #region DefineUserString

        public uint DefineUserString(string szString, uint cchString)
        {
            HRESULT hr;
            uint pstk;

            if ((hr = TryDefineUserString(szString, cchString, out pstk)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pstk;
        }

        public HRESULT TryDefineUserString(string szString, uint cchString, out uint pstk)
        {
            /*HRESULT DefineUserString(
            [MarshalAs(UnmanagedType.LPWStr, SizeParamIndex = 1)] string szString,
            uint cchString,
            out uint pstk);*/
            return Raw.DefineUserString(szString, cchString, out pstk);
        }

        #endregion
        #region DeleteToken

        public void DeleteToken(mdToken tkObj)
        {
            HRESULT hr;

            if ((hr = TryDeleteToken(tkObj)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryDeleteToken(mdToken tkObj)
        {
            /*HRESULT DeleteToken(mdToken tkObj);*/
            return Raw.DeleteToken(tkObj);
        }

        #endregion
        #region SetMethodProps

        public void SetMethodProps(uint md, uint dwMethodFlags, uint ulCodeRVA, uint dwImplFlags)
        {
            HRESULT hr;

            if ((hr = TrySetMethodProps(md, dwMethodFlags, ulCodeRVA, dwImplFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetMethodProps(uint md, uint dwMethodFlags, uint ulCodeRVA, uint dwImplFlags)
        {
            /*HRESULT SetMethodProps(
            uint md,
            uint dwMethodFlags,
            uint ulCodeRVA,
            uint dwImplFlags);*/
            return Raw.SetMethodProps(md, dwMethodFlags, ulCodeRVA, dwImplFlags);
        }

        #endregion
        #region SetTypeDefProps

        public void SetTypeDefProps(mdTypeDef td, CorTypeAttr dwTypeDefFlags, mdToken tkExtends, mdToken[] rtkImplements)
        {
            HRESULT hr;

            if ((hr = TrySetTypeDefProps(td, dwTypeDefFlags, tkExtends, rtkImplements)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetTypeDefProps(mdTypeDef td, CorTypeAttr dwTypeDefFlags, mdToken tkExtends, mdToken[] rtkImplements)
        {
            /*HRESULT SetTypeDefProps(
            mdTypeDef td,
            CorTypeAttr dwTypeDefFlags,
            mdToken tkExtends,
            [MarshalAs(UnmanagedType.LPArray)] mdToken[] rtkImplements);*/
            return Raw.SetTypeDefProps(td, dwTypeDefFlags, tkExtends, rtkImplements);
        }

        #endregion
        #region SetEventProps

        public void SetEventProps(uint ev, CorEventAttr dwEventFlags, mdToken tkEventType, uint mdAddOn, uint mdRemoveOn, uint mdFire, mdMethodDef[] rmdOtherMethods)
        {
            HRESULT hr;

            if ((hr = TrySetEventProps(ev, dwEventFlags, tkEventType, mdAddOn, mdRemoveOn, mdFire, rmdOtherMethods)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetEventProps(uint ev, CorEventAttr dwEventFlags, mdToken tkEventType, uint mdAddOn, uint mdRemoveOn, uint mdFire, mdMethodDef[] rmdOtherMethods)
        {
            /*HRESULT SetEventProps(
            uint ev,
            CorEventAttr dwEventFlags,
            mdToken tkEventType,
            uint mdAddOn,
            uint mdRemoveOn,
            uint mdFire,
            [MarshalAs(UnmanagedType.LPArray)] mdMethodDef[] rmdOtherMethods);*/
            return Raw.SetEventProps(ev, dwEventFlags, tkEventType, mdAddOn, mdRemoveOn, mdFire, rmdOtherMethods);
        }

        #endregion
        #region SetPermissionSetProps

        public mdPermission SetPermissionSetProps(mdToken tk, CorDeclSecurity dwAction, byte[] pvPermission, uint cbPermission)
        {
            HRESULT hr;
            mdPermission ppm;

            if ((hr = TrySetPermissionSetProps(tk, dwAction, pvPermission, cbPermission, out ppm)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppm;
        }

        public HRESULT TrySetPermissionSetProps(mdToken tk, CorDeclSecurity dwAction, byte[] pvPermission, uint cbPermission, out mdPermission ppm)
        {
            /*HRESULT SetPermissionSetProps(
            mdToken tk,
            CorDeclSecurity dwAction,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pvPermission,
            uint cbPermission,
            out mdPermission ppm);*/
            return Raw.SetPermissionSetProps(tk, dwAction, pvPermission, cbPermission, out ppm);
        }

        #endregion
        #region DefinePinvokeMap

        public void DefinePinvokeMap(mdToken tk, uint dwMappingFlags, string szImportName, uint mrImportDLL)
        {
            HRESULT hr;

            if ((hr = TryDefinePinvokeMap(tk, dwMappingFlags, szImportName, mrImportDLL)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryDefinePinvokeMap(mdToken tk, uint dwMappingFlags, string szImportName, uint mrImportDLL)
        {
            /*HRESULT DefinePinvokeMap(
            mdToken tk,
            uint dwMappingFlags,
            [MarshalAs(UnmanagedType.LPWStr)] string szImportName,
            uint mrImportDLL);*/
            return Raw.DefinePinvokeMap(tk, dwMappingFlags, szImportName, mrImportDLL);
        }

        #endregion
        #region SetPinvokeMap

        public void SetPinvokeMap(mdToken tk, CorPinvokeMap dwMappingFlags, string szImportName, mdModuleRef mrImportDLL)
        {
            HRESULT hr;

            if ((hr = TrySetPinvokeMap(tk, dwMappingFlags, szImportName, mrImportDLL)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetPinvokeMap(mdToken tk, CorPinvokeMap dwMappingFlags, string szImportName, mdModuleRef mrImportDLL)
        {
            /*HRESULT SetPinvokeMap(
            mdToken tk,
            CorPinvokeMap dwMappingFlags,
            [MarshalAs(UnmanagedType.LPWStr)] string szImportName,
            mdModuleRef mrImportDLL);*/
            return Raw.SetPinvokeMap(tk, dwMappingFlags, szImportName, mrImportDLL);
        }

        #endregion
        #region DeletePinvokeMap

        public void DeletePinvokeMap(mdToken tk)
        {
            HRESULT hr;

            if ((hr = TryDeletePinvokeMap(tk)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryDeletePinvokeMap(mdToken tk)
        {
            /*HRESULT DeletePinvokeMap(mdToken tk);*/
            return Raw.DeletePinvokeMap(tk);
        }

        #endregion
        #region DefineCustomAttribute

        public mdCustomAttribute DefineCustomAttribute(mdToken tkObj, mdToken tkType, byte[] pCustomAttribute, uint cbCustomAttribute)
        {
            HRESULT hr;
            mdCustomAttribute pcv;

            if ((hr = TryDefineCustomAttribute(tkObj, tkType, pCustomAttribute, cbCustomAttribute, out pcv)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pcv;
        }

        public HRESULT TryDefineCustomAttribute(mdToken tkObj, mdToken tkType, byte[] pCustomAttribute, uint cbCustomAttribute, out mdCustomAttribute pcv)
        {
            /*HRESULT DefineCustomAttribute(
            mdToken tkObj,
            mdToken tkType,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] pCustomAttribute,
            uint cbCustomAttribute,
            out mdCustomAttribute pcv);*/
            return Raw.DefineCustomAttribute(tkObj, tkType, pCustomAttribute, cbCustomAttribute, out pcv);
        }

        #endregion
        #region SetCustomAttributeValue

        public void SetCustomAttributeValue(uint pcv, byte[] pCustomAttribute, uint cbCustomAttribute)
        {
            HRESULT hr;

            if ((hr = TrySetCustomAttributeValue(pcv, pCustomAttribute, cbCustomAttribute)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetCustomAttributeValue(uint pcv, byte[] pCustomAttribute, uint cbCustomAttribute)
        {
            /*HRESULT SetCustomAttributeValue(
            uint pcv,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pCustomAttribute,
            uint cbCustomAttribute);*/
            return Raw.SetCustomAttributeValue(pcv, pCustomAttribute, cbCustomAttribute);
        }

        #endregion
        #region DefineField

        public mdFieldDef DefineField(mdTypeDef td, string szName, CorFieldAttr dwFieldFlags, byte[] pvSigBlob, uint cbSigBlob, CorElementType dwCPlusTypeFlag, byte[] pValue, uint cchValue)
        {
            HRESULT hr;
            mdFieldDef pmd;

            if ((hr = TryDefineField(td, szName, dwFieldFlags, pvSigBlob, cbSigBlob, dwCPlusTypeFlag, pValue, cchValue, out pmd)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pmd;
        }

        public HRESULT TryDefineField(mdTypeDef td, string szName, CorFieldAttr dwFieldFlags, byte[] pvSigBlob, uint cbSigBlob, CorElementType dwCPlusTypeFlag, byte[] pValue, uint cchValue, out mdFieldDef pmd)
        {
            /*HRESULT DefineField(
            mdTypeDef td,
            [MarshalAs(UnmanagedType.LPWStr)] string szName,
            CorFieldAttr dwFieldFlags,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] pvSigBlob,
            uint cbSigBlob,
            CorElementType dwCPlusTypeFlag,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 7)] byte[] pValue,
            uint cchValue,
            out mdFieldDef pmd);*/
            return Raw.DefineField(td, szName, dwFieldFlags, pvSigBlob, cbSigBlob, dwCPlusTypeFlag, pValue, cchValue, out pmd);
        }

        #endregion
        #region DefineProperty

        public mdProperty DefineProperty(uint td, string szProperty, uint dwPropFlags, byte[] pvSig, uint cbSig, uint dwCPlusTypeFlag, byte[] cvalue, uint cchValue, uint mdSetter, uint mdGetter, mdToken[] rmdOtherMethods)
        {
            HRESULT hr;
            mdProperty pmdProp;

            if ((hr = TryDefineProperty(td, szProperty, dwPropFlags, pvSig, cbSig, dwCPlusTypeFlag, cvalue, cchValue, mdSetter, mdGetter, rmdOtherMethods, out pmdProp)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pmdProp;
        }

        public HRESULT TryDefineProperty(uint td, string szProperty, uint dwPropFlags, byte[] pvSig, uint cbSig, uint dwCPlusTypeFlag, byte[] cvalue, uint cchValue, uint mdSetter, uint mdGetter, mdToken[] rmdOtherMethods, out mdProperty pmdProp)
        {
            /*HRESULT DefineProperty(
            uint td,
            [MarshalAs(UnmanagedType.LPWStr)] string szProperty,
            uint dwPropFlags,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] pvSig,
            uint cbSig,
            uint dwCPlusTypeFlag,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 7)] byte[] cvalue,
            uint cchValue,
            uint mdSetter,
            uint mdGetter,
            [MarshalAs(UnmanagedType.LPArray)] mdToken[] rmdOtherMethods,
            out mdProperty pmdProp);*/
            return Raw.DefineProperty(td, szProperty, dwPropFlags, pvSig, cbSig, dwCPlusTypeFlag, cvalue, cchValue, mdSetter, mdGetter, rmdOtherMethods, out pmdProp);
        }

        #endregion
        #region DefineParam

        public mdParamDef DefineParam(uint md, uint ulParamSeq, string szName, CorParamAttr dwParamFlags, CorElementType dwCPlusTypeFlag, byte[] pValue, uint cchValue)
        {
            HRESULT hr;
            mdParamDef ppd;

            if ((hr = TryDefineParam(md, ulParamSeq, szName, dwParamFlags, dwCPlusTypeFlag, pValue, cchValue, out ppd)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppd;
        }

        public HRESULT TryDefineParam(uint md, uint ulParamSeq, string szName, CorParamAttr dwParamFlags, CorElementType dwCPlusTypeFlag, byte[] pValue, uint cchValue, out mdParamDef ppd)
        {
            /*HRESULT DefineParam(
            uint md,
            uint ulParamSeq,
            [MarshalAs(UnmanagedType.LPWStr)] string szName,
            CorParamAttr dwParamFlags,
            CorElementType dwCPlusTypeFlag,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)] byte[] pValue,
            uint cchValue,
            out mdParamDef ppd);*/
            return Raw.DefineParam(md, ulParamSeq, szName, dwParamFlags, dwCPlusTypeFlag, pValue, cchValue, out ppd);
        }

        #endregion
        #region SetFieldProps

        public void SetFieldProps(uint fd, CorFieldAttr dwFieldFlags, CorElementType dwCPlusTypeFlag, byte[] pValue, uint cchValue)
        {
            HRESULT hr;

            if ((hr = TrySetFieldProps(fd, dwFieldFlags, dwCPlusTypeFlag, pValue, cchValue)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetFieldProps(uint fd, CorFieldAttr dwFieldFlags, CorElementType dwCPlusTypeFlag, byte[] pValue, uint cchValue)
        {
            /*HRESULT SetFieldProps(
            uint fd,
            CorFieldAttr dwFieldFlags,
            CorElementType dwCPlusTypeFlag,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] pValue,
            uint cchValue);*/
            return Raw.SetFieldProps(fd, dwFieldFlags, dwCPlusTypeFlag, pValue, cchValue);
        }

        #endregion
        #region SetPropertyProps

        public void SetPropertyProps(uint pr, uint dwPropFlags, uint dwCPlusTypeFlag, byte[] pValue, uint cchValue, uint mdSetter, uint mdGetter, mdToken[] rmdOtherMethods)
        {
            HRESULT hr;

            if ((hr = TrySetPropertyProps(pr, dwPropFlags, dwCPlusTypeFlag, pValue, cchValue, mdSetter, mdGetter, rmdOtherMethods)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetPropertyProps(uint pr, uint dwPropFlags, uint dwCPlusTypeFlag, byte[] pValue, uint cchValue, uint mdSetter, uint mdGetter, mdToken[] rmdOtherMethods)
        {
            /*HRESULT SetPropertyProps(
            uint pr,
            uint dwPropFlags,
            uint dwCPlusTypeFlag,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] pValue,
            uint cchValue,
            uint mdSetter,
            uint mdGetter,
            [MarshalAs(UnmanagedType.LPArray)] mdToken[] rmdOtherMethods);*/
            return Raw.SetPropertyProps(pr, dwPropFlags, dwCPlusTypeFlag, pValue, cchValue, mdSetter, mdGetter, rmdOtherMethods);
        }

        #endregion
        #region SetParamProps

        public void SetParamProps(uint pd, string szName, uint dwParamFlags, uint dwCPlusTypeFlag, byte[] pValue, uint cchValue)
        {
            HRESULT hr;

            if ((hr = TrySetParamProps(pd, szName, dwParamFlags, dwCPlusTypeFlag, pValue, cchValue)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetParamProps(uint pd, string szName, uint dwParamFlags, uint dwCPlusTypeFlag, byte[] pValue, uint cchValue)
        {
            /*HRESULT SetParamProps(
            uint pd,
            [MarshalAs(UnmanagedType.LPWStr)] string szName,
            uint dwParamFlags,
            uint dwCPlusTypeFlag,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] byte[] pValue,
            uint cchValue);*/
            return Raw.SetParamProps(pd, szName, dwParamFlags, dwCPlusTypeFlag, pValue, cchValue);
        }

        #endregion
        #region DefineSecurityAttributeSet

        public uint DefineSecurityAttributeSet(mdToken tkObj, COR_SECATTR[] rSecAttrs, uint cSecAttrs)
        {
            HRESULT hr;
            uint pulErrorAttr;

            if ((hr = TryDefineSecurityAttributeSet(tkObj, rSecAttrs, cSecAttrs, out pulErrorAttr)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pulErrorAttr;
        }

        public HRESULT TryDefineSecurityAttributeSet(mdToken tkObj, COR_SECATTR[] rSecAttrs, uint cSecAttrs, out uint pulErrorAttr)
        {
            /*HRESULT DefineSecurityAttributeSet(
            mdToken tkObj,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] COR_SECATTR[] rSecAttrs,
            uint cSecAttrs,
            out uint pulErrorAttr);*/
            return Raw.DefineSecurityAttributeSet(tkObj, rSecAttrs, cSecAttrs, out pulErrorAttr);
        }

        #endregion
        #region ApplyEditAndContinue

        public void ApplyEditAndContinue(object pImport)
        {
            HRESULT hr;

            if ((hr = TryApplyEditAndContinue(pImport)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryApplyEditAndContinue(object pImport)
        {
            /*HRESULT ApplyEditAndContinue([MarshalAs(UnmanagedType.IUnknown)] object pImport);*/
            return Raw.ApplyEditAndContinue(pImport);
        }

        #endregion
        #region TranslateSigWithScope

        public uint TranslateSigWithScope(IMetaDataAssemblyImport pAssemImport, byte[] pbHashValue, uint cbHashValue, IMetaDataImport import, byte[] pbSigBlob, uint cbSigBlob, IMetaDataAssemblyEmit pAssemEmit, IMetaDataEmit emit, byte[] pvTranslatedSig, uint cbTranslatedSigMax)
        {
            HRESULT hr;
            uint pcbTranslatedSig;

            if ((hr = TryTranslateSigWithScope(pAssemImport, pbHashValue, cbHashValue, import, pbSigBlob, cbSigBlob, pAssemEmit, emit, pvTranslatedSig, cbTranslatedSigMax, out pcbTranslatedSig)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pcbTranslatedSig;
        }

        public HRESULT TryTranslateSigWithScope(IMetaDataAssemblyImport pAssemImport, byte[] pbHashValue, uint cbHashValue, IMetaDataImport import, byte[] pbSigBlob, uint cbSigBlob, IMetaDataAssemblyEmit pAssemEmit, IMetaDataEmit emit, byte[] pvTranslatedSig, uint cbTranslatedSigMax, out uint pcbTranslatedSig)
        {
            /*HRESULT TranslateSigWithScope(
            [MarshalAs(UnmanagedType.Interface)] IMetaDataAssemblyImport pAssemImport,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pbHashValue,
            uint cbHashValue,
            [MarshalAs(UnmanagedType.Interface)] IMetaDataImport import,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] byte[] pbSigBlob,
            uint cbSigBlob,
            [MarshalAs(UnmanagedType.Interface)] IMetaDataAssemblyEmit pAssemEmit,
            [MarshalAs(UnmanagedType.Interface)] IMetaDataEmit emit,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 9)] byte[] pvTranslatedSig,
            uint cbTranslatedSigMax,
            out uint pcbTranslatedSig);*/
            return Raw.TranslateSigWithScope(pAssemImport, pbHashValue, cbHashValue, import, pbSigBlob, cbSigBlob, pAssemEmit, emit, pvTranslatedSig, cbTranslatedSigMax, out pcbTranslatedSig);
        }

        #endregion
        #region SetMethodImplFlags

        public void SetMethodImplFlags(uint md, uint dwImplFlags)
        {
            HRESULT hr;

            if ((hr = TrySetMethodImplFlags(md, dwImplFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetMethodImplFlags(uint md, uint dwImplFlags)
        {
            /*HRESULT SetMethodImplFlags(
            uint md,
            uint dwImplFlags);*/
            return Raw.SetMethodImplFlags(md, dwImplFlags);
        }

        #endregion
        #region SetFieldRVA

        public void SetFieldRVA(uint fd, uint ulRVA)
        {
            HRESULT hr;

            if ((hr = TrySetFieldRVA(fd, ulRVA)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetFieldRVA(uint fd, uint ulRVA)
        {
            /*HRESULT SetFieldRVA(
            uint fd,
            uint ulRVA);*/
            return Raw.SetFieldRVA(fd, ulRVA);
        }

        #endregion
        #region Merge

        public void Merge(IMetaDataImport pImport, IMapToken pHostMapToken, object pHandler)
        {
            HRESULT hr;

            if ((hr = TryMerge(pImport, pHostMapToken, pHandler)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryMerge(IMetaDataImport pImport, IMapToken pHostMapToken, object pHandler)
        {
            /*HRESULT Merge(
            [MarshalAs(UnmanagedType.Interface)] IMetaDataImport pImport,
            [MarshalAs(UnmanagedType.Interface)] IMapToken pHostMapToken,
            [MarshalAs(UnmanagedType.IUnknown)] object pHandler);*/
            return Raw.Merge(pImport, pHostMapToken, pHandler);
        }

        #endregion
        #region MergeEnd

        public void MergeEnd()
        {
            HRESULT hr;

            if ((hr = TryMergeEnd()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryMergeEnd()
        {
            /*HRESULT MergeEnd();*/
            return Raw.MergeEnd();
        }

        #endregion
        #endregion
        #region IMetaDataEmit2

        public IMetaDataEmit2 Raw2 => (IMetaDataEmit2) Raw;

        #region DefineMethodSpec

        public uint DefineMethodSpec(mdToken tkParent, byte[] pvSigBlob, uint cbSigBlob)
        {
            HRESULT hr;
            uint pmi;

            if ((hr = TryDefineMethodSpec(tkParent, pvSigBlob, cbSigBlob, out pmi)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pmi;
        }

        public HRESULT TryDefineMethodSpec(mdToken tkParent, byte[] pvSigBlob, uint cbSigBlob, out uint pmi)
        {
            /*HRESULT DefineMethodSpec(mdToken tkParent, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
            byte[] pvSigBlob, uint cbSigBlob, out uint pmi);*/
            return Raw2.DefineMethodSpec(tkParent, pvSigBlob, cbSigBlob, out pmi);
        }

        #endregion
        #region GetDeltaSaveSize

        public uint GetDeltaSaveSize(CorSaveSize fSave)
        {
            HRESULT hr;
            uint pdwSaveSize;

            if ((hr = TryGetDeltaSaveSize(fSave, out pdwSaveSize)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pdwSaveSize;
        }

        public HRESULT TryGetDeltaSaveSize(CorSaveSize fSave, out uint pdwSaveSize)
        {
            /*HRESULT GetDeltaSaveSize(CorSaveSize fSave, out uint pdwSaveSize);*/
            return Raw2.GetDeltaSaveSize(fSave, out pdwSaveSize);
        }

        #endregion
        #region SaveDelta

        public void SaveDelta(string szFile, uint dwSaveFlags)
        {
            HRESULT hr;

            if ((hr = TrySaveDelta(szFile, dwSaveFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySaveDelta(string szFile, uint dwSaveFlags)
        {
            /*HRESULT SaveDelta([MarshalAs(UnmanagedType.LPWStr)] string szFile, uint dwSaveFlags);*/
            return Raw2.SaveDelta(szFile, dwSaveFlags);
        }

        #endregion
        #region SaveDeltaToStream

        public void SaveDeltaToStream(object pIStream, uint dwSaveFlags)
        {
            HRESULT hr;

            if ((hr = TrySaveDeltaToStream(pIStream, dwSaveFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySaveDeltaToStream(object pIStream, uint dwSaveFlags)
        {
            /*HRESULT SaveDeltaToStream([MarshalAs(UnmanagedType.Interface)] object pIStream, uint dwSaveFlags);*/
            return Raw2.SaveDeltaToStream(pIStream, dwSaveFlags);
        }

        #endregion
        #region SaveDeltaToMemory

        public void SaveDeltaToMemory(IntPtr pbData, uint cbData)
        {
            HRESULT hr;

            if ((hr = TrySaveDeltaToMemory(pbData, cbData)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySaveDeltaToMemory(IntPtr pbData, uint cbData)
        {
            /*HRESULT SaveDeltaToMemory(IntPtr pbData, uint cbData);*/
            return Raw2.SaveDeltaToMemory(pbData, cbData);
        }

        #endregion
        #region DefineGenericParam

        public uint DefineGenericParam(mdToken tk, uint ulParamSeq, uint dwParamFlags, string szname, uint reserved, mdToken[] rtkConstraints)
        {
            HRESULT hr;
            uint pgp;

            if ((hr = TryDefineGenericParam(tk, ulParamSeq, dwParamFlags, szname, reserved, rtkConstraints, out pgp)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pgp;
        }

        public HRESULT TryDefineGenericParam(mdToken tk, uint ulParamSeq, uint dwParamFlags, string szname, uint reserved, mdToken[] rtkConstraints, out uint pgp)
        {
            /*HRESULT DefineGenericParam(
            mdToken tk,
            uint ulParamSeq,
            uint dwParamFlags,
            [MarshalAs(UnmanagedType.LPWStr)] string szname,
            uint reserved,
            [MarshalAs(UnmanagedType.LPArray)] mdToken[] rtkConstraints,
            out uint pgp
        );*/
            return Raw2.DefineGenericParam(tk, ulParamSeq, dwParamFlags, szname, reserved, rtkConstraints, out pgp);
        }

        #endregion
        #region SetGenericParamProps

        public void SetGenericParamProps(uint gp, uint dwParamFlags, string szName, uint reserved, mdToken[] rtkConstraints)
        {
            HRESULT hr;

            if ((hr = TrySetGenericParamProps(gp, dwParamFlags, szName, reserved, rtkConstraints)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetGenericParamProps(uint gp, uint dwParamFlags, string szName, uint reserved, mdToken[] rtkConstraints)
        {
            /*HRESULT SetGenericParamProps(
            uint gp,
            uint dwParamFlags,
            [MarshalAs(UnmanagedType.LPWStr)] string szName,
            uint reserved,
            [MarshalAs(UnmanagedType.LPArray)] mdToken[] rtkConstraints
        );*/
            return Raw2.SetGenericParamProps(gp, dwParamFlags, szName, reserved, rtkConstraints);
        }

        #endregion
        #region ResetENCLog

        public void ResetENCLog()
        {
            HRESULT hr;

            if ((hr = TryResetENCLog()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryResetENCLog()
        {
            /*HRESULT ResetENCLog();*/
            return Raw2.ResetENCLog();
        }

        #endregion
        #endregion
    }
}