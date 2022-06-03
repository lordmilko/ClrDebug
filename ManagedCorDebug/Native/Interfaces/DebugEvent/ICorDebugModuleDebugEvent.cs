using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("51A15E8D-9FFF-4864-9B87-F4FBDEA747A2")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugModuleDebugEvent : ICorDebugDebugEvent
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetEventKind(out CorDebugDebugEventKind pDebugEventKind);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetThread([MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetModule([MarshalAs(UnmanagedType.Interface)] out ICorDebugModule ppModule);
    }
}