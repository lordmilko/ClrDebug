namespace ClrDebug.DbgEng
{
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

        public SvcSymbol LexicalParent
        {
            get
            {
                SvcSymbol lexicalParentResult;
                TryGetLexicalParent(out lexicalParentResult).ThrowDbgEngNotOK();

                return lexicalParentResult;
            }
        }

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
