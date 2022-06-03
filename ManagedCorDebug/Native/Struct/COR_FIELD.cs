using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct COR_FIELD
    {
        public uint token;
        public uint offset;
        public COR_TYPEID id;
        public uint fieldType;
    }
}