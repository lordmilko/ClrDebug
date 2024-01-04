using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("ABE84A4B-1EA3-4058-B875-A1D69A7BB3FE")]
    [ComImport]
    public interface ISvcModuleEnumerator
    {
        [PreserveSig]
        HRESULT Reset();
        
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModule targetModule);
    }
}
