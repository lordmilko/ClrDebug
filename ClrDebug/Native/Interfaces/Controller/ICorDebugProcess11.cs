using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("344B37AA-F2C0-4D3B-9909-91CCF787DA8C")]
    [ComImport]
    public interface ICorDebugProcess11
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateLoaderHeapMemoryRegions([MarshalAs(UnmanagedType.Interface)] out ICorDebugMemoryRangeEnum ppRanges);
    }
}
