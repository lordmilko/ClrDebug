using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D5EBB8E2-7BBE-4C1D-98A6-A3C04CBDEF64")]
    [ComImport]
    public interface ICorDebugRemote
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CreateProcessEx(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugRemoteTarget pRemoteTarget,
            [MarshalAs(UnmanagedType.LPWStr), In] string lpApplicationName,
            [MarshalAs(UnmanagedType.LPWStr), In] string lpCommandLine,
            [In] ref _SECURITY_ATTRIBUTES lpProcessAttributes,
            [In] ref _SECURITY_ATTRIBUTES lpThreadAttributes,
            [In] int bInheritHandles,
            [In] uint dwCreationFlags,
            [In] IntPtr lpEnvironment,
            [MarshalAs(UnmanagedType.LPWStr), In] string lpCurrentDirectory,
            [ComAliasName("cordebug.ULONG_PTR"), In]
            ulong lpStartupInfo,
            [ComAliasName("cordebug.ULONG_PTR"), In]
            ulong lpProcessInformation,
            [In] CorDebugCreateProcessFlags debuggingFlags,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void DebugActiveProcessEx(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugRemoteTarget pRemoteTarget,
            [In] uint dwProcessId,
            [In] int fWin32Attach,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);
    }
}