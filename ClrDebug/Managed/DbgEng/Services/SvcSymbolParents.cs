namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Any symbol which supports finding its parent (lexical or otherwise) supports this interface. Simple symbol providers which only do basic address -&gt; name and name -&gt; address mapping need not implement this interface.<para/>
    /// This interface should be considered *OPTIONAL* -- even in the presence of ISvcSymbolChildren.
    /// </summary>
    public class SvcSymbolParents : ComObject<ISvcSymbolParents>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolParents"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolParents(ISvcSymbolParents raw) : base(raw)
        {
        }

        #region ISvcSymbolParents
        #region LexicalParent

        /// <summary>
        /// Gets the lexical parent of the given symbol.
        /// </summary>
        public SvcSymbol LexicalParent
        {
            get
            {
                SvcSymbol lexicalParentResult;
                TryGetLexicalParent(out lexicalParentResult).ThrowDbgEngNotOK();

                return lexicalParentResult;
            }
        }

        /// <summary>
        /// Gets the lexical parent of the given symbol.
        /// </summary>
        public HRESULT TryGetLexicalParent(out SvcSymbol lexicalParentResult)
        {
            /*HRESULT GetLexicalParent(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol lexicalParent);*/
            ISvcSymbol lexicalParent;
            HRESULT hr = Raw.GetLexicalParent(out lexicalParent);

            if (hr == HRESULT.S_OK)
                lexicalParentResult = lexicalParent == null ? null : new SvcSymbol(lexicalParent);
            else
                lexicalParentResult = default(SvcSymbol);

            return hr;
        }

        #endregion
        #endregion
    }
}
