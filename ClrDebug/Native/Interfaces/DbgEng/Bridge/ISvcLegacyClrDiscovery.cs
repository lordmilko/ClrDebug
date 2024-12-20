using System;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Private bridge interface to the existing mechanism of DAC discovery for processes utilizing the CLR.<para/>
    /// That's a significant refactor that is not yet happening in order to get better CLR symbol support.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("1BD06C4B-4E39-4517-B984-179B806A2705")]
    [ComImport]
    public interface ISvcLegacyClrDiscovery
    {
        /// <summary>
        /// Locates the appropriate DAC for the given process.
        /// </summary>
        [PreserveSig]
        HRESULT LocateDacForProcess(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess process,
            [Out, MarshalAs(UnmanagedType.BStr)] out string dacPath,
            [In, MarshalAs(UnmanagedType.LPWStr)] string requestedModuleName,
            [In] int requestedModuleTimeStamp,
            [In] int requestedModuleSize);

        /// <summary>
        /// Locates the appropriate DBI for the given process.
        /// </summary>
        [PreserveSig]
        HRESULT LocateDbiForProcess(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess process,
            [Out, MarshalAs(UnmanagedType.BStr)] out string dbiPath,
            [In, MarshalAs(UnmanagedType.LPWStr)] string requestedModuleName,
            [In] int requestedModuleTimeStamp,
            [In] int requestedModuleSize);

        /// <summary>
        /// Loads the given module and verifies its authenticity.
        /// </summary>
        [PreserveSig]
        HRESULT SecureLoadModule(
            [In, MarshalAs(UnmanagedType.LPWStr)] string dllPath,
            [Out] out IntPtr libraryHandle);
    }
}
