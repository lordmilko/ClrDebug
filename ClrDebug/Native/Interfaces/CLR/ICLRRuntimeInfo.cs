using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides methods that return information about a specific common language runtime (CLR), including version, directory, and load status.<para/>
    /// This interface also provides runtime-specific functionality without initializing the runtime. It includes the runtime-relative <see cref="LoadLibrary"/> method, the runtime module-specific <see cref="GetProcAddress"/> method, and runtime-provided interfaces through the <see cref="GetInterface"/> method.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("BD39D1D2-BA2F-486A-89B0-B4B0CB466891")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICLRRuntimeInfo
    {
        /// <summary>
        /// Gets common language runtime (CLR) version information associated with a given <see cref="ICLRRuntimeInfo"/> interface.<para/>
        /// This method supersedes the following functions:
        /// </summary>
        /// <param name="pwzBuffer">[out] The .NET Framework compilation version in the format "vA.B[.X]". A, B, and X are decimal numbers that correspond to the major version, the minor version, and the build number.<para/>
        /// X is optional. If X is not present, there is no trailing period. Example values are "v1.0.3705", "v1.1.4322", "v2.0.50727", and "v4.0.x", where x depends on the build number installed.<para/>
        /// Note that the "v" prefix is mandatory.</param>
        /// <param name="pcchBuffer">[in, out] Specifies the size of pwzBuffer to avoid buffer overruns. If pwzBuffer is null, pchBuffer returns the required size of pwzBuffer to allow preallocation.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT   | Description                        |
        /// | --------- | ---------------------------------- |
        /// | S_OK      | The method completed successfully. |
        /// | E_POINTER | pwzBuffer or pchBuffer is null.    |
        /// </returns>
        [PreserveSig]
        HRESULT GetVersionString(
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1), SRI.Out] char[] pwzBuffer,
            [In, Out] ref int pcchBuffer);

        /// <summary>
        /// Gets the installation directory of the common language runtime (CLR) associated with this interface. This method supersedes the GetCORSystemDirectory function provided in the .NET Framework versions 2.0, 3.0, and 3.5.
        /// </summary>
        /// <param name="pwzBuffer">[out] Returns the CLR installation directory. The installation path is fully qualified; for example, "c:\windows\microsoft.net\framework\v1.0.3705\".</param>
        /// <param name="pcchBuffer">[in, out] Specifies the size of pwzBuffer to avoid buffer overruns. If pwzBuffer is null, pchBuffer returns the required size of pwzBuffer.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT   | Description                        |
        /// | --------- | ---------------------------------- |
        /// | S_OK      | The method completed successfully. |
        /// | E_POINTER | pwzBuffer or pchBuffer is null.    |
        /// </returns>
        [PreserveSig]
        HRESULT GetRuntimeDirectory(
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 1), SRI.Out] char[] pwzBuffer,
            [In, Out] ref int pcchBuffer);

        /// <summary>
        /// Indicates whether the common language runtime (CLR) associated with the <see cref="ICLRRuntimeInfo"/> interface is loaded into a process.<para/>
        /// A runtime can be loaded without also being started.
        /// </summary>
        /// <param name="hndProcess">[in] A handle to the process.</param>
        /// <param name="pbLoaded">[out] true if the CLR is loaded into the process; otherwise, false.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT   | Description                        |
        /// | --------- | ---------------------------------- |
        /// | S_OK      | The method completed successfully. |
        /// | E_POINTER | pbLoaded is null.                  |
        /// </returns>
        /// <remarks>
        /// This method is backward-compatible with the following functions and interfaces: A host may call one of the deprecated
        /// CorBindTo* functions, such as the CorBindToRuntime function, to instantiate a specific version of the CLR. The
        /// host could then call the <see cref="ICLRMetaHost.GetRuntime"/> method and specify the same version number to obtain
        /// a <see cref="ICLRRuntimeInfo"/> interface. If the host then calls the IsLoaded method on the returned <see cref="ICLRRuntimeInfo"/>
        /// interface, pbLoaded returns true; otherwise, it returns false.
        /// </remarks>
        [PreserveSig]
        HRESULT IsLoaded(
            [In] IntPtr hndProcess,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pbLoaded);

        /// <summary>
        /// Translates an <see cref="HRESULT"/> value into an appropriate error message for the specified culture. This method supersedes the following functions:
        /// </summary>
        /// <param name="iResourceID">[in] The <see cref="HRESULT"/> to translate.</param>
        /// <param name="pwzBuffer">[out] The message string associated with the given <see cref="HRESULT"/>.</param>
        /// <param name="pcchBuffer">[in, out] The size of pwzbuffer to avoid buffer overruns. If pwzbuffer is null, pcchBuffer provides the expected size of pwzbuffer to allow preallocation.</param>
        /// <param name="iLocaleID">[in] The culture identifier. To use the default culture, you must specify -1.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT      | Description                        |
        /// | ------------ | ---------------------------------- |
        /// | S_OK         | The method completed successfully. |
        /// | E_POINTER    | pcchBuffer is null.                |
        /// | E_INVALIDARG | pwzBuffer is null.                 |
        /// </returns>
        [PreserveSig]
        HRESULT LoadErrorString(
            [In] HRESULT iResourceID,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2), SRI.Out] char[] pwzBuffer,
            [In, Out] ref int pcchBuffer,
            [In] int iLocaleID);

        /// <summary>
        /// Loads a .NET Framework library from the common language runtime (CLR) represented by an <see cref="ICLRRuntimeInfo"/> interface.<para/>
        /// This method supersedes the LoadLibraryShim function.
        /// </summary>
        /// <param name="pwzDllName">[in] The name of the assembly to be loaded.</param>
        /// <param name="phndModule">[out] A handle to the loaded assembly.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT       | Description                                           |
        /// | ------------- | ----------------------------------------------------- |
        /// | S_OK          | The method completed successfully.                    |
        /// | E_POINTER     | pwzDllName or phndModule is null.                     |
        /// | E_OUTOFMEMORY | Not enough memory is available to handle the request. |
        /// </returns>
        /// <remarks>
        /// This method only loads DLLs included in the .NET Framework redistributable package. It can not load user-generated
        /// assemblies.
        /// </remarks>
        [PreserveSig]
        HRESULT LoadLibrary(
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzDllName,
            [Out] out IntPtr phndModule);

        /// <summary>
        /// Gets the address of a specified function that was exported from the common language runtime (CLR) associated with this interface.<para/>
        /// This method supersedes the GetRealProcAddress function.
        /// </summary>
        /// <param name="pszProcName">[in] The name of the exported function.</param>
        /// <param name="ppProc">[out] The address of the exported function.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT                  | Description                                         |
        /// | ------------------------ | --------------------------------------------------- |
        /// | S_OK                     | The method completed successfully.                  |
        /// | E_POINTER                | pszProcName or ppProc is null.                      |
        /// | CLR_E_SHIM_RUNTIMEEXPORT | The specified function is not an exported function. |
        /// </returns>
        /// <remarks>
        /// This method causes the CLR to be loaded but not initialized.
        /// </remarks>
        [PreserveSig]
        HRESULT GetProcAddress(
            [MarshalAs(UnmanagedType.LPStr), In] string pszProcName,
            [Out] out IntPtr ppProc);

        /// <summary>
        /// Loads the CLR into the current process and returns runtime interface pointers, such as <see cref="ICLRRuntimeHost"/>, <see cref="ICLRStrongName"/>, and <see cref="IMetaDataDispenser"/>.<para/>
        /// This method supersedes all the CorBindTo* functions in the Deprecated CLR Hosting Functions section.
        /// </summary>
        /// <param name="rclsid">[in] The CLSID interface for the coclass.</param>
        /// <param name="riid">[in] The IID of the requested rclsid interface.</param>
        /// <param name="ppUnk">[out] A pointer to the queried interface.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT                              | Description                                                                          |
        /// | ------------------------------------ | ------------------------------------------------------------------------------------ |
        /// | S_OK                                 | The method completed successfully.                                                   |
        /// | E_POINTER                            | ppUnk is null.                                                                       |
        /// | E_OUTOFMEMORY                        | Not enough memory is available to handle the request.                                |
        /// | CLR_E_SHIM_LEGACYRUNTIMEALREADYBOUND | A different runtime was already bound to the legacy CLR version 2 activation policy. |
        /// </returns>
        /// <remarks>
        /// This method causes the CLR to be loaded but not initialized. The following table shows the supported combinations
        /// for rclsid and riid.
        /// </remarks>
        [PreserveSig]
        HRESULT GetInterface(
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid rclsid,
#if !GENERATED_MARSHALLING
            [In, MarshalAs(UnmanagedType.LPStruct)]
#else
            [MarshalUsing(typeof(GuidMarshaller))] in
#endif
            Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppUnk);

        /// <summary>
        /// Indicates whether the runtime associated with this interface can be loaded into the current process, taking into account other runtimes that might already be loaded into the process.
        /// </summary>
        /// <param name="pbLoadable">[out] true if this runtime could be loaded into the current process; otherwise, false.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT   | Description                        |
        /// | --------- | ---------------------------------- |
        /// | S_OK      | The method completed successfully. |
        /// | E_POINTER | pbLoadable is null.                |
        /// </returns>
        /// <remarks>
        /// If another runtime is already loaded into the process, and the runtime associated with this interface can be loaded
        /// for in-process side-by-side execution, pbLoadable returns true. If the two runtimes cannot run side-by-side in-process,
        /// pbLoadable returns false. For example, the common language runtime (CLR) version 4 can run side-by-side in the
        /// same process with CLR version 2.0 or CLR version 1.1. However, CLR version 1.1 and CLR version 2.0 cannot run side-by-side
        /// in-process. If no runtimes are loaded into the process, this method always returns true.
        /// </remarks>
        [PreserveSig]
        HRESULT IsLoadable(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pbLoadable);

        /// <summary>
        /// Sets the startup flags and the host configuration file that will be used to start the runtime. This method supersedes the use of the startupFlags parameter in the CorBindToRuntimeEx and CorBindToRuntimeHost functions.
        /// </summary>
        /// <param name="dwStartupFlags">[in] The host startup flags to set. Use the same flags as with the CorBindToRuntimeEx and CorBindToRuntimeHost functions.</param>
        /// <param name="pwzHostConfigFile">[in] The directory path of the host configuration file to set.</param>
        /// <returns>
        /// This method returns the following specific HRESULT as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT | Description                        |
        /// | ------- | ---------------------------------- |
        /// | S_OK    | The method completed successfully. |
        /// </returns>
        /// <remarks>
        /// A multithreaded host should synchronize calls to this method. Otherwise, thread A might call the SetStartupFlags
        /// method after thread B completes a call to SetStartupFlags and before thread B starts the runtime.
        /// </remarks>
        [PreserveSig]
        HRESULT SetDefaultStartupFlags(
            [In] STARTUP_FLAGS dwStartupFlags,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzHostConfigFile);

        /// <summary>
        /// Gets the startup flags and host configuration file that will be used to start the runtime.
        /// </summary>
        /// <param name="pdwStartupFlags">[out] A pointer to the host startup flags that are currently set.</param>
        /// <param name="pwzHostConfigFile">[out] A pointer to the directory path of the current host configuration file.</param>
        /// <param name="pcchHostConfigFile">[in, out] On input, the size of pwzHostConfigFile, to avoid buffer overruns. If pwzHostConfigFile is null, the method returns the required size of pwzHostConfigFile for pre-allocation.</param>
        /// <returns>
        /// This method returns the following specific HRESULT as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT | Description                        |
        /// | ------- | ---------------------------------- |
        /// | S_OK    | The method completed successfully. |
        /// </returns>
        /// <remarks>
        /// This method returns the default flag values (STARTUP_CONCURRENT_GC and NULL), or the values provided by a previous
        /// call to the <see cref="SetDefaultStartupFlags"/>, or the values set by any of the CorBind* methods if they are
        /// bound to this runtime.
        /// </remarks>
        [PreserveSig]
        HRESULT GetDefaultStartupFlags(
            [Out] out STARTUP_FLAGS pdwStartupFlags,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 2), SRI.Out] char[] pwzHostConfigFile,
            [In, Out] ref int pcchHostConfigFile);

        /// <summary>
        /// Binds the current runtime for all legacy common language runtime (CLR) version 2 activation policy decisions.
        /// </summary>
        /// <returns>
        /// This method returns the following specific HRESULTs:
        /// 
        /// | HRESULT                              | Description                                                                                                        |
        /// | ------------------------------------ | ------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                                 | Either binding succeeded, or this runtime was already bound as the legacy CLR version 2 activation policy runtime. |
        /// | CLR_E_SHIM_LEGACYRUNTIMEALREADYBOUND | A different runtime was already bound to the legacy CLR version 2 activation policy.                               |
        /// </returns>
        /// <remarks>
        /// If the current runtime is already bound for all legacy CLR version 2 activation policy decisions (for example,
        /// by using the useLegacyV2RuntimeActivationPolicy attribute on the &lt;startup&gt; element in the configuration file),
        /// this method does not return an error result; instead, the result is S_OK, just as it would be if the method had
        /// successfully bound legacy activation policy.
        /// </remarks>
        [PreserveSig]
        HRESULT BindAsLegacyV2Runtime();

        /// <summary>
        /// Indicates whether the runtime has been started (that is, whether the <see cref="ICLRRuntimeHost.Start"/> has been called and has succeeded).
        /// </summary>
        /// <param name="pbStarted">[out] true if this runtime is started; otherwise, false.</param>
        /// <param name="pdwStartupFlags">[out] Returns the flags that were used to start the runtime.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT   | Description                                                                                        |
        /// | --------- | -------------------------------------------------------------------------------------------------- |
        /// | S_OK      | The method completed successfully.                                                                 |
        /// | E_NOTIMPL | The common language runtime (CLR) version is earlier than the CLR version in the .NET Framework 4. |
        /// </returns>
        /// <remarks>
        /// This method does not work with CLR versions earlier than the CLR version in the .NET Framework 4.
        /// </remarks>
        [PreserveSig]
        HRESULT IsStarted(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pbStarted,
            [Out] out STARTUP_FLAGS pdwStartupFlags);
    }
}
