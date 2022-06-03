using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct CorDebugExceptionObjectStackFrame
    {
        [MarshalAs(UnmanagedType.Interface)] public ICorDebugModule pModule;
        public ulong ip;
        public uint methodDef;
        public int isLastForeignExceptionFrame;
    }
}