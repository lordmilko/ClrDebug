using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ManagedCorDebug
{
    public class CLRMetaHostPolicy : ComObject<ICLRMetaHostPolicy>
    {
        public CLRMetaHostPolicy(ICLRMetaHostPolicy raw) : base(raw)
        {
        }

        #region ICLRMetaHostPolicy
        #region GetRequestedRuntime

        public GetRequestedRuntimeResult GetRequestedRuntime(METAHOST_POLICY_FLAGS dwPolicyFlags, string pwzBinary, IStream pCfgStream, Guid riid)
        {
            HRESULT hr;
            GetRequestedRuntimeResult result;

            if ((hr = TryGetRequestedRuntime(dwPolicyFlags, pwzBinary, pCfgStream, riid, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetRequestedRuntime(METAHOST_POLICY_FLAGS dwPolicyFlags, string pwzBinary, IStream pCfgStream, Guid riid, out GetRequestedRuntimeResult result)
        {
            /*HRESULT GetRequestedRuntime(
            [In] METAHOST_POLICY_FLAGS dwPolicyFlags,
            [MarshalAs(UnmanagedType.LPWStr), In] string pwzBinary,
            [MarshalAs(UnmanagedType.Interface), In]
            IStream pCfgStream,
            [MarshalAs(UnmanagedType.LPWStr), In] [Out]
            StringBuilder pwzVersion,
            [In] [Out] ref uint pcchVersion,
            [MarshalAs(UnmanagedType.LPWStr), Out]
            StringBuilder pwzImageVersion,
            [In] [Out] ref uint pcchImageVersion,
            out METAHOST_CONFIG_FLAGS pdwConfigFlags,
            [In] ref Guid riid,
            [Out] out object ppRuntime);*/
            StringBuilder pwzVersion = null;
            uint pcchVersion = default(uint);
            StringBuilder pwzImageVersion = null;
            uint pcchImageVersion = default(uint);
            METAHOST_CONFIG_FLAGS pdwConfigFlags;
            object ppRuntime;
            HRESULT hr = Raw.GetRequestedRuntime(dwPolicyFlags, pwzBinary, pCfgStream, pwzVersion, ref pcchVersion, pwzImageVersion, ref pcchImageVersion, out pdwConfigFlags, ref riid, out ppRuntime);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            pwzVersion = new StringBuilder((int) pcchVersion);
            pwzImageVersion = new StringBuilder((int) pcchImageVersion);
            hr = Raw.GetRequestedRuntime(dwPolicyFlags, pwzBinary, pCfgStream, pwzVersion, ref pcchVersion, pwzImageVersion, ref pcchImageVersion, out pdwConfigFlags, ref riid, out ppRuntime);

            if (hr == HRESULT.S_OK)
            {
                result = new GetRequestedRuntimeResult(pwzVersion.ToString(), pwzImageVersion.ToString(), pdwConfigFlags, ppRuntime);

                return hr;
            }

            fail:
            result = default(GetRequestedRuntimeResult);

            return hr;
        }

        #endregion
        #endregion
    }
}