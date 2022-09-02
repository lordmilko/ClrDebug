using System.Text;

namespace ClrDebug
{
    /// <summary>
    /// Represents a variable, such as a parameter, a local variable, or a field.
    /// </summary>
    public class SymUnmanagedVariable : ComObject<ISymUnmanagedVariable>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymUnmanagedVariable"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SymUnmanagedVariable(ISymUnmanagedVariable raw) : base(raw)
        {
        }

        #region ISymUnmanagedVariable
        #region Name

        /// <summary>
        /// Gets the name of this variable.
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
        /// Gets the name of this variable.
        /// </summary>
        /// <param name="szNameResult">[out] The buffer that stores the name.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetName(out string szNameResult)
        {
            /*HRESULT GetName(
            [In] int cchName,
            [Out] out int pcchName,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName);*/
            int cchName = 0;
            int pcchName;
            StringBuilder szName;
            HRESULT hr = Raw.GetName(cchName, out pcchName, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder(cchName);
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
        #region Attributes

        /// <summary>
        /// Gets the attribute flags for this variable.
        /// </summary>
        public CorSymVarFlag Attributes
        {
            get
            {
                CorSymVarFlag pRetVal;
                TryGetAttributes(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Gets the attribute flags for this variable.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the attributes. The returned value will be one of the values defined in the <see cref="CorSymVarFlag"/> enumeration.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetAttributes(out CorSymVarFlag pRetVal)
        {
            /*HRESULT GetAttributes(
            [Out] out CorSymVarFlag pRetVal);*/
            return Raw.GetAttributes(out pRetVal);
        }

        #endregion
        #region Signature

        /// <summary>
        /// Gets the signature of this variable.
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
        /// Gets the signature of this variable.
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
        #region AddressKind

        /// <summary>
        /// Gets the kind of address of this variable.
        /// </summary>
        public CorSymAddrKind AddressKind
        {
            get
            {
                CorSymAddrKind pRetVal;
                TryGetAddressKind(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Gets the kind of address of this variable.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the value. The possible values are defined in the <see cref="CorSymAddrKind"/> enumeration.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetAddressKind(out CorSymAddrKind pRetVal)
        {
            /*HRESULT GetAddressKind(
            [Out] out CorSymAddrKind pRetVal);*/
            return Raw.GetAddressKind(out pRetVal);
        }

        #endregion
        #region AddressField1

        /// <summary>
        /// Gets the first address field for this variable. Its meaning depends on the kind of address.
        /// </summary>
        public int AddressField1
        {
            get
            {
                int pRetVal;
                TryGetAddressField1(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Gets the first address field for this variable. Its meaning depends on the kind of address.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the first address field.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetAddressField1(out int pRetVal)
        {
            /*HRESULT GetAddressField1(
            [Out] out int pRetVal);*/
            return Raw.GetAddressField1(out pRetVal);
        }

        #endregion
        #region AddressField2

        /// <summary>
        /// Gets the second address field for this variable. Its meaning depends on the kind of address.
        /// </summary>
        public int AddressField2
        {
            get
            {
                int pRetVal;
                TryGetAddressField2(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Gets the second address field for this variable. Its meaning depends on the kind of address.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the second address field.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetAddressField2(out int pRetVal)
        {
            /*HRESULT GetAddressField2(
            [Out] out int pRetVal);*/
            return Raw.GetAddressField2(out pRetVal);
        }

        #endregion
        #region AddressField3

        /// <summary>
        /// Gets the third address field for this variable. Its meaning depends on the kind of address.
        /// </summary>
        public int AddressField3
        {
            get
            {
                int pRetVal;
                TryGetAddressField3(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Gets the third address field for this variable. Its meaning depends on the kind of address.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the third address field.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetAddressField3(out int pRetVal)
        {
            /*HRESULT GetAddressField3(
            [Out] out int pRetVal);*/
            return Raw.GetAddressField3(out pRetVal);
        }

        #endregion
        #region StartOffset

        /// <summary>
        /// Gets the start offset of this variable within its parent. If this is a local variable within a scope, the start offset will fall within the offsets defined for the scope.
        /// </summary>
        public int StartOffset
        {
            get
            {
                int pRetVal;
                TryGetStartOffset(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Gets the start offset of this variable within its parent. If this is a local variable within a scope, the start offset will fall within the offsets defined for the scope.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the start offset.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetStartOffset(out int pRetVal)
        {
            /*HRESULT GetStartOffset(
            [Out] out int pRetVal);*/
            return Raw.GetStartOffset(out pRetVal);
        }

        #endregion
        #region EndOffset

        /// <summary>
        /// Gets the end offset of this variable within its parent. If this is a local variable within a scope, the end offset will fall within the offsets defined for the scope.
        /// </summary>
        public int EndOffset
        {
            get
            {
                int pRetVal;
                TryGetEndOffset(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Gets the end offset of this variable within its parent. If this is a local variable within a scope, the end offset will fall within the offsets defined for the scope.
        /// </summary>
        /// <param name="pRetVal">[out] A pointer to a ULONG32 that receives the end offset.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetEndOffset(out int pRetVal)
        {
            /*HRESULT GetEndOffset(
            [Out] out int pRetVal);*/
            return Raw.GetEndOffset(out pRetVal);
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
