using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("80450742-C0A5-4160-8430-90B2212E132C")]
    [ComImport]
    public interface ISvcSymbolDiscriminatorValuesEnumerator
    {
        [PreserveSig]
        HRESULT Reset();
        
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Struct)] out object pLowValue,
            [Out, MarshalAs(UnmanagedType.Struct)] out object pHighValue);
    }
}
