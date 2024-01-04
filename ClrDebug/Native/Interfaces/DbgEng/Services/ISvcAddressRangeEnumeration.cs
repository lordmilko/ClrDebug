using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A4D7D798-A4C1-40AD-9235-B80F0BF8E2AD")]
    [ComImport]
    public interface ISvcAddressRangeEnumeration
    {
        [PreserveSig]
        HRESULT EnumerateAddressRanges(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcAddressRangeEnumerator ppEnum);
    }
}
