using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// Represents a module within the DBI.
    /// </summary>
    public unsafe class Mod1
    {
        public IntPtr Raw { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private Mod1Vtbl* vtbl;

        #region QueryInterfaceVersion

        public delegate PDBINTV QueryInterfaceVersionDelegate(
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

        public delegate DBIImpv QueryImplementationVersionDelegate(
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

        //delegate bool AddTypesDelegate(
        //    [In] IntPtr @this);

        //private AddTypesDelegate addTypes;

        //public bar AddTypes()
        //{
        //    InitDelegate(ref addTypes, vtbl->AddTypes);

        //    if (!addTypes(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region AddSymbols

        //virtual BOOL AddSymbols(BYTE* pbSym, int cb) pure;

        //delegate bool AddSymbolsDelegate(
        //    [In] IntPtr @this);

        //private AddSymbolsDelegate addSymbols;

        //public bar AddSymbols()
        //{
        //    InitDelegate(ref addSymbols, vtbl->AddSymbols);

        //    if (!addSymbols(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region AddPublic

        //virtual BOOL AddPublic(_In_z_ const char* szPublic, USHORT isect, int off) pure;

        //delegate bool AddPublicDelegate(
        //    [In] IntPtr @this);

        //private AddPublicDelegate addPublic;

        //public bar AddPublic()
        //{
        //    InitDelegate(ref addPublic, vtbl->AddPublic);

        //    if (!addPublic(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region AddLines

        //virtual BOOL AddLines(_In_z_ const char* szSrc, USHORT isect, int offCon, int cbCon, int doff, USHORT lineStart, BYTE* pbCoff, int cbCoff) pure;

        //delegate bool AddLinesDelegate(
        //    [In] IntPtr @this);

        //private AddLinesDelegate addLines;

        //public bar AddLines()
        //{
        //    InitDelegate(ref addLines, vtbl->AddLines);

        //    if (!addLines(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region AddSecContrib

        //virtual BOOL AddSecContrib(USHORT isect, int off, int cb, UINT dwCharacteristics) pure;

        //delegate bool AddSecContribDelegate(
        //    [In] IntPtr @this);

        //private AddSecContribDelegate addSecContrib;

        //public bar AddSecContrib()
        //{
        //    InitDelegate(ref addSecContrib, vtbl->AddSecContrib);

        //    if (!addSecContrib(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryCBName

        //virtual BOOL QueryCBName(OUT int* pcb) pure;

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

        //delegate bool QueryLinesDelegate(
        //    [In] IntPtr @this);

        //private QueryLinesDelegate queryLines;

        //public bar QueryLines()
        //{
        //    InitDelegate(ref queryLines, vtbl->QueryLines);

        //    if (!queryLines(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region SetPvClient

        //virtual BOOL SetPvClient(void *pvClient) pure;

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

        //delegate bool QueryImodDelegate(
        //    [In] IntPtr @this);

        //private QueryImodDelegate queryImod;

        //public bar QueryImod()
        //{
        //    InitDelegate(ref queryImod, vtbl->QueryImod);

        //    if (!queryImod(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryDBI

        //virtual BOOL QueryDBI(OUT DBI** ppdbi) pure;

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

        //delegate bool CloseDelegate(
        //    [In] IntPtr @this);

        //private CloseDelegate close;

        //public bar Close()
        //{
        //    InitDelegate(ref close, vtbl->Close);

        //    if (!close(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryCBFile

        //virtual BOOL QueryCBFile(OUT int* pcb) pure;

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

        //delegate bool AddSecContribExDelegate(
        //    [In] IntPtr @this);

        //private AddSecContribExDelegate addSecContribEx;

        //public bar AddSecContribEx()
        //{
        //    InitDelegate(ref addSecContribEx, vtbl->AddSecContribEx);

        //    if (!addSecContribEx(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryItsm

        //virtual BOOL QueryItsm(OUT USHORT* pitsm) pure;

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

        //delegate bool QuerySupportsECDelegate(
        //    [In] IntPtr @this);

        //private QuerySupportsECDelegate querySupportsEC;

        //public bar QuerySupportsEC()
        //{
        //    InitDelegate(ref querySupportsEC, vtbl->QuerySupportsEC);

        //    if (!querySupportsEC(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryPdbFile

        //virtual BOOL QueryPdbFile(_Out_z_cap_(PDB_MAX_PATH) OUT char szFile[PDB_MAX_PATH], OUT int* pcb) pure;

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

        //delegate bool ReplaceLinesDelegate(
        //    [In] IntPtr @this);

        //private ReplaceLinesDelegate replaceLines;

        //public bar ReplaceLines()
        //{
        //    InitDelegate(ref replaceLines, vtbl->ReplaceLines);

        //    if (!replaceLines(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region GetEnumLines

        //virtual bool GetEnumLines( EnumLines** ppenum ) pure;

        //delegate bool GetEnumLinesDelegate(
        //    [In] IntPtr @this);

        //private GetEnumLinesDelegate getEnumLines;

        //public bar GetEnumLines()
        //{
        //    InitDelegate(ref getEnumLines, vtbl->GetEnumLines);

        //    if (!getEnumLines(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryLineFlags

        //virtual bool QueryLineFlags( OUT DWORD* pdwFlags ) pure;    // what data is present?

        //delegate bool QueryLineFlagsDelegate(
        //    [In] IntPtr @this);

        //private QueryLineFlagsDelegate queryLineFlags;

        //public bar QueryLineFlags()
        //{
        //    InitDelegate(ref queryLineFlags, vtbl->QueryLineFlags);

        //    if (!queryLineFlags(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryFileNameInfo

        //virtual bool QueryFileNameInfo(IN DWORD        fileId, _Out_opt_capcount_(*pccFilename) OUT wchar_t*    szFilename, IN OUT DWORD*   pccFilename, OUT DWORD*      pChksumType, OUT BYTE*       pbChksum, IN OUT DWORD*   pcbChksum) pure;

        //delegate bool QueryFileNameInfoDelegate(
        //    [In] IntPtr @this);

        //private QueryFileNameInfoDelegate queryFileNameInfo;

        //public bar QueryFileNameInfo()
        //{
        //    InitDelegate(ref queryFileNameInfo, vtbl->QueryFileNameInfo);

        //    if (!queryFileNameInfo(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region AddPublicW

        //virtual BOOL AddPublicW(_In_z_ const wchar_t* szPublic, USHORT isect, int off, CV_pubsymflag_t cvpsf =0) pure;

        //delegate bool AddPublicWDelegate(
        //    [In] IntPtr @this);

        //private AddPublicWDelegate addPublicW;

        //public bar AddPublicW()
        //{
        //    InitDelegate(ref addPublicW, vtbl->AddPublicW);

        //    if (!addPublicW(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region AddLinesW

        //virtual BOOL AddLinesW(_In_z_ const wchar_t* szSrc, USHORT isect, int offCon, int cbCon, int doff, UINT lineStart, BYTE* pbCoff, int cbCoff) pure;

        //delegate bool AddLinesWDelegate(
        //    [In] IntPtr @this);

        //private AddLinesWDelegate addLinesW;

        //public bar AddLinesW()
        //{
        //    InitDelegate(ref addLinesW, vtbl->AddLinesW);

        //    if (!addLinesW(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryNameW

        //virtual BOOL QueryNameW(_Out_z_cap_(PDB_MAX_PATH) OUT wchar_t szName[PDB_MAX_PATH], OUT int* pcb) pure;

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

        //delegate bool QuerySrcFileWDelegate(
        //    [In] IntPtr @this);

        //private QuerySrcFileWDelegate querySrcFileW;

        //public bar QuerySrcFileW()
        //{
        //    InitDelegate(ref querySrcFileW, vtbl->QuerySrcFileW);

        //    if (!querySrcFileW(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryPdbFileW

        //virtual BOOL QueryPdbFileW(_Out_z_cap_(PDB_MAX_PATH) OUT wchar_t szFile[PDB_MAX_PATH], OUT int* pcb) pure;

        //delegate bool QueryPdbFileWDelegate(
        //    [In] IntPtr @this);

        //private QueryPdbFileWDelegate queryPdbFileW;

        //public bar QueryPdbFileW()
        //{
        //    InitDelegate(ref queryPdbFileW, vtbl->QueryPdbFileW);

        //    if (!queryPdbFileW(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region AddPublic2

        //virtual BOOL AddPublic2(_In_z_ const char* szPublic, USHORT isect, int off, CV_pubsymflag_t cvpsf =0) pure;

        //delegate bool AddPublic2Delegate(
        //    [In] IntPtr @this);

        //private AddPublic2Delegate addPublic2;

        //public bar AddPublic2()
        //{
        //    InitDelegate(ref addPublic2, vtbl->AddPublic2);

        //    if (!addPublic2(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region InsertLines

        //virtual BOOL InsertLines(BYTE* pbLines, int cb) pure;

        //delegate bool InsertLinesDelegate(
        //    [In] IntPtr @this);

        //private InsertLinesDelegate insertLines;

        //public bar InsertLines()
        //{
        //    InitDelegate(ref insertLines, vtbl->InsertLines);

        //    if (!insertLines(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryLines2

        //virtual BOOL QueryLines2(IN int cbLines, OUT BYTE *pbLines, OUT int *pcbLines) pure;

        //delegate bool QueryLines2Delegate(
        //    [In] IntPtr @this);

        //private QueryLines2Delegate queryLines2;

        //public bar QueryLines2()
        //{
        //    InitDelegate(ref queryLines2, vtbl->QueryLines2);

        //    if (!queryLines2(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryCrossScopeExports

        //virtual BOOL QueryCrossScopeExports(DWORD cb, BYTE* pb, DWORD* pcb) pure;

        //delegate bool QueryCrossScopeExportsDelegate(
        //    [In] IntPtr @this);

        //private QueryCrossScopeExportsDelegate queryCrossScopeExports;

        //public bar QueryCrossScopeExports()
        //{
        //    InitDelegate(ref queryCrossScopeExports, vtbl->QueryCrossScopeExports);

        //    if (!queryCrossScopeExports(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryCrossScopeImports

        //virtual BOOL QueryCrossScopeImports(DWORD cb, BYTE* pb, DWORD* pcb) pure;

        //delegate bool QueryCrossScopeImportsDelegate(
        //    [In] IntPtr @this);

        //private QueryCrossScopeImportsDelegate queryCrossScopeImports;

        //public bar QueryCrossScopeImports()
        //{
        //    InitDelegate(ref queryCrossScopeImports, vtbl->QueryCrossScopeImports);

        //    if (!queryCrossScopeImports(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryInlineeLines

        //virtual BOOL QueryInlineeLines(DWORD cb, BYTE* pb, DWORD* pcb) pure;

        //delegate bool QueryInlineeLinesDelegate(
        //          [In] IntPtr @this);

        //      private QueryInlineeLinesDelegate queryInlineeLines;

        //      public bar QueryInlineeLines()
        //      {
        //          InitDelegate(ref queryInlineeLines, vtbl->QueryInlineeLines);

        //          if (!queryInlineeLines(Raw))
        //              throw new NotImplementedException();
        //      }

        #endregion
        #region TranslateFileId

        //virtual BOOL TranslateFileId(DWORD id, DWORD* pid) pure;

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

        //delegate bool QueryILLinesDelegate(
        //    [In] IntPtr @this);

        //private QueryILLinesDelegate queryILLines;

        //public bar QueryILLines()
        //{
        //    InitDelegate(ref queryILLines, vtbl->QueryILLines);

        //    if (!queryILLines(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region GetEnumILLines

        //virtual bool GetEnumILLines(EnumLines** ppenum) pure;

        //delegate bool GetEnumILLinesDelegate(
        //    [In] IntPtr @this);

        //private GetEnumILLinesDelegate getEnumILLines;

        //public bar GetEnumILLines()
        //{
        //    InitDelegate(ref getEnumILLines, vtbl->GetEnumILLines);

        //    if (!getEnumILLines(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryILLineFlags

        //virtual bool QueryILLineFlags(OUT DWORD* pdwFlags) pure;

        //delegate bool QueryILLineFlagsDelegate(
        //    [In] IntPtr @this);

        //private QueryILLineFlagsDelegate queryILLineFlags;

        //public bar QueryILLineFlags()
        //{
        //    InitDelegate(ref queryILLineFlags, vtbl->QueryILLineFlags);

        //    if (!queryILLineFlags(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region MergeTypes

        //virtual BOOL MergeTypes(BYTE *pb, DWORD cb) pure;

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

        //delegate bool AddSymbols2Delegate(
        //    [In] IntPtr @this);

        //private AddSymbols2Delegate addSymbols2;

        //public bar AddSymbols2()
        //{
        //    InitDelegate(ref addSymbols2, vtbl->AddSymbols2);

        //    if (!addSymbols2(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region RemoveGlobalRefs

        //virtual BOOL RemoveGlobalRefs() pure;

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

        //delegate bool GetErrorCodeDelegate(
        //    [In] IntPtr @this);

        //private GetErrorCodeDelegate getErrorCode;

        //public bar GetErrorCode()
        //{
        //    InitDelegate(ref getErrorCode, vtbl->GetErrorCode);

        //    if (!getErrorCode(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region AddCoffTypeSectionChecksum

        //Mod1::AddCoffTypeSectionChecksum(unsigned __int64)

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

        public override string ToString()
        {
            return NameW;
        }
    }
}
