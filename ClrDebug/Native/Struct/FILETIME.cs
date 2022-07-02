using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("dwLowDateTime = {dwLowDateTime}, dwHighDateTime = {dwHighDateTime}")]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct FILETIME
    {
        public int dwLowDateTime;
        public int dwHighDateTime;
    }
}
