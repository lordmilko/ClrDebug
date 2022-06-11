using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class CorDebugStaticFieldSymbol : ComObject<ICorDebugStaticFieldSymbol>
    {
        public CorDebugStaticFieldSymbol(ICorDebugStaticFieldSymbol raw) : base(raw)
        {
        }

        #region ICorDebugStaticFieldSymbol
        #region GetSize

        public uint Size
        {
            get
            {
                HRESULT hr;
                uint pcbSize;

                if ((hr = TryGetSize(out pcbSize)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pcbSize;
            }
        }

        public HRESULT TryGetSize(out uint pcbSize)
        {
            /*HRESULT GetSize(out uint pcbSize);*/
            return Raw.GetSize(out pcbSize);
        }

        #endregion
        #region GetAddress

        public ulong Address
        {
            get
            {
                HRESULT hr;
                ulong pRVA;

                if ((hr = TryGetAddress(out pRVA)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pRVA;
            }
        }

        public HRESULT TryGetAddress(out ulong pRVA)
        {
            /*HRESULT GetAddress(out ulong pRVA);*/
            return Raw.GetAddress(out pRVA);
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
        #endregion
    }
}