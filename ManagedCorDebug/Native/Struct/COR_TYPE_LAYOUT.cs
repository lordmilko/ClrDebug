using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct COR_TYPE_LAYOUT
    {
        public COR_TYPEID parentID;
        public uint objectSize;
        public uint numFields;
        public uint boxOffset;
        public uint type;
    }
}