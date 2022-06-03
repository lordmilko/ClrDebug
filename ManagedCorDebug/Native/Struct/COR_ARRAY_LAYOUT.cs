using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct COR_ARRAY_LAYOUT
    {
        public COR_TYPEID componentID;
        public uint componentType;
        public uint firstElementOffset;
        public uint elementSize;
        public uint countOffset;
        public uint rankSize;
        public uint numRanks;
        public uint rankOffset;
    }
}