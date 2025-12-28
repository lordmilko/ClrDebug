using static ClrDebug.Extensions;

namespace ClrDebug
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
                int pcchString;
                TryGetLength(out pcchString).ThrowOnNotOK();

                return pcchString;
            }
        }

        /// <summary>
        /// Gets the number of characters in the string referenced by this <see cref="ICorDebugStringValue"/>.
        /// </summary>
        /// <param name="pcchString">[out] A pointer to a value that specifies the length of the string referenced by this <see cref="ICorDebugStringValue"/> object.</param>
        public HRESULT TryGetLength(out int pcchString)
        {
            /*HRESULT GetLength(
            [Out] out int pcchString);*/
            return Raw.GetLength(out pcchString);
        }

        #endregion
        #region GetString

        /// <summary>
        /// Gets the string referenced by this <see cref="ICorDebugStringValue"/>.
        /// </summary>
        /// <param name="cchString">[in] The size of the szString array.</param>
        /// <returns>[out] An array that stores the retrieved string.</returns>
        public string GetString(int cchString)
        {
            string szStringResult;
            TryGetString(cchString, out szStringResult).ThrowOnNotOK();

            return szStringResult;
        }

        /// <summary>
        /// Gets the string referenced by this <see cref="ICorDebugStringValue"/>.
        /// </summary>
        /// <param name="cchString">[in] The size of the szString array.</param>
        /// <param name="szStringResult">[out] An array that stores the retrieved string.</param>
        public HRESULT TryGetString(int cchString, out string szStringResult)
        {
            /*HRESULT GetString(
            [In] int cchString,
            [Out] out int pcchString,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeParamIndex = 0)] char[] szString);*/
            int pcchString;
            char[] szString = new char[cchString];
            HRESULT hr = Raw.GetString(cchString, out pcchString, szString);

            if (hr == HRESULT.S_OK)
                szStringResult = new string(szString, 0, pcchString);
            else
                szStringResult = default(string);

            return hr;
        }

        #endregion
        #endregion
    }
}
