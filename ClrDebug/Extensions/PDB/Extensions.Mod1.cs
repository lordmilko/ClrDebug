using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using ClrDebug.DIA;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// Represents a module within the DBI.
    /// </summary>
    public unsafe class Mod1 : IDisposable
    {
        public IntPtr Raw { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Mod1Vtbl* vtbl;

        #region QueryInterfaceVersion

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate PDBINTV QueryInterfaceVersionDelegate(
            [In] IntPtr @this);

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
        #region AddTypes

        //virtual BOOL AddTypes(BYTE* pbTypes, int cb) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool AddTypesDelegate(
            [In] IntPtr @this,
            [In] IntPtr pbTypes,
            [In] int cb);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AddTypesDelegate addTypes;

        public void AddTypes(IntPtr pbTypes, int cb)
        {
            InitDelegate(ref addTypes, vtbl->AddTypes);

            if (!addTypes(Raw, pbTypes, cb))
                throw new NotImplementedException();
        }

        #endregion
        #region AddSymbols

        //virtual BOOL AddSymbols(BYTE* pbSym, int cb) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool AddSymbolsDelegate(
            [In] IntPtr @this,
            [In] IntPtr pbSym,
            [In] int cb);

        private AddSymbolsDelegate addSymbols;

        public void AddSymbols(IntPtr pbSym, int cb)
        {
            InitDelegate(ref addSymbols, vtbl->AddSymbols);

            if (!addSymbols(Raw, pbSym, cb))
                throw new NotImplementedException();
        }

        #endregion
        #region AddPublic

        //virtual BOOL AddPublic(_In_z_ const char* szPublic, USHORT isect, int off) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool AddPublicDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.LPStr)] string szPublic,
            [In] ushort isect,
            [In] int off);

        private AddPublicDelegate addPublic;

        public void AddPublic(string szPublic, ushort isect, int off)
        {
            InitDelegate(ref addPublic, vtbl->AddPublic);

            if (!addPublic(Raw, szPublic, isect, off))
                throw new NotImplementedException();
        }

        #endregion
        #region AddLines

        //virtual BOOL AddLines(_In_z_ const char* szSrc, USHORT isect, int offCon, int cbCon, int doff, USHORT lineStart, BYTE* pbCoff, int cbCoff) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool AddLinesDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.LPStr)] string szSrc,
            [In] ushort isect,
            [In] int offCon,
            [In] int cbCon,
            [In] int doff,
            [In] short lineStart,
            [In] IntPtr pbCoff,
            [In] int cbCoff);

        private AddLinesDelegate addLines;

        public void AddLines(string szSrc, ushort isect, int offCon, int cbCon, int doff, short lineStart, IntPtr pbCoff, int cbCoff)
        {
            InitDelegate(ref addLines, vtbl->AddLines);

            if (!addLines(Raw, szSrc, isect, offCon, cbCon, doff, lineStart, pbCoff, cbCoff))
                throw new NotImplementedException();
        }

        #endregion
        #region AddSecContrib

        //virtual BOOL AddSecContrib(USHORT isect, int off, int cb, UINT dwCharacteristics) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool AddSecContribDelegate(
            [In] IntPtr @this,
            [In] ushort isect,
            [In] int cb,
            [In] IMAGE_SCN dwCharacteristics);

        private AddSecContribDelegate addSecContrib;

        public void AddSecContrib(ushort isect, int cb, IMAGE_SCN dwCharacteristics)
        {
            InitDelegate(ref addSecContrib, vtbl->AddSecContrib);

            if (!addSecContrib(Raw, isect, cb, dwCharacteristics))
                throw new NotImplementedException();
        }

        #endregion
        #region QueryCBName

        //virtual BOOL QueryCBName(OUT int* pcb) pure;

        //Just gets the size required for calling QueryName

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryCBNameDelegate(
        //    [In] IntPtr @this);

        //private QueryCBNameDelegate queryCBName;

        //public bar QueryCBName()
        //{
        //    InitDelegate(ref queryCBName, vtbl->QueryCBName);

        //    if (!queryCBName(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryName

        //virtual BOOL QueryName(_Out_z_cap_(PDB_MAX_PATH) OUT char szName[PDB_MAX_PATH], OUT int* pcb) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QueryNameDelegate(
            [In] IntPtr @this,
            [Out, MarshalAs(UnmanagedType.LPArray)] byte[] szName,
            [In, Out] ref int pcb);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryNameDelegate queryName;

        public string Name
        {
            get
            {
                if (!TryQueryName(out var szName))
                    throw PDB1.GetUnknownError(MethodBase.GetCurrentMethod());

                return szName;
            }
        }

        public bool TryQueryName(out string szName)
        {
            InitDelegate(ref queryName, vtbl->QueryName);

            var pcb = PDB1.PDB_MAX_PATH;
            var szNameRaw = new byte[pcb];

            if (queryName(Raw, szNameRaw, ref pcb))
            {
                szName = CreateString(szNameRaw, pcb);
                return true;
            }

            szName = null;
            return false;
        }

        #endregion
        #region QuerySymbols

        //virtual BOOL QuerySymbols(BYTE* pbSym, int* pcb) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QuerySymbolsDelegate(
            [In] IntPtr @this,
            [In] IntPtr pbSym,
            [In, Out] ref int pcb);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QuerySymbolsDelegate querySymbols;

        public bool TryQuerySymbols(IntPtr pbSym, ref int pcb)
        {
            InitDelegate(ref querySymbols, vtbl->QuerySymbols);

            return querySymbols(Raw, pbSym, ref pcb);
        }

        #endregion
        #region QueryLines

        //virtual BOOL QueryLines(BYTE* pbLines, int* pcb) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QueryLinesDelegate(
            [In] IntPtr @this,
            [In] IntPtr pbLines,
            [In, Out] ref int pcb);

        private QueryLinesDelegate queryLines;

        public void QueryLines(IntPtr pbLines, ref int pcb)
        {
            InitDelegate(ref queryLines, vtbl->QueryLines);

            if (!queryLines(Raw, pbLines, ref pcb))
                throw new NotImplementedException();
        }

        #endregion
        #region SetPvClient

        //virtual BOOL SetPvClient(void *pvClient) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool SetPvClientDelegate(
        //    [In] IntPtr @this);

        //private SetPvClientDelegate setPvClient;

        //public bar SetPvClient()
        //{
        //    InitDelegate(ref setPvClient, vtbl->SetPvClient);

        //    if (!setPvClient(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region GetPvClient

        //virtual BOOL GetPvClient(OUT void** ppvClient) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool GetPvClientDelegate(
        //    [In] IntPtr @this);

        //private GetPvClientDelegate getPvClient;

        //public bar GetPvClient()
        //{
        //    InitDelegate(ref getPvClient, vtbl->GetPvClient);

        //    if (!getPvClient(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryFirstCodeSecContrib

        //virtual BOOL QueryFirstCodeSecContrib(OUT USHORT* pisect, OUT int* poff, OUT int* pcb, OUT UINT* pdwCharacteristics) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryFirstCodeSecContribDelegate(
        //    [In] IntPtr @this);

        //private QueryFirstCodeSecContribDelegate queryFirstCodeSecContrib;

        //public bar QueryFirstCodeSecContrib()
        //{
        //    InitDelegate(ref queryFirstCodeSecContrib, vtbl->QueryFirstCodeSecContrib);

        //    if (!queryFirstCodeSecContrib(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryImod

        //virtual BOOL QueryImod(OUT USHORT* pimod) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QueryImodDelegate(
            [In] IntPtr @this,
            [Out] out ushort pimod);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryImodDelegate queryImod;

        public ushort Imod
        {
            get
            {
                InitDelegate(ref queryImod, vtbl->QueryImod);

                if (!queryImod(Raw, out var pimod))
                    throw new NotImplementedException();

                return pimod;
            }
        }

        #endregion
        #region QueryDBI

        //virtual BOOL QueryDBI(OUT DBI** ppdbi) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryDBIDelegate(
        //    [In] IntPtr @this);

        //private QueryDBIDelegate queryDBI;

        //public bar QueryDBI()
        //{
        //    InitDelegate(ref queryDBI, vtbl->QueryDBI);

        //    if (!queryDBI(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region Close

        //virtual BOOL Close() pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool CloseDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private CloseDelegate close;

        public void Close()
        {
            InitDelegate(ref close, vtbl->Close);

            if (!close(Raw))
                throw new NotImplementedException();
        }

        #endregion
        #region QueryCBFile

        //virtual BOOL QueryCBFile(OUT int* pcb) pure;

        //Just gets the size required for calling QueryFile

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryCBFileDelegate(
        //    [In] IntPtr @this);

        //private QueryCBFileDelegate queryCBFile;

        //public bar QueryCBFile()
        //{
        //    InitDelegate(ref queryCBFile, vtbl->QueryCBFile);

        //    if (!queryCBFile(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryFile

        //virtual BOOL QueryFile(_Out_z_cap_(PDB_MAX_PATH) OUT char szFile[PDB_MAX_PATH], OUT int* pcb) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QueryFileDelegate(
            [In] IntPtr @this,
            [Out, MarshalAs(UnmanagedType.LPArray)] byte[] szFile,
            [In, Out] ref int pcb);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryFileDelegate queryFile;

        public string File
        {
            get
            {
                if (!TryQueryFile(out var szFile))
                    throw PDB1.GetUnknownError(MethodBase.GetCurrentMethod());

                return szFile;
            }
        }

        public bool TryQueryFile(out string szFile)
        {
            InitDelegate(ref queryFile, vtbl->QueryFile);

            var pcb = PDB1.PDB_MAX_PATH;
            var szFileRaw = new byte[pcb];

            if (queryFile(Raw, szFileRaw, ref pcb))
            {
                szFile = CreateString(szFileRaw, pcb);
                return true;
            }

            szFile = null;
            return false;
        }

        #endregion
        #region QueryTpi

        //virtual BOOL QueryTpi(OUT TPI** pptpi) pure; // return this Mod's Tpi

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryTpiDelegate(
        //    [In] IntPtr @this);

        //private QueryTpiDelegate queryTpi;

        //public bar QueryTpi()
        //{
        //    InitDelegate(ref queryTpi, vtbl->QueryTpi);

        //    if (!queryTpi(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region AddSecContribEx

        //virtual BOOL AddSecContribEx(USHORT isect, int off, int cb, UINT dwCharacteristics, DWORD dwDataCrc, DWORD dwRelocCrc) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool AddSecContribExDelegate(
            [In] IntPtr @this,
            [In] int isect,
            [In] int off,
            [In] int cb,
            [In] IMAGE_SCN dwCharacteristics,
            [In] int dwDataCrc,
            [In] int dwRelocCrc);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AddSecContribExDelegate addSecContribEx;

        public void AddSecContribEx(int isect, int off, int cb, IMAGE_SCN dwCharacteristics, int dwDataCrc, int dwRelocCrc)
        {
            InitDelegate(ref addSecContribEx, vtbl->AddSecContribEx);

            if (!addSecContribEx(Raw, isect, off, cb, dwCharacteristics, dwDataCrc, dwRelocCrc))
                throw new NotImplementedException();
        }

        #endregion
        #region QueryItsm

        //virtual BOOL QueryItsm(OUT USHORT* pitsm) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryItsmDelegate(
        //    [In] IntPtr @this);

        //private QueryItsmDelegate queryItsm;

        //public bar QueryItsm()
        //{
        //    InitDelegate(ref queryItsm, vtbl->QueryItsm);

        //    if (!queryItsm(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QuerySrcFile

        //virtual BOOL QuerySrcFile(_Out_z_cap_(PDB_MAX_PATH) OUT char szFile[PDB_MAX_PATH], OUT int* pcb) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QuerySrcFileDelegate(
        //    [In] IntPtr @this);

        //private QuerySrcFileDelegate querySrcFile;

        //public bar QuerySrcFile()
        //{
        //    InitDelegate(ref querySrcFile, vtbl->QuerySrcFile);

        //    if (!querySrcFile(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QuerySupportsEC

        //virtual BOOL QuerySupportsEC() pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QuerySupportsECDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QuerySupportsECDelegate querySupportsEC;

        public bool SupportsEC
        {
            get
            {
                InitDelegate(ref querySupportsEC, vtbl->QuerySupportsEC);

                return querySupportsEC(Raw);
            }
        }

        #endregion
        #region QueryPdbFile

        //virtual BOOL QueryPdbFile(_Out_z_cap_(PDB_MAX_PATH) OUT char szFile[PDB_MAX_PATH], OUT int* pcb) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryPdbFileDelegate(
        //    [In] IntPtr @this);

        //private QueryPdbFileDelegate queryPdbFile;

        //public bar QueryPdbFile()
        //{
        //    InitDelegate(ref queryPdbFile, vtbl->QueryPdbFile);

        //    if (!queryPdbFile(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region ReplaceLines

        //virtual BOOL ReplaceLines(BYTE* pbLines, int cb) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool ReplaceLinesDelegate(
            [In] IntPtr @this,
            [In] IntPtr pbLines,
            [In] int cb);

        private ReplaceLinesDelegate replaceLines;

        public void ReplaceLines(IntPtr pbLines, int cb)
        {
            InitDelegate(ref replaceLines, vtbl->ReplaceLines);

            if (!replaceLines(Raw, pbLines, cb))
                throw new NotImplementedException();
        }

        #endregion
        #region GetEnumLines

        //virtual bool GetEnumLines( EnumLines** ppenum ) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool GetEnumLinesDelegate(
            [In] IntPtr @this,
            [Out] out IntPtr ppenum);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GetEnumLinesDelegate getEnumLines;

        public EnumLines GetEnumLines()
        {
            if (!TryGetEnumLines(out var enumLines))
                throw new NotImplementedException();

            return enumLines;
        }

        public bool TryGetEnumLines(out EnumLines enumLines)
        {
            InitDelegate(ref getEnumLines, vtbl->GetEnumLines);

            if (!getEnumLines(Raw, out var ppenum))
            {
                enumLines = null;
                return false;
            }

            enumLines = new EnumLines(ppenum);
            return true;
        }

        #endregion
        #region QueryLineFlags

        //virtual bool QueryLineFlags( OUT DWORD* pdwFlags ) pure;    // what data is present?

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QueryLineFlagsDelegate(
            [In] IntPtr @this,
            [Out] out CV_LINES pdwFlags);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryLineFlagsDelegate queryLineFlags;

        public CV_LINES LineFlags
        {
            get
            {
                if (!TryQueryLineFlags(out var pdwFlags))
                    throw new NotImplementedException();

                return pdwFlags;
            }
        }

        public bool TryQueryLineFlags(out CV_LINES pdwFlags)
        {
            InitDelegate(ref queryLineFlags, vtbl->QueryLineFlags);

            return queryLineFlags(Raw, out pdwFlags);
        }

        #endregion
        #region QueryFileNameInfo

        //virtual bool QueryFileNameInfo(IN DWORD        fileId, _Out_opt_capcount_(*pccFilename) OUT wchar_t*    szFilename, IN OUT DWORD*   pccFilename, OUT DWORD*      pChksumType, OUT BYTE*       pbChksum, IN OUT DWORD*   pcbChksum) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QueryFileNameInfoDelegate(
            [In] IntPtr @this,
            [In] int fileId,
            [In] IntPtr szFilename, //wchar_t*
            [In, Out] ref int pccFilename, //in/out
            [Out] out CV_SourceChksum_t pChksumType,
            [Out] IntPtr pbChksum,
            [In, Out] ref int pcbChksum); //in/out

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryFileNameInfoDelegate queryFileNameInfo;

        public bool QueryFileNameInfo(
            int fileId,
            IntPtr szFilename, //wchar_t*
            ref int pccFilename,
            out CV_SourceChksum_t pChksumType,
            IntPtr pbChksum,
            ref int pcbChksum)
        {
            InitDelegate(ref queryFileNameInfo, vtbl->QueryFileNameInfo);

            return queryFileNameInfo(Raw, fileId, szFilename, ref pccFilename, out pChksumType, pbChksum, ref pcbChksum);
        }

        #endregion
        #region AddPublicW

        //virtual BOOL AddPublicW(_In_z_ const wchar_t* szPublic, USHORT isect, int off, CV_pubsymflag_t cvpsf =0) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool AddPublicWDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szPublic,
            [In] ushort isect,
            [In] int coff,
            [In] CV_PUBSYMFLAGS cvpsf); //There are 3 definitions for pub sym flags. CV_pubsymflag_t is the least useful

        private AddPublicWDelegate addPublicW;

        public void AddPublicW(string szPublic, ushort isect, int off, CV_PUBSYMFLAGS cvpsf = default)
        {
            InitDelegate(ref addPublicW, vtbl->AddPublicW);

            if (!addPublicW(Raw, szPublic, isect, off, cvpsf))
                throw new NotImplementedException();
        }

        #endregion
        #region AddLinesW

        //virtual BOOL AddLinesW(_In_z_ const wchar_t* szSrc, USHORT isect, int offCon, int cbCon, int doff, UINT lineStart, BYTE* pbCoff, int cbCoff) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool AddLinesWDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szSrc,
            [In] ushort isect,
            [In] int offCon,
            [In] int cbCon,
            [In] int doff,
            [In] int lineStart,
            [In] IntPtr pbCoff,
            [In] int cbCoff);

        private AddLinesWDelegate addLinesW;

        public void AddLinesW(string szSrc, ushort isect, int offCon, int cbCon, int doff, int lineStart, IntPtr pbCoff, int cbCoff)
        {
            InitDelegate(ref addLinesW, vtbl->AddLinesW);

            if (!addLinesW(Raw, szSrc, isect, offCon, cbCon, doff, lineStart, pbCoff, cbCoff))
                throw new NotImplementedException();
        }

        #endregion
        #region QueryNameW

        //virtual BOOL QueryNameW(_Out_z_cap_(PDB_MAX_PATH) OUT wchar_t szName[PDB_MAX_PATH], OUT int* pcb) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QueryNameWDelegate(
            [In] IntPtr @this,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2)] char[] szName,
            [In, Out] ref int pcb);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryNameWDelegate queryNameW;

        public string NameW
        {
            get
            {
                if (!TryQueryNameW(out var szName))
                    throw PDB1.GetUnknownError(MethodBase.GetCurrentMethod());

                return szName;
            }
        }

        public bool TryQueryNameW(out string szName)
        {
            InitDelegate(ref queryNameW, vtbl->QueryNameW);

            var pcb = PDB1.PDB_MAX_PATH;
            var szNameRaw = new char[pcb];

            if (queryNameW(Raw, szNameRaw, ref pcb))
            {
                szName = CreateString(szNameRaw, pcb);
                return true;
            }

            szName = null;
            return false;
        }

        #endregion
        #region QueryFileW

        //virtual BOOL QueryFileW(_Out_z_cap_(PDB_MAX_PATH) OUT wchar_t szFile[PDB_MAX_PATH], OUT int* pcb) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QueryFileWDelegate(
            [In] IntPtr @this,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2)] char[] szFile,
            [In, Out] ref int pcb);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryFileWDelegate queryFileW;

        public string FileW
        {
            get
            {
                if (!TryQueryFileW(out var szFile))
                    throw PDB1.GetUnknownError(MethodBase.GetCurrentMethod());

                return szFile;
            }
        }

        public bool TryQueryFileW(out string szFile)
        {
            InitDelegate(ref queryFileW, vtbl->QueryFileW);

            var pcb = PDB1.PDB_MAX_PATH;
            var szFileRaw = new char[pcb];

            if (queryFileW(Raw, szFileRaw, ref pcb))
            {
                szFile = CreateString(szFileRaw, pcb);
                return true;
            }

            szFile = null;
            return false;
        }

        #endregion
        #region QuerySrcFileW

        //virtual BOOL QuerySrcFileW(_Out_z_cap_(PDB_MAX_PATH) OUT wchar_t szFile[PDB_MAX_PATH], OUT int* pcb) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QuerySrcFileWDelegate(
            [In] IntPtr @this,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2)] char[] szFile,
            [In, Out] ref int pcb);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryFileWDelegate querySrcFileW;

        public string SrcFileW
        {
            get
            {
                if (!TryQuerySrcFileW(out var szFile))
                    throw PDB1.GetUnknownError(MethodBase.GetCurrentMethod());

                return szFile;
            }
        }

        public bool TryQuerySrcFileW(out string szFile)
        {
            InitDelegate(ref querySrcFileW, vtbl->QuerySrcFileW);

            var pcb = PDB1.PDB_MAX_PATH;
            var szFileRaw = new char[pcb];

            if (querySrcFileW(Raw, szFileRaw, ref pcb))
            {
                szFile = CreateString(szFileRaw, pcb);
                return true;
            }

            szFile = null;
            return false;
        }

        #endregion
        #region QueryPdbFileW

        //virtual BOOL QueryPdbFileW(_Out_z_cap_(PDB_MAX_PATH) OUT wchar_t szFile[PDB_MAX_PATH], OUT int* pcb) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QueryPdbFileWDelegate(
            [In] IntPtr @this,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2)] char[] szFile,
            [In, Out] ref int pcb);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryFileWDelegate queryPdbFileW;

        public string PdbFileW
        {
            get
            {
                if (!TryQueryPdbFileW(out var szFile))
                    throw PDB1.GetUnknownError(MethodBase.GetCurrentMethod());

                return szFile;
            }
        }

        public bool TryQueryPdbFileW(out string szFile)
        {
            InitDelegate(ref queryPdbFileW, vtbl->QueryPdbFileW);

            var pcb = PDB1.PDB_MAX_PATH;
            var szFileRaw = new char[pcb];

            if (queryPdbFileW(Raw, szFileRaw, ref pcb))
            {
                szFile = CreateString(szFileRaw, pcb);
                return true;
            }

            szFile = null;
            return false;
        }

        #endregion
        #region AddPublic2

        //virtual BOOL AddPublic2(_In_z_ const char* szPublic, USHORT isect, int off, CV_pubsymflag_t cvpsf =0) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool AddPublic2Delegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.LPStr)] string szPublic,
            [In] ushort isect,
            [In] int off,
            [In] CV_PUBSYMFLAGS cvpsf); //There are 3 definitions for pub sym flags. CV_pubsymflag_t is the least useful

        private AddPublic2Delegate addPublic2;

        public void AddPublic2(string szPublic, ushort isect, int off, CV_PUBSYMFLAGS cvpsf = default)
        {
            InitDelegate(ref addPublic2, vtbl->AddPublic2);

            if (!addPublic2(Raw, szPublic, isect, off, cvpsf))
                throw new NotImplementedException();
        }

        #endregion
        #region InsertLines

        //virtual BOOL InsertLines(BYTE* pbLines, int cb) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool InsertLinesDelegate(
            [In] IntPtr @this,
            [In] IntPtr pbLines,
            [In] int cb);

        private InsertLinesDelegate insertLines;

        public void InsertLines(IntPtr pbLines, int cb)
        {
            InitDelegate(ref insertLines, vtbl->InsertLines);

            if (!insertLines(Raw, pbLines, cb))
                throw new NotImplementedException();
        }

        #endregion
        #region QueryLines2

        //virtual BOOL QueryLines2(IN int cbLines, OUT BYTE *pbLines, OUT int *pcbLines) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QueryLines2Delegate(
            [In] IntPtr @this,
            [In] int cbLines,
            [Out] IntPtr pbLines,
            [Out] out int pcbLines);

        private QueryLines2Delegate queryLines2;

        public void QueryLines2(int cbLines, IntPtr pbLines, out int pcbLines)
        {
            InitDelegate(ref queryLines2, vtbl->QueryLines2);

            if (!queryLines2(Raw, cbLines, pbLines, out pcbLines))
                throw new NotImplementedException();
        }

        #endregion
        #region QueryCrossScopeExports

        //virtual BOOL QueryCrossScopeExports(DWORD cb, BYTE* pb, DWORD* pcb) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QueryCrossScopeExportsDelegate(
            [In] IntPtr @this,
            [In] int cb,
            [In] IntPtr pb,
            [Out] out int pcb);

        private QueryCrossScopeExportsDelegate queryCrossScopeExports;

        //Query C13 DEBUG_S_CROSSSCOPEEXPORTS

        public void QueryCrossScopeExports(int cb, IntPtr pb, out int pcb)
        {
            InitDelegate(ref queryCrossScopeExports, vtbl->QueryCrossScopeExports);

            if (!queryCrossScopeExports(Raw, cb, pb, out pcb))
                throw new NotImplementedException();
        }

        #endregion
        #region QueryCrossScopeImports

        //virtual BOOL QueryCrossScopeImports(DWORD cb, BYTE* pb, DWORD* pcb) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QueryCrossScopeImportsDelegate(
            [In] IntPtr @this,
            [In] int cb,
            [In] IntPtr pb,
            [Out] out int pcb);

        private QueryCrossScopeImportsDelegate queryCrossScopeImports;

        //Query C13 DEBUG_S_CROSSSCOPEIMPORTS

        public void QueryCrossScopeImports(int cb, IntPtr pb, out int pcb)
        {
            InitDelegate(ref queryCrossScopeImports, vtbl->QueryCrossScopeImports);

            if (!queryCrossScopeImports(Raw, cb, pb, out pcb))
                throw new NotImplementedException();
        }

        #endregion
        #region QueryInlineeLines

        //virtual BOOL QueryInlineeLines(DWORD cb, BYTE* pb, DWORD* pcb) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QueryInlineeLinesDelegate(
            [In] IntPtr @this,
            [In] int cb,
            [In] IntPtr pb,
            [Out] out int pcb);

        private QueryInlineeLinesDelegate queryInlineeLines;

        //Query C13 DEBUG_S_INLINEELINES

        public void QueryInlineeLines(int cb, IntPtr pb, out int pcb)
        {
            InitDelegate(ref queryInlineeLines, vtbl->QueryInlineeLines);

            if (!queryInlineeLines(Raw, cb, pb, out pcb))
                throw new NotImplementedException();
        }

        #endregion
        #region TranslateFileId

        //virtual BOOL TranslateFileId(DWORD id, DWORD* pid) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool TranslateFileIdDelegate(
        //    [In] IntPtr @this);

        //private TranslateFileIdDelegate translateFileId;

        //public bar TranslateFileId()
        //{
        //    InitDelegate(ref translateFileId, vtbl->TranslateFileId);

        //    if (!translateFileId(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryFuncMDTokenMap

        //virtual BOOL QueryFuncMDTokenMap(DWORD cb, BYTE* pb, DWORD* pcb) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryFuncMDTokenMapDelegate(
        //    [In] IntPtr @this);

        //private QueryFuncMDTokenMapDelegate queryFuncMDTokenMap;

        //public bar QueryFuncMDTokenMap()
        //{
        //    InitDelegate(ref queryFuncMDTokenMap, vtbl->QueryFuncMDTokenMap);

        //    if (!queryFuncMDTokenMap(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryTypeMDTokenMap

        //virtual BOOL QueryTypeMDTokenMap(DWORD cb, BYTE* pb, DWORD* pcb) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryTypeMDTokenMapDelegate(
        //    [In] IntPtr @this);

        //private QueryTypeMDTokenMapDelegate queryTypeMDTokenMap;

        //public bar QueryTypeMDTokenMap()
        //{
        //    InitDelegate(ref queryTypeMDTokenMap, vtbl->QueryTypeMDTokenMap);

        //    if (!queryTypeMDTokenMap(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryMergedAssemblyInput

        //virtual BOOL QueryMergedAssemblyInput(DWORD cb, BYTE* pb, DWORD* pcb) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryMergedAssemblyInputDelegate(
        //    [In] IntPtr @this);

        //private QueryMergedAssemblyInputDelegate queryMergedAssemblyInput;

        //public bar QueryMergedAssemblyInput()
        //{
        //    InitDelegate(ref queryMergedAssemblyInput, vtbl->QueryMergedAssemblyInput);

        //    if (!queryMergedAssemblyInput(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryILLines

        //virtual BOOL QueryILLines(DWORD cb, BYTE* pb, DWORD* pcb) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QueryILLinesDelegate(
            [In] IntPtr @this,
            [In] int cb,
            [In] IntPtr pb,
            [Out] out int pcb);

        private QueryILLinesDelegate queryILLines;

        public bool TryQueryILLines(int cb, IntPtr pb, out int pcb)
        {
            InitDelegate(ref queryILLines, vtbl->QueryILLines);

            return queryILLines(Raw, cb, pb, out pcb);
        }

        #endregion
        #region GetEnumILLines

        //virtual bool GetEnumILLines(EnumLines** ppenum) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool GetEnumILLinesDelegate(
            [In] IntPtr @this,
            [Out] out IntPtr ppenum);

        private GetEnumILLinesDelegate getEnumILLines;

        public EnumLines GetEnumILLines()
        {
            if (!TryGetEnumILLines(out var enumLines))
                throw new NotImplementedException();

            return enumLines;
        }

        public bool TryGetEnumILLines(out EnumLines enumLines)
        {
            InitDelegate(ref getEnumILLines, vtbl->GetEnumILLines);

            if (!getEnumILLines(Raw, out var ppenum))
            {
                enumLines = null;
                return false;
            }

            enumLines = new EnumLines(ppenum);
            return true;
        }

        #endregion
        #region QueryILLineFlags

        //virtual bool QueryILLineFlags(OUT DWORD* pdwFlags) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QueryILLineFlagsDelegate(
            [In] IntPtr @this,
            [Out] out CV_LINES pdwFlags);

        private QueryILLineFlagsDelegate queryILLineFlags;

        public CV_LINES ILLineFlags
        {
            get
            {
                if (!TryQueryILLineFlags(out var pdwFlags))
                    throw new NotImplementedException();

                return pdwFlags;
            }
        }

        public bool TryQueryILLineFlags(out CV_LINES pdwFlags)
        {
            InitDelegate(ref queryILLineFlags, vtbl->QueryILLineFlags);

            return queryILLineFlags(Raw, out pdwFlags);
        }

        #endregion
        #region MergeTypes

        //virtual BOOL MergeTypes(BYTE *pb, DWORD cb) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool MergeTypesDelegate(
        //    [In] IntPtr @this);

        //private MergeTypesDelegate mergeTypes;

        //public bar MergeTypes()
        //{
        //    InitDelegate(ref mergeTypes, vtbl->MergeTypes);

        //    if (!mergeTypes(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region IsTypeServed

        //virtual BOOL IsTypeServed(DWORD index, BOOL fID) pure;

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
        #region QueryTypes

        //virtual BOOL QueryTypes(BYTE* pb, DWORD* pcb) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryTypesDelegate(
        //    [In] IntPtr @this);

        //private QueryTypesDelegate queryTypes;

        //public bar QueryTypes()
        //{
        //    InitDelegate(ref queryTypes, vtbl->QueryTypes);

        //    if (!queryTypes(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryIDs

        //virtual BOOL QueryIDs(BYTE* pb, DWORD* pcb) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryIDsDelegate(
        //    [In] IntPtr @this);

        //private QueryIDsDelegate queryIDs;

        //public bar QueryIDs()
        //{
        //    InitDelegate(ref queryIDs, vtbl->QueryIDs);

        //    if (!queryIDs(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryCVRecordForTi

        //virtual BOOL QueryCVRecordForTi(DWORD index, BOOL fID, OUT BYTE* pb, IN OUT DWORD* pcb) pure;

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

        //virtual BOOL QueryPbCVRecordForTi(DWORD index, BOOL fID, OUT BYTE** ppb) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryPbCVRecordForTiDelegate(
        //    [In] IntPtr @this);

        //private QueryPbCVRecordForTiDelegate queryPbCVRecordForTi;

        //public bar QueryPbCVRecordForTi()
        //{
        //    InitDelegate(ref queryPbCVRecordForTi, vtbl->QueryPbCVRecordForTi);

        //    if (!queryPbCVRecordForTi(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryTiForUDT

        //virtual BOOL QueryTiForUDT(_In_z_ const char *sz, BOOL fCase, OUT TI *pti) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryTiForUDTDelegate(
        //    [In] IntPtr @this);

        //private QueryTiForUDTDelegate queryTiForUDT;

        //public bar QueryTiForUDT()
        //{
        //    InitDelegate(ref queryTiForUDT, vtbl->QueryTiForUDT);

        //    if (!queryTiForUDT(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryCoffSymRVAs

        //virtual BOOL QueryCoffSymRVAs(BYTE *pb, DWORD *pcb) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QueryCoffSymRVAsDelegate(
            [In] IntPtr @this,
            [In] IntPtr pb,
            [In, Out] ref int pcb);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryCoffSymRVAsDelegate queryCoffSymRVAs;

        public bool TryQueryCoffSymRVAs(IntPtr pb, ref int pcb)
        {
            InitDelegate(ref queryCoffSymRVAs, vtbl->QueryCoffSymRVAs);

            return queryCoffSymRVAs(Raw, pb, ref pcb);
        }

        #endregion
        #region AddSecContrib2

        //virtual BOOL AddSecContrib2(USHORT isect, DWORD off, DWORD isectCoff, DWORD cb, DWORD dwCharacteristics) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool AddSecContrib2Delegate(
        //    [In] IntPtr @this);

        //private AddSecContrib2Delegate addSecContrib2;

        //public bar AddSecContrib2()
        //{
        //    InitDelegate(ref addSecContrib2, vtbl->AddSecContrib2);

        //    if (!addSecContrib2(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region AddSecContrib2Ex

        //virtual BOOL AddSecContrib2Ex(USHORT isect, DWORD off, DWORD isecfCoff, DWORD cb, DWORD dwCharacteristics, DWORD dwDataCrc, DWORD dwRelocCrc) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool AddSecContrib2ExDelegate(
        //    [In] IntPtr @this);

        //private AddSecContrib2ExDelegate addSecContrib2Ex;

        //public bar AddSecContrib2Ex()
        //{
        //    InitDelegate(ref addSecContrib2Ex, vtbl->AddSecContrib2Ex);

        //    if (!addSecContrib2Ex(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region AddSymbols2

        //virtual BOOL AddSymbols2(BYTE* pbSym, DWORD cb, DWORD isectCoff) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool AddSymbols2Delegate(
            [In] IntPtr @this,
            [In] IntPtr pbSym,
            [In] int cb,
            [In] int isectCoff);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AddSymbols2Delegate addSymbols2;

        public void AddSymbols2(IntPtr pbSym, int cb, int isectCoff)
        {
            InitDelegate(ref addSymbols2, vtbl->AddSymbols2);

            if (!addSymbols2(Raw, pbSym, cb, isectCoff))
                throw new NotImplementedException();
        }

        #endregion
        #region RemoveGlobalRefs

        //virtual BOOL RemoveGlobalRefs() pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool RemoveGlobalRefsDelegate(
        //    [In] IntPtr @this);

        //private RemoveGlobalRefsDelegate removeGlobalRefs;

        //public bar RemoveGlobalRefs()
        //{
        //    InitDelegate(ref removeGlobalRefs, vtbl->RemoveGlobalRefs);

        //    if (!removeGlobalRefs(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QuerySrcLineForUDT

        //virtual BOOL QuerySrcLineForUDT(TI ti, _Deref_out_z_ char **pszSrc, DWORD *pLine) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QuerySrcLineForUDTDelegate(
        //    [In] IntPtr @this);

        //private QuerySrcLineForUDTDelegate querySrcLineForUDT;

        //public bar QuerySrcLineForUDT()
        //{
        //    InitDelegate(ref querySrcLineForUDT, vtbl->QuerySrcLineForUDT);

        //    if (!querySrcLineForUDT(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region NeedReloadCompilerGeneratedPDB

        //Mod1::NeedReloadCompilerGeneratedPDB(void)

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool NeedReloadCompilerGeneratedPDBDelegate(
        //    [In] IntPtr @this);

        //private NeedReloadCompilerGeneratedPDBDelegate needReloadCompilerGeneratedPDB;

        //public bar NeedReloadCompilerGeneratedPDB()
        //{
        //    InitDelegate(ref needReloadCompilerGeneratedPDB, vtbl->NeedReloadCompilerGeneratedPDB);

        //    if (!needReloadCompilerGeneratedPDB(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region EnCReleaseCompilerGeneratedPDB

        //Mod1::EnCReleaseCompilerGeneratedPDB(uchar *,uint)

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool EnCReleaseCompilerGeneratedPDBDelegate(
        //    [In] IntPtr @this);

        //private EnCReleaseCompilerGeneratedPDBDelegate enCReleaseCompilerGeneratedPDB;

        //public bar EnCReleaseCompilerGeneratedPDB()
        //{
        //    InitDelegate(ref enCReleaseCompilerGeneratedPDB, vtbl->EnCReleaseCompilerGeneratedPDB);

        //    if (!enCReleaseCompilerGeneratedPDB(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryInlineeMDTokenMap

        //Mod1::QueryInlineeMDTokenMap(uint,uchar *,uint *)

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryInlineeMDTokenMapDelegate(
        //    [In] IntPtr @this);

        //private QueryInlineeMDTokenMapDelegate queryInlineeMDTokenMap;

        //public bar QueryInlineeMDTokenMap()
        //{
        //    InitDelegate(ref queryInlineeMDTokenMap, vtbl->QueryInlineeMDTokenMap);

        //    if (!queryInlineeMDTokenMap(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region GetErrorCode

        //Mod1::GetErrorCode(void)

        //delegate int GetErrorCodeDelegate(
        //    [In] IntPtr @this);

        //private GetErrorCodeDelegate getErrorCode;

        //public int GetErrorCode()
        //{
        //    InitDelegate(ref getErrorCode, vtbl->GetErrorCode);

        //    return getErrorCode(Raw);
        //}

        #endregion
        #region AddCoffTypeSectionChecksum

        //Mod1::AddCoffTypeSectionChecksum(unsigned __int64)

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool AddCoffTypeSectionChecksumDelegate(
        //    [In] IntPtr @this);

        //private AddCoffTypeSectionChecksumDelegate addCoffTypeSectionChecksum;

        //public bar AddCoffTypeSectionChecksum()
        //{
        //    InitDelegate(ref addCoffTypeSectionChecksum, vtbl->AddCoffTypeSectionChecksum);

        //    if (!addCoffTypeSectionChecksum(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion

        public Mod1(IntPtr raw)
        {
            if (raw == IntPtr.Zero)
                throw new ArgumentNullException(nameof(raw));

            Raw = raw;
            vtbl = *(Mod1Vtbl**) raw;
        }

        public void Dispose()
        {
            Close();
        }

        public override string ToString()
        {
            return NameW;
        }
    }
}
