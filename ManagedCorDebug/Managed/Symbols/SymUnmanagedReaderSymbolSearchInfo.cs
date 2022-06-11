using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class SymUnmanagedReaderSymbolSearchInfo : ComObject<ISymUnmanagedReaderSymbolSearchInfo>
    {
        public SymUnmanagedReaderSymbolSearchInfo(ISymUnmanagedReaderSymbolSearchInfo raw) : base(raw)
        {
        }

        #region ISymUnmanagedReaderSymbolSearchInfo
        #region GetSymbolSearchInfoCount

        public uint SymbolSearchInfoCount
        {
            get
            {
                HRESULT hr;
                uint pcSearchInfo;

                if ((hr = TryGetSymbolSearchInfoCount(out pcSearchInfo)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pcSearchInfo;
            }
        }

        public HRESULT TryGetSymbolSearchInfoCount(out uint pcSearchInfo)
        {
            /*HRESULT GetSymbolSearchInfoCount(out uint pcSearchInfo);*/
            return Raw.GetSymbolSearchInfoCount(out pcSearchInfo);
        }

        #endregion
        #region GetSymbolSearchInfo

        public GetSymbolSearchInfoResult GetSymbolSearchInfo(uint cSearchInfo)
        {
            HRESULT hr;
            GetSymbolSearchInfoResult result;

            if ((hr = TryGetSymbolSearchInfo(cSearchInfo, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetSymbolSearchInfo(uint cSearchInfo, out GetSymbolSearchInfoResult result)
        {
            /*HRESULT GetSymbolSearchInfo(
            [In] uint cSearchInfo,
            out uint pcSearchInfo,
            [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedSymbolSearchInfo rgpSearchInfo);*/
            uint pcSearchInfo;
            ISymUnmanagedSymbolSearchInfo rgpSearchInfo;
            HRESULT hr = Raw.GetSymbolSearchInfo(cSearchInfo, out pcSearchInfo, out rgpSearchInfo);

            if (hr == HRESULT.S_OK)
                result = new GetSymbolSearchInfoResult(pcSearchInfo, new SymUnmanagedSymbolSearchInfo(rgpSearchInfo));
            else
                result = default(GetSymbolSearchInfoResult);

            return hr;
        }

        #endregion
        #endregion
    }
}