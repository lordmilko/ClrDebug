using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class CorDebugEditAndContinueErrorInfo : ComObject<ICorDebugEditAndContinueErrorInfo>
    {
        public CorDebugEditAndContinueErrorInfo(ICorDebugEditAndContinueErrorInfo raw) : base(raw)
        {
        }

        #region ICorDebugEditAndContinueErrorInfo
        #region GetModule

        [Obsolete]
        public CorDebugModule Module
        {
            get
            {
                HRESULT hr;
                CorDebugModule ppModuleResult;

                if ((hr = TryGetModule(out ppModuleResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return ppModuleResult;
            }
        }

        [Obsolete]
        public HRESULT TryGetModule(out CorDebugModule ppModuleResult)
        {
            /*HRESULT GetModule([MarshalAs(UnmanagedType.Interface)] out ICorDebugModule ppModule);*/
            ICorDebugModule ppModule;
            HRESULT hr = Raw.GetModule(out ppModule);

            if (hr == HRESULT.S_OK)
                ppModuleResult = new CorDebugModule(ppModule);
            else
                ppModuleResult = default(CorDebugModule);

            return hr;
        }

        #endregion
        #region GetToken

        [Obsolete]
        public uint Token
        {
            get
            {
                HRESULT hr;
                uint pToken;

                if ((hr = TryGetToken(out pToken)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pToken;
            }
        }

        [Obsolete]
        public HRESULT TryGetToken(out uint pToken)
        {
            /*HRESULT GetToken(out uint pToken);*/
            return Raw.GetToken(out pToken);
        }

        #endregion
        #region GetErrorCode

        [Obsolete]
        public int ErrorCode
        {
            get
            {
                HRESULT hr;
                int pHr;

                if ((hr = TryGetErrorCode(out pHr)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pHr;
            }
        }

        [Obsolete]
        public HRESULT TryGetErrorCode(out int pHr)
        {
            /*HRESULT GetErrorCode([MarshalAs(UnmanagedType.Error)] out int pHr);*/
            return Raw.GetErrorCode(out pHr);
        }

        #endregion
        #region GetString

        [Obsolete]
        public string GetString()
        {
            HRESULT hr;
            string szStringResult;

            if ((hr = TryGetString(out szStringResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szStringResult;
        }

        [Obsolete]
        public HRESULT TryGetString(out string szStringResult)
        {
            /*HRESULT GetString([In] uint cchString, out uint pcchString, [Out] StringBuilder szString);*/
            uint cchString = 0;
            uint pcchString;
            StringBuilder szString = null;
            HRESULT hr = Raw.GetString(cchString, out pcchString, szString);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchString = pcchString;
            szString = new StringBuilder((int) pcchString);
            hr = Raw.GetString(cchString, out pcchString, szString);

            if (hr == HRESULT.S_OK)
            {
                szStringResult = szString.ToString();

                return hr;
            }

            fail:
            szStringResult = default(string);

            return hr;
        }

        #endregion
        #endregion
    }
}