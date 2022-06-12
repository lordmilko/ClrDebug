using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods that allow the host to make requests of the common language runtime (CLR), or to provide notification to the CLR about the associated task.
    /// </summary>
    /// <remarks>
    /// An <see cref="ICLRTask"/> is the representation of a task for the CLR. At any point during code execution, a task can be described
    /// either as running or waiting to run. The host calls the <see cref="SwitchIn"/> method to notify the CLR that the task
    /// that the current <see cref="ICLRTask"/> instance represents is now in an operable state. After a call to <see cref="SwitchIn"/>,
    /// the host can schedule the task on any operating system thread, except in cases where the runtime requires thread-affinity,
    /// as specified by calls to the <see cref="HostTaskManager.BeginThreadAffinity"/> and <see cref="HostTaskManager.EndThreadAffinity"/>
    /// methods. Some time later, the operating system might decide to remove the task from the thread and place it in
    /// a non-running state. For example, this might happen whenever the task blocks on synchronization primitives, or
    /// waits for I/O operations to complete. The host calls <see cref="SwitchOut"/> to notify the CLR that the task represented
    /// by the current <see cref="ICLRTask"/> instance is no longer in an operable state. A task typically terminates at the end of code
    /// execution. At that time, the host calls <see cref="ExitTask"/> to destroy the associated <see cref="ICLRTask"/>. However, tasks can
    /// also be recycled by using a call to <see cref="Reset"/>, which allows the <see cref="ICLRTask"/> instance to be used again. This
    /// approach prevents the overhead of repeatedly creating and destroying instances.
    /// </remarks>
    public class CLRTask : ComObject<ICLRTask>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CLRTask"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CLRTask(ICLRTask raw) : base(raw)
        {
        }

        #region ICLRTask
        #region MemStats

        /// <summary>
        /// Gets statistical memory usage information related to the task that the current <see cref="ICLRTask"/> instance represents.
        /// </summary>
        public COR_GC_THREAD_STATS MemStats
        {
            get
            {
                HRESULT hr;
                COR_GC_THREAD_STATS memUsage;

                if ((hr = TryGetMemStats(out memUsage)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return memUsage;
            }
        }

        /// <summary>
        /// Gets statistical memory usage information related to the task that the current <see cref="ICLRTask"/> instance represents.
        /// </summary>
        /// <param name="memUsage">[out] A pointer to a <see cref="COR_GC_THREAD_STATS"/> instance that contains details about the memory usage of the task, including the number of bytes allocated.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | GetMemStats returned successfully.                                                                                                                                                         |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        public HRESULT TryGetMemStats(out COR_GC_THREAD_STATS memUsage)
        {
            /*HRESULT GetMemStats([Out] out COR_GC_THREAD_STATS memUsage);*/
            return Raw.GetMemStats(out memUsage);
        }

        #endregion
        #region SwitchIn

        /// <summary>
        /// Notifies the common language runtime (CLR) that the task that the current <see cref="ICLRTask"/> instance represents is now in an operable state.
        /// </summary>
        /// <param name="threadHandle">[in] A handle to the physical thread on which the task represented by the current <see cref="ICLRTask"/> instance is executing.</param>
        /// <remarks>
        /// The threadHandle parameter represents a handle to the operating system thread on which the task represented by
        /// the current <see cref="ICLRTask"/> instance has been scheduled. If impersonation has occurred on this thread, you must call <see 
        ///cref="HostSecurityManager.RevertToSelf"/> before switching in the task.
        /// </remarks>
        public void SwitchIn(IntPtr threadHandle)
        {
            HRESULT hr;

            if ((hr = TrySwitchIn(threadHandle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the common language runtime (CLR) that the task that the current <see cref="ICLRTask"/> instance represents is now in an operable state.
        /// </summary>
        /// <param name="threadHandle">[in] A handle to the physical thread on which the task represented by the current <see cref="ICLRTask"/> instance is executing.</param>
        /// <returns>
        /// | HRESULT                 | Description                                                                                                                                                                                |
        /// | ----------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                    | SwitchIn returned successfully.                                                                                                                                                            |
        /// | HOST_E_CLRNOTAVAILABLE  | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                 |
        /// | HOST_E_TIMEOUT          | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER        | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED        | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                  | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | HOST_E_INVALIDOPERATION | SwitchIn was called without an earlier call to <see cref="SwitchOut"/>.                                                                                                                    |
        /// </returns>
        /// <remarks>
        /// The threadHandle parameter represents a handle to the operating system thread on which the task represented by
        /// the current <see cref="ICLRTask"/> instance has been scheduled. If impersonation has occurred on this thread, you must call <see 
        ///cref="HostSecurityManager.RevertToSelf"/> before switching in the task.
        /// </remarks>
        public HRESULT TrySwitchIn(IntPtr threadHandle)
        {
            /*HRESULT SwitchIn([In] IntPtr threadHandle);*/
            return Raw.SwitchIn(threadHandle);
        }

        #endregion
        #region SwitchOut

        /// <summary>
        /// Notifies the common language runtime (CLR) that the task represented by the current <see cref="ICLRTask"/> instance is no longer in an operable state.
        /// </summary>
        /// <remarks>
        /// A host calls SwitchOut to inform the CLR that it has temporarily stopped executing the task that the current <see cref="ICLRTask"/>
        /// instance represents, and will reschedule the task.
        /// </remarks>
        public void SwitchOut()
        {
            HRESULT hr;

            if ((hr = TrySwitchOut()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the common language runtime (CLR) that the task represented by the current <see cref="ICLRTask"/> instance is no longer in an operable state.
        /// </summary>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | SwitchOut returned successfully.                                                                                                                                                           |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                 |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// A host calls SwitchOut to inform the CLR that it has temporarily stopped executing the task that the current <see cref="ICLRTask"/>
        /// instance represents, and will reschedule the task.
        /// </remarks>
        public HRESULT TrySwitchOut()
        {
            /*HRESULT SwitchOut();*/
            return Raw.SwitchOut();
        }

        #endregion
        #region Reset

        /// <summary>
        /// Informs the common language runtime (CLR) that the host has completed a task, and enables the CLR to reuse the current <see cref="ICLRTask"/> instance to represent another task.
        /// </summary>
        /// <param name="fFull">[in] true, if the runtime should reset all thread-related static values in addition to the security and locale information related to the current <see cref="ICLRTask"/> instance; otherwise, false.<para/>
        /// If the value is true, the runtime resets data that was stored using <see cref="Thread.AllocateDataSlot"/> or <see cref="Thread.AllocateNamedDataSlot"/>.</param>
        /// <remarks>
        /// The CLR can recycle previously created <see cref="ICLRTask"/> instances to avoid the overhead of repeatedly creating new instances
        /// every time it needs a fresh task. The host enables this feature by calling <see cref="Reset"/> instead of <see cref="ExitTask"/>
        /// when it has completed a task. The following list summarizes the normal life cycle of an <see cref="ICLRTask"/> instance: Reset
        /// alters this scenario in two ways. In step 5 above, the host calls Reset to reset the task to a clean state, and
        /// then decouples the <see cref="ICLRTask"/> instance from its associated <see cref="IHostTask"/> instance. If desired, the host
        /// can also cache the <see cref="IHostTask"/> instance for reuse. In step 1 above, the runtime pulls a recycled <see cref="ICLRTask"/> from the
        /// cache instead of creating a new instance. This approach works well when the host also has a pool of reusable worker
        /// tasks. When the host destroys one of its <see cref="IHostTask"/> instances, it destroys the corresponding <see cref="ICLRTask"/> by calling
        /// ExitTask.
        /// </remarks>
        public void Reset(int fFull)
        {
            HRESULT hr;

            if ((hr = TryReset(fFull)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Informs the common language runtime (CLR) that the host has completed a task, and enables the CLR to reuse the current <see cref="ICLRTask"/> instance to represent another task.
        /// </summary>
        /// <param name="fFull">[in] true, if the runtime should reset all thread-related static values in addition to the security and locale information related to the current <see cref="ICLRTask"/> instance; otherwise, false.<para/>
        /// If the value is true, the runtime resets data that was stored using <see cref="Thread.AllocateDataSlot"/> or <see cref="Thread.AllocateNamedDataSlot"/>.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | Reset returned successfully.                                                                                                                                                               |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call. successfully                                                 |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// The CLR can recycle previously created <see cref="ICLRTask"/> instances to avoid the overhead of repeatedly creating new instances
        /// every time it needs a fresh task. The host enables this feature by calling <see cref="Reset"/> instead of <see cref="ExitTask"/>
        /// when it has completed a task. The following list summarizes the normal life cycle of an <see cref="ICLRTask"/> instance: Reset
        /// alters this scenario in two ways. In step 5 above, the host calls Reset to reset the task to a clean state, and
        /// then decouples the <see cref="ICLRTask"/> instance from its associated <see cref="IHostTask"/> instance. If desired, the host
        /// can also cache the <see cref="IHostTask"/> instance for reuse. In step 1 above, the runtime pulls a recycled <see cref="ICLRTask"/> from the
        /// cache instead of creating a new instance. This approach works well when the host also has a pool of reusable worker
        /// tasks. When the host destroys one of its <see cref="IHostTask"/> instances, it destroys the corresponding <see cref="ICLRTask"/> by calling
        /// ExitTask.
        /// </remarks>
        public HRESULT TryReset(int fFull)
        {
            /*HRESULT Reset([In] int fFull);*/
            return Raw.Reset(fFull);
        }

        #endregion
        #region ExitTask

        /// <summary>
        /// Notifies the common language runtime (CLR) that the task represented by the current <see cref="ICLRTask"/> instance is ending, and attempts to shut the task down gracefully.
        /// </summary>
        /// <remarks>
        /// ExitTask attempts a clean shutdown of a task, in a manner analogous to detaching a thread from an unmanaged type
        /// library.
        /// </remarks>
        public void ExitTask()
        {
            HRESULT hr;

            if ((hr = TryExitTask()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the common language runtime (CLR) that the task represented by the current <see cref="ICLRTask"/> instance is ending, and attempts to shut the task down gracefully.
        /// </summary>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | ExitTask returned successfully.                                                                                                                                                            |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                 |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// ExitTask attempts a clean shutdown of a task, in a manner analogous to detaching a thread from an unmanaged type
        /// library.
        /// </remarks>
        public HRESULT TryExitTask()
        {
            /*HRESULT ExitTask();*/
            return Raw.ExitTask();
        }

        #endregion
        #region Abort

        /// <summary>
        /// Requests that the common language runtime (CLR) abort the task that the current <see cref="ICLRTask"/> instance represents.
        /// </summary>
        /// <remarks>
        /// The CLR raises a <see cref="ThreadAbortException"/> when the host calls Abort. It returns immediately after the
        /// exception information is initialized, without waiting for user code, such as finalizers or exception handling mechanisms,
        /// to execute. Calls to Abort thus return quickly.
        /// </remarks>
        public void Abort()
        {
            HRESULT hr;

            if ((hr = TryAbort()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Requests that the common language runtime (CLR) abort the task that the current <see cref="ICLRTask"/> instance represents.
        /// </summary>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | Abort returned successfully.                                                                                                                                                               |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                 |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// The CLR raises a <see cref="ThreadAbortException"/> when the host calls Abort. It returns immediately after the
        /// exception information is initialized, without waiting for user code, such as finalizers or exception handling mechanisms,
        /// to execute. Calls to Abort thus return quickly.
        /// </remarks>
        public HRESULT TryAbort()
        {
            /*HRESULT Abort();*/
            return Raw.Abort();
        }

        #endregion
        #region RudeAbort

        /// <summary>
        /// Instructs the common language runtime (CLR) to abort the task represented by the current <see cref="ICLRTask"/> instance immediately and unconditionally.
        /// </summary>
        /// <remarks>
        /// A host calls RudeAbort to abort a task immediately. Finalizers and exception handling routines are not guaranteed
        /// to be executed.
        /// </remarks>
        public void RudeAbort()
        {
            HRESULT hr;

            if ((hr = TryRudeAbort()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Instructs the common language runtime (CLR) to abort the task represented by the current <see cref="ICLRTask"/> instance immediately and unconditionally.
        /// </summary>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | RudeAbort returned successfully.                                                                                                                                                           |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                 |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// A host calls RudeAbort to abort a task immediately. Finalizers and exception handling routines are not guaranteed
        /// to be executed.
        /// </remarks>
        public HRESULT TryRudeAbort()
        {
            /*HRESULT RudeAbort();*/
            return Raw.RudeAbort();
        }

        #endregion
        #region NeedsPriorityScheduling

        /// <summary>
        /// Gets a value that indicates whether the current task, which is being switched out, needs to be marked as a high priority for rescheduling.
        /// </summary>
        /// <returns>[out] true, if the host should attempt to reschedule the current task instance as soon as possible; otherwise, false.</returns>
        /// <remarks>
        /// In situations where the task is close to being collected by the garbage collector, the CLR sets the value of pbNeedsPriorityScheduling
        /// to true, indicating high-priority rescheduling. This allows the host to reschedule the task quickly, thereby minimizing
        /// the potential for delays in garbage collection, and enabling the host and the runtime to cooperate in conserving
        /// memory resources.
        /// </remarks>
        public int NeedsPriorityScheduling()
        {
            HRESULT hr;
            int pbNeedsPriorityScheduling;

            if ((hr = TryNeedsPriorityScheduling(out pbNeedsPriorityScheduling)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pbNeedsPriorityScheduling;
        }

        /// <summary>
        /// Gets a value that indicates whether the current task, which is being switched out, needs to be marked as a high priority for rescheduling.
        /// </summary>
        /// <param name="pbNeedsPriorityScheduling">[out] true, if the host should attempt to reschedule the current task instance as soon as possible; otherwise, false.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | NeedsPriorityRescheduling returned successfully.                                                                                                                                           |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// In situations where the task is close to being collected by the garbage collector, the CLR sets the value of pbNeedsPriorityScheduling
        /// to true, indicating high-priority rescheduling. This allows the host to reschedule the task quickly, thereby minimizing
        /// the potential for delays in garbage collection, and enabling the host and the runtime to cooperate in conserving
        /// memory resources.
        /// </remarks>
        public HRESULT TryNeedsPriorityScheduling(out int pbNeedsPriorityScheduling)
        {
            /*HRESULT NeedsPriorityScheduling([Out] out int pbNeedsPriorityScheduling);*/
            return Raw.NeedsPriorityScheduling(out pbNeedsPriorityScheduling);
        }

        #endregion
        #region YieldTask

        /// <summary>
        /// Requests that the common language runtime (CLR) put aside the task that the current <see cref="ICLRTask"/> instance represents, and make the processor time available to other tasks.
        /// </summary>
        /// <remarks>
        /// A host calls YieldTask to request processor resources for other tasks or processes. This method is primarily intended
        /// to allow long-running code to give up CPU time. The runtime attempts to put the task that the current <see cref="ICLRTask"/>
        /// instance represents in a state where it can yield processing time, but makes no guarantee of success.
        /// </remarks>
        public void YieldTask()
        {
            HRESULT hr;

            if ((hr = TryYieldTask()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Requests that the common language runtime (CLR) put aside the task that the current <see cref="ICLRTask"/> instance represents, and make the processor time available to other tasks.
        /// </summary>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | YieldTask returned successfully.                                                                                                                                                           |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                 |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// A host calls YieldTask to request processor resources for other tasks or processes. This method is primarily intended
        /// to allow long-running code to give up CPU time. The runtime attempts to put the task that the current <see cref="ICLRTask"/>
        /// instance represents in a state where it can yield processing time, but makes no guarantee of success.
        /// </remarks>
        public HRESULT TryYieldTask()
        {
            /*HRESULT YieldTask();*/
            return Raw.YieldTask();
        }

        #endregion
        #region LocksHeld

        /// <summary>
        /// Gets the number of locks currently held on the task.
        /// </summary>
        /// <returns>[out] The number of locks held on the task at the time of the method call.</returns>
        public int LocksHeld()
        {
            HRESULT hr;
            int pLockCount;

            if ((hr = TryLocksHeld(out pLockCount)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pLockCount;
        }

        /// <summary>
        /// Gets the number of locks currently held on the task.
        /// </summary>
        /// <param name="pLockCount">[out] The number of locks held on the task at the time of the method call.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | LocksHeld returned successfully.                                                                                                                                                           |
        /// | HOST_E_CLRNOTAVAILABLE | The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                       |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        public HRESULT TryLocksHeld(out int pLockCount)
        {
            /*HRESULT LocksHeld([Out] out int pLockCount);*/
            return Raw.LocksHeld(out pLockCount);
        }

        #endregion
        #region SetTaskIdentifier

        /// <summary>
        /// Instructs the common language runtime (CLR) to associate the specified identifier value with the task represented by the current <see cref="ICLRTask"/> instance.
        /// </summary>
        /// <param name="asked">[in] The unique identifier for the common language runtime to associate with the task represented by the current <see cref="ICLRTask"/> instance.</param>
        /// <remarks>
        /// The host can associate an identifier with a task to help integrate the CLR and the host in a debugging environment.
        /// The identifier has no meaning for the CLR. The CLR passes it along to a debugger application. The debugger can
        /// use this identifier to associate a CLR call stack with a host call stack, and enable their respective trace information
        /// to be unified when viewed in the debugger's user interface.
        /// </remarks>
        public void SetTaskIdentifier(long asked)
        {
            HRESULT hr;

            if ((hr = TrySetTaskIdentifier(asked)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Instructs the common language runtime (CLR) to associate the specified identifier value with the task represented by the current <see cref="ICLRTask"/> instance.
        /// </summary>
        /// <param name="asked">[in] The unique identifier for the common language runtime to associate with the task represented by the current <see cref="ICLRTask"/> instance.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | SetTaskIdentifier returned successfully.                                                                                                                                                   |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                 |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// The host can associate an identifier with a task to help integrate the CLR and the host in a debugging environment.
        /// The identifier has no meaning for the CLR. The CLR passes it along to a debugger application. The debugger can
        /// use this identifier to associate a CLR call stack with a host call stack, and enable their respective trace information
        /// to be unified when viewed in the debugger's user interface.
        /// </remarks>
        public HRESULT TrySetTaskIdentifier(long asked)
        {
            /*HRESULT SetTaskIdentifier([In] long asked);*/
            return Raw.SetTaskIdentifier(asked);
        }

        #endregion
        #endregion
    }
}