using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class SymUnmanagedVariable : ComObject<ISymUnmanagedVariable>
    {
        public SymUnmanagedVariable(ISymUnmanagedVariable raw) : base(raw)
        {
        }

        #region ISymUnmanagedVariable
        #region GetAttributes

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

        public HRESULT TryGetAttributes(out CorSymVarFlag pRetVal)
        {
            /*HRESULT GetAttributes([Out] out CorSymVarFlag pRetVal);*/
            return Raw.GetAttributes(out pRetVal);
        }

        #endregion
        #region GetAddressKind

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

        public HRESULT TryGetAddressKind(out CorSymAddrKind pRetVal)
        {
            /*HRESULT GetAddressKind([Out] out CorSymAddrKind pRetVal);*/
            return Raw.GetAddressKind(out pRetVal);
        }

        #endregion
        #region GetAddressField1

        public uint AddressField1
        {
            get
            {
                HRESULT hr;
                uint pRetVal;

                if ((hr = TryGetAddressField1(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pRetVal;
            }
        }

        public HRESULT TryGetAddressField1(out uint pRetVal)
        {
            /*HRESULT GetAddressField1([Out] out uint pRetVal);*/
            return Raw.GetAddressField1(out pRetVal);
        }

        #endregion
        #region GetAddressField2

        public uint AddressField2
        {
            get
            {
                HRESULT hr;
                uint pRetVal;

                if ((hr = TryGetAddressField2(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pRetVal;
            }
        }

        public HRESULT TryGetAddressField2(out uint pRetVal)
        {
            /*HRESULT GetAddressField2([Out] out uint pRetVal);*/
            return Raw.GetAddressField2(out pRetVal);
        }

        #endregion
        #region GetAddressField3

        public uint AddressField3
        {
            get
            {
                HRESULT hr;
                uint pRetVal;

                if ((hr = TryGetAddressField3(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pRetVal;
            }
        }

        public HRESULT TryGetAddressField3(out uint pRetVal)
        {
            /*HRESULT GetAddressField3([Out] out uint pRetVal);*/
            return Raw.GetAddressField3(out pRetVal);
        }

        #endregion
        #region GetStartOffset

        public uint StartOffset
        {
            get
            {
                HRESULT hr;
                uint pRetVal;

                if ((hr = TryGetStartOffset(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pRetVal;
            }
        }

        public HRESULT TryGetStartOffset(out uint pRetVal)
        {
            /*HRESULT GetStartOffset([Out] out uint pRetVal);*/
            return Raw.GetStartOffset(out pRetVal);
        }

        #endregion
        #region GetEndOffset

        public uint EndOffset
        {
            get
            {
                HRESULT hr;
                uint pRetVal;

                if ((hr = TryGetEndOffset(out pRetVal)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pRetVal;
            }
        }

        public HRESULT TryGetEndOffset(out uint pRetVal)
        {
            /*HRESULT GetEndOffset([Out] out uint pRetVal);*/
            return Raw.GetEndOffset(out pRetVal);
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
        #region GetSignature

        public GetSignatureResult GetSignature(uint cSig)
        {
            HRESULT hr;
            GetSignatureResult result;

            if ((hr = TryGetSignature(cSig, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

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