using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_SYMBOL_PARAMETERS
    {
        public ulong Module;
        public uint TypeId;
        public uint ParentSymbol;
        public uint SubElements;
        public DEBUG_SYMBOL Flags;
        public ulong Reserved;
    }
}