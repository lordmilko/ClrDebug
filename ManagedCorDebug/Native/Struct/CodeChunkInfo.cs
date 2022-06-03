using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct CodeChunkInfo
    {
        public ulong startAddr;
        public uint length;
    }
}