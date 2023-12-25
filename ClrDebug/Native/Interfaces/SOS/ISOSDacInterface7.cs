using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    [Guid("c1020dde-fe98-4536-a53b-f35a74c327eb")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISOSDacInterface7
    {
        [PreserveSig]
        HRESULT GetPendingReJITID(
            [In] CLRDATA_ADDRESS methodDesc,
            [Out] out int pRejitId);

        [PreserveSig]
        HRESULT GetReJITInformation(
            [In] CLRDATA_ADDRESS methodDesc,
            [In] int rejitId,
            [Out] out DacpReJitData2 pRejitData);

        [PreserveSig]
        HRESULT GetProfilerModifiedILInformation(
            [In] CLRDATA_ADDRESS methodDesc,
            [Out] out DacpProfilerILData pILData);

        [PreserveSig]
        HRESULT GetMethodsWithProfilerModifiedIL(
            [In] CLRDATA_ADDRESS mod,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] CLRDATA_ADDRESS[] methodDescs,
            [In] int cMethodDescs,
            [Out] out int pcMethodDescs);
    }
}
