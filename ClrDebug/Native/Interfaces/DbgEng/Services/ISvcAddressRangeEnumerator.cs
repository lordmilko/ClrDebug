using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("A7DF185B-CBBF-4B0D-BBA6-C58D6F9240C0")]
    [ComImport]
    public interface ISvcAddressRangeEnumerator
    {
        [PreserveSig]
        HRESULT Reset();
        
        [PreserveSig]
        HRESULT GetNext(
            [Out] out SvcAddressRange pAddressRange);
    }
}
