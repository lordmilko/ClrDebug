using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods that handle loading and unloading modules for debugging.
    /// </summary>
    /// <remarks>
    /// You can obtain an instance of the ICLRDebugging interface by using the CLRCreateInstance function.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D28F3C5A-9634-4206-A509-477552EEFB10")]
    [ComImport]
    public interface ICLRDebugging
    {
        /// <summary>
        /// Gets the ICorDebugProcess interface that corresponds to a common language runtime (CLR) module loaded in the process.
        /// </summary>
        /// <param name="moduleBaseAddress">[in] The base address of a module in the target process. COR_E_NOT_CLR will be returned if the specified module is not a CLR module.</param>
        /// <param name="pDataTarget">[in] A data target abstraction that allows the managed debugger to inspect process state. The debugger must implement the <see cref="ICorDebugDataTarget"/> interface. You should implement the <see cref="ICLRDebuggingLibraryProvider"/> interface to support scenarios where the CLR that is being debugged is not installed locally on the computer.</param>
        /// <param name="pLibraryProvider">[in] A library provider callback interface that allows version-specific debugging libraries to be located and loaded on demand. This parameter is required only if ppProcess or pFlags is not null.</param>
        /// <param name="pMaxDebuggerSupportedVersion">[in] The highest version of the CLR that this debugger can debug. You should specify the major, minor, and build versions from the latest CLR version this debugger supports, and set the revision number to 65535 to accommodate future in-place CLR servicing releases.</param>
        /// <param name="riidProcess">[in] The ID of the ICorDebugProcess interface to retrieve. Currently, the only accepted values are IID_CORDEBUGPROCESS3, IID_CORDEBUGPROCESS2, and IID_CORDEBUGPROCESS.</param>
        /// <param name="ppProcess">[out] A pointer to the COM interface that is identified by riidProcess.</param>
        /// <param name="pVersion">[in, out] The version of the CLR. On input, this value can be null. It can also point to a <see cref="CLR_DEBUGGING_VERSION"/> structure, in which case the structure's wStructVersion field must be initialized to 0 (zero).
        /// On output, the returned CLR_DEBUGGING_VERSION structure will be filled in with the version information for the CLR.</param>
        /// <param name="pdwFlags">[out] Informational flags about the specified runtime. See the <see cref="CLR_DEBUGGING_PROCESS_FLAGS"/> topic for a description of the flags.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT OpenVirtualProcess(
            [In] ulong moduleBaseAddress,
            [MarshalAs(UnmanagedType.IUnknown), In]
            object pDataTarget,
            [MarshalAs(UnmanagedType.Interface), In]
            ICLRDebuggingLibraryProvider pLibraryProvider,
            [In] ref CLR_DEBUGGING_VERSION pMaxDebuggerSupportedVersion,
            [In] ref Guid riidProcess,
            [MarshalAs(UnmanagedType.IUnknown)] out object ppProcess,
            [In] [Out] ref CLR_DEBUGGING_VERSION pVersion,
            out CLR_DEBUGGING_PROCESS_FLAGS pdwFlags);

        /// <summary>
        /// Determines whether a library that was provided by an <see cref="ICLRDebuggingLibraryProvider"/> interface is still in use or can be unloaded.
        /// </summary>
        /// <param name="hModule">[in] The base address of a module in the target process.</param>
        /// <remarks>
        /// This method checks to see if all instances of ICorDebug* interfaces have been released and no thread is currently
        /// within a call to the <see cref="ICLRDebugging.OpenVirtualProcess"/> method.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CanUnloadNow(IntPtr hModule);
    }
}