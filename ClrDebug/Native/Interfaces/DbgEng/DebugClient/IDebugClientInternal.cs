using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0995BEC6-8A12-453d-A694-09CD2712BDD7")]
    [ComImport]
    public interface IDebugClientInternal
    {
        [PreserveSig]
        HRESULT OpenProtocolConnectionWide(
            [MarshalAs(UnmanagedType.LPWStr), In] string protocolString);
    }
}
