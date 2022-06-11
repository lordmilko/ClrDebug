using System;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace ManagedCorDebug
{
    public class CorDebugRemote : ComObject<ICorDebugRemote>
    {
        public CorDebugRemote(ICorDebugRemote raw) : base(raw)
        {
        }

        #region ICorDebugRemote
        #region CreateProcessEx

        public CorDebugProcess CreateProcessEx(ICorDebugRemoteTarget pRemoteTarget, string lpApplicationName, string lpCommandLine, SECURITY_ATTRIBUTES lpProcessAttributes, SECURITY_ATTRIBUTES lpThreadAttributes, int bInheritHandles, uint dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, ulong lpStartupInfo, ulong lpProcessInformation, CorDebugCreateProcessFlags debuggingFlags)
        {
            HRESULT hr;
            CorDebugProcess ppProcessResult;

            if ((hr = TryCreateProcessEx(pRemoteTarget, lpApplicationName, lpCommandLine, lpProcessAttributes, lpThreadAttributes, bInheritHandles, dwCreationFlags, lpEnvironment, lpCurrentDirectory, lpStartupInfo, lpProcessInformation, debuggingFlags, out ppProcessResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppProcessResult;
        }

        public HRESULT TryCreateProcessEx(ICorDebugRemoteTarget pRemoteTarget, string lpApplicationName, string lpCommandLine, SECURITY_ATTRIBUTES lpProcessAttributes, SECURITY_ATTRIBUTES lpThreadAttributes, int bInheritHandles, uint dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, ulong lpStartupInfo, ulong lpProcessInformation, CorDebugCreateProcessFlags debuggingFlags, out CorDebugProcess ppProcessResult)
        {
            /*HRESULT CreateProcessEx(
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
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);*/
            ICorDebugProcess ppProcess;
            HRESULT hr = Raw.CreateProcessEx(pRemoteTarget, lpApplicationName, lpCommandLine, ref lpProcessAttributes, ref lpThreadAttributes, bInheritHandles, dwCreationFlags, lpEnvironment, lpCurrentDirectory, lpStartupInfo, lpProcessInformation, debuggingFlags, out ppProcess);

            if (hr == HRESULT.S_OK)
                ppProcessResult = new CorDebugProcess(ppProcess);
            else
                ppProcessResult = default(CorDebugProcess);

            return hr;
        }

        #endregion
        #region DebugActiveProcessEx

        public CorDebugProcess DebugActiveProcessEx(ICorDebugRemoteTarget pRemoteTarget, uint dwProcessId, int fWin32Attach)
        {
            HRESULT hr;
            CorDebugProcess ppProcessResult;

            if ((hr = TryDebugActiveProcessEx(pRemoteTarget, dwProcessId, fWin32Attach, out ppProcessResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppProcessResult;
        }

        public HRESULT TryDebugActiveProcessEx(ICorDebugRemoteTarget pRemoteTarget, uint dwProcessId, int fWin32Attach, out CorDebugProcess ppProcessResult)
        {
            /*HRESULT DebugActiveProcessEx(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugRemoteTarget pRemoteTarget,
            [In] uint dwProcessId,
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