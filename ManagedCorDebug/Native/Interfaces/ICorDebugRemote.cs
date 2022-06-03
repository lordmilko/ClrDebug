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