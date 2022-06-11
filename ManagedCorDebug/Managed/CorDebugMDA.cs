using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class CorDebugMDA : ComObject<ICorDebugMDA>
    {
        public CorDebugMDA(ICorDebugMDA raw) : base(raw)
        {
        }

        #region ICorDebugMDA
        #region GetOSThreadId

        public uint OSThreadId
        {
            get
            {
                HRESULT hr;
                uint pOsTid;

                if ((hr = TryGetOSThreadId(out pOsTid)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pOsTid;
            }
        }

        public HRESULT TryGetOSThreadId(out uint pOsTid)
        {
            /*HRESULT GetOSThreadId(out uint pOsTid);*/
            return Raw.GetOSThreadId(out pOsTid);
        }

        #endregion
        #region GetName

        public string GetName()
        {
            HRESULT hr;
            string szNameResult;

            if ((hr = TryGetName(out szNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szNameResult;
        }

        public HRESULT TryGetName(out string szNameResult)
        {
            /*HRESULT GetName([In] uint cchName, out uint pcchName, [Out] StringBuilder szName);*/
            uint cchName = 0;
            uint pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetName(cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder((int) pcchName);
            hr = Raw.GetName(cchName, out pcchName, szName);

            if (hr == HRESULT.S_OK)
            {
                szNameResult = szName.ToString();

                return hr;
            }

            fail:
            szNameResult = default(string);

            return hr;
        }

        #endregion
        #region GetDescription

        public string GetDescription()
        {
            HRESULT hr;
            string szNameResult;

            if ((hr = TryGetDescription(out szNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szNameResult;
        }

        public HRESULT TryGetDescription(out string szNameResult)
        {
            /*HRESULT GetDescription([In] uint cchName, out uint pcchName, [Out] StringBuilder szName);*/
            uint cchName = 0;
            uint pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetDescription(cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder((int) pcchName);
            hr = Raw.GetDescription(cchName, out pcchName, szName);

            if (hr == HRESULT.S_OK)
            {
                szNameResult = szName.ToString();

                return hr;
            }

            fail:
            szNameResult = default(string);

            return hr;
        }

        #endregion
        #region GetXML

        public string GetXML()
        {
            HRESULT hr;
            string szNameResult;

            if ((hr = TryGetXML(out szNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szNameResult;
        }

        public HRESULT TryGetXML(out string szNameResult)
        {
            /*HRESULT GetXML([In] uint cchName, out uint pcchName, [Out] StringBuilder szName);*/
            uint cchName = 0;
            uint pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetXML(cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder((int) pcchName);
            hr = Raw.GetXML(cchName, out pcchName, szName);

            if (hr == HRESULT.S_OK)
            {
                szNameResult = szName.ToString();

                return hr;
            }

            fail:
            szNameResult = default(string);

            return hr;
        }

        #endregion
        #region GetFlags

        public void GetFlags(CorDebugMDAFlags pFlags)
        {
            HRESULT hr;

            if ((hr = TryGetFlags(pFlags)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);
        }

        public HRESULT TryGetFlags(CorDebugMDAFlags pFlags)
        {
            /*HRESULT GetFlags([In] ref CorDebugMDAFlags pFlags);*/
            return Raw.GetFlags(ref pFlags);
        }

        #endregion
        #endregion
    }
}