using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Provides methods that get symbol search information. Obtain this interface by calling QueryInterface on an object that implements the <see cref="ISymUnmanagedReader"/> interface.
    /// </summary>
    public class SymUnmanagedReaderSymbolSearchInfo : ComObject<ISymUnmanagedReaderSymbolSearchInfo>
    {
        public SymUnmanagedReaderSymbolSearchInfo(ISymUnmanagedReaderSymbolSearchInfo raw) : base(raw)
        {
        }

        #region ISymUnmanagedReaderSymbolSearchInfo
        #region GetSymbolSearchInfoCount

        /// <summary>
        /// Gets a count of symbol search information.
        /// </summary>
        public int SymbolSearchInfoCount
        {
            get
            {
                HRESULT hr;
                int pcSearchInfo;

                if ((hr = TryGetSymbolSearchInfoCount(out pcSearchInfo)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pcSearchInfo;
            }
        }

        /// <summary>
        /// Gets a count of symbol search information.
        /// </summary>
        /// <param name="pcSearchInfo">]out] A pointer to a ULONG32 that receives the size of the buffer required to contain the search information.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetSymbolSearchInfoCount(out int pcSearchInfo)
        {
            /*HRESULT GetSymbolSearchInfoCount(out int pcSearchInfo);*/
            return Raw.GetSymbolSearchInfoCount(out pcSearchInfo);
        }

        #endregion
        #region GetSymbolSearchInfo

        /// <summary>
        /// Gets symbol search information.
        /// </summary>
        /// <param name="cSearchInfo">[in] A ULONG32 that indicates the size of rgpSearchInfo.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetSymbolSearchInfoResult GetSymbolSearchInfo(int cSearchInfo)
        {
            HRESULT hr;
            GetSymbolSearchInfoResult result;

            if ((hr = TryGetSymbolSearchInfo(cSearchInfo, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        /// <summary>
        /// Gets symbol search information.
        /// </summary>
        /// <param name="cSearchInfo">[in] A ULONG32 that indicates the size of rgpSearchInfo.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetSymbolSearchInfo(int cSearchInfo, out GetSymbolSearchInfoResult result)
        {
            /*HRESULT GetSymbolSearchInfo(
            [In] int cSearchInfo,
            out int pcSearchInfo,
            [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedSymbolSearchInfo rgpSearchInfo);*/
            int pcSearchInfo;
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