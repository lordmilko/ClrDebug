using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("51A15E8D-9FFF-4864-9B87-F4FBDEA747A2")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugModuleDebugEvent : ICorDebugDebugEvent
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetEventKind(out CorDebugDebugEventKind pDebugEventKind);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void GetThread([MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetModule([MarshalAs(UnmanagedType.Interface)] out ICorDebugModule ppModule);
    }
}