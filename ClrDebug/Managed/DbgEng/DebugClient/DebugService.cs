namespace ClrDebug.DbgEng
{
    public class DebugService : ComObject<IDebugService>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugService"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugService(IDebugService raw) : base(raw)
        {
        }
    }
}
