using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CLRControl : ComObject<ICLRControl>
    {
        public CLRControl(ICLRControl raw) : base(raw)
        {
        }

        #region ICLRControl
        #region GetCLRManager

        public object GetCLRManager(Guid riid)
        {
            HRESULT hr;
            object ppObject;

            if ((hr = TryGetCLRManager(riid, out ppObject)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return ppObject;
        }

        public HRESULT TryGetCLRManager(Guid riid, out object ppObject)
        {
            /*HRESULT GetCLRManager(
            [In] [MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [MarshalAs(UnmanagedType.Interface, IidParameterIndex = 0)] out object ppObject);*/
            return Raw.GetCLRManager(riid, out ppObject);
        }

        #endregion
        #region SetAppDomainManagerType

        public void SetAppDomainManagerType(string pwzAppDomainManagerAssembly, string pwzAppDomainManagerType)
        {
            HRESULT hr;

            if ((hr = TrySetAppDomainManagerType(pwzAppDomainManagerAssembly, pwzAppDomainManagerType)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TrySetAppDomainManagerType(string pwzAppDomainManagerAssembly, string pwzAppDomainManagerType)
        {
            /*HRESULT SetAppDomainManagerType(
            [MarshalAs(UnmanagedType.LPWStr)] [In] string pwzAppDomainManagerAssembly,
            [MarshalAs(UnmanagedType.LPWStr)] [In] string pwzAppDomainManagerType);*/
            return Raw.SetAppDomainManagerType(pwzAppDomainManagerAssembly, pwzAppDomainManagerType);
        }

        #endregion
        #endregion
    }
}