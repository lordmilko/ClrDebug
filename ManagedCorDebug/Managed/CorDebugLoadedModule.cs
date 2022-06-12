using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
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
                HRESULT hr;
                CORDB_ADDRESS pAddress;

                if ((hr = TryGetBaseAddress(out pAddress)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pAddress;
            }
        }

        /// <summary>
        /// Gets the base address of the loaded module.
        /// </summary>
        /// <param name="pAddress">[out] A pointer to the base address of the loaded module.</param>
        public HRESULT TryGetBaseAddress(out CORDB_ADDRESS pAddress)
        {
            /*HRESULT GetBaseAddress(out CORDB_ADDRESS pAddress);*/
            return Raw.GetBaseAddress(out pAddress);
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
                HRESULT hr;
                int pcBytes;

                if ((hr = TryGetSize(out pcBytes)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pcBytes;
            }
        }

        /// <summary>
        /// Gets the size in bytes of the loaded module.
        /// </summary>
        /// <param name="pcBytes">[out] A pointer to the number of bytes in the loaded module.</param>
        public HRESULT TryGetSize(out int pcBytes)
        {
            /*HRESULT GetSize(out int pcBytes);*/
            return Raw.GetSize(out pcBytes);
        }

        #endregion
        #region GetName

        /// <summary>
        /// Gets the name of the loaded module.
        /// </summary>
        /// <returns>[out] An array of characters that contain the name of the loaded module.</returns>
        public string GetName()
        {
            HRESULT hr;
            string szNameResult;

            if ((hr = TryGetName(out szNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szNameResult;
        }

        /// <summary>
        /// Gets the name of the loaded module.
        /// </summary>
        /// <param name="szNameResult">[out] An array of characters that contain the name of the loaded module.</param>
        public HRESULT TryGetName(out string szNameResult)
        {
            /*HRESULT GetName([In] int cchName, out int pcchName, [Out] StringBuilder szName);*/
            int cchName = 0;
            int pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetName(cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER)
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
        #endregion
    }
}