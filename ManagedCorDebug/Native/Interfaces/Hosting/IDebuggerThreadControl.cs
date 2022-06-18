using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods for notifying the host about the blocking and unblocking of threads by the debugging services.
    /// </summary>
    [Guid("23D86786-0BB5-4774-8FB5-E3522ADD6246")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IDebuggerThreadControl
    {
        /// <summary>
        /// Notifies the host that the thread that is sending this callback is about to block within the debugging services.
        /// </summary>
        /// <remarks>
        /// The ThreadIsBlockingForDebugger method will always be called on a runtime thread. The ThreadIsBlockingForDebugger
        /// method gives the host an opportunity to perform another action while the thread blocks.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall)]
        HRESULT ThreadIsBlockingForDebugger();

        /// <summary>
        /// Notifies the host that the debugging services are about to release all threads that are blocked.
        /// </summary>
        /// <remarks>
        /// The ReleaseAllRuntimeThreads method will never be called on a runtime thread. If the host has a runtime thread
        /// blocked, it should release it now.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall)]
        HRESULT ReleaseAllRuntimeThreads();

        /// <summary>
        /// Notifies the host that the debugging services are about to start blocking all threads.
        /// </summary>
        /// <param name="dwUnused">[in] Reserved for future use.</param>
        /// <remarks>
        /// The StartBlockingForDebugger method could be called on a runtime thread.
        /// </remarks>
        [PreserveSig]
        [MethodImpl(MethodImplOptions.InternalCall)]
        HRESULT StartBlockingForDebugger([In] int dwUnused);
    }
}