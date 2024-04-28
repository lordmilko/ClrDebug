using System;

namespace ClrDebug.PDB
{
#pragma warning disable CS0649
    internal struct EnumSymsVtbl
    {
        public IntPtr release;
        public IntPtr reset;
        public IntPtr next;

        public IntPtr get;
        public IntPtr prev;
        public IntPtr clone;
        public IntPtr locate;
    }
#pragma warning restore CS0649
}
