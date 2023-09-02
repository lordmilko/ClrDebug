using System;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug
{
    #region Delegates

    /// <summary>
    /// Create a native callable function pointer for a managed method.
    /// </summary>
    /// <param name="hostHandle">Handle of the host</param>
    /// <param name="domainId">Id of the domain</param>
    /// <param name="entryPointAssemblyName">Name of the assembly which holds the custom entry point</param>
    /// <param name="entryPointTypeName">Name of the type which holds the custom entry point</param>
    /// <param name="entryPointMethodName">Name of the method which is the custom entry point</param>
    /// <param name="delegate">Output parameter, the function stores a native callable function pointer to the delegate at the specified address</param>
    /// <returns>HRESULT indicating status of the operation. S_OK if the assembly was successfully executed</returns>
    public delegate HRESULT coreclr_create_delegate_fn(
        [In] IntPtr hostHandle,
        [In] int domainId,
        [MarshalAs(UnmanagedType.LPStr), In] string entryPointAssemblyName,
        [MarshalAs(UnmanagedType.LPStr), In] string entryPointTypeName,
        [MarshalAs(UnmanagedType.LPStr), In] string entryPointMethodName,
        [Out] out IntPtr @delegate);

    /// <summary>
    /// Execute a managed assembly with given arguments
    /// </summary>
    /// <param name="hostHandle">Handle of the host</param>
    /// <param name="domainId">Id of the domain</param>
    /// <param name="argc">Number of arguments passed to the executed assembly</param>
    /// <param name="argv">Array of arguments passed to the executed assembly</param>
    /// <param name="managedAssemblyPath">Path of the managed assembly to execute (or NULL if using a custom entrypoint).</param>
    /// <param name="exitCode">Exit code returned by the executed assembly</param>
    /// <returns>HRESULT indicating status of the operation. S_OK if the assembly was successfully executed</returns>
    public delegate HRESULT coreclr_execute_assembly_fn(
        [In] IntPtr hostHandle,
        [In] int domainId,
        [In] int argc,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 2), In] string[] argv,
        [MarshalAs(UnmanagedType.LPStr), In] string managedAssemblyPath,
        [Out] out int exitCode);

    /// <summary>
    /// Initialize the CoreCLR. Creates and starts CoreCLR host and creates an app domain
    /// </summary>
    /// <param name="exePath">Absolute path of the executable that invoked the ExecuteAssembly (the native host application)</param>
    /// <param name="appDomainFriendlyName">Friendly name of the app domain that will be created to execute the assembly</param>
    /// <param name="propertyCount">Number of properties (elements of the following two arguments)</param>
    /// <param name="propertyKeys">Keys of properties of the app domain</param>
    /// <param name="propertyValues">Values of properties of the app domain</param>
    /// <param name="hostHandle">Output parameter, handle of the created host</param>
    /// <param name="domainId">Output parameter, id of the created app domain</param>
    /// <returns>HRESULT indicating status of the operation. S_OK if the assembly was successfully executed</returns>
    public delegate HRESULT coreclr_initialize_fn(
        [MarshalAs(UnmanagedType.LPStr), In] string exePath,
        [MarshalAs(UnmanagedType.LPStr), In] string appDomainFriendlyName,
        [In] int propertyCount,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 2), In] string[] propertyKeys,
        [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 2), In] string[] propertyValues,
        [Out] out IntPtr hostHandle,
        [Out] out int domainId);

    /// <summary>
    /// Set callback for writing error logging
    /// </summary>
    /// <param name="error_writer">Callback that will be called for each line of the error info.<para/>
    /// Passing in NULL removes a callback that was previously set</param>
    /// <returns>S_OK</returns>
    public delegate HRESULT coreclr_set_error_writer_fn(
        [MarshalAs(UnmanagedType.FunctionPtr), In] coreclr_error_writer_callback_fn error_writer);

    /// <summary>
    /// Shutdown CoreCLR. It unloads the app domain and stops the CoreCLR host.
    /// </summary>
    /// <param name="hostHandle">Handle of the host</param>
    /// <param name="domainId">Id of the domain</param>
    /// <returns>HRESULT indicating status of the operation. S_OK if the assembly was successfully executed</returns>
    public delegate HRESULT coreclr_shutdown_fn(
        [In] IntPtr hostHandle,
        [In] int domainId);

    /// <summary>
    /// Shutdown CoreCLR. It unloads the app domain and stops the CoreCLR host.
    /// </summary>
    /// <param name="hostHandle">Handle of the host</param>
    /// <param name="domainId">Id of the domain</param>
    /// <param name="latchedExitCode">Latched exit code after domain unloaded</param>
    /// <returns>HRESULT indicating status of the operation. S_OK if the assembly was successfully executed</returns>
    public delegate HRESULT coreclr_shutdown_2_fn(
        [In] IntPtr hostHandle,
        [In] int domainId,
        [Out] out int latchedExitCode);

    public delegate void coreclr_error_writer_callback_fn(
        IntPtr message);

    public delegate HRESULT GetCLRRuntimeHostDelegate(
        [MarshalAs(UnmanagedType.LPStruct), In] Guid riid,
        [MarshalAs(UnmanagedType.Interface), Out] out object ppUnk);

    #endregion

    public class CoreCLR
    {
        private DelegateProvider delegateProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoreCLR"/> class.
        /// </summary>
        /// <param name="hModule">A handle to the coreclr library that has been loaded into the process.</param>
        public CoreCLR(IntPtr hModule)
        {
            if (hModule == IntPtr.Zero)
                throw new ArgumentNullException(nameof(hModule));

            delegateProvider = new DelegateProvider(hModule);
        }

        #region coreclr_create_delegate

        /// <summary>
        /// Create a native callable function pointer for a managed method.
        /// </summary>
        /// <param name="hostHandle">Handle of the host</param>
        /// <param name="domainId">Id of the domain</param>
        /// <param name="entryPointAssemblyName">Name of the assembly which holds the custom entry point</param>
        /// <param name="entryPointTypeName">Name of the type which holds the custom entry point</param>
        /// <param name="entryPointMethodName">Name of the method which is the custom entry point</param>
        /// <returns>A native callable function pointer to the delegate for the specified method</returns>
        public IntPtr CreateDelegate(
            IntPtr hostHandle,
            int domainId,
            string entryPointAssemblyName,
            string entryPointTypeName,
            string entryPointMethodName)
        {
            TryCreateDelegate(hostHandle, domainId, entryPointAssemblyName, entryPointTypeName, entryPointMethodName, out var @delegate);
            return @delegate;
        }

        /// <summary>
        /// Tries to create a native callable function pointer for a managed method.
        /// </summary>
        /// <param name="hostHandle">Handle of the host</param>
        /// <param name="domainId">Id of the domain</param>
        /// <param name="entryPointAssemblyName">Name of the assembly which holds the custom entry point</param>
        /// <param name="entryPointTypeName">Name of the type which holds the custom entry point</param>
        /// <param name="entryPointMethodName">Name of the method which is the custom entry point</param>
        /// <param name="delegate">Output parameter, the function stores a native callable function pointer to the delegate at the specified address</param>
        /// <returns>HRESULT indicating status of the operation. S_OK if the assembly was successfully executed</returns>
        public HRESULT TryCreateDelegate(
            IntPtr hostHandle,
            int domainId,
            string entryPointAssemblyName,
            string entryPointTypeName,
            string entryPointMethodName,
            out IntPtr @delegate)
        {
            var @delegateInternal = delegateProvider.coreclr_create_delegate;

            return delegateInternal(hostHandle, domainId, entryPointAssemblyName, entryPointTypeName, entryPointMethodName, out @delegate);
        }

        #endregion
        #region coreclr_execute_assembly

        /// <summary>
        /// Execute a managed assembly with given arguments
        /// </summary>
        /// <param name="hostHandle">Handle of the host</param>
        /// <param name="domainId">Id of the domain</param>
        /// <param name="argc">Number of arguments passed to the executed assembly</param>
        /// <param name="argv">Array of arguments passed to the executed assembly</param>
        /// <param name="managedAssemblyPath">Path of the managed assembly to execute (or NULL if using a custom entrypoint).</param>
        /// <returns>Exit code returned by the executed assembly</returns>
        public int ExecuteAssembly(
            IntPtr hostHandle,
            int domainId,
            int argc,
            string[] argv,
            string managedAssemblyPath)
        {
            TryExecuteAssembly(hostHandle, domainId, argc, argv, managedAssemblyPath, out var exitCode).ThrowOnNotOK();
            return exitCode;
        }

        /// <summary>
        /// Tries to execute a managed assembly with given arguments
        /// </summary>
        /// <param name="hostHandle">Handle of the host</param>
        /// <param name="domainId">Id of the domain</param>
        /// <param name="argc">Number of arguments passed to the executed assembly</param>
        /// <param name="argv">Array of arguments passed to the executed assembly</param>
        /// <param name="managedAssemblyPath">Path of the managed assembly to execute (or NULL if using a custom entrypoint).</param>
        /// <param name="exitCode">Exit code returned by the executed assembly</param>
        /// <returns>HRESULT indicating status of the operation. S_OK if the assembly was successfully executed</returns>
        public HRESULT TryExecuteAssembly(
            IntPtr hostHandle,
            int domainId,
            int argc,
            string[] argv,
            string managedAssemblyPath,
            out int exitCode)
        {
            var @delegate = delegateProvider.coreclr_execute_assembly;

            return @delegate(hostHandle, domainId, argc, argv, managedAssemblyPath, out exitCode);
        }

        #endregion
        #region coreclr_initialize

        /// <summary>
        /// Initialize the CoreCLR. Creates and starts CoreCLR host and creates an app domain
        /// </summary>
        /// <param name="exePath">Absolute path of the executable that invoked the ExecuteAssembly (the native host application)</param>
        /// <param name="appDomainFriendlyName">Friendly name of the app domain that will be created to execute the assembly</param>
        /// <param name="propertyCount">Number of properties (elements of the following two arguments)</param>
        /// <param name="propertyKeys">Keys of properties of the app domain</param>
        /// <param name="propertyValues">Values of properties of the app domain</param>
        /// <returns>A struct containing a handle of the created host and ID of the created AppDomain</returns>
        public CoreCLRInitializeResult Initialize(
            string exePath,
            string appDomainFriendlyName,
            int propertyCount,
            string[] propertyKeys,
            string[] propertyValues)
        {
            TryInitialize(exePath, appDomainFriendlyName, propertyCount, propertyKeys, propertyValues, out var result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Initialize the CoreCLR. Creates and starts CoreCLR host and creates an app domain
        /// </summary>
        /// <param name="exePath">Absolute path of the executable that invoked the ExecuteAssembly (the native host application)</param>
        /// <param name="appDomainFriendlyName">Friendly name of the app domain that will be created to execute the assembly</param>
        /// <param name="propertyCount">Number of properties (elements of the following two arguments)</param>
        /// <param name="propertyKeys">Keys of properties of the app domain</param>
        /// <param name="propertyValues">Values of properties of the app domain</param>
        /// <param name="result">A struct containing a handle of the created host and ID of the created AppDomain</param>
        /// <returns>HRESULT indicating status of the operation. S_OK if the assembly was successfully executed</returns>
        public HRESULT TryInitialize(
            string exePath,
            string appDomainFriendlyName,
            int propertyCount,
            string[] propertyKeys,
            string[] propertyValues,
            out CoreCLRInitializeResult result)
        {
            var @delegate = delegateProvider.coreclr_initialize;

            var hr = @delegate(exePath, appDomainFriendlyName, propertyCount, propertyKeys, propertyValues, out var hostHandle, out var domainId);

            if (hr == HRESULT.S_OK)
                result = new CoreCLRInitializeResult(hostHandle, domainId);
            else
                result = default(CoreCLRInitializeResult);

            return hr;
        }

        #endregion
        #region coreclr_set_error_writer

        /// <summary>
        /// Set callback for writing error logging
        /// </summary>
        /// <param name="errorWriter">Callback that will be called for each line of the error info.<para/>
        /// Passing in NULL removes a callback that was previously set</param>
        public void SetErrorWriter(CoreCLRErrorWriterCallbackDelegate errorWriter) =>
            TrySetErrorWriter(errorWriter).ThrowOnNotOK();

        /// <summary>
        /// Tries to set callback for writing error logging
        /// </summary>
        /// <param name="errorWriter">Callback that will be called for each line of the error info.<para/>
        /// Passing in NULL removes a callback that was previously set</param>
        /// <returns>S_OK</returns>
        public HRESULT TrySetErrorWriter(CoreCLRErrorWriterCallbackDelegate errorWriter)
        {
            var @delegate = delegateProvider.coreclr_set_error_writer;

            coreclr_error_writer_callback_fn error_writer = null;

            if (errorWriter != null)
            {
                error_writer = message =>
                {
                    var msg = Marshal.PtrToStringUni(message);

                    errorWriter(msg);
                };
            }

            return @delegate(error_writer);
        }

        #endregion
        #region coreclr_shutdown

        /// <summary>
        /// Shutdown CoreCLR. It unloads the app domain and stops the CoreCLR host.
        /// </summary>
        /// <param name="hostHandle">Handle of the host</param>
        /// <param name="domainId">Id of the domain</param>
        public void Shutdown(IntPtr hostHandle, int domainId) =>
            TryShutdown(hostHandle, domainId).ThrowOnNotOK();

        /// <summary>
        /// Tries to shutdown CoreCLR. It unloads the app domain and stops the CoreCLR host.
        /// </summary>
        /// <param name="hostHandle">Handle of the host</param>
        /// <param name="domainId">Id of the domain</param>
        /// <returns>HRESULT indicating status of the operation. S_OK if the assembly was successfully executed</returns>
        public HRESULT TryShutdown(IntPtr hostHandle, int domainId)
        {
            var @delegate = delegateProvider.coreclr_shutdown;

            return @delegate(hostHandle, domainId);
        }

        #endregion
        #region coreclr_shutdown_2

        /// <summary>
        /// Shutdown CoreCLR. It unloads the app domain and stops the CoreCLR host.
        /// </summary>
        /// <param name="hostHandle">Handle of the host</param>
        /// <param name="domainId">Id of the domain</param>
        /// <returns>Latched exit code after domain unloaded</returns>
        public int Shutdown2(IntPtr hostHandle, int domainId)
        {
            TryShutdown2(hostHandle, domainId, out var latchedExitCode).ThrowOnNotOK();
            return latchedExitCode;
        }

        /// <summary>
        /// Tries to shutdown CoreCLR. It unloads the app domain and stops the CoreCLR host.
        /// </summary>
        /// <param name="hostHandle">Handle of the host</param>
        /// <param name="domainId">Id of the domain</param>
        /// <param name="latchedExitCode">Latched exit code after domain unloaded</param>
        /// <returns>HRESULT indicating status of the operation. S_OK if the assembly was successfully executed</returns>
        public HRESULT TryShutdown2(IntPtr hostHandle, int domainId, out int latchedExitCode)
        {
            var @delegate = delegateProvider.coreclr_shutdown_2;

            return @delegate(hostHandle, domainId, out latchedExitCode);
        }

        #endregion
        #region GetCLRRuntimeHost

        public CLRRuntimeHost GetCLRRuntimeHost()
        {
            TryGetCLRRuntimeHost(out var ppUnk).ThrowOnNotOK();
            return ppUnk;
        }

        public HRESULT TryGetCLRRuntimeHost(out CLRRuntimeHost ppUnk)
        {
            var @delegate = delegateProvider.GetCLRRuntimeHost;

            var hr = @delegate(typeof(ICLRRuntimeHost).GUID, out var unk);

            if (hr == HRESULT.S_OK)
                ppUnk = new CLRRuntimeHost((ICLRRuntimeHost) unk);
            else
                ppUnk = null;

            return hr;
        }

        #endregion
        #region MetaDataGetDispenser

        public MetaDataDispenserEx MetaDataGetDispenser()
        {
            TryMetaDataGetDispenser(out var ppv).ThrowOnNotOK();
            return ppv;
        }

        public object MetaDataGetDispenser(Guid rclsid, Guid riid)
        {
            TryMetaDataGetDispenser(rclsid, riid, out var ppv).ThrowOnNotOK();
            return ppv;
        }

        public HRESULT TryMetaDataGetDispenser(out MetaDataDispenserEx ppv)
        {
            var hr = TryMetaDataGetDispenser(CLSID_CorMetaDataDispenser, typeof(IMetaDataDispenserEx).GUID, out var raw);

            if (hr == HRESULT.S_OK)
                ppv = new MetaDataDispenserEx((IMetaDataDispenserEx)raw);
            else
                ppv = null;

            return hr;
        }

        public HRESULT TryMetaDataGetDispenser(Guid rclsid, Guid riid, out object ppv)
        {
            var @delegate = delegateProvider.MetaDataGetDispenser;

            return @delegate(rclsid, riid, out ppv);
        }

        #endregion
    }

    public delegate void CoreCLRErrorWriterCallbackDelegate(string message);
}
