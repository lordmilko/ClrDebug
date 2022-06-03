using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3D6F5F60-7538-11D3-8D5B-00104B35E7EF")]
    [ComImport]
    public interface ICorDebugManagedCallback
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Breakpoint(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugBreakpoint pBreakpoint);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT StepComplete(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugStepper pStepper,
            [In] CorDebugStepReason reason);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Break([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread thread);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Exception([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread, [In] int unhandled);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EvalComplete([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugEval pEval);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EvalException([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugEval pEval);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CreateProcess([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ExitProcess([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CreateThread([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread thread);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ExitThread([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread thread);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT LoadModule([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugModule pModule);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT UnloadModule([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugModule pModule);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT LoadClass([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass c);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT UnloadClass([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass c);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT DebuggerError([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess, [MarshalAs(UnmanagedType.Error), In] int errorHR, [In] uint errorCode);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT LogMessage(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [In] int lLevel,
            [MarshalAs(UnmanagedType.LPWStr), In] string pLogSwitchName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pMessage);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT LogSwitch(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [In] int lLevel,
            [In] uint ulReason,
            [MarshalAs(UnmanagedType.LPWStr)]  [In] string pLogSwitchName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pParentName);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT CreateAppDomain([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ExitAppDomain([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT LoadAssembly([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAssembly pAssembly);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT UnloadAssembly([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAssembly pAssembly);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT ControlCTrap([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT NameChange([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT UpdateModuleSymbols(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugModule pModule,
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pSymbolStream);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EditAndContinueRemap(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pFunction,
            [In] int fAccurate);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT BreakpointSetError(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugBreakpoint pBreakpoint,
            [In] uint dwError);
    }
}