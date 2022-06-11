using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class SymUnmanagedConstant : ComObject<ISymUnmanagedConstant>
    {
        public SymUnmanagedConstant(ISymUnmanagedConstant raw) : base(raw)
        {
        }

        #region ISymUnmanagedConstant
        #region GetValue

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

        public HRESULT TryGetValue(ref object pValue)
        {
            /*HRESULT GetValue([MarshalAs(UnmanagedType.Struct)] ref object pValue);*/
            return Raw.GetValue(ref pValue);
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