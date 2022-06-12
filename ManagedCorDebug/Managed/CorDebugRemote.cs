using System;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides the ability to launch or attach a managed debugger to a remote target process.
    /// </summary>
    /// <remarks>
    /// Currently, this functionality is supported only for debugging a Silverlight-based application target that is running
    /// on a remote Macintosh machine.
    /// </remarks>
    public class CorDebugRemote : ComObject<ICorDebugRemote>
    {
        public CorDebugRemote(ICorDebugRemote raw) : base(raw)
        {
        }

        #region ICorDebugRemote
        #region CreateProcessEx

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
        /// <returns>[out] A pointer to the address of a"ICorDebugProcess Interface" object that represents the process.</returns>
        /// <remarks>
        /// Mixed-mode debugging is not supported in Silverlight.
        /// </remarks>
        public CorDebugProcess CreateProcessEx(ICorDebugRemoteTarget pRemoteTarget, string lpApplicationName, string lpCommandLine, SECURITY_ATTRIBUTES lpProcessAttributes, SECURITY_ATTRIBUTES lpThreadAttributes, int bInheritHandles, int dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, STARTUPINFO lpStartupInfo, PROCESS_INFORMATION lpProcessInformation, CorDebugCreateProcessFlags debuggingFlags)
        {
            HRESULT hr;
            CorDebugProcess ppProcessResult;

            if ((hr = TryCreateProcessEx(pRemoteTarget, lpApplicationName, lpCommandLine, lpProcessAttributes, lpThreadAttributes, bInheritHandles, dwCreationFlags, lpEnvironment, lpCurrentDirectory, lpStartupInfo, lpProcessInformation, debuggingFlags, out ppProcessResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppProcessResult;
        }

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
        /// <param name="ppProcessResult">[out] A pointer to the address of a"ICorDebugProcess Interface" object that represents the process.</param>
        /// <returns>
        /// * S_OK - Successfully launched the process on the remote machine and returned an "ICorDebugProcess Interface" for debugging.
        /// * E_FAIL (or other E_ return codes) - Unable to launch the process on the remote machine and return an "ICorDebugProcess Interface" for debugging.
        /// </returns>
        /// <remarks>
        /// Mixed-mode debugging is not supported in Silverlight.
        /// </remarks>
        public HRESULT TryCreateProcessEx(ICorDebugRemoteTarget pRemoteTarget, string lpApplicationName, string lpCommandLine, SECURITY_ATTRIBUTES lpProcessAttributes, SECURITY_ATTRIBUTES lpThreadAttributes, int bInheritHandles, int dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, STARTUPINFO lpStartupInfo, PROCESS_INFORMATION lpProcessInformation, CorDebugCreateProcessFlags debuggingFlags, out CorDebugProcess ppProcessResult)
        {
            /*HRESULT CreateProcessEx(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugRemoteTarget pRemoteTarget,
            [MarshalAs(UnmanagedType.LPWStr), In] string lpApplicationName,
            [MarshalAs(UnmanagedType.LPWStr), In] string lpCommandLine,
            [In] ref SECURITY_ATTRIBUTES lpProcessAttributes,
            [In] ref SECURITY_ATTRIBUTES lpThreadAttributes,
            [In] int bInheritHandles,
            [In] int dwCreationFlags,
            [In] IntPtr lpEnvironment,
            [MarshalAs(UnmanagedType.LPWStr), In] string lpCurrentDirectory,
            [In] ref STARTUPINFO lpStartupInfo,
            [In] ref PROCESS_INFORMATION lpProcessInformation,
            [In] CorDebugCreateProcessFlags debuggingFlags,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);*/
            ICorDebugProcess ppProcess;
            HRESULT hr = Raw.CreateProcessEx(pRemoteTarget, lpApplicationName, lpCommandLine, ref lpProcessAttributes, ref lpThreadAttributes, bInheritHandles, dwCreationFlags, lpEnvironment, lpCurrentDirectory, ref lpStartupInfo, ref lpProcessInformation, debuggingFlags, out ppProcess);

            if (hr == HRESULT.S_OK)
                ppProcessResult = new CorDebugProcess(ppProcess);
            else
                ppProcessResult = default(CorDebugProcess);

            return hr;
        }

        #endregion
        #region DebugActiveProcessEx

        /// <summary>
        /// Launches a process on a remote machine under the debugger.
        /// </summary>
        /// <param name="pRemoteTarget">[in] Pointer to an <see cref="ICorDebugRemoteTarget"/>. This parameter is used to determine the machine on which the process is running.</param>
        /// <param name="dwProcessId">[in] The ID of the process to which the debugger is to be attached.</param>
        /// <param name="fWin32Attach">[in] true if the debugger should behave as the Win32 debugger for the process and dispatch the unmanaged callbacks; otherwise, false.</param>
        /// <returns>[out] A pointer to the address of an "ICorDebugProcess" object that represents the process to which the debugger has been attached.</returns>
        /// <remarks>
        /// Mixed-mode debugging is not supported in Silverlight.
        /// </remarks>
        public CorDebugProcess DebugActiveProcessEx(ICorDebugRemoteTarget pRemoteTarget, int dwProcessId, int fWin32Attach)
        {
            HRESULT hr;
            CorDebugProcess ppProcessResult;

            if ((hr = TryDebugActiveProcessEx(pRemoteTarget, dwProcessId, fWin32Attach, out ppProcessResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppProcessResult;
        }

        /// <summary>
        /// Launches a process on a remote machine under the debugger.
        /// </summary>
        /// <param name="pRemoteTarget">[in] Pointer to an <see cref="ICorDebugRemoteTarget"/>. This parameter is used to determine the machine on which the process is running.</param>
        /// <param name="dwProcessId">[in] The ID of the process to which the debugger is to be attached.</param>
        /// <param name="fWin32Attach">[in] true if the debugger should behave as the Win32 debugger for the process and dispatch the unmanaged callbacks; otherwise, false.</param>
        /// <param name="ppProcessResult">[out] A pointer to the address of an "ICorDebugProcess" object that represents the process to which the debugger has been attached.</param>
        /// <returns>
        /// * S_OK - Successfully attached to the process on the remote machine.
        /// * E_FAIL (or other E_ return codes) - Unable to attach to the process on the remote machine.
        /// </returns>
        /// <remarks>
        /// Mixed-mode debugging is not supported in Silverlight.
        /// </remarks>
        public HRESULT TryDebugActiveProcessEx(ICorDebugRemoteTarget pRemoteTarget, int dwProcessId, int fWin32Attach, out CorDebugProcess ppProcessResult)
        {
            /*HRESULT DebugActiveProcessEx(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugRemoteTarget pRemoteTarget,
            [In] int dwProcessId,
            [In] int fWin32Attach,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);*/
            ICorDebugProcess ppProcess;
            HRESULT hr = Raw.DebugActiveProcessEx(pRemoteTarget, dwProcessId, fWin32Attach, out ppProcess);

            if (hr == HRESULT.S_OK)
                ppProcessResult = new CorDebugProcess(ppProcess);
            else
                ppProcessResult = default(CorDebugProcess);

            return hr;
        }

        #endregion
        #endregion
    }
}