using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// Provides access to type information within a <see cref="DBI1"/>.
    /// </summary>
    public unsafe class TPI1 : IDisposable
    {
        public IntPtr Raw { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private TPI1Vtbl* vtbl;

        #region QueryInterfaceVersion

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate PDBINTV QueryInterfaceVersionDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        QueryInterfaceVersionDelegate queryInterfaceVersion;

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
        delegate DBIImpv QueryImplementationVersionDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        QueryImplementationVersionDelegate queryImplementationVersion;

        public DBIImpv ImplementationVersion
        {
            get
            {
                InitDelegate(ref queryImplementationVersion, vtbl->QueryImplementationVersion);

                return queryImplementationVersion(Raw);
            }
        }

        #endregion
        #region QueryTi16ForCVRecord

        //virtual BOOL QueryTi16ForCVRecord(BYTE* pb, OUT TI16* pti) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QueryTi16ForCVRecordDelegate(
            [In] IntPtr @this,
            [In] TYPTYPE* pb,
            [Out] out CV_typ16_t pti);

        private QueryTi16ForCVRecordDelegate queryTi16ForCVRecord;

        public CV_typ16_t QueryTi16ForCVRecord(TYPTYPE* pb)
        {
            if (!queryTi16ForCVRecord(Raw, pb, out var pti))
                throw PDB1.GetUnknownError(MethodBase.GetCurrentMethod());

            return pti;
        }

        public bool TryQueryTi16ForCVRecord(TYPTYPE* pb, out CV_typ16_t pti)
        {
            InitDelegate(ref queryTi16ForCVRecord, vtbl->QueryTi16ForCVRecord);

            return queryTi16ForCVRecord(Raw, pb, out pti);
        }

        #endregion
        #region QueryCVRecordForTi16

        //virtual BOOL QueryCVRecordForTi16(TI16 ti, OUT BYTE* pb, IN OUT long* pcb) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryCVRecordForTi16Delegate(
        //    [In] IntPtr @this);

        //private QueryCVRecordForTi16Delegate queryCVRecordForTi16;

        //public bar QueryCVRecordForTi16()
        //{
        //    InitDelegate(ref queryCVRecordForTi16, vtbl->QueryCVRecordForTi16);

        //    if (!queryCVRecordForTi16(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryPbCVRecordForTi16

        //virtual BOOL QueryPbCVRecordForTi16(TI16 ti, OUT BYTE** ppb) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryPbCVRecordForTi16Delegate(
        //    [In] IntPtr @this);

        //private QueryPbCVRecordForTi16Delegate queryPbCVRecordForTi16;

        //public bar QueryPbCVRecordForTi16()
        //{
        //    InitDelegate(ref queryPbCVRecordForTi16, vtbl->QueryPbCVRecordForTi16);

        //    if (!queryPbCVRecordForTi16(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryTi16Min

        //virtual TI16 QueryTi16Min() pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryTi16MinDelegate(
        //    [In] IntPtr @this);

        //private QueryTi16MinDelegate queryTi16Min;

        //public bar QueryTi16Min()
        //{
        //    InitDelegate(ref queryTi16Min, vtbl->QueryTi16Min);

        //    if (!queryTi16Min(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryTi16Mac

        //virtual TI16 QueryTi16Mac() pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryTi16MacDelegate(
        //    [In] IntPtr @this);

        //private QueryTi16MacDelegate queryTi16Mac;

        //public bar QueryTi16Mac()
        //{
        //    InitDelegate(ref queryTi16Mac, vtbl->QueryTi16Mac);

        //    if (!queryTi16Mac(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryCb

        //virtual long QueryCb() pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryCbDelegate(
        //    [In] IntPtr @this);

        //private QueryCbDelegate queryCb;

        //public bar QueryCb()
        //{
        //    InitDelegate(ref queryCb, vtbl->QueryCb);

        //    if (!queryCb(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region Close

        //virtual BOOL Close() pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool CloseDelegate(
            [In] IntPtr @this);

        private CloseDelegate close;

        public void Close()
        {
            InitDelegate(ref close, vtbl->Close);

            if (!close(Raw))
                throw PDB1.GetUnknownError(MethodBase.GetCurrentMethod());
        }

        #endregion
        #region Commit

        //virtual BOOL Commit() pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool CommitDelegate(
        //    [In] IntPtr @this);

        //private CommitDelegate commit;

        //public bar Commit()
        //{
        //    InitDelegate(ref commit, vtbl->Commit);

        //    if (!commit(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryTi16ForUDT

        //virtual BOOL QueryTi16ForUDT(_In_z_ const char *sz, BOOL fCase, OUT TI16* pti) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryTi16ForUDTDelegate(
        //    [In] IntPtr @this);

        //private QueryTi16ForUDTDelegate queryTi16ForUDT;

        //public bar QueryTi16ForUDT()
        //{
        //    InitDelegate(ref queryTi16ForUDT, vtbl->QueryTi16ForUDT);

        //    if (!queryTi16ForUDT(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region SupportQueryTiForUDT

        //virtual BOOL SupportQueryTiForUDT() pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool SupportQueryTiForUDTDelegate(
        //    [In] IntPtr @this);

        //private SupportQueryTiForUDTDelegate supportQueryTiForUDT;

        //public bar SupportQueryTiForUDT()
        //{
        //    InitDelegate(ref supportQueryTiForUDT, vtbl->SupportQueryTiForUDT);

        //    if (!supportQueryTiForUDT(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region fIs16bitTypePool

        //virtual BOOL fIs16bitTypePool() pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool fIs16bitTypePoolDelegate(
        //    [In] IntPtr @this);

        //private fIs16bitTypePoolDelegate fis16bitTypePool;

        //public bar fIs16bitTypePool()
        //{
        //    InitDelegate(ref fis16bitTypePool, vtbl->fIs16bitTypePool);

        //    if (!fis16bitTypePool(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryTiForUDT

        //virtual BOOL QueryTiForUDT(_In_z_ const char *sz, BOOL fCase, OUT TI* pti) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QueryTiForUDTDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.LPStr)] string sz,
            [In] bool fCase,
            [Out] CV_typ_t* pti);

        private QueryTiForUDTDelegate queryTiForUDT;

        public bool TryQueryTiForUDT(string sz, bool fCase, CV_typ_t* pti)
        {
            InitDelegate(ref queryTiForUDT, vtbl->QueryTiForUDT);

            return queryTiForUDT(Raw, sz, fCase, pti);
        }

        #endregion
        #region QueryTiForCVRecord

        //virtual BOOL QueryTiForCVRecord(BYTE* pb, OUT TI* pti) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QueryTiForCVRecordDelegate(
            [In] IntPtr @this,
            [In] TYPTYPE* pb,
            [Out] out CV_typ_t pti);

        private QueryTiForCVRecordDelegate queryTiForCVRecord;

        public CV_typ_t QueryTiForCVRecord(TYPTYPE* pb)
        {
            if (!TryQueryTiForCVRecord(pb, out var pti))
                throw PDB1.GetUnknownError(MethodBase.GetCurrentMethod());

            return pti;
        }

        public bool TryQueryTiForCVRecord(TYPTYPE* pb, out CV_typ_t pti)
        {
            InitDelegate(ref queryTiForCVRecord, vtbl->QueryTiForCVRecord);

            return queryTiForCVRecord(Raw, pb, out pti);
        }

        #endregion
        #region QueryCVRecordForTi

        //virtual BOOL QueryCVRecordForTi(TI ti, OUT BYTE* pb, IN OUT long* pcb) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryCVRecordForTiDelegate(
        //    [In] IntPtr @this);

        //private QueryCVRecordForTiDelegate queryCVRecordForTi;

        //public bar QueryCVRecordForTi()
        //{
        //    InitDelegate(ref queryCVRecordForTi, vtbl->QueryCVRecordForTi);

        //    if (!queryCVRecordForTi(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryPbCVRecordForTi

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QueryPbCVRecordForTiDelegate(
            [In] IntPtr @this,
            [In] CV_typ_t ti,
            [Out] out TYPTYPE* ppb);

        private QueryPbCVRecordForTiDelegate queryPbCVRecordForTi;

        public TYPTYPE* QueryPbCVRecordForTi(CV_typ_t ti)
        {
            InitDelegate(ref queryPbCVRecordForTi, vtbl->QueryPbCVRecordForTi);

            if (!queryPbCVRecordForTi(Raw, ti, out var ppb))
                throw PDB1.GetUnknownError(MethodBase.GetCurrentMethod());

            return ppb;
        }

        #endregion
        #region QueryTiMin

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate CV_typ_t QueryTiMinDelegate(
            [In] IntPtr @this);

        private QueryTiMinDelegate queryTiMin;

        public CV_typ_t TiMin
        {
            get
            {
                InitDelegate(ref queryTiMin, vtbl->QueryTiMin);

                return queryTiMin(Raw);
            }
        }

        #endregion
        #region QueryTiMac

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate CV_typ_t QueryTiMacDelegate(
            [In] IntPtr @this);

        private QueryTiMacDelegate queryTiMac;

        public CV_typ_t TiMac
        {
            get
            {
                InitDelegate(ref queryTiMac, vtbl->QueryTiMac);

                return queryTiMac(Raw);
            }
        }

        #endregion
        #region AreTypesEqual

        //virtual BOOL AreTypesEqual( TI ti1, TI ti2 ) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool AreTypesEqualDelegate(
        //    [In] IntPtr @this);

        //private AreTypesEqualDelegate areTypesEqual;

        //public bar AreTypesEqual()
        //{
        //    InitDelegate(ref areTypesEqual, vtbl->AreTypesEqual);

        //    if (!areTypesEqual(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region IsTypeServed

        //virtual BOOL IsTypeServed( TI ti ) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool IsTypeServedDelegate(
        //    [In] IntPtr @this);

        //private IsTypeServedDelegate isTypeServed;

        //public bar IsTypeServed()
        //{
        //    InitDelegate(ref isTypeServed, vtbl->IsTypeServed);

        //    if (!isTypeServed(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryTiForUDTW

        //virtual BOOL QueryTiForUDTW(_In_z_ const wchar_t *wcs, BOOL fCase, OUT TI* pti) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryTiForUDTWDelegate(
        //    [In] IntPtr @this);

        //private QueryTiForUDTWDelegate queryTiForUDTW;

        //public bar QueryTiForUDTW()
        //{
        //    InitDelegate(ref queryTiForUDTW, vtbl->QueryTiForUDTW);

        //    if (!queryTiForUDTW(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryModSrcLineForUDTDefn

        //virtual BOOL QueryModSrcLineForUDTDefn(const TI tiUdt, USHORT *pimod, OUT NI* psrcId, OUT DWORD* pline) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryModSrcLineForUDTDefnDelegate(
        //    [In] IntPtr @this);

        //private QueryModSrcLineForUDTDefnDelegate queryModSrcLineForUDTDefn;

        //public bar QueryModSrcLineForUDTDefn()
        //{
        //    InitDelegate(ref queryModSrcLineForUDTDefn, vtbl->QueryModSrcLineForUDTDefn);

        //    if (!queryModSrcLineForUDTDefn(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryTIsForCVRecords

        //TPI1::QueryTIsForCVRecords(uchar *,int,int,int,int *)

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryTIsForCVRecordsDelegate(
        //    [In] IntPtr @this);

        //private QueryTIsForCVRecordsDelegate queryTIsForCVRecords;

        //public bar QueryTIsForCVRecords()
        //{
        //    InitDelegate(ref queryTIsForCVRecords, vtbl->QueryTIsForCVRecords);

        //    if (!queryTIsForCVRecords(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion

        public TPI1(IntPtr raw)
        {
            if (raw == IntPtr.Zero)
                throw new ArgumentNullException(nameof(raw));

            Raw = raw;
            vtbl = *(TPI1Vtbl**) raw;
        }

        public void Dispose()
        {
            Close();
        }
    }
}
