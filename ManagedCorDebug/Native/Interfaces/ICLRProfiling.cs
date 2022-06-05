using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B349ABE3-B56F-4689-BFCD-76BF39D888EA")]
    [ComImport]
    public interface ICLRProfiling
    {
        /// <summary>
        /// Attaches the specified profiler to the specified process.
        /// </summary>
        /// <param name="dwProfileeProcessID">[in] The process ID of the process to which the profiler should be attached. On a 64-bit machine, the profiled process's bitness must match the bitness of the trigger process that is calling AttachProfiler. If the user account under which AttachProfiler is called has administrative privileges, the target process may be any process on the system. Otherwise, the target process must be owned by the same user account.</param>
        /// <param name="dwMillisecondsMax">[in] The time duration, in milliseconds, for AttachProfiler to complete. The trigger process should pass a timeout that is known to be sufficient for the particular profiler to complete its initialization.</param>
        /// <param name="pClsidProfiler">[in] A pointer to the CLSID of the profiler to be loaded. The trigger process can reuse this memory after AttachProfiler returns.</param>
        /// <param name="wszProfilerPath">[in] The full path to the profiler’s DLL file to be loaded. This string should contain no more than 260 characters, including the null terminator. If wszProfilerPath is null or an empty string, the common language runtime (CLR) will try to find the location of the profiler’s DLL file by looking in the registry for the CLSID that pClsidProfiler points to.</param>
        /// <param name="pvClientData">[in] A pointer to data to be passed to the profiler by the <see cref="ICorProfilerCallback3.InitializeForAttach"/> method. The trigger process can reuse this memory after AttachProfiler returns. If pvClientData is null, cbClientData must be 0 (zero).</param>
        /// <param name="cbClientData">[in] The size, in bytes, of the data that pvClientData points to.</param>
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