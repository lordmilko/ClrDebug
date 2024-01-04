using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcSymbolSetSimpleSourceLineResolution.FindSourceLineByOffset"/> method.
    /// </summary>
    [DebuggerDisplay("sourceFileName = {sourceFileName}, sourceLine = {sourceLine}, lineDisplacement = {lineDisplacement}")]
    public struct FindSourceLineByOffsetResult
    {
        public string sourceFileName { get; }

        public long sourceLine { get; }

        public long lineDisplacement { get; }

        public FindSourceLineByOffsetResult(string sourceFileName, long sourceLine, long lineDisplacement)
        {
            this.sourceFileName = sourceFileName;
            this.sourceLine = sourceLine;
            this.lineDisplacement = lineDisplacement;
        }
    }
}
