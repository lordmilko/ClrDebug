using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif
using static ClrDebug.Extensions;

namespace ClrDebug
{
    [Guid("B08C5CDC-FD8A-49C5-AB38-5FEEF35235B4")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISOSDacInterface3
    {
        [PreserveSig]
        HRESULT GetGCInterestingInfoData(
            [In] CLRDATA_ADDRESS interestingInfoAddr,
            [Out] out DacpGCInterestingInfoData data);

        [PreserveSig]
        HRESULT GetGCInterestingInfoStaticData(
            [Out] out DacpGCInterestingInfoData data);

        //This method expects an array with DAC_MAX_GLOBAL_GC_MECHANISMS_COUNT (6) items to be passed to it.
        //This is automatically handled by DacpGCInterestingInfoData
        [PreserveSig]
        HRESULT GetGCGlobalMechanisms(
            [In, MarshalAs(UnmanagedType.LPArray, SizeConst = DAC_MAX_GLOBAL_GC_MECHANISMS_COUNT)] long[] globalMechanisms);
    }
}
