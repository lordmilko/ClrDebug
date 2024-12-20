using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_OS_INFORMATION.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("7B6FABD4-D271-413A-8475-31F8483179FD")]
    [ComImport]
    public interface ISvcOSPlatformInformation2 : ISvcOSPlatformInformation
    {
        /// <summary>
        /// Gets the high level infromation about the platform that the target is running on. A component which runs on a platform that is not described by SvcOSPlatform may return SvcOSPlatUnknown.
        /// </summary>
        [PreserveSig]
        new HRESULT GetOSPlatform(
            [Out] out SvcOSPlatform pOSPlatform);

        /// <summary>
        /// Gets the 1-4 digit version of the platform. When digits are not appropriate for the platform, use a 0 default. If the implementation cannot make a determination of the OS Version Number, E_NOT_SET may legally be returned.<para/>
        /// If the implementation doesn't support the concept of an OS Version Number, E_NOTIMPL may legally be returned.
        /// </summary>
        [PreserveSig]
        HRESULT GetOSVersion(
            [Out] out short pMajor,
            [Out] out short pMinor,
            [Out] out short pBuild,
            [Out] out short pRevision);

        /// <summary>
        /// Gets the string that represents the Build Lab (environment) that built this version of the platform. If the implementation cannot make a determination of the Build Lab, E_NOT_SET may legally be returned.<para/>
        /// If the implementation doesn't support the concept of a Build Lab, E_NOTIMPL may legally be returned.
        /// </summary>
        [PreserveSig]
        HRESULT GetOSBuildLab(
            [Out, MarshalAs(UnmanagedType.BStr)] out string pBuildLab);
    }
}
