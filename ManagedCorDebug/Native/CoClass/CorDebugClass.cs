using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug.CoClass
{
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("6FEF44D0-39E7-4C77-BE8E-C9F8CF988630")]
    [TypeLibType(TypeLibTypeFlags.FCanCreate)]
    [ComImport]
    public class CorDebugClass : ICorDebug, CorDebug
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT Initialize();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT Terminate();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT SetManagedHandler([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugManagedCallback pCallback);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT SetUnmanagedHandler([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugUnmanagedCallback pCallback);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT CreateProcess(
            [MarshalAs(UnmanagedType.LPWStr), In] string lpApplicationName,
            [MarshalAs(UnmanagedType.LPWStr), In] string lpCommandLine,
            [In] ref SECURITY_ATTRIBUTES lpProcessAttributes,
            [In] ref SECURITY_ATTRIBUTES lpThreadAttributes,
            [In] bool bInheritHandles,
            [In] CreateProcessFlags dwCreationFlags,
            [In] IntPtr lpEnvironment,
            [MarshalAs(UnmanagedType.LPWStr), In] string lpCurrentDirectory,
            [In] ref STARTUPINFO lpStartupInfo,
            [In] ref PROCESS_INFORMATION lpProcessInformation,
            [In] CorDebugCreateProcessFlags debuggingFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT DebugActiveProcess(
            [In] int id,
            [In] int win32Attach,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT EnumerateProcesses(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugProcessEnum ppProcess);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT GetProcess([In] int dwProcessId,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        public virtual extern HRESULT CanLaunchOrAttach([In] int dwProcessId, [In] int win32DebuggingEnabled);
    }
}