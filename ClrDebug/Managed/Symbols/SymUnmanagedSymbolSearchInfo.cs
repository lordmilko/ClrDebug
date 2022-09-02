using System.Text;

namespace ClrDebug
{
    /// <summary>
    /// Provides methods that get information about the search path. Obtain this interface by calling QueryInterface on an object that implements the <see cref="ISymUnmanagedReader"/> interface.
    /// </summary>
    public class SymUnmanagedSymbolSearchInfo : ComObject<ISymUnmanagedSymbolSearchInfo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymUnmanagedSymbolSearchInfo"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SymUnmanagedSymbolSearchInfo(ISymUnmanagedSymbolSearchInfo raw) : base(raw)
        {
        }

        #region ISymUnmanagedSymbolSearchInfo
        #region SearchPathLength

        /// <summary>
        /// Gets the search path length.
        /// </summary>
        public int SearchPathLength
        {
            get
            {
                int pcchPath;
                TryGetSearchPathLength(out pcchPath).ThrowOnNotOK();

                return pcchPath;
            }
        }

        /// <summary>
        /// Gets the search path length.
        /// </summary>
        /// <param name="pcchPath">[out] A pointer to a ULONG32 that receives the size, in characters, of the buffer required to contain the search path length.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetSearchPathLength(out int pcchPath)
        {
            /*HRESULT GetSearchPathLength(
            [Out] out int pcchPath);*/
            return Raw.GetSearchPathLength(out pcchPath);
        }

        #endregion
        #region SearchPath

        /// <summary>
        /// Gets the search path.
        /// </summary>
        public string SearchPath
        {
            get
            {
                string szPathResult;
                TryGetSearchPath(out szPathResult).ThrowOnNotOK();

                return szPathResult;
            }
        }

        /// <summary>
        /// Gets the search path.
        /// </summary>
        /// <param name="szPathResult">[out] A buffer to hold the search path.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetSearchPath(out string szPathResult)
        {
            /*HRESULT GetSearchPath(
            [In] int cchPath,
            [Out] out int pcchPath,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szPath);*/
            int cchPath = 0;
            int pcchPath;
            StringBuilder szPath;
            HRESULT hr = Raw.GetSearchPath(cchPath, out pcchPath, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchPath = pcchPath;
            szPath = new StringBuilder(cchPath);
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
        #region HRESULT

        /// <summary>
        /// Gets the <see cref="HRESULT"/>.
        /// </summary>
        public HRESULT HRESULT
        {
            get
            {
                HRESULT phr;
                TryGetHRESULT(out phr).ThrowOnNotOK();

                return phr;
            }
        }

        /// <summary>
        /// Gets the <see cref="HRESULT"/>.
        /// </summary>
        /// <param name="phr">[out] A pointer to the <see cref="HRESULT"/>.</param>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryGetHRESULT(out HRESULT phr)
        {
            /*HRESULT GetHRESULT(
            [Out, MarshalAs(UnmanagedType.Error)] out HRESULT phr);*/
            return Raw.GetHRESULT(out phr);
        }

        #endregion
        #endregion
    }
}
