using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugHostTaggedUnionRangeEnumerator.Next"/> property.
    /// </summary>
    [DebuggerDisplay("pLow = {pLow}, pHigh = {pHigh}")]
    public struct DebugHostTaggedUnionRangeEnumerator_GetNextResult
    {
        public object pLow { get; }

        public object pHigh { get; }

        public DebugHostTaggedUnionRangeEnumerator_GetNextResult(object pLow, object pHigh)
        {
            this.pLow = pLow;
            this.pHigh = pHigh;
        }
    }
}
