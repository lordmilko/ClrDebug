using System;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace ManagedCorDebug
{
    public class CorDebug : ComObject<ICorDebug>
    {
        public CorDebug(ICorDebug raw) : base(raw)
        {
        }

        #region ICorDebug
        #region Initialize

        public void Initialize()
        {
            HRESULT hr;

            if ((hr = TryInitialize()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryInitialize()
        {
            /*HRESULT Initialize();*/
            return Raw.Initialize();
        }

        #endregion
        #region Terminate

        public void Terminate()
        {
            HRESULT hr;

            if ((hr = TryTerminate()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryTerminate()
        {
            /*HRESULT Terminate();*/
            return Raw.Terminate();
        }

        #endregion
        #region SetManagedHandler

        public void SetManagedHandler(ICorDebugManagedCallback pCallback)
        {
            HRESULT hr;

            if ((hr = TrySetManagedHandler(pCallback)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetManagedHandler(ICorDebugManagedCallback pCallback)
        {
            /*HRESULT SetManagedHandler([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugManagedCallback pCallback);*/
            return Raw.SetManagedHandler(pCallback);
        }

        #endregion
        #region SetUnmanagedHandler

        public void SetUnmanagedHandler(ICorDebugUnmanagedCallback pCallback)
        {
            HRESULT hr;

            if ((hr = TrySetUnmanagedHandler(pCallback)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetUnmanagedHandler(ICorDebugUnmanagedCallback pCallback)
        {
            /*HRESULT SetUnmanagedHandler([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugUnmanagedCallback pCallback);*/
            return Raw.SetUnmanagedHandler(pCallback);
        }

        #endregion
        #region CreateProcess

        public CorDebugProcess CreateProcess(string lpApplicationName, string lpCommandLine, SECURITY_ATTRIBUTES lpProcessAttributes, SECURITY_ATTRIBUTES lpThreadAttributes, int bInheritHandles, CreateProcessFlags dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, STARTUPINFO lpStartupInfo, PROCESS_INFORMATION lpProcessInformation, CorDebugCreateProcessFlags debuggingFlags)
        {
            HRESULT hr;
            CorDebugProcess ppProcessResult;

            if ((hr = TryCreateProcess(lpApplicationName, lpCommandLine, lpProcessAttributes, lpThreadAttributes, bInheritHandles, dwCreationFlags, lpEnvironment, lpCurrentDirectory, lpStartupInfo, lpProcessInformation, debuggingFlags, out ppProcessResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppProcessResult;
        }

        public HRESULT TryCreateProcess(string lpApplicationName, string lpCommandLine, SECURITY_ATTRIBUTES lpProcessAttributes, SECURITY_ATTRIBUTES lpThreadAttributes, int bInheritHandles, CreateProcessFlags dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, STARTUPINFO lpStartupInfo, PROCESS_INFORMATION lpProcessInformation, CorDebugCreateProcessFlags debuggingFlags, out CorDebugProcess ppProcessResult)
        {
            /*HRESULT CreateProcess(
            [MarshalAs(UnmanagedType.LPWStr), In] string lpApplicationName,
            [MarshalAs(UnmanagedType.LPWStr), In] string lpCommandLine,
            [In] ref SECURITY_ATTRIBUTES lpProcessAttributes,
            [In] ref SECURITY_ATTRIBUTES lpThreadAttributes,
            [In] int bInheritHandles,
            [In] CreateProcessFlags dwCreationFlags,
            [In] IntPtr lpEnvironment,
            [MarshalAs(UnmanagedType.LPWStr), In] string lpCurrentDirectory,
            [In] ref STARTUPINFO lpStartupInfo,
            [In] ref PROCESS_INFORMATION lpProcessInformation,
            [In] CorDebugCreateProcessFlags debuggingFlags,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);*/
            ICorDebugProcess ppProcess;
            HRESULT hr = Raw.CreateProcess(lpApplicationName, lpCommandLine, ref lpProcessAttributes, ref lpThreadAttributes, bInheritHandles, dwCreationFlags, lpEnvironment, lpCurrentDirectory, ref lpStartupInfo, ref lpProcessInformation, debuggingFlags, out ppProcess);

            if (hr == HRESULT.S_OK)
                ppProcessResult = new CorDebugProcess(ppProcess);
            else
                ppProcessResult = default(CorDebugProcess);

            return hr;
        }

        #endregion
        #region DebugActiveProcess

        public CorDebugProcess DebugActiveProcess(uint id, int win32Attach)
        {
            HRESULT hr;
            CorDebugProcess ppProcessResult;

            if ((hr = TryDebugActiveProcess(id, win32Attach, out ppProcessResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppProcessResult;
        }

        public HRESULT TryDebugActiveProcess(uint id, int win32Attach, out CorDebugProcess ppProcessResult)
        {
            /*HRESULT DebugActiveProcess([In] uint id, [In] int win32Attach,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);*/
            ICorDebugProcess ppProcess;
            HRESULT hr = Raw.DebugActiveProcess(id, win32Attach, out ppProcess);

            if (hr == HRESULT.S_OK)
                ppProcessResult = new CorDebugProcess(ppProcess);
            else
                ppProcessResult = default(CorDebugProcess);

            return hr;
        }

        #endregion
        #region EnumerateProcesses

        public CorDebugProcessEnum EnumerateProcesses()
        {
            HRESULT hr;
            CorDebugProcessEnum ppProcessResult;

            if ((hr = TryEnumerateProcesses(out ppProcessResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppProcessResult;
        }

        public HRESULT TryEnumerateProcesses(out CorDebugProcessEnum ppProcessResult)
        {
            /*HRESULT EnumerateProcesses([MarshalAs(UnmanagedType.Interface)] out ICorDebugProcessEnum ppProcess);*/
            ICorDebugProcessEnum ppProcess;
            HRESULT hr = Raw.EnumerateProcesses(out ppProcess);

            if (hr == HRESULT.S_OK)
                ppProcessResult = new CorDebugProcessEnum(ppProcess);
            else
                ppProcessResult = default(CorDebugProcessEnum);

            return hr;
        }

        #endregion
        #region GetProcess

        public CorDebugProcess GetProcess(uint dwProcessId)
        {
            HRESULT hr;
            CorDebugProcess ppProcessResult;

            if ((hr = TryGetProcess(dwProcessId, out ppProcessResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppProcessResult;
        }

        public HRESULT TryGetProcess(uint dwProcessId, out CorDebugProcess ppProcessResult)
        {
            /*HRESULT GetProcess([In] uint dwProcessId, [MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);*/
            ICorDebugProcess ppProcess;
            HRESULT hr = Raw.GetProcess(dwProcessId, out ppProcess);

            if (hr == HRESULT.S_OK)
                ppProcessResult = new CorDebugProcess(ppProcess);
            else
                ppProcessResult = default(CorDebugProcess);

            return hr;
        }

        #endregion
        #region CanLaunchOrAttach

        public void CanLaunchOrAttach(uint dwProcessId, int win32DebuggingEnabled)
        {
            HRESULT hr;

            if ((hr = TryCanLaunchOrAttach(dwProcessId, win32DebuggingEnabled)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryCanLaunchOrAttach(uint dwProcessId, int win32DebuggingEnabled)
        {
            /*HRESULT CanLaunchOrAttach([In] uint dwProcessId, [In] int win32DebuggingEnabled);*/
            return Raw.CanLaunchOrAttach(dwProcessId, win32DebuggingEnabled);
        }

        #endregion
        #endregion
        #region ICorDebug2

        public ICorDebug2 Raw2 => (ICorDebug2) Raw;

        #endregion
    }
}