using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("C6B492DC-CBC1-4574-8E16-95BDFC06AEA0")]
    [ComImport]
    public interface ISvcWindowsKernelInfrastructure
    {
        [PreserveSig]
        HRESULT FindKpcrForProcessor(
            [In] long processorNumber,
            [Out] out long kpcrAddress);
        
        [PreserveSig]
        HRESULT FindKprcbForProcessor(
            [In] long processorNumber,
            [Out] out long kprcbAddress);
        
        [PreserveSig]
        HRESULT FindThreadForProcessor(
            [In] long processorNumber,
            [Out] out long kthreadAddress);
        
        [PreserveSig]
        HRESULT ReadContextForProcessor(
            [In] long processorNumber,
            [In] SvcContextFlags contextFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext ppRegisterContext);
        
        [PreserveSig]
        HRESULT ReadSpecialContextForProcessor(
            [In] long processorNumber,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext ppSpecialContext);
    }
}
