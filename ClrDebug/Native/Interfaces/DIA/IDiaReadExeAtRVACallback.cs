using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DIA
{
    /// <summary>
    /// Enables a client application to supply bytes of an executable file as specified by a relative virtual address.
    /// </summary>
    /// <remarks>
    /// The client application implements this interface in order to provide the bytes of the executable using a relative
    /// virtual address into the executable's file. To use an absolute file offset, implement the IDiaReadExeAtOffsetCallback
    /// interface. This method is implemented by the client application and passed to the IDiaDataSource method as an alternative
    /// method for reading the file.
    /// </remarks>
    [Guid("8E3F80CA-7517-432A-BA07-285134AAEA8E")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDiaReadExeAtRVACallback
    {
        /// <summary>
        /// Reads the specified number of bytes starting at the specified relative virtual address (RVA) from the executable file.
        /// </summary>
        /// <param name="relativeVirtualAddress">[in] The RVA in the executable file to begin reading.</param>
        /// <param name="cbData">[in] Number of bytes to read.</param>
        /// <param name="pcbData">[out] Returns the number of bytes read.</param>
        /// <param name="pbData">[in, out] An array that is filled in with bytes read from the file.</param>
        /// <remarks>
        /// This method is called by the DIA support code to load data bytes from an executable using a relative virtual address.
        /// This method is called in support of the IDiaDataSource method.
        /// </remarks>
        [PreserveSig]
        HRESULT ReadExecutableAtRVA(
            [In] int relativeVirtualAddress,
            [In] int cbData,
            [Out] out int pcbData,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] byte[] pbData);
    }
}
