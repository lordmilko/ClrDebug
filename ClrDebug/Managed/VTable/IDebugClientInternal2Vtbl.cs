using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng.Vtbl
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct IDebugClientInternal2Vtbl
    {
        public readonly IntPtr OpenProtocolConnectionWide;
        public readonly IntPtr OpenProtocolConnectionWide2;
    }
}
