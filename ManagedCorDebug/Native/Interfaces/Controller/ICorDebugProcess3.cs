using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("2EE06488-C0D4-42B1-B26D-F3795EF606FB")]
    [ComImport]
    public interface ICorDebugProcess3
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetEnableCustomNotification([MarshalAs(UnmanagedType.Interface)] ICorDebugClass pClass, int fEnable);
    }
}