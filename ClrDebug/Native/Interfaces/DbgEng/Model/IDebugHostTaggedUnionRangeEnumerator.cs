using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("F4A035C0-4CA0-4B6D-BFD2-B378A0DBFE4C")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDebugHostTaggedUnionRangeEnumerator
    {
        [PreserveSig]
        HRESULT Reset();
        
        [PreserveSig]
        HRESULT GetNext(
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(VariantMarshaller))]
#endif
            [Out] out object pLow,
#if GENERATED_MARSHALLING
            [MarshalUsing(typeof(VariantMarshaller))]
#endif
            [Out] out object pHigh);
        
        [PreserveSig]
        HRESULT GetCount(
            [Out] out int pCount);
    }
}
