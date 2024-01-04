using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcJITSymbolProvider.LocateSymbolsForJITSegment"/> method.
    /// </summary>
    [DebuggerDisplay("symbolSet = {symbolSet?.ToString(),nq}, image = {image?.ToString(),nq}")]
    public struct LocateSymbolsForJITSegmentResult
    {
        public SvcSymbolSet symbolSet { get; }

        public SvcModule image { get; }

        public LocateSymbolsForJITSegmentResult(SvcSymbolSet symbolSet, SvcModule image)
        {
            this.symbolSet = symbolSet;
            this.image = image;
        }
    }
}
