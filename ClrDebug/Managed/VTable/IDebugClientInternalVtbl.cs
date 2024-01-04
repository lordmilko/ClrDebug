using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng.Vtbl
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct IDebugClientInternalVtbl
    {
        public readonly IntPtr OpenProtocolConnectionWide;
    }
}
