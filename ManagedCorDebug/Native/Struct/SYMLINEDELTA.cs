using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct SYMLINEDELTA
    {
        public uint mdMethod;
        public int delta;
    }
}