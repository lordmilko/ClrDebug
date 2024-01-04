using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugHostFunctionIntrospection.FindContainingCodeRangeByRVA"/> method.
    /// </summary>
    [DebuggerDisplay("rangeStart = {rangeStart.ToString(),nq}, rangeEnd = {rangeEnd.ToString(),nq}")]
    public struct FindContainingCodeRangeByRVAResult
    {
        public Location rangeStart { get; }

        public Location rangeEnd { get; }

        public FindContainingCodeRangeByRVAResult(Location rangeStart, Location rangeEnd)
        {
            this.rangeStart = rangeStart;
            this.rangeEnd = rangeEnd;
        }
    }
}
