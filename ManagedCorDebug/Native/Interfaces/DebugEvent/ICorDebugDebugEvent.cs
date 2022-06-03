using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("41BD395D-DE99-48F1-BF7A-CC0F44A6D281")]
    [ComImport]
    public interface ICorDebugDebugEvent
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetEventKind(out CorDebugDebugEventKind pDebugEventKind);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetThread([MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);
    }
}