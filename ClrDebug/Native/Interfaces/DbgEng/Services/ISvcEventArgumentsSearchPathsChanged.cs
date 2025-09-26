using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("996F652A-C052-413E-9406-87884D24FA1D")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISvcEventArgumentsSearchPathsChanged
    {
        [PreserveSig]
        HRESULT GetAllPaths(
            [Out, MarshalAs(UnmanagedType.BStr)] out string searchPaths);
    }
}
