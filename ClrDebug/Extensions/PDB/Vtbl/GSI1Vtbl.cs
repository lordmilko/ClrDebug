using System;

namespace ClrDebug.PDB
{
#pragma warning disable CS0649
    internal struct GSI1Vtbl
    {
        public IntPtr QueryInterfaceVersion;
        public IntPtr QueryImplementationVersion;
        public IntPtr NextSym;
        public IntPtr HashSym;
        public IntPtr NearestSym;
        public IntPtr Close;
        public IntPtr getEnumThunk;
        public IntPtr OffForSym;
        public IntPtr SymForOff;
        public IntPtr HashSymW;
        public IntPtr getEnumByAddr;
        public IntPtr setPfnMiniPDBNHBuildStatusCallback;
        public IntPtr _Missing1;
        public IntPtr QueryMiniPDBForTiDefnUDT2;
        public IntPtr BinarySearchGSNameInModule;
        public IntPtr getEnumSyms;
        public IntPtr _Missing2;
    }
#pragma warning restore CS0649
}
