using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    //https://github.com/microsoft/microsoft-pdb/blob/805655a28bd8198004be2ac27e6e0290121a5e89/langapi/include/pdb.h#L355

    //Note: some structures in the PDB1 API are misaligned, containing a short field immediately followed by an int. Normally this would
    //cause padding to be added which would cause our structs to misalign with the native data; to rectify this, all PDB1 structs are
    //set to use Pack = 2. In the event we discover something _really_ wacky, we may need to even change this to Pack = 1

    [UnmanagedFunctionPointer(CallingConvention.Winapi)]
    public delegate bool PfnFindDebugInfoFile(IntPtr pSearchDebugInfo);

    /// <summary>
    /// Represents a Program Database.
    /// </summary>
    public unsafe class PDB1
    {
        internal const byte CV_OFFSET_PARENT_LENGTH_LIMIT = 12;

        internal const int PDB_MAX_PATH = 260;
        private const int cbErrMax = 1024;

        public IntPtr Raw { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private PDB1Vtbl* vtbl;

        #region QueryInterfaceVersion

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate PDBINTV QueryInterfaceVersionDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryInterfaceVersionDelegate queryInterfaceVersion;

        //Seems to relate to the PDB itself, not the PDB1 interface that reads it
        public PDBINTV InterfaceVersion
        {
            get
            {
                InitDelegate(ref queryInterfaceVersion, vtbl->QueryInterfaceVersion);

                return queryInterfaceVersion(Raw);
            }
        }

        #endregion
        #region QueryImplementationVersion

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate PDBIMPV QueryImplementationVersionDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryImplementationVersionDelegate queryImplementationVersion;

        public PDBIMPV ImplementationVersion
        {
            get
            {
                InitDelegate(ref queryImplementationVersion, vtbl->QueryImplementationVersion);

                return queryImplementationVersion(Raw);
            }
        }

        #endregion
        #region QueryLastError

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate EC QueryLastErrorDelegate(
            [In] IntPtr @this,
            [Out, MarshalAs(UnmanagedType.LPArray)] byte[] szError);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryLastErrorDelegate queryLastError;

        public PDB1_QueryLastErrorResult LastError
        {
            get
            {
                InitDelegate(ref queryLastError, vtbl->QueryLastError);

                var bytes = new byte[cbErrMax];

                var err = queryLastError(Raw, bytes);

                var str = CreateString(bytes);

                return new PDB1_QueryLastErrorResult(err, str);
            }
        }

        #endregion
        #region QueryPDBName

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate IntPtr QueryPDBNameDelegate(
            [In] IntPtr @this,
            [Out, MarshalAs(UnmanagedType.LPArray)] byte[] szPDB); //Return value is just the input buffer

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryPDBNameDelegate queryPDBName;

        //For Portable PDBs, this may just be the parent folder
        public string PDBName
        {
            get
            {
                InitDelegate(ref queryPDBName, vtbl->QueryPDBName);

                var szPDB = new byte[PDB_MAX_PATH];
                queryPDBName(Raw, szPDB);
                return CreateString(szPDB);
            }
        }

        #endregion
        #region QuerySignature

        //virtual SIG  QuerySignature() pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate int QuerySignatureDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QuerySignatureDelegate querySignature;

        public int Signature
        {
            get
            {
                InitDelegate(ref querySignature, vtbl->QuerySignature);

                return querySignature(Raw);
            }
        }

        #endregion
        #region QueryAge

        //virtual AGE  QueryAge() pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate int QueryAgeDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryAgeDelegate queryAge;

        public int Age
        {
            get
            {
                InitDelegate(ref queryAge, vtbl->QueryAge);

                return queryAge(Raw);
            }
        }

        #endregion
        #region CreateDBI

        //virtual BOOL CreateDBI(_In_z_ const char* szTarget, OUT DBI** ppdbi) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool CreateDBIDelegate(
        //    [In] IntPtr @this);

        //private CreateDBIDelegate createDBI;

        //public bar CreateDBI()
        //{
        //    InitDelegate(ref createDBI, vtbl->CreateDBI);

        //    if (!createDBI(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region OpenDBI

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool OpenDBIDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.LPStr)] string szTarget,
            [In, MarshalAs(UnmanagedType.LPStr)] string szMode,
            [Out] out IntPtr ppdbi);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OpenDBIDelegate openDBI;

        public DBI1 OpenDBI(string szTarget, string szMode)
        {
            InitDelegate(ref openDBI, vtbl->OpenDBI);

            if (!openDBI(Raw, szTarget, szMode, out var ppdbi))
                throw GetUnknownError(MethodBase.GetCurrentMethod());

            return new DBI1(ppdbi);
        }

        #endregion
        #region OpenTpi

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool OpenTpiDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.LPStr)] string szMode,
            [Out] out IntPtr pptpi);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OpenTpiDelegate openTpi;

        public TPI1 OpenTpi(string szMode)
        {
            InitDelegate(ref openTpi, vtbl->OpenTpi);

            if (!openTpi(Raw, szMode, out var pptpi))
                throw GetUnknownError(MethodBase.GetCurrentMethod());

            return new TPI1(pptpi);
        }

        #endregion
        #region OpenIpi

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool OpenIpiDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.LPStr)] string szMode,
            [Out] out IntPtr pptpi);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OpenIpiDelegate openIpi;

        public TPI1 OpenIpi(string szMode)
        {
            InitDelegate(ref openIpi, vtbl->OpenIpi);

            if (!openIpi(Raw, szMode, out var pptpi))
                throw GetUnknownError(MethodBase.GetCurrentMethod());

            return new TPI1(pptpi);
        }

        #endregion
        #region Commit

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool CommitDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CommitDelegate commit;

        public void Commit()
        {
            InitDelegate(ref commit, vtbl->Commit);

            if (!commit(Raw))
                throw GetUnknownError(MethodBase.GetCurrentMethod());
        }

        #endregion
        #region Close

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool CloseDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CloseDelegate close;

        public void Close()
        {
            InitDelegate(ref close, vtbl->Close);

            if (!close(Raw))
                throw GetUnknownError(MethodBase.GetCurrentMethod());
        }

        #endregion
        #region OpenStream

        //virtual BOOL OpenStream(_In_z_ const char* szStream, OUT Stream** ppstream) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool OpenStreamDelegate(
        //    [In] IntPtr @this);

        //private OpenStreamDelegate openStream;

        //public bar OpenStream()
        //{
        //    InitDelegate(ref openStream, vtbl->OpenStream);

        //    if (!openStream(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region GetEnumStreamNameMap

        //virtual BOOL GetEnumStreamNameMap(OUT Enum** ppenum) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool GetEnumStreamNameMapDelegate(
        //    [In] IntPtr @this);

        //private GetEnumStreamNameMapDelegate getEnumStreamNameMap;

        //public bar GetEnumStreamNameMap()
        //{
        //    InitDelegate(ref getEnumStreamNameMap, vtbl->GetEnumStreamNameMap);

        //    if (!getEnumStreamNameMap(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region GetRawBytes

        //virtual BOOL GetRawBytes(PFNfReadPDBRawBytes pfnfSnarfRawBytes) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool GetRawBytesDelegate(
        //    [In] IntPtr @this);

        //private GetRawBytesDelegate getRawBytes;

        //public bar GetRawBytes()
        //{
        //    InitDelegate(ref getRawBytes, vtbl->GetRawBytes);

        //    if (!getRawBytes(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryPdbImplementationVersion

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate PDBIMPV QueryPdbImplementationVersionDelegate(
            [In] IntPtr @this);

        QueryPdbImplementationVersionDelegate queryPdbImplementationVersion;

        public PDBIMPV PdbImplementationVersion
        {
            get
            {
                InitDelegate(ref queryPdbImplementationVersion, vtbl->QueryPdbImplementationVersion);

                return queryPdbImplementationVersion(Raw);
            }
        }

        #endregion
        #region OpenDBIEx

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool OpenDBIExDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.LPStr)] string szTarget,
            [In, MarshalAs(UnmanagedType.LPStr)] string szMode,
            [Out] out IntPtr ppdbi,
            [In, MarshalAs(UnmanagedType.FunctionPtr), Optional] PfnFindDebugInfoFile pfn);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OpenDBIExDelegate openDBIEx;

        public bool TryOpenDBIEx(string szTarget, string szMode, PfnFindDebugInfoFile pfn, out DBI1 ppdbi)
        {
            InitDelegate(ref openDBIEx, vtbl->OpenDBIEx);

            //todo: need to cache last pfn so it doesnt gc

            var result = openDBIEx(Raw, szTarget, szMode, out var ppdbiRaw, pfn);

            ppdbi = ppdbiRaw != IntPtr.Zero ? new DBI1(ppdbiRaw) : null;

            return result;
        }

        #endregion
        #region CopyTo

        //virtual BOOL CopyTo( _Pre_notnull_ _Post_z_ const char *szDst, DWORD dwCopyFilter, DWORD dwReserved) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool CopyToDelegate(
        //    [In] IntPtr @this);

        //private CopyToDelegate copyTo;

        //public bar CopyTo()
        //{
        //    InitDelegate(ref copyTo, vtbl->CopyTo);

        //    if (!copyTo(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region OpenSrc

        //virtual BOOL OpenSrc(OUT Src** ppsrc) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool OpenSrcDelegate(
        //    [In] IntPtr @this);

        //private OpenSrcDelegate openSrc;

        //public bar OpenSrc()
        //{
        //    InitDelegate(ref openSrc, vtbl->OpenSrc);

        //    if (!openSrc(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryLastErrorExW

        //virtual EC   QueryLastErrorExW(_Out_opt_cap_(cchMax) OUT wchar_t *wszError, size_t cchMax) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate EC QueryLastErrorExWDelegate(
            [In] IntPtr @this,
            [Out, MarshalAs(UnmanagedType.LPArray)] char[] szError,
            [In] IntPtr cchMax);

        private QueryLastErrorExWDelegate queryLastErrorExW;

        public PDB1_QueryLastErrorResult QueryLastErrorExW()
        {
            InitDelegate(ref queryLastErrorExW, vtbl->QueryLastErrorExW);

            //It's called "cb" but in the case of the new wchar APIs its more like cch
            var chars = new char[cbErrMax];

            var err = queryLastErrorExW(Raw, chars, (IntPtr) cbErrMax);

            var str = CreateString(chars);

            return new PDB1_QueryLastErrorResult(err, str);
        }

        #endregion
        #region QueryPDBNameExW

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate IntPtr QueryPDBNameExWDelegate(
            [In] IntPtr @this,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2)] char[] wszPDB,
            [In] IntPtr cchMax);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryPDBNameExWDelegate queryPDBNameExW;

        //For Portable PDBs, this may just be the parent folder
        public string PDBNameExW
        {
            get
            {
                InitDelegate(ref queryPDBNameExW, vtbl->QueryPDBNameExW);

                var wszPDB = new char[PDB_MAX_PATH];
                queryPDBNameExW(Raw, wszPDB, (IntPtr) PDB_MAX_PATH);
                return CreateString(wszPDB);
            }
        }

        #endregion
        #region QuerySignature2

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QuerySignature2Delegate(
            [In] IntPtr @this,
            [Out] out Guid psig70);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QuerySignature2Delegate querySignature2;

        public Guid Signature2
        {
            get
            {
                InitDelegate(ref querySignature2, vtbl->QuerySignature2);

                //This should always return true
                if (!querySignature2(Raw, out var psig70))
                    throw GetUnknownError(MethodBase.GetCurrentMethod());

                return psig70;
            }
        }

        #endregion
        #region CopyToW

        //virtual BOOL CopyToW( _Pre_notnull_ _Post_z_ const wchar_t *szDst, DWORD dwCopyFilter, DWORD dwReserved) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool CopyToWDelegate(
        //    [In] IntPtr @this);

        //private CopyToWDelegate copyToW;

        //public bar CopyToW()
        //{
        //    InitDelegate(ref copyToW, vtbl->CopyToW);

        //    if (!copyToW(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region fIsSZPDB

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool fIsSZPDBDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private fIsSZPDBDelegate fisSZPDB;

        public bool fIsSZPDB
        {
            get
            {
                InitDelegate(ref fisSZPDB, vtbl->fIsSZPDB);

                return fisSZPDB(Raw);
            }
        }

        #endregion
        #region OpenStreamW

        //virtual BOOL OpenStreamW(_In_z_ const wchar_t * szStream, OUT Stream** ppstream) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool OpenStreamWDelegate(
        //    [In] IntPtr @this);

        //private OpenStreamWDelegate openStreamW;

        //public bar OpenStreamW()
        //{
        //    InitDelegate(ref openStreamW, vtbl->OpenStreamW);

        //    if (!openStreamW(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region CopyToW2

        //virtual BOOL CopyToW2(_In_z_ const wchar_t *  szDst, DWORD dwCopyFilter, PfnPDBCopyQueryCallback pfnCallBack, void *                  pvClientContext) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool CopyToW2Delegate(
        //    [In] IntPtr @this);

        //private CopyToW2Delegate copyToW2;

        //public bar CopyToW2()
        //{
        //    InitDelegate(ref copyToW2, vtbl->CopyToW2);

        //    if (!copyToW2(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region OpenStreamEx

        //virtual BOOL OpenStreamEx(_In_z_ const char * szStream, _In_z_ const char *szMode, Stream **ppStream) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool OpenStreamExDelegate(
        //    [In] IntPtr @this);

        //private OpenStreamExDelegate openStreamEx;

        //public bar OpenStreamEx()
        //{
        //    InitDelegate(ref openStreamEx, vtbl->OpenStreamEx);

        //    if (!openStreamEx(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region RegisterPDBMapping

        //virtual BOOL RegisterPDBMapping(_In_z_ const wchar_t *wszPDBFrom, _In_z_ const wchar_t *wszPDBTo) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool RegisterPDBMappingDelegate(
        //    [In] IntPtr @this);

        //private RegisterPDBMappingDelegate registerPDBMapping;

        //public bar RegisterPDBMapping()
        //{
        //    InitDelegate(ref registerPDBMapping, vtbl->RegisterPDBMapping);

        //    if (!registerPDBMapping(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region EnablePrefetching

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool EnablePrefetchingDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private EnablePrefetchingDelegate enablePrefetching;

        public bool EnablePrefetching()
        {
            InitDelegate(ref enablePrefetching, vtbl->EnablePrefetching);

            return enablePrefetching(Raw);
        }

        #endregion
        #region FLazy

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool FLazyDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private FLazyDelegate fLazy;

        public bool FLazy
        {
            get
            {
                InitDelegate(ref fLazy, vtbl->FLazy);

                return fLazy(Raw);
            }
        }

        #endregion
        #region FMinimal

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool FMinimalDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private FMinimalDelegate fMinimal;

        public bool FMinimal
        {
            get
            {
                InitDelegate(ref fMinimal, vtbl->FLazy);

                return fMinimal(Raw);
            }
        }

        #endregion
        #region ResetGUID

        //virtual BOOL ResetGUID(BYTE *pb, DWORD cb) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool ResetGUIDDelegate(
        //    [In] IntPtr @this);

        //private ResetGUIDDelegate resetGUID;

        //public bar ResetGUID()
        //{
        //    InitDelegate(ref resetGUID, vtbl->ResetGUID);

        //    if (!resetGUID(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region FReleaseGlobalSymbolBuffer

        //bool PDB1::FReleaseGlobalSymbolBuffer(void)

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool FReleaseGlobalSymbolBufferDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private FReleaseGlobalSymbolBufferDelegate fReleaseGlobalSymbolBuffer;

        public void FReleaseGlobalSymbolBuffer()
        {
            InitDelegate(ref fReleaseGlobalSymbolBuffer, vtbl->FReleaseGlobalSymbolBuffer);

            if (!fReleaseGlobalSymbolBuffer(Raw))
                throw GetUnknownError(MethodBase.GetCurrentMethod());
        }

        #endregion
        #region UpdateSignature

        //bool PDB1::UpdateSignature(int,_GUID*,int)

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool UpdateSignatureDelegate(
        //    [In] IntPtr @this);

        //private UpdateSignatureDelegate updateSignature;

        //public bar UpdateSignature()
        //{
        //    InitDelegate(ref updateSignature, vtbl->UpdateSignature);

        //    if (!updateSignature(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region FRepro

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool FReproDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private FReproDelegate fRepro;

        public bool FRepro
        {
            get
            {
                InitDelegate(ref fRepro, vtbl->FRepro);

                return fRepro(Raw);
            }
        }

        #endregion
        #region FPortablePDB

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool FPortablePDBDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private FPortablePDBDelegate fPortablePDB;

        public bool FPortablePDB
        {
            get
            {
                InitDelegate(ref fPortablePDB, vtbl->FPortablePDB);

                return fPortablePDB(Raw);
            }
        }

        #endregion

        public PDB1(IntPtr raw)
        {
            if (raw == IntPtr.Zero)
                throw new ArgumentNullException(nameof(raw));

            Raw = raw;
            vtbl = *(PDB1Vtbl**) raw;
        }

        internal static DebugException GetUnknownError(MethodBase method)
        {
            return new DebugException($"Failed to call {method.DeclaringType.Name}.{method.Name}. Extended error information may or may not be available in {nameof(PDB1)}.{nameof(LastError)}", HRESULT.E_FAIL);
        }
    }
}
