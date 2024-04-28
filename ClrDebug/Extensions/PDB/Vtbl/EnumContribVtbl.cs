using System;

namespace ClrDebug.PDB
{
#pragma warning disable CS0649
    internal struct EnumContribVtbl
    {
        public IntPtr release;
        public IntPtr reset;
        public IntPtr next;

        public IntPtr get;
        public IntPtr getCrcs;
        public IntPtr fUpdate;
        public IntPtr prev;
        public IntPtr clone;
        public IntPtr locate;
        public IntPtr get2;
    }
#pragma warning restore CS0649
}
