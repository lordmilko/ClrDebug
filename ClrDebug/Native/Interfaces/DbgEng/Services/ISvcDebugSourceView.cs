using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("52276F45-1CA1-4C47-8DC5-426AE90D7A26")]
    [ComImport]
    public interface ISvcDebugSourceView
    {
        [PreserveSig]
        HRESULT GetViewSource(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugServiceManager viewSource);
    }
}
