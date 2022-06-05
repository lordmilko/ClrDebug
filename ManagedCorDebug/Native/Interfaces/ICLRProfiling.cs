using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides the <see cref="AttachProfiler"/> method, which enables a profiler to attach to a running process.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B349ABE3-B56F-4689-BFCD-76BF39D888EA")]
    [ComImport]
    public interface ICLRProfiling
    {
        /// <summary>
        /// Attaches the specified profiler to the specified process.
        /// </summary>
        /// <param name="dwProfileeProcessID">[in] The process ID of the process to which the profiler should be attached. On a 64-bit machine, the profiled process's bitness must match the bitness of the trigger process that is calling AttachProfiler.<para/>
        /// If the user account under which AttachProfiler is called has administrative privileges, the target process may be any process on the system.<para/>
        /// Otherwise, the target process must be owned by the same user account.</param>
        /// <param name="dwMillisecondsMax">[in] The time duration, in milliseconds, for AttachProfiler to complete. The trigger process should pass a timeout that is known to be sufficient for the particular profiler to complete its initialization.</param>
        /// <param name="pClsidProfiler">[in] A pointer to the CLSID of the profiler to be loaded. The trigger process can reuse this memory after AttachProfiler returns.</param>
        /// <param name="wszProfilerPath">[in] The full path to the profiler’s DLL file to be loaded. This string should contain no more than 260 characters, including the null terminator.<para/>
        /// If wszProfilerPath is null or an empty string, the common language runtime (CLR) will try to find the location of the profiler’s DLL file by looking in the registry for the CLSID that pClsidProfiler points to.</param>
        /// <param name="pvClientData">[in] A pointer to data to be passed to the profiler by the ICorProfilerCallback3.InitializeForAttach method. The trigger process can reuse this memory after AttachProfiler returns.<para/>
        /// If pvClientData is null, cbClientData must be 0 (zero).</param>
        /// <param name="cbClientData">[in] The size, in bytes, of the data that pvClientData points to.</param>
        /// <returns>
        /// This method returns the following HRESULTs.
        /// 
        /// | HRESULT                                      | Description                                                                                                                                                                                                                        |
        /// | -------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                                         | The specified profiler has successfully attached to the target process.                                                                                                                                                            |
        /// | CORPROF_E_PROFILER_ALREADY_ACTIVE            | There is already a profiler active or attaching to the target process.                                                                                                                                                             |
        /// | CORPROF_E_PROFILER_NOT_ATTACHABLE            | The specified profiler does not support attachment. The trigger process may attempt to attach a different profiler.                                                                                                                |
        /// | CORPROF_E_PROFILEE_INCOMPATIBLE_WITH_TRIGGER | Unable to request a profiler attachment, because the version of the target process is incompatible with the current process that is calling AttachProfiler.                                                                        |
        /// | HRESULT_FROM_WIN32(ERROR_ACCESS_DENIED)      | The user of the trigger process does not have access to the target process.                                                                                                                                                        |
        /// | HRESULT_FROM_WIN32(ERROR_PRIVILEGE_NOT_HELD) | The user of the trigger process does not have the privileges necessary to attach a profiler to the given target process. The application event log may contain more information.                                                   |
        /// | CORPROF_E_IPC_FAILED                         | A failure occurred when communicating with the target process. This commonly happens if the target process was shutting down.                                                                                                      |
        /// | HRESULT_FROM_WIN32(ERROR_FILE_NOT_FOUND)     | The target process does not exist or is not running a CLR that supports attachment. This may indicate that the CLR was unloaded since the call to the runtime enumeration method.                                                  |
        /// | HRESULT_FROM_WIN32(ERROR_TIMEOUT)            | The timeout expired without beginning to load the profiler. You can retry the attach operation. Timeouts occur when a finalizer in the target process runs for a longer time than the timeout value.                               |
        /// | E_INVALIDARG                                 | One or more parameters have invalid values.                                                                                                                                                                                        |
        /// | E_FAIL                                       | Some other, unspecified failure occurred.                                                                                                                                                                                          |
        /// | Other error codes                            | If the profiler’s ICorProfilerCallback3.InitializeForAttach method returns an HRESULT that indicates failure, AttachProfiler returns that same HRESULT. In this case, E_NOTIMPL is converted to CORPROF_E_PROFILER_NOT_ATTACHABLE. |
        /// </returns>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT AttachProfiler(
            [In] uint dwProfileeProcessID,
            [In] uint dwMillisecondsMax,
            [In] ref Guid pClsidProfiler,
            [MarshalAs(UnmanagedType.LPWStr), In] string wszProfilerPath,
            [In] IntPtr pvClientData,
            [In] uint cbClientData);
    }
}