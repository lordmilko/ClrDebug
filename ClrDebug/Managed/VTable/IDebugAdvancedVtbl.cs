using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng.Vtbl
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct IDebugAdvancedVtbl
    {
        public readonly IntPtr GetThreadContext;
        public readonly IntPtr SetThreadContext;
    }
}
