using System;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    //https://learn.microsoft.com/en-us/dotnet/standard/native-interop/charset

    #region Delegates
    #region nethost

    /// <summary>
    /// Get the path to the hostfxr library
    /// </summary>
    /// <param name="buffer">Buffer that will be populated with the hostfxr path, including a null terminator.<para/>
    /// UTF16 on Windows, UTF8 on Unix.</param>
    /// <param name="buffer_size">Size of buffer in char_t units.</param>
    /// <param name="parameters">Optional. <see cref="get_hostfxr_parameters"/> that modify the behaviour for locating the hostfxr library.
    /// If nullptr, hostfxr is located using the environment variable or global registration.</param>
    /// <returns>
    /// 0 on success, otherwise failure
    /// HostApiBufferTooSmall - buffer is too small
    /// </returns>
    [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Auto)]
    public delegate HostStatusCode get_hostfxr_path_fn(
        [In] IntPtr buffer,
        [In, Out] ref IntPtr buffer_size,
        [In] IntPtr parameters);

    #endregion
    #region hostfxr

    /// <summary>
    /// Closes an initialized host context
    /// </summary>
    /// <param name="host_context_handle">Handle to the initialized host context</param>
    /// <returns>The error code result.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate HostStatusCode hostfxr_close_fn(
        [In] IntPtr host_context_handle);

    /// <summary>
    /// Returns the list of all available SDKs ordered by ascending version.
    /// </summary>
    /// <param name="exe_dir">The path to the dotnet executable.<para/>
    /// UTF16 on Windows, UTF8 on Unix.</param>
    /// <param name="result">Callback invoke to return the list of SDKs by their directory paths.
    /// String array and its elements are valid for the duration of the call.</param>
    /// <returns>0 on success, otherwise failure.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public delegate HostStatusCode hostfxr_get_available_sdks_fn(
        [MarshalAs(UnmanagedType.LPTStr), In, Optional] string exe_dir,
        [MarshalAs(UnmanagedType.FunctionPtr), In] hostfxr_get_available_sdks_result_fn result);

    /// <summary>
    /// Returns available SDKs and frameworks.<para/>
    /// 
    /// Resolves the existing SDKs and frameworks from a dotnet root directory (if
    /// any), or the global default location. If multi-level lookup is enabled and
    /// the dotnet root location is different than the global location, the SDKs and
    /// frameworks will be enumerated from both locations.<para/>
    /// 
    /// The SDKs are sorted in ascending order by version, multi-level lookup
    /// locations are put before private ones.<para/>
    /// 
    /// The frameworks are sorted in ascending order by name followed by version,
    /// multi-level lookup locations are put before private ones.
    /// </summary>
    /// <param name="dotnet_root">The path to a directory containing a dotnet executable.<para/>
    /// UTF16 on Windows, UTF8 on Unix.</param>
    /// <param name="reserved">Reserved for future parameters.</param>
    /// <param name="result">Callback invoke to return the list of SDKs and frameworks.
    /// Structs and their elements are valid for the duration of the call.</param>
    /// <param name="result_context">Additional context passed to the result callback.</param>
    /// <returns>0 on success, otherwise failure.</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public delegate HostStatusCode hostfxr_get_dotnet_environment_info_fn(
        [MarshalAs(UnmanagedType.LPWStr), In, Optional] string dotnet_root,
        [In] IntPtr reserved,
        [In, MarshalAs(UnmanagedType.FunctionPtr)] hostfxr_get_dotnet_environment_info_result_fn result,
        [In] IntPtr result_context);

    /// <summary>
    /// Returns the native directories of the runtime based upon the specified app.<para/>
    /// Returned format is a list of paths separated by PATH_SEPARATOR which is a semicolon (;) on Windows and a colon (:) otherwise.
    /// The returned string is null-terminated.
    /// </summary>
    /// <param name="argc">The number of argv arguments</param>
    /// <param name="argv">The standard arguments normally passed to dotnet.exe for launching the application.<para/>
    /// UTF16 on Windows, UTF8 on Unix.</param>
    /// <param name="buffer">The buffer where the native paths and null terminator will be written.<para/>
    /// UTF16 on Windows, UTF8 on Unix.</param>
    /// <param name="buffer_size">The size of the buffer argument in pal::char_t units.</param>
    /// <param name="required_buffer_size">If the return value is <see cref="HostStatusCode.HostApiBufferTooSmall"/>, then required_buffer_size is set to the minimum buffer
    /// size necessary to contain the result including the null terminator.</param>
    /// <returns>
    /// 0 on success, otherwise failure
    /// HostApiBufferTooSmall - Buffer is too small
    /// </returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public delegate HostStatusCode hostfxr_get_native_search_directories_fn(
        [In] int argc,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPTStr, SizeParamIndex = 0), In] string[] argv,
        [In] IntPtr buffer,
        [In] int buffer_size,
        [Out] out int required_buffer_size);

    /// <summary>
    /// Gets a typed delegate from the currently loaded CoreCLR or from a newly created one.
    /// </summary>
    /// <param name="host_context_handle">Handle to the initialized host context. Prior to .NET 8 this value cannot be null.</param>
    /// <param name="type">Type of runtime delegate requested</param>
    /// <param name="delegate">An out parameter that will be assigned the delegate.</param>
    /// <returns>The error code result.</returns>
    /// <remarks>
    /// If the host_context_handle was initialized using hostfxr_initialize_for_runtime_config,
    /// then all delegate types are supported.
    /// If the host_context_handle was initialized using hostfxr_initialize_for_dotnet_command_line,
    /// then only the following delegate types are currently supported:
    ///     <see cref="hostfxr_delegate_type.hdt_load_assembly_and_get_function_pointer"/>
    ///     <see cref="hostfxr_delegate_type.hdt_get_function_pointer"/>
    /// </remarks>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public delegate HostStatusCode hostfxr_get_runtime_delegate_fn(
        [In, Optional] IntPtr host_context_handle,
        [In] hostfxr_delegate_type type,
        [Out] out IntPtr @delegate);

    /// <summary>
    /// Gets all the runtime properties for an initialized host context
    /// </summary>
    /// <param name="host_context_handle">Handle to the initialized host context</param>
    /// <param name="count">Size of the keys and values buffers</param>
    /// <param name="keys">Array of pointers to buffers with runtime property keys<para/>
    /// UTF16 on Windows, UTF8 on Unix.</param>
    /// <param name="values">Array of pointers to buffers with runtime property values<para/>
    /// UTF16 on Windows, UTF8 on Unix.</param>
    /// <returns>The error code result.</returns>
    /// <remarks>
    /// The buffers pointed to by keys and values are owned by the host context. The lifetime of the buffers is only
    /// guaranteed until any of the below occur:
    ///   - a 'run' method is called for the host context
    ///   - properties are changed via hostfxr_set_runtime_property_value
    ///   - the host context is closed via 'hostfxr_close'
    ///
    /// If host_context_handle is nullptr and an active host context exists, this function will get the
    /// properties for the active host context.
    /// </remarks>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public delegate HostStatusCode hostfxr_get_runtime_properties_fn(
        [In, Optional] IntPtr host_context_handle,
        [In, Out] ref IntPtr count,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysInt, SizeParamIndex = 1), In] IntPtr[] keys,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.SysInt, SizeParamIndex = 1), In] IntPtr[] values);

    /// <summary>
    /// Gets the runtime property value for an initialized host context
    /// </summary>
    /// <param name="host_context_handle">Handle to the initialized host context</param>
    /// <param name="name">Runtime property name<para/>
    /// UTF16 on Windows, UTF8 on Unix.</param>
    /// <param name="value">Out parameter. Pointer to a buffer with the property value.<para/>
    /// UTF16 on Windows, UTF8 on Unix.</param>
    /// <returns>The error code result.</returns>
    /// <remarks>
    /// The buffer pointed to by value is owned by the host context. The lifetime of the buffer is only
    /// guaranteed until any of the below occur:
    ///   - a 'run' method is called for the host context
    ///   - properties are changed via hostfxr_set_runtime_property_value
    ///   - the host context is closed via 'hostfxr_close'
    ///
    /// If host_context_handle is nullptr and an active host context exists, this function will get the
    /// property value for the active host context.
    /// </remarks>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public delegate HostStatusCode hostfxr_get_runtime_property_value_fn(
        [In, Optional] IntPtr host_context_handle,
        [MarshalAs(UnmanagedType.LPTStr), In] string name,
        [Out] out IntPtr value);

    /// <summary>
    /// Initializes the hosting components for a dotnet command line running an application
    /// </summary>
    /// <param name="argc">Number of argv arguments</param>
    /// <param name="argv">Command-line arguments for running an application (as if through the dotnet executable).
    /// Only command-line arguments which are accepted by runtime installation are supported, SDK/CLI commands are not supported.
    /// For example 'app.dll app_argument_1 app_argument_2`.<para/>
    /// UTF16 on Windows, UTF8 on Unix.</param>
    /// <param name="parameters">Optional. Additional <see cref="hostfxr_initialize_parameters"/> for initialization</param>
    /// <param name="host_context_handle">On success, this will be populated with an opaque value representing the initialized host context</param>
    /// <returns>
    /// Success          - Hosting components were successfully initialized
    /// HostInvalidState - Hosting components are already initialized
    /// </returns>
    /// <remarks>
    /// This function parses the specified command-line arguments to determine the application to run. It will
    /// then find the corresponding .runtimeconfig.json and .deps.json with which to resolve frameworks and
    /// dependencies and prepare everything needed to load the runtime.<para/>
    ///
    /// This function only supports arguments for running an application. It does not support SDK commands.<para/>
    ///
    /// This function does not load the runtime.
    /// </remarks>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public delegate HostStatusCode hostfxr_initialize_for_dotnet_command_line_fn(
        [In] int argc,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPTStr, SizeParamIndex = 0), In] string[] argv,
        [In, Optional] IntPtr parameters,
        [Out] out IntPtr host_context_handle);

    /// <summary>
    /// Initializes the hosting components using a .runtimeconfig.json file
    /// </summary>
    /// <param name="runtime_config_path">Path to the .runtimeconfig.json file<para/>
    /// UTF16 on Windows, UTF8 on Unix.</param>
    /// <param name="parameters">Optional. Additional <see cref="hostfxr_initialize_parameters"/> for initialization</param>
    /// <param name="host_context_handle">On success, this will be populated with an opaque value representing the initialized host context</param>
    /// <returns>
    /// Success                            - Hosting components were successfully initialized
    /// Success_HostAlreadyInitialized     - Config is compatible with already initialized hosting components
    /// Success_DifferentRuntimeProperties - Config has runtime properties that differ from already initialized hosting components
    /// CoreHostIncompatibleConfig         - Config is incompatible with already initialized hosting components
    /// </returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public delegate HostStatusCode hostfxr_initialize_for_runtime_config_fn(
        [MarshalAs(UnmanagedType.LPTStr), In] string runtime_config_path,
        [In, Optional] IntPtr parameters,
        [Out] out IntPtr host_context_handle);

    /// <summary>
    /// Run an application.
    /// </summary>
    /// <param name="argc">Number of argv arguments</param>
    /// <param name="argv">Command-line arguments<para/>
    /// UTF16 on Windows, UTF8 on Unix.</param>
    /// <returns>If the application is successfully executed, this value will return the exit code of the application. Otherwise, it will return an error code indicating the failure.</returns>
    /// <remarks>
    /// This function does not return until the application completes execution. It will shutdown CoreCLR after the application executes.
    /// </remarks>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public delegate HostStatusCode hostfxr_main_fn(
        [In] int argc,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPTStr, SizeParamIndex = 0), In] string[] argv);

    //No documentation in dotnet/runtime
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public delegate HostStatusCode hostfxr_main_bundle_startupinfo_fn(
        [In] int argc,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPTStr, SizeParamIndex = 0), In] string[] argv,
        [MarshalAs(UnmanagedType.LPTStr), In, Optional] string host_path,
        [MarshalAs(UnmanagedType.LPTStr), In, Optional] string dotnet_root,
        [MarshalAs(UnmanagedType.LPTStr), In, Optional] string app_path,
        [In] long bundle_header_offset);

    /// <summary>
    /// Run an application.
    /// </summary>
    /// <param name="argc">Number of argv arguments</param>
    /// <param name="argv">Command-line arguments<para/>
    /// UTF16 on Windows, UTF8 on Unix.</param>
    /// <param name="host_path">Path to the host application<para/>
    /// UTF16 on Windows, UTF8 on Unix.</param>
    /// <param name="dotnet_root">Path to the .NET Core installation root<para/>
    /// UTF16 on Windows, UTF8 on Unix.</param>
    /// <param name="app_path">Path to the application to run<para/>
    /// UTF16 on Windows, UTF8 on Unix.</param>
    /// <returns>If the application is successfully executed, this value will return the exit code of the application. Otherwise, it will return an error code indicating the failure.</returns>
    /// <remarks>
    /// This function does not return until the application completes execution. It will shutdown CoreCLR after the application executes.
    /// </remarks>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public delegate HostStatusCode hostfxr_main_startupinfo_fn(
        [In] int argc,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPTStr, SizeParamIndex = 0), In] string[] argv,
        [MarshalAs(UnmanagedType.LPTStr), In, Optional] string host_path,
        [MarshalAs(UnmanagedType.LPTStr), In, Optional] string dotnet_root,
        [MarshalAs(UnmanagedType.LPTStr), In, Optional] string app_path);

    /// <summary>
    /// Determines the directory location of the SDK accounting for global.json and multi-level lookup policy.
    /// </summary>
    /// <param name="exe_dir">The main directory where SDKs are located in sdk\[version] sub-folders.<para/>
    /// Pass the directory of a dotnet executable to mimic how that executable would search in its own directory.<para/>
    /// It is also valid to pass nullptr or empty, in which case multi-level lookup can still search other locations if
    /// it has not been disabled by the user's environment.<para/>
    /// UTF16 on Windows, UTF8 on Unix.</param>
    /// <param name="working_dir">The directory where the search for global.json (which can control the resolved SDK version)
    /// starts and proceeds upwards.</param>
    /// <param name="buffer">The buffer where the resolved SDK path will be written.<para/>
    /// UTF16 on Windows, UTF8 on Unix.</param>
    /// <param name="buffer_size">The size of the buffer argument in pal::char_t units.</param>
    /// <returns>
    /// &lt;0 - Invalid argument
    /// 0  - SDK could not be found.
    /// &gt;0 - The number of characters (including null terminator) required to store the located SDK.
    /// </returns>
    /// <remarks>
    /// If resolution succeeds and the positive return value is less than or equal to buffer_size (i.e. the buffer is large enough),
    /// then the resolved SDK path is copied to the buffer and null terminated. Otherwise, no data is written to the buffer.
    /// </remarks>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public delegate int hostfxr_resolve_sdk_fn(
        [MarshalAs(UnmanagedType.LPTStr), In, Optional] string exe_dir,
        [MarshalAs(UnmanagedType.LPTStr), In, Optional] string working_dir,
        [In] IntPtr buffer,
        [In] int buffer_size);

    /// <summary>
    /// Determines the directory location of the SDK accounting for global.json and multi-level lookup policy.
    /// </summary>
    /// <param name="exe_dir">The main directory where SDKs are located in sdk\[version] sub-folders.<para/>
    /// Pass the directory of a dotnet executable to mimic how that executable would search in its own directory.<para/>
    /// It is also valid to pass nullptr or empty, in which case multi-level lookup can still search other locations if
    /// it has not been disabled by the user's environment.<para/>
    /// UTF16 on Windows, UTF8 on Unix.</param>
    /// <param name="working_dir">The directory where the search for global.json (which can control the resolved SDK version)
    /// starts and proceeds upwards.<para/>
    /// UTF16 on Windows, UTF8 on Unix.</param>
    /// <param name="flags">Bitwise flags that influence resolution.</param>
    /// <param name="result">Callback invoked to return values. It can be invoked more than once. String values passed are valid only for the duration of a call.<para/>
    /// If resolution succeeds, then result will be invoked with resolved_sdk_dir key and the value will hold the path to the resolved SDK directory.<para/>
    /// If global.json is used, then result will be invoked with global_json_path key and the value will hold the path to global.json.<para/>
    /// If there was no global.json found, or the contents of global.json did not impact resolution (e.g. no version specified),
    /// then result will not be invoked with global_json_path key. This will occur for both resolution success and failure.<para/>
    /// If a specific version is requested (via global.json), then result will be invoked with requested_version key and the
    /// value will hold the requested version. This will occur for both resolution success and failure.</param>
    /// <returns>0 on success, otherwise failure</returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public delegate HostStatusCode hostfxr_resolve_sdk2_fn(
        [MarshalAs(UnmanagedType.LPTStr), In, Optional] string exe_dir,
        [MarshalAs(UnmanagedType.LPTStr), In, Optional] string working_dir,
        [In, Optional] hostfxr_resolve_sdk2_flags_t flags,
        [MarshalAs(UnmanagedType.FunctionPtr), In] hostfxr_resolve_sdk2_result_fn result);

    /// <summary>
    /// Load CoreCLR and run the application for an initialized host context
    /// </summary>
    /// <param name="host_context_handle">Handle to the initialized host context</param>
    /// <returns>If the app was successfully run, the exit code of the application. Otherwise, the error code result.</returns>
    /// <remarks>
    /// The host_context_handle must have been initialized using hostfxr_initialize_for_dotnet_command_line.<para/>
    /// This function will not return until the managed application exits.
    /// </remarks>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public delegate HostStatusCode hostfxr_run_app_fn(
        [In, Optional] IntPtr host_context_handle);

    /// <summary>
    /// Sets a callback which is to be used to write errors to.
    /// </summary>
    /// <param name="error_writer">A callback function which will be invoked every time an error is to be reported.
    /// Or nullptr to unregister previously registered callback and return to the default behavior.</param>
    /// <returns>The previously registered callback (which is now unregistered), or nullptr if no previous callback was registered</returns>
    /// <remarks>
    /// The error writer is registered per-thread, so the registration is thread-local. On each thread
    /// only one callback can be registered. Subsequent registrations overwrite the previous ones. <para/>
    ///
    /// By default no callback is registered in which case the errors are written to stderr.<para/>
    ///
    /// Each call to the error writer is sort of like writing a single line (the EOL character is omitted).
    /// Multiple calls to the error writer may occur for one failure.<para/>
    ///
    /// If the hostfxr invokes functions in hostpolicy as part of its operation, the error writer
    /// will be propagated to hostpolicy for the duration of the call. This means that errors from
    /// both hostfxr and hostpolicy will be reporter through the same error writer.<para/>
    /// </remarks>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    [return: MarshalAs(UnmanagedType.FunctionPtr)]
    public delegate hostfxr_error_writer_fn hostfxr_set_error_writer_fn(
        [MarshalAs(UnmanagedType.FunctionPtr), In] hostfxr_error_writer_fn error_writer);

    /// <summary>
    /// Sets the value of a runtime property for an initialized host context
    /// </summary>
    /// <param name="host_context_handle">Handle to the initialized host context</param>
    /// <param name="name">Runtime property name<para/>
    /// UTF16 on Windows, UTF8 on Unix.</param>
    /// <param name="value">Value to set<para/>
    /// UTF16 on Windows, UTF8 on Unix.</param>
    /// <returns>The error code result.</returns>
    /// <remarks>
    /// Setting properties is only supported for the first host context, before the runtime has been loaded.<para/>
    /// If the property already exists in the host context, it will be overwritten. If value is nullptr, the property will be removed.
    /// </remarks>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public delegate HostStatusCode hostfxr_set_runtime_property_value_fn(
        [In, Optional] IntPtr host_context_handle,
        [MarshalAs(UnmanagedType.LPTStr), In] string name,
        [MarshalAs(UnmanagedType.LPTStr), In] string value);

    #region Callbacks

    //We use IntPtr here instead of string for compatibility with NativeAOT's reverse P/Invoke
    //marshaller. We could potentially write our own reverse P/Invoke stub, but I'm not sure
    //how to have non-static stubs (so we can store the particular managed delegate to relay to)

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public delegate void hostfxr_get_available_sdks_result_fn(
        [In] int sdk_count,
        [In] IntPtr sdk_dirs); //string[]. UTF16 on Windows, UTF8 on Unix

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public unsafe delegate void hostfxr_get_dotnet_environment_info_result_fn(
        [In] hostfxr_dotnet_environment_info* info,
        [In] IntPtr result_context);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public delegate void hostfxr_resolve_sdk2_result_fn(
        [In] hostfxr_resolve_sdk2_result_key_t key,
        [In] IntPtr value); //string. UTF16 on Windows, UTF8 on Unix

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Auto)]
    public delegate void hostfxr_error_writer_fn(
        [In] IntPtr message); //string. UTF16 on Windows, UTF8 on Unix

    #endregion
    #endregion
    #endregion

    public class NetHost
    {
        private DelegateProvider delegateProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="NetHost"/> class.
        /// </summary>
        /// <param name="hModule">A handle to the nethost library that has been loaded into the process.</param>
        public NetHost(IntPtr hModule)
        {
            if (hModule == IntPtr.Zero)
                throw new ArgumentNullException(nameof(hModule));

            delegateProvider = new DelegateProvider(hModule);
        }

        #region get_hostfxr_path

        /// <summary>
        /// Get the path to the hostfxr library
        /// </summary>
        /// <param name="parameters">Optional. Parameters that modify the behaviour for locating the hostfxr library.
        /// If not specified, hostfxr is located using the environment variable or global registration.</param>
        /// <returns>The path to the hostfxr library</returns>
        public string GetHostFxrPath(get_hostfxr_parameters parameters = default(get_hostfxr_parameters))
        {
            TryGetHostFxrPath(parameters, out var result).ThrowOnNotOK();
            return result;
        }

        /// <summary>
        /// Tries to get the path to the hostfxr library
        /// </summary>
        /// <param name="parameters">Optional. Parameters that modify the behaviour for locating the hostfxr library.
        /// If not specified, hostfxr is located using the environment variable or global registration.</param>
        /// <param name="result">The path to the hostfxr library</param>
        /// <returns>
        /// 0 on success, otherwise failure
        /// HostApiBufferTooSmall - buffer is too small
        /// </returns>
        public HostStatusCode TryGetHostFxrPath(get_hostfxr_parameters parameters, out string result)
        {
            IntPtr parametersBuffer = IntPtr.Zero;
            IntPtr pathBuffer = IntPtr.Zero;

            try
            {
                if (!parameters.Equals(default(get_hostfxr_parameters)))
                {
                    parametersBuffer = Marshal.AllocHGlobal(Marshal.SizeOf<get_hostfxr_parameters>());
                    Marshal.StructureToPtr(parameters, parametersBuffer, false);
                }

                var bufferSize = new IntPtr(512);
#if GENERATED_MARSHALLING
                pathBuffer = Marshal.AllocHGlobal(bufferSize * (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? 2 : 1));
#else
                pathBuffer = Marshal.AllocHGlobal((int) bufferSize * 2);
#endif
                var @delegate = delegateProvider.get_hostfxr_path;

                var status = @delegate(pathBuffer, ref bufferSize, parametersBuffer);

                if ((int)bufferSize > 0)
                    result = CrossPlatformStringMarshaller.ConvertToManaged(pathBuffer);
                else
                    result = null;

                return status;
            }
            finally
            {
                if (pathBuffer != IntPtr.Zero)
                    Marshal.FreeHGlobal(pathBuffer);

                if (parametersBuffer != IntPtr.Zero)
                {
                    Marshal.DestroyStructure<get_hostfxr_parameters>(parametersBuffer);
                    Marshal.FreeHGlobal(parametersBuffer);
                }
            }
        }

        #endregion
    }

    public class HostFxr
    {
        //Cache delegates that may be called after the method has returned to prevent it from being garbage collected
        private hostfxr_error_writer_fn lastSetErrorWriterCallback;

        private DelegateProvider delegateProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="HostFxr"/> class.
        /// </summary>
        /// <param name="hModule">A handle to a hostfxr library that has been loaded into the process.</param>
        public HostFxr(IntPtr hModule)
        {
            if (hModule == IntPtr.Zero)
                throw new ArgumentNullException(nameof(hModule));

            delegateProvider = new DelegateProvider(hModule);
        }

        #region hostfxr_close_fn

        /// <summary>
        /// Closes an initialized host context
        /// </summary>
        /// <param name="hostContextHandle">Handle to the initialized host context</param>
        public void Close(IntPtr hostContextHandle) =>
            TryClose(hostContextHandle).ThrowOnNotOK();

        /// <summary>
        /// Tries to close an initialized host context
        /// </summary>
        /// <param name="hostContextHandle">Handle to the initialized host context</param>
        /// <returns>The error code result.</returns>
        public HostStatusCode TryClose(IntPtr hostContextHandle)
        {
            var @delegate = delegateProvider.hostfxr_close;

            return @delegate(hostContextHandle);
        }

        #endregion
        #region hostfxr_get_available_sdks_fn

        /// <summary>
        /// Returns the list of all available SDKs ordered by ascending version.
        /// </summary>
        /// <param name="exeDir">The path to the dotnet executable.<para/>
        /// UTF16 on Windows, UTF8 on Unix.</param>
        /// <param name="callback">Callback invoke to return the list of SDKs by their directory paths.
        /// String array and its elements are valid for the duration of the call.</param>
        public void GetAvailableSdks(string exeDir, HostFxrGetAvailableSDKsResultDelegate callback) =>
            TryGetAvailableSdks(exeDir, callback).ThrowOnNotOK();

        /// <summary>
        /// Returns the list of all available SDKs ordered by ascending version.
        /// </summary>
        /// <param name="callback">Callback invoke to return the list of SDKs by their directory paths.
        /// String array and its elements are valid for the duration of the call.</param>
        public void GetAvailableSdks(HostFxrGetAvailableSDKsResultDelegate callback) =>
            TryGetAvailableSdks(null, callback).ThrowOnNotOK();

        /// <summary>
        /// Tries to return the list of all available SDKs ordered by ascending version.
        /// </summary>
        /// <param name="callback">Callback invoke to return the list of SDKs by their directory paths.
        /// String array and its elements are valid for the duration of the call.</param>
        /// <returns>0 on success, otherwise failure.</returns>
        public HostStatusCode TryGetAvailableSdks(HostFxrGetAvailableSDKsResultDelegate callback) =>
            TryGetAvailableSdks(null, callback);

        /// <summary>
        /// Tries to return the list of all available SDKs ordered by ascending version.
        /// </summary>
        /// <param name="exeDir">The path to the dotnet executable.<para/>
        /// UTF16 on Windows, UTF8 on Unix.</param>
        /// <param name="callback">Callback invoke to return the list of SDKs by their directory paths.
        /// String array and its elements are valid for the duration of the call.</param>
        /// <returns>0 on success, otherwise failure.</returns>
        public HostStatusCode TryGetAvailableSdks(string exeDir, HostFxrGetAvailableSDKsResultDelegate callback)
        {
            var @delegate = delegateProvider.hostfxr_get_available_sdks;

            hostfxr_get_available_sdks_result_fn result = null;

            if (callback != null)
            {
                result = (sdkCount, sdkDirs) =>
                {
                    var array = new string[sdkCount];

                    for (var i = 0; i < sdkCount; i++)
                    {
                        var ptr = Marshal.ReadIntPtr(sdkDirs + i * IntPtr.Size);

                        array[i] = CrossPlatformStringMarshaller.ConvertToManaged(ptr);
                    }

                    callback(sdkCount, array);
                };
            }

            var status = @delegate(exeDir, result);
            GC.KeepAlive(callback);

            return status;
        }

        #endregion
        #region hostfxr_get_dotnet_environment_info_fn

        /// <summary>
        /// Returns available SDKs and frameworks.<para/>
        /// 
        /// Resolves the existing SDKs and frameworks from a dotnet root directory (if
        /// any), or the global default location. If multi-level lookup is enabled and
        /// the dotnet root location is different than the global location, the SDKs and
        /// frameworks will be enumerated from both locations.<para/>
        /// 
        /// The SDKs are sorted in ascending order by version, multi-level lookup
        /// locations are put before private ones.<para/>
        /// 
        /// The frameworks are sorted in ascending order by name followed by version,
        /// multi-level lookup locations are put before private ones.
        /// </summary>
        /// <param name="callback">Callback invoke to return the list of SDKs and frameworks.
        /// Structs and their elements are valid for the duration of the call.</param>
        public void GetDotnetEnvironmentInfo(
            HostFxrDotnetEnvironmentInfoResultDelegate callback) =>
            GetDotnetEnvironmentInfo(null, callback);

        /// <summary>
        /// Returns available SDKs and frameworks.<para/>
        /// 
        /// Resolves the existing SDKs and frameworks from a dotnet root directory (if
        /// any), or the global default location. If multi-level lookup is enabled and
        /// the dotnet root location is different than the global location, the SDKs and
        /// frameworks will be enumerated from both locations.<para/>
        /// 
        /// The SDKs are sorted in ascending order by version, multi-level lookup
        /// locations are put before private ones.<para/>
        /// 
        /// The frameworks are sorted in ascending order by name followed by version,
        /// multi-level lookup locations are put before private ones.
        /// </summary>
        /// <param name="dotnetRoot">The path to a directory containing a dotnet executable.<para/>
        /// UTF16 on Windows, UTF8 on Unix.</param>
        /// <param name="callback">Callback invoke to return the list of SDKs and frameworks.
        /// Structs and their elements are valid for the duration of the call.</param>
        public void GetDotnetEnvironmentInfo(
            string dotnetRoot,
            HostFxrDotnetEnvironmentInfoResultDelegate callback) =>
            GetDotnetEnvironmentInfo(dotnetRoot, IntPtr.Zero, callback, IntPtr.Zero);

        /// <summary>
        /// Returns available SDKs and frameworks.<para/>
        /// 
        /// Resolves the existing SDKs and frameworks from a dotnet root directory (if
        /// any), or the global default location. If multi-level lookup is enabled and
        /// the dotnet root location is different than the global location, the SDKs and
        /// frameworks will be enumerated from both locations.<para/>
        /// 
        /// The SDKs are sorted in ascending order by version, multi-level lookup
        /// locations are put before private ones.<para/>
        /// 
        /// The frameworks are sorted in ascending order by name followed by version,
        /// multi-level lookup locations are put before private ones.
        /// </summary>
        /// <param name="dotnetRoot">The path to a directory containing a dotnet executable.<para/>
        /// UTF16 on Windows, UTF8 on Unix.</param>
        /// <param name="reserved">Reserved for future parameters.</param>
        /// <param name="callback">Callback invoke to return the list of SDKs and frameworks.
        /// Structs and their elements are valid for the duration of the call.</param>
        /// <param name="resultContext">Additional context passed to the result callback.</param>
        public void GetDotnetEnvironmentInfo(
            string dotnetRoot,
            IntPtr reserved,
            HostFxrDotnetEnvironmentInfoResultDelegate callback,
            IntPtr resultContext) =>
            TryGetDotnetEnvironmentInfo(dotnetRoot, reserved, callback, resultContext).ThrowOnNotOK();

        /// <summary>
        /// Tries to return available SDKs and frameworks.<para/>
        /// 
        /// Resolves the existing SDKs and frameworks from a dotnet root directory (if
        /// any), or the global default location. If multi-level lookup is enabled and
        /// the dotnet root location is different than the global location, the SDKs and
        /// frameworks will be enumerated from both locations.<para/>
        /// 
        /// The SDKs are sorted in ascending order by version, multi-level lookup
        /// locations are put before private ones.<para/>
        /// 
        /// The frameworks are sorted in ascending order by name followed by version,
        /// multi-level lookup locations are put before private ones.
        /// </summary>
        /// <param name="callback">Callback invoke to return the list of SDKs and frameworks.
        /// Structs and their elements are valid for the duration of the call.</param>
        /// <returns>0 on success, otherwise failure.</returns>
        public HostStatusCode TryGetDotnetEnvironmentInfo(
            HostFxrDotnetEnvironmentInfoResultDelegate callback) =>
            TryGetDotnetEnvironmentInfo(null, callback);

        /// <summary>
        /// Tries to return available SDKs and frameworks.<para/>
        /// 
        /// Resolves the existing SDKs and frameworks from a dotnet root directory (if
        /// any), or the global default location. If multi-level lookup is enabled and
        /// the dotnet root location is different than the global location, the SDKs and
        /// frameworks will be enumerated from both locations.<para/>
        /// 
        /// The SDKs are sorted in ascending order by version, multi-level lookup
        /// locations are put before private ones.<para/>
        /// 
        /// The frameworks are sorted in ascending order by name followed by version,
        /// multi-level lookup locations are put before private ones.
        /// </summary>
        /// <param name="dotnetRoot">The path to a directory containing a dotnet executable.<para/>
        /// UTF16 on Windows, UTF8 on Unix.</param>
        /// <param name="callback">Callback invoke to return the list of SDKs and frameworks.
        /// Structs and their elements are valid for the duration of the call.</param>
        /// <returns>0 on success, otherwise failure.</returns>
        public HostStatusCode TryGetDotnetEnvironmentInfo(
            string dotnetRoot,
            HostFxrDotnetEnvironmentInfoResultDelegate callback) =>
            TryGetDotnetEnvironmentInfo(dotnetRoot, IntPtr.Zero, callback, IntPtr.Zero);

        /// <summary>
        /// Tries to return available SDKs and frameworks.<para/>
        /// 
        /// Resolves the existing SDKs and frameworks from a dotnet root directory (if
        /// any), or the global default location. If multi-level lookup is enabled and
        /// the dotnet root location is different than the global location, the SDKs and
        /// frameworks will be enumerated from both locations.<para/>
        /// 
        /// The SDKs are sorted in ascending order by version, multi-level lookup
        /// locations are put before private ones.<para/>
        /// 
        /// The frameworks are sorted in ascending order by name followed by version,
        /// multi-level lookup locations are put before private ones.
        /// </summary>
        /// <param name="dotnetRoot">The path to a directory containing a dotnet executable.<para/>
        /// UTF16 on Windows, UTF8 on Unix.</param>
        /// <param name="reserved">Reserved for future parameters.</param>
        /// <param name="callback">Callback invoke to return the list of SDKs and frameworks.
        /// Structs and their elements are valid for the duration of the call.</param>
        /// <param name="resultContext">Additional context passed to the result callback.</param>
        /// <returns>0 on success, otherwise failure.</returns>
        public unsafe HostStatusCode TryGetDotnetEnvironmentInfo(
            string dotnetRoot,
            IntPtr reserved,
            HostFxrDotnetEnvironmentInfoResultDelegate callback,
            IntPtr resultContext)
        {
            var @delegate = delegateProvider.hostfxr_get_dotnet_environment_info;

            hostfxr_get_dotnet_environment_info_result_fn nativeCallback = null;

            if (callback != null)
            {
                nativeCallback = (info, context) =>
                {
                    var managed = (IntPtr)info == IntPtr.Zero ? default(HostFxrDotnetEnvironmentInfo) : info->ToManaged();

                    callback(managed, context);
                };
            }

            var result = @delegate(dotnetRoot, reserved, nativeCallback, resultContext);

            GC.KeepAlive(nativeCallback);

            return result;
        }

        #endregion
        #region hostfxr_get_native_search_directories

        /// <summary>
        /// Returns the native directories of the runtime based upon the specified app.
        /// </summary>
        /// <param name="argv">The standard arguments normally passed to dotnet.exe for launching the application.</param>
        /// <returns>The retrieved runtime directories</returns>
        public string[] GetNativeSearchDirectories(string[] argv = null)
        {
            TryGetNativeSearchDirectories(argv, out var directories).ThrowOnNotOK();
            return directories;
        }

        /// <summary>
        /// Tries to return the native directories of the runtime based upon the specified app.
        /// </summary>
        /// <param name="argv">The standard arguments normally passed to dotnet.exe for launching the application.</param>
        /// <param name="directories">The retrieved runtime directories</param>
        /// <returns>
        /// 0 on success, otherwise failure
        /// HostApiBufferTooSmall - Buffer is too small
        /// </returns>
        public HostStatusCode TryGetNativeSearchDirectories(string[] argv, out string[] directories)
        {
            var @delegate = delegateProvider.hostfxr_get_native_search_directories;

            IntPtr buffer = IntPtr.Zero;

            try
            {
                var status = @delegate(argv?.Length ?? 0, argv, IntPtr.Zero, 0, out var requiredBufferSize);

                if (status == HostStatusCode.HostApiBufferTooSmall)
                {
                    var bufferSize = requiredBufferSize;
#if GENERATED_MARSHALLING
                    buffer = Marshal.AllocHGlobal(bufferSize * (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? 2 : 1));
#else
                    buffer = Marshal.AllocHGlobal(bufferSize * 2);
#endif
                    status = @delegate(argv?.Length ?? 0, argv, buffer, bufferSize, out requiredBufferSize);
                }

                if (status == HostStatusCode.Success)
                {
                    var str = CrossPlatformStringMarshaller.ConvertToManaged(buffer);

#if GENERATED_MARSHALLING
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                        directories = str.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    else
                        directories = str.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
#else
                    directories = str.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
#endif
                }
                else
                    directories = null;

                return status;
            }
            finally
            {
                if (buffer != IntPtr.Zero)
                    Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region hostfxr_get_runtime_delegate

        /// <summary>
        /// Gets a typed delegate from the currently loaded CoreCLR.<para/>
        /// This method requires hostfxr from .NET 8 or newer.
        /// </summary>
        /// <param name="type">Type of runtime delegate requested</param>
        /// <returns>A pointer for the requested delegate.</returns>
        public IntPtr GetRuntimeDelegate(hostfxr_delegate_type type) =>
            GetRuntimeDelegate(IntPtr.Zero, type);

        /// <summary>
        /// Gets a typed delegate from the currently loaded CoreCLR or from a newly created one.
        /// </summary>
        /// <param name="hostContextHandle">Handle to the initialized host context. Prior to .NET 8 this value cannot be null.</param>
        /// <param name="type">Type of runtime delegate requested</param>
        /// <returns>A pointer for the requested delegate.</returns>
        public IntPtr GetRuntimeDelegate(IntPtr hostContextHandle, hostfxr_delegate_type type)
        {
            TryGetRuntimeDelegate(hostContextHandle, type, out var @delegate).ThrowOnNotOK();
            return @delegate;
        }

        /// <summary>
        /// Tries to get a typed delegate from the currently loaded CoreCLR.
        /// </summary>
        /// <param name="type">Type of runtime delegate requested</param>
        /// <param name="delegate">A pointer for the requested delegate.</param>
        /// <returns>The error code result.</returns>
        public HostStatusCode TryGetRuntimeDelegate(hostfxr_delegate_type type, out IntPtr @delegate) =>
            TryGetRuntimeDelegate(IntPtr.Zero, type, out @delegate);

        /// <summary>
        /// Tries to get a typed delegate from the currently loaded CoreCLR or from a newly created one.
        /// </summary>
        /// <param name="hostContextHandle">Handle to the initialized host context. Prior to .NET 8 this value cannot be null.</param>
        /// <param name="type">Type of runtime delegate requested</param>
        /// <param name="delegate">A pointer for the requested delegate.</param>
        /// <returns>The error code result.</returns>
        public HostStatusCode TryGetRuntimeDelegate(IntPtr hostContextHandle, hostfxr_delegate_type type, out IntPtr @delegate)
        {
            var delegateInternal = delegateProvider.hostfxr_get_runtime_delegate;

            return delegateInternal(hostContextHandle, type, out @delegate);
        }

        #endregion
        #region hostfxr_get_runtime_properties

        /// <summary>
        /// Gets all the runtime properties for an initialized host context
        /// </summary>
        /// <param name="hostContextHandle">Handle to the initialized host context</param>
        /// <returns>A collection of key/value pairs containing the runtime properties</returns>
        /// <remarks>If host_context_handle is nullptr and an active host context exists, this function will get the
        /// properties for the active host context.</remarks>
        public GetRuntimePropertiesItem[] GetRuntimeProperties(IntPtr hostContextHandle = default(IntPtr))
        {
            TryGetRuntimeProperties(hostContextHandle, out var result).ThrowOnNotOK();
            return result;
        }

        /// <summary>
        /// Tries to get all the runtime properties for an initialized host context
        /// </summary>
        /// <param name="result">A collection of key/value pairs containing the runtime properties</param>
        /// <returns>The error code result.</returns>
        public HostStatusCode TryGetRuntimeProperties(out GetRuntimePropertiesItem[] result) =>
            TryGetRuntimeProperties(IntPtr.Zero, out result);

        /// <summary>
        /// Tries to get all the runtime properties for an initialized host context
        /// </summary>
        /// <param name="hostContextHandle">Handle to the initialized host context</param>
        /// <param name="result">A collection of key/value pairs containing the runtime properties</param>
        /// <returns>The error code result.</returns>
        public HostStatusCode TryGetRuntimeProperties(
            IntPtr hostContextHandle,
            out GetRuntimePropertiesItem[] result)
        {
            var @delegate = delegateProvider.hostfxr_get_runtime_properties;

            IntPtr count = IntPtr.Zero;
            var status = @delegate(hostContextHandle, ref count, null, null);

            if (status == HostStatusCode.HostApiBufferTooSmall)
            {
                var keys = new IntPtr[(int)count];
                var values = new IntPtr[(int)count];

                status = @delegate(hostContextHandle, ref count, keys, values);

                var array = new GetRuntimePropertiesItem[(int) count];

                for (var i = 0; i < (int)count; i++)
                {
                    array[i].Key = CrossPlatformStringMarshaller.ConvertToManaged(keys[i]);
                    array[i].Value = CrossPlatformStringMarshaller.ConvertToManaged(values[i]);
                }

                result = array;
            }
            else
                result = null;

            return status;
        }

        #endregion
        #region hostfxr_get_runtime_property_value

        /// <summary>
        /// Gets the runtime property value for an initialized host context
        /// </summary>
        /// <param name="name">Runtime property name</param>
        /// <returns>The requested property value</returns>
        public string GetRuntimePropertyValue(string name)
        {
            TryGetRuntimePropertyValue(IntPtr.Zero, name, out var value).ThrowOnNotOK();
            return value;
        }

        /// <summary>
        /// Gets the runtime property value for an initialized host context
        /// </summary>
        /// <param name="hostContextHandle">Handle to the initialized host context</param>
        /// <param name="name">Runtime property name</param>
        /// <returns>The requested property value</returns>
        public string GetRuntimePropertyValue(IntPtr hostContextHandle, string name)
        {
            TryGetRuntimePropertyValue(hostContextHandle, name, out var value).ThrowOnNotOK();
            return value;
        }

        /// <summary>
        /// Tries to get the runtime property value for an initialized host context
        /// </summary>
        /// <param name="name">Runtime property name</param>
        /// <param name="value">The requested property value</param>
        /// <returns>The error code result.</returns>
        public HostStatusCode TryGetRuntimePropertyValue(string name, out string value) =>
            TryGetRuntimePropertyValue(IntPtr.Zero, name, out value);

        /// <summary>
        /// Tries to get the runtime property value for an initialized host context
        /// </summary>
        /// <param name="hostContextHandle">Handle to the initialized host context</param>
        /// <param name="name">Runtime property name</param>
        /// <param name="value">The requested property value</param>
        /// <returns>The error code result.</returns>
        public HostStatusCode TryGetRuntimePropertyValue(IntPtr hostContextHandle, string name, out string value)
        {
            var @delegate = delegateProvider.hostfxr_get_runtime_property_value;

            var status = @delegate(hostContextHandle, name, out var buffer);

            value = CrossPlatformStringMarshaller.ConvertToManaged(buffer);

            return status;
        }

        #endregion
        #region hostfxr_initialize_for_dotnet_command_line

        /// <summary>
        /// Initializes the hosting components for a dotnet command line running an application
        /// </summary>
        /// <param name="argv">Command-line arguments for running an application (as if through the dotnet executable).
        /// Only command-line arguments which are accepted by runtime installation are supported, SDK/CLI commands are not supported.
        /// For example 'app.dll app_argument_1 app_argument_2`.</param>
        /// <returns>An opaque value representing the initialized host context</returns>
        public IntPtr InitializeForDotnetCommandLine(params string[] argv) =>
            InitializeForDotnetCommandLine(argv, default(hostfxr_initialize_parameters));

        /// <summary>
        /// Initializes the hosting components for a dotnet command line running an application
        /// </summary>
        /// <param name="argv">Command-line arguments for running an application (as if through the dotnet executable).
        /// Only command-line arguments which are accepted by runtime installation are supported, SDK/CLI commands are not supported.
        /// For example 'app.dll app_argument_1 app_argument_2`.</param>
        /// <param name="parameters">Additional <see cref="hostfxr_initialize_parameters"/> for initialization</param>
        /// <returns>An opaque value representing the initialized host context</returns>
        public IntPtr InitializeForDotnetCommandLine(string[] argv, hostfxr_initialize_parameters parameters)
        {
            TryInitializeForDotnetCommandLine(argv, parameters, out var hostContextHandle).ThrowOnNotOK();
            return hostContextHandle;
        }

        /// <summary>
        /// Tries to initialize the hosting components for a dotnet command line running an application
        /// </summary>
        /// <param name="argv">Command-line arguments for running an application (as if through the dotnet executable).
        /// Only command-line arguments which are accepted by runtime installation are supported, SDK/CLI commands are not supported.
        /// For example 'app.dll app_argument_1 app_argument_2`.</param>
        /// <param name="hostContextHandle">On success, this will be populated with an opaque value representing the initialized host context</param>
        /// <returns>
        /// Success          - Hosting components were successfully initialized
        /// HostInvalidState - Hosting components are already initialized
        /// </returns>
        public HostStatusCode TryInitializeForDotnetCommandLine(
            string[] argv,
            out IntPtr hostContextHandle) =>
            TryInitializeForDotnetCommandLine(argv, default(hostfxr_initialize_parameters), out hostContextHandle);

        /// <summary>
        /// Tries to initialize the hosting components for a dotnet command line running an application
        /// </summary>
        /// <param name="argv">Command-line arguments for running an application (as if through the dotnet executable).
        /// Only command-line arguments which are accepted by runtime installation are supported, SDK/CLI commands are not supported.
        /// For example 'app.dll app_argument_1 app_argument_2`.</param>
        /// <param name="parameters">Additional <see cref="hostfxr_initialize_parameters"/> for initialization</param>
        /// <param name="hostContextHandle">On success, this will be populated with an opaque value representing the initialized host context</param>
        /// <returns>
        /// Success          - Hosting components were successfully initialized
        /// HostInvalidState - Hosting components are already initialized
        /// </returns>
        public HostStatusCode TryInitializeForDotnetCommandLine(
            string[] argv,
            hostfxr_initialize_parameters parameters,
            out IntPtr hostContextHandle)
        {
            IntPtr rawParameters = IntPtr.Zero;

            try
            {
                if (!parameters.Equals(default(hostfxr_initialize_parameters)))
                    rawParameters = Marshal.AllocHGlobal(rawParameters);

                var @delegate = delegateProvider.hostfxr_initialize_for_dotnet_command_line;

                return @delegate(argv?.Length ?? 0, argv, rawParameters, out hostContextHandle);
            }
            finally
            {
                if (rawParameters != IntPtr.Zero)
                    Marshal.FreeHGlobal(rawParameters);
            }
        }

        #endregion
        #region hostfxr_initialize_for_runtime_config

        /// <summary>
        /// Initializes the hosting components using a .runtimeconfig.json file
        /// </summary>
        /// <param name="runtimeConfigPath">Path to the .runtimeconfig.json file</param>
        /// <param name="parameters">Additional <see cref="hostfxr_initialize_parameters"/> for initialization</param>
        /// <returns>An opaque value representing the initialized host context</returns>
        public IntPtr InitializeForRuntimeConfig(
            string runtimeConfigPath,
            hostfxr_initialize_parameters parameters = default(hostfxr_initialize_parameters))
        {
            TryInitializeForRuntimeConfig(runtimeConfigPath, parameters, out var hostContextHandle).ThrowOnNotOK();
            return hostContextHandle;
        }

        /// <summary>
        /// Tries to initialize the hosting components using a .runtimeconfig.json file
        /// </summary>
        /// <param name="runtimeConfigPath">Path to the .runtimeconfig.json file</param>
        /// <param name="hostContextHandle">On success, this will be populated with an opaque value representing the initialized host context</param>
        /// <returns>
        /// Success                            - Hosting components were successfully initialized
        /// Success_HostAlreadyInitialized     - Config is compatible with already initialized hosting components
        /// Success_DifferentRuntimeProperties - Config has runtime properties that differ from already initialized hosting components
        /// CoreHostIncompatibleConfig         - Config is incompatible with already initialized hosting components
        /// </returns>
        public HostStatusCode TryInitializeForRuntimeConfig(
            string runtimeConfigPath,
            out IntPtr hostContextHandle) =>
            TryInitializeForRuntimeConfig(runtimeConfigPath, default(hostfxr_initialize_parameters), out hostContextHandle);

        /// <summary>
        /// Tries to initialize the hosting components using a .runtimeconfig.json file
        /// </summary>
        /// <param name="runtimeConfigPath">Path to the .runtimeconfig.json file</param>
        /// <param name="parameters">Additional <see cref="hostfxr_initialize_parameters"/> for initialization</param>
        /// <param name="hostContextHandle">On success, this will be populated with an opaque value representing the initialized host context</param>
        /// <returns>
        /// Success                            - Hosting components were successfully initialized
        /// Success_HostAlreadyInitialized     - Config is compatible with already initialized hosting components
        /// Success_DifferentRuntimeProperties - Config has runtime properties that differ from already initialized hosting components
        /// CoreHostIncompatibleConfig         - Config is incompatible with already initialized hosting components
        /// </returns>
        public HostStatusCode TryInitializeForRuntimeConfig(
            string runtimeConfigPath,
            hostfxr_initialize_parameters parameters,
            out IntPtr hostContextHandle)
        {
            IntPtr rawParameters = IntPtr.Zero;

            try
            {
                if (!parameters.Equals(default(hostfxr_initialize_parameters)))
                    rawParameters = Marshal.AllocHGlobal(rawParameters);

                var @delegate = delegateProvider.hostfxr_initialize_for_runtime_config;

                return @delegate(runtimeConfigPath, rawParameters, out hostContextHandle);
            }
            finally
            {
                if (rawParameters != IntPtr.Zero)
                    Marshal.FreeHGlobal(rawParameters);
            }
        }

        #endregion
        #region hostfxr_main

        /// <summary>
        /// Run an application.
        /// </summary>
        /// <param name="argv">Command-line arguments</param>
        /// <remarks>
        /// This function does not return until the application completes execution. It will shutdown CoreCLR after the application executes.
        /// </remarks>
        public void Main(string[] argv = null) =>
            TryMain(argv).ThrowOnNotOK();

        /// <summary>
        /// Tries to run an application.
        /// </summary>
        /// <param name="argv">Command-line arguments</param>
        /// <returns>If the application is successfully executed, this value will return the exit code of the application. Otherwise, it will return an error code indicating the failure.</returns>
        /// <remarks>
        /// This function does not return until the application completes execution. It will shutdown CoreCLR after the application executes.
        /// </remarks>
        public HostStatusCode TryMain(string[] argv = null)
        {
            var @delegate = delegateProvider.hostfxr_main;

            return @delegate(argv?.Length ?? 0, argv);
        }

        #endregion
        #region hostfxr_main_bundle_startupinfo

        public void MainBundleStartupInfo(
            string[] argv,
            string hostPath,
            string dotnetRoot,
            string appPath,
            long bundleHeaderOffset) =>
            TryMainBundleStartupInfo(argv, hostPath, dotnetRoot, appPath, bundleHeaderOffset).ThrowOnNotOK();

        public HostStatusCode TryMainBundleStartupInfo(
            string[] argv,
            string hostPath,
            string dotnetRoot,
            string appPath,
            long bundleHeaderOffset)
        {
            var @delegate = delegateProvider.hostfxr_main_bundle_startupinfo;

            return @delegate(argv?.Length ?? 0, argv, hostPath, dotnetRoot, appPath, bundleHeaderOffset);
        }

        #endregion
        #region hostfxr_main_startupinfo

        /// <summary>
        /// Run an application.
        /// </summary>
        /// <param name="argv">Command-line arguments</param>
        /// <param name="hostPath">Path to the host application</param>
        /// <param name="dotnetRoot">Path to the .NET Core installation root</param>
        /// <param name="appPath">Path to the application to run</param>
        /// <remarks>
        /// This function does not return until the application completes execution. It will shutdown CoreCLR after the application executes.
        /// </remarks>
        public void MainStartupInfo(
            string[] argv,
            string hostPath,
            string dotnetRoot,
            string appPath) =>
            TryMainStartupInfo(argv, hostPath, dotnetRoot, appPath).ThrowOnNotOK();

        /// <summary>
        /// Tries to run an application.
        /// </summary>
        /// <param name="argv">Command-line arguments</param>
        /// <param name="hostPath">Path to the host application</param>
        /// <param name="dotnetRoot">Path to the .NET Core installation root</param>
        /// <param name="appPath">Path to the application to run</param>
        /// <returns>If the application is successfully executed, this value will return the exit code of the application. Otherwise, it will return an error code indicating the failure.</returns>
        /// <remarks>
        /// This function does not return until the application completes execution. It will shutdown CoreCLR after the application executes.
        /// </remarks>
        public HostStatusCode TryMainStartupInfo(
            string[] argv,
            string hostPath,
            string dotnetRoot,
            string appPath)
        {
            var @delegate = delegateProvider.hostfxr_main_startupinfo;

            return @delegate(argv?.Length ?? 0, argv, hostPath, dotnetRoot, appPath);
        }

        #endregion
        #region hostfxr_resolve_sdk

        /// <summary>
        /// Determines the directory location of the SDK accounting for global.json and multi-level lookup policy.
        /// </summary>
        /// <param name="exeDir">The main directory where SDKs are located in sdk\[version] sub-folders.<para/>
        /// Pass the directory of a dotnet executable to mimic how that executable would search in its own directory.<para/>
        /// It is also valid to pass nullptr or empty, in which case multi-level lookup can still search other locations if
        /// it has not been disabled by the user's environment.</param>
        /// <param name="workingDir">The directory where the search for global.json (which can control the resolved SDK version)
        /// starts and proceeds upwards.</param>
        /// <remarks>
        /// If resolution succeeds and the positive return value is less than or equal to buffer_size (i.e. the buffer is large enough),
        /// then the resolved SDK path is copied to the buffer and null terminated. Otherwise, no data is written to the buffer.
        /// </remarks>
        [Obsolete]
        public string ResolveSdk(
            string exeDir = null,
            string workingDir = null)
        {
            var result = TryResolveSdk(exeDir, workingDir, out var path);

            if (result != 0)
                throw new HostingException(HostStatusCode.InvalidArgFailure);

            return path;
        }

        /// <summary>
        /// Tries to determine the directory location of the SDK accounting for global.json and multi-level lookup policy.
        /// </summary>
        /// <param name="exeDir">The main directory where SDKs are located in sdk\[version] sub-folders.<para/>
        /// Pass the directory of a dotnet executable to mimic how that executable would search in its own directory.<para/>
        /// It is also valid to pass nullptr or empty, in which case multi-level lookup can still search other locations if
        /// it has not been disabled by the user's environment.</param>
        /// <param name="workingDir">The directory where the search for global.json (which can control the resolved SDK version)
        /// starts and proceeds upwards.</param>
        /// <param name="path">The path to the resolved SDK</param>
        /// <returns>
        /// &lt;0 - Invalid argument
        /// 0  - SDK could not be found.
        /// &gt;0 - The number of characters (including null terminator) required to store the located SDK.
        /// </returns>
        /// <remarks>
        /// If resolution succeeds and the positive return value is less than or equal to buffer_size (i.e. the buffer is large enough),
        /// then the resolved SDK path is copied to the buffer and null terminated. Otherwise, no data is written to the buffer.
        /// </remarks>
        [Obsolete]
        public int TryResolveSdk(
            string exeDir,
            string workingDir,
            out string path)
        {
            IntPtr buffer = IntPtr.Zero;

            try
            {
                var @delegate = delegateProvider.hostfxr_resolve_sdk;

                var result = @delegate(exeDir, workingDir, IntPtr.Zero, 0);

                if (result > 0)
                {
                    var bufferSize = result;
#if GENERATED_MARSHALLING
                    buffer = Marshal.AllocHGlobal(bufferSize * (RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? 2 : 1));
#else
                    buffer = Marshal.AllocHGlobal(bufferSize * 2);
#endif
                    //On success this still returns the required length of the buffer
                    result = @delegate(exeDir, workingDir, buffer, bufferSize);

                    if (result > 0)
                    {
                        path = CrossPlatformStringMarshaller.ConvertToManaged(buffer);
                        return 0;
                    }
                }

                path = null;
                return result;
            }
            finally
            {
                if (buffer != IntPtr.Zero)
                    Marshal.FreeHGlobal(buffer);
            }
        }

        #endregion
        #region hostfxr_resolve_sdk2

        /// <summary>
        /// Determines the directory location of the SDK accounting for global.json and multi-level lookup policy.
        /// </summary>
        /// <param name="callback">Callback invoked to return values. It can be invoked more than once. String values passed are valid only for the duration of a call.<para/>
        /// If resolution succeeds, then result will be invoked with resolved_sdk_dir key and the value will hold the path to the resolved SDK directory.<para/>
        /// If global.json is used, then result will be invoked with global_json_path key and the value will hold the path to global.json.<para/>
        /// If there was no global.json found, or the contents of global.json did not impact resolution (e.g. no version specified),
        /// then result will not be invoked with global_json_path key. This will occur for both resolution success and failure.<para/>
        /// If a specific version is requested (via global.json), then result will be invoked with requested_version key and the
        /// value will hold the requested version. This will occur for both resolution success and failure.</param>
        public void ResolveSdk2(
            HostFxrResolveSdk2ResultDelegate callback) =>
            ResolveSdk2(null, null, 0, callback);

        /// <summary>
        /// Determines the directory location of the SDK accounting for global.json and multi-level lookup policy.
        /// </summary>
        /// <param name="exeDir">The main directory where SDKs are located in sdk\[version] sub-folders.<para/>
        /// Pass the directory of a dotnet executable to mimic how that executable would search in its own directory.<para/>
        /// It is also valid to pass nullptr or empty, in which case multi-level lookup can still search other locations if
        /// it has not been disabled by the user's environment.</param>
        /// <param name="workingDir">The directory where the search for global.json (which can control the resolved SDK version)
        /// starts and proceeds upwards.</param>
        /// <param name="flags">Bitwise flags that influence resolution.</param>
        /// <param name="callback">Callback invoked to return values. It can be invoked more than once. String values passed are valid only for the duration of a call.<para/>
        /// If resolution succeeds, then result will be invoked with resolved_sdk_dir key and the value will hold the path to the resolved SDK directory.<para/>
        /// If global.json is used, then result will be invoked with global_json_path key and the value will hold the path to global.json.<para/>
        /// If there was no global.json found, or the contents of global.json did not impact resolution (e.g. no version specified),
        /// then result will not be invoked with global_json_path key. This will occur for both resolution success and failure.<para/>
        /// If a specific version is requested (via global.json), then result will be invoked with requested_version key and the
        /// value will hold the requested version. This will occur for both resolution success and failure.</param>
        public void ResolveSdk2(
            string exeDir,
            string workingDir,
            hostfxr_resolve_sdk2_flags_t flags,
            HostFxrResolveSdk2ResultDelegate callback) =>
            TryResolveSdk2(exeDir, workingDir, flags, callback).ThrowOnNotOK();

        /// <summary>
        /// Tries to determine the directory location of the SDK accounting for global.json and multi-level lookup policy.
        /// </summary>
        /// <param name="callback">Callback invoked to return values. It can be invoked more than once. String values passed are valid only for the duration of a call.<para/>
        /// If resolution succeeds, then result will be invoked with resolved_sdk_dir key and the value will hold the path to the resolved SDK directory.<para/>
        /// If global.json is used, then result will be invoked with global_json_path key and the value will hold the path to global.json.<para/>
        /// If there was no global.json found, or the contents of global.json did not impact resolution (e.g. no version specified),
        /// then result will not be invoked with global_json_path key. This will occur for both resolution success and failure.<para/>
        /// If a specific version is requested (via global.json), then result will be invoked with requested_version key and the
        /// value will hold the requested version. This will occur for both resolution success and failure.</param>
        /// <returns>0 on success, otherwise failure</returns>
        public HostStatusCode TryResolveSdk2(
            HostFxrResolveSdk2ResultDelegate callback) => TryResolveSdk2(null, null, 0, callback);

        /// <summary>
        /// Tries to determine the directory location of the SDK accounting for global.json and multi-level lookup policy.
        /// </summary>
        /// <param name="exeDir">The main directory where SDKs are located in sdk\[version] sub-folders.<para/>
        /// Pass the directory of a dotnet executable to mimic how that executable would search in its own directory.<para/>
        /// It is also valid to pass nullptr or empty, in which case multi-level lookup can still search other locations if
        /// it has not been disabled by the user's environment.</param>
        /// <param name="workingDir">The directory where the search for global.json (which can control the resolved SDK version)
        /// starts and proceeds upwards.</param>
        /// <param name="flags">Bitwise flags that influence resolution.</param>
        /// <param name="callback">Callback invoked to return values. It can be invoked more than once. String values passed are valid only for the duration of a call.<para/>
        /// If resolution succeeds, then result will be invoked with resolved_sdk_dir key and the value will hold the path to the resolved SDK directory.<para/>
        /// If global.json is used, then result will be invoked with global_json_path key and the value will hold the path to global.json.<para/>
        /// If there was no global.json found, or the contents of global.json did not impact resolution (e.g. no version specified),
        /// then result will not be invoked with global_json_path key. This will occur for both resolution success and failure.<para/>
        /// If a specific version is requested (via global.json), then result will be invoked with requested_version key and the
        /// value will hold the requested version. This will occur for both resolution success and failure.</param>
        /// <returns>0 on success, otherwise failure</returns>
        public HostStatusCode TryResolveSdk2(
            string exeDir,
            string workingDir,
            hostfxr_resolve_sdk2_flags_t flags,
            HostFxrResolveSdk2ResultDelegate callback)
        {
            var @delegate = delegateProvider.hostfxr_resolve_sdk2;

            hostfxr_resolve_sdk2_result_fn result = null;

            if (callback != null)
            {
                result = (key, value) =>
                {
                    var val = CrossPlatformStringMarshaller.ConvertToManaged(value);

                    callback(key, val);
                };
            }

            var status = @delegate(exeDir, workingDir, flags, result);

            GC.KeepAlive(result);

            return status;
        }

        #endregion
        #region hostfxr_run_app

        /// <summary>
        /// Load CoreCLR and run the application for an initialized host context
        /// </summary>
        /// <param name="hostContextHandle">Handle to the initialized host context</param>
        /// <remarks>
        /// The host_context_handle must have been initialized using hostfxr_initialize_for_dotnet_command_line.<para/>
        /// This function will not return until the managed application exits.
        /// </remarks>
        public void RunApp(IntPtr hostContextHandle) =>
            TryRunApp(hostContextHandle).ThrowOnNotOK();

        /// <summary>
        /// Tries to load CoreCLR and run the application for an initialized host context
        /// </summary>
        /// <param name="hostContextHandle">Handle to the initialized host context</param>
        /// <returns>If the app was successfully run, the exit code of the application. Otherwise, the error code result.</returns>
        /// <remarks>
        /// The host_context_handle must have been initialized using hostfxr_initialize_for_dotnet_command_line.<para/>
        /// This function will not return until the managed application exits.
        /// </remarks>
        public HostStatusCode TryRunApp(IntPtr hostContextHandle)
        {
            var @delegate = delegateProvider.hostfxr_run_app;

            return @delegate(hostContextHandle);
        }

        #endregion
        #region hostfxr_set_error_writer

        /// <summary>
        /// Sets a callback which is to be used to write errors to.
        /// </summary>
        /// <param name="errorWriter">A callback function which will be invoked every time an error is to be reported.
        /// Or nullptr to unregister previously registered callback and return to the default behavior.</param>
        /// <returns>The previously registered callback (which is now unregistered), or nullptr if no previous callback was registered</returns>
        /// <remarks>
        /// The error writer is registered per-thread, so the registration is thread-local. On each thread
        /// only one callback can be registered. Subsequent registrations overwrite the previous ones. <para/>
        ///
        /// By default no callback is registered in which case the errors are written to stderr.<para/>
        ///
        /// Each call to the error writer is sort of like writing a single line (the EOL character is omitted).
        /// Multiple calls to the error writer may occur for one failure.<para/>
        ///
        /// If the hostfxr invokes functions in hostpolicy as part of its operation, the error writer
        /// will be propagated to hostpolicy for the duration of the call. This means that errors from
        /// both hostfxr and hostpolicy will be reporter through the same error writer.<para/>
        /// </remarks>
        public HostFxrErrorWriterDelegate SetErrorWriter(HostFxrErrorWriterDelegate errorWriter)
        {
            var @delegate = delegateProvider.hostfxr_set_error_writer;

            hostfxr_error_writer_fn error_writer = null;

            if (errorWriter != null)
            {
                error_writer = message =>
                {
                    var msg = CrossPlatformStringMarshaller.ConvertToManaged(message);

                    errorWriter(msg);
                };
            }

            lastSetErrorWriterCallback = error_writer;

            var result = @delegate(error_writer);

            if (result == null)
                return null;

            return msg =>
            {
                var message = CrossPlatformStringMarshaller.ConvertToUnmanaged(msg);

                try
                {
                    result((IntPtr) message);
                }
                finally
                {
                    CrossPlatformStringMarshaller.Free(message);
                }
            };
        }

        #endregion
        #region hostfxr_set_runtime_property_value

        /// <summary>
        /// Sets the value of a runtime property for an initialized host context
        /// </summary>
        /// <param name="hostContextHandle">Handle to the initialized host context</param>
        /// <param name="name">Runtime property name</param>
        /// <param name="value">Value to set</param>
        /// <remarks>
        /// Setting properties is only supported for the first host context, before the runtime has been loaded.<para/>
        /// If the property already exists in the host context, it will be overwritten. If value is nullptr, the property will be removed.
        /// </remarks>
        public void SetRuntimePropertyValue(IntPtr hostContextHandle, string name, string value) =>
            TrySetRuntimePropertyValue(hostContextHandle, name, value).ThrowOnNotOK();

        /// <summary>
        /// Tries to set the value of a runtime property for an initialized host context
        /// </summary>
        /// <param name="hostContextHandle">Handle to the initialized host context</param>
        /// <param name="name">Runtime property name</param>
        /// <param name="value">Value to set</param>
        /// <returns>The error code result.</returns>
        /// <remarks>
        /// Setting properties is only supported for the first host context, before the runtime has been loaded.<para/>
        /// If the property already exists in the host context, it will be overwritten. If value is nullptr, the property will be removed.
        /// </remarks>
        public HostStatusCode TrySetRuntimePropertyValue(IntPtr hostContextHandle, string name, string value)
        {
            var @delegate = delegateProvider.hostfxr_set_runtime_property_value;

            return @delegate(hostContextHandle, name, value);
        }

        #endregion
    }

    public delegate void HostFxrGetAvailableSDKsResultDelegate(int sdkCount, string[] sdkDirs);
    public delegate void HostFxrDotnetEnvironmentInfoResultDelegate(HostFxrDotnetEnvironmentInfo info, IntPtr result_context);
    public delegate void HostFxrResolveSdk2ResultDelegate(hostfxr_resolve_sdk2_result_key_t key, string value);
    public delegate void HostFxrErrorWriterDelegate(string message);
}
