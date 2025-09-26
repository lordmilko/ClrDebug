using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_OS_INFORMATION.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("40B23EAC-F503-46FC-9C95-09384D050A11")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ISvcOSPlatformInformation
    {
        /// <summary>
        /// Gets the high level infromation about the platform that the target is running on. A component which runs on a platform that is not described by SvcOSPlatform may return SvcOSPlatUnknown.
        /// </summary>
        [PreserveSig]
        HRESULT GetOSPlatform(
            [Out] out SvcOSPlatform pOSPlatform);
    }
}
