using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugHostMemory.ReadIntrinsics"/> method.
    /// </summary>
    [DebuggerDisplay("vals = {vals}, intrinsicsRead = {intrinsicsRead}")]
    public struct ReadIntrinsicsResult
    {
        public object[] vals { get; }

        public long intrinsicsRead { get; }

        public ReadIntrinsicsResult(object[] vals, long intrinsicsRead)
        {
            this.vals = vals;
            this.intrinsicsRead = intrinsicsRead;
        }
    }
}
