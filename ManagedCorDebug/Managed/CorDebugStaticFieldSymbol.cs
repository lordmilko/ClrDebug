using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents the debug symbol information for a static field.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICorDebugStaticFieldSymbol"/> interface is used to retrieve the debug symbol information for a static field.
    /// </remarks>
    public class CorDebugStaticFieldSymbol : ComObject<ICorDebugStaticFieldSymbol>
    {
        public CorDebugStaticFieldSymbol(ICorDebugStaticFieldSymbol raw) : base(raw)
        {
        }

        #region ICorDebugStaticFieldSymbol
        #region GetSize

        /// <summary>
        /// Gets the size in bytes of the static field.
        /// </summary>
        public int Size
        {
            get
            {
                HRESULT hr;
                int pcbSize;

                if ((hr = TryGetSize(out pcbSize)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pcbSize;
            }
        }

        /// <summary>
        /// Gets the size in bytes of the static field.
        /// </summary>
        /// <param name="pcbSize">[out] A pointer to length of the field.</param>
        public HRESULT TryGetSize(out int pcbSize)
        {
            /*HRESULT GetSize(out int pcbSize);*/
            return Raw.GetSize(out pcbSize);
        }

        #endregion
        #region GetAddress

        /// <summary>
        /// Gets the address of a static field.
        /// </summary>
        public long Address
        {
            get
            {
                HRESULT hr;
                long pRVA;

                if ((hr = TryGetAddress(out pRVA)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pRVA;
            }
        }

        /// <summary>
        /// Gets the address of a static field.
        /// </summary>
        /// <param name="pRVA">[out] A pointer to the relative virtual address (RVA) of the static field.</param>
        public HRESULT TryGetAddress(out long pRVA)
        {
            /*HRESULT GetAddress(out long pRVA);*/
            return Raw.GetAddress(out pRVA);
        }

        #endregion
        #region GetName

        /// <summary>
        /// Gets the name of the static field.
        /// </summary>
        /// <returns>[out] A character array that stores the returned name.</returns>
        public string GetName()
        {
            HRESULT hr;
            string szNameResult;

            if ((hr = TryGetName(out szNameResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szNameResult;
        }

        /// <summary>
        /// Gets the name of the static field.
        /// </summary>
        /// <param name="szNameResult">[out] A character array that stores the returned name.</param>
        public HRESULT TryGetName(out string szNameResult)
        {
            /*HRESULT GetName([In] int cchName, out int pcchName, [Out] StringBuilder szName);*/
            int cchName = 0;
            int pcchName;
            StringBuilder szName = null;
            HRESULT hr = Raw.GetName(cchName, out pcchName, szName);

            if (hr != HRESULT.S_FALSE)
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