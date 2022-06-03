using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("211F1254-BC7E-4AF5-B9AA-067308D83DD1")]
    [TypeLibType(TypeLibTypeFlags.FCanCreate)]
    [ClassInterface(ClassInterfaceType.None)]
    [ComImport]
    public class EmbeddedCLRCorDebugClass : ICorDebug, EmbeddedCLRCorDebug
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