namespace ClrDebug
{
    /// <summary>
    /// Provides methods for configuring the common language runtime (CLR).
    /// </summary>
    public class CorConfiguration : ComObject<ICorConfiguration>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorConfiguration"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorConfiguration(ICorConfiguration raw) : base(raw)
        {
        }

        #region ICorConfiguration
        #region SetGCThreadControl

        /// <summary>
        /// Sets the callback interface for scheduling threads for non-runtime tasks that would otherwise be blocked for a garbage collection.
        /// </summary>
        /// <param name="pGCThreadControl">[in] A pointer to an <see cref="IGCThreadControl"/> object that notifies the host about the suspension of threads for non-runtime tasks.</param>
        /// <remarks>
        /// The host may choose within the <see cref="GCThreadControl.ThreadIsBlockingForSuspension"/> callback whether to
        /// reschedule a thread.
        /// </remarks>
        public void SetGCThreadControl(IGCThreadControl pGCThreadControl)
        {
            TrySetGCThreadControl(pGCThreadControl).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the callback interface for scheduling threads for non-runtime tasks that would otherwise be blocked for a garbage collection.
        /// </summary>
        /// <param name="pGCThreadControl">[in] A pointer to an <see cref="IGCThreadControl"/> object that notifies the host about the suspension of threads for non-runtime tasks.</param>
        /// <remarks>
        /// The host may choose within the <see cref="GCThreadControl.ThreadIsBlockingForSuspension"/> callback whether to
        /// reschedule a thread.
        /// </remarks>
        public HRESULT TrySetGCThreadControl(IGCThreadControl pGCThreadControl)
        {
            /*HRESULT SetGCThreadControl(
            [In, MarshalAs(UnmanagedType.Interface)] IGCThreadControl pGCThreadControl);*/
            return Raw.SetGCThreadControl(pGCThreadControl);
        }

        #endregion
        #region SetGCHostControl

        /// <summary>
        /// Sets the callback interface to be used by the garbage collector to request the host to change the limits of virtual memory.
        /// </summary>
        /// <param name="pGCHostControl">[in] A pointer to an <see cref="IGCHostControl"/> object that allows the garbage collector to request the host to change the limits of virtual memory.</param>
        public void SetGCHostControl(IGCHostControl pGCHostControl)
        {
            TrySetGCHostControl(pGCHostControl).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the callback interface to be used by the garbage collector to request the host to change the limits of virtual memory.
        /// </summary>
        /// <param name="pGCHostControl">[in] A pointer to an <see cref="IGCHostControl"/> object that allows the garbage collector to request the host to change the limits of virtual memory.</param>
        public HRESULT TrySetGCHostControl(IGCHostControl pGCHostControl)
        {
            /*HRESULT SetGCHostControl(
            [In, MarshalAs(UnmanagedType.Interface)] IGCHostControl pGCHostControl);*/
            return Raw.SetGCHostControl(pGCHostControl);
        }

        #endregion
        #region SetDebuggerThreadControl

        /// <summary>
        /// Sets the callback interface that the debugging services will call as common language runtime (CLR) threads are blocked and unblocked for debugging.
        /// </summary>
        /// <param name="pDebuggerThreadControl">[in] A pointer to an <see cref="IDebuggerThreadControl"/> object that notifies the host about the blocking and unblocking of threads by the debugging services.</param>
        public void SetDebuggerThreadControl(IDebuggerThreadControl pDebuggerThreadControl)
        {
            TrySetDebuggerThreadControl(pDebuggerThreadControl).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the callback interface that the debugging services will call as common language runtime (CLR) threads are blocked and unblocked for debugging.
        /// </summary>
        /// <param name="pDebuggerThreadControl">[in] A pointer to an <see cref="IDebuggerThreadControl"/> object that notifies the host about the blocking and unblocking of threads by the debugging services.</param>
        public HRESULT TrySetDebuggerThreadControl(IDebuggerThreadControl pDebuggerThreadControl)
        {
            /*HRESULT SetDebuggerThreadControl(
            [In, MarshalAs(UnmanagedType.Interface)] IDebuggerThreadControl pDebuggerThreadControl);*/
            return Raw.SetDebuggerThreadControl(pDebuggerThreadControl);
        }

        #endregion
        #region AddDebuggerSpecialThread

        /// <summary>
        /// Indicates to the debugging services that a particular thread should be allowed to continue executing while the debugger has an application stopped during managed or unmanaged debugging scenarios.
        /// </summary>
        /// <param name="dwSpecialThreadId">[in] The ID of the thread that should be allowed to continue executing.</param>
        /// <remarks>
        /// The specified thread will not be allowed to run managed code or enter the runtime in any way. An example of such
        /// a thread would be an in-process thread to support legacy script debuggers.
        /// </remarks>
        public void AddDebuggerSpecialThread(int dwSpecialThreadId)
        {
            TryAddDebuggerSpecialThread(dwSpecialThreadId).ThrowOnNotOK();
        }

        /// <summary>
        /// Indicates to the debugging services that a particular thread should be allowed to continue executing while the debugger has an application stopped during managed or unmanaged debugging scenarios.
        /// </summary>
        /// <param name="dwSpecialThreadId">[in] The ID of the thread that should be allowed to continue executing.</param>
        /// <remarks>
        /// The specified thread will not be allowed to run managed code or enter the runtime in any way. An example of such
        /// a thread would be an in-process thread to support legacy script debuggers.
        /// </remarks>
        public HRESULT TryAddDebuggerSpecialThread(int dwSpecialThreadId)
        {
            /*HRESULT AddDebuggerSpecialThread(
            [In] int dwSpecialThreadId);*/
            return Raw.AddDebuggerSpecialThread(dwSpecialThreadId);
        }

        #endregion
        #endregion
    }
}
