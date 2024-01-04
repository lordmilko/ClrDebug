using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("C809D0B1-4563-4577-BFDC-AF951FCE5308")]
    [ComImport]
    public interface ISvcOSKernelTypes
    {
        [PreserveSig]
        HRESULT GetProcessType(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol ppProcessType);
        
        [PreserveSig]
        HRESULT GetThreadType(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol ppThreadType);
        
        [PreserveSig]
        HRESULT GetModuleType(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol ppModuleType);
    }
}
