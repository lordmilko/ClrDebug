using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class CorDebugMergedAssemblyRecord : ComObject<ICorDebugMergedAssemblyRecord>
    {
        public CorDebugMergedAssemblyRecord(ICorDebugMergedAssemblyRecord raw) : base(raw)
        {
        }

        #region ICorDebugMergedAssemblyRecord
        #region GetVersion

        public GetVersionResult Version
        {
            get
            {
                HRESULT hr;
                GetVersionResult result;

                if ((hr = TryGetVersion(out result)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return result;
            }
        }

        public HRESULT TryGetVersion(out GetVersionResult result)
        {
            /*HRESULT GetVersion(out ushort pMajor, out ushort pMinor, out ushort pBuild, out ushort pRevision);*/
            ushort pMajor;
            ushort pMinor;
            ushort pBuild;
            ushort pRevision;
            HRESULT hr = Raw.GetVersion(out pMajor, out pMinor, out pBuild, out pRevision);

            if (hr == HRESULT.S_OK)
                result = new GetVersionResult(pMajor, pMinor, pBuild, pRevision);
            else
                result = default(GetVersionResult);

            return hr;
        }

        #endregion
        #region GetIndex

        public uint Index
        {
            get
            {
                HRESULT hr;
                uint pIndex;

                if ((hr = TryGetIndex(out pIndex)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pIndex;
            }
        }

        public HRESULT TryGetIndex(out uint pIndex)
        {
            /*HRESULT GetIndex(out uint pIndex);*/
            return Raw.GetIndex(out pIndex);
        }

        #endregion
        #region GetSimpleName

        public string GetSimpleName()
        {
            HRESULT hr;
            string szNameResult;

            if ((hr = TryGetSimpleName(out szNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szNameResult;
        }

        public HRESULT TryGetSimpleName(out string szNameResult)
        {
            /*HRESULT GetSimpleName([In] uint cchName, out uint pcchName, [Out] StringBuilder szName);*/
            uint cchName = 0;
            uint pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetSimpleName(cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder((int) pcchName);
            hr = Raw.GetSimpleName(cchName, out pcchName, szName);

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
        #region GetCulture

        public string GetCulture()
        {
            HRESULT hr;
            string szCultureResult;

            if ((hr = TryGetCulture(out szCultureResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szCultureResult;
        }

        public HRESULT TryGetCulture(out string szCultureResult)
        {
            /*HRESULT GetCulture([In] uint cchCulture, out uint pcchCulture, [Out] StringBuilder szCulture);*/
            uint cchCulture = 0;
            uint pcchCulture;
            StringBuilder szCulture = null;
            HRESULT hr = Raw.GetCulture(cchCulture, out pcchCulture, szCulture);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchCulture = pcchCulture;
            szCulture = new StringBuilder((int) pcchCulture);
            hr = Raw.GetCulture(cchCulture, out pcchCulture, szCulture);

            if (hr == HRESULT.S_OK)
            {
                szCultureResult = szCulture.ToString();

                return hr;
            }

            fail:
            szCultureResult = default(string);

            return hr;
        }

        #endregion
        #region GetPublicKey

        public GetPublicKeyResult GetPublicKey(uint cbPublicKey)
        {
            HRESULT hr;
            GetPublicKeyResult result;

            if ((hr = TryGetPublicKey(cbPublicKey, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetPublicKey(uint cbPublicKey, out GetPublicKeyResult result)
        {
            /*HRESULT GetPublicKey(
            [In] uint cbPublicKey,
            out uint pcbPublicKey,
            [MarshalAs(UnmanagedType.LPArray), Out]
            byte[] pbPublicKey);*/
            uint pcbPublicKey;
            byte[] pbPublicKey = null;
            HRESULT hr = Raw.GetPublicKey(cbPublicKey, out pcbPublicKey, pbPublicKey);

            if (hr == HRESULT.S_OK)
                result = new GetPublicKeyResult(pcbPublicKey, pbPublicKey);
            else
                result = default(GetPublicKeyResult);

            return hr;
        }

        #endregion
        #region GetPublicKeyToken

        public GetPublicKeyTokenResult GetPublicKeyToken(uint cbPublicKeyToken)
        {
            HRESULT hr;
            GetPublicKeyTokenResult result;

            if ((hr = TryGetPublicKeyToken(cbPublicKeyToken, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetPublicKeyToken(uint cbPublicKeyToken, out GetPublicKeyTokenResult result)
        {
            /*HRESULT GetPublicKeyToken(
            [In] uint cbPublicKeyToken,
            out uint pcbPublicKeyToken,
            [MarshalAs(UnmanagedType.LPArray), Out]
            byte[] pbPublicKeyToken);*/
            uint pcbPublicKeyToken;
            byte[] pbPublicKeyToken = null;
            HRESULT hr = Raw.GetPublicKeyToken(cbPublicKeyToken, out pcbPublicKeyToken, pbPublicKeyToken);

            if (hr == HRESULT.S_OK)
                result = new GetPublicKeyTokenResult(pcbPublicKeyToken, pbPublicKeyToken);
            else
                result = default(GetPublicKeyTokenResult);

            return hr;
        }

        #endregion
        #endregion
    }
}