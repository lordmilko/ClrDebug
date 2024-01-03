using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("286CA186-E763-4F61-9760-487D43AE4341")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISOSEnum
    {
        [PreserveSig]
        HRESULT Skip(
            [In] int count);

        [PreserveSig]
        HRESULT Reset();

        [PreserveSig]
        HRESULT GetCount(
            [Out] out int pCount);
    }
}
