using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    /// <summary>
    /// A subclass of <see cref="ICorDebugHeapValue"/> that applies to string values.
    /// </summary>
    public class CorDebugStringValue : CorDebugHeapValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugStringValue"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugStringValue(ICorDebugStringValue raw) : base(raw)
        {
        }

        #region ICorDebugStringValue

        public new ICorDebugStringValue Raw => (ICorDebugStringValue) base.Raw;

        #region Length

        /// <summary>
        /// Gets the number of characters in the string referenced by this <see cref="ICorDebugStringValue"/>.
        /// </summary>
        public int Length
        {
            get
            {
                HRESULT hr;
                int pcchString;

                if ((hr = TryGetLength(out pcchString)) != HRESULT.S_OK)
                    Marshal.ThrowExceptionForHR((int) hr);

                return pcchString;
            }
        }

        /// <summary>
        /// Gets the number of characters in the string referenced by this <see cref="ICorDebugStringValue"/>.
        /// </summary>
        /// <param name="pcchString">[out] A pointer to a value that specifies the length of the string referenced by this <see cref="ICorDebugStringValue"/> object.</param>
        public HRESULT TryGetLength(out int pcchString)
        {
            /*HRESULT GetLength(out int pcchString);*/
            return Raw.GetLength(out pcchString);
        }

        #endregion
        #region GetString

        /// <summary>
        /// Gets the string referenced by this <see cref="ICorDebugStringValue"/>.
        /// </summary>
        /// <returns>[out] An array that stores the retrieved string.</returns>
        public string GetString()
        {
            HRESULT hr;
            string szStringResult;

            if ((hr = TryGetString(out szStringResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return szStringResult;
        }

        /// <summary>
        /// Gets the string referenced by this <see cref="ICorDebugStringValue"/>.
        /// </summary>
        /// <param name="szStringResult">[out] An array that stores the retrieved string.</param>
        public HRESULT TryGetString(out string szStringResult)
        {
            /*HRESULT GetString([In] int cchString, out int pcchString, [Out] StringBuilder szString);*/
            int cchString = 0;
            int pcchString;
            StringBuilder szString = null;
            HRESULT hr = Raw.GetString(cchString, out pcchString, szString);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER)
                goto fail;

            cchString = pcchString;
            szString = new StringBuilder(pcchString);
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