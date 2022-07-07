using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("4c7fd663-c394-4e26-8ef1-34ad5ed3764c")]
    [ComImport]
    public interface IDebugOutputCallbacksWide
    {
        [PreserveSig]
        HRESULT Output(
            [In] DEBUG_OUTPUT mask,
            [In, MarshalAs(UnmanagedType.LPWStr)] string text);
    }
}
