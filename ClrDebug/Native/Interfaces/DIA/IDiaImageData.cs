using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DIA
{
    /// <summary>
    /// Exposes the details of the base location and memory offsets of the module or image.
    /// </summary>
    /// <remarks>
    /// Some debug streams (XDATA, PDATA) contain copies of data also stored in the image. These stream data objects can
    /// be queried for the IDiaImageData interface. See the "Notes for Callers" section in this topic for details. Obtain
    /// this interface by calling QueryInterface on an <see cref="IDiaEnumDebugStreamData"/> object. Note that not all
    /// debug streams support the IDiaImageData interface. For example, currently only the XDATA and PDATA streams support
    /// the IDiaImageData interface.
    /// </remarks>
    [Guid("C8E40ED2-A1D9-4221-8692-3CE661184B44")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDiaImageData
    {
        /// <summary>
        /// Retrieves the location in virtual memory of the module relative to the application.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the relative virtual memory offset of the module.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_relativeVirtualAddress(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves the location in virtual memory of the image.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the virtual address of the image.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_virtualAddress(
            [Out] out long pRetVal);

        /// <summary>
        /// Retrieves the memory location where the image should be based.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the suggested image base value.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// Due to image base conflicts, an image may be rebased automatically to an unused memory location when it is loaded.
        /// This method returns the base hint (suggested memory location) that was stored in the module at compile time.
        /// </remarks>
        [PreserveSig]
        HRESULT get_imageBase(
            [Out] out long pRetVal);
    }
}
