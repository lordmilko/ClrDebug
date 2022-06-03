using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct COR_TYPEID
    {
        public ulong token1;
        public ulong token2;
    }
}