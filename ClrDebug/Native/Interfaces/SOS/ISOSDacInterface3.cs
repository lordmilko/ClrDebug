using System.Runtime.InteropServices;

namespace ClrDebug
{
    [Guid("B08C5CDC-FD8A-49C5-AB38-5FEEF35235B4")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISOSDacInterface3
    {
        [PreserveSig]
        HRESULT GetGCInterestingInfoData(
            [In] CLRDATA_ADDRESS interestingInfoAddr,
            [Out] out DacpGCInterestingInfoData data);

        [PreserveSig]
        HRESULT GetGCInterestingInfoStaticData(
            [Out] out DacpGCInterestingInfoData data);

        [PreserveSig]
        HRESULT GetGCGlobalMechanisms(
            [Out, MarshalAs(UnmanagedType.LPArray)] long[] globalMechanisms);
    }
}
