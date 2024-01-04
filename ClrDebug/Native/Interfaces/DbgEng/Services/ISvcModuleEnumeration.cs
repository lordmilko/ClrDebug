using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("20D4BA1D-BE37-4DC4-9F6A-90E3C373200E")]
    [ComImport]
    public interface ISvcModuleEnumeration
    {
        [PreserveSig]
        HRESULT FindModule(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess process,
            [In] long moduleKey,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModule targetModule);
        
        [PreserveSig]
        HRESULT FindModuleAtAddress(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess process,
            [In] long moduleAddress,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModule targetModule);
        
        [PreserveSig]
        HRESULT EnumerateModules(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess process,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModuleEnumerator targetModuleEnumerator);
    }
}
