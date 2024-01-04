using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An enumerator which runs through children of a symbol.
    /// </summary>
    public abstract class DebugHostSymbolEnumerator : ComObject<IDebugHostSymbolEnumerator>
    {
        public static DebugHostSymbolEnumerator New(IDebugHostSymbolEnumerator value)
        {
            if (value == null)
                return null;

            if (value is IDebugHostSymbolSubstitutionEnumerator)
                return new DebugHostSymbolSubstitutionEnumerator((IDebugHostSymbolSubstitutionEnumerator) value);

            throw new NotImplementedException("Encountered an 'IDebugHostSymbolEnumerator' interface of an unknown type. Cannot create wrapper type.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostSymbolEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        protected DebugHostSymbolEnumerator(IDebugHostSymbolEnumerator raw) : base(raw)
        {
        }

        #region IDebugHostSymbolEnumerator
        #region Next

        /// <summary>
        /// Moves the iterator forward and fetches the next symbol in the set. E_BOUNDS will be returned when the enumerator hits the end of the set.
        /// </summary>
        public DebugHostSymbol Next
        {
            get
            {
                DebugHostSymbol symbolResult;
                TryGetNext(out symbolResult).ThrowDbgEngNotOK();

                return symbolResult;
            }
        }

        /// <summary>
        /// Moves the iterator forward and fetches the next symbol in the set. E_BOUNDS will be returned when the enumerator hits the end of the set.
        /// </summary>
        /// <param name="symbolResult">The next enumerated symbol will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetNext(out DebugHostSymbol symbolResult)
        {
            /*HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbol symbol);*/
            IDebugHostSymbol symbol;
            HRESULT hr = Raw.GetNext(out symbol);

            if (hr == HRESULT.S_OK)
                symbolResult = DebugHostSymbol.New(symbol);
            else
                symbolResult = default(DebugHostSymbol);

            return hr;
        }

        #endregion
        #region Reset

        /// <summary>
        /// Resets the enumerator to its initial state. A subsequent GetNext call will return the first symbol in the set in enumerator order.
        /// </summary>
        public void Reset()
        {
            TryReset().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Resets the enumerator to its initial state. A subsequent GetNext call will return the first symbol in the set in enumerator order.
        /// </summary>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryReset()
        {
            /*HRESULT Reset();*/
            return Raw.Reset();
        }

        #endregion
        #endregion
    }
}
