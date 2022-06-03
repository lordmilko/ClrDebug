using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct COR_ACTIVE_FUNCTION
    {
        [MarshalAs(UnmanagedType.Interface)] public ICorDebugAppDomain pAppDomain;
        [MarshalAs(UnmanagedType.Interface)] public ICorDebugModule pModule;
        [MarshalAs(UnmanagedType.Interface)] public ICorDebugFunction2 pFunction;
        public uint ilOffset;
        public uint flags;
    }
}