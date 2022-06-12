using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods that allow the host to request explicitly that the common language runtime (CLR) create a new task, get the currently executing task, and set the geographic language and culture for the task.
    /// </summary>
    /// <remarks>
    /// Each task that is running in a hosted environment has representations both on the host side (an instance of <see 
    ///cref="IHostTask"/>) and on the CLR side (an instance of <see cref="ICLRTask"/>). Either the host or the CLR can
    /// initiate the creation of a task, but the host-side representation must be associated with a corresponding CLR-side
    /// representation to ensure successful communication between the host and the CLR regarding the task. The two objects
    /// must be created and instantiated before managed code can execute on an operating system thread.
    /// </remarks>
    public class CLRTaskManager : ComObject<ICLRTaskManager>
    {
        public CLRTaskManager(ICLRTaskManager raw) : base(raw)
        {
        }

        #region ICLRTaskManager
        #region CurrentTask

        /// <summary>
        /// Gets the <see cref="ICLRTask"/> instance that is currently running on the operating system thread from which the method call originated.
        /// </summary>
        public CLRTask CurrentTask
        {
            get
            {
                HRESULT hr;
                CLRTask pTaskResult;

                if ((hr = TryGetCurrentTask(out pTaskResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pTaskResult;
            }
        }

        /// <summary>
        /// Gets the <see cref="ICLRTask"/> instance that is currently running on the operating system thread from which the method call originated.
        /// </summary>
        /// <param name="pTaskResult">[out] A pointer to the address of an <see cref="ICLRTask"/> instance that is currently executing on the operating system thread from which the call originated, or null if no task is currently executing on this thread.</param>
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
        /// The <see cref="ICLRTask"/> instance that the ppTask parameter points to represents the currently executing task for the CLR.
        /// The <see cref="ICLRTask"/> instance is associated with a corresponding <see cref="IHostTask"/> instance that represents the task
        /// for the host.
        /// </remarks>
        public HRESULT TryGetCurrentTask(out CLRTask pTaskResult)
        {
            /*HRESULT GetCurrentTask([Out] out ICLRTask pTask);*/
            ICLRTask pTask;
            HRESULT hr = Raw.GetCurrentTask(out pTask);

            if (hr == HRESULT.S_OK)
                pTaskResult = new CLRTask(pTask);
            else
                pTaskResult = default(CLRTask);

            return hr;
        }

        #endregion
        #region CurrentTaskType

        /// <summary>
        /// Gets the type of the task that is currently executing.
        /// </summary>
        public ETaskType CurrentTaskType
        {
            get
            {
                HRESULT hr;
                ETaskType pTaskType;

                if ((hr = TryGetCurrentTaskType(out pTaskType)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pTaskType;
            }
        }

        /// <summary>
        /// Gets the type of the task that is currently executing.
        /// </summary>
        /// <param name="pTaskType">[out] A pointer to a value of the <see cref="ETaskType"/> enumeration that indicates the type of task that is currently executing.</param>
        public HRESULT TryGetCurrentTaskType(out ETaskType pTaskType)
        {
            /*HRESULT GetCurrentTaskType([Out] out ETaskType pTaskType);*/
            return Raw.GetCurrentTaskType(out pTaskType);
        }

        #endregion
        #region CreateTask

        /// <summary>
        /// Requests explicitly that the common language runtime (CLR) create a new task.
        /// </summary>
        /// <returns>[out] A pointer to the address of a newly created <see cref="ICLRTask"/>, or null, if the task could not be created.</returns>
        /// <remarks>
        /// The CLR creates a new task automatically upon initialization, when user code creates a thread by using types in
        /// the <see cref="System.Threading"/> namespace, or when the size of the thread pool is increased. It also creates
        /// tasks when unmanaged code makes a call to a managed function. CreateTask allows the host to make an explicit request
        /// that the CLR create a new task. For example, the host can invoke this method to preinitialize data structures.
        /// </remarks>
        public CLRTask CreateTask()
        {
            HRESULT hr;
            CLRTask pTaskResult;

            if ((hr = TryCreateTask(out pTaskResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pTaskResult;
        }

        /// <summary>
        /// Requests explicitly that the common language runtime (CLR) create a new task.
        /// </summary>
        /// <param name="pTaskResult">[out] A pointer to the address of a newly created <see cref="ICLRTask"/>, or null, if the task could not be created.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | The method returned successfully.                                                                                                                                                          |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                 |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// | E_OUTOFMEMORY          | Not enough memory is available to allocate the requested resource.                                                                                                                         |
        /// </returns>
        /// <remarks>
        /// The CLR creates a new task automatically upon initialization, when user code creates a thread by using types in
        /// the <see cref="System.Threading"/> namespace, or when the size of the thread pool is increased. It also creates
        /// tasks when unmanaged code makes a call to a managed function. CreateTask allows the host to make an explicit request
        /// that the CLR create a new task. For example, the host can invoke this method to preinitialize data structures.
        /// </remarks>
        public HRESULT TryCreateTask(out CLRTask pTaskResult)
        {
            /*HRESULT CreateTask([Out] out ICLRTask pTask);*/
            ICLRTask pTask;
            HRESULT hr = Raw.CreateTask(out pTask);

            if (hr == HRESULT.S_OK)
                pTaskResult = new CLRTask(pTask);
            else
                pTaskResult = default(CLRTask);

            return hr;
        }

        #endregion
        #region SetUILocale

        /// <summary>
        /// Notifies the common language runtime (CLR) that the host has modified the user interface (UI) locale, or culture, on the currently executing task.
        /// </summary>
        /// <param name="lcid">[in] The locale identifier value that maps to the newly assigned geographical culture and language for the user interface.</param>
        /// <remarks>
        /// SetUILocale provides an opportunity for the host to execute any mechanisms it might have for the synchronization
        /// of locales.
        /// </remarks>
        public void SetUILocale(int lcid)
        {
            HRESULT hr;

            if ((hr = TrySetUILocale(lcid)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the common language runtime (CLR) that the host has modified the user interface (UI) locale, or culture, on the currently executing task.
        /// </summary>
        /// <param name="lcid">[in] The locale identifier value that maps to the newly assigned geographical culture and language for the user interface.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | SetUILocale returned successfully.                                                                                                                                                         |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                 |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// SetUILocale provides an opportunity for the host to execute any mechanisms it might have for the synchronization
        /// of locales.
        /// </remarks>
        public HRESULT TrySetUILocale(int lcid)
        {
            /*HRESULT SetUILocale([In] int lcid);*/
            return Raw.SetUILocale(lcid);
        }

        #endregion
        #region SetLocale

        /// <summary>
        /// Notifies the common language runtime (CLR) that the host has modified the value of the locale identifier (which maps to the geographical culture and language) on the currently executing task.
        /// </summary>
        /// <param name="lcid">[in] The locale identifier value that maps to the newly assigned geographical culture and language.</param>
        /// <remarks>
        /// SetLocale gives the host an opportunity to execute any mechanisms it might have for the synchronization of locales.
        /// </remarks>
        public void SetLocale(int lcid)
        {
            HRESULT hr;

            if ((hr = TrySetLocale(lcid)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        /// <summary>
        /// Notifies the common language runtime (CLR) that the host has modified the value of the locale identifier (which maps to the geographical culture and language) on the currently executing task.
        /// </summary>
        /// <param name="lcid">[in] The locale identifier value that maps to the newly assigned geographical culture and language.</param>
        /// <returns>
        /// | HRESULT                | Description                                                                                                                                                                                |
        /// | ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
        /// | S_OK                   | The method returned successfully.                                                                                                                                                          |
        /// | HOST_E_CLRNOTAVAILABLE | The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.                                                 |
        /// | HOST_E_TIMEOUT         | The call timed out.                                                                                                                                                                        |
        /// | HOST_E_NOT_OWNER       | The caller does not own the lock.                                                                                                                                                          |
        /// | HOST_E_ABANDONED       | An event was canceled while a blocked thread or fiber was waiting on it.                                                                                                                   |
        /// | E_FAIL                 | An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE. |
        /// </returns>
        /// <remarks>
        /// SetLocale gives the host an opportunity to execute any mechanisms it might have for the synchronization of locales.
        /// </remarks>
        public HRESULT TrySetLocale(int lcid)
        {
            /*HRESULT SetLocale([In] int lcid);*/
            return Raw.SetLocale(lcid);
        }

        #endregion
        #endregion
    }
}