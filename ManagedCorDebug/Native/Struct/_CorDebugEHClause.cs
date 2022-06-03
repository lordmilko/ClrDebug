using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct _CorDebugEHClause
    {
        public uint flags;
        public uint TryOffset;
        public uint TryLength;
        public uint HandlerOffset;
        public uint HandlerLength;
        public uint ClassToken;
        public uint FilterOffset;
    }
}