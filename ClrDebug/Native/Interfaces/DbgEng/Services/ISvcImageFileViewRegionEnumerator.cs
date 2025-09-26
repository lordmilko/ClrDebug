using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An enumerator for "file view regions" of an executable.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A4AE6E38-E6DA-4BC8-9FC0-EC65821948E5")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISvcImageFileViewRegionEnumerator
    {
        /// <summary>
        /// Resets the enumerator.
        /// </summary>
        [PreserveSig]
        HRESULT Reset();

        /// <summary>
        /// Gets the next "file view region".
        /// </summary>
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcImageFileViewRegion ppRegion);
    }
}
