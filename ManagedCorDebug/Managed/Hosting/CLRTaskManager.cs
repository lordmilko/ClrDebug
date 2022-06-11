using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CLRTaskManager : ComObject<ICLRTaskManager>
    {
        public CLRTaskManager(ICLRTaskManager raw) : base(raw)
        {
        }

        #region ICLRTaskManager
        #region GetCurrentTask

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
        #region GetCurrentTaskType

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

        public HRESULT TryGetCurrentTaskType(out ETaskType pTaskType)
        {
            /*HRESULT GetCurrentTaskType([Out] out ETaskType pTaskType);*/
            return Raw.GetCurrentTaskType(out pTaskType);
        }

        #endregion
        #region CreateTask

        public CLRTask CreateTask()
        {
            HRESULT hr;
            CLRTask pTaskResult;

            if ((hr = TryCreateTask(out pTaskResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pTaskResult;
        }

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

        public void SetUILocale(int lcid)
        {
            HRESULT hr;

            if ((hr = TrySetUILocale(lcid)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetUILocale(int lcid)
        {
            /*HRESULT SetUILocale([In] int lcid);*/
            return Raw.SetUILocale(lcid);
        }

        #endregion
        #region SetLocale

        public void SetLocale(int lcid)
        {
            HRESULT hr;

            if ((hr = TrySetLocale(lcid)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetLocale(int lcid)
        {
            /*HRESULT SetLocale([In] int lcid);*/
            return Raw.SetLocale(lcid);
        }

        #endregion
        #endregion
    }
}