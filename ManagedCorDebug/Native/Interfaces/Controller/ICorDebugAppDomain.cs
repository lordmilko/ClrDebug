using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3D6F5F63-7538-11D3-8D5B-00104B35E7EF")]
    [ComImport]
    public interface ICorDebugAppDomain : ICorDebugController
    {
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Stop([In] uint dwTimeoutIgnored);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Continue([In] int fIsOutOfBand);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT IsRunning(out int pbRunning);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT HasQueuedCallbacks([MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pThread, out int pbQueued);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT EnumerateThreads([MarshalAs(UnmanagedType.Interface)] out ICorDebugThreadEnum ppThreads);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT SetAllThreadsDebugState([In] CorDebugThreadState state, [MarshalAs(UnmanagedType.Interface), In]
            ICorDebugThread pExceptThisThread);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Detach();

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT Terminate([In] uint exitCode);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT CanCommitChanges(
            [In] uint cSnapshots,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugEditAndContinueSnapshot pSnapshots,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugErrorInfoEnum pError);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        new HRESULT CommitChanges(
            [In] uint cSnapshots,
            [MarshalAs(UnmanagedType.Interface), In]
            ref ICorDebugEditAndContinueSnapshot pSnapshots,
            [MarshalAs(UnmanagedType.Interface)] out ICorDebugErrorInfoEnum pError);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetProcess([MarshalAs(UnmanagedType.Interface)] out ICorDebugProcess ppProcess);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateAssemblies([MarshalAs(UnmanagedType.Interface)] out ICorDebugAssemblyEnum ppAssemblies);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetModuleFromMetaDataInterface([MarshalAs(UnmanagedType.IUnknown), In]
            object pIMetaData, [MarshalAs(UnmanagedType.Interface)] out ICorDebugModule ppModule);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateBreakpoints([MarshalAs(UnmanagedType.Interface)] out ICorDebugBreakpointEnum ppBreakpoints);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT EnumerateSteppers([MarshalAs(UnmanagedType.Interface)] out ICorDebugStepperEnum ppSteppers);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT IsAttached(out int pbAttached);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetName([In] uint cchName, out uint pcchName, [MarshalAs(UnmanagedType.Interface), Out]
            StringBuilder szName);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetObject([MarshalAs(UnmanagedType.Interface)] out ICorDebugValue ppObject);

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT Attach();

        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        HRESULT GetID(out uint pId);
    }
}