using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class HostIoCompletionManager : ComObject<IHostIoCompletionManager>
    {
        public HostIoCompletionManager(IHostIoCompletionManager raw) : base(raw)
        {
        }

        #region IHostIoCompletionManager
        #region GetMaxThreads

        public uint MaxThreads
        {
            get
            {
                HRESULT hr;
                uint pdwMaxIOCompletionThreads;

                if ((hr = TryGetMaxThreads(out pdwMaxIOCompletionThreads)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pdwMaxIOCompletionThreads;
            }
            set
            {
                HRESULT hr;

                if ((hr = TrySetMaxThreads(value)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);
            }
        }

        public HRESULT TryGetMaxThreads(out uint pdwMaxIOCompletionThreads)
        {
            /*HRESULT GetMaxThreads([Out] out uint pdwMaxIOCompletionThreads);*/
            return Raw.GetMaxThreads(out pdwMaxIOCompletionThreads);
        }

        public HRESULT TrySetMaxThreads(uint dwMaxIOCompletionThreads)
        {
            /*HRESULT SetMaxThreads([In] uint dwMaxIOCompletionThreads);*/
            return Raw.SetMaxThreads(dwMaxIOCompletionThreads);
        }

        #endregion
        #region GetAvailableThreads

        public uint AvailableThreads
        {
            get
            {
                HRESULT hr;
                uint pdwAvailableIOCompletionThreads;

                if ((hr = TryGetAvailableThreads(out pdwAvailableIOCompletionThreads)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pdwAvailableIOCompletionThreads;
            }
        }

        public HRESULT TryGetAvailableThreads(out uint pdwAvailableIOCompletionThreads)
        {
            /*HRESULT GetAvailableThreads([Out] out uint pdwAvailableIOCompletionThreads);*/
            return Raw.GetAvailableThreads(out pdwAvailableIOCompletionThreads);
        }

        #endregion
        #region GetHostOverlappedSize

        public uint HostOverlappedSize
        {
            get
            {
                HRESULT hr;
                uint pcbSize;

                if ((hr = TryGetHostOverlappedSize(out pcbSize)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pcbSize;
            }
        }

        public HRESULT TryGetHostOverlappedSize(out uint pcbSize)
        {
            /*HRESULT GetHostOverlappedSize([Out] out uint pcbSize);*/
            return Raw.GetHostOverlappedSize(out pcbSize);
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
        #region CreateIoCompletionPort

        public IntPtr CreateIoCompletionPort()
        {
            HRESULT hr;
            IntPtr phPort = default(IntPtr);

            if ((hr = TryCreateIoCompletionPort(ref phPort)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return phPort;
        }

        public HRESULT TryCreateIoCompletionPort(ref IntPtr phPort)
        {
            /*HRESULT CreateIoCompletionPort([Out] IntPtr phPort);*/
            return Raw.CreateIoCompletionPort(phPort);
        }

        #endregion
        #region CloseIoCompletionPort

        public void CloseIoCompletionPort(IntPtr hPort)
        {
            HRESULT hr;

            if ((hr = TryCloseIoCompletionPort(hPort)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryCloseIoCompletionPort(IntPtr hPort)
        {
            /*HRESULT CloseIoCompletionPort([In] IntPtr hPort);*/
            return Raw.CloseIoCompletionPort(hPort);
        }

        #endregion
        #region SetCLRIoCompletionManager

        public void SetCLRIoCompletionManager(ICLRIoCompletionManager pManager)
        {
            HRESULT hr;

            if ((hr = TrySetCLRIoCompletionManager(pManager)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetCLRIoCompletionManager(ICLRIoCompletionManager pManager)
        {
            /*HRESULT SetCLRIoCompletionManager(
            [In, MarshalAs(UnmanagedType.Interface)] ICLRIoCompletionManager pManager);*/
            return Raw.SetCLRIoCompletionManager(pManager);
        }

        #endregion
        #region InitializeHostOverlapped

        public void InitializeHostOverlapped(IntPtr pvOverlapped)
        {
            HRESULT hr;

            if ((hr = TryInitializeHostOverlapped(pvOverlapped)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryInitializeHostOverlapped(IntPtr pvOverlapped)
        {
            /*HRESULT InitializeHostOverlapped(
            [In] IntPtr pvOverlapped);*/
            return Raw.InitializeHostOverlapped(pvOverlapped);
        }

        #endregion
        #region Bind

        public void Bind(IntPtr hPort, IntPtr hHandle)
        {
            HRESULT hr;

            if ((hr = TryBind(hPort, hHandle)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryBind(IntPtr hPort, IntPtr hHandle)
        {
            /*HRESULT Bind(
            [In] IntPtr hPort,
            [In] IntPtr hHandle);*/
            return Raw.Bind(hPort, hHandle);
        }

        #endregion
        #endregion
    }
}