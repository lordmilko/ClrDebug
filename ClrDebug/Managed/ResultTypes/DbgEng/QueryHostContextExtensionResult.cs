using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugHostExtensibility.QueryHostContextExtension"/> method.
    /// </summary>
    [DebuggerDisplay("blobId = {blobId}, blobSize = {blobSize}")]
    public struct QueryHostContextExtensionResult
    {
        public int blobId { get; }

        public int blobSize { get; }

        public QueryHostContextExtensionResult(int blobId, int blobSize)
        {
            this.blobId = blobId;
            this.blobSize = blobSize;
        }
    }
}
