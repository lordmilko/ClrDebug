using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a variable, such as a parameter, a local variable, or a field.
    /// </summary>
    public class SymUnmanagedVariable : ComObject<ISymUnmanagedVariable>
    {
        public SymUnmanagedVariable(ISymUnmanagedVariable raw) : base(raw)
        {
        }

        #region ISymUnmanagedVariable
        #region Attributes

        /// <summary>
        /// Gets the attribute flags for this variable.
        /// </summary>
        public CorSymVarFlag Attributes
        {
            get
            {
                HRESULT hr;
                CorSymVarFlag pRetVal;

                if ((hr = TryGetAttributes(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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
            /*HRESULT GetAttributes([Out] out CorSymVarFlag pRetVal);*/
            return Raw.GetAttributes(out pRetVal);
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
                HRESULT hr;
                CorSymAddrKind pRetVal;

                if ((hr = TryGetAddressKind(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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
            /*HRESULT GetAddressKind([Out] out CorSymAddrKind pRetVal);*/
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
                HRESULT hr;
                int pRetVal;

                if ((hr = TryGetAddressField1(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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
            /*HRESULT GetAddressField1([Out] out int pRetVal);*/
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
                HRESULT hr;
                int pRetVal;

                if ((hr = TryGetAddressField2(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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
            /*HRESULT GetAddressField2([Out] out int pRetVal);*/
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
                HRESULT hr;
                int pRetVal;

                if ((hr = TryGetAddressField3(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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
            /*HRESULT GetAddressField3([Out] out int pRetVal);*/
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
                HRESULT hr;
                int pRetVal;

                if ((hr = TryGetStartOffset(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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
            /*HRESULT GetStartOffset([Out] out int pRetVal);*/
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
                HRESULT hr;
                int pRetVal;

                if ((hr = TryGetEndOffset(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

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
            /*HRESULT GetEndOffset([Out] out int pRetVal);*/
            return Raw.GetEndOffset(out pRetVal);
        }

        #endregion
        #region GetName

        /// <summary>
        /// Gets the name of this variable.
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
        /// Gets the name of this variable.
        /// </summary>
        /// <param name="szNameResult">[out] The buffer that stores the name.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetName(out string szNameResult)
        {
            /*HRESULT GetName([In] int cchName, out int pcchName, [Out] StringBuilder szName);*/
            int cchName = 0;
            int pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetName(cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER)
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
        #region GetSignature

        /// <summary>
        /// Gets the signature of this variable.
        /// </summary>
        /// <param name="cSig">[in] The length of the buffer pointed to by the sig parameter.</param>
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
        /// Gets the signature of this variable.
        /// </summary>
        /// <param name="cSig">[in] The length of the buffer pointed to by the sig parameter.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetSignature(int cSig, out GetSignatureResult result)
        {
            /*HRESULT GetSignature([In] int cSig, out int pcSig, [MarshalAs(UnmanagedType.LPArray), Out] byte[] sig);*/
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