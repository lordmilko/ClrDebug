using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugSymbols.GetLineByInlineContextWide"/> method.
    /// </summary>
    [DebuggerDisplay("Line = {Line}, FileBuffer = {FileBuffer}, Displacement = {Displacement}")]
    public struct GetLineByInlineContextWideResult
    {
        /// <summary>
        /// A pointer to the returned line.
        /// </summary>
        public int Line { get; }

        /// <summary>
        /// A pointer to a buffer for a Unicode character string.
        /// </summary>
        public string FileBuffer { get; }

        /// <summary>
        /// A pointer to the displacement value of the file.
        /// </summary>
        public long Displacement { get; }

        public GetLineByInlineContextWideResult(int line, string fileBuffer, long displacement)
        {
            Line = line;
            FileBuffer = fileBuffer;
            Displacement = displacement;
        }
    }
}
