namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a lexical scope within code. A scope can implement ISvcSymbolChildren to allow query of other children underneath the scope.
    /// </summary>
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

        /// <summary>
        /// If the scope is a function scope (or is a lexical sub-scope of a function), this enumerates the arguments of the function.<para/>
        /// This will fail for a scope for which arguments are inappropriate.
        /// </summary>
        public SvcSymbolSetEnumerator EnumerateArguments()
        {
            SvcSymbolSetEnumerator enumeratorResult;
            TryEnumerateArguments(out enumeratorResult).ThrowDbgEngNotOK();

            return enumeratorResult;
        }

        /// <summary>
        /// If the scope is a function scope (or is a lexical sub-scope of a function), this enumerates the arguments of the function.<para/>
        /// This will fail for a scope for which arguments are inappropriate.
        /// </summary>
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

        /// <summary>
        /// Enumerates the locals within the scope.
        /// </summary>
        public SvcSymbolSetEnumerator EnumerateLocals()
        {
            SvcSymbolSetEnumerator enumeratorResult;
            TryEnumerateLocals(out enumeratorResult).ThrowDbgEngNotOK();

            return enumeratorResult;
        }

        /// <summary>
        /// Enumerates the locals within the scope.
        /// </summary>
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
