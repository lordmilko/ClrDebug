using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugHostFunctionLocalStorage.ValidRange"/> property.
    /// </summary>
    [DebuggerDisplay("start = {start}, end = {end}, guaranteed = {guaranteed}")]
    public struct GetValidRangeResult
    {
        public long start { get; }

        public long end { get; }

        public bool guaranteed { get; }

        public GetValidRangeResult(long start, long end, bool guaranteed)
        {
            this.start = start;
            this.end = end;
            this.guaranteed = guaranteed;
        }
    }
}
