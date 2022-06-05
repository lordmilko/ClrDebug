using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public delegate void RuntimeLoadedCallback(
        [MarshalAs(UnmanagedType.Interface)] ICLRRuntimeInfo pRuntimeInfo,
        [MarshalAs(UnmanagedType.FunctionPtr)] CallbackThreadSet pfnCallbackThreadSet,
        [MarshalAs(UnmanagedType.FunctionPtr)] CallbackThreadUnset pfnCallbackThreadUnset
    );

    public delegate void CallbackThreadSet();

    public delegate void CallbackThreadUnset();

    /// <summary>
    /// Provides methods that return a specific version of the common language runtime (CLR) based on its version number, list all installed CLRs, list all runtimes that are loaded in a specified process, discover the CLR version used to compile an assembly, exit a process with a clean runtime shutdown, and query legacy API binding.
    /// </summary>
    /// <remarks>
    /// The only way to get an instance of this interface is by calling the CLRCreateInstance function as follows:
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D332DB9E-B9B3-4125-8207-A14884F53216")]
    [ComImport]
    public interface ICLRMetaHost
    {
        /// <summary>
        /// Gets the <see cref="ICLRRuntimeInfo"/> interface that corresponds to a particular version of the common language runtime (CLR). This method supersedes the CorBindToRuntimeEx function used with the <see cref="STARTUP_FLAGS"/> flag.
        /// </summary>
        /// <param name="pwzVersion">[in] The .NET Framework compilation version stored in the metadata, in the format "vA.B[.X]". A, B, and X are decimal numbers that correspond to the major version, the minor version, and the build number.
        /// Example values are "v1.0.3705", "v1.1.4322", "v2.0.50727", and "v4.0.X", where X depends on the build number installed. The "v" prefix is required.</param>
        /// <param name="riid">[in] The identifier for the desired interface. Currently, the only valid value for this parameter is IID_ICLRRuntimeInfo.</param>
        /// <param name="ppRuntime">[out] A pointer to the <see cref="ICLRRuntimeInfo"/> interface that corresponds to the requested runtime.</param>
        /// <remarks>
        /// This method interacts consistently with legacy interfaces such as the <see cref="ICorRuntimeHost"/> interface and
        /// legacy functions such as the deprecated CorBindTo* functions (see Deprecated CLR Hosting Functions in the .NET
        /// Framework 2.0 hosting API). That is, runtimes that are loaded with the legacy API are visible to the new API, and
        /// runtimes that are loaded with the new API are visible to the legacy API.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetRuntime([MarshalAs(UnmanagedType.LPWStr), In] string pwzVersion, [In] ref Guid riid, [Out] out object ppRuntime);

        /// <summary>
        /// Gets an assembly's original .NET Framework compilation version (stored in the metadata), given its file path. This method supersedes the GetFileVersion function.
        /// </summary>
        /// <param name="pwzFilePath">[in] The complete assembly file path.</param>
        /// <param name="pwzBuffer">[out] The .NET Framework compilation version stored in the metadata, in the format "vA.B[.X]". A, B, and X are decimal numbers that correspond to the major version, the minor version, and the build number. The length of this string is limited to MAX_PATH.
        /// Example values are "v1.0.3705", "v1.1.4322", "v2.0.50727", and "v4.0.X", where X depends on the build number installed. Note that the "v" prefix is required.</param>
        /// <param name="pcchBuffer">[in, out] The size of pwzbuffer to avoid buffer overruns.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetVersionFromFile([MarshalAs(UnmanagedType.LPWStr), In] string pwzFilePath,
            [MarshalAs(UnmanagedType.LPWStr), Out]
            StringBuilder pwzBuffer, [In] [Out] ref uint pcchBuffer);

        /// <summary>
        /// Returns an enumeration that contains a valid <see cref="ICLRRuntimeInfo"/> interface for each version of the common language runtime (CLR) that is installed on a computer.
        /// </summary>
        /// <param name="ppEnumerator">[out] An enumeration of <see cref="ICLRRuntimeInfo"/> interfaces corresponding to each version of the CLR that is installed on the computer.</param>
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateInstalledRuntimes([MarshalAs(UnmanagedType.Interface)] out IEnumUnknown ppEnumerator);

        /// <summary>
        /// Returns an enumeration that includes a valid <see cref="ICLRRuntimeInfo"/> interface pointer for each version of the common language runtime (CLR) that is loaded in a given process. This method supersedes the GetVersionFromProcess function.
        /// </summary>
        /// <param name="hndProcess">[in] The handle of the process to inspect for loaded runtimes.</param>
        /// <param name="ppEnumerator">[out] An Microsoft.VisualStudio.OLE.Interop.IEnumUnknown enumeration of <see cref="ICLRRuntimeInfo"/> interfaces corresponding to each CLR that is loaded by the process.</param>
        /// <remarks>
        /// This method is lists all loaded runtimes, even if they were loaded with deprecated functions such as CorBindToRuntime.
        /// </remarks>
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateLoadedRuntimes([In] IntPtr hndProcess, [MarshalAs(UnmanagedType.Interface)] out IEnumUnknown ppEnumerator);

        /// <summary>
        /// Provides a callback function that is guaranteed to be called when a common language runtime (CLR) version is first loaded, but not yet started. This method supersedes the LockClrVersion function.
        /// </summary>
        /// <param name="pCallbackFunction">[in] The callback function that is invoked when a new runtime has been loaded.</param>
        /// <remarks>
        /// The callback works in the following way: The callback function has the following prototype: The callback function
        /// prototypes are as follows: If the host intends to load or cause another runtime to be loaded in a reentrant manner,
        /// the pfnCallbackThreadSet and pfnCallbackThreadUnset parameters that are provided in the callback function must
        /// be used in the following way:
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT RequestRuntimeLoadedNotification([MarshalAs(UnmanagedType.FunctionPtr), In]
            RuntimeLoadedCallback pCallbackFunction);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        IntPtr QueryLegacyV2RuntimeBinding([In] ref Guid riid);

        /// <summary>
        /// Attempts to shut down all loaded runtimes gracefully and then terminates the process. Supersedes the CorExitProcess function.
        /// </summary>
        /// <param name="iExitCode">[in] The exit code for the process.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ExitProcess([In] int iExitCode);
    }
}