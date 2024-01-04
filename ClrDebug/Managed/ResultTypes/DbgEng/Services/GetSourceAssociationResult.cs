using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcStackProviderFrameAttributes.SourceAssociation"/> property.
    /// </summary>
    [DebuggerDisplay("sourceFile = {sourceFile}, sourceLine = {sourceLine}, sourceColumn = {sourceColumn}")]
    public struct GetSourceAssociationResult
    {
        public string sourceFile { get; }

        public long sourceLine { get; }

        public long sourceColumn { get; }

        public GetSourceAssociationResult(string sourceFile, long sourceLine, long sourceColumn)
        {
            this.sourceFile = sourceFile;
            this.sourceLine = sourceLine;
            this.sourceColumn = sourceColumn;
        }
    }
}
