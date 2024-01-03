using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("FCCEE788-0088-454B-A811-C99F298D1942")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorProfilerMethodEnum
    {
        [PreserveSig]
        HRESULT Skip(
            [In] int celt);

        [PreserveSig]
        HRESULT Reset();

        [PreserveSig]
        HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorProfilerMethodEnum ppEnum);

        [PreserveSig]
        HRESULT GetCount(
            [Out] out int pcelt);

        [PreserveSig]
        HRESULT Next(
            [In] int celt,
            [Out] out COR_PRF_METHOD elements,
            [Out] out int pceltFetched);
    }
}
