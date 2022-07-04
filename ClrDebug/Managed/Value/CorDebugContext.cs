namespace ClrDebug
{
    /// <summary>
    /// Represents a context object. This interface has not been implemented yet.
    /// </summary>
    public class CorDebugContext : CorDebugObjectValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugContext"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugContext(ICorDebugContext raw) : base(raw)
        {
        }

        #region ICorDebugContext

        public new ICorDebugContext Raw => (ICorDebugContext) base.Raw;

        #endregion
    }
}
