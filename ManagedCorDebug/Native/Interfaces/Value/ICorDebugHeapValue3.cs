using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A69ACAD8-2374-46E9-9FF8-B1F14120D296")]
    [ComImport]
    public interface ICorDebugHeapValue3
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetThreadOwningMonitorLock([MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread,
            out uint pAcquisitionCount);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetMonitorEventWaitList([MarshalAs(UnmanagedType.Interface)] out ICorDebugThreadEnum ppThreadEnum);
    }
}