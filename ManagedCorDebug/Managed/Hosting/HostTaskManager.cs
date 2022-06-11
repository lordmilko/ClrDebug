using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class HostTaskManager : ComObject<IHostTaskManager>
    {
        public HostTaskManager(IHostTaskManager raw) : base(raw)
        {
        }

        #region IHostTaskManager
        #region GetStackGuarantee

        public uint StackGuarantee
        {
            get
            {
                HRESULT hr;
                uint pGuarantee;

                if ((hr = TryGetStackGuarantee(out pGuarantee)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pGuarantee;
            }
            set
            {
                HRESULT hr;

                if ((hr = TrySetStackGuarantee(value)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);
            }
        }

        public HRESULT TryGetStackGuarantee(out uint pGuarantee)
        {
            /*HRESULT GetStackGuarantee([Out] out uint pGuarantee);*/
            return Raw.GetStackGuarantee(out pGuarantee);
        }

        public HRESULT TrySetStackGuarantee(uint guarantee)
        {
            /*HRESULT SetStackGuarantee([In] uint guarantee);*/
            return Raw.SetStackGuarantee(guarantee);
        }

        #endregion
        #region CreateTask

        public HostTaskManager CreateTask(uint dwStackSize, LPTHREAD_START_ROUTINE pStartAddress, IntPtr pParameter)
        {
            HRESULT hr;
            HostTaskManager ppTaskResult;

            if ((hr = TryCreateTask(dwStackSize, pStartAddress, pParameter, out ppTaskResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppTaskResult;
        }

        public HRESULT TryCreateTask(uint dwStackSize, LPTHREAD_START_ROUTINE pStartAddress, IntPtr pParameter, out HostTaskManager ppTaskResult)
        {
            /*HRESULT CreateTask(
            [In] uint dwStackSize,
            [In, MarshalAs(UnmanagedType.FunctionPtr)] LPTHREAD_START_ROUTINE pStartAddress,
            [In] IntPtr pParameter,
            [Out] out IHostTaskManager ppTask);*/
            IHostTaskManager ppTask;
            HRESULT hr = Raw.CreateTask(dwStackSize, pStartAddress, pParameter, out ppTask);

            if (hr == HRESULT.S_OK)
                ppTaskResult = new HostTaskManager(ppTask);
            else
                ppTaskResult = default(HostTaskManager);

            return hr;
        }

        #endregion
        #region Sleep

        public void Sleep(uint dwMilliseconds, uint option)
        {
            HRESULT hr;

            if ((hr = TrySleep(dwMilliseconds, option)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySleep(uint dwMilliseconds, uint option)
        {
            /*HRESULT Sleep(
            [In] uint dwMilliseconds,
            [In] uint option);*/
            return Raw.Sleep(dwMilliseconds, option);
        }

        #endregion
        #region SwitchToTask

        public void SwitchToTask(uint option)
        {
            HRESULT hr;

            if ((hr = TrySwitchToTask(option)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySwitchToTask(uint option)
        {
            /*HRESULT SwitchToTask(
            [In] uint option);*/
            return Raw.SwitchToTask(option);
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
            /*HRESULT SetUILocale(
            [In] int lcid);*/
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
            /*HRESULT SetLocale(
            [In] int lcid);*/
            return Raw.SetLocale(lcid);
        }

        #endregion
        #region CallNeedsHostHook

        public int CallNeedsHostHook(uint target)
        {
            HRESULT hr;
            int pbCallNeedsHostHook;

            if ((hr = TryCallNeedsHostHook(target, out pbCallNeedsHostHook)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pbCallNeedsHostHook;
        }

        public HRESULT TryCallNeedsHostHook(uint target, out int pbCallNeedsHostHook)
        {
            /*HRESULT CallNeedsHostHook(
            [In] uint target,
            [Out] out int pbCallNeedsHostHook);*/
            return Raw.CallNeedsHostHook(target, out pbCallNeedsHostHook);
        }

        #endregion
        #region LeaveRuntime

        public void LeaveRuntime(uint target)
        {
            HRESULT hr;

            if ((hr = TryLeaveRuntime(target)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryLeaveRuntime(uint target)
        {
            /*HRESULT LeaveRuntime([In] uint target);*/
            return Raw.LeaveRuntime(target);
        }

        #endregion
        #region EnterRuntime

        public void EnterRuntime()
        {
            HRESULT hr;

            if ((hr = TryEnterRuntime()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEnterRuntime()
        {
            /*HRESULT EnterRuntime();*/
            return Raw.EnterRuntime();
        }

        #endregion
        #region ReverseLeaveRuntime

        public void ReverseLeaveRuntime()
        {
            HRESULT hr;

            if ((hr = TryReverseLeaveRuntime()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryReverseLeaveRuntime()
        {
            /*HRESULT ReverseLeaveRuntime();*/
            return Raw.ReverseLeaveRuntime();
        }

        #endregion
        #region ReverseEnterRuntime

        public void ReverseEnterRuntime()
        {
            HRESULT hr;

            if ((hr = TryReverseEnterRuntime()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryReverseEnterRuntime()
        {
            /*HRESULT ReverseEnterRuntime();*/
            return Raw.ReverseEnterRuntime();
        }

        #endregion
        #region BeginDelayAbort

        public void BeginDelayAbort()
        {
            HRESULT hr;

            if ((hr = TryBeginDelayAbort()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryBeginDelayAbort()
        {
            /*HRESULT BeginDelayAbort();*/
            return Raw.BeginDelayAbort();
        }

        #endregion
        #region EndDelayAbort

        public void EndDelayAbort()
        {
            HRESULT hr;

            if ((hr = TryEndDelayAbort()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEndDelayAbort()
        {
            /*HRESULT EndDelayAbort();*/
            return Raw.EndDelayAbort();
        }

        #endregion
        #region BeginThreadAffinity

        public void BeginThreadAffinity()
        {
            HRESULT hr;

            if ((hr = TryBeginThreadAffinity()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryBeginThreadAffinity()
        {
            /*HRESULT BeginThreadAffinity();*/
            return Raw.BeginThreadAffinity();
        }

        #endregion
        #region EndThreadAffinity

        public void EndThreadAffinity()
        {
            HRESULT hr;

            if ((hr = TryEndThreadAffinity()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryEndThreadAffinity()
        {
            /*HRESULT EndThreadAffinity();*/
            return Raw.EndThreadAffinity();
        }

        #endregion
        #region SetCLRTaskManager

        public CLRTaskManager SetCLRTaskManager()
        {
            HRESULT hr;
            CLRTaskManager ppManagerResult;

            if ((hr = TrySetCLRTaskManager(out ppManagerResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppManagerResult;
        }

        public HRESULT TrySetCLRTaskManager(out CLRTaskManager ppManagerResult)
        {
            /*HRESULT SetCLRTaskManager([Out] out ICLRTaskManager ppManager);*/
            ICLRTaskManager ppManager;
            HRESULT hr = Raw.SetCLRTaskManager(out ppManager);

            if (hr == HRESULT.S_OK)
                ppManagerResult = new CLRTaskManager(ppManager);
            else
                ppManagerResult = default(CLRTaskManager);

            return hr;
        }

        #endregion
        #endregion
    }
}