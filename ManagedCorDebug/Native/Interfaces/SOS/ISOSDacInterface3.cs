using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("B08C5CDC-FD8A-49C5-AB38-5FEEF35235B4")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISOSDacInterface3
    {
        [PreserveSig]
        HRESULT GetGCInterestingInfoData(
            CLRDATA_ADDRESS interestingInfoAddr,
            out DacpGCInterestingInfoData data);

        [PreserveSig]
        HRESULT GetGCInterestingInfoStaticData(
            out DacpGCInterestingInfoData data);

        [PreserveSig]
        HRESULT GetGCGlobalMechanisms(
            [Out, MarshalAs(UnmanagedType.LPArray)] long[] globalMechanisms);
    }
}
