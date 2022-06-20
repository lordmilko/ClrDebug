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
                string szNameResult;
                TryGetName(out szNameResult).ThrowOnNotOK();

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
                object pValue;
                TryGetValue(out pValue).ThrowOnNotOK();

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
        #region Signature

        /// <summary>
        /// Gets the signature of the constant.
        /// </summary>
        public byte[] Signature
        {
            get
            {
                byte[] sigResult;
                TryGetSignature(out sigResult).ThrowOnNotOK();

                return sigResult;
            }
        }

        /// <summary>
        /// Gets the signature of the constant.
        /// </summary>
        /// <param name="sigResult">[out] The buffer that stores the signature.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetSignature(out byte[] sigResult)
        {
            /*HRESULT GetSignature([In] int cSig, [Out] out int pcSig, [MarshalAs(UnmanagedType.LPArray), Out] byte[] sig);*/
            int cSig = 0;
            int pcSig;
            byte[] sig = null;
            HRESULT hr = Raw.GetSignature(cSig, out pcSig, sig);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cSig = pcSig;
            sig = new byte[pcSig];
            hr = Raw.GetSignature(cSig, out pcSig, sig);

            if (hr == HRESULT.S_OK)
            {
                sigResult = sig;

                return hr;
            }

            fail:
            sigResult = default(byte[]);

            return hr;
        }

        #endregion
        #endregion
    }
}