using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CLRTask : ComObject<ICLRTask>
    {
        public CLRTask(ICLRTask raw) : base(raw)
        {
        }

        #region ICLRTask
        #region GetMemStats

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

        public HRESULT TryGetMemStats(out COR_GC_THREAD_STATS memUsage)
        {
            /*HRESULT GetMemStats([Out] out COR_GC_THREAD_STATS memUsage);*/
            return Raw.GetMemStats(out memUsage);
        }

        #endregion
        #region SwitchIn

        public void SwitchIn(IntPtr threadHandle)
        {
            HRESULT hr;

            if ((hr = TrySwitchIn(threadHandle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySwitchIn(IntPtr threadHandle)
        {
            /*HRESULT SwitchIn([In] IntPtr threadHandle);*/
            return Raw.SwitchIn(threadHandle);
        }

        #endregion
        #region SwitchOut

        public void SwitchOut()
        {
            HRESULT hr;

            if ((hr = TrySwitchOut()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySwitchOut()
        {
            /*HRESULT SwitchOut();*/
            return Raw.SwitchOut();
        }

        #endregion
        #region Reset

        public void Reset(int fFull)
        {
            HRESULT hr;

            if ((hr = TryReset(fFull)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryReset(int fFull)
        {
            /*HRESULT Reset([In] int fFull);*/
            return Raw.Reset(fFull);
        }

        #endregion
        #region ExitTask

        public void ExitTask()
        {
            HRESULT hr;

            if ((hr = TryExitTask()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryExitTask()
        {
            /*HRESULT ExitTask();*/
            return Raw.ExitTask();
        }

        #endregion
        #region Abort

        public void Abort()
        {
            HRESULT hr;

            if ((hr = TryAbort()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryAbort()
        {
            /*HRESULT Abort();*/
            return Raw.Abort();
        }

        #endregion
        #region RudeAbort

        public void RudeAbort()
        {
            HRESULT hr;

            if ((hr = TryRudeAbort()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryRudeAbort()
        {
            /*HRESULT RudeAbort();*/
            return Raw.RudeAbort();
        }

        #endregion
        #region NeedsPriorityScheduling

        public int NeedsPriorityScheduling()
        {
            HRESULT hr;
            int pbNeedsPriorityScheduling;

            if ((hr = TryNeedsPriorityScheduling(out pbNeedsPriorityScheduling)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pbNeedsPriorityScheduling;
        }

        public HRESULT TryNeedsPriorityScheduling(out int pbNeedsPriorityScheduling)
        {
            /*HRESULT NeedsPriorityScheduling([Out] out int pbNeedsPriorityScheduling);*/
            return Raw.NeedsPriorityScheduling(out pbNeedsPriorityScheduling);
        }

        #endregion
        #region YieldTask

        public void YieldTask()
        {
            HRESULT hr;

            if ((hr = TryYieldTask()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryYieldTask()
        {
            /*HRESULT YieldTask();*/
            return Raw.YieldTask();
        }

        #endregion
        #region LocksHeld

        public uint LocksHeld()
        {
            HRESULT hr;
            uint pLockCount;

            if ((hr = TryLocksHeld(out pLockCount)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return pLockCount;
        }

        public HRESULT TryLocksHeld(out uint pLockCount)
        {
            /*HRESULT LocksHeld([Out] out uint pLockCount);*/
            return Raw.LocksHeld(out pLockCount);
        }

        #endregion
        #region SetTaskIdentifier

        public void SetTaskIdentifier(ulong asked)
        {
            HRESULT hr;

            if ((hr = TrySetTaskIdentifier(asked)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetTaskIdentifier(ulong asked)
        {
            /*HRESULT SetTaskIdentifier([In] ulong asked);*/
            return Raw.SetTaskIdentifier(asked);
        }

        #endregion
        #endregion
    }
}