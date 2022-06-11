using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class CorDebugStringValue : CorDebugHeapValue
    {
        public CorDebugStringValue(ICorDebugStringValue raw) : base(raw)
        {
        }

        #region ICorDebugStringValue

        public new ICorDebugStringValue Raw => (ICorDebugStringValue) base.Raw;

        #region GetLength

        public uint Length
        {
            get
            {
                HRESULT hr;
                uint pcchString;

                if ((hr = TryGetLength(out pcchString)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pcchString;
            }
        }

        public HRESULT TryGetLength(out uint pcchString)
        {
            /*HRESULT GetLength(out uint pcchString);*/
            return Raw.GetLength(out pcchString);
        }

        #endregion
        #region GetString

        public string GetString()
        {
            HRESULT hr;
            string szStringResult;

            if ((hr = TryGetString(out szStringResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szStringResult;
        }

        public HRESULT TryGetString(out string szStringResult)
        {
            /*HRESULT GetString([In] uint cchString, out uint pcchString, [Out] StringBuilder szString);*/
            uint cchString = 0;
            uint pcchString;
            StringBuilder szString = null;
            HRESULT hr = Raw.GetString(cchString, out pcchString, szString);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchString = pcchString;
            szString = new StringBuilder((int) pcchString);
            hr = Raw.GetString(cchString, out pcchString, szString);

            if (hr == HRESULT.S_OK)
            {
                szStringResult = szString.ToString();

                return hr;
            }

            fail:
            szStringResult = default(string);

            return hr;
        }

        #endregion
        #endregion
    }
}