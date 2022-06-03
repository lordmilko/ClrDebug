using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3D6F5F60-7538-11D3-8D5B-00104B35E7EF")]
    [ComImport]
    public interface ICorDebugManagedCallback
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Breakpoint(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugBreakpoint pBreakpoint);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void StepComplete(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugStepper pStepper,
            [In] CorDebugStepReason reason);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Break([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread thread);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Exception([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread, [In] int unhandled);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void EvalComplete([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugEval pEval);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void EvalException([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugEval pEval);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CreateProcess([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ExitProcess([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CreateThread([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread thread);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ExitThread([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread thread);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void LoadModule([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugModule pModule);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void UnloadModule([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugModule pModule);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void LoadClass([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass c);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void UnloadClass([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugClass c);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void DebuggerError([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess, [MarshalAs(UnmanagedType.Error), In] int errorHR, [In] uint errorCode);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void LogMessage(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [In] int lLevel,
            [MarshalAs(UnmanagedType.LPWStr), In] string pLogSwitchName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pMessage);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void LogSwitch(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [In] int lLevel,
            [In] uint ulReason,
            [MarshalAs(UnmanagedType.LPWStr)]  [In] string pLogSwitchName,
            [MarshalAs(UnmanagedType.LPWStr), In] string pParentName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CreateAppDomain([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ExitAppDomain([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void LoadAssembly([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAssembly pAssembly);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void UnloadAssembly([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAssembly pAssembly);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ControlCTrap([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess pProcess);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void NameChange([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void UpdateModuleSymbols(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugModule pModule,
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pSymbolStream);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void EditAndContinueRemap(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugFunction pFunction,
            [In] int fAccurate);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void BreakpointSetError(
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugAppDomain pAppDomain,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread,
            [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugBreakpoint pBreakpoint,
            [In] uint dwError);
    }
}