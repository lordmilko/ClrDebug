using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_OS_KERNELLOCATOR.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("995F51EF-FE22-441E-BCE6-0F6FECFB9A0A")]
    [ComImport]
    public interface ISvcOSKernelLocator
    {
        /// <summary>
        /// Gets the base address of the kernel.
        /// </summary>
        [PreserveSig]
        HRESULT GetKernelBase(
            [Out] out long pKernelBase);

        /// <summary>
        /// Creates the component aggregate for whatever operating system kernel was identified.
        /// </summary>
        [PreserveSig]
        HRESULT CreateOSKernelComponent(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceLayer ppServiceLayer);
    }
}
