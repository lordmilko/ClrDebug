using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("6FEF44D0-39E7-4C77-BE8E-C9F8CF988630")]
    [TypeLibType(TypeLibTypeFlags.FCanCreate)]
    [ComImport]
    public class CorDebugClass : ICorDebug, CorDebug
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void Initialize();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void Terminate();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void SetManagedHandler([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugManagedCallback pCallback);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void SetUnmanagedHandler([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugUnmanagedCallback pCallback);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void CreateProcess(
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
        public virtual extern void DebugActiveProcess(
            [In] uint id,
            [In] int win32Attach,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void EnumerateProcesses(
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugProcessEnum ppProcess);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void GetProcess([In] uint dwProcessId,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern void CanLaunchOrAttach([In] uint dwProcessId, [In] int win32DebuggingEnabled);
    }
}