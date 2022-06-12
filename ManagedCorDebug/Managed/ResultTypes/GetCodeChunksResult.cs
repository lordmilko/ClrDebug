using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugCode.GetCodeChunks"/> method.
    /// </summary>
    [DebuggerDisplay("pcnumChunks = {pcnumChunks}, chunks = {chunks}")]
    public struct GetCodeChunksResult
    {
        /// <summary>
        /// [out] The number of chunks returned in the chunks array.
        /// </summary>
        public int pcnumChunks { get; }

        /// <summary>
        /// [out] An array of "CodeChunkInfo" structures, each of which represents a single chunk of code. If the value of cbufSize is 0, this parameter can be null.
        /// </summary>
        public CodeChunkInfo[] chunks { get; }

        public GetCodeChunksResult(int pcnumChunks, CodeChunkInfo[] chunks)
        {
            this.pcnumChunks = pcnumChunks;
            this.chunks = chunks;
        }
    }
}