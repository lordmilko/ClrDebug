using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugHostModule.Range"/> property.
    /// </summary>
    [DebuggerDisplay("moduleStart = {moduleStart.ToString(),nq}, moduleEnd = {moduleEnd.ToString(),nq}")]
    public struct GetRangeResult
    {
        public Location moduleStart { get; }

        public Location moduleEnd { get; }

        public GetRangeResult(Location moduleStart, Location moduleEnd)
        {
            this.moduleStart = moduleStart;
            this.moduleEnd = moduleEnd;
        }
    }
}
