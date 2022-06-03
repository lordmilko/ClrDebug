using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("AE4CA65D-59DD-42A2-83A5-57E8A08D8719")]
    [ComImport]
    public interface ICorDebugExceptionObjectValue
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateExceptionCallStack(
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugExceptionObjectCallStackEnum ppCallStackEnum);
    }
}