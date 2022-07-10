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
        public uint FileSize { get; }

        /// <summary>
        /// A pointer to the displacement value of the file.
        /// </summary>
        public ulong Displacement { get; }

        public GetLineByInlineContextWideResult(string fileBuffer, uint fileSize, ulong displacement)
        {
            FileBuffer = fileBuffer;
            FileSize = fileSize;
            Displacement = displacement;
        }
    }
}
