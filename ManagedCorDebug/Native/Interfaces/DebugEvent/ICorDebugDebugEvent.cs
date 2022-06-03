using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("41BD395D-DE99-48F1-BF7A-CC0F44A6D281")]
    [ComImport]
    public interface ICorDebugDebugEvent
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetEventKind(out CorDebugDebugEventKind pDebugEventKind);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetThread([MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);
    }
}