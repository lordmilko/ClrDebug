using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct CorDebugBlockingObject
    {
        [MarshalAs(UnmanagedType.Interface)] public ICorDebugValue pBlockingObject;
        public uint dwTimeout;
        public CorDebugBlockingReason blockingReason;
    }
}