using System;

namespace ClrDebug.PDB
{
#pragma warning disable CS0649
    internal struct EnumLinesVtbl
    {
        public IntPtr release;
        public IntPtr reset;
        public IntPtr next;
        public IntPtr getLines;
        public IntPtr getLinesColumns;
        public IntPtr clone;
    }
#pragma warning restore CS0649
}
