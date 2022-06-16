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
            CLRDATA_ADDRESS objAddr,
            out DacpExceptionObjectData data);

        [PreserveSig]
        HRESULT IsRCWDCOMProxy(
            CLRDATA_ADDRESS rcwAddr,
            out int isDCOMProxy);
    }
}
