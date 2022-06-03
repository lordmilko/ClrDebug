using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("3D6F5F61-7538-11D3-8D5B-00104B35E7EF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebug
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Initialize();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Terminate();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetManagedHandler([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugManagedCallback pCallback);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetUnmanagedHandler([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugUnmanagedCallback pCallback);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CreateProcess(
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
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void DebugActiveProcess([In] uint id, [In] int win32Attach,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void EnumerateProcesses([MarshalAs(UnmanagedType.Interface)] out ICorDebugProcessEnum ppProcess);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetProcess([In] uint dwProcessId, [MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CanLaunchOrAttach([In] uint dwProcessId, [In] int win32DebuggingEnabled);
    }
}