using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Supports the debug output stream.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("7782D8F2-2B85-4059-AB88-28CEDDCA1C80")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDebugOutputStream
    {
        /// <summary>
        /// Writes to the debug output stream.
        /// </summary>
        /// <param name="text">[in] A pointer to a Unicode character string of content to write.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        [PreserveSig]
        HRESULT Write(
            [MarshalAs(UnmanagedType.LPWStr), In] string text);
    }
}
