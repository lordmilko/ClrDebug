using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods that allow the common language runtime (CLR) to interact with I/O completion ports provided by the host.
    /// </summary>
    /// <remarks>
    /// <see cref="IHostIoCompletionManager"/> corresponds to the <see cref="ICLRIoCompletionManager"/> interface implemented by the CLR. The CLR calls
    /// the methods of <see cref="IHostIoCompletionManager"/> to bind handles to the ports that the host provides, and the host calls
    /// the methods of <see cref="ICLRIoCompletionManager"/> to report the completion of I/O requests.
    /// </remarks>
    public class HostIoCompletionManager : ComObject<IHostIoCompletionManager>
    {
        public HostIoCompletionManager(IHostIoCompletionManager raw) : base(raw)
        {
        }

        #region IHostIoCompletionManager
        #region MaxThreads

        /// <summary>
        /// Gets or sets the maximum number of threads that the host can allot to service I/O requests.
        /// </summary>
        public int MaxThreads
        {
            get
            {
                HRESULT hr;
                int pdwMaxIOCompletionThreads;

                if ((hr = TryGetMaxThreads(out pdwMaxIOCompletionThreads)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pdwMaxIOCompletionThreads;
            }
            set
            {
                HRESULT hr;

                if ((hr = TrySetMaxThreads(value)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);
            }
        }

        /// <summary>
        /// Gets the maximum number of threads that the host can allot to service I/O requests.
        /// </summary>
        /// <param name="pdwMaxIOCompletionThreads">[out] A pointer to the maximum number of threads in the thread pool that the host can allot to service I/O requests.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | GetMaxThreads returned successfully.                                                                                                                                                       |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | E_NOTIMPL              | The host does not provide an implementation of GetMaxThreads.                                                                                                                              |
        /// </returns>
        /// <remarks>
        /// A host might want exclusive control over the number of threads that can be allotted to process I/O requests, for
        /// reasons such as implementation, performance, or scalability. For this reason, the host is not required to implement
        /// GetMaxThreads. In this case, the host should return E_NOTIMPL from this method.
        /// </remarks>
        public HRESULT TryGetMaxThreads(out int pdwMaxIOCompletionThreads)
        {
            /*HRESULT GetMaxThreads([Out] out int pdwMaxIOCompletionThreads);*/
            return Raw.GetMaxThreads(out pdwMaxIOCompletionThreads);
        }

        /// <summary>
        /// Sets the maximum number of threads that the host allots to service I/O requests.
        /// </summary>
        /// <param name="dwMaxIOCompletionThreads">[in] The maximum number of threads to allot for I/O requests.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | SetMaxThreads returned successfully.                                                                                                                                                       |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | E_NOTIMPL              | The host does not provide an implementation of SetMaxThreads.                                                                                                                              |
        /// </returns>
        /// <remarks>
        /// SetMaxThreads provides the CLR with an opportunity to set the maximum number of threads that are available to service
        /// requests on I/O ports. A host might need exclusive control over the size of the thread pool, for reasons such as
        /// implementation, performance, or scalability. For this reason, the host is not required to implement SetMaxThreads.
        /// In this case, a host should return E_NOTIMPL from this method.
        /// </remarks>
        public HRESULT TrySetMaxThreads(int dwMaxIOCompletionThreads)
        {
            /*HRESULT SetMaxThreads([In] int dwMaxIOCompletionThreads);*/
            return Raw.SetMaxThreads(dwMaxIOCompletionThreads);
        }

        #endregion
        #region AvailableThreads

        /// <summary>
        /// Gets the number of I/O completion threads, of the total number of threads managed by the host, that are not currently servicing requests.
        /// </summary>
        public int AvailableThreads
        {
            get
            {
                HRESULT hr;
                int pdwAvailableIOCompletionThreads;

                if ((hr = TryGetAvailableThreads(out pdwAvailableIOCompletionThreads)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pdwAvailableIOCompletionThreads;
            }
        }

        /// <summary>
        /// Gets the number of I/O completion threads, of the total number of threads managed by the host, that are not currently servicing requests.
        /// </summary>
        /// <param name="pdwAvailableIOCompletionThreads">[out] A pointer to the number of I/O completion threads managed by the host that are currently available to service requests.</param>
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
        /// A host might want exclusive control over the size of the I/O completion thread pool, for reasons such as implementation,
        /// performance, or scalability. Therefore, the host is not required to implement GetAvailableThreads. In this case,
        /// the host should return E_NOTIMPL from this method.
        /// </remarks>
        public HRESULT TryGetAvailableThreads(out int pdwAvailableIOCompletionThreads)
        {
            /*HRESULT GetAvailableThreads([Out] out int pdwAvailableIOCompletionThreads);*/
            return Raw.GetAvailableThreads(out pdwAvailableIOCompletionThreads);
        }

        #endregion
        #region HostOverlappedSize

        /// <summary>
        /// Gets the size of any custom data the host intends to append to I/O requests.
        /// </summary>
        public int HostOverlappedSize
        {
            get
            {
                HRESULT hr;
                int pcbSize;

                if ((hr = TryGetHostOverlappedSize(out pcbSize)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pcbSize;
            }
        }

        /// <summary>
        /// Gets the size of any custom data the host intends to append to I/O requests.
        /// </summary>
        /// <param name="pcbSize">[out] A pointer to the number of bytes that the common language runtime (CLR) should allocate in addition to the size of the Win32 OVERLAPPED object.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | GetHostOverlappedSize returned successfully.                                                                                                                                               |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                 |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// All asynchronous I/O calls to Windows Platform APIs take a Win32 OVERLAPPED object, which provides information
        /// such as the file pointer position. To maintain state, applications that make asynchronous I/O calls typically add
        /// custom data to the structure. GetHostOverlappedSize and <see cref="InitializeHostOverlapped"/> provide an opportunity
        /// for the host to include such custom data. The CLR calls the GetHostOverlappedSize method to determine the size
        /// of the custom data that the host intends to append to the OVERLAPPED object. For more information about the OVERLAPPED
        /// structure, see the Windows Platform documentation.
        /// </remarks>
        public HRESULT TryGetHostOverlappedSize(out int pcbSize)
        {
            /*HRESULT GetHostOverlappedSize([Out] out int pcbSize);*/
            return Raw.GetHostOverlappedSize(out pcbSize);
        }

        #endregion
        #region MinThreads

        /// <summary>
        /// Gets or sets the minimum number of threads that the host provides for processing I/O requests.
        /// </summary>
        public int MinThreads
        {
            get
            {
                HRESULT hr;
                int pdwMinIOCompletionThreads;

                if ((hr = TryGetMinThreads(out pdwMinIOCompletionThreads)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pdwMinIOCompletionThreads;
            }
            set
            {
                HRESULT hr;

                if ((hr = TrySetMinThreads(value)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);
            }
        }

        /// <summary>
        /// Gets the minimum number of threads that the host provides for processing I/O requests.
        /// </summary>
        /// <param name="pdwMinIOCompletionThreads">[out] A pointer to the minimum number of threads that the host provides to process I/O requests.</param>
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
        /// A host might want exclusive control over the number of threads allotted to service I/O requests, for reasons such
        /// as implementation, performance, or scalability. For this reason, the host is not required to implement GetMinThreads.
        /// In this case, the host should return E_NOTIMPL from this method.
        /// </remarks>
        public HRESULT TryGetMinThreads(out int pdwMinIOCompletionThreads)
        {
            /*HRESULT GetMinThreads(
            [Out] out int pdwMinIOCompletionThreads);*/
            return Raw.GetMinThreads(out pdwMinIOCompletionThreads);
        }

        /// <summary>
        /// Sets the minimum number of threads that the host should allot to I/O completion.
        /// </summary>
        /// <param name="dwMinIOCompletionThreads">[in] The minimum number of I/O completion threads that the host should create.</param>
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
        /// A host might want exclusive control over the number of threads that can be allotted to process I/O requests, for
        /// reasons such as implementation, performance, or scalability. For this reason, the host is not required to implement
        /// SetMinThreads. In this case, the host should return E_NOTIMPL from this method.
        /// </remarks>
        public HRESULT TrySetMinThreads(int dwMinIOCompletionThreads)
        {
            /*HRESULT SetMinThreads(
            [In] int dwMinIOCompletionThreads);*/
            return Raw.SetMinThreads(dwMinIOCompletionThreads);
        }

        #endregion
        #region CreateIoCompletionPort

        /// <summary>
        /// Requests that the host create a new I/O completion port.
        /// </summary>
        /// <returns>[out] A pointer to a handle to the newly created I/O completion port, or 0 (zero), if the port could not be created.</returns>
        /// <remarks>
        /// The CLR calls the CreateIoCompletionPort method to request that the host create a new I/O completion port. It binds
        /// I/O operations to this port through a call to the <see cref="Bind"/> method. The host reports status back to the
        /// CLR by calling <see cref="CLRIoCompletionManager.OnComplete"/>.
        /// </remarks>
        public IntPtr CreateIoCompletionPort()
        {
            HRESULT hr;
            IntPtr phPort = default(IntPtr);

            if ((hr = TryCreateIoCompletionPort(ref phPort)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return phPort;
        }

        /// <summary>
        /// Requests that the host create a new I/O completion port.
        /// </summary>
        /// <param name="phPort">[out] A pointer to a handle to the newly created I/O completion port, or 0 (zero), if the port could not be created.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | CreateIoCompletionPort returned successfully.                                                                                                                                              |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | E_OUTOFMEMORY          | Not enough memory was available to allocate the requested resource.                                                                                                                        |
        /// </returns>
        /// <remarks>
        /// The CLR calls the CreateIoCompletionPort method to request that the host create a new I/O completion port. It binds
        /// I/O operations to this port through a call to the <see cref="Bind"/> method. The host reports status back to the
        /// CLR by calling <see cref="CLRIoCompletionManager.OnComplete"/>.
        /// </remarks>
        public HRESULT TryCreateIoCompletionPort(ref IntPtr phPort)
        {
            /*HRESULT CreateIoCompletionPort([Out] IntPtr phPort);*/
            return Raw.CreateIoCompletionPort(phPort);
        }

        #endregion
        #region CloseIoCompletionPort

        /// <summary>
        /// Requests that the host close a port that was opened through an earlier call to <see cref="CreateIoCompletionPort"/>.
        /// </summary>
        /// <param name="hPort">[in] The handle of the port to close.</param>
        /// <remarks>
        /// hPort must be a handle to a port that was created by an earlier call to CreateIoCompletionPort.
        /// </remarks>
        public void CloseIoCompletionPort(IntPtr hPort)
        {
            HRESULT hr;

            if ((hr = TryCloseIoCompletionPort(hPort)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Requests that the host close a port that was opened through an earlier call to <see cref="CreateIoCompletionPort"/>.
        /// </summary>
        /// <param name="hPort">[in] The handle of the port to close.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | CloseIoCompletionPort returned successfully.                                                                                                                                               |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | E_INVALIDARG           | An invalid port handle was passed.                                                                                                                                                         |
        /// </returns>
        /// <remarks>
        /// hPort must be a handle to a port that was created by an earlier call to CreateIoCompletionPort.
        /// </remarks>
        public HRESULT TryCloseIoCompletionPort(IntPtr hPort)
        {
            /*HRESULT CloseIoCompletionPort([In] IntPtr hPort);*/
            return Raw.CloseIoCompletionPort(hPort);
        }

        #endregion
        #region SetCLRIoCompletionManager

        /// <summary>
        /// Provides the host with an interface pointer to the <see cref="ICLRIoCompletionManager"/> instance implemented by the common language runtime (CLR).
        /// </summary>
        /// <param name="pManager">[in] An interface pointer to an <see cref="ICLRIoCompletionManager"/> instance provided by the CLR.</param>
        /// <remarks>
        /// After the CLR has called SetCLRIoCompletionManager, the host must call <see cref="CLRIoCompletionManager.OnComplete"/>
        /// to notify the CLR when an I/O request has been completed.
        /// </remarks>
        public void SetCLRIoCompletionManager(ICLRIoCompletionManager pManager)
        {
            HRESULT hr;

            if ((hr = TrySetCLRIoCompletionManager(pManager)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Provides the host with an interface pointer to the <see cref="ICLRIoCompletionManager"/> instance implemented by the common language runtime (CLR).
        /// </summary>
        /// <param name="pManager">[in] An interface pointer to an <see cref="ICLRIoCompletionManager"/> instance provided by the CLR.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | SetCLRIoCompletionManager returned successfully.                                                                                                                                           |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                 |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// After the CLR has called SetCLRIoCompletionManager, the host must call <see cref="CLRIoCompletionManager.OnComplete"/>
        /// to notify the CLR when an I/O request has been completed.
        /// </remarks>
        public HRESULT TrySetCLRIoCompletionManager(ICLRIoCompletionManager pManager)
        {
            /*HRESULT SetCLRIoCompletionManager(
            [In, MarshalAs(UnmanagedType.Interface)] ICLRIoCompletionManager pManager);*/
            return Raw.SetCLRIoCompletionManager(pManager);
        }

        #endregion
        #region InitializeHostOverlapped

        /// <summary>
        /// Provides the host with an opportunity to initialize any custom data to append to a Win32 OVERLAPPED structure that is used for asynchronous I/O requests.
        /// </summary>
        /// <param name="pvOverlapped">[in] A pointer to the Win32 OVERLAPPED structure to be included with the I/O request.</param>
        /// <remarks>
        /// The Windows Platform functions use the OVERLAPPED structure to store state for asynchronous I/O requests. The CLR
        /// calls the InitializeHostOverlapped method to give the host the opportunity to append custom data to an OVERLAPPED
        /// instance. A return value of E_OUTOFMEMORY indicates that the host has failed to initialize its custom data. In
        /// this case, the CLR reports an error and fails the call.
        /// </remarks>
        public void InitializeHostOverlapped(IntPtr pvOverlapped)
        {
            HRESULT hr;

            if ((hr = TryInitializeHostOverlapped(pvOverlapped)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Provides the host with an opportunity to initialize any custom data to append to a Win32 OVERLAPPED structure that is used for asynchronous I/O requests.
        /// </summary>
        /// <param name="pvOverlapped">[in] A pointer to the Win32 OVERLAPPED structure to be included with the I/O request.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | InitializeHostOverlapped returned successfully.                                                                                                                                            |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | E_OUTOFMEMORY          | Not enough memory was available to allocate the requested resource.                                                                                                                        |
        /// </returns>
        /// <remarks>
        /// The Windows Platform functions use the OVERLAPPED structure to store state for asynchronous I/O requests. The CLR
        /// calls the InitializeHostOverlapped method to give the host the opportunity to append custom data to an OVERLAPPED
        /// instance. A return value of E_OUTOFMEMORY indicates that the host has failed to initialize its custom data. In
        /// this case, the CLR reports an error and fails the call.
        /// </remarks>
        public HRESULT TryInitializeHostOverlapped(IntPtr pvOverlapped)
        {
            /*HRESULT InitializeHostOverlapped(
            [In] IntPtr pvOverlapped);*/
            return Raw.InitializeHostOverlapped(pvOverlapped);
        }

        #endregion
        #region Bind

        /// <summary>
        /// Binds the specified handle to an I/O completion port that has been created by an earlier call to <see cref="CreateIoCompletionPort"/>.
        /// </summary>
        /// <param name="hPort">[in] The I/O completion port to which to bind hHandle. If the value of hPort is null, hHandle is bound to the default I/O completion port.</param>
        /// <param name="hHandle">[in] The operating system handle to bind to hPort.</param>
        /// <remarks>
        /// An I/O completion port is created by using a call to CreateIoCompletionPort. The CLR calls Bind to bind a handle
        /// to that port.
        /// </remarks>
        public void Bind(IntPtr hPort, IntPtr hHandle)
        {
            HRESULT hr;

            if ((hr = TryBind(hPort, hHandle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Binds the specified handle to an I/O completion port that has been created by an earlier call to <see cref="CreateIoCompletionPort"/>.
        /// </summary>
        /// <param name="hPort">[in] The I/O completion port to which to bind hHandle. If the value of hPort is null, hHandle is bound to the default I/O completion port.</param>
        /// <param name="hHandle">[in] The operating system handle to bind to hPort.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | Bind returned successfully.                                                                                                                                                                |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// An I/O completion port is created by using a call to CreateIoCompletionPort. The CLR calls Bind to bind a handle
        /// to that port.
        /// </remarks>
        public HRESULT TryBind(IntPtr hPort, IntPtr hHandle)
        {
            /*HRESULT Bind(
            [In] IntPtr hPort,
            [In] IntPtr hHandle);*/
            return Raw.Bind(hPort, hHandle);
        }

        #endregion
        #endregion
    }
}