using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods that allow the common language runtime (CLR) to work with tasks through the host instead of using the standard operating system threading or fiber functions.
    /// </summary>
    /// <remarks>
    /// <see cref="IHostTaskManager"/> allows the CLR to create and manage tasks, to provide hooks for the host to take action when control
    /// transfers from managed to unmanaged code and vice versa, and to specify certain actions the host can and cannot
    /// take during code execution.
    /// </remarks>
    [Guid("997FF24C-43B7-4352-8667-0DC04FAFD354")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport]
    public interface IHostTaskManager
    {
        /// <summary>
        /// Requests that the host create a new task.
        /// </summary>
        /// <param name="dwStackSize">[in] The requested size, in bytes, of the requested stack, or 0 (zero) for the default size.</param>
        /// <param name="pStartAddress">[in] A pointer to the function the task is to execute.</param>
        /// <param name="pParameter">[in] A pointer to the user data to be passed to the function, or null if the function takes no parameters.</param>
        /// <param name="ppTask">[out] A pointer to the address of an <see cref="IHostTask"/> instance created by the host, or null if the task cannot be created.<para/>
        /// The task remains in a suspended state until it is explicitly started by a call to <see cref="IHostTask.Start"/>.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | CreateTask returned successfully.                                                                                                                                                          |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | E_OUTOFMEMORY          | Not enough memory was available to create the requested task.                                                                                                                              |
        /// </returns>
        /// <remarks>
        /// The CLR calls CreateTask to request that the host create a new task. The host returns an interface pointer to an
        /// <see cref="IHostTask"/> instance. The returned task must remain suspended until it is explicitly started by a call to IHostTask::Start.
        /// </remarks>
        [PreserveSig]
        HRESULT CreateTask(
            [In] int dwStackSize,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] LPTHREAD_START_ROUTINE pStartAddress,
            [In] IntPtr pParameter,
            [Out] out IHostTaskManager ppTask);

        /// <summary>
        /// Notifies the host that the current task is going to sleep.
        /// </summary>
        /// <param name="dwMilliseconds">[in] The time interval, in milliseconds, that the thread will sleep.</param>
        /// <param name="option">[in] One of the <see cref="WAIT_OPTION"/> enumeration values, indicating what action the host should take if this action blocks.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | Sleep returned successfully.                                                                                                                                                               |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// The CLR typically calls <see cref="Sleep"/> when <see cref="Thread.Sleep(int)"/> is called from user code.
        /// </remarks>
        [PreserveSig]
        HRESULT Sleep(
            [In] int dwMilliseconds,
            [In] int option);

        /// <summary>
        /// Notifies the host that it should switch out the current task.
        /// </summary>
        /// <param name="option">[in] One of the <see cref="WAIT_OPTION"/> enumeration values, indicating the action the host should take if the requested operation blocks.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | SwitchToTask returned successfully.                                                                                                                                                        |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// The host can switch in another task as desired or needed.
        /// </remarks>
        [PreserveSig]
        HRESULT SwitchToTask(
            [In] int option);

        /// <summary>
        /// Notifies the host that the common language runtime (CLR) has changed the user interface (UI) locale, or culture, on the currently executing task.
        /// </summary>
        /// <param name="lcid">[in] The locale identifier value that maps to the newly assigned geographical culture and language.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | SetUILocale returned successfully.                                                                                                                                                         |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                 |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | E_NOTIMPL              | The host does not allow managed user code to change the UI culture.                                                                                                                        |
        /// </returns>
        /// <remarks>
        /// The runtime calls SetUILocale when the value of the <see cref="Thread.CurrentUICulture"/> property is changed by
        /// managed code. This method provides an opportunity for the host to execute any mechanisms it might have for synchronization
        /// of locales. If a host does not allow the UI locale to be changed from managed code, or does not implement a mechanism
        /// to synchronize locales, it should return E_NOTIMPL from this method.
        /// </remarks>
        [PreserveSig]
        HRESULT SetUILocale(
            [In] int lcid);

        /// <summary>
        /// Notifies the host that the common language runtime (CLR) has changed the locale, or culture, on the currently executing task.
        /// </summary>
        /// <param name="lcid">[in] The locale identifier value that maps to the newly assigned geographical culture and language.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | SetLocale returned successfully.                                                                                                                                                           |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                 |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | E_NOTIMPL              | The host does not allow managed user code to modify the locale.                                                                                                                            |
        /// </returns>
        /// <remarks>
        /// The runtime calls SetLocale when the value of the <see cref="Thread.CurrentCulture"/> property is changed by managed
        /// code. This method provides an opportunity for the host to execute any mechanisms it might have for synchronization
        /// of locales. If a host does not allow the locale to be changed from managed code, or does not implement a mechanism
        /// to synchronize locales, it should return E_NOTIMPL from this method.
        /// </remarks>
        [PreserveSig]
        HRESULT SetLocale(
            [In] int lcid);

        /// <summary>
        /// Enables the host to specify whether the common language runtime (CLR) can inline the specified call to an unmanaged function.
        /// </summary>
        /// <param name="target">[in] The address within the mapped portable executable (PE) file of the unmanaged function that is to be called.</param>
        /// <param name="pbCallNeedsHostHook">[out] A pointer to a Boolean value that indicates whether the host requires the call to be hooked.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                    |
        /// | ---------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
        /// | S_OK                   | CallNeedsHostHook returned successfully.                                                                                                                                                       |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                     |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                            |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                              |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                       |
        /// | E_FAIL                 | An unknown catastrophic failure has occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// To help optimize code execution, the CLR performs an analysis of each platform invoke call during compilation to
        /// determine whether the call can be inlined. CallNeedsHostHook enables the host to override that decision by requiring
        /// that a call to an unmanaged function be hooked. If the host requires a hook, the runtime does not inline the call.
        /// The host typically would require a hook where it must adjust a floating-point state, or upon receiving notification
        /// that a call is entering a state where the host cannot track the runtime's requests for memory or any locks taken.
        /// When the host requires that the call be hooked, the runtime notifies the host of transitions to and from managed
        /// code by using calls to <see cref="EnterRuntime"/>, <see cref="LeaveRuntime"/>, <see cref="ReverseEnterRuntime"/>,
        /// and <see cref="ReverseLeaveRuntime"/>.
        /// </remarks>
        [PreserveSig]
        HRESULT CallNeedsHostHook(
            [In] int target,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool pbCallNeedsHostHook);

        /// <summary>
        /// Notifies the host that the currently executing task is about to leave the common language runtime (CLR) and enter unmanaged code.
        /// </summary>
        /// <param name="target">[in] The address within the mapped portable executable file of the unmanaged function to be called.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | LeaveRuntime returned successfully.                                                                                                                                                        |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                 |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | E_OUTOFMEMORY          | Not enough memory is available to complete the requested allocation.                                                                                                                       |
        /// </returns>
        /// <remarks>
        /// Call sequences to and from unmanaged code can be nested. For example, the list below describes a hypothetical situation
        /// in which the sequence of calls to LeaveRuntime, <see cref="ReverseEnterRuntime"/>, <see cref="ReverseLeaveRuntime"/>,
        /// and <see cref="EnterRuntime"/> allows the host to identify the nested layers.
        /// </remarks>
        [PreserveSig]
        HRESULT LeaveRuntime(
            [In] int target);

        /// <summary>
        /// Notifies the host that a call to an unmanaged method, such as a platform invoke method, is returning execution control to the common language runtime (CLR).
        /// </summary>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | EnterRuntime returned successfully.                                                                                                                                                        |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                 |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | E_OUTOFMEMORY          | Not enough memory was available to complete the requested allocation.                                                                                                                      |
        /// </returns>
        /// <remarks>
        /// EnterRuntime is called to notify the host that an unmanaged function, for which an earlier call to the <see cref="LeaveRuntime"/>
        /// method was made, has finished executing, and is returning execution control to the runtime.
        /// </remarks>
        [PreserveSig]
        HRESULT EnterRuntime();

        /// <summary>
        /// Notifies the host that control is leaving the common language runtime (CLR) and entering an unmanaged function that was, in turn, called from managed code.
        /// </summary>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | ReverseLeaveRuntime returned successfully.                                                                                                                                                 |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                 |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | E_OUTOFMEMORY          | Not enough memory is available to complete the requested resource allocation.                                                                                                              |
        /// </returns>
        /// <remarks>
        /// The CLR calls ReverseLeaveRuntime to inform the host that the currently executing task is returning control to
        /// an unmanaged function that was, in turn, called from managed code through platform invoke. Each call to ReverseLeaveRuntime
        /// matches a corresponding call to <see cref="ReverseEnterRuntime"/>.
        /// </remarks>
        [PreserveSig]
        HRESULT ReverseLeaveRuntime();

        /// <summary>
        /// Notifies the host that a call is being made into the common language runtime (CLR) from unmanaged code.
        /// </summary>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | ReverseEnterRuntime returned successfully.                                                                                                                                                 |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                 |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | E_OUTOFMEMORY          | Not enough memory is available to complete the requested resource allocation.                                                                                                              |
        /// </returns>
        /// <remarks>
        /// If the call into the CLR is made from a sequence that originated in managed code, each call to ReverseEnterRuntime
        /// corresponds to a call to <see cref="ReverseLeaveRuntime"/>.
        /// </remarks>
        [PreserveSig]
        HRESULT ReverseEnterRuntime();

        /// <summary>
        /// Notifies the host that managed code is entering a period in which the current task must not be aborted.
        /// </summary>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | BeginDelayAbort returned successfully.                                                                                                                                                     |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | E_UNEXPECTED           | BeginDelayAbort has already been called, but the corresponding call to <see cref="EndDelayAbort"/> has not yet been received.                                                              |
        /// </returns>
        /// <remarks>
        /// The host must not abort the current task until EndDelayAbort is called. If another call to BeginDelayAbort is made
        /// without an intervening call to EndDelayAbort, the host should return E_UNEXPECTED from BeginDelayAbort, and should
        /// take no action.
        /// </remarks>
        [PreserveSig]
        HRESULT BeginDelayAbort();

        /// <summary>
        /// Notifies the host that managed code is exiting the period in which the current task must not be aborted, following an earlier call to <see cref="BeginDelayAbort"/>.
        /// </summary>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | EndDelayAbort returned successfully.                                                                                                                                                       |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | E_UNEXPECTED           | EndDelayAbort was called without a corresponding call to BeginDelayAbort.                                                                                                                  |
        /// </returns>
        /// <remarks>
        /// The CLR makes a corresponding call to BeginDelayAbort on the current task before calling EndDelayAbort. In the
        /// absence of such a corresponding call, the host's implementation of <see cref="IHostTaskManager"/> should return
        /// E_UNEXPECTED from EndDelayAbort, and should take no action.
        /// </remarks>
        [PreserveSig]
        HRESULT EndDelayAbort();

        /// <summary>
        /// Notifies the host that managed code is entering a period in which the current task must not be moved to another operating system thread.
        /// </summary>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | BeginThreadAffinity returned successfully.                                                                                                                                                 |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// The CLR typically calls <see cref="BeginThreadAffinity"/> in the context of a call to <see cref="Thread.BeginThreadAffinity"/>.
        /// The current task must not be rescheduled until a corresponding call is made to <see cref="EndThreadAffinity"/>.
        /// Tasks can be switched out, but when they are switched back in, they must be assigned to the same operating system
        /// thread from which they were switched out. Nested calls to BeginThreadAffinity have no effect, because the call
        /// refers to the current task.
        /// </remarks>
        [PreserveSig]
        HRESULT BeginThreadAffinity();

        /// <summary>
        /// Notifies the host that managed code is exiting the period in which the current task must not be moved to another operating system thread, following an earlier call to <see cref="BeginThreadAffinity"/>.
        /// </summary>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | EndThreadAffinity returned successfully.                                                                                                                                                   |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | E_UNEXPECTED           | EndThreadAffinity was called without an earlier corresponding call to BeginThreadAffinity.                                                                                                 |
        /// </returns>
        /// <remarks>
        /// The CLR makes a corresponding call to BeginThreadAffinity on the current task before calling EndThreadAffinity.
        /// In the absence of such a corresponding call, the host's implementation of <see cref="IHostTaskManager"/> should
        /// return E_UNEXPECTED, and take no action.
        /// </remarks>
        [PreserveSig]
        HRESULT EndThreadAffinity();

        /// <summary>
        /// Reserved for internal use only.
        /// </summary>
        [PreserveSig]
        HRESULT SetStackGuarantee(
            [In] int guarantee);

        /// <summary>
        /// Gets the amount of stack space that is guaranteed to be available after a stack operation completes, but before the closing of a process.
        /// </summary>
        /// <param name="pGuarantee">[out] A pointer to the number of bytes that are available.</param>
        [PreserveSig]
        HRESULT GetStackGuarantee(
            [Out] out int pGuarantee);

        /// <summary>
        /// Provides the host with an interface pointer to an <see cref="ICLRTaskManager"/> instance implemented by the common language runtime (CLR).
        /// </summary>
        /// <param name="ppManager">[in] A pointer to an <see cref="ICLRTaskManager"/> instance implemented by the common language runtime.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | SetCLRTaskManager returned successfully.                                                                                                                                                   |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                 |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// The runtime calls SetCLRTaskManager to provide the host with an interface pointer to an <see cref="ICLRTaskManager"/> instance.
        /// </remarks>
        [PreserveSig]
        HRESULT SetCLRTaskManager(
            [Out] out ICLRTaskManager ppManager);
    }
}
