using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E327A72A-65D9-4545-9304-09F0104BB138")]
    [ComImport]
    public interface ISvcMemoryRegion
    {
        [PreserveSig]
        HRESULT GetRange(
            [Out] out SvcAddressRange Range);
        
        [PreserveSig]
        HRESULT IsReadable(
            [Out, MarshalAs(UnmanagedType.U1)] out bool IsReadable);
        
        [PreserveSig]
        HRESULT IsWriteable(
            [Out, MarshalAs(UnmanagedType.U1)] out bool IsWriteable);
        
        [PreserveSig]
        HRESULT IsExecutable(
            [Out, MarshalAs(UnmanagedType.U1)] out bool IsExecutable);
    }
}
