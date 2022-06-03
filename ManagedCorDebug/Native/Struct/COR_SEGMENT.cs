using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct COR_SEGMENT
    {
        public ulong start;
        public ulong end;
        public CorDebugGenerationTypes type;
        public uint heap;
    }
}