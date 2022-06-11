using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class CorDebugInstanceFieldSymbol : ComObject<ICorDebugInstanceFieldSymbol>
    {
        public CorDebugInstanceFieldSymbol(ICorDebugInstanceFieldSymbol raw) : base(raw)
        {
        }

        #region ICorDebugInstanceFieldSymbol
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
        #region GetOffset

        public uint Offset
        {
            get
            {
                HRESULT hr;
                uint pcbOffset;

                if ((hr = TryGetOffset(out pcbOffset)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pcbOffset;
            }
        }

        public HRESULT TryGetOffset(out uint pcbOffset)
        {
            /*HRESULT GetOffset(out uint pcbOffset);*/
            return Raw.GetOffset(out pcbOffset);
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