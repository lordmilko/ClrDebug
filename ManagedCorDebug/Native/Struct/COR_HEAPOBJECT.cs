using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct COR_HEAPOBJECT
    {
        public ulong address;
        public ulong size;
        public COR_TYPEID type;
    }
}