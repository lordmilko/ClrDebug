using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct _COR_HEAPOBJECT
    {
        public ulong address;
        public ulong size;
        public COR_TYPEID type;
    }
}