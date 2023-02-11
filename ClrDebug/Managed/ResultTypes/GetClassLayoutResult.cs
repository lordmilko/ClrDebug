using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.GetClassLayout"/> method.
    /// </summary>
    [DebuggerDisplay("rFieldOffset = {rFieldOffset}, pulClassSize = {pulClassSize}")]
    public struct GetClassLayoutResult
    {
        /// <summary>
        /// An array of COR_FIELD_OFFSET structures, each of which contains the tokens and offsets of the class's fields.
        /// </summary>
        public COR_FIELD_OFFSET[] rFieldOffset { get; }

        /// <summary>
        /// A pointer to a location that contains the size, in bytes, of the class.
        /// </summary>
        public int pulClassSize { get; }

        public GetClassLayoutResult(COR_FIELD_OFFSET[] rFieldOffset, int pulClassSize)
        {
            this.rFieldOffset = rFieldOffset;
            this.pulClassSize = pulClassSize;
        }
    }
}
