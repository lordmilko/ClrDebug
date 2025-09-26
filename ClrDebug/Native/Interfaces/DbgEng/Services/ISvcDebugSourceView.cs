using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("52276F45-1CA1-4C47-8DC5-426AE90D7A26")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISvcDebugSourceView
    {
        /// <summary>
        /// Gets the the source of this view.
        /// </summary>
        [PreserveSig]
        HRESULT GetViewSource(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceManager viewSource);
    }
}
