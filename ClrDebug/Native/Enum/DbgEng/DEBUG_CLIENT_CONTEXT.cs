namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Contains a debug client constant to provide to the <see cref="IDebugClient7.SetClientContext"/> method.
    /// </summary>
    public struct DEBUG_CLIENT_CONTEXT
    {
        /// <summary>
        /// A size value.
        /// </summary>
        public int cbSize;

        /// <summary>
        /// A client value.
        /// </summary>
        public int eClient;
    }
}