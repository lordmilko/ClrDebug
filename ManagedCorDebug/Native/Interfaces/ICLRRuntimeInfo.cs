using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods that return information about a specific common language runtime (CLR), including version, directory, and load status. This interface also provides runtime-specific functionality without initializing the runtime. It includes the runtime-relative <see cref="ICLRRuntimeInfo.LoadLibrary"/> method, the runtime module-specific <see cref="ICLRRuntimeInfo.GetProcAddress"/> method, and runtime-provided interfaces through the <see cref="ICLRRuntimeInfo.GetInterface"/> method.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("BD39D1D2-BA2F-486A-89B0-B4B0CB466891")]
    [ComImport]
    public interface ICLRRuntimeInfo
    {
        /// <summary>
        /// Gets common language runtime (CLR) version information associated with a given <see cref="ICLRRuntimeInfo"/> interface.<para/>
        /// This method supersedes the following functions:
        /// </summary>
        /// <param name="pwzBuffer">[out] The .NET Framework compilation version in the format "vA.B[.X]". A, B, and X are decimal numbers that correspond to the major version, the minor version, and the build number. X is optional. If X is not present, there is no trailing period.
        /// Example values are "v1.0.3705", "v1.1.4322", "v2.0.50727", and "v4.0.x", where x depends on the build number installed. Note that the "v" prefix is mandatory.</param>
        /// <param name="pcchBuffer">[in, out] Specifies the size of pwzBuffer to avoid buffer overruns. If pwzBuffer is null, pchBuffer returns the required size of pwzBuffer to allow preallocation.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetVersionString([MarshalAs(UnmanagedType.LPWStr), Out]
            StringBuilder pwzBuffer, [In] [Out] ref uint pcchBuffer);

        /// <summary>
        /// Gets the installation directory of the common language runtime (CLR) associated with this interface.<para/>
        /// This method supersedes the GetCORSystemDirectory function provided in the .NET Framework versions 2.0, 3.0, and 3.5.
        /// </summary>
        /// <param name="pwzBuffer">[out] Returns the CLR installation directory. The installation path is fully qualified; for example, "c:\windows\microsoft.net\framework\v1.0.3705\".</param>
        /// <param name="pcchBuffer">[in, out] Specifies the size of pwzBuffer to avoid buffer overruns. If pwzBuffer is null, pchBuffer returns the required size of pwzBuffer.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetRuntimeDirectory([MarshalAs(UnmanagedType.LPWStr), Out]
            StringBuilder pwzBuffer, [In] [Out] ref uint pcchBuffer);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT IsLoaded([In] IntPtr hndProcess);

        [PreserveSig]
        [LCIDConversion(3)]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT LoadErrorString([In] uint iResourceID, [MarshalAs(UnmanagedType.LPWStr), Out]
            StringBuilder pwzBuffer, [In] [Out] ref uint pcchBuffer);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPWStr), In] string pwzDllName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        IntPtr GetProcAddress([MarshalAs(UnmanagedType.LPStr), In] string pszProcName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetInterface([In] ref Guid rclsid, [In] ref Guid riid);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT IsLoadable();

        /// <summary>
        /// Sets the startup flags and the host configuration file that will be used to start the runtime. This method supersedes the use of the startupFlags parameter in the CorBindToRuntimeEx and CorBindToRuntimeHost functions.
        /// </summary>
        /// <param name="dwStartupFlags">[in] The host startup flags to set. Use the same flags as with the CorBindToRuntimeEx and CorBindToRuntimeHost functions.</param>
        /// <param name="pwzHostConfigFile">[in] The directory path of the host configuration file to set.</param>
        /// <remarks>
        /// A multithreaded host should synchronize calls to this method. Otherwise, thread A might call the SetStartupFlags
        /// method after thread B completes a call to SetStartupFlags and before thread B starts the runtime.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT SetDefaultStartupFlags([In] uint dwStartupFlags,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzHostConfigFile);

        /// <summary>
        /// Gets the startup flags and host configuration file that will be used to start the runtime.
        /// </summary>
        /// <param name="pdwStartupFlags">[out] A pointer to the host startup flags that are currently set.</param>
        /// <param name="pwzHostConfigFile">[out] A pointer to the directory path of the current host configuration file.</param>
        /// <param name="pcchHostConfigFile">[in, out] On input, the size of pwzHostConfigFile, to avoid buffer overruns. If pwzHostConfigFile is null, the method returns the required size of pwzHostConfigFile for pre-allocation.</param>
        /// <remarks>
        /// This method returns the default flag values (STARTUP_CONCURRENT_GC and NULL), or the values provided by a previous
        /// call to the <see cref="ICLRRuntimeInfo.SetDefaultStartupFlags"/>, or the values set by any of the CorBind* methods
        /// if they are bound to this runtime.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetDefaultStartupFlags(
            out uint pdwStartupFlags,
            [MarshalAs(UnmanagedType.LPWStr), Out]
            StringBuilder pwzHostConfigFile,
            [In] [Out] ref uint pcchHostConfigFile);

        /// <summary>
        /// Binds the current runtime for all legacy common language runtime (CLR) version 2 activation policy decisions.
        /// </summary>
        /// <remarks>
        /// If the current runtime is already bound for all legacy CLR version 2 activation policy decisions (for example,
        /// by using the useLegacyV2RuntimeActivationPolicy attribute on the &lt;startup&gt; element in the configuration file),
        /// this method does not return an error result; instead, the result is S_OK, just as it would be if the method had
        /// successfully bound legacy activation policy.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT BindAsLegacyV2Runtime();

        /// <summary>
        /// Indicates whether the runtime has been started (that is, whether the <see cref="ICLRRuntimeHost.Start"/> has been called and has succeeded).
        /// </summary>
        /// <param name="pbStarted">[out] true if this runtime is started; otherwise, false.</param>
        /// <param name="pdwStartupFlags">[out] Returns the flags that were used to start the runtime.</param>
        /// <remarks>
        /// This method does not work with CLR versions earlier than the CLR version in the .NET Framework 4.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT IsStarted(out int pbStarted, out uint pdwStartupFlags);
    }
}