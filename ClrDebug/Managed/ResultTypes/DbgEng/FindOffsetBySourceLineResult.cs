using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcSymbolSetSimpleSourceLineResolution.FindOffsetBySourceLine"/> method.
    /// </summary>
    [DebuggerDisplay("moduleOffset = {moduleOffset}, actualSourceFileName = {actualSourceFileName}, returnedLine = {returnedLine}")]
    public struct FindOffsetBySourceLineResult
    {
        public long moduleOffset { get; }

        public string actualSourceFileName { get; }

        public long returnedLine { get; }

        public FindOffsetBySourceLineResult(long moduleOffset, string actualSourceFileName, long returnedLine)
        {
            this.moduleOffset = moduleOffset;
            this.actualSourceFileName = actualSourceFileName;
            this.returnedLine = returnedLine;
        }
    }
}
