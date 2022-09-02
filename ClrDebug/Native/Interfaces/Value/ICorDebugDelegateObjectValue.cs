using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [Guid("3AF70CC7-6047-47F6-A5C5-090A1A622638")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugDelegateObjectValue
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetTarget(
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugReferenceValue ppObject);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetFunction(
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction);
    }
}
