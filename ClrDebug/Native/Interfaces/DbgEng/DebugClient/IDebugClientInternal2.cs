using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FFFB5A2D-49C9-4530-9226-7A6BCA1D6856")]
    [ComImport]
    public interface IDebugClientInternal2 : IDebugClientInternal
    {
        [PreserveSig]
        new HRESULT OpenProtocolConnectionWide(
            [MarshalAs(UnmanagedType.LPWStr), In] string protocolString);

        [PreserveSig]
        HRESULT OpenProtocolConnectionWide2(
            [MarshalAs(UnmanagedType.LPWStr), In] string protocolString,
            [Out] out ProtocolConnectionKind connectionKind,
            [Out] out int systemId,
            [Out] out long server);
    }
}
