using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("96BA1DB9-14CD-4492-8065-1CAAECF6E5CF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ISOSDacInterface11
    {
        [PreserveSig]
        HRESULT IsTrackedType(
            [In] CLRDATA_ADDRESS objAddr,
            [Out] out int isTrackedType,
            [Out] out int hasTaggedMemory);

        [PreserveSig]
        HRESULT GetTaggedMemory(
            [In] CLRDATA_ADDRESS objAddr,
            [Out] out CLRDATA_ADDRESS taggedMemory,
            [Out] out long taggedMemorySizeInBytes);
    }
}
