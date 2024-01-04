using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("F4A035C0-4CA0-4B6D-BFD2-B378A0DBFE4C")]
    [ComImport]
    public interface IDebugHostTaggedUnionRangeEnumerator
    {
        [PreserveSig]
        HRESULT Reset();
        
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Struct)] out object pLow,
            [Out, MarshalAs(UnmanagedType.Struct)] out object pHigh);
        
        [PreserveSig]
        HRESULT GetCount(
            [Out] out int pCount);
    }
}
