using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E184675D-EBF8-46E0-BC60-514378AF6F35")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISvcConnectableProcessEnumerator
    {
        /// <summary>
        /// Resets the enumerator to the first process.
        /// </summary>
        [PreserveSig]
        HRESULT Reset();

        /// <summary>
        /// Gets the next connectable process in the list.
        /// </summary>
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcConnectableProcess connectableProcess);
    }
}
