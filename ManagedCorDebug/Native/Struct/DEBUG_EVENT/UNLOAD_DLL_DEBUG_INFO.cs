using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct UNLOAD_DLL_DEBUG_INFO
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal string DebuggerDisplay => $"lpBaseOfDll = {lpBaseOfDll}";

        public IntPtr lpBaseOfDll;
    }
}
