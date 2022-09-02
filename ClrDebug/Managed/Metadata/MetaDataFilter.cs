namespace ClrDebug
{
    /// <summary>
    /// Provides methods for marking and filtering metadata tokens to avoid repeating actions that have already been taken.
    /// </summary>
    public class MetaDataFilter : ComObject<IMetaDataFilter>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetaDataFilter"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public MetaDataFilter(IMetaDataFilter raw) : base(raw)
        {
        }

        #region IMetaDataFilter
        #region UnmarkAll

        /// <summary>
        /// Removes the processing marks from all the tokens in the current metadata scope.
        /// </summary>
        public void UnmarkAll()
        {
            TryUnmarkAll().ThrowOnNotOK();
        }

        /// <summary>
        /// Removes the processing marks from all the tokens in the current metadata scope.
        /// </summary>
        public HRESULT TryUnmarkAll()
        {
            /*HRESULT UnmarkAll();*/
            return Raw.UnmarkAll();
        }

        #endregion
        #region MarkToken

        /// <summary>
        /// Sets a value indicating that the specified metadata token has been processed.
        /// </summary>
        /// <param name="tk">[in] The token to mark as processed.</param>
        public void MarkToken(mdToken tk)
        {
            TryMarkToken(tk).ThrowOnNotOK();
        }

        /// <summary>
        /// Sets a value indicating that the specified metadata token has been processed.
        /// </summary>
        /// <param name="tk">[in] The token to mark as processed.</param>
        public HRESULT TryMarkToken(mdToken tk)
        {
            /*HRESULT MarkToken(
            [In] mdToken tk);*/
            return Raw.MarkToken(tk);
        }

        #endregion
        #region IsTokenMarked

        /// <summary>
        /// Gets a value indicating whether the specified metadata token has been marked as processed.
        /// </summary>
        /// <param name="tk">[in] The token to examine for a processing mark.</param>
        /// <returns>[out] A value that is true if tk has been processed; otherwise false.</returns>
        public int IsTokenMarked(mdToken tk)
        {
            int pIsMarked;
            TryIsTokenMarked(tk, out pIsMarked).ThrowOnNotOK();

            return pIsMarked;
        }

        /// <summary>
        /// Gets a value indicating whether the specified metadata token has been marked as processed.
        /// </summary>
        /// <param name="tk">[in] The token to examine for a processing mark.</param>
        /// <param name="pIsMarked">[out] A value that is true if tk has been processed; otherwise false.</param>
        public HRESULT TryIsTokenMarked(mdToken tk, out int pIsMarked)
        {
            /*HRESULT IsTokenMarked(
            [In] mdToken tk,
            [Out] out int pIsMarked);*/
            return Raw.IsTokenMarked(tk, out pIsMarked);
        }

        #endregion
        #endregion
    }
}
