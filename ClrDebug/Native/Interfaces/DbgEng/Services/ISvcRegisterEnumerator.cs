using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("AE8EC624-52F6-43A4-BBAB-57A6C1C393C3")]
    [ComImport]
    public interface ISvcRegisterEnumerator
    {
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterInformation registerInfo);
        
        [PreserveSig]
        HRESULT Reset();
    }
}
