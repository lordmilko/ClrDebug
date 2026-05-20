using System;

namespace ClrDebug.PDB
{
#pragma warning disable CS0649
    internal struct EnumThunkVtbl
    {
        public IntPtr release;
        public IntPtr reset;
        public IntPtr next;

        public IntPtr get;
    }
#pragma warning restore CS0649
}
