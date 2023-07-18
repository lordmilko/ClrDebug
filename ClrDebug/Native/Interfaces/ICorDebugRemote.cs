using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides the ability to launch or attach a managed debugger to a remote target process.
    /// </summary>
    /// <remarks>
    /// Currently, this functionality is supported only for debugging a Silverlight-based application target that is running
    /// on a remote Macintosh machine.
    /// </remarks>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D5EBB8E2-7BBE-4C1D-98A6-A3C04CBDEF64")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorDebugRemote
    {
        /// <summary>
        /// Launches a process on a remote machine under the debugger.
        /// </summary>
        /// <param name="pRemoteTarget">[in] Pointer to an <see cref="ICorDebugRemoteTarget"/>. Used to determine the remote machine on which the process will be launched.</param>
        /// <param name="lpApplicationName">[in] Pointer to a null-terminated string that specifies the module to be executed by the launched process. The module is executed in the security context of the calling process.</param>
        /// <param name="lpCommandLine">[in] Pointer to a null-terminated string that specifies the command line to be executed by the launched process.</param>
        /// <param name="lpProcessAttributes">[in] Unused for remote debugging.</param>
        /// <param name="lpThreadAttributes">[in] Unused for remote debugging.</param>
        /// <param name="bInheritHandles">[in] Unused for remote debugging.</param>
        /// <param name="dwCreationFlags">[in] Unused for remote debugging.</param>
        /// <param name="lpEnvironment">[in] Pointer to an environment block for the new process.</param>
        /// <param name="lpCurrentDirectory">[in] Pointer to a null-terminated string that specifies the full path to the current directory for the process.<para/>
        /// If this parameter is null, the new process will have the same current drive and directory as the calling process.</param>
        /// <param name="lpStartupInfo">[in] Unused for remote debugging.</param>
        /// <param name="lpProcessInformation">[in] Unused for remote debugging.</param>
        /// <param name="debuggingFlags">[in] Unused for remote debugging.</param>
        /// <param name="ppProcess">[out] A pointer to the address of a"ICorDebugProcess Interface" object that represents the process.</param>
        /// <returns>
        /// * S_OK - Successfully launched the process on the remote machine and returned an "ICorDebugProcess Interface" for debugging.
        /// * E_FAIL (or other E_ return codes) - Unable to launch the process on the remote machine and return an "ICorDebugProcess Interface" for debugging.
        /// </returns>
        /// <remarks>
        /// Mixed-mode debugging is not supported in Silverlight.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CreateProcessEx(
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugRemoteTarget pRemoteTarget,
            [MarshalAs(UnmanagedType.LPWStr), In] string lpApplicationName,
            [MarshalAs(UnmanagedType.LPWStr), In] string lpCommandLine,
            [In] ref SECURITY_ATTRIBUTES lpProcessAttributes,
            [In] ref SECURITY_ATTRIBUTES lpThreadAttributes,
            [In, MarshalAs(UnmanagedType.Bool)] bool bInheritHandles,
            [In] CreateProcessFlags dwCreationFlags,
            [In] IntPtr lpEnvironment,
            [MarshalAs(UnmanagedType.LPWStr), In] string lpCurrentDirectory,
            [In] ref STARTUPINFOW lpStartupInfo,
            [In] ref PROCESS_INFORMATION lpProcessInformation,
            [In] CorDebugCreateProcessFlags debuggingFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);

        /// <summary>
        /// Launches a process on a remote machine under the debugger.
        /// </summary>
        /// <param name="pRemoteTarget">[in] Pointer to an <see cref="ICorDebugRemoteTarget"/>. This parameter is used to determine the machine on which the process is running.</param>
        /// <param name="dwProcessId">[in] The ID of the process to which the debugger is to be attached.</param>
        /// <param name="fWin32Attach">[in] true if the debugger should behave as the Win32 debugger for the process and dispatch the unmanaged callbacks; otherwise, false.</param>
        /// <param name="ppProcess">[out] A pointer to the address of an "ICorDebugProcess" object that represents the process to which the debugger has been attached.</param>
        /// <returns>
        /// * S_OK - Successfully attached to the process on the remote machine.
        /// * E_FAIL (or other E_ return codes) - Unable to attach to the process on the remote machine.
        /// </returns>
        /// <remarks>
        /// Mixed-mode debugging is not supported in Silverlight.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT DebugActiveProcessEx(
            [MarshalAs(UnmanagedType.Interface), In] ICorDebugRemoteTarget pRemoteTarget,
            [In] int dwProcessId,
            [In, MarshalAs(UnmanagedType.Bool)] bool fWin32Attach,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);
    }
}
