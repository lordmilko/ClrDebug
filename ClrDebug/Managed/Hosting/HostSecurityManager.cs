using System;
using System.Threading;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods that allow access to and control over the security context of the currently executing thread.
    /// </summary>
    /// <remarks>
    /// A host can control all code access to thread tokens by both the common language runtime (CLR) and user code. It
    /// can also ensure that complete security context information is passed across asynchronous operations or code points
    /// with restricted code access. <see cref="IHostSecurityContext"/> encapsulates this security context information, which is opaque
    /// to the CLR. The CLR handles managed thread context internally. It queries the process-specific <see cref="IHostSecurityManager"/>
    /// in the following situations:
    /// </remarks>
    public class HostSecurityManager : ComObject<IHostSecurityManager>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HostSecurityManager"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public HostSecurityManager(IHostSecurityManager raw) : base(raw)
        {
        }

        #region IHostSecurityManager
        #region ImpersonateLoggedOnUser

        /// <summary>
        /// Requests that code be executed using the credentials of the current user identity.
        /// </summary>
        /// <param name="hToken">[in] A token representing the credentials of the user to be impersonated.</param>
        /// <remarks>
        /// Call LogonUser or a related Win32 function to get a handle to the credentials of the current user identity. The
        /// HANDLE type is not COM-compliant, that is, its size is specific to an operating system, and it requires custom
        /// marshalling. Thus, this token is for use only within the process, between the CLR and the host.
        /// </remarks>
        public void ImpersonateLoggedOnUser(IntPtr hToken)
        {
            TryImpersonateLoggedOnUser(hToken).ThrowOnNotOK();
        }

        /// <summary>
        /// Requests that code be executed using the credentials of the current user identity.
        /// </summary>
        /// <param name="hToken">[in] A token representing the credentials of the user to be impersonated.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | ImpersonateLoggedOnUser returned successfully.                                                                                                                                             |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// Call LogonUser or a related Win32 function to get a handle to the credentials of the current user identity. The
        /// HANDLE type is not COM-compliant, that is, its size is specific to an operating system, and it requires custom
        /// marshalling. Thus, this token is for use only within the process, between the CLR and the host.
        /// </remarks>
        public HRESULT TryImpersonateLoggedOnUser(IntPtr hToken)
        {
            /*HRESULT ImpersonateLoggedOnUser([In] IntPtr hToken);*/
            return Raw.ImpersonateLoggedOnUser(hToken);
        }

        #endregion
        #region RevertToSelf

        /// <summary>
        /// Terminates impersonation of the current user identity and returns the original thread token.
        /// </summary>
        /// <remarks>
        /// RevertToSelf is called to return to the original thread token, after an earlier call to the <see cref="ImpersonateLoggedOnUser"/>
        /// method.
        /// </remarks>
        public void RevertToSelf()
        {
            TryRevertToSelf().ThrowOnNotOK();
        }

        /// <summary>
        /// Terminates impersonation of the current user identity and returns the original thread token.
        /// </summary>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | RevertToSelf returned successfully.                                                                                                                                                        |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// RevertToSelf is called to return to the original thread token, after an earlier call to the <see cref="ImpersonateLoggedOnUser"/>
        /// method.
        /// </remarks>
        public HRESULT TryRevertToSelf()
        {
            /*HRESULT RevertToSelf();*/
            return Raw.RevertToSelf();
        }

        #endregion
        #region OpenThreadToken

        /// <summary>
        /// Opens the discretionary access token associated with the currently executing thread.
        /// </summary>
        /// <param name="dwDesiredAccess">[in] A mask of access values that specify the requested types of access to the thread token. These values are defined in the Win32 OpenThreadToken function.<para/>
        /// The requested access types are reconciled against the token's discretionary access control list (DACL) to determine which types of access to grant or deny.</param>
        /// <param name="bOpenAsSelf">[in] true to specify that the access check should be made using the security context of the process for the calling thread; false to specify that the access check should be performed using the security context for the calling thread itself.<para/>
        /// If the thread is impersonating a client, the security context can be that of a client process.</param>
        /// <returns>[out] A pointer to the newly opened access token.</returns>
        /// <remarks>
        /// IHostSecurityManager::OpenThreadToken behaves similarly to the corresponding Win32 function of the same name, except
        /// that the Win32 function allows the caller to pass in a handle to an arbitrary thread, while IHostSecurityManager::OpenThreadToken
        /// opens only the token associated with the calling thread. The HANDLE type is not COM-compliant, that is, its size
        /// is specific to the operating system, and it requires custom marshalling. Thus, this token is for use only within
        /// the process, between the CLR and the host.
        /// </remarks>
        public IntPtr OpenThreadToken(int dwDesiredAccess, bool bOpenAsSelf)
        {
            IntPtr phThreadToken;
            TryOpenThreadToken(dwDesiredAccess, bOpenAsSelf, out phThreadToken).ThrowOnNotOK();

            return phThreadToken;
        }

        /// <summary>
        /// Opens the discretionary access token associated with the currently executing thread.
        /// </summary>
        /// <param name="dwDesiredAccess">[in] A mask of access values that specify the requested types of access to the thread token. These values are defined in the Win32 OpenThreadToken function.<para/>
        /// The requested access types are reconciled against the token's discretionary access control list (DACL) to determine which types of access to grant or deny.</param>
        /// <param name="bOpenAsSelf">[in] true to specify that the access check should be made using the security context of the process for the calling thread; false to specify that the access check should be performed using the security context for the calling thread itself.<para/>
        /// If the thread is impersonating a client, the security context can be that of a client process.</param>
        /// <param name="phThreadToken">[out] A pointer to the newly opened access token.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | OpenThreadToken returned successfully.                                                                                                                                                     |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// IHostSecurityManager::OpenThreadToken behaves similarly to the corresponding Win32 function of the same name, except
        /// that the Win32 function allows the caller to pass in a handle to an arbitrary thread, while IHostSecurityManager::OpenThreadToken
        /// opens only the token associated with the calling thread. The HANDLE type is not COM-compliant, that is, its size
        /// is specific to the operating system, and it requires custom marshalling. Thus, this token is for use only within
        /// the process, between the CLR and the host.
        /// </remarks>
        public HRESULT TryOpenThreadToken(int dwDesiredAccess, bool bOpenAsSelf, out IntPtr phThreadToken)
        {
            /*HRESULT OpenThreadToken(
            [In] int dwDesiredAccess,
            [In] bool bOpenAsSelf,
            [Out] out IntPtr phThreadToken);*/
            return Raw.OpenThreadToken(dwDesiredAccess, bOpenAsSelf, out phThreadToken);
        }

        #endregion
        #region SetThreadToken

        /// <summary>
        /// Sets a handle for the currently executing thread.
        /// </summary>
        /// <param name="hToken">[in] A handle to the token to set for the currently executing thread.</param>
        /// <remarks>
        /// IHostSecurityManager::SetThreadToken behaves similarly to the corresponding Win32 function of the same name, except
        /// that the Win32 function allows the caller to pass in a handle to an arbitrary thread, while IHostSecurityManager::SetThreadToken
        /// can associate a token only with the currently executing thread. The HANDLE type is not COM-compliant; that is,
        /// its size is specific to an operating system and it requires custom marshalling. Thus, this token is for use only
        /// within the process, between the CLR and the host.
        /// </remarks>
        public void SetThreadToken(IntPtr hToken)
        {
            TrySetThreadToken(hToken).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets a handle for the currently executing thread.
        /// </summary>
        /// <param name="hToken">[in] A handle to the token to set for the currently executing thread.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | SetThreadToken returned successfully.                                                                                                                                                      |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// IHostSecurityManager::SetThreadToken behaves similarly to the corresponding Win32 function of the same name, except
        /// that the Win32 function allows the caller to pass in a handle to an arbitrary thread, while IHostSecurityManager::SetThreadToken
        /// can associate a token only with the currently executing thread. The HANDLE type is not COM-compliant; that is,
        /// its size is specific to an operating system and it requires custom marshalling. Thus, this token is for use only
        /// within the process, between the CLR and the host.
        /// </remarks>
        public HRESULT TrySetThreadToken(IntPtr hToken)
        {
            /*HRESULT SetThreadToken(
            [In] IntPtr hToken);*/
            return Raw.SetThreadToken(hToken);
        }

        #endregion
        #region GetSecurityContext

        /// <summary>
        /// Gets the requested <see cref="IHostSecurityContext"/> from the host.
        /// </summary>
        /// <param name="eContextType">[in] One of the <see cref="EContextType"/> values, indicating what type of security context to return.</param>
        /// <returns>[out] The address of an interface pointer to the <see cref="IHostSecurityContext"/> of <see cref="EContextType"/>.</returns>
        /// <remarks>
        /// A host can control all code access to thread tokens by both the CLR and user code. It can also ensure that complete
        /// security context information is passed across asynchronous operations or code points with restricted code access.
        /// <see cref="IHostSecurityContext"/> encapsulates this security context information, which is opaque to the CLR. The CLR captures
        /// this information and moves it across thread pool worker item dispatch, finalizer execution, and module and class
        /// construction.
        /// </remarks>
        public HostSecurityContext GetSecurityContext(EContextType eContextType)
        {
            HostSecurityContext ppSecurityContextResult;
            TryGetSecurityContext(eContextType, out ppSecurityContextResult).ThrowOnNotOK();

            return ppSecurityContextResult;
        }

        /// <summary>
        /// Gets the requested <see cref="IHostSecurityContext"/> from the host.
        /// </summary>
        /// <param name="eContextType">[in] One of the <see cref="EContextType"/> values, indicating what type of security context to return.</param>
        /// <param name="ppSecurityContextResult">[out] The address of an interface pointer to the <see cref="IHostSecurityContext"/> of <see cref="EContextType"/>.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | GetSecurityContext returned successfully.                                                                                                                                                  |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// A host can control all code access to thread tokens by both the CLR and user code. It can also ensure that complete
        /// security context information is passed across asynchronous operations or code points with restricted code access.
        /// <see cref="IHostSecurityContext"/> encapsulates this security context information, which is opaque to the CLR. The CLR captures
        /// this information and moves it across thread pool worker item dispatch, finalizer execution, and module and class
        /// construction.
        /// </remarks>
        public HRESULT TryGetSecurityContext(EContextType eContextType, out HostSecurityContext ppSecurityContextResult)
        {
            /*HRESULT GetSecurityContext(
            [In] EContextType eContextType,
            [Out, MarshalAs(UnmanagedType.Interface)] out IHostSecurityContext ppSecurityContext);*/
            IHostSecurityContext ppSecurityContext;
            HRESULT hr = Raw.GetSecurityContext(eContextType, out ppSecurityContext);

            if (hr == HRESULT.S_OK)
                ppSecurityContextResult = new HostSecurityContext(ppSecurityContext);
            else
                ppSecurityContextResult = default(HostSecurityContext);

            return hr;
        }

        #endregion
        #region SetSecurityContext

        /// <summary>
        /// Sets the security context of the currently executing thread.
        /// </summary>
        /// <param name="eContextType">[in] One of the <see cref="EContextType"/> values, indicating what type of context the common language runtime (CLR) is placing on the host.</param>
        /// <param name="pSecurityContext">[out] A pointer to the address of a new <see cref="IHostSecurityContext"/> object.</param>
        /// <remarks>
        /// The CLR calls SetSecurityContext in several scenarios. Before it executes class and module constructors and finalizers,
        /// the CLR calls SetSecurityContext to protect the host from execution failures. It then resets the security context
        /// to its original state after execution of the constructor or finalizer, by using another call to SetSecurityContext.
        /// A similar pattern occurs with I/O completion. If the host implements <see cref="IHostIoCompletionManager"/>, the
        /// CLR calls SetSecurityContext after the host calls <see cref="CLRIoCompletionManager.OnComplete"/>. At asynchronous
        /// points in worker threads, the CLR calls SetSecurityContext within <see cref="ThreadPool.QueueUserWorkItem(WaitCallback)"/>
        /// or within <see cref="HostThreadPoolManager.QueueUserWorkItem"/>, depending on whether the host or the CLR is implementing
        /// the thread pool.
        /// </remarks>
        public void SetSecurityContext(EContextType eContextType, IHostSecurityContext pSecurityContext)
        {
            TrySetSecurityContext(eContextType, pSecurityContext).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets the security context of the currently executing thread.
        /// </summary>
        /// <param name="eContextType">[in] One of the <see cref="EContextType"/> values, indicating what type of context the common language runtime (CLR) is placing on the host.</param>
        /// <param name="pSecurityContext">[out] A pointer to the address of a new <see cref="IHostSecurityContext"/> object.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | SetSecurityContext returned successfully.                                                                                                                                                  |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                 |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// The CLR calls SetSecurityContext in several scenarios. Before it executes class and module constructors and finalizers,
        /// the CLR calls SetSecurityContext to protect the host from execution failures. It then resets the security context
        /// to its original state after execution of the constructor or finalizer, by using another call to SetSecurityContext.
        /// A similar pattern occurs with I/O completion. If the host implements <see cref="IHostIoCompletionManager"/>, the
        /// CLR calls SetSecurityContext after the host calls <see cref="CLRIoCompletionManager.OnComplete"/>. At asynchronous
        /// points in worker threads, the CLR calls SetSecurityContext within <see cref="ThreadPool.QueueUserWorkItem(WaitCallback)"/>
        /// or within <see cref="HostThreadPoolManager.QueueUserWorkItem"/>, depending on whether the host or the CLR is implementing
        /// the thread pool.
        /// </remarks>
        public HRESULT TrySetSecurityContext(EContextType eContextType, IHostSecurityContext pSecurityContext)
        {
            /*HRESULT SetSecurityContext(
            [In] EContextType eContextType,
            [In, MarshalAs(UnmanagedType.Interface)] IHostSecurityContext pSecurityContext);*/
            return Raw.SetSecurityContext(eContextType, pSecurityContext);
        }

        #endregion
        #endregion
    }
}
