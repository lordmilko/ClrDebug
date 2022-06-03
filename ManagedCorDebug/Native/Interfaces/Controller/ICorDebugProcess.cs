using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    [Guid("3D6F5F64-7538-11D3-8D5B-00104B35E7EF")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICorDebugProcess : ICorDebugController
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
        void GetID(out uint pdwProcessId);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetHandle([ComAliasName("cordebug.long")] out uint phProcessHandle);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetThread([In] uint dwThreadId, [MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void EnumerateObjects([MarshalAs(UnmanagedType.Interface)] out ICorDebugObjectEnum ppObjects);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void IsTransitionStub([In] ulong address, out int pbTransitionStub);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void IsOSSuspended([In] uint threadID, out int pbSuspended);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetThreadContext([In] uint threadID, [In] uint contextSize, [MarshalAs(UnmanagedType.Interface), In, Out]
            ICorDebugProcess context);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void SetThreadContext([In] uint threadID, [In] uint contextSize, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugProcess context);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ReadMemory([In] ulong address, [In] uint size, [MarshalAs(UnmanagedType.Interface), Out]
            ICorDebugProcess buffer, [ComAliasName("cordebug.ULONG_PTR")] out ulong read);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void WriteMemory([In] ulong address, [In] uint size, [In] ref byte buffer,
            [ComAliasName("cordebug.ULONG_PTR")] out ulong written);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ClearCurrentException([In] uint threadID);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void EnableLogMessages([In] int fOnOff);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ModifyLogSwitch([In] ref ushort pLogSwitchName, [In] int lLevel);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void EnumerateAppDomains([MarshalAs(UnmanagedType.Interface)] out ICorDebugAppDomainEnum ppAppDomains);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetObject([MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppObject);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void ThreadForFiberCookie([In] uint fiberCookie,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugThread ppThread);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void GetHelperThreadID(out uint pThreadID);
    }
}