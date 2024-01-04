using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("56373E0F-D615-487F-95B9-37931E2A9A90")]
    [ComImport]
    public interface ISvcMemoryTranslation
    {
        [PreserveSig]
        HRESULT TranslateAddress(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext addressContext,
            [In] long offset,
            [In] long contiguousByteCount,
            [Out] out long translatedOffset,
            [Out] out long translatedContiguousByteCount,
            [Out] out long translationEntry);
    }
}
