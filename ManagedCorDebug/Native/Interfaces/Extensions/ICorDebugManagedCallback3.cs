using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("264EA0FC-2591-49AA-868E-835E6515323F")]
    [ComImport]
    public interface ICorDebugManagedCallback3
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CustomNotification([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain);
    }
}