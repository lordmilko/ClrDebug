using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcImageVersionParser.GetVersionNumber"/> method.
    /// </summary>
    [DebuggerDisplay("p1 = {p1}, p2 = {p2}, p3 = {p3}, p4 = {p4}")]
    public struct GetVersionNumberResult
    {
        public long p1 { get; }

        public long p2 { get; }

        public long p3 { get; }

        public long p4 { get; }

        public GetVersionNumberResult(long p1, long p2, long p3, long p4)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.p4 = p4;
        }
    }
}
