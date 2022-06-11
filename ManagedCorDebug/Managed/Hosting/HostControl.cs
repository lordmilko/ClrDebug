using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class HostControl : ComObject<IHostControl>
    {
        public HostControl(IHostControl raw) : base(raw)
        {
        }

        #region IHostControl
        #region GetHostManager

        public object GetHostManager(Guid riid)
        {
            HRESULT hr;
            object ppObject;

            if ((hr = TryGetHostManager(riid, out ppObject)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppObject;
        }

        public HRESULT TryGetHostManager(Guid riid, out object ppObject)
        {
            /*HRESULT GetHostManager(
            [In] [MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)] out object ppObject);*/
            return Raw.GetHostManager(riid, out ppObject);
        }

        #endregion
        #region SetAppDomainManager

        public void SetAppDomainManager(uint dwAppDomainID, object pUnkAppDomainManager)
        {
            HRESULT hr;

            if ((hr = TrySetAppDomainManager(dwAppDomainID, pUnkAppDomainManager)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetAppDomainManager(uint dwAppDomainID, object pUnkAppDomainManager)
        {
            /*HRESULT SetAppDomainManager(
            [In] uint dwAppDomainID,
            [MarshalAs(UnmanagedType.IUnknown)] [In] object pUnkAppDomainManager);*/
            return Raw.SetAppDomainManager(dwAppDomainID, pUnkAppDomainManager);
        }

        #endregion
        #endregion
    }
}