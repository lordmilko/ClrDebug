using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    //Global symbol info
    public unsafe class GSI1 : IDisposable
    {
        public IntPtr Raw { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private GSI1Vtbl* vtbl;

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
        #region NextSym

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate SYMTYPE* NextSymDelegate(
            [In] IntPtr @this,
            [In] SYMTYPE* pbSym);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private NextSymDelegate nextSym;

        public SYMTYPE* NextSym(SYMTYPE* pbSym)
        {
            InitDelegate(ref nextSym, vtbl->NextSym);

            return nextSym(Raw, pbSym);
        }

        #endregion
        #region HashSym

        //virtual BYTE* HashSym(_In_z_ const char* szName, BYTE* pbSym) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate SYMTYPE* HashSymDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.LPStr)] string szName,
            [In] SYMTYPE* pbSym);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private HashSymDelegate hashSym;

        public SYMTYPE* HashSym(string szName, SYMTYPE* pbSym)
        {
            InitDelegate(ref hashSym, vtbl->HashSym);

            return hashSym(Raw, szName, pbSym);
        }

        #endregion
        #region NearestSym

        //virtual BYTE* NearestSym(USHORT isect, long off, OUT long* pdisp) pure;      //currently only supported for publics

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate SYMTYPE* NearestSymDelegate(
            [In] IntPtr @this,
            [In] ushort isect,
            [In] int off,
            [Out] out int pdisp);

        private NearestSymDelegate nearestSym;

        public SYMTYPE* NearestSym(ushort isect, int off, out int pdisp)
        {
            InitDelegate(ref nearestSym, vtbl->NearestSym);

            return nearestSym(Raw, isect, off, out pdisp);
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
        #region getEnumThunk

        //virtual BOOL getEnumThunk(USHORT isect, long off, OUT EnumThunk** ppenum) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool getEnumThunkDelegate(
            [In] IntPtr @this,
            [In] ushort isect,
            [In] int off,
            [Out] out IntPtr ppenum);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private getEnumThunkDelegate getEnumThunk;

        public EnumThunk GetEnumThunk(ushort isect, int off)
        {
            if (!TryGetEnumThunk(isect, off, out var ppEnum))
                throw PDB1.GetUnknownError(MethodBase.GetCurrentMethod());

            return ppEnum;
        }

        /* How does getEnumThunkWork?
         *
         * Suppose we have a PE File with the following
         *
         * - Section 2 is the .text section whose VirtualAddress is 0x11000
         * - At RVA 0x143C0 (.text + 0x33C0) there is a function Foo
         * - At RVA 0x11479 (.text + 0x479) there is a thunk that simply contains a jump to foo.
         *   This is much more likely in a debug build, where every function will have a thunk in
         *   order to support EnC
         *
         * PSGSIHDR contains a thunk map that describes the RVAs of all of these thunks.
         * If you want to know that a given function has a corresponding thunk, you can use this method.
         * As PDB1 does not support querying by RVA, you would first split your RVA into its section and offset
         * (so in the case of RVA 0x143C0, we pass in isect = 2, off = 0x33C0). PSGSI1::getEnumThunk will then
         * scan bufSectMap for a SO whose isect matches the isect that you pass to this method. If there is a match,
         * the offset you specified is incremented by SO.off to get an RVA again, to be matched against in bufThunkMap.
         * bufThunkMap is not sorted. PSEnumThunk::next simply iterates through the entire list of thunk offsets
         * trying to find any entries whose RVA is a match.
         *
         * Based on the position of the matching RVA in bufThunkMap, the location of the thunk itself can be computed.
         * PSGSIHDR.isectThunkTable and offThunkTable describe the location in the PE File where the thunk table is listed.
         * In this example, if isectThunkTable is 2, and offThunkTable is 5, this is the .text section described above, so
         * the thunk table starts at 0x11005. The size of each thunk depends on the CPU architecture in use; in an AMD64 process
         * each thunk will simply consist of a jmp, meaning that the size of each thunk is 5 bytes. By using PSGSIHDR.nThunks,
         * we can also compute the end of the thunk table: it will simply be 0x11005 + (nThunks * 5). The order of the entries
         * in bufThunkMap matches the physical order that exists in the PE File. As such, we can see that the offset of a give
         * thunk can be computed by multiplying its position in bufThunkMap by 5. The match for 0x143C0 was found at index 229,
         * giving 5+229 = 0x479.
         *
         * Thus, if a match is found, PSEnumThunk::get returns the following information
         *
         * - isect: PSGSIHDR.isectThunkTable
         * - off: the index of the match in bufThunkMap * cbSizeOfThunk
         * - pcb: PSGSIHDR.cbSizeOfThunk
         *
         */

        //If isect is not in PSGSIHDR.nSects, this method will return false
        public bool TryGetEnumThunk(ushort isect, int off, out EnumThunk ppEnum)
        {
            InitDelegate(ref getEnumThunk, vtbl->getEnumThunk);

            var result = getEnumThunk(Raw, isect, off, out var ppEnumRaw);

            ppEnum = ppEnumRaw != IntPtr.Zero ? new EnumThunk(ppEnumRaw) : null;

            return result;
        }

        #endregion
        #region OffForSym

        //virtual int OffForSym(BYTE *pbSym) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate int OffForSymDelegate(
            [In] IntPtr @this,
            [In] SYMTYPE* pbSym);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private OffForSymDelegate offForSym;

        public int OffForSym(SYMTYPE* pbSym)
        {
            InitDelegate(ref offForSym, vtbl->OffForSym);

            return offForSym(Raw, pbSym);
        }

        #endregion
        #region SymForOff

        //virtual BYTE* SymForOff(int off) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate SYMTYPE* SymForOffDelegate(
            [In] IntPtr @this,
            [In] int off);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private SymForOffDelegate symForOff;

        public SYMTYPE* SymForOff(int off)
        {
            InitDelegate(ref symForOff, vtbl->SymForOff);

            return symForOff(Raw, off);
        }

        #endregion
        #region HashSymW

        //virtual BYTE* HashSymW(_In_z_ const wchar_t *wcsName, BYTE* pbSym) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate SYMTYPE* HashSymWDelegate(
            [In] IntPtr @this,
            [In, MarshalAs(UnmanagedType.LPWStr)] string wcsName,
            [In] SYMTYPE* pbSym);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private HashSymWDelegate hashSymW;

        public SYMTYPE* HashSymW(string wcsName, SYMTYPE* pbSym)
        {
            InitDelegate(ref hashSymW, vtbl->HashSymW);

            return hashSymW(Raw, wcsName, pbSym);
        }

        #endregion
        #region getEnumByAddr

        //virtual BOOL getEnumByAddr(EnumSyms **ppEnum) pure;

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool getEnumByAddrDelegate(
            [In] IntPtr @this,
            [Out] out IntPtr ppEnum);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private getEnumByAddrDelegate getEnumByAddr;

        public EnumSyms GetEnumByAddr()
        {
            if (!TryGetEnumByAddr(out var ppEnum))
                throw PDB1.GetUnknownError(MethodBase.GetCurrentMethod());

            return ppEnum;
        }

        public bool TryGetEnumByAddr(out EnumSyms ppEnum)
        {
            InitDelegate(ref getEnumByAddr, vtbl->getEnumByAddr);

            var result = getEnumByAddr(Raw, out var ppEnumRaw);

            ppEnum = ppEnumRaw != IntPtr.Zero ? new EnumSyms(ppEnumRaw) : null;

            return result;
        }

        #endregion
        #region setPfnMiniPDBNHBuildStatusCallback

        //GSI1::setPfnMiniPDBNHBuildStatusCallback(void *,int (*)(void *,int))

        //Guessed name
        public delegate int MiniPDBNHBuildStatusCallback(IntPtr a1, int a2);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate void setPfnMiniPDBNHBuildStatusCallbackDelegate(
            [In] IntPtr @this,
            [In] IntPtr a2,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] MiniPDBNHBuildStatusCallback a3);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private setPfnMiniPDBNHBuildStatusCallbackDelegate setPfnMiniPDBNHBuildStatusCallback;

        public void SetPfnMiniPDBNHBuildStatusCallback(IntPtr a2, MiniPDBNHBuildStatusCallback a3)
        {
            InitDelegate(ref setPfnMiniPDBNHBuildStatusCallback, vtbl->setPfnMiniPDBNHBuildStatusCallback);

            setPfnMiniPDBNHBuildStatusCallback(Raw, a2, a3);
        }

        #endregion
        #region _Missing1

        #endregion
        #region QueryMiniPDBForTiDefnUDT2

        //GSI1::QueryMiniPDBForTiDefnUDT2(char const *,ushort,ushort *)

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool QueryMiniPDBForTiDefnUDT2Delegate(
        //    [In] IntPtr @this);

        //private QueryMiniPDBForTiDefnUDT2Delegate queryMiniPDBForTiDefnUDT2;

        //public bar QueryMiniPDBForTiDefnUDT2()
        //{
        //    InitDelegate(ref queryMiniPDBForTiDefnUDT2, vtbl->QueryMiniPDBForTiDefnUDT2);

        //    if (!queryMiniPDBForTiDefnUDT2(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region BinarySearchGSNameInModule

        //GSI1::BinarySearchGSNameInModule(ushort,char const *,uchar * *,int *)

        //[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        //delegate bool BinarySearchGSNameInModuleDelegate(
        //    [In] IntPtr @this);

        //private BinarySearchGSNameInModuleDelegate binarySearchGSNameInModule;

        //public bar BinarySearchGSNameInModule()
        //{
        //    InitDelegate(ref binarySearchGSNameInModule, vtbl->BinarySearchGSNameInModule);

        //    if (!binarySearchGSNameInModule(Raw))
        //        throw new NotImplementedException();
        //}

        #endregion
        #region getEnumSyms

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        delegate bool getEnumSymsDelegate(
            [In] IntPtr @this,
            [Out] out IntPtr ppEnum,
            [In] SYMTYPE* pbSym);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private getEnumSymsDelegate getEnumSyms;

        public EnumSyms GetEnumSyms(SYMTYPE* pbSym)
        {
            if (!TryGetEnumSyms(pbSym, out var ppEnum))
                throw PDB1.GetUnknownError(MethodBase.GetCurrentMethod());

            return ppEnum;
        }

        public bool TryGetEnumSyms(SYMTYPE* pbSym, out EnumSyms ppEnum)
        {
            InitDelegate(ref getEnumSyms, vtbl->getEnumSyms);

            //pbSym can be null
            var result = getEnumSyms(Raw, out var ppEnumRaw, pbSym);

            ppEnum = ppEnumRaw != IntPtr.Zero ? new EnumSyms(ppEnumRaw) : null;

            return result;
        }

        #endregion
        #region _Missing2

        #endregion

        public GSI1(IntPtr raw)
        {
            if (raw == IntPtr.Zero)
                throw new ArgumentNullException(nameof(raw));

            Raw = raw;
            vtbl = *(GSI1Vtbl**) raw;
        }

        public void Dispose()
        {
            Close();
        }
    }
}
