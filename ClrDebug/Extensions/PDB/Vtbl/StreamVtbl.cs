using System;

namespace ClrDebug.PDB
{
#pragma warning disable CS0649
    internal struct StreamVtbl
    {
        public IntPtr QueryCb;
        public IntPtr Read;
        public IntPtr Write;
        public IntPtr Replace;
        public IntPtr Append;
        public IntPtr Delete;
        public IntPtr Release;
        public IntPtr Read2;
        public IntPtr Truncate;
    }
#pragma warning restore CS0649
}
