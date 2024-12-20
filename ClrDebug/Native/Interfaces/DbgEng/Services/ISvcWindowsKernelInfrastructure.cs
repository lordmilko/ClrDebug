using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("C6B492DC-CBC1-4574-8E16-95BDFC06AEA0")]
    [ComImport]
    public interface ISvcWindowsKernelInfrastructure
    {
        /// <summary>
        /// Finds the KPCR for a given processor.
        /// </summary>
        [PreserveSig]
        HRESULT FindKpcrForProcessor(
            [In] long processorNumber,
            [Out] out long kpcrAddress);

        /// <summary>
        /// Finds the KPRCB for a given processor.
        /// </summary>
        [PreserveSig]
        HRESULT FindKprcbForProcessor(
            [In] long processorNumber,
            [Out] out long kprcbAddress);

        /// <summary>
        /// Finds the KTHREAD which is executing on a given processor.
        /// </summary>
        [PreserveSig]
        HRESULT FindThreadForProcessor(
            [In] long processorNumber,
            [Out] out long kthreadAddress);

        /// <summary>
        /// Reads a context record from the KPRCB for a given processor.
        /// </summary>
        [PreserveSig]
        HRESULT ReadContextForProcessor(
            [In] long processorNumber,
            [In] SvcContextFlags contextFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext ppRegisterContext);

        /// <summary>
        /// Reads the special registers from the KPRCB for a given processor.
        /// </summary>
        [PreserveSig]
        HRESULT ReadSpecialContextForProcessor(
            [In] long processorNumber,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext ppSpecialContext);
    }
}
