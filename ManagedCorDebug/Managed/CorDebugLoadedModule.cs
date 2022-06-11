using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class CorDebugLoadedModule : ComObject<ICorDebugLoadedModule>
    {
        public CorDebugLoadedModule(ICorDebugLoadedModule raw) : base(raw)
        {
        }

        #region ICorDebugLoadedModule
        #region GetBaseAddress

        public ulong BaseAddress
        {
            get
            {
                HRESULT hr;
                ulong pAddress;

                if ((hr = TryGetBaseAddress(out pAddress)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pAddress;
            }
        }

        public HRESULT TryGetBaseAddress(out ulong pAddress)
        {
            /*HRESULT GetBaseAddress(out ulong pAddress);*/
            return Raw.GetBaseAddress(out pAddress);
        }

        #endregion
        #region GetSize

        public uint Size
        {
            get
            {
                HRESULT hr;
                uint pcBytes;

                if ((hr = TryGetSize(out pcBytes)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pcBytes;
            }
        }

        public HRESULT TryGetSize(out uint pcBytes)
        {
            /*HRESULT GetSize(out uint pcBytes);*/
            return Raw.GetSize(out pcBytes);
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