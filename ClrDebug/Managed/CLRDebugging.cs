using System;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods that handle loading and unloading modules for debugging.
    /// </summary>
    /// <remarks>
    /// You can obtain an instance of the <see cref="ICLRDebugging"/> interface by using the CLRCreateInstance function.
    /// </remarks>
    public partial class CLRDebugging : ComObject<ICLRDebugging>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CLRDebugging"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CLRDebugging(ICLRDebugging raw) : base(raw)
        {
        }

        #region ICLRDebugging
        #region OpenVirtualProcess

        /// <summary>
        /// Gets the <see cref="ICorDebugProcess"/> interface that corresponds to a common language runtime (CLR) module loaded in the process.
        /// </summary>
        /// <param name="moduleBaseAddress">[in] The base address of a module in the target process. COR_E_NOT_CLR will be returned if the specified module is not a CLR module.</param>
        /// <param name="pDataTarget">[in] A data target abstraction that allows the managed debugger to inspect process state. The debugger must implement the <see cref="ICorDebugDataTarget"/> interface.<para/>
        /// You should implement the <see cref="ICLRDebuggingLibraryProvider"/> interface to support scenarios where the CLR that is being debugged is not installed locally on the computer.</param>
        /// <param name="pLibraryProvider">[in] A library provider callback interface that allows version-specific debugging libraries to be located and loaded on demand.<para/>
        /// This parameter is required only if ppProcess or pFlags is not null.</param>
        /// <param name="pMaxDebuggerSupportedVersion">[in] The highest version of the CLR that this debugger can debug. You should specify the major, minor, and build versions from the latest CLR version this debugger supports, and set the revision number to 65535 to accommodate future in-place CLR servicing releases.</param>
        /// <param name="riidProcess">[in] The ID of the <see cref="ICorDebugProcess"/> interface to retrieve. Currently, the only accepted values are IID_CORDEBUGPROCESS3, IID_CORDEBUGPROCESS2, and IID_CORDEBUGPROCESS.</param>
        /// <param name="pVersion">[in, out] The version of the CLR. On input, this value can be null. It can also point to a <see cref="CLR_DEBUGGING_VERSION"/> structure, in which case the structure's wStructVersion field must be initialized to 0 (zero).<para/>
        /// On output, the returned <see cref="CLR_DEBUGGING_VERSION"/> structure will be filled in with the version information for the CLR.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public OpenVirtualProcessResult OpenVirtualProcess(long moduleBaseAddress, ICorDebugDataTarget pDataTarget, ICLRDebuggingLibraryProvider pLibraryProvider, CLR_DEBUGGING_VERSION pMaxDebuggerSupportedVersion, Guid riidProcess, ref CLR_DEBUGGING_VERSION pVersion)
        {
            OpenVirtualProcessResult result;
            TryOpenVirtualProcess(moduleBaseAddress, pDataTarget, pLibraryProvider, pMaxDebuggerSupportedVersion, riidProcess, ref pVersion, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Gets the <see cref="ICorDebugProcess"/> interface that corresponds to a common language runtime (CLR) module loaded in the process.
        /// </summary>
        /// <param name="moduleBaseAddress">[in] The base address of a module in the target process. COR_E_NOT_CLR will be returned if the specified module is not a CLR module.</param>
        /// <param name="pDataTarget">[in] A data target abstraction that allows the managed debugger to inspect process state. The debugger must implement the <see cref="ICorDebugDataTarget"/> interface.<para/>
        /// You should implement the <see cref="ICLRDebuggingLibraryProvider"/> interface to support scenarios where the CLR that is being debugged is not installed locally on the computer.</param>
        /// <param name="pLibraryProvider">[in] A library provider callback interface that allows version-specific debugging libraries to be located and loaded on demand.<para/>
        /// This parameter is required only if ppProcess or pFlags is not null.</param>
        /// <param name="pMaxDebuggerSupportedVersion">[in] The highest version of the CLR that this debugger can debug. You should specify the major, minor, and build versions from the latest CLR version this debugger supports, and set the revision number to 65535 to accommodate future in-place CLR servicing releases.</param>
        /// <param name="riidProcess">[in] The ID of the <see cref="ICorDebugProcess"/> interface to retrieve. Currently, the only accepted values are IID_CORDEBUGPROCESS3, IID_CORDEBUGPROCESS2, and IID_CORDEBUGPROCESS.</param>
        /// <param name="pVersion">[in, out] The version of the CLR. On input, this value can be null. It can also point to a <see cref="CLR_DEBUGGING_VERSION"/> structure, in which case the structure's wStructVersion field must be initialized to 0 (zero).<para/>
        /// On output, the returned <see cref="CLR_DEBUGGING_VERSION"/> structure will be filled in with the version information for the CLR.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT                                | Description                                                                                                                                                                                                                                   |
        /// | -------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                                   | The method completed successfully.                                                                                                                                                                                                            |
        /// | E_POINTER                              | pDataTarget is null.                                                                                                                                                                                                                          |
        /// | CORDBG_E_LIBRARY_PROVIDER_ERROR        | The <see cref="ICLRDebuggingLibraryProvider"/> callback returns an error or does not provide a valid handle.                                                                                                                                  |
        /// | CORDBG_E_MISSING_DATA_TARGET_INTERFACE | pDataTarget does not implement the required data target interfaces for this version of the runtime.                                                                                                                                           |
        /// | CORDBG_E_NOT_CLR                       | The indicated module is not a CLR module. This HRESULT is also returned when a CLR module cannot be detected because memory has been corrupted, the module is not available, or the CLR version is later than the shim version.               |
        /// | CORDBG_E_UNSUPPORTED_DEBUGGING_MODEL   | This runtime version does not support this debugging model. Currently, the debugging model is not supported by CLR versions before the .NET Framework 4. The pwszVersion output parameter is still set to the correct value after this error. |
        /// | CORDBG_E_UNSUPPORTED_FORWARD_COMPAT    | The version of the CLR is greater than the version this debugger claims to support. The pwszVersion output parameter is still set to the correct value after this error.                                                                      |
        /// | E_NO_INTERFACE                         | The riidProcess interface is not available.                                                                                                                                                                                                   |
        /// | CORDBG_E_UNSUPPORTED_VERSION_STRUCT    | The CLR_DEBUGGING_VERSION structure does not have a recognized value for wStructVersion. The only accepted value at this time is 0.                                                                                                           |
        /// </returns>
        public HRESULT TryOpenVirtualProcess(long moduleBaseAddress, ICorDebugDataTarget pDataTarget, ICLRDebuggingLibraryProvider pLibraryProvider, CLR_DEBUGGING_VERSION pMaxDebuggerSupportedVersion, Guid riidProcess, ref CLR_DEBUGGING_VERSION pVersion, out OpenVirtualProcessResult result)
        {
            /*HRESULT OpenVirtualProcess(
            [In] long moduleBaseAddress,
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugDataTarget pDataTarget,
            [MarshalAs(UnmanagedType.Interface), In] ICLRDebuggingLibraryProvider pLibraryProvider,
            [In] ref CLR_DEBUGGING_VERSION pMaxDebuggerSupportedVersion,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riidProcess,
            [Out, MarshalAs(UnmanagedType.Interface)] out object ppProcess,
            [In, Out] ref CLR_DEBUGGING_VERSION pVersion,
            [Out] out CLR_DEBUGGING_PROCESS_FLAGS pdwFlags);*/
            object ppProcess;
            CLR_DEBUGGING_PROCESS_FLAGS pdwFlags;
            HRESULT hr = Raw.OpenVirtualProcess(moduleBaseAddress, pDataTarget, pLibraryProvider, ref pMaxDebuggerSupportedVersion, riidProcess, out ppProcess, ref pVersion, out pdwFlags);

            if (hr == HRESULT.S_OK)
                result = new OpenVirtualProcessResult(ppProcess, pdwFlags);
            else
                result = default(OpenVirtualProcessResult);

            return hr;
        }

        #endregion
        #region CanUnloadNow

        /// <summary>
        /// Determines whether a library that was provided by an <see cref="ICLRDebuggingLibraryProvider"/> interface is still in use or can be unloaded.
        /// </summary>
        /// <param name="hModule">[in] The base address of a module in the target process.</param>
        /// <remarks>
        /// This method checks to see if all instances of ICorDebug* interfaces have been released and no thread is currently
        /// within a call to the <see cref="OpenVirtualProcess"/> method.
        /// </remarks>
        public void CanUnloadNow(IntPtr hModule)
        {
            TryCanUnloadNow(hModule).ThrowOnNotOK();
        }

        /// <summary>
        /// Determines whether a library that was provided by an <see cref="ICLRDebuggingLibraryProvider"/> interface is still in use or can be unloaded.
        /// </summary>
        /// <param name="hModule">[in] The base address of a module in the target process.</param>
        /// <returns>
        /// This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.
        /// 
        /// | HRESULT       | Description                                               |
        /// | ------------- | --------------------------------------------------------- |
        /// | S_OK          | The module that is referenced by hmodule can be unloaded. |
        /// | S_FALSE       | The module that is referenced by hmodule is still in use. |
        /// | COR_E_NOT_CLR | The indicated module is not a CLR module.                 |
        /// </returns>
        /// <remarks>
        /// This method checks to see if all instances of ICorDebug* interfaces have been released and no thread is currently
        /// within a call to the <see cref="OpenVirtualProcess"/> method.
        /// </remarks>
        public HRESULT TryCanUnloadNow(IntPtr hModule)
        {
            /*HRESULT CanUnloadNow(
            [In] IntPtr hModule);*/
            return Raw.CanUnloadNow(hModule);
        }

        #endregion
        #endregion
    }
}
