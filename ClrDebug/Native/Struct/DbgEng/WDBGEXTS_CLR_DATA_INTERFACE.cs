using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WDBGEXTS_CLR_DATA_INTERFACE
    {
        public IntPtr Iid;
        public IntPtr Iface;
    }
}
