namespace ClrDebug
{
    /// <summary>
    /// Provides methods for notifying the host about the blocking and unblocking of threads by the debugging services.
    /// </summary>
    public class DebuggerThreadControl : ComObject<IDebuggerThreadControl>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebuggerThreadControl"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebuggerThreadControl(IDebuggerThreadControl raw) : base(raw)
        {
        }

        #region IDebuggerThreadControl
        #region ThreadIsBlockingForDebugger

        /// <summary>
        /// Notifies the host that the thread that is sending this callback is about to block within the debugging services.
        /// </summary>
        /// <remarks>
        /// The ThreadIsBlockingForDebugger method will always be called on a runtime thread. The ThreadIsBlockingForDebugger
        /// method gives the host an opportunity to perform another action while the thread blocks.
        /// </remarks>
        public void ThreadIsBlockingForDebugger()
        {
            TryThreadIsBlockingForDebugger().ThrowOnNotOK();
        }

        /// <summary>
        /// Notifies the host that the thread that is sending this callback is about to block within the debugging services.
        /// </summary>
        /// <remarks>
        /// The ThreadIsBlockingForDebugger method will always be called on a runtime thread. The ThreadIsBlockingForDebugger
        /// method gives the host an opportunity to perform another action while the thread blocks.
        /// </remarks>
        public HRESULT TryThreadIsBlockingForDebugger()
        {
            /*HRESULT ThreadIsBlockingForDebugger();*/
            return Raw.ThreadIsBlockingForDebugger();
        }

        #endregion
        #region ReleaseAllRuntimeThreads

        /// <summary>
        /// Notifies the host that the debugging services are about to release all threads that are blocked.
        /// </summary>
        /// <remarks>
        /// The ReleaseAllRuntimeThreads method will never be called on a runtime thread. If the host has a runtime thread
        /// blocked, it should release it now.
        /// </remarks>
        public void ReleaseAllRuntimeThreads()
        {
            TryReleaseAllRuntimeThreads().ThrowOnNotOK();
        }

        /// <summary>
        /// Notifies the host that the debugging services are about to release all threads that are blocked.
        /// </summary>
        /// <remarks>
        /// The ReleaseAllRuntimeThreads method will never be called on a runtime thread. If the host has a runtime thread
        /// blocked, it should release it now.
        /// </remarks>
        public HRESULT TryReleaseAllRuntimeThreads()
        {
            /*HRESULT ReleaseAllRuntimeThreads();*/
            return Raw.ReleaseAllRuntimeThreads();
        }

        #endregion
        #region StartBlockingForDebugger

        /// <summary>
        /// Notifies the host that the debugging services are about to start blocking all threads.
        /// </summary>
        /// <param name="dwUnused">[in] Reserved for future use.</param>
        /// <remarks>
        /// The StartBlockingForDebugger method could be called on a runtime thread.
        /// </remarks>
        public void StartBlockingForDebugger(int dwUnused)
        {
            TryStartBlockingForDebugger(dwUnused).ThrowOnNotOK();
        }

        /// <summary>
        /// Notifies the host that the debugging services are about to start blocking all threads.
        /// </summary>
        /// <param name="dwUnused">[in] Reserved for future use.</param>
        /// <remarks>
        /// The StartBlockingForDebugger method could be called on a runtime thread.
        /// </remarks>
        public HRESULT TryStartBlockingForDebugger(int dwUnused)
        {
            /*HRESULT StartBlockingForDebugger(
            [In] int dwUnused);*/
            return Raw.StartBlockingForDebugger(dwUnused);
        }

        #endregion
        #endregion
    }
}
