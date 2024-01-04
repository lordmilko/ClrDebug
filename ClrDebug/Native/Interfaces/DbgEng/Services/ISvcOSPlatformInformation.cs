using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("40B23EAC-F503-46FC-9C95-09384D050A11")]
    [ComImport]
    public interface ISvcOSPlatformInformation
    {
        [PreserveSig]
        HRESULT GetOSPlatform(
            [Out] out SvcOSPlatform pOSPlatform);
    }
}
