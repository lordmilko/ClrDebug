using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedDocument.GetSourceRange"/> method.
    /// </summary>
    [DebuggerDisplay("pcSourceBytes = {pcSourceBytes}, source = {source}")]
    public struct GetSourceRangeResult
    {
        /// <summary>
        /// [out] A pointer to a variable that receives the source size.
        /// </summary>
        public int pcSourceBytes { get; }

        /// <summary>
        /// [out] The size and length of the specified range of the source document, in bytes.
        /// </summary>
        public byte[] source { get; }

        public GetSourceRangeResult(int pcSourceBytes, byte[] source)
        {
            this.pcSourceBytes = pcSourceBytes;
            this.source = source;
        }
    }
}