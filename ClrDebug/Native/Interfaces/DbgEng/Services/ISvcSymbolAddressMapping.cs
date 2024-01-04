using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D2513438-18DA-4360-8242-49E0638FB2A4")]
    [ComImport]
    public interface ISvcSymbolAddressMapping
    {
        [PreserveSig]
        HRESULT GetAddressRange(
            [Out] out SvcAddressRange addressRange);
        
        [PreserveSig]
        HRESULT EnumerateAddressRanges(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcAddressRangeEnumerator rangeEnum);
    }
}
