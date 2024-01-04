using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("01C932D4-9F5E-4268-8B12-EC246582A82D")]
    [ComImport]
    public interface ISvcExecutionUnit
    {
        [PreserveSig]
        HRESULT GetContext(
            [In] SvcContextFlags contextFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext ppRegisterContext);
        
        [PreserveSig]
        HRESULT SetContext(
            [In] SvcContextFlags contextFlags,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext pRegisterContext);
    }
}
