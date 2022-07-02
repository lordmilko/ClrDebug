namespace ClrDebug
{
    /// <summary>
    /// Allows the common language runtime (CLR) to maintain security context information implemented by the host.
    /// </summary>
    /// <remarks>
    /// A host can control all code access to thread tokens by both the CLR and user code. It can also ensure that complete
    /// security context information is passed across asynchronous operations or code points with restricted code access.
    /// <see cref="IHostSecurityContext"/> encapsulates this security context information, which is opaque to the runtime. The runtime
    /// captures this information using Capture, and moves it across thread pool worker item dispatch, finalizer execution,
    /// and module and class constructors.
    /// </remarks>
    public class HostSecurityContext : ComObject<IHostSecurityContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HostSecurityContext"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public HostSecurityContext(IHostSecurityContext raw) : base(raw)
        {
        }

        #region IHostSecurityContext
        #region Capture

        /// <summary>
        /// Gets a clone of the <see cref="IHostSecurityContext"/> instance returned from a call to <see cref="HostSecurityManager.GetSecurityContext"/>.
        /// </summary>
        /// <returns>[out] A pointer to the address of a clone of the <see cref="IHostSecurityContext"/> object to be captured.</returns>
        /// <remarks>
        /// The interface pointer returned from Capture is a clone of the captured context. When this information is moved
        /// across an asynchronous code point, its lifetime is separated from that of the pointer against which the call was
        /// made. The original pointer can therefore be released.
        /// </remarks>
        public HostSecurityContext Capture()
        {
            HostSecurityContext ppClonedContextResult;
            TryCapture(out ppClonedContextResult).ThrowOnNotOK();

            return ppClonedContextResult;
        }

        /// <summary>
        /// Gets a clone of the <see cref="IHostSecurityContext"/> instance returned from a call to <see cref="HostSecurityManager.GetSecurityContext"/>.
        /// </summary>
        /// <param name="ppClonedContextResult">[out] A pointer to the address of a clone of the <see cref="IHostSecurityContext"/> object to be captured.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | Capture returned successfully.                                                                                                                                                             |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// The interface pointer returned from Capture is a clone of the captured context. When this information is moved
        /// across an asynchronous code point, its lifetime is separated from that of the pointer against which the call was
        /// made. The original pointer can therefore be released.
        /// </remarks>
        public HRESULT TryCapture(out HostSecurityContext ppClonedContextResult)
        {
            /*HRESULT Capture([Out, MarshalAs(UnmanagedType.Interface)] out IHostSecurityContext ppClonedContext);*/
            IHostSecurityContext ppClonedContext;
            HRESULT hr = Raw.Capture(out ppClonedContext);

            if (hr == HRESULT.S_OK)
                ppClonedContextResult = new HostSecurityContext(ppClonedContext);
            else
                ppClonedContextResult = default(HostSecurityContext);

            return hr;
        }

        #endregion
        #endregion
    }
}