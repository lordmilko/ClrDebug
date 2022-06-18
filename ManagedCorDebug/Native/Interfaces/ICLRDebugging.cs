using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods that handle loading and unloading modules for debugging.
    /// </summary>
    /// <remarks>
    /// You can obtain an instance of the <see cref="ICLRDebugging"/> interface by using the CLRCreateInstance function.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D28F3C5A-9634-4206-A509-477552EEFB10")]
    [ComImport]
    public interface ICLRDebugging
    {
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
        /// <param name="ppProcess">[out] A pointer to the COM interface that is identified by riidProcess.</param>
        /// <param name="pVersion">[in, out] The version of the CLR. On input, this value can be null. It can also point to a <see cref="CLR_DEBUGGING_VERSION"/> structure, in which case the structure's wStructVersion field must be initialized to 0 (zero).<para/>
        /// On output, the returned <see cref="CLR_DEBUGGING_VERSION"/> structure will be filled in with the version information for the CLR.</param>
        /// <param name="pdwFlags">[out] Informational flags about the specified runtime. See the <see cref="CLR_DEBUGGING_PROCESS_FLAGS"/> topic for a description of the flags.</param>
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
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT OpenVirtualProcess(
            [In] long moduleBaseAddress,
            [MarshalAs(UnmanagedType.IUnknown), In]
            object pDataTarget,
            [MarshalAs(UnmanagedType.Interface), In]
            ICLRDebuggingLibraryProvider pLibraryProvider,
            [In] ref CLR_DEBUGGING_VERSION pMaxDebuggerSupportedVersion,
            [In] ref Guid riidProcess,
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object ppProcess,
            [In] [Out] ref CLR_DEBUGGING_VERSION pVersion,
            [Out] out CLR_DEBUGGING_PROCESS_FLAGS pdwFlags);

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
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CanUnloadNow([In] IntPtr hModule);
    }
}