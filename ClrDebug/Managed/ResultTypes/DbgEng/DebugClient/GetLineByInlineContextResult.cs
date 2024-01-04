using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugSymbols.GetLineByInlineContext"/> method.
    /// </summary>
    [DebuggerDisplay("FileBuffer = {FileBuffer}, FileSize = {FileSize}, Displacement = {Displacement}")]
    public struct GetLineByInlineContextResult
    {
        /// <summary>
        /// A pointer to an output buffer.
        /// </summary>
        public string FileBuffer { get; }

        /// <summary>
        /// A pointer to the length of the file.
        /// </summary>
        public int FileSize { get; }

        /// <summary>
        /// A pointer to the displacement value of the file.
        /// </summary>
        public long Displacement { get; }

        public GetLineByInlineContextResult(string fileBuffer, int fileSize, long displacement)
        {
            FileBuffer = fileBuffer;
            FileSize = fileSize;
            Displacement = displacement;
        }
    }
}
