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
        public uint FileSize { get; }

        /// <summary>
        /// A pointer to the displacement value of the file.
        /// </summary>
        public ulong Displacement { get; }

        public GetLineByInlineContextResult(string fileBuffer, uint fileSize, ulong displacement)
        {
            FileBuffer = fileBuffer;
            FileSize = fileSize;
            Displacement = displacement;
        }
    }
}
