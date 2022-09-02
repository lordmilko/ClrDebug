using System;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Implements a callback method that allows the host to notify the common language runtime (CLR) of the status of specified I/O requests.
    /// </summary>
    /// <remarks>
    /// The host implements the I/O completion abstraction by using the <see cref="IHostIoCompletionManager"/> interface.
    /// The CLR makes I/O requests through this interface, and the host notifies the runtime of the outcome of such requests
    /// by using the <see cref="ICLRIoCompletionManager"/> interface.
    /// </remarks>
    [Guid("2d74ce86-b8d6-4c84-b3a7-9768933b3c12")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface ICLRIoCompletionManager
    {
        /// <summary>
        /// Notifies the common language runtime (CLR) of the status of an I/O request that was made by using a call to the <see cref="IHostIoCompletionManager.Bind"/> method.
        /// </summary>
        /// <param name="dwErrorCode">[in] An <see cref="HRESULT"/> value that indicates the status of the bind operation.</param>
        /// <param name="NumberOfBytesTransferred">[in] The number of bytes transferred during the processing of the I/O request.</param>
        /// <param name="pvOverlapped">[in] A pointer to the OVERLAPPED structure that was passed to the call to the <see cref="IHostIoCompletionManager.Bind"/> method.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                 |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | OnComplete returned successfully.                                                                                                                                                           |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                  |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                         |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                           |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                    |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. After a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// If the host implements an I/O completion abstraction, the CLR makes I/O requests through the host by using methods
        /// of <see cref="IHostIoCompletionManager"/>. The host then calls the OnComplete method to notify the runtime of the
        /// outcome of such requests.
        /// </remarks>
        [PreserveSig]
        HRESULT OnComplete(
            [In] HRESULT dwErrorCode,
            [In] int NumberOfBytesTransferred,
            [In] IntPtr pvOverlapped);
    }
}
