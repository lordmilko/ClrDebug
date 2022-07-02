using System.Runtime.InteropServices;

namespace ClrDebug
{
    [Guid("127d6abe-6c86-4e48-8e7b-220781c58101")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISOSDacInterface5
    {
        [PreserveSig]
        HRESULT GetTieredVersions(
            [In] CLRDATA_ADDRESS methodDesc,
            [In] int rejitId,
            [Out, MarshalAs(UnmanagedType.LPArray)] DacpTieredVersionData[] nativeCodeAddrs,
            [In] int cNativeCodeAddrs,
            [Out] out int pcNativeCodeAddrs);
    }
}
