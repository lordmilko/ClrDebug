using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [DebuggerDisplay("Base = {Base}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_LAST_EVENT_INFO_LOAD_MODULE
    {
        public ulong Base;
    }
}
