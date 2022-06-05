using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
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
    [ComImport]
    public interface ICorDebugRemote
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
        /// <param name="lpCurrentDirectory">[in] Pointer to a null-terminated string that specifies the full path to the current directory for the process. If this parameter is null, the new process will have the same current drive and directory as the calling process.</param>
        /// <param name="lpStartupInfo">[in] Unused for remote debugging.</param>
        /// <param name="lpProcessInformation">[in] Unused for remote debugging.</param>
        /// <param name="debuggingFlags">[in] Unused for remote debugging.</param>
        /// <param name="ppProcess">[out] A pointer to the address of a"ICorDebugProcess Interface" object that represents the process.</param>
        /// <remarks>
        /// Mixed-mode debugging is not supported in Silverlight.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CreateProcessEx(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugRemoteTarget pRemoteTarget,
            [MarshalAs(UnmanagedType.LPWStr), In] string lpApplicationName,
            [MarshalAs(UnmanagedType.LPWStr), In] string lpCommandLine,
            [In] ref SECURITY_ATTRIBUTES lpProcessAttributes,
            [In] ref SECURITY_ATTRIBUTES lpThreadAttributes,
            [In] int bInheritHandles,
            [In] uint dwCreationFlags,
            [In] IntPtr lpEnvironment,
            [MarshalAs(UnmanagedType.LPWStr), In] string lpCurrentDirectory,
            [In] ulong lpStartupInfo,
            [In] ulong lpProcessInformation,
            [In] CorDebugCreateProcessFlags debuggingFlags,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);

        /// <summary>
        /// Launches a process on a remote machine under the debugger.
        /// </summary>
        /// <param name="pRemoteTarget">[in] Pointer to an <see cref="ICorDebugRemoteTarget"/>. This parameter is used to determine the machine on which the process is running.</param>
        /// <param name="dwProcessId">[in] The ID of the process to which the debugger is to be attached.</param>
        /// <param name="fWin32Attach">[in] true if the debugger should behave as the Win32 debugger for the process and dispatch the unmanaged callbacks; otherwise, false.</param>
        /// <param name="ppProcess">[out] A pointer to the address of an "ICorDebugProcess" object that represents the process to which the debugger has been attached.</param>
        /// <remarks>
        /// Mixed-mode debugging is not supported in Silverlight.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT DebugActiveProcessEx(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugRemoteTarget pRemoteTarget,
            [In] uint dwProcessId,
            [In] int fWin32Attach,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);
    }
}