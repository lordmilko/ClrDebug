namespace ClrDebug
{
    /// <summary>
    /// Disposes of unmanaged resources.
    /// </summary>
    public class SymUnmanagedDispose : ComObject<ISymUnmanagedDispose>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SymUnmanagedDispose"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SymUnmanagedDispose(ISymUnmanagedDispose raw) : base(raw)
        {
        }

        #region ISymUnmanagedDispose
        #region Destroy

        /// <summary>
        /// Causes the underlying object to release all internal references and return failure on any subsequent method calls.
        /// </summary>
        public void Destroy()
        {
            TryDestroy().ThrowOnNotOK();
        }

        /// <summary>
        /// Causes the underlying object to release all internal references and return failure on any subsequent method calls.
        /// </summary>
        /// <returns>S_OK if the method succeeds; otherwise, E_FAIL or some other error code.</returns>
        public HRESULT TryDestroy()
        {
            /*HRESULT Destroy();*/
            return Raw.Destroy();
        }

        #endregion
        #endregion
    }
}
