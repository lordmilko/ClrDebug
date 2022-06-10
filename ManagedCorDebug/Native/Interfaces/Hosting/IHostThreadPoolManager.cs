using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods that enable the common language runtime (CLR) to configure the thread pool and to queue work items to the thread pool.
    /// </summary>
    /// <remarks>
    /// The host is not required to configure the thread pool by using the values specified in calls to the SetMaxThreads
    /// and SetMinThreads methods. In this case, the host should return an <see cref="HRESULT"/> value of E_NOTIMPL from these methods.
    /// </remarks>
    [Guid("983D50E2-CB15-466B-80FC-845DC6E8C5FD")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IHostThreadPoolManager
    {
        /// <summary>
        /// Queues a function for execution, and specifies an object containing data to be used by that function. The function executes when a thread becomes available.
        /// </summary>
        /// <param name="Function">[in] A function pointer that represents the function to execute.</param>
        /// <param name="Context">[in] An object that contains data to be used by Function.</param>
        /// <param name="Flags">[in] One of the flags values, as defined for the Win32 QueueUserWorkItem method, that control execution.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | QueueUserWorkItem returned successfully.                                                                                                                                                   |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// QueueUserWorkItem queues a work item to a worker thread in the thread pool. Its signature and parameter types are
        /// identical to those of the corresponding Win32 function, which has the same name. For more information, see the
        /// Windows Platform documentation.
        /// </remarks>
        [PreserveSig]
        HRESULT QueueUserWorkItem(
            [In, MarshalAs(UnmanagedType.FunctionPtr)] LPTHREAD_START_ROUTINE Function,
            [In] IntPtr Context,
            [In] uint Flags);

        /// <summary>
        /// Sets the maximum number of threads that the host can maintain in the thread pool.
        /// </summary>
        /// <param name="dwMaxWorkerThreads">The maximum number of worker threads in the thread pool.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                 |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | SetMaxThreads returned successfully.                                                                                                                                                        |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                        |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                         |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                           |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                    |
        /// | E_FAIL                 | An unknown, catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | E_NOTIMPL              | The host does not provide an implementation of SetMaxThreads.                                                                                                                               |
        /// </returns>
        /// <remarks>
        /// A host is not required to allow the CLR to configure the size of the thread pool. Some hosts might want exclusive
        /// control over the thread pool, for reasons such as implementation, performance, or scalability. In this case, a
        /// host should return an <see cref="HRESULT"/> value of E_NOTIMPL.
        /// </remarks>
        [PreserveSig]
        HRESULT SetMaxThreads(
            [In] uint dwMaxWorkerThreads);

        /// <summary>
        /// Gets the maximum number of threads that the host maintains concurrently in the thread pool.
        /// </summary>
        /// <param name="pdwMaxWorkerThreads">[out] A pointer to the maximum number of threads that the host maintains in the thread pool.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | GetMaxThreads returned successfully.                                                                                                                                                       |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR( has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | E_NOTIMPL              | The host does not provide an implementation of GetMaxThreads.                                                                                                                              |
        /// </returns>
        /// <remarks>
        /// The CLR calls GetMaxThreads to determine the total number of threads in the thread pool. The <see cref="GetAvailableThreads"/>
        /// method gets the number of threads that are not currently processing work items. All requests above the returned
        /// value of the pdwMaxWorkerThreads parameter remain queued until threads become available. If the host does not provide
        /// an implementation of GetMaxThreads, it should return an <see cref="HRESULT"/> value of E_NOTIMPL.
        /// </remarks>
        [PreserveSig]
        HRESULT GetMaxThreads(
            [Out] out uint pdwMaxWorkerThreads);

        /// <summary>
        /// Gets the number of threads in the thread pool that are not currently processing work items.
        /// </summary>
        /// <param name="pdwAvailableWorkerThreads">[out] Pointer to the number of threads in the thread pool that are not currently processing work items.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | GetAvailableThreads returned successfully.                                                                                                                                                 |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | E_NOTIMPL              | The host does not provide an implementation of GetAvailableThreads.                                                                                                                        |
        /// </returns>
        /// <remarks>
        /// If the host does not provide an implementation of GetAvailableThreads, it should return an <see cref="HRESULT"/> value of E_NOTIMPL.
        /// </remarks>
        [PreserveSig]
        HRESULT GetAvailableThreads(
            [Out] out uint pdwAvailableWorkerThreads);

        /// <summary>
        /// Sets the minimum number of idle threads that the host must maintain in anticipation of requests.
        /// </summary>
        /// <param name="dwMinIOCompletionThreads">[in] The new minimum number of threads that the host must maintain.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | SetMinThreads returned successfully.                                                                                                                                                       |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | E_NOTIMPL              | The host does not provide an implementation of SetMinThreads.                                                                                                                              |
        /// </returns>
        /// <remarks>
        /// A host is not required to provide an implementation of SetMinThreads. In this case, it should return an <see cref="HRESULT"/>
        /// value of E_NOTIMPL.
        /// </remarks>
        [PreserveSig]
        HRESULT SetMinThreads(
            [In] uint dwMinIOCompletionThreads);

        /// <summary>
        /// Gets the minimum number of idle threads that the host maintains in the thread pool in anticipation of requests.
        /// </summary>
        /// <param name="pdwMinIOCompletionThreads">[out] A pointer to the minimum number of idle worker threads that the host currently maintains.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | GetMinThreads returned successfully.                                                                                                                                                       |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | E_NOTIMPL              | The host does not provide an implementation of GetMinThreads.                                                                                                                              |
        /// </returns>
        /// <remarks>
        /// The host is not required to provide an implementation of GetMinThreads. In this case, it should return an <see cref="HRESULT"/>
        /// value of E_NOTIMPL.
        /// </remarks>
        [PreserveSig]
        HRESULT GetMinThreads(
            [Out] out uint pdwMinIOCompletionThreads);
    }
}