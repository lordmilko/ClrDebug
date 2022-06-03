using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3D6F5F63-7538-11D3-8D5B-00104B35E7EF")]
    [ComImport]
    public interface ICorDebugAppDomain : ICorDebugController
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void Stop([In] uint dwTimeoutIgnored);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void Continue([In] int fIsOutOfBand);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void IsRunning(out int pbRunning);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void HasQueuedCallbacks([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread, out int pbQueued);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void EnumerateThreads([MarshalAs(UnmanagedType.Interface)] out ICorDebugThreadEnum ppThreads);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void SetAllThreadsDebugState([In] CorDebugThreadState state, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pExceptThisThread);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void Detach();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void Terminate([In] uint exitCode);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void CanCommitChanges(
            [In] uint cSnapshots,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugEditAndContinueSnapshot pSnapshots,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugErrorInfoEnum pError);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new void CommitChanges(
            [In] uint cSnapshots,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugEditAndContinueSnapshot pSnapshots,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugErrorInfoEnum pError);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetProcess([MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void EnumerateAssemblies([MarshalAs(UnmanagedType.Interface)] out ICorDebugAssemblyEnum ppAssemblies);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetModuleFromMetaDataInterface([MarshalAs(UnmanagedType.IUnknown), In]
            object pIMetaData, [MarshalAs(UnmanagedType.Interface)] out ICorDebugModule ppModule);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void EnumerateBreakpoints([MarshalAs(UnmanagedType.Interface)] out ICorDebugBreakpointEnum ppBreakpoints);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void EnumerateSteppers([MarshalAs(UnmanagedType.Interface)] out ICorDebugStepperEnum ppSteppers);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void IsAttached(out int pbAttached);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetName([In] uint cchName, out uint pcchName, [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugAppDomain szName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetObject([MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppObject);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Attach();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetID(out uint pId);
    }
}