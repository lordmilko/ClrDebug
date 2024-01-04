using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcSymbolSetSimpleInlineSourceLineResolution.FindSourceLineByOffsetAndInlineSymbol"/> method.
    /// </summary>
    [DebuggerDisplay("sourceFileName = {sourceFileName}, sourceLine = {sourceLine}, lineDisplacement = {lineDisplacement}")]
    public struct FindSourceLineByOffsetAndInlineSymbolResult
    {
        public string sourceFileName { get; }

        public long sourceLine { get; }

        public long lineDisplacement { get; }

        public FindSourceLineByOffsetAndInlineSymbolResult(string sourceFileName, long sourceLine, long lineDisplacement)
        {
            this.sourceFileName = sourceFileName;
            this.sourceLine = sourceLine;
            this.lineDisplacement = lineDisplacement;
        }
    }
}
