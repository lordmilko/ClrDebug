using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct UNLOAD_DLL_DEBUG_INFO
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal string DebuggerDisplay => $"lpBaseOfDll = 0x{((ulong)(void*)lpBaseOfDll):X}";

        public IntPtr lpBaseOfDll;
    }
}
