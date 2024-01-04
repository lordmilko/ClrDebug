using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugSymbols.GetLineByInlineContextWide"/> method.
    /// </summary>
    [DebuggerDisplay("FileBuffer = {FileBuffer}, FileSize = {FileSize}, Displacement = {Displacement}")]
    public struct GetLineByInlineContextWideResult
    {
        /// <summary>
        /// A pointer to a buffer for a Unicode character string.
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

        public GetLineByInlineContextWideResult(string fileBuffer, int fileSize, long displacement)
        {
            FileBuffer = fileBuffer;
            FileSize = fileSize;
            Displacement = displacement;
        }
    }
}
