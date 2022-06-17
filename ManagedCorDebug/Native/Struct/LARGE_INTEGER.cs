using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [DebuggerDisplay("QuadPart = {QuadPart}")]
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct LARGE_INTEGER
    {
        public long QuadPart;
    }
}
