namespace ClrDebug.DbgEng
{
    public class SvcSymbolSetScope : ComObject<ISvcSymbolSetScope>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolSetScope"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolSetScope(ISvcSymbolSetScope raw) : base(raw)
        {
        }

        #region ISvcSymbolSetScope
        #region EnumerateArguments

        public SvcSymbolSetEnumerator EnumerateArguments()
        {
            SvcSymbolSetEnumerator enumeratorResult;
            TryEnumerateArguments(out enumeratorResult).ThrowDbgEngNotOK();

            return enumeratorResult;
        }

        public HRESULT TryEnumerateArguments(out SvcSymbolSetEnumerator enumeratorResult)
        {
            /*HRESULT EnumerateArguments(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetEnumerator enumerator);*/
            ISvcSymbolSetEnumerator enumerator;
            HRESULT hr = Raw.EnumerateArguments(out enumerator);

            if (hr == HRESULT.S_OK)
                enumeratorResult = enumerator == null ? null : new SvcSymbolSetEnumerator(enumerator);
            else
                enumeratorResult = default(SvcSymbolSetEnumerator);

            return hr;
        }

        #endregion
        #region EnumerateLocals

        public SvcSymbolSetEnumerator EnumerateLocals()
        {
            SvcSymbolSetEnumerator enumeratorResult;
            TryEnumerateLocals(out enumeratorResult).ThrowDbgEngNotOK();

            return enumeratorResult;
        }

        public HRESULT TryEnumerateLocals(out SvcSymbolSetEnumerator enumeratorResult)
        {
            /*HRESULT EnumerateLocals(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetEnumerator enumerator);*/
            ISvcSymbolSetEnumerator enumerator;
            HRESULT hr = Raw.EnumerateLocals(out enumerator);

            if (hr == HRESULT.S_OK)
                enumeratorResult = enumerator == null ? null : new SvcSymbolSetEnumerator(enumerator);
            else
                enumeratorResult = default(SvcSymbolSetEnumerator);

            return hr;
        }

        #endregion
        #endregion
    }
}
