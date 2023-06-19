using static ClrDebug.Extensions;

namespace ClrDebug
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
            /*HRESULT GetName(
            [In] int cchName,
            [Out] out int pcchName,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] szName);*/
            int cchName = 0;
            int pcchName;
            char[] szName;
            HRESULT hr = Raw.GetName(cchName, out pcchName, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pcchName;
            szName = new char[cchName];
            hr = Raw.GetName(cchName, out pcchName, szName);

            if (hr == HRESULT.S_OK)
            {
                szNameResult = CreateString(szName, pcchName);

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
            /*HRESULT GetValue(
            [Out, MarshalAs(UnmanagedType.Struct)] out object pValue);*/
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
                byte[] sig;
                TryGetSignature(out sig).ThrowOnNotOK();

                return sig;
            }
        }

        /// <summary>
        /// Gets the signature of the constant.
        /// </summary>
        /// <param name="sig">[out] The buffer that stores the signature.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetSignature(out byte[] sig)
        {
            /*HRESULT GetSignature(
            [In] int cSig,
            [Out] out int pcSig,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0), Out] byte[] sig);*/
            int cSig = 0;
            int pcSig;
            sig = null;
            HRESULT hr = Raw.GetSignature(cSig, out pcSig, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cSig = pcSig;
            sig = new byte[cSig];
            hr = Raw.GetSignature(cSig, out pcSig, sig);
            fail:
            return hr;
        }

        #endregion
        #endregion
        
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
