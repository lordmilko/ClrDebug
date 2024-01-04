using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("7B6FABD4-D271-413A-8475-31F8483179FD")]
    [ComImport]
    public interface ISvcOSPlatformInformation2 : ISvcOSPlatformInformation
    {
        [PreserveSig]
        new HRESULT GetOSPlatform(
            [Out] out SvcOSPlatform pOSPlatform);
        
        [PreserveSig]
        HRESULT GetOSVersion(
            [Out] out short pMajor,
            [Out] out short pMinor,
            [Out] out short pBuild,
            [Out] out short pRevision);
        
        [PreserveSig]
        HRESULT GetOSBuildLab(
            [Out, MarshalAs(UnmanagedType.BStr)] out string pBuildLab);
    }
}
