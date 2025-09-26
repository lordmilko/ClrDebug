using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FF85423A-3B47-4205-8D0C-3F28F47FF3D7")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISvcProcessEnumerator
    {
        /// <summary>
        /// Resets the enumerator.
        /// </summary>
        [PreserveSig]
        HRESULT Reset();

        /// <summary>
        /// Gets the next process from the enumerator.
        /// </summary>
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcProcess targetProcess);
    }
}
