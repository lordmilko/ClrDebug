using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides access to unmanaged constants.
    /// </summary>
    public class SymUnmanagedConstant : ComObject<ISymUnmanagedConstant>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymUnmanagedConstant"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SymUnmanagedConstant(ISymUnmanagedConstant raw) : base(raw)
        {
        }

        #region ISymUnmanagedConstant
        #region Name

        /// <summary>
        /// Gets the name of the constant.
        /// </summary>
        public string Name
        {
            get
            {
                HRESULT hr;
                string szNameResult;

                if ((hr = TryGetName(out szNameResult)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return szNameResult;
            }
        }

        /// <summary>
        /// Gets the name of the constant.
        /// </summary>
        /// <param name="szNameResult">[out] The buffer that stores the name.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetName(out string szNameResult)
        {
            /*HRESULT GetName([In] int cchName, [Out] out int pcchName, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName);*/
            int cchName = 0;
            int pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetName(cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder(pcchName);
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
        #region Value

        /// <summary>
        /// Gets the value of the constant.
        /// </summary>
        public object Value
        {
            get
            {
                HRESULT hr;
                object pValue;

                if ((hr = TryGetValue(out pValue)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pValue;
            }
        }

        /// <summary>
        /// Gets the value of the constant.
        /// </summary>
        /// <param name="pValue">[out] A pointer to a variable that receives the value.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetValue(out object pValue)
        {
            /*HRESULT GetValue([Out, MarshalAs(UnmanagedType.Struct)] out object pValue);*/
            return Raw.GetValue(out pValue);
        }

        #endregion
        #region GetSignature

        /// <summary>
        /// Gets the signature of the constant.
        /// </summary>
        /// <param name="cSig">[in] The length of the buffer that the pcSig parameter points to.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetSignatureResult GetSignature(int cSig)
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
        public HRESULT TryGetSignature(int cSig, out GetSignatureResult result)
        {
            /*HRESULT GetSignature([In] int cSig, [Out] out int pcSig, [MarshalAs(UnmanagedType.LPArray), Out] byte[] sig);*/
            int pcSig;
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