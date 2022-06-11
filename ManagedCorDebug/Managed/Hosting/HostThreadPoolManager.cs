using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class HostThreadPoolManager : ComObject<IHostThreadPoolManager>
    {
        public HostThreadPoolManager(IHostThreadPoolManager raw) : base(raw)
        {
        }

        #region IHostThreadPoolManager
        #region GetMaxThreads

        public uint MaxThreads
        {
            get
            {
                HRESULT hr;
                uint pdwMaxWorkerThreads;

                if ((hr = TryGetMaxThreads(out pdwMaxWorkerThreads)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pdwMaxWorkerThreads;
            }
            set
            {
                HRESULT hr;

                if ((hr = TrySetMaxThreads(value)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);
            }
        }

        public HRESULT TryGetMaxThreads(out uint pdwMaxWorkerThreads)
        {
            /*HRESULT GetMaxThreads(
            [Out] out uint pdwMaxWorkerThreads);*/
            return Raw.GetMaxThreads(out pdwMaxWorkerThreads);
        }

        public HRESULT TrySetMaxThreads(uint dwMaxWorkerThreads)
        {
            /*HRESULT SetMaxThreads(
            [In] uint dwMaxWorkerThreads);*/
            return Raw.SetMaxThreads(dwMaxWorkerThreads);
        }

        #endregion
        #region GetAvailableThreads

        public uint AvailableThreads
        {
            get
            {
                HRESULT hr;
                uint pdwAvailableWorkerThreads;

                if ((hr = TryGetAvailableThreads(out pdwAvailableWorkerThreads)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pdwAvailableWorkerThreads;
            }
        }

        public HRESULT TryGetAvailableThreads(out uint pdwAvailableWorkerThreads)
        {
            /*HRESULT GetAvailableThreads(
            [Out] out uint pdwAvailableWorkerThreads);*/
            return Raw.GetAvailableThreads(out pdwAvailableWorkerThreads);
        }

        #endregion
        #region GetMinThreads

        public uint MinThreads
        {
            get
            {
                HRESULT hr;
                uint pdwMinIOCompletionThreads;

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

        public HRESULT TryGetMinThreads(out uint pdwMinIOCompletionThreads)
        {
            /*HRESULT GetMinThreads(
            [Out] out uint pdwMinIOCompletionThreads);*/
            return Raw.GetMinThreads(out pdwMinIOCompletionThreads);
        }

        public HRESULT TrySetMinThreads(uint dwMinIOCompletionThreads)
        {
            /*HRESULT SetMinThreads(
            [In] uint dwMinIOCompletionThreads);*/
            return Raw.SetMinThreads(dwMinIOCompletionThreads);
        }

        #endregion
        #region QueueUserWorkItem

        public void QueueUserWorkItem(LPTHREAD_START_ROUTINE function, IntPtr context, uint flags)
        {
            HRESULT hr;

            if ((hr = TryQueueUserWorkItem(function, context, flags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryQueueUserWorkItem(LPTHREAD_START_ROUTINE function, IntPtr context, uint flags)
        {
            /*HRESULT QueueUserWorkItem(
            [In, MarshalAs(UnmanagedType.FunctionPtr)] LPTHREAD_START_ROUTINE Function,
            [In] IntPtr Context,
            [In] uint Flags);*/
            return Raw.QueueUserWorkItem(function, context, flags);
        }

        #endregion
        #endregion
    }
}