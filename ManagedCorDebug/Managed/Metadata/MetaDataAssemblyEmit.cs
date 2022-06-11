using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class MetaDataAssemblyEmit : ComObject<IMetaDataAssemblyEmit>
    {
        public MetaDataAssemblyEmit(IMetaDataAssemblyEmit raw) : base(raw)
        {
        }

        #region IMetaDataAssemblyEmit
        #region DefineAssembly

        public int DefineAssembly(byte[] pbPublicKey, uint cbPublicKey, uint ulHashAlgId, string szName, IntPtr pMetaData, CorAssemblyFlags dwAssemblyFlags)
        {
            HRESULT hr;
            int pma;

            if ((hr = TryDefineAssembly(pbPublicKey, cbPublicKey, ulHashAlgId, szName, pMetaData, dwAssemblyFlags, out pma)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pma;
        }

        public HRESULT TryDefineAssembly(byte[] pbPublicKey, uint cbPublicKey, uint ulHashAlgId, string szName, IntPtr pMetaData, CorAssemblyFlags dwAssemblyFlags, out int pma)
        {
            /*HRESULT DefineAssembly(
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pbPublicKey,
            uint cbPublicKey,
            uint ulHashAlgId,
            [MarshalAs(UnmanagedType.LPWStr)] string szName,
            IntPtr pMetaData,
            CorAssemblyFlags dwAssemblyFlags,
            out int pma);*/
            return Raw.DefineAssembly(pbPublicKey, cbPublicKey, ulHashAlgId, szName, pMetaData, dwAssemblyFlags, out pma);
        }

        #endregion
        #region DefineAssemblyRef

        public uint DefineAssemblyRef(byte[] pbPublicKeyOrToken, uint cbPublicKeyOrToken, string szName, ASSEMBLYMETADATA pMetaData, byte[] pbHashValue, uint cbHashValue, CorAssemblyFlags dwAssemblyRefFlags)
        {
            HRESULT hr;
            uint assemblyRefToken;

            if ((hr = TryDefineAssemblyRef(pbPublicKeyOrToken, cbPublicKeyOrToken, szName, pMetaData, pbHashValue, cbHashValue, dwAssemblyRefFlags, out assemblyRefToken)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return assemblyRefToken;
        }

        public HRESULT TryDefineAssemblyRef(byte[] pbPublicKeyOrToken, uint cbPublicKeyOrToken, string szName, ASSEMBLYMETADATA pMetaData, byte[] pbHashValue, uint cbHashValue, CorAssemblyFlags dwAssemblyRefFlags, out uint assemblyRefToken)
        {
            /*HRESULT DefineAssemblyRef(
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pbPublicKeyOrToken,
            uint cbPublicKeyOrToken,
            [MarshalAs(UnmanagedType.LPWStr)] string szName,
            [In] ASSEMBLYMETADATA pMetaData,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] pbHashValue,
            uint cbHashValue,
            CorAssemblyFlags dwAssemblyRefFlags,
            out uint assemblyRefToken);*/
            return Raw.DefineAssemblyRef(pbPublicKeyOrToken, cbPublicKeyOrToken, szName, pMetaData, pbHashValue, cbHashValue, dwAssemblyRefFlags, out assemblyRefToken);
        }

        #endregion
        #region DefineFile

        public uint DefineFile(string szName, byte[] pbHashValue, uint cbHashValue, uint dwFileFlags)
        {
            HRESULT hr;
            uint fileToken;

            if ((hr = TryDefineFile(szName, pbHashValue, cbHashValue, dwFileFlags, out fileToken)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return fileToken;
        }

        public HRESULT TryDefineFile(string szName, byte[] pbHashValue, uint cbHashValue, uint dwFileFlags, out uint fileToken)
        {
            /*HRESULT DefineFile(
            [MarshalAs(UnmanagedType.LPWStr)] string szName,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pbHashValue,
            uint cbHashValue,
            uint dwFileFlags,
            out uint fileToken);*/
            return Raw.DefineFile(szName, pbHashValue, cbHashValue, dwFileFlags, out fileToken);
        }

        #endregion
        #region DefineExportedType

        public uint DefineExportedType(string szName, mdToken tkImplementation, mdTypeDef tkTypeDef, uint dwExportedTypeFlags)
        {
            HRESULT hr;
            uint pmdct;

            if ((hr = TryDefineExportedType(szName, tkImplementation, tkTypeDef, dwExportedTypeFlags, out pmdct)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pmdct;
        }

        public HRESULT TryDefineExportedType(string szName, mdToken tkImplementation, mdTypeDef tkTypeDef, uint dwExportedTypeFlags, out uint pmdct)
        {
            /*HRESULT DefineExportedType(
            [MarshalAs(UnmanagedType.LPWStr)] string szName,
            mdToken tkImplementation,
            mdTypeDef tkTypeDef,
            uint dwExportedTypeFlags,
            out uint pmdct);*/
            return Raw.DefineExportedType(szName, tkImplementation, tkTypeDef, dwExportedTypeFlags, out pmdct);
        }

        #endregion
        #region DefineManifestResource

        public uint DefineManifestResource(string szName, mdToken tkImplementation, uint dwOffset, uint dwResourceFlags)
        {
            HRESULT hr;
            uint pmdmr;

            if ((hr = TryDefineManifestResource(szName, tkImplementation, dwOffset, dwResourceFlags, out pmdmr)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pmdmr;
        }

        public HRESULT TryDefineManifestResource(string szName, mdToken tkImplementation, uint dwOffset, uint dwResourceFlags, out uint pmdmr)
        {
            /*HRESULT DefineManifestResource(
            [MarshalAs(UnmanagedType.LPWStr)] string szName,
            mdToken tkImplementation,
            uint dwOffset,
            uint dwResourceFlags,
            out uint pmdmr);*/
            return Raw.DefineManifestResource(szName, tkImplementation, dwOffset, dwResourceFlags, out pmdmr);
        }

        #endregion
        #region SetAssemblyProps

        public void SetAssemblyProps(uint pma, byte[] pbPublicKey, uint cbPublicKey, uint ulHashAlgId, string szName, IntPtr pMetaData, uint dwAssemblyFlags)
        {
            HRESULT hr;

            if ((hr = TrySetAssemblyProps(pma, pbPublicKey, cbPublicKey, ulHashAlgId, szName, pMetaData, dwAssemblyFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetAssemblyProps(uint pma, byte[] pbPublicKey, uint cbPublicKey, uint ulHashAlgId, string szName, IntPtr pMetaData, uint dwAssemblyFlags)
        {
            /*HRESULT SetAssemblyProps(uint pma,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pbPublicKey,
            uint cbPublicKey,
            uint ulHashAlgId,
            [MarshalAs(UnmanagedType.LPWStr)] string szName,
            IntPtr pMetaData,
            uint dwAssemblyFlags);*/
            return Raw.SetAssemblyProps(pma, pbPublicKey, cbPublicKey, ulHashAlgId, szName, pMetaData, dwAssemblyFlags);
        }

        #endregion
        #region SetAssemblyRefProps

        public void SetAssemblyRefProps(uint ar, byte[] pbPublicKeyOrToken, uint cbPublicKeyOrToken, string szName, IntPtr pMetaData, byte[] pbHashValue, uint cbHashValue, AssemblyRefFlags dwAssemblyRefFlags)
        {
            HRESULT hr;

            if ((hr = TrySetAssemblyRefProps(ar, pbPublicKeyOrToken, cbPublicKeyOrToken, szName, pMetaData, pbHashValue, cbHashValue, dwAssemblyRefFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetAssemblyRefProps(uint ar, byte[] pbPublicKeyOrToken, uint cbPublicKeyOrToken, string szName, IntPtr pMetaData, byte[] pbHashValue, uint cbHashValue, AssemblyRefFlags dwAssemblyRefFlags)
        {
            /*HRESULT SetAssemblyRefProps(
            uint ar,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)]
            byte[] pbPublicKeyOrToken, uint cbPublicKeyOrToken, [MarshalAs(UnmanagedType.LPWStr)] string szName, IntPtr pMetaData,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)]
            byte[] pbHashValue,
            uint cbHashValue,
            AssemblyRefFlags dwAssemblyRefFlags);*/
            return Raw.SetAssemblyRefProps(ar, pbPublicKeyOrToken, cbPublicKeyOrToken, szName, pMetaData, pbHashValue, cbHashValue, dwAssemblyRefFlags);
        }

        #endregion
        #region SetFileProps

        public void SetFileProps(uint file, byte[] pbHashValue, uint cbHashValue, uint dwFileFlags)
        {
            HRESULT hr;

            if ((hr = TrySetFileProps(file, pbHashValue, cbHashValue, dwFileFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetFileProps(uint file, byte[] pbHashValue, uint cbHashValue, uint dwFileFlags)
        {
            /*HRESULT SetFileProps(
            uint file,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pbHashValue,
            uint cbHashValue,
            uint dwFileFlags);*/
            return Raw.SetFileProps(file, pbHashValue, cbHashValue, dwFileFlags);
        }

        #endregion
        #region SetExportedTypeProps

        public void SetExportedTypeProps(uint ct, mdToken tkImplementation, mdTypeDef tkTypeDef, uint dwExportedTypeFlags)
        {
            HRESULT hr;

            if ((hr = TrySetExportedTypeProps(ct, tkImplementation, tkTypeDef, dwExportedTypeFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetExportedTypeProps(uint ct, mdToken tkImplementation, mdTypeDef tkTypeDef, uint dwExportedTypeFlags)
        {
            /*HRESULT SetExportedTypeProps(
            uint ct,
            mdToken tkImplementation,
            mdTypeDef tkTypeDef,
            uint dwExportedTypeFlags);*/
            return Raw.SetExportedTypeProps(ct, tkImplementation, tkTypeDef, dwExportedTypeFlags);
        }

        #endregion
        #region SetManifestResourceProps

        public void SetManifestResourceProps(uint mr, mdToken tkImplementation, uint dwOffset, uint dwResourceFlags)
        {
            HRESULT hr;

            if ((hr = TrySetManifestResourceProps(mr, tkImplementation, dwOffset, dwResourceFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetManifestResourceProps(uint mr, mdToken tkImplementation, uint dwOffset, uint dwResourceFlags)
        {
            /*HRESULT SetManifestResourceProps(
            uint mr,
            mdToken tkImplementation,
            uint dwOffset,
            uint dwResourceFlags);*/
            return Raw.SetManifestResourceProps(mr, tkImplementation, dwOffset, dwResourceFlags);
        }

        #endregion
        #endregion
    }
}