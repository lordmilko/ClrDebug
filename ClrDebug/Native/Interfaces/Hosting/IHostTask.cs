using System;
using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif
using System.Threading;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods that allow the common language runtime (CLR) to communicate with the host to manage tasks.
    /// </summary>
    /// <remarks>
    /// The CLR calls methods defined by <see cref="IHostTask"/> to start a task, set its thread priority level, and so on.
    /// </remarks>
    [Guid("C2275828-C4B1-4B55-82C9-92135F74DF1A")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IHostTask
    {
        /// <summary>
        /// Requests that the host move the task represented by the current <see cref="IHostTask"/> instance from a suspended to a live state, in which code can be executed.
        /// </summary>
        /// <returns>
        /// | HRESULT | Description                                                                                                                                                                                                          |
        /// | ------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK    | Start returned successfully.                                                                                                                                                                                         |
        /// | E_FAIL  | An unknown catastrophic failure occurred. When a method returns E_FAIL, the common language runtime (CLR) is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// Start always returns an <see cref="HRESULT"/> value of S_OK, except in cases where a catastrophic failure has occurred.
        /// </remarks>
        [PreserveSig]
        HRESULT Start();

        /// <summary>
        /// Requests that the host wake the task represented by the current <see cref="IHostTask"/> instance, so the task can be aborted.
        /// </summary>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | The method returned successfully.                                                                                                                                                          |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// The CLR calls the Alert method when <see cref="Thread.Abort()"/> is called from user code, or when the <see cref="AppDomain"/>
        /// associated with the current <see cref="Thread"/> shuts down. The host must return immediately, because the call
        /// is made asynchronously. If the host cannot alert the task immediately, it must wake up the next time it enters
        /// a state in which it can be alerted.
        /// </remarks>
        [PreserveSig]
        HRESULT Alert();

        /// <summary>
        /// Blocks the calling task until the task represented by the current <see cref="IHostTask"/> instance completes, the specified time interval elapses, or <see cref="Alert"/> is called.
        /// </summary>
        /// <param name="dwMilliseconds">[in] The time interval, in milliseconds, to wait for the task to terminate. If this interval elapses before the task terminates, the calling task unblocks.</param>
        /// <param name="option">[in] One of the <see cref="WAIT_OPTION"/> values. A value of WAIT_ALERTABLE instructs the host to wake the task if Alert is called before milliseconds elapses.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | Join returned successfully.                                                                                                                                                                |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it, or the current IHostTask instance is not associated with a task.                                                  |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        [PreserveSig]
        HRESULT Join(
            [In] int dwMilliseconds,
            [In] int option);

        /// <summary>
        /// Requests that the host adjust the thread priority level for the task represented by the current <see cref="IHostTask"/> instance.
        /// </summary>
        /// <param name="newPriority">[in] An integer that represents the requested thread priority value for the task represented by the current <see cref="IHostTask"/> instance.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | SetPriority returned successfully.                                                                                                                                                         |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// Threads are granted processing time using a round-robin system that is partly based on a thread's priority level.
        /// SetPriority allows the CLR to set that thread priority level for the current task. The following newPriority values
        /// are supported. The CLR calls SetPriority when the value of the <see cref="Thread.Priority"/> is modified by user
        /// code. A host can define its own algorithms for thread priority assignment, and is free to ignore this request.
        /// Thread priority level values are defined by the Win32 SetThreadPriority function. For more information about thread
        /// priority, see the Windows Platform documentation.
        /// </remarks>
        [PreserveSig]
        HRESULT SetPriority(
            [In] int newPriority);

        /// <summary>
        /// Gets the thread priority level of the task represented by the current <see cref="IHostTask"/> instance.
        /// </summary>
        /// <param name="pPriority">[out] A pointer to an integer that indicates the thread priority level of the task represented by the current <see cref="IHostTask"/> instance.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | GetPriority returned successfully.                                                                                                                                                         |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// Thread priority level values are defined by the Win32 SetThreadPriority function.
        /// </remarks>
        [PreserveSig]
        HRESULT GetPriority(
            [Out] out int pPriority);

        /// <summary>
        /// Associates an <see cref="ICLRTask"/> instance with the current <see cref="IHostTask"/> instance.
        /// </summary>
        /// <param name="pCLRTask">[in] An interface pointer to the <see cref="ICLRTask"/> instance to be associated with the current <see cref="IHostTask"/> instance.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | SetCLRTask returned successfully.                                                                                                                                                          |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// The CLR calls SetCLRTask to associate an <see cref="ICLRTask"/> instance with the current <see cref="IHostTask"/> instance, which was created
        /// by a call to <see cref="IHostTaskManager.CreateTask"/>.
        /// </remarks>
        [PreserveSig]
        HRESULT SetCLRTask(
            [In, MarshalAs(UnmanagedType.Interface)] ICLRTask pCLRTask);
    }
}
