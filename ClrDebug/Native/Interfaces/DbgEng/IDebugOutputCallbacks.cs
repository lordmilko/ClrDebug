using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("4bf58045-d654-4c40-b0af-683090f356dc")]
    [ComImport]
    public interface IDebugOutputCallbacks
    {
        [PreserveSig]
        HRESULT Output(
            [In] DEBUG_OUTPUT mask,
            [In, MarshalAs(UnmanagedType.LPStr)] string text);
    }
}
