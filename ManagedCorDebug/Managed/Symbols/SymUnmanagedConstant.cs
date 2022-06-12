using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides access to unmanaged constants.
    /// </summary>
    public class SymUnmanagedConstant : ComObject<ISymUnmanagedConstant>
    {
        public SymUnmanagedConstant(ISymUnmanagedConstant raw) : base(raw)
        {
        }

        #region ISymUnmanagedConstant
        #region GetValue

        /// <summary>
        /// Gets the value of the constant.
        /// </summary>
        public object Value
        {
            get
            {
                HRESULT hr;
                object pValue = default(object);

                if ((hr = TryGetValue(ref pValue)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pValue;
            }
        }

        /// <summary>
        /// Gets the value of the constant.
        /// </summary>
        /// <param name="pValue">[out] A pointer to a variable that receives the value.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetValue(ref object pValue)
        {
            /*HRESULT GetValue([MarshalAs(UnmanagedType.Struct)] ref object pValue);*/
            return Raw.GetValue(ref pValue);
        }

        #endregion
        #region GetName

        /// <summary>
        /// Gets the name of the constant.
        /// </summary>
        /// <returns>[out] The buffer that stores the name.</returns>
        public string GetName()
        {
            HRESULT hr;
            string szNameResult;

            if ((hr = TryGetName(out szNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szNameResult;
        }

        /// <summary>
        /// Gets the name of the constant.
        /// </summary>
        /// <param name="szNameResult">[out] The buffer that stores the name.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
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
        #region GetSignature

        /// <summary>
        /// Gets the signature of the constant.
        /// </summary>
        /// <param name="cSig">[in] The length of the buffer that the pcSig parameter points to.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetSignatureResult GetSignature(uint cSig)
        {
            HRESULT hr;
            GetSignatureResult result;

            if ((hr = TryGetSignature(cSig, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets the signature of the constant.
        /// </summary>
        /// <param name="cSig">[in] The length of the buffer that the pcSig parameter points to.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetSignature(uint cSig, out GetSignatureResult result)
        {
            /*HRESULT GetSignature([In] uint cSig, out uint pcSig, [MarshalAs(UnmanagedType.LPArray), Out] byte[] sig);*/
            uint pcSig;
            byte[] sig = null;
            HRESULT hr = Raw.GetSignature(cSig, out pcSig, sig);

            if (hr == HRESULT.S_OK)
                result = new GetSignatureResult(pcSig, sig);
            else
                result = default(GetSignatureResult);

            return hr;
        }

        #endregion
        #endregion
    }
}