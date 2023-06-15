using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct LOAD_DLL_DEBUG_INFO
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal string DebuggerDisplay => $"lpBaseOfDll = 0x{((ulong)(void*)lpBaseOfDll):X}";

        public IntPtr hFile;
        public IntPtr lpBaseOfDll;
        public int dwDebugInfoFileOffset;
        public int nDebugInfoSize;

        //This name is either null, or points to an address in the target process, that itself is either null or points to the actual name
        public IntPtr lpImageName;
        public short fUnicode;
    }
}
