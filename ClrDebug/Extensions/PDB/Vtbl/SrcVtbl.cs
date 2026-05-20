using System;

namespace ClrDebug.PDB
{
#pragma warning disable CS0649
    internal struct SrcVtbl
    {
        public IntPtr Close;
        public IntPtr Add;
        public IntPtr Remove;
        public IntPtr QueryByName;
        public IntPtr GetData;
        public IntPtr GetEnum;
        public IntPtr GetHeaderBlock;
        public IntPtr RemoveW;
        public IntPtr QueryByNameW;
        public IntPtr AddW;
    }
#pragma warning restore CS0649
}
