using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("127d6abe-6c86-4e48-8e7b-220781c58101")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISOSDacInterface5
    {
        [PreserveSig]
        HRESULT GetTieredVersions(
            CLRDATA_ADDRESS methodDesc,
            int rejitId,
            [Out, MarshalAs(UnmanagedType.LPArray)] DacpTieredVersionData[] nativeCodeAddrs,
            int cNativeCodeAddrs,
            out int pcNativeCodeAddrs);
    }
}
