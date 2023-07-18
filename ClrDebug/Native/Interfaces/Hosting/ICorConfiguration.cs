using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides methods for configuring the common language runtime (CLR).
    /// </summary>
    [Guid("5C2B07A5-1E98-11D3-872F-00C04F79ED0D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface ICorConfiguration
    {
        /// <summary>
        /// Sets the callback interface for scheduling threads for non-runtime tasks that would otherwise be blocked for a garbage collection.
        /// </summary>
        /// <param name="pGCThreadControl">[in] A pointer to an <see cref="IGCThreadControl"/> object that notifies the host about the suspension of threads for non-runtime tasks.</param>
        /// <remarks>
        /// The host may choose within the <see cref="IGCThreadControl.ThreadIsBlockingForSuspension"/> callback whether to
        /// reschedule a thread.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall)]
        HRESULT SetGCThreadControl(
            [In, MarshalAs(UnmanagedType.Interface)] IGCThreadControl pGCThreadControl);

        /// <summary>
        /// Sets the callback interface to be used by the garbage collector to request the host to change the limits of virtual memory.
        /// </summary>
        /// <param name="pGCHostControl">[in] A pointer to an <see cref="IGCHostControl"/> object that allows the garbage collector to request the host to change the limits of virtual memory.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall)]
        HRESULT SetGCHostControl(
            [In, MarshalAs(UnmanagedType.Interface)] IGCHostControl pGCHostControl);

        /// <summary>
        /// Sets the callback interface that the debugging services will call as common language runtime (CLR) threads are blocked and unblocked for debugging.
        /// </summary>
        /// <param name="pDebuggerThreadControl">[in] A pointer to an <see cref="IDebuggerThreadControl"/> object that notifies the host about the blocking and unblocking of threads by the debugging services.</param>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall)]
        HRESULT SetDebuggerThreadControl(
            [In, MarshalAs(UnmanagedType.Interface)] IDebuggerThreadControl pDebuggerThreadControl);

        /// <summary>
        /// Indicates to the debugging services that a particular thread should be allowed to continue executing while the debugger has an application stopped during managed or unmanaged debugging scenarios.
        /// </summary>
        /// <param name="dwSpecialThreadId">[in] The ID of the thread that should be allowed to continue executing.</param>
        /// <remarks>
        /// The specified thread will not be allowed to run managed code or enter the runtime in any way. An example of such
        /// a thread would be an in-process thread to support legacy script debuggers.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall)]
        HRESULT AddDebuggerSpecialThread(
            [In] int dwSpecialThreadId);
    }
}
