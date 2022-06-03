using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct COR_HEAPINFO
    {
        public int areGCStructuresValid;
        public uint pointerSize;
        public uint numHeaps;
        public int concurrent;
        public CorDebugGCType gcType;
    }
}