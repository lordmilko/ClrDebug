using System.Text;

namespace ClrDebug
{
    /// <summary>
    /// Represents the debug symbol information for an instance field.
    /// </summary>
    /// <remarks>
    /// The <see cref="ICorDebugInstanceFieldSymbol"/> interface is used to retrieve the debug symbol information for an instance field.
    /// </remarks>
    public class CorDebugInstanceFieldSymbol : ComObject<ICorDebugInstanceFieldSymbol>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugInstanceFieldSymbol"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugInstanceFieldSymbol(ICorDebugInstanceFieldSymbol raw) : base(raw)
        {
        }

        #region ICorDebugInstanceFieldSymbol
        #region Name

        /// <summary>
        /// Gets the name of the instance field.
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
        /// Gets the name of the instance field.
        /// </summary>
        /// <param name="szNameResult">[out] A character array that stores the returned name.</param>
        public HRESULT TryGetName(out string szNameResult)
        {
            /*HRESULT GetName([In] int cchName, [Out] out int pcchName, [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder szName);*/
            int cchName = 0;
            int pcchName;
            StringBuilder szName;
            HRESULT hr = Raw.GetName(cchName, out pcchName, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cchName = pcchName;
            szName = new StringBuilder(cchName);
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
        /// Gets the size in bytes of the instance field.
        /// </summary>
        public int Size
        {
            get
            {
                int pcbSize;
                TryGetSize(out pcbSize).ThrowOnNotOK();

                return pcbSize;
            }
        }

        /// <summary>
        /// Gets the size in bytes of the instance field.
        /// </summary>
        /// <param name="pcbSize">[out] A pointer to length of the field.</param>
        public HRESULT TryGetSize(out int pcbSize)
        {
            /*HRESULT GetSize([Out] out int pcbSize);*/
            return Raw.GetSize(out pcbSize);
        }

        #endregion
        #region Offset

        /// <summary>
        /// Gets the offset in bytes of this instance field in its parent class.
        /// </summary>
        public int Offset
        {
            get
            {
                int pcbOffset;
                TryGetOffset(out pcbOffset).ThrowOnNotOK();

                return pcbOffset;
            }
        }

        /// <summary>
        /// Gets the offset in bytes of this instance field in its parent class.
        /// </summary>
        /// <param name="pcbOffset">A pointer to the number of bytes that this instance field is offset in its parent class.</param>
        public HRESULT TryGetOffset(out int pcbOffset)
        {
            /*HRESULT GetOffset([Out] out int pcbOffset);*/
            return Raw.GetOffset(out pcbOffset);
        }

        #endregion
        #endregion
        
        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
