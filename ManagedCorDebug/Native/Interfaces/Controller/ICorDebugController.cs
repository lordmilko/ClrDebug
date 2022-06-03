using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("3D6F5F62-7538-11D3-8D5B-00104B35E7EF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugController
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Stop([In] uint dwTimeoutIgnored);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Continue([In] int fIsOutOfBand);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void IsRunning(out int pbRunning);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void HasQueuedCallbacks([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread, out int pbQueued);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void EnumerateThreads([MarshalAs(UnmanagedType.Interface)] out ICorDebugThreadEnum ppThreads);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetAllThreadsDebugState([In] CorDebugThreadState state, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pExceptThisThread);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Detach();

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void Terminate([In] uint exitCode);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CanCommitChanges(
            [In] uint cSnapshots,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugEditAndContinueSnapshot pSnapshots,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugErrorInfoEnum pError);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void CommitChanges(
            [In] uint cSnapshots,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugEditAndContinueSnapshot pSnapshots,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugErrorInfoEnum pError);
    }
}