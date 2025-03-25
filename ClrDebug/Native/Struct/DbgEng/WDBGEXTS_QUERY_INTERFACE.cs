using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [DebuggerDisplay("Iid = {Iid.ToString(),nq}, Iface = {Iface.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct WDBGEXTS_QUERY_INTERFACE
    {
        public IntPtr Iid;
        public IntPtr Iface;
    }
}
