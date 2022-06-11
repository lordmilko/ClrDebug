using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class HostTask : ComObject<IHostTask>
    {
        public HostTask(IHostTask raw) : base(raw)
        {
        }

        #region IHostTask
        #region GetPriority

        public int Priority
        {
            get
            {
                HRESULT hr;
                int pPriority;

                if ((hr = TryGetPriority(out pPriority)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pPriority;
            }
            set
            {
                HRESULT hr;

                if ((hr = TrySetPriority(value)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);
            }
        }

        public HRESULT TryGetPriority(out int pPriority)
        {
            /*HRESULT GetPriority([Out] out int pPriority);*/
            return Raw.GetPriority(out pPriority);
        }

        public HRESULT TrySetPriority(int newPriority)
        {
            /*HRESULT SetPriority([In] int newPriority);*/
            return Raw.SetPriority(newPriority);
        }

        #endregion
        #region Start

        public void Start()
        {
            HRESULT hr;

            if ((hr = TryStart()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryStart()
        {
            /*HRESULT Start();*/
            return Raw.Start();
        }

        #endregion
        #region Alert

        public void Alert()
        {
            HRESULT hr;

            if ((hr = TryAlert()) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryAlert()
        {
            /*HRESULT Alert();*/
            return Raw.Alert();
        }

        #endregion
        #region Join

        public void Join(uint dwMilliseconds, uint option)
        {
            HRESULT hr;

            if ((hr = TryJoin(dwMilliseconds, option)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryJoin(uint dwMilliseconds, uint option)
        {
            /*HRESULT Join([In] uint dwMilliseconds, [In] uint option);*/
            return Raw.Join(dwMilliseconds, option);
        }

        #endregion
        #region SetCLRTask

        public void SetCLRTask(ICLRTask pCLRTask)
        {
            HRESULT hr;

            if ((hr = TrySetCLRTask(pCLRTask)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetCLRTask(ICLRTask pCLRTask)
        {
            /*HRESULT SetCLRTask([In, MarshalAs(UnmanagedType.Interface)] ICLRTask pCLRTask);*/
            return Raw.SetCLRTask(pCLRTask);
        }

        #endregion
        #endregion
    }
}