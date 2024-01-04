using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("59C0BA4E-84E8-4A2E-8874-83DF03E3CFF5")]
    [ComImport]
    public interface ISvcMachineDebug
    {
        [PreserveSig]
        HRESULT GetDefaultAddressContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcAddressContext defaultAddressContext);
        
        [PreserveSig]
        long GetNumberOfProcessors();
        
        [PreserveSig]
        HRESULT GetProcessor(
            [In] long processorNumber,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcExecutionUnit processor);
    }
}
