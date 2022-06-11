using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class CorDebugRemoteTarget : ComObject<ICorDebugRemoteTarget>
    {
        public CorDebugRemoteTarget(ICorDebugRemoteTarget raw) : base(raw)
        {
        }

        #region ICorDebugRemoteTarget
        #region GetHostName

        public string GetHostName()
        {
            HRESULT hr;
            string szHostNameResult;

            if ((hr = TryGetHostName(out szHostNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szHostNameResult;
        }

        public HRESULT TryGetHostName(out string szHostNameResult)
        {
            /*HRESULT GetHostName([In] uint cchHostName, out uint pcchHostName, [Out] StringBuilder szHostName);*/
            uint cchHostName = 0;
            uint pcchHostName;
            StringBuilder szHostName = null;
            HRESULT hr = Raw.GetHostName(cchHostName, out pcchHostName, szHostName);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchHostName = pcchHostName;
            szHostName = new StringBuilder((int) pcchHostName);
            hr = Raw.GetHostName(cchHostName, out pcchHostName, szHostName);

            if (hr == HRESULT.S_OK)
            {
                szHostNameResult = szHostName.ToString();

                return hr;
            }

            fail:
            szHostNameResult = default(string);

            return hr;
        }

        #endregion
        #endregion
    }
}