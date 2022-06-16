using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// <see cref="ICorDebugEditAndContinueErrorInfo"/> is obsolete. Do not use this interface.
    /// </summary>
    public class CorDebugEditAndContinueErrorInfo : ComObject<ICorDebugEditAndContinueErrorInfo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugEditAndContinueErrorInfo"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugEditAndContinueErrorInfo(ICorDebugEditAndContinueErrorInfo raw) : base(raw)
        {
        }

        #region ICorDebugEditAndContinueErrorInfo
        #region Module

        /// <summary>
        /// GetModule is obsolete. Do not call this method.
        /// </summary>
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

        /// <summary>
        /// GetModule is obsolete. Do not call this method.
        /// </summary>
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
        #region Token

        /// <summary>
        /// GetToken is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public int Token
        {
            get
            {
                HRESULT hr;
                int pToken;

                if ((hr = TryGetToken(out pToken)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pToken;
            }
        }

        /// <summary>
        /// GetToken is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public HRESULT TryGetToken(out int pToken)
        {
            /*HRESULT GetToken(out int pToken);*/
            return Raw.GetToken(out pToken);
        }

        #endregion
        #region ErrorCode

        /// <summary>
        /// GetErrorCode is obsolete. Do not call this method.
        /// </summary>
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

        /// <summary>
        /// GetErrorCode is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public HRESULT TryGetErrorCode(out int pHr)
        {
            /*HRESULT GetErrorCode([MarshalAs(UnmanagedType.Error)] out int pHr);*/
            return Raw.GetErrorCode(out pHr);
        }

        #endregion
        #region String

        /// <summary>
        /// GetString is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public string String
        {
            get
            {
                HRESULT hr;
                string szStringResult;

                if ((hr = TryGetString(out szStringResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return szStringResult;
            }
        }

        /// <summary>
        /// GetString is obsolete. Do not call this method.
        /// </summary>
        [Obsolete]
        public HRESULT TryGetString(out string szStringResult)
        {
            /*HRESULT GetString([In] int cchString, out int pcchString, [Out] StringBuilder szString);*/
            int cchString = 0;
            int pcchString;
            StringBuilder szString = null;
            HRESULT hr = Raw.GetString(cchString, out pcchString, szString);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchString = pcchString;
            szString = new StringBuilder(pcchString);
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