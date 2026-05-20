namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Supports the debug output stream.
    /// </summary>
    public class DebugOutputStream : ComObject<IDebugOutputStream>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugOutputStream"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugOutputStream(IDebugOutputStream raw) : base(raw)
        {
        }

        #region IDebugOutputStream
        #region Write

        /// <summary>
        /// Writes to the debug output stream.
        /// </summary>
        /// <param name="text">[in] A pointer to a Unicode character string of content to write.</param>
        public void Write(string text)
        {
            TryWrite(text).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Writes to the debug output stream.
        /// </summary>
        /// <param name="text">[in] A pointer to a Unicode character string of content to write.</param>
        /// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
        public HRESULT TryWrite(string text)
        {
            /*HRESULT Write(
            [MarshalAs(UnmanagedType.LPWStr), In] string text);*/
            return Raw.Write(text);
        }

        #endregion
        #endregion
    }
}
