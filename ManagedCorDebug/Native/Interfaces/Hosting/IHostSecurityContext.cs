using System.Runtime.InteropServices;

namespace ManagedCorDebug
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
    [Guid("7E573CE4-0343-4423-98D7-6318348A1D3C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IHostSecurityContext
    {
        /// <summary>
        /// Gets a clone of the <see cref="IHostSecurityContext"/> instance returned from a call to <see cref="IHostSecurityManager.GetSecurityContext"/>.
        /// </summary>
        /// <param name="ppClonedContext">[out] A pointer to the address of a clone of the <see cref="IHostSecurityContext"/> object to be captured.</param>
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
        [PreserveSig]
        HRESULT Capture([Out, MarshalAs(UnmanagedType.Interface)] out IHostSecurityContext ppClonedContext);
    }
}