using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("1C4D9A4B-702D-4CF6-B290-1DB6F43050D0")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IXCLRDataFrame2
    {
        [PreserveSig]
        HRESULT GetExactGenericArgsToken(
            [Out] out IXCLRDataValue genericToken);
    }
}
