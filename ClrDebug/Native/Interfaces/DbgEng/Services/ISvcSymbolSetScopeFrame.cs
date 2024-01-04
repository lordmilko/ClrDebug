using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("58B61CE1-875D-421F-BA4F-B8FFF3DE0964")]
    [ComImport]
    public interface ISvcSymbolSetScopeFrame
    {
        [PreserveSig]
        HRESULT GetContext(
            [In] SvcContextFlags contextFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext registerContext);
    }
}
