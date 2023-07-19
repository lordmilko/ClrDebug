using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.CoClass
{
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("6FEF44D0-39E7-4C77-BE8E-C9F8CF988630")]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComClass]
#endif
    public partial class CorDebugClass : ICorDebug, CorDebug
    {
        [PreserveSig]
        public virtual extern HRESULT Initialize();

        [PreserveSig]
        public virtual extern HRESULT Terminate();

        [PreserveSig]
        public virtual extern HRESULT SetManagedHandler([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugManagedCallback pCallback);

        [PreserveSig]
        public virtual extern HRESULT SetUnmanagedHandler([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugUnmanagedCallback pCallback);

        [PreserveSig]
        public virtual extern HRESULT CreateProcess(
            [MarshalAs(UnmanagedType.LPWStr), In] string lpApplicationName,
            [MarshalAs(UnmanagedType.LPWStr), In] string lpCommandLine,
            [In] ref SECURITY_ATTRIBUTES lpProcessAttributes,
            [In] ref SECURITY_ATTRIBUTES lpThreadAttributes,
            [In, MarshalAs(UnmanagedType.Bool)] bool bInheritHandles,
            [In] CreateProcessFlags dwCreationFlags,
            [In] IntPtr lpEnvironment,
            [MarshalAs(UnmanagedType.LPWStr), In] string lpCurrentDirectory,
            [In] ref STARTUPINFOW lpStartupInfo,
            [In] ref PROCESS_INFORMATION lpProcessInformation,
            [In] CorDebugCreateProcessFlags debuggingFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);

        [PreserveSig]
        public virtual extern HRESULT DebugActiveProcess(
            [In] int id,
            [In, MarshalAs(UnmanagedType.Bool)] bool win32Attach,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);

        [PreserveSig]
        public virtual extern HRESULT EnumerateProcesses(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugProcessEnum ppProcess);

        [PreserveSig]
        public virtual extern HRESULT GetProcess([In] int dwProcessId,
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);

        [PreserveSig]
        public virtual extern HRESULT CanLaunchOrAttach([In] int dwProcessId, [In] int win32DebuggingEnabled);
    }
}
