using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("4eca42d8-7e7b-4c8a-a116-7bfbf6929267")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISOSDacInterface9
    {
        [PreserveSig]
        HRESULT GetBreakingChangeVersion(
            [Out] out int pVersion);
    }
}
