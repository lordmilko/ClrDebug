using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("1A1F204B-1C66-4637-823F-3EE6C744A69C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugThread4
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void HasUnhandledException();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetBlockingObjects(
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugBlockingObjectEnum ppBlockingObjectEnum);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetCurrentCustomDebuggerNotification(
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppNotificationObject);
    }
}