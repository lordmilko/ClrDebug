using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class SymUnmanagedSymbolSearchInfo : ComObject<ISymUnmanagedSymbolSearchInfo>
    {
        public SymUnmanagedSymbolSearchInfo(ISymUnmanagedSymbolSearchInfo raw) : base(raw)
        {
        }

        #region ISymUnmanagedSymbolSearchInfo
        #region GetSearchPathLength

        public uint SearchPathLength
        {
            get
            {
                HRESULT hr;
                uint pcchPath;

                if ((hr = TryGetSearchPathLength(out pcchPath)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pcchPath;
            }
        }

        public HRESULT TryGetSearchPathLength(out uint pcchPath)
        {
            /*HRESULT GetSearchPathLength(out uint pcchPath);*/
            return Raw.GetSearchPathLength(out pcchPath);
        }

        #endregion
        #region GetHRESULT

        public HRESULT HRESULT
        {
            get
            {
                HRESULT hr;
                HRESULT phr;

                if ((hr = TryGetHRESULT(out phr)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return phr;
            }
        }

        public HRESULT TryGetHRESULT(out HRESULT phr)
        {
            /*HRESULT GetHRESULT([MarshalAs(UnmanagedType.Error)] out HRESULT phr);*/
            return Raw.GetHRESULT(out phr);
        }

        #endregion
        #region GetSearchPath

        public string GetSearchPath()
        {
            HRESULT hr;
            string szPathResult;

            if ((hr = TryGetSearchPath(out szPathResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szPathResult;
        }

        public HRESULT TryGetSearchPath(out string szPathResult)
        {
            /*HRESULT GetSearchPath(
            [In] uint cchPath,
            out uint pcchPath,
            [Out] StringBuilder szPath);*/
            uint cchPath = 0;
            uint pcchPath;
            StringBuilder szPath = null;
            HRESULT hr = Raw.GetSearchPath(cchPath, out pcchPath, szPath);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchPath = pcchPath;
            szPath = new StringBuilder((int) pcchPath);
            hr = Raw.GetSearchPath(cchPath, out pcchPath, szPath);

            if (hr == HRESULT.S_OK)
            {
                szPathResult = szPath.ToString();

                return hr;
            }

            fail:
            szPathResult = default(string);

            return hr;
        }

        #endregion
        #endregion
    }
}