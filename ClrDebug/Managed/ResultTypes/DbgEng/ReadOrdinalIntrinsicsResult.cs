using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugHostMemory.ReadOrdinalIntrinsics"/> method.
    /// </summary>
    [DebuggerDisplay("vals = {vals}, intrinsicsRead = {intrinsicsRead}")]
    public struct ReadOrdinalIntrinsicsResult
    {
        public object[] vals { get; }

        public long intrinsicsRead { get; }

        public ReadOrdinalIntrinsicsResult(object[] vals, long intrinsicsRead)
        {
            this.vals = vals;
            this.intrinsicsRead = intrinsicsRead;
        }
    }
}
