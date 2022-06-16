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
            CLRDATA_ADDRESS objAddr,
            out int isTrackedType,
            out int hasTaggedMemory);

        [PreserveSig]
        HRESULT GetTaggedMemory(
            CLRDATA_ADDRESS objAddr,
            out CLRDATA_ADDRESS taggedMemory,
            out long taggedMemorySizeInBytes);
    }
}
