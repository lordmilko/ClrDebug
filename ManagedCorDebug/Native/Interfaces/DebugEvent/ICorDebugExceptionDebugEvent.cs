using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("AF79EC94-4752-419C-A626-5FB1CC1A5AB7")]
    [ComImport]
    public interface ICorDebugExceptionDebugEvent : ICorDebugDebugEvent
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetEventKind(out CorDebugDebugEventKind pDebugEventKind);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetThread([MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetStackPointer(out ulong pStackPointer);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetNativeIP(out ulong pIP);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetFlags(out CorDebugExceptionFlags pdwFlags);
    }
}