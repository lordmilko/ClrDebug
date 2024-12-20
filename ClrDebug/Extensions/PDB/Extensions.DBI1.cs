using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// Provides access to the Debug Information stream of a PDB.
    /// </summary>
    public unsafe class DBI1 : IDisposable
    {
        public IntPtr Raw { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DBI1Vtbl* vtbl;

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
        #region OpenMod

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool OpenModDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.LPStr)] string szModule,
            [In, MarshalAs(UnmanagedType.LPStr)] string szFile,
            [Out] out IntPtr ppmod);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OpenModDelegate openMod;

        public Mod1 OpenMod(string szModule, string szFile)
        {
            InitDelegate(ref openMod, vtbl->OpenMod);

            if (!openMod(Raw, szModule, szFile, out var ppmod))
                throw PDB1.GetUnknownError(MethodBase.GetCurrentMethod());

            return new Mod1(ppmod);
        }

        #endregion
        #region DeleteMod

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool DeleteModDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.LPStr)] string szModule);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DeleteModDelegate deleteMod;

        public void DeleteMod(string szModule)
        {
            InitDelegate(ref deleteMod, vtbl->DeleteMod);

            if (!deleteMod(Raw, szModule))
                throw PDB1.GetUnknownError(MethodBase.GetCurrentMethod());
        }

        #endregion
        #region QueryNextMod

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QueryNextModDelegate(
            [In] IntPtr @this,
            [In] IntPtr pmod,
            [Out] out IntPtr ppmodNext);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryNextModDelegate queryNextMod;

        public Mod1 QueryNextMod(Mod1 pmod)
        {
            if (!TryQueryNextMod(pmod, out var ppmodNext))
                throw PDB1.GetUnknownError(MethodBase.GetCurrentMethod());

            return ppmodNext;
        }

        public bool TryQueryNextMod(Mod1 pmod, out Mod1 ppmodNext)
        {
            InitDelegate(ref queryNextMod, vtbl->QueryNextMod);

            if (queryNextMod(Raw, pmod?.Raw ?? IntPtr.Zero, out var ppmodNextRaw))
            {
                ppmodNext = ppmodNextRaw == IntPtr.Zero ? null : new Mod1(ppmodNextRaw);
                return true;
            }

            ppmodNext = null;
            return false;
        }

        #endregion
        #region OpenGlobals

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool OpenGlobalsDelegate(
            [In] IntPtr @this,
            [Out] out IntPtr ppgsi);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OpenGlobalsDelegate openGlobals;

        public GSI1 OpenGlobals()
        {
            InitDelegate(ref openGlobals, vtbl->OpenGlobals);

            if (!openGlobals(Raw, out var ppgsi))
                throw PDB1.GetUnknownError(MethodBase.GetCurrentMethod());

            return new GSI1(ppgsi);
        }

        #endregion
        #region OpenPublics

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool OpenPublicsDelegate(
            [In] IntPtr @this,
            [Out] out IntPtr ppgsi);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OpenPublicsDelegate openPublics;

        public GSI1 OpenPublics()
        {
            InitDelegate(ref openPublics, vtbl->OpenPublics);

            if (!openPublics(Raw, out var ppgsi))
                throw PDB1.GetUnknownError(MethodBase.GetCurrentMethod());

            return new GSI1(ppgsi);
        }

        #endregion
        #region AddSec

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool AddSecDelegate(
            [In] IntPtr @this,
            [In] short isect,
            [In] short flags,
            [In] int off,
            [In] int cb);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private AddSecDelegate addSec;

        public void AddSec(short isect, short flags, int off, int cb)
        {
            InitDelegate(ref addSec, vtbl->AddSec);

            if (!addSec(Raw, isect, flags, off, cb))
                throw PDB1.GetUnknownError(MethodBase.GetCurrentMethod());
        }

        #endregion
        #region QueryModFromAddr

        //virtual BOOL QueryModFromAddr(USHORT isect, int off, OUT Mod** ppmod, OUT USHORT* pisect, OUT long* poff, OUT long* pcb) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QueryModFromAddrDelegate(
            [In] IntPtr @this,
            [In] short isect,
            [In] int off,
            [Out] out IntPtr ppmod,
            [Out] out short pisect,
            [Out] out int poff,
            [Out] out int pcb);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryModFromAddrDelegate queryModFromAddr;

        public bool TryQueryModFromAddr(int isect, int off, out DBI1_QueryModFromAddrResult result)
        {
            InitDelegate(ref queryModFromAddr, vtbl->QueryModFromAddr);

            if (queryModFromAddr(Raw, (short) isect, off, out var ppmod, out var pisect, out var poff, out var pcb))
            {
                result = new DBI1_QueryModFromAddrResult(ppmod != IntPtr.Zero ? new Mod1(ppmod) : null, pisect, poff, pcb);
                return true;
            }

            result = default;
            return false;
        }

        #endregion
        #region QuerySecMap

        //virtual BOOL QuerySecMap(OUT BYTE* pb, long* pcb) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QuerySecMapDelegate(
            [In] IntPtr @this,
            [Out] IntPtr pb,
            [Out] out int pcb);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QuerySecMapDelegate querySecMap;

        public bool TryQuerySecMap(IntPtr pb, out int pcb)
        {
            InitDelegate(ref querySecMap, vtbl->QuerySecMap);

            return querySecMap(Raw, pb, out pcb);
        }

        #endregion
        #region QueryFileInfo

        //virtual BOOL QueryFileInfo(OUT BYTE* pb, long* pcb) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QueryFileInfoDelegate(
            [In] IntPtr @this,
            [Out] IntPtr pb,
            [Out] out int pcb);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryFileInfoDelegate queryFileInfo;

        public int QueryFileInfo(IntPtr pb)
        {
            InitDelegate(ref queryFileInfo, vtbl->QueryFileInfo);

            if (!queryFileInfo(Raw, pb, out var pcb))
                throw PDB1.GetUnknownError(MethodBase.GetCurrentMethod());

            return pcb;
        }

        #endregion
        #region DumpMods

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate void DumpModsDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DumpModsDelegate dumpMods;

        public void DumpMods()
        {
            InitDelegate(ref dumpMods, vtbl->DumpMods);

            dumpMods(Raw);
        }

        #endregion
        #region DumpSecContribs

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate void DumpSecContribsDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DumpSecContribsDelegate dumpSecContribs;

        public void DumpSecContribs()
        {
            InitDelegate(ref dumpSecContribs, vtbl->DumpSecContribs);

            dumpSecContribs(Raw);
        }

        #endregion
        #region DumpSecMap

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate void DumpSecMapDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private DumpSecMapDelegate dumpSecMap;

        public void DumpSecMap()
        {
            InitDelegate(ref dumpSecMap, vtbl->DumpSecMap);

            dumpSecMap(Raw);
        }

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
                throw PDB1.GetUnknownError(MethodBase.GetCurrentMethod());
        }

        #endregion
        #region AddThunkMap

        //virtual BOOL AddThunkMap(long* poffThunkMap, unsigned nThunks, int cbSizeOfThunk, struct SO* psoSectMap, unsigned nSects, USHORT isectThunkTable, int offThunkTable) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool AddThunkMapDelegate(
        //    [In] IntPtr @this);

        //private AddThunkMapDelegate addThunkMap;

        //public bar AddThunkMap()
        //{
        //    InitDelegate(ref addThunkMap, vtbl->AddThunkMap);

        //    if (!addThunkMap(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region AddPublic

        //virtual BOOL AddPublic(_In_z_ const char* szPublic, USHORT isect, int off) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
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
        #region getEnumContrib

        //virtual BOOL getEnumContrib(OUT Enum** ppenum) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool getEnumContribDelegate(
            [In] IntPtr @this,
            [Out] out IntPtr ppenum);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private getEnumContribDelegate getEnumContrib;

        public EnumContrib GetEnumContrib()
        {
            if (!TryGetEnumContrib(out var ppenum))
                throw PDB1.GetUnknownError(MethodBase.GetCurrentMethod());

            return ppenum;
        }

        public bool TryGetEnumContrib(out EnumContrib ppenum)
        {
            InitDelegate(ref getEnumContrib, vtbl->getEnumContrib);

            var result = getEnumContrib(Raw, out var ppenumRaw);

            ppenum = ppenumRaw != IntPtr.Zero ? new EnumContrib(ppenumRaw) : null;

            return result;
        }

        #endregion
        #region QueryTypeServer

        //virtual BOOL QueryTypeServer( ITSM itsm, OUT TPI** pptpi ) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryTypeServerDelegate(
        //    [In] IntPtr @this);

        //private QueryTypeServerDelegate queryTypeServer;

        //public bar QueryTypeServer()
        //{
        //    InitDelegate(ref queryTypeServer, vtbl->QueryTypeServer);

        //    if (!queryTypeServer(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryItsmForTi

        //virtual BOOL QueryItsmForTi( TI ti, OUT ITSM* pitsm ) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryItsmForTiDelegate(
        //    [In] IntPtr @this);

        //private QueryItsmForTiDelegate queryItsmForTi;

        //public bar QueryItsmForTi()
        //{
        //    InitDelegate(ref queryItsmForTi, vtbl->QueryItsmForTi);

        //    if (!queryItsmForTi(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryNextItsm

        //virtual BOOL QueryNextItsm( ITSM itsm, OUT ITSM *inext ) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryNextItsmDelegate(
        //    [In] IntPtr @this);

        //private QueryNextItsmDelegate queryNextItsm;

        //public bar QueryNextItsm()
        //{
        //    InitDelegate(ref queryNextItsm, vtbl->QueryNextItsm);

        //    if (!queryNextItsm(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryLazyTypes

        //virtual BOOL QueryLazyTypes() pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryLazyTypesDelegate(
        //    [In] IntPtr @this);

        //private QueryLazyTypesDelegate queryLazyTypes;

        //public bar QueryLazyTypes()
        //{
        //    InitDelegate(ref queryLazyTypes, vtbl->QueryLazyTypes);

        //    if (!queryLazyTypes(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region SetLazyTypes

        //virtual BOOL SetLazyTypes( BOOL fLazy ) pure;   // lazy is default and can only be turned off

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool SetLazyTypesDelegate(
        //    [In] IntPtr @this);

        //private SetLazyTypesDelegate setLazyTypes;

        //public bar SetLazyTypes()
        //{
        //    InitDelegate(ref setLazyTypes, vtbl->SetLazyTypes);

        //    if (!setLazyTypes(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region FindTypeServers

        //virtual BOOL FindTypeServers( OUT EC* pec, _Out_opt_cap_(cbErrMax) OUT char szError[cbErrMax] ) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool FindTypeServersDelegate(
        //    [In] IntPtr @this);

        //private FindTypeServersDelegate findTypeServers;

        //public bar FindTypeServers()
        //{
        //    InitDelegate(ref findTypeServers, vtbl->FindTypeServers);

        //    if (!findTypeServers(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region DumpTypeServers

        //virtual void DumpTypeServers() pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool DumpTypeServersDelegate(
        //    [In] IntPtr @this);

        //private DumpTypeServersDelegate dumpTypeServers;

        //public bar DumpTypeServers()
        //{
        //    InitDelegate(ref dumpTypeServers, vtbl->DumpTypeServers);

        //    if (!dumpTypeServers(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region OpenDbg

        //virtual BOOL OpenDbg(DBGTYPE dbgtype, OUT Dbg **ppdbg) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool OpenDbgDelegate(
            [In] IntPtr @this,
            [In] DBGTYPE dbgtype,
            [Out] out IntPtr ppdbg);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OpenDbgDelegate openDbg;

        public Dbg1 OpenDbg(DBGTYPE dbgtype)
        {
            if (!TryOpenDbg(dbgtype, out var ppdbg))
                throw PDB1.GetUnknownError(MethodBase.GetCurrentMethod());

            return ppdbg;
        }

        public bool TryOpenDbg(DBGTYPE dbgtype, out Dbg1 ppdbg)
        {
            InitDelegate(ref openDbg, vtbl->OpenDbg);

            var result = openDbg(Raw, dbgtype, out var ppdbgRaw);

            ppdbg = ppdbgRaw != IntPtr.Zero ? new Dbg1(ppdbgRaw) : null;

            return result;
        }

        #endregion
        #region QueryDbgTypes

        //virtual BOOL QueryDbgTypes(OUT DBGTYPE *pdbgtype, OUT long* pcDbgtype) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryDbgTypesDelegate(
        //    [In] IntPtr @this);

        //private QueryDbgTypesDelegate queryDbgTypes;

        //public bar QueryDbgTypes()
        //{
        //    InitDelegate(ref queryDbgTypes, vtbl->QueryDbgTypes);

        //    if (!queryDbgTypes(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryAddrForSec

        //virtual BOOL QueryAddrForSec(OUT USHORT* pisect, OUT long* poff, USHORT imod, int cb, DWORD dwDataCrc, DWORD dwRelocCrc) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryAddrForSecDelegate(
        //    [In] IntPtr @this);

        //private QueryAddrForSecDelegate queryAddrForSec;

        //public bar QueryAddrForSec()
        //{
        //    InitDelegate(ref queryAddrForSec, vtbl->QueryAddrForSec);

        //    if (!queryAddrForSec(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryAddrForSecEx

        //virtual BOOL QueryAddrForSecEx(OUT USHORT* pisect, OUT long* poff, USHORT imod, int cb, DWORD dwDataCrc, DWORD dwRelocCrc, DWORD dwCharacteristics) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryAddrForSecExDelegate(
        //    [In] IntPtr @this);

        //private QueryAddrForSecExDelegate queryAddrForSecEx;

        //public bar QueryAddrForSecEx()
        //{
        //    InitDelegate(ref queryAddrForSecEx, vtbl->QueryAddrForSecEx);

        //    if (!queryAddrForSecEx(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QuerySupportsEC

        //virtual BOOL QuerySupportsEC() pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
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
        #region QueryPdb

        //virtual BOOL QueryPdb( OUT PDB** pppdb ) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryPdbDelegate(
        //    [In] IntPtr @this);

        //private QueryPdbDelegate queryPdb;

        //public bar QueryPdb()
        //{
        //    InitDelegate(ref queryPdb, vtbl->QueryPdb);

        //    if (!queryPdb(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region AddLinkInfo

        //virtual BOOL AddLinkInfo(IN PLinkInfo ) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool AddLinkInfoDelegate(
        //    [In] IntPtr @this);

        //private AddLinkInfoDelegate addLinkInfo;

        //public bar AddLinkInfo()
        //{
        //    InitDelegate(ref addLinkInfo, vtbl->AddLinkInfo);

        //    if (!addLinkInfo(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryLinkInfo

        //virtual BOOL QueryLinkInfo(PLinkInfo, OUT int * pcb) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryLinkInfoDelegate(
        //    [In] IntPtr @this);

        //private QueryLinkInfoDelegate queryLinkInfo;

        //public bar QueryLinkInfo()
        //{
        //    InitDelegate(ref queryLinkInfo, vtbl->QueryLinkInfo);

        //    if (!queryLinkInfo(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryAge

        //virtual AGE  QueryAge() const pure;

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
        #region QueryHeader

        //virtual void * QueryHeader() const pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryHeaderDelegate(
        //    [In] IntPtr @this);

        //private QueryHeaderDelegate queryHeader;

        //public bar QueryHeader()
        //{
        //    InitDelegate(ref queryHeader, vtbl->QueryHeader);

        //    if (!queryHeader(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region FlushTypeServers

        //virtual void FlushTypeServers() pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool FlushTypeServersDelegate(
        //    [In] IntPtr @this);

        //private FlushTypeServersDelegate flushTypeServers;

        //public bar FlushTypeServers()
        //{
        //    InitDelegate(ref flushTypeServers, vtbl->FlushTypeServers);

        //    if (!flushTypeServers(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryTypeServerByPdb

        //virtual BOOL QueryTypeServerByPdb(_In_z_ const char* szPdb, OUT ITSM* pitsm) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryTypeServerByPdbDelegate(
        //    [In] IntPtr @this);

        //private QueryTypeServerByPdbDelegate queryTypeServerByPdb;

        //public bar QueryTypeServerByPdb()
        //{
        //    InitDelegate(ref queryTypeServerByPdb, vtbl->QueryTypeServerByPdb);

        //    if (!queryTypeServerByPdb(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region OpenModW

        //virtual BOOL OpenModW(_In_z_ const wchar_t* szModule, _In_z_ const wchar_t* szFile, OUT Mod** ppmod) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool OpenModWDelegate(
        //    [In] IntPtr @this);

        //private OpenModWDelegate openModW;

        //public bar OpenModW()
        //{
        //    InitDelegate(ref openModW, vtbl->OpenModW);

        //    if (!openModW(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region DeleteModW

        //virtual BOOL DeleteModW(_In_z_ const wchar_t* szModule) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool DeleteModWDelegate(
        //    [In] IntPtr @this);

        //private DeleteModWDelegate deleteModW;

        //public bar DeleteModW()
        //{
        //    InitDelegate(ref deleteModW, vtbl->DeleteModW);

        //    if (!deleteModW(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region AddPublicW

        //virtual BOOL AddPublicW(_In_z_ const wchar_t* szPublic, USHORT isect, int off, CV_pubsymflag_t cvpsf =0) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
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
        #region QueryTypeServerByPdbW

        //virtual BOOL QueryTypeServerByPdbW(_In_z_ const wchar_t* szPdb, OUT ITSM* pitsm ) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryTypeServerByPdbWDelegate(
        //    [In] IntPtr @this);

        //private QueryTypeServerByPdbWDelegate queryTypeServerByPdbW;

        //public bar QueryTypeServerByPdbW()
        //{
        //    InitDelegate(ref queryTypeServerByPdbW, vtbl->QueryTypeServerByPdbW);

        //    if (!queryTypeServerByPdbW(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region AddLinkInfoW

        //virtual BOOL AddLinkInfoW(IN PLinkInfoW ) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool AddLinkInfoWDelegate(
        //    [In] IntPtr @this);

        //private AddLinkInfoWDelegate addLinkInfoW;

        //public bar AddLinkInfoW()
        //{
        //    InitDelegate(ref addLinkInfoW, vtbl->AddLinkInfoW);

        //    if (!addLinkInfoW(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region AddPublic2

        //virtual BOOL AddPublic2(_In_z_ const char* szPublic, USHORT isect, int off, CV_pubsymflag_t cvpsf =0) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
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
        #region QueryMachineType

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate short QueryMachineTypeDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryMachineTypeDelegate queryMachineType;

        public IMAGE_FILE_MACHINE MachineType
        {
            get
            {
                InitDelegate(ref queryMachineType, vtbl->QueryMachineType);

                return (IMAGE_FILE_MACHINE) queryMachineType(Raw);
            }
        }

        #endregion
        #region SetMachineType

        //virtual void SetMachineType(USHORT wMachine) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool SetMachineTypeDelegate(
        //    [In] IntPtr @this);

        //private SetMachineTypeDelegate setMachineType;

        //public bar SetMachineType()
        //{
        //    InitDelegate(ref setMachineType, vtbl->SetMachineType);

        //    if (!setMachineType(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region RemoveDataForRva

        //virtual void RemoveDataForRva( ULONG rva, ULONG cb ) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool RemoveDataForRvaDelegate(
        //    [In] IntPtr @this);

        //private RemoveDataForRvaDelegate removeDataForRva;

        //public bar RemoveDataForRva()
        //{
        //    InitDelegate(ref removeDataForRva, vtbl->RemoveDataForRva);

        //    if (!removeDataForRva(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region FStripped

        //virtual BOOL FStripped() pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool FStrippedDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private FStrippedDelegate fStripped;

        public bool FStripped
        {
            get
            {
                InitDelegate(ref fStripped, vtbl->FStripped);

                return fStripped(Raw);
            }
        }

        #endregion
        #region QueryModFromAddr2

        //virtual BOOL QueryModFromAddr2(USHORT isect, int off, OUT Mod** ppmod, OUT USHORT* pisect, OUT long* poff, OUT long* pcb, OUT ULONG * pdwCharacteristics) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QueryModFromAddr2Delegate(
            [In] IntPtr @this,
            [In] short isect,
            [In] int off,
            [Out] out IntPtr ppmod,
            [Out] out short pisect,
            [Out] out int poff,
            [Out] out int pcb,
            [Out] out int pdwCharacteristics);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryModFromAddr2Delegate queryModFromAddr2;

        public bool TryQueryModFromAddr2(int isect, int off, out DBI1_QueryModFromAddr2Result result)
        {
            InitDelegate(ref queryModFromAddr2, vtbl->QueryModFromAddr2);

            if (queryModFromAddr2(Raw, (short) isect, off, out var ppmod, out var pisect, out var poff, out var pcb, out var pdwCharacteristics))
            {
                result = new DBI1_QueryModFromAddr2Result(ppmod != IntPtr.Zero ? new Mod1(ppmod) : null, pisect, poff, pcb, pdwCharacteristics);
                return true;
            }

            result = default;
            return false;
        }

        #endregion
        #region QueryNoOfMods

        //virtual BOOL QueryNoOfMods(long *cMods) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryNoOfModsDelegate(
        //    [In] IntPtr @this);

        //private QueryNoOfModsDelegate queryNoOfMods;

        //public bar QueryNoOfMods()
        //{
        //    InitDelegate(ref queryNoOfMods, vtbl->QueryNoOfMods);

        //    if (!queryNoOfMods(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryMods

        //virtual BOOL QueryMods(Mod **ppmodNext, int cMods) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryModsDelegate(
        //    [In] IntPtr @this);

        //private QueryModsDelegate queryMods;

        //public bar QueryMods()
        //{
        //    InitDelegate(ref queryMods, vtbl->QueryMods);

        //    if (!queryMods(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryImodFromAddr

        //virtual BOOL QueryImodFromAddr(USHORT isect, int off, OUT USHORT* pimod, OUT USHORT* pisect, OUT long* poff, OUT long* pcb, OUT ULONG * pdwCharacteristics) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool QueryImodFromAddrDelegate(
            [In] IntPtr @this,
            [In] short isect,
            [In] int off,
            [Out] out short pimod,
            [Out] out short pisect,
            [Out] out int poff,
            [Out] out int pcb,
            [Out] out int pdwCharacteristics);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private QueryImodFromAddrDelegate queryImodFromAddr;

        //Like QueryModFromAddr but only returns the module index, instead of creating a new Mod1.
        //It's very annoying having to downcast ints to shorts to call this method, so we make isect an int instead
        public bool TryQueryImodFromAddr(int isect, int off, out DBI1_QueryImodFromAddrResult result)
        {
            InitDelegate(ref queryImodFromAddr, vtbl->QueryImodFromAddr);

            if (queryImodFromAddr(Raw, (short) isect, off, out var pimod, out var pisect, out var poff, out var pcb, out var pdwCharacteristics))
            {
                result = new DBI1_QueryImodFromAddrResult(pimod, pisect, poff, pcb, pdwCharacteristics);
                return true;
            }

            result = default;
            return false;
        }

        #endregion
        #region OpenModFromImod

        //virtual BOOL OpenModFromImod( USHORT imod, OUT Mod **ppmod ) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool OpenModFromImodDelegate(
        //    [In] IntPtr @this);

        //private OpenModFromImodDelegate openModFromImod;

        //public bar OpenModFromImod()
        //{
        //    InitDelegate(ref openModFromImod, vtbl->OpenModFromImod);

        //    if (!openModFromImod(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryHeader2

        //virtual BOOL QueryHeader2(long cb, OUT BYTE * pb, OUT int * pcbOut) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryHeader2Delegate(
        //    [In] IntPtr @this);

        //private QueryHeader2Delegate queryHeader2;

        //public bar QueryHeader2()
        //{
        //    InitDelegate(ref queryHeader2, vtbl->QueryHeader2);

        //    if (!queryHeader2(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region FAddSourceMappingItem

        //virtual BOOL FAddSourceMappingItem(_In_z_ const wchar_t * szMapTo, _In_z_ const wchar_t * szMapFrom, ULONG grFlags) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool FAddSourceMappingItemDelegate(
        //    [In] IntPtr @this);

        //private FAddSourceMappingItemDelegate fAddSourceMappingItem;

        //public bar FAddSourceMappingItem()
        //{
        //    InitDelegate(ref fAddSourceMappingItem, vtbl->FAddSourceMappingItem);

        //    if (!fAddSourceMappingItem(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region FSetPfnNotePdbUsed

        //virtual BOOL FSetPfnNotePdbUsed(void * pvContext, PFNNOTEPDBUSED) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool FSetPfnNotePdbUsedDelegate(
        //    [In] IntPtr @this);

        //private FSetPfnNotePdbUsedDelegate fSetPfnNotePdbUsed;

        //public bar FSetPfnNotePdbUsed()
        //{
        //    InitDelegate(ref fSetPfnNotePdbUsed, vtbl->FSetPfnNotePdbUsed);

        //    if (!fSetPfnNotePdbUsed(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region FCTypes

        //virtual BOOL FCTypes() pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool FCTypesDelegate(
            [In] IntPtr @this);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private FCTypesDelegate fCTypes;

        public bool FCTypes
        {
            get
            {
                InitDelegate(ref fCTypes, vtbl->FCTypes);

                return fCTypes(Raw);
            }
        }

        #endregion
        #region QueryFileInfo2

        //virtual BOOL QueryFileInfo2(BYTE *pb, int *pcb) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryFileInfo2Delegate(
        //    [In] IntPtr @this);

        //private QueryFileInfo2Delegate queryFileInfo2;

        //public bar QueryFileInfo2()
        //{
        //    InitDelegate(ref queryFileInfo2, vtbl->QueryFileInfo2);

        //    if (!queryFileInfo2(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region FSetPfnQueryCallback

        //virtual BOOL FSetPfnQueryCallback(void *pvContext, PFNDBIQUERYCALLBACK) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool FSetPfnQueryCallbackDelegate(
        //    [In] IntPtr @this);

        //private FSetPfnQueryCallbackDelegate fSetPfnQueryCallback;

        //public bar FSetPfnQueryCallback()
        //{
        //    InitDelegate(ref fSetPfnQueryCallback, vtbl->FSetPfnQueryCallback);

        //    if (!fSetPfnQueryCallback(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region FSetPfnNoteTypeMismatch

        //virtual BOOL FSetPfnNoteTypeMismatch(void * pvContext, PFNNOTETYPEMISMATCH) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool FSetPfnNoteTypeMismatchDelegate(
        //    [In] IntPtr @this);

        //private FSetPfnNoteTypeMismatchDelegate fSetPfnNoteTypeMismatch;

        //public bar FSetPfnNoteTypeMismatch()
        //{
        //    InitDelegate(ref fSetPfnNoteTypeMismatch, vtbl->FSetPfnNoteTypeMismatch);

        //    if (!fSetPfnNoteTypeMismatch(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region FSetPfnTmdTypeFilter

        //virtual BOOL FSetPfnTmdTypeFilter(void *pvContext, PFNTMDTYPEFILTER) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool FSetPfnTmdTypeFilterDelegate(
        //    [In] IntPtr @this);

        //private FSetPfnTmdTypeFilterDelegate fSetPfnTmdTypeFilter;

        //public bar FSetPfnTmdTypeFilter()
        //{
        //    InitDelegate(ref fSetPfnTmdTypeFilter, vtbl->FSetPfnTmdTypeFilter);

        //    if (!fSetPfnTmdTypeFilter(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region FSetPfnDumpTMCache

        //DBI1::FSetPfnDumpTMCache(void *,void (*)(void *,ushort const *))

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool FSetPfnDumpTMCacheDelegate(
        //    [In] IntPtr @this);

        //private FSetPfnDumpTMCacheDelegate fSetPfnDumpTMCache;

        //public bar FSetPfnDumpTMCache()
        //{
        //    InitDelegate(ref fSetPfnDumpTMCache, vtbl->FSetPfnDumpTMCache);

        //    if (!fSetPfnDumpTMCache(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region RemovePublic

        //virtual BOOL RemovePublic(_In_z_ const char* szPublic) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool RemovePublicDelegate(
        //    [In] IntPtr @this);

        //private RemovePublicDelegate removePublic;

        //public bar RemovePublic()
        //{
        //    InitDelegate(ref removePublic, vtbl->RemovePublic);

        //    if (!removePublic(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region getEnumContrib2

        //virtual BOOL getEnumContrib2(OUT Enum** ppenum) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool getEnumContrib2Delegate(
        //    [In] IntPtr @this);

        //private getEnumContrib2Delegate getenumContrib2;

        //public bar getEnumContrib2()
        //{
        //    InitDelegate(ref getenumContrib2, vtbl->getEnumContrib2);

        //    if (!getenumContrib2(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryModFromAddrEx

        //virtual BOOL QueryModFromAddrEx(USHORT isect, ULONG off, OUT Mod** ppmod, OUT USHORT* pisect, OUT ULONG *pisectCoff, OUT ULONG* poff, OUT ULONG* pcb, OUT ULONG * pdwCharacteristics) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryModFromAddrExDelegate(
        //    [In] IntPtr @this,
        //    [In] short isect,
        //    [In] int off,
        //    [Out] out IntPtr ppmod,
        //    [Out] out short pisect,
        //    [Out] out int pisectCoff,
        //    [Out] out int pcb,
        //    [Out] out int pdwCharacteristics);

        //private QueryModFromAddrExDelegate queryModFromAddrEx;

        //public bool TryQueryModFromAddrEx(short isect, int off)
        //{
        //    InitDelegate(ref queryModFromAddrEx, vtbl->QueryModFromAddrEx);

        //    if (queryModFromAddrEx(Raw, isect, off, out var ppmod, out var pisect, out var pisectCoff, out var pcb, out var pdwCharacteristics))
        //    {

        //    }

        //    throw new NotImplementedException();
        //}

        #endregion
        #region QueryImodFromAddrEx

        //virtual BOOL QueryImodFromAddrEx(USHORT isect, ULONG off, OUT USHORT* pimod, OUT USHORT* pisect, OUT ULONG *pisectCoff, OUT ULONG* poff, OUT ULONG* pcb, OUT ULONG * pdwCharacteristics) pure;

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryImodFromAddrExDelegate(
        //    [In] IntPtr @this);

        //private QueryImodFromAddrExDelegate queryImodFromAddrEx;

        //public bar QueryImodFromAddrEx()
        //{
        //    InitDelegate(ref queryImodFromAddrEx, vtbl->QueryImodFromAddrEx);

        //    if (!queryImodFromAddrEx(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region UpdateGlobalDataAddr

        //DBI1::UpdateGlobalDataAddr(char const *,ushort,int)

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool UpdateGlobalDataAddrDelegate(
        //    [In] IntPtr @this);

        //private UpdateGlobalDataAddrDelegate updateGlobalDataAddr;

        //public bar UpdateGlobalDataAddr()
        //{
        //    InitDelegate(ref updateGlobalDataAddr, vtbl->UpdateGlobalDataAddr);

        //    if (!updateGlobalDataAddr(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region _Missing

        #endregion
        #region ClearSegmentMap

        //DBI1::ClearSegmentMap(void)

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool ClearSegmentMapDelegate(
        //    [In] IntPtr @this);

        //private ClearSegmentMapDelegate clearSegmentMap;

        //public bar ClearSegmentMap()
        //{
        //    InitDelegate(ref clearSegmentMap, vtbl->ClearSegmentMap);

        //    if (!clearSegmentMap(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region DumpTMCache

        //DBI1::DumpTMCache(void)

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool DumpTMCacheDelegate(
        //    [In] IntPtr @this);

        //private DumpTMCacheDelegate dumpTMCache;

        //public bar DumpTMCache()
        //{
        //    InitDelegate(ref dumpTMCache, vtbl->DumpTMCache);

        //    if (!dumpTMCache(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region QueryDbgHeader

        //DBI1::QueryDbgHeader(int,uchar *,int *)

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryDbgHeaderDelegate(
        //    [In] IntPtr @this);

        //private QueryDbgHeaderDelegate queryDbgHeader;

        //public bar QueryDbgHeader()
        //{
        //    InitDelegate(ref queryDbgHeader, vtbl->QueryDbgHeader);

        //    if (!queryDbgHeader(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion

        public DBI1(IntPtr raw)
        {
            if (raw == IntPtr.Zero)
                throw new ArgumentNullException(nameof(raw));

            Raw = raw;
            vtbl = *(DBI1Vtbl**) raw;
        }

        public void Dispose()
        {
            Close();
        }
    }
}
