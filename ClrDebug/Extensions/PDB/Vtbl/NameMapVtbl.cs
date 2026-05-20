using System;

namespace ClrDebug.PDB
{
#pragma warning disable CS0649
    internal struct NameMapVtbl
    {
        public IntPtr close;
        public IntPtr reinitialize;
        public IntPtr getNi;
        public IntPtr getName;
        public IntPtr getEnumNameMap;
        public IntPtr contains;
        public IntPtr commit;
        public IntPtr isValidNi;
        public IntPtr getNiW;
        public IntPtr getNameW;
        public IntPtr containsW;
        public IntPtr containsUTF8;
        public IntPtr getNiUTF8;
        public IntPtr getNameA;
        public IntPtr getNameW2;
    }
#pragma warning restore CS0649
}
