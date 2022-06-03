using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct COR_GC_REFERENCE
    {
        [MarshalAs(UnmanagedType.Interface)] public ICorDebugAppDomain Domain;
        [MarshalAs(UnmanagedType.Interface)] public ICorDebugValue Location;
        public CorGCReferenceType type;
        public ulong ExtraData;
    }
}