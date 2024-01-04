using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("BE5E232C-1D4B-4983-A520-383DA865DA1C")]
    [ComImport]
    public interface ISvcContextTranslation
    {
        [PreserveSig]
        HRESULT GetTranslatedContext(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcExecutionUnit execUnit,
            [In] SvcContextFlags contextFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext context);
        
        [PreserveSig]
        HRESULT SetTranslatedContext(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcExecutionUnit execUnit,
            [In] SvcContextFlags contextFlags,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext context);
    }
}
