using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("AF79EC94-4752-419C-A626-5FB1CC1A5AB7")]
    [ComImport]
    public interface ICorDebugExceptionDebugEvent : ICorDebugDebugEvent
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetEventKind(out CorDebugDebugEventKind pDebugEventKind);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT GetThread([MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetStackPointer(out ulong pStackPointer);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetNativeIP(out ulong pIP);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetFlags(out CorDebugExceptionFlags pdwFlags);
    }
}