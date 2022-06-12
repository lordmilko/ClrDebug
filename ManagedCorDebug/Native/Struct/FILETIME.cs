using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct FILETIME
    {
        public int dwLowDateTime;
        public int dwHighDateTime;
    }
}