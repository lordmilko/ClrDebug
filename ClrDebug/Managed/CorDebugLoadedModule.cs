using System.Text;

namespace ClrDebug
{
    /// <summary>
    /// Provides information about a loaded module.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICorDebugLoadedModule"/> interface is implemented by a debugger and is used by the CLR debugging interfaces to
    /// get information about the loaded module from the debugger.
    /// </remarks>
    public class CorDebugLoadedModule : ComObject<ICorDebugLoadedModule>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugLoadedModule"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugLoadedModule(ICorDebugLoadedModule raw) : base(raw)
        {
        }

        #region ICorDebugLoadedModule
        #region BaseAddress

        /// <summary>
        /// Gets the base address of the loaded module.
        /// </summary>
        public CORDB_ADDRESS BaseAddress
        {
            get
            {
                CORDB_ADDRESS pAddress;
                TryGetBaseAddress(out pAddress).ThrowOnNotOK();

                return pAddress;
            }
        }

        /// <summary>
        /// Gets the base address of the loaded module.
        /// </summary>
        /// <param name="pAddress">[out] A pointer to the base address of the loaded module.</param>
        public HRESULT TryGetBaseAddress(out CORDB_ADDRESS pAddress)
        {
            /*HRESULT GetBaseAddress([Out] out CORDB_ADDRESS pAddress);*/
            return Raw.GetBaseAddress(out pAddress);
        }

        #endregion
        #region Name

        /// <summary>
        /// Gets the name of the loaded module.
        /// </summary>
        public string Name
        {
            get
            {
                string szNameResult;
                TryGetName(out szNameResult).ThrowOnNotOK();

                return szNameResult;
            }
        }

        /// <summary>
        /// Gets the name of the loaded module.
        /// </summary>
        /// <param name="szNameResult">[out] An array of characters that contain the name of the loaded module.</param>
        public HRESULT TryGetName(out string szNameResult)
        {
            /*HRESULT GetName([In] int cchName, [Out] out int pcchName, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName);*/
            int cchName = 0;
            int pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetName(cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder(pcchName);
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
        #region Size

        /// <summary>
        /// Gets the size in bytes of the loaded module.
        /// </summary>
        public int Size
        {
            get
            {
                int pcBytes;
                TryGetSize(out pcBytes).ThrowOnNotOK();

                return pcBytes;
            }
        }

        /// <summary>
        /// Gets the size in bytes of the loaded module.
        /// </summary>
        /// <param name="pcBytes">[out] A pointer to the number of bytes in the loaded module.</param>
        public HRESULT TryGetSize(out int pcBytes)
        {
            /*HRESULT GetSize([Out] out int pcBytes);*/
            return Raw.GetSize(out pcBytes);
        }

        #endregion
        #endregion
    }
}