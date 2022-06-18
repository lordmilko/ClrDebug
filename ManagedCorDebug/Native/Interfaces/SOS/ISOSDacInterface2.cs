using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [ Guid("A16026EC-96F4-40BA-87FB-5575986FB7AF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISOSDacInterface2
    {
        [PreserveSig]
        HRESULT GetObjectExceptionData(
            [In] CLRDATA_ADDRESS objAddr,
            [Out] out DacpExceptionObjectData data);

        [PreserveSig]
        HRESULT IsRCWDCOMProxy(
            [In] CLRDATA_ADDRESS rcwAddr,
            [Out] out int isDCOMProxy);
    }
}
