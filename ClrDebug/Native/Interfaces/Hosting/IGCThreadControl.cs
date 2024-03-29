﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug
{
    /// <summary>
    /// Provides methods for participating in the scheduling of threads that would otherwise be blocked for a garbage collection.
    /// </summary>
    [Guid("F31D1788-C397-4725-87A5-6AF3472C2791")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IGCThreadControl
    {
        /// <summary>
        /// Notifies the host that the thread that is making the call is about to block, perhaps for a garbage collection or other suspension.
        /// </summary>
        /// <remarks>
        /// The host may choose within the ThreadIsBlockingForSuspension callback whether to reschedule a thread.
        /// </remarks>
        [PreserveSig]
        HRESULT ThreadIsBlockingForSuspension();

        /// <summary>
        /// Notifies the host that the runtime is beginning a thread suspension for a garbage collection or other suspension.
        /// </summary>
        /// <remarks>
        /// Do not reschedule any threads during the SuspensionStarting callback.
        /// </remarks>
        [PreserveSig]
        HRESULT SuspensionStarting();

        /// <summary>
        /// Notifies the host that the runtime is resuming threads after a garbage collection or other suspension.
        /// </summary>
        /// <param name="Generation">[in] The generation on which a garbage collection has been performed.</param>
        /// <remarks>
        /// Do not reschedule any threads during the SuspensionEnding callback.
        /// </remarks>
        [PreserveSig]
        HRESULT SuspensionEnding(
            [In] int Generation);
    }
}
